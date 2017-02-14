Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class LaunchForm
    'Tilesets
    'Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub() End Sub))
    '数据结构：使用图像存储地图
    '   图像尺寸即地图单元格规模
    '   R通道储存地图层元素标识
    '   G通道暂留
    '   B通道储存遮罩层元素标识
    '   A通道暂留

    'TODO:数据结构重构：
    '   R通道用于储存地图层元素标识（图块数量不可超过一个字节）
    '   G通道和B通道合并为Int16结构用于储存遮罩层元素标识（图块数量不可超过两个字节）
    '   A通道一个字节拆分为8位（BitArray），前四位储存是否可以向四个方向移动，后四位储存是否存在洞穴或门或道具等

    Private Const MapCount As Integer = 67 '（0-66）
    Private Const MaskCount As Integer = 253 '(1-253)
    Dim MapFilePath As String '地图文件路径
    Dim MapWidth As Integer '地图规模宽度
    Dim MapHeight As Integer '地图规模高度
    Dim MapBitmap As Bitmap '渲染后的可视化地图层
    Dim MapDatas() As Byte '从内存中读取的地图数据字节数组（四个字节为一个分组，分组内通道顺序：R、G、B、A）
    Dim MouseDownLocation As Point '记录鼠标在地图显示控件上按下时的位置，用于拖动
    Dim ZoomRate As Single = 1.0 '缩放倍率
    Dim GroupIndex As Byte = 0 '图块所在分组（0：Map;1：Mask）
    Dim TilesetIndex As Short = 0 '图块标识

    Private Sub LaunchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Me.SetBounds(0, 0, My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        LaunchPanel.SetBounds((Me.Width - 600) \ 2, (Me.Height - 485) \ 2, 600, 485)
        MapPictureBox.SetBounds(0, 0, Me.Width, Me.Height)
        SaveButton.Left = Me.Width - 1
        BackButton.Left = Me.Width - 1
        TilesetListView.SetBounds(0, Me.Height - 1, Me.Width, 360)
    End Sub

    Private Sub LaunchForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadTilesetsToListview()
    End Sub

#Region "启动菜单事件"

    Private Sub CreateMapButton_Click(sender As Object, e As EventArgs) Handles CreateMapButton.Click
        CreateNewMapPanel.Show()
    End Sub

    Private Sub EditMapButton_Click(sender As Object, e As EventArgs) Handles EditMapButton.Click
        Dim OpenMapDialog As OpenFileDialog = New OpenFileDialog With {
            .DefaultExt = ".lmap",
            .Filter = "LeonRPG地图文件|*.lmap|所有文件|*.*",
            .FilterIndex = 2,
            .Multiselect = False,
            .Title = "请选择LeonRPG地图文件"}
        If OpenMapDialog.ShowDialog <> DialogResult.OK Then Exit Sub
        LaunchPanel.Hide()
        MapPictureBox.Show()
        MapFilePath = OpenMapDialog.FileName
        OpenMapFile()
        MapBitmap = CreateMapBitmap()
        MapPictureBox.Size = MapBitmap.Size
        MapPictureBox.BackgroundImage = MapBitmap
        SaveButton.Show()
        BackButton.Show()
        TilesetListView.Show()
        AddHandler MapPictureBox.MouseClick, AddressOf EditMapTileset
        AddHandler MapPictureBox.MouseWheel, AddressOf MapPictureBox_MouseWheel
        AddHandler MapPictureBox.MouseDown, AddressOf MapPictureBox_MouseDown
        AddHandler MapPictureBox.MouseUp, AddressOf MapPictureBox_MouseUp
        AddHandler MapPictureBox.DoubleClick, AddressOf MapPictureBox_DoubleClick
        AddHandler Me.DoubleClick, AddressOf MapPictureBox_DoubleClick
        AddHandler Me.MouseWheel, AddressOf MapPictureBox_MouseWheel
    End Sub

    Private Sub PlayMapButton_Click(sender As Object, e As EventArgs) Handles PlayMapButton.Click
        LaunchPanel.Hide()
    End Sub

    Private Sub ExitGameButton_Click(sender As Object, e As EventArgs) Handles ExitGameButton.Click
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub()
                                                                              Do While Me.Opacity > 0
                                                                                  Me.Opacity -= 0.1
                                                                                  Threading.Thread.Sleep(30)
                                                                              Loop
                                                                              Application.Exit()
                                                                          End Sub))
    End Sub
#End Region

#Region "侧面按钮事件"

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim SaveMapDialog As SaveFileDialog = New SaveFileDialog With {
            .DefaultExt = ".lmap",
            .Filter = "LeonRPG地图文件|*.lmap|所有文件|*.*",
            .FilterIndex = 2,
            .FileName = MapNameTextBox.Text,
            .Title = "请选择地图文件储存路径："}
        If SaveMapDialog.ShowDialog <> DialogResult.OK Then Exit Sub
        MapFilePath = SaveMapDialog.FileName
        SaveMapFile()
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        If MsgBox("确定要返回主菜单吗？未保存的修改将会被遗弃！", MsgBoxStyle.Question Or MsgBoxStyle.OkCancel, "确定要返回吗？") <> MsgBoxResult.Ok Then Exit Sub
        MapFilePath = vbNullString
        MapWidth = 0
        MapHeight = 0
        MapBitmap = Nothing
        Erase MapDatas
        MouseDownLocation = Point.Empty
        ZoomRate = 1.0
        GroupIndex = 0
        TilesetIndex = 0
        LaunchPanel.Show()
        SaveButton.Left = Me.Width - 1
        SaveButton.Hide()
        BackButton.Hide()
        BackButton.Left = Me.Width - 1
        TilesetListView.Hide()
        MapPictureBox.BackgroundImage = Nothing
        MapPictureBox.Size = Me.Size
        MapPictureBox.Hide()
        RemoveHandler MapPictureBox.MouseClick, AddressOf EditMapTileset
        RemoveHandler MapPictureBox.MouseWheel, AddressOf MapPictureBox_MouseWheel
        RemoveHandler MapPictureBox.MouseDown, AddressOf MapPictureBox_MouseDown
        RemoveHandler MapPictureBox.MouseUp, AddressOf MapPictureBox_MouseUp
        RemoveHandler MapPictureBox.DoubleClick, AddressOf MapPictureBox_DoubleClick
        RemoveHandler Me.DoubleClick, AddressOf MapPictureBox_DoubleClick
        RemoveHandler Me.MouseWheel, AddressOf MapPictureBox_MouseWheel
        GC.Collect()
    End Sub

#End Region

#Region "通用动态按钮事件"
    Private Sub CommandButton_MouseDown(Button As Label, e As MouseEventArgs) Handles CreateMapButton.MouseDown, EditMapButton.MouseDown, PlayMapButton.MouseDown, ExitGameButton.MouseDown, CancelButton.MouseDown, OKButton.MouseDown
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "2")
    End Sub

    Private Sub CommandButton_MouseEnter(Button As Label, e As EventArgs) Handles CreateMapButton.MouseEnter, EditMapButton.MouseEnter, PlayMapButton.MouseEnter, ExitGameButton.MouseEnter, CancelButton.MouseEnter, OKButton.MouseEnter
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "1")
    End Sub

    Private Sub CommandButton_MouseLeave(Button As Label, e As EventArgs) Handles CreateMapButton.MouseLeave, EditMapButton.MouseLeave, PlayMapButton.MouseLeave, ExitGameButton.MouseLeave, CancelButton.MouseLeave, OKButton.MouseLeave
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "0")
    End Sub

    Private Sub CommandButton_MouseUp(Button As Label, e As MouseEventArgs) Handles CreateMapButton.MouseUp, EditMapButton.MouseUp, PlayMapButton.MouseUp, ExitGameButton.MouseUp, CancelButton.MouseUp, OKButton.MouseUp
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "1")
    End Sub
#End Region

#Region "侧面隐藏按钮动态特效"
    Private Sub LateralButton_MouseDown(Button As Label, e As MouseEventArgs) Handles BackButton.MouseDown, SaveButton.MouseDown
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "2")
    End Sub

    Private Sub LateralButton_MouseEnter(sender As Object, e As EventArgs) Handles SaveButton.MouseEnter, BackButton.MouseEnter
        Dim Button As Label = CType(sender, Label)
        RemoveHandler Button.MouseEnter, AddressOf LateralButton_MouseEnter
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "1")
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub()
                                                                              Do While Button.Left + Button.Width > Me.Width + 20
                                                                                  Button.Left -= 20
                                                                                  Threading.Thread.Sleep(30)
                                                                              Loop
                                                                              Button.Left = Me.Width - Button.Width
                                                                              AddHandler Button.MouseLeave, AddressOf LateralButton_MouseLeave
                                                                          End Sub))
    End Sub

    Private Sub LateralButton_MouseLeave(sender As Object, e As EventArgs)
        Dim Button As Label = CType(sender, Label)
        RemoveHandler Button.MouseLeave, AddressOf LateralButton_MouseLeave
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "0")
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub()
                                                                              Do While Button.Left < Me.Width + 19
                                                                                  Button.Left += 20
                                                                                  Threading.Thread.Sleep(30)
                                                                              Loop
                                                                              Button.Left = Me.Width - 1
                                                                              AddHandler Button.MouseEnter, AddressOf LateralButton_MouseEnter
                                                                          End Sub))
    End Sub

    Private Sub LateralButton_MouseUp(Button As Label, e As MouseEventArgs)
        Button.Image = My.Resources.GameResource.ResourceManager.GetObject(Button.Tag & "1")
    End Sub
#End Region

#Region "读取或写入地图文件"

    ''' <summary>
    ''' 读取地图文件
    ''' </summary>
    Private Sub OpenMapFile()
        Dim MapData As Bitmap = Bitmap.FromFile(MapFilePath)
        MapWidth = MapData.Width
        MapHeight = MapData.Height
        Dim Data As BitmapData = MapData.LockBits(New Rectangle(0, 0, MapData.Width, MapData.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
        Dim DataUBound As Integer = MapData.Height * Data.Stride - 1
        ReDim MapDatas(DataUBound)
        Marshal.Copy(Data.Scan0, MapDatas, 0, DataUBound)
        MapData.UnlockBits(Data)
        Data = Nothing
        MapData = Nothing
    End Sub

    Private Sub SaveMapFile()
        Dim MapData As Bitmap = New Bitmap(MapWidth, MapHeight)
        Dim Data As BitmapData = MapData.LockBits(New Rectangle(0, 0, MapData.Width, MapData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb)
        Dim DataUBound As Integer = MapData.Height * Data.Stride - 1
        Marshal.Copy(MapDatas, 0, Data.Scan0, DataUBound)
        MapData.UnlockBits(Data)
        MapData.Save(MapFilePath, ImageFormat.Png)
        Data = Nothing
        MapData = Nothing
    End Sub

    Private Function CreateMapBitmap() As Bitmap
        Dim MapBitmap As Bitmap = New Bitmap(MapWidth * 32, MapHeight * 32)
        Dim Index As Integer = 0, DrawX As Integer = 0, DrawY As Integer = 0
        Using MapGraphics As Graphics = Graphics.FromImage(MapBitmap)
            For IndexY As Integer = 0 To MapHeight - 1
                For IndexX As Integer = 0 To MapWidth - 1
                    MapGraphics.DrawImage(My.Resources.GameResource.ResourceManager.GetObject("Map_" & (MapDatas(Index) Mod MapCount).ToString), DrawX, DrawY, 32, 32)
                    Index += 4 : DrawX += 32
                Next
                DrawX = 0 : DrawY += 32
            Next
            Index = 2 : DrawY = 0
            For IndexY As Integer = 0 To MapHeight - 1
                For IndexX As Integer = 0 To MapWidth - 1
                    If MapDatas(Index) > 0 Then MapGraphics.DrawImage(My.Resources.GameResource.ResourceManager.GetObject("Mask_" & (MapDatas(Index) Mod MaskCount).ToString), DrawX, DrawY, 32, 32)
                    Index += 4 : DrawX += 32
                Next
                DrawX = 0 : DrawY += 32
            Next
        End Using
        Return MapBitmap
    End Function

#End Region

#Region "鼠标拖动和缩放地图"
    Private Sub MapPictureBox_MouseWheel(sender As Object, e As MouseEventArgs)
        If Not MapPictureBox.Visible Then Exit Sub
        ZoomRate += e.Delta / 1000
        MapPictureBox.Width = MapBitmap.Width * ZoomRate
        MapPictureBox.Height = MapBitmap.Height * ZoomRate
        If MapPictureBox.Bottom < Me.Height AndAlso MapPictureBox.Height > Me.Height Then MapPictureBox.Top = Me.Height - MapPictureBox.Height
        If MapPictureBox.Right < Me.Width AndAlso MapPictureBox.Width > Me.Width Then MapPictureBox.Left = Me.Width - MapPictureBox.Width
    End Sub

    Private Sub MapPictureBox_MouseDown(sender As Object, e As MouseEventArgs)
        MouseDownLocation.X = e.X
        MouseDownLocation.Y = e.Y
        AddHandler MapPictureBox.MouseMove, AddressOf MapPictureBox_MouseMove
    End Sub

    Private Sub MapPictureBox_MouseUp(sender As Object, e As MouseEventArgs)
        RemoveHandler MapPictureBox.MouseMove, AddressOf MapPictureBox_MouseMove
    End Sub

    Private Sub MapPictureBox_MouseMove(sender As Object, e As MouseEventArgs)
        Dim NewX As Integer = MousePosition.X - MouseDownLocation.X
        Dim NewY As Integer = MousePosition.Y - MouseDownLocation.Y
        If NewX <= 0 AndAlso NewX + MapPictureBox.Width >= Me.Width Then MapPictureBox.Left = NewX
        If NewY <= 0 AndAlso NewY + MapPictureBox.Height >= Me.Height Then MapPictureBox.Top = NewY
    End Sub

    Private Sub MapPictureBox_DoubleClick(sender As Object, e As EventArgs)
        ZoomRate = 1
        MapPictureBox.Width = MapBitmap.Width
        MapPictureBox.Height = MapBitmap.Height
        MapPictureBox.Location = Point.Empty
    End Sub
#End Region

#Region "图块列表控件"
    Private Sub TilesetListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TilesetListView.SelectedIndexChanged
        If TilesetListView.SelectedItems.Count = 0 Then Exit Sub
        GroupIndex = CInt(TilesetListView.SelectedItems(0).Group.Tag)
        TilesetIndex = TilesetListView.SelectedIndices(0)
        If (GroupIndex = 1) Then TilesetIndex -= MapCount
    End Sub

    Private Sub TilesetListView_MouseEnter(sender As Object, e As EventArgs) Handles TilesetListView.MouseEnter
        RemoveHandler TilesetListView.MouseEnter, AddressOf TilesetListView_MouseEnter
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub()
                                                                              Do While TilesetListView.Top > Me.Height - TilesetListView.Height + 20
                                                                                  TilesetListView.Top -= 20
                                                                                  Threading.Thread.Sleep(30)
                                                                              Loop
                                                                              TilesetListView.Top = Me.Height - TilesetListView.Height
                                                                              AddHandler TilesetListView.MouseLeave, AddressOf TilesetListView_MouseLeave
                                                                          End Sub))
    End Sub

    Private Sub TilesetListView_MouseLeave(sender As Object, e As EventArgs)
        RemoveHandler TilesetListView.MouseLeave, AddressOf TilesetListView_MouseLeave
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(Sub()
                                                                              Do While TilesetListView.Top < Me.Height + 19
                                                                                  TilesetListView.Top += 20
                                                                                  Threading.Thread.Sleep(30)
                                                                              Loop
                                                                              TilesetListView.Top = Me.Height - 1
                                                                              AddHandler TilesetListView.MouseEnter, AddressOf TilesetListView_MouseEnter
                                                                          End Sub))
    End Sub
#End Region

#Region "功能函数"
    ''' <summary>
    ''' 加载图块到列表控件
    ''' </summary>
    Private Sub LoadTilesetsToListview()
        Dim TempImageList As ImageList = New ImageList With {.ImageSize = New Size(32, 32)}
        TilesetListView.LargeImageList = TempImageList
        For Index As Integer = 0 To MapCount - 1
            TempImageList.Images.Add(My.Resources.GameResource.ResourceManager.GetObject("Map_" & Index))
            TilesetListView.Items.Add(New ListViewItem(Index.ToString, Index, TilesetListView.Groups.Item(0)))
        Next
        TilesetListView.Items.Add(New ListViewItem("(无)", TilesetListView.Groups.Item(1)))
        For Index As Integer = 1 To MaskCount
            TempImageList.Images.Add(My.Resources.GameResource.ResourceManager.GetObject("Mask_" & Index))
            TilesetListView.Items.Add(New ListViewItem(Index.ToString, MapCount - 1 + Index, TilesetListView.Groups.Item(1)))
        Next
    End Sub

    Private Sub EditMapTileset(sender As Object, e As MouseEventArgs)
        Dim X As Integer = (e.X / ZoomRate) \ 32, Y As Integer = (e.Y / ZoomRate) \ 32, Index As Integer = 4 * (Y * MapWidth + X)
        Using MapGraphics As Graphics = Graphics.FromImage(MapBitmap)
            MapDatas(Index + 2 * GroupIndex) = TilesetIndex
            MapGraphics.DrawImage(My.Resources.GameResource.ResourceManager.GetObject("Map_" & (MapDatas(Index) Mod MapCount).ToString), X * 32, Y * 32, 32, 32)
            Index += 2
            If MapDatas(Index) > 0 Then
                MapGraphics.DrawImage(My.Resources.GameResource.ResourceManager.GetObject("Mask_" & (MapDatas(Index) Mod MaskCount).ToString), X * 32, Y * 32, 32, 32)
            End If
            MapPictureBox.BackgroundImage = MapBitmap
            MapPictureBox.Refresh()
        End Using
    End Sub
#End Region

#Region "新建地图面板"

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        CreateNewMapPanel.Hide()
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        If MapNameTextBox.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) > -1 Then MsgBox("地图名称含有不允许出现在文件名称中的字符，请修改！", MsgBoxStyle.Information, "地图名称含有非法字符...") : MapNameTextBox.Focus()
        CreateNewMapPanel.Hide()
        LaunchPanel.Hide()

        MapWidth = WidthNumericUpDown.Value
        MapHeight = HeightNumericUpDown.Value
        ReDim MapDatas(4 * MapHeight * MapWidth - 1)

        MapBitmap = CreateMapBitmap()
        MapPictureBox.Show()
        MapPictureBox.Size = MapBitmap.Size
        MapPictureBox.BackgroundImage = MapBitmap
        TilesetListView.Show()

        SaveButton.Show()
        BackButton.Show()
        AddHandler MapPictureBox.MouseClick, AddressOf EditMapTileset
        AddHandler MapPictureBox.MouseWheel, AddressOf MapPictureBox_MouseWheel
        AddHandler MapPictureBox.MouseDown, AddressOf MapPictureBox_MouseDown
        AddHandler MapPictureBox.MouseUp, AddressOf MapPictureBox_MouseUp
        AddHandler MapPictureBox.DoubleClick, AddressOf MapPictureBox_DoubleClick
        AddHandler Me.DoubleClick, AddressOf MapPictureBox_DoubleClick
        AddHandler Me.MouseWheel, AddressOf MapPictureBox_MouseWheel
    End Sub

#End Region

End Class
