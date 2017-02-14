<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LaunchForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LaunchForm))
        Dim ListViewGroup7 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("地图", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup8 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("遮罩", System.Windows.Forms.HorizontalAlignment.Left)
        Me.LaunchPanel = New System.Windows.Forms.Panel()
        Me.CreateNewMapPanel = New System.Windows.Forms.Panel()
        Me.OKButton = New System.Windows.Forms.Label()
        Me.CancelButton = New System.Windows.Forms.Label()
        Me.HeightNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.WidthNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MapNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MessageLabel = New System.Windows.Forms.Label()
        Me.ExitGameButton = New System.Windows.Forms.Label()
        Me.PlayMapButton = New System.Windows.Forms.Label()
        Me.EditMapButton = New System.Windows.Forms.Label()
        Me.LogoLabel = New System.Windows.Forms.Label()
        Me.CreateMapButton = New System.Windows.Forms.Label()
        Me.MapPictureBox = New System.Windows.Forms.PictureBox()
        Me.TilesetListView = New System.Windows.Forms.ListView()
        Me.SaveButton = New System.Windows.Forms.Label()
        Me.BackButton = New System.Windows.Forms.Label()
        Me.LaunchPanel.SuspendLayout()
        Me.CreateNewMapPanel.SuspendLayout()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LaunchPanel
        '
        Me.LaunchPanel.BackColor = System.Drawing.Color.Transparent
        Me.LaunchPanel.BackgroundImage = Global.LeonRPG.My.Resources.GameResource.LaunchMenuBGI
        Me.LaunchPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LaunchPanel.Controls.Add(Me.CreateNewMapPanel)
        Me.LaunchPanel.Controls.Add(Me.ExitGameButton)
        Me.LaunchPanel.Controls.Add(Me.PlayMapButton)
        Me.LaunchPanel.Controls.Add(Me.EditMapButton)
        Me.LaunchPanel.Controls.Add(Me.LogoLabel)
        Me.LaunchPanel.Controls.Add(Me.CreateMapButton)
        Me.LaunchPanel.Location = New System.Drawing.Point(77, 31)
        Me.LaunchPanel.Name = "LaunchPanel"
        Me.LaunchPanel.Size = New System.Drawing.Size(600, 485)
        Me.LaunchPanel.TabIndex = 0
        '
        'CreateNewMapPanel
        '
        Me.CreateNewMapPanel.BackColor = System.Drawing.Color.Transparent
        Me.CreateNewMapPanel.BackgroundImage = Global.LeonRPG.My.Resources.GameResource.MsgboxBGI
        Me.CreateNewMapPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CreateNewMapPanel.Controls.Add(Me.OKButton)
        Me.CreateNewMapPanel.Controls.Add(Me.CancelButton)
        Me.CreateNewMapPanel.Controls.Add(Me.HeightNumericUpDown)
        Me.CreateNewMapPanel.Controls.Add(Me.Label3)
        Me.CreateNewMapPanel.Controls.Add(Me.WidthNumericUpDown)
        Me.CreateNewMapPanel.Controls.Add(Me.Label2)
        Me.CreateNewMapPanel.Controls.Add(Me.MapNameTextBox)
        Me.CreateNewMapPanel.Controls.Add(Me.Label1)
        Me.CreateNewMapPanel.Controls.Add(Me.MessageLabel)
        Me.CreateNewMapPanel.Location = New System.Drawing.Point(0, 46)
        Me.CreateNewMapPanel.Name = "CreateNewMapPanel"
        Me.CreateNewMapPanel.Size = New System.Drawing.Size(600, 400)
        Me.CreateNewMapPanel.TabIndex = 5
        Me.CreateNewMapPanel.Visible = False
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OKButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OKButton.Image = Global.LeonRPG.My.Resources.GameResource.MsgboxButton_0
        Me.OKButton.Location = New System.Drawing.Point(300, 223)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(191, 53)
        Me.OKButton.TabIndex = 8
        Me.OKButton.Tag = "MsgboxButton_"
        Me.OKButton.Text = "确定"
        Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CancelButton
        '
        Me.CancelButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CancelButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CancelButton.Image = Global.LeonRPG.My.Resources.GameResource.MsgboxButton_0
        Me.CancelButton.Location = New System.Drawing.Point(109, 223)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(191, 53)
        Me.CancelButton.TabIndex = 7
        Me.CancelButton.Tag = "MsgboxButton_"
        Me.CancelButton.Text = "取消"
        Me.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HeightNumericUpDown
        '
        Me.HeightNumericUpDown.BackColor = System.Drawing.Color.Gray
        Me.HeightNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HeightNumericUpDown.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.HeightNumericUpDown.ForeColor = System.Drawing.Color.Cyan
        Me.HeightNumericUpDown.Location = New System.Drawing.Point(312, 168)
        Me.HeightNumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.HeightNumericUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.HeightNumericUpDown.Name = "HeightNumericUpDown"
        Me.HeightNumericUpDown.Size = New System.Drawing.Size(59, 26)
        Me.HeightNumericUpDown.TabIndex = 6
        Me.HeightNumericUpDown.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(288, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "X"
        '
        'WidthNumericUpDown
        '
        Me.WidthNumericUpDown.BackColor = System.Drawing.Color.Gray
        Me.WidthNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WidthNumericUpDown.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WidthNumericUpDown.ForeColor = System.Drawing.Color.Cyan
        Me.WidthNumericUpDown.Location = New System.Drawing.Point(223, 168)
        Me.WidthNumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.WidthNumericUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.WidthNumericUpDown.Name = "WidthNumericUpDown"
        Me.WidthNumericUpDown.Size = New System.Drawing.Size(59, 26)
        Me.WidthNumericUpDown.TabIndex = 4
        Me.WidthNumericUpDown.Value = New Decimal(New Integer() {42, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(138, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "地图规模："
        '
        'MapNameTextBox
        '
        Me.MapNameTextBox.BackColor = System.Drawing.Color.Gray
        Me.MapNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MapNameTextBox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MapNameTextBox.ForeColor = System.Drawing.Color.Cyan
        Me.MapNameTextBox.Location = New System.Drawing.Point(223, 132)
        Me.MapNameTextBox.Name = "MapNameTextBox"
        Me.MapNameTextBox.Size = New System.Drawing.Size(238, 26)
        Me.MapNameTextBox.TabIndex = 2
        Me.MapNameTextBox.Text = "NewMap"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(138, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "地图名称："
        '
        'MessageLabel
        '
        Me.MessageLabel.AutoSize = True
        Me.MessageLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MessageLabel.ForeColor = System.Drawing.Color.White
        Me.MessageLabel.Location = New System.Drawing.Point(80, 70)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(90, 21)
        Me.MessageLabel.TabIndex = 0
        Me.MessageLabel.Text = "新建地图："
        '
        'ExitGameButton
        '
        Me.ExitGameButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ExitGameButton.ForeColor = System.Drawing.Color.White
        Me.ExitGameButton.Image = CType(resources.GetObject("ExitGameButton.Image"), System.Drawing.Image)
        Me.ExitGameButton.Location = New System.Drawing.Point(172, 377)
        Me.ExitGameButton.Name = "ExitGameButton"
        Me.ExitGameButton.Size = New System.Drawing.Size(256, 58)
        Me.ExitGameButton.TabIndex = 4
        Me.ExitGameButton.Tag = "GameButton_"
        Me.ExitGameButton.Text = "退出"
        Me.ExitGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlayMapButton
        '
        Me.PlayMapButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PlayMapButton.ForeColor = System.Drawing.Color.White
        Me.PlayMapButton.Image = CType(resources.GetObject("PlayMapButton.Image"), System.Drawing.Image)
        Me.PlayMapButton.Location = New System.Drawing.Point(172, 319)
        Me.PlayMapButton.Name = "PlayMapButton"
        Me.PlayMapButton.Size = New System.Drawing.Size(256, 58)
        Me.PlayMapButton.TabIndex = 3
        Me.PlayMapButton.Tag = "GameButton_"
        Me.PlayMapButton.Text = "开始游戏"
        Me.PlayMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EditMapButton
        '
        Me.EditMapButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EditMapButton.ForeColor = System.Drawing.Color.White
        Me.EditMapButton.Image = CType(resources.GetObject("EditMapButton.Image"), System.Drawing.Image)
        Me.EditMapButton.Location = New System.Drawing.Point(172, 261)
        Me.EditMapButton.Name = "EditMapButton"
        Me.EditMapButton.Size = New System.Drawing.Size(256, 58)
        Me.EditMapButton.TabIndex = 2
        Me.EditMapButton.Tag = "GameButton_"
        Me.EditMapButton.Text = "编辑地图"
        Me.EditMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogoLabel
        '
        Me.LogoLabel.Font = New System.Drawing.Font("Snap ITC", 42.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoLabel.ForeColor = System.Drawing.Color.OrangeRed
        Me.LogoLabel.Location = New System.Drawing.Point(3, 80)
        Me.LogoLabel.Name = "LogoLabel"
        Me.LogoLabel.Size = New System.Drawing.Size(594, 75)
        Me.LogoLabel.TabIndex = 1
        Me.LogoLabel.Text = "Leon RPG"
        Me.LogoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CreateMapButton
        '
        Me.CreateMapButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CreateMapButton.ForeColor = System.Drawing.Color.White
        Me.CreateMapButton.Image = Global.LeonRPG.My.Resources.GameResource.GameButton_0
        Me.CreateMapButton.Location = New System.Drawing.Point(172, 203)
        Me.CreateMapButton.Name = "CreateMapButton"
        Me.CreateMapButton.Size = New System.Drawing.Size(256, 58)
        Me.CreateMapButton.TabIndex = 0
        Me.CreateMapButton.Tag = "GameButton_"
        Me.CreateMapButton.Text = "新建地图"
        Me.CreateMapButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MapPictureBox
        '
        Me.MapPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.MapPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MapPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.MapPictureBox.Name = "MapPictureBox"
        Me.MapPictureBox.Size = New System.Drawing.Size(709, 517)
        Me.MapPictureBox.TabIndex = 1
        Me.MapPictureBox.TabStop = False
        Me.MapPictureBox.Visible = False
        '
        'TilesetListView
        '
        Me.TilesetListView.BackColor = System.Drawing.SystemColors.Window
        Me.TilesetListView.BorderStyle = System.Windows.Forms.BorderStyle.None
        ListViewGroup7.Header = "地图"
        ListViewGroup7.Name = "MapGroup"
        ListViewGroup7.Tag = "0"
        ListViewGroup8.Header = "遮罩"
        ListViewGroup8.Name = "MaskGroup"
        ListViewGroup8.Tag = "1"
        Me.TilesetListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup7, ListViewGroup8})
        Me.TilesetListView.Location = New System.Drawing.Point(0, 530)
        Me.TilesetListView.MultiSelect = False
        Me.TilesetListView.Name = "TilesetListView"
        Me.TilesetListView.Size = New System.Drawing.Size(744, 166)
        Me.TilesetListView.TabIndex = 2
        Me.TilesetListView.UseCompatibleStateImageBehavior = False
        Me.TilesetListView.Visible = False
        '
        'SaveButton
        '
        Me.SaveButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SaveButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SaveButton.Image = Global.LeonRPG.My.Resources.GameResource.MsgboxButton_0
        Me.SaveButton.Location = New System.Drawing.Point(703, 20)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(191, 53)
        Me.SaveButton.TabIndex = 8
        Me.SaveButton.Tag = "MsgboxButton_"
        Me.SaveButton.Text = "保存"
        Me.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SaveButton.Visible = False
        '
        'BackButton
        '
        Me.BackButton.BackColor = System.Drawing.Color.Transparent
        Me.BackButton.Font = New System.Drawing.Font("汉仪书魂体简", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BackButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BackButton.Image = Global.LeonRPG.My.Resources.GameResource.MsgboxButton_0
        Me.BackButton.Location = New System.Drawing.Point(703, 86)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(191, 53)
        Me.BackButton.TabIndex = 9
        Me.BackButton.Tag = "MsgboxButton_"
        Me.BackButton.Text = "返回主菜单"
        Me.BackButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BackButton.Visible = False
        '
        'LaunchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = Global.LeonRPG.My.Resources.GameResource.GameFormBGI
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(745, 541)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.LaunchPanel)
        Me.Controls.Add(Me.TilesetListView)
        Me.Controls.Add(Me.MapPictureBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LaunchForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LeonRPG"
        Me.LaunchPanel.ResumeLayout(False)
        Me.CreateNewMapPanel.ResumeLayout(False)
        Me.CreateNewMapPanel.PerformLayout()
        CType(Me.HeightNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WidthNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LaunchPanel As Panel
    Friend WithEvents CreateMapButton As Label
    Private WithEvents LogoLabel As Label
    Friend WithEvents EditMapButton As Label
    Friend WithEvents PlayMapButton As Label
    Friend WithEvents ExitGameButton As Label
    Friend WithEvents MapPictureBox As PictureBox
    Friend WithEvents TilesetListView As ListView
    Friend WithEvents CreateNewMapPanel As Panel
    Friend WithEvents MessageLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MapNameTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents WidthNumericUpDown As NumericUpDown
    Friend WithEvents HeightNumericUpDown As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents CancelButton As Label
    Friend WithEvents OKButton As Label
    Friend WithEvents SaveButton As Label
    Friend WithEvents BackButton As Label
End Class
