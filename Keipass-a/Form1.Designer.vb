<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.AxJVLink1 = New AxJVDTLabLib.AxJVLink()
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.mnuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfJV = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.BottomLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnGetJVData = New System.Windows.Forms.Button()
        Me.rtbData = New System.Windows.Forms.RichTextBox()
        Me.btnGetJVOdds = New System.Windows.Forms.Button()
        Me.ListRace = New System.Windows.Forms.ListBox()
        Me.btnShowRace = New System.Windows.Forms.Button()
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxJVLink1
        '
        Me.AxJVLink1.Enabled = True
        Me.AxJVLink1.Location = New System.Drawing.Point(435, 29)
        Me.AxJVLink1.Name = "AxJVLink1"
        Me.AxJVLink1.OcxState = CType(resources.GetObject("AxJVLink1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink1.Size = New System.Drawing.Size(36, 32)
        Me.AxJVLink1.TabIndex = 0
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfig})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(495, 26)
        Me.mainMenu.TabIndex = 1
        Me.mainMenu.Text = "MenuStrip1"
        '
        'mnuConfig
        '
        Me.mnuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfJV})
        Me.mnuConfig.Name = "mnuConfig"
        Me.mnuConfig.Size = New System.Drawing.Size(62, 22)
        Me.mnuConfig.Text = "設定(&C)"
        '
        'mnuConfJV
        '
        Me.mnuConfJV.Name = "mnuConfJV"
        Me.mnuConfJV.Size = New System.Drawing.Size(181, 22)
        Me.mnuConfJV.Text = "JV-Linkの設定(&J)..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar, Me.BottomLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 587)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(495, 23)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar
        '
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(100, 17)
        Me.ProgressBar.Step = 1
        '
        'BottomLabel
        '
        Me.BottomLabel.Name = "BottomLabel"
        Me.BottomLabel.Size = New System.Drawing.Size(136, 18)
        Me.BottomLabel.Text = "ToolStripStatusLabel1"
        '
        'btnGetJVData
        '
        Me.btnGetJVData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGetJVData.ForeColor = System.Drawing.Color.White
        Me.btnGetJVData.Location = New System.Drawing.Point(8, 29)
        Me.btnGetJVData.Name = "btnGetJVData"
        Me.btnGetJVData.Size = New System.Drawing.Size(98, 32)
        Me.btnGetJVData.TabIndex = 3
        Me.btnGetJVData.Text = "データ取得"
        Me.btnGetJVData.UseVisualStyleBackColor = False
        '
        'rtbData
        '
        Me.rtbData.Location = New System.Drawing.Point(8, 185)
        Me.rtbData.Name = "rtbData"
        Me.rtbData.Size = New System.Drawing.Size(475, 400)
        Me.rtbData.TabIndex = 4
        Me.rtbData.Text = ""
        Me.rtbData.WordWrap = False
        '
        'btnGetJVOdds
        '
        Me.btnGetJVOdds.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGetJVOdds.ForeColor = System.Drawing.Color.White
        Me.btnGetJVOdds.Location = New System.Drawing.Point(112, 29)
        Me.btnGetJVOdds.Name = "btnGetJVOdds"
        Me.btnGetJVOdds.Size = New System.Drawing.Size(98, 32)
        Me.btnGetJVOdds.TabIndex = 5
        Me.btnGetJVOdds.Text = "オッズ取得"
        Me.btnGetJVOdds.UseVisualStyleBackColor = False
        '
        'ListRace
        '
        Me.ListRace.FormattingEnabled = True
        Me.ListRace.ItemHeight = 12
        Me.ListRace.Location = New System.Drawing.Point(8, 67)
        Me.ListRace.Name = "ListRace"
        Me.ListRace.Size = New System.Drawing.Size(198, 112)
        Me.ListRace.TabIndex = 6
        '
        'btnShowRace
        '
        Me.btnShowRace.BackColor = System.Drawing.Color.SteelBlue
        Me.btnShowRace.ForeColor = System.Drawing.Color.White
        Me.btnShowRace.Location = New System.Drawing.Point(216, 29)
        Me.btnShowRace.Name = "btnShowRace"
        Me.btnShowRace.Size = New System.Drawing.Size(98, 32)
        Me.btnShowRace.TabIndex = 7
        Me.btnShowRace.Text = "レース一覧"
        Me.btnShowRace.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 610)
        Me.Controls.Add(Me.btnShowRace)
        Me.Controls.Add(Me.ListRace)
        Me.Controls.Add(Me.btnGetJVOdds)
        Me.Controls.Add(Me.rtbData)
        Me.Controls.Add(Me.btnGetJVData)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.AxJVLink1)
        Me.Controls.Add(Me.mainMenu)
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "frmMain"
        Me.Text = "Form1"
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxJVLink1 As AxJVDTLabLib.AxJVLink
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfJV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnGetJVData As System.Windows.Forms.Button
    Friend WithEvents rtbData As System.Windows.Forms.RichTextBox
    Friend WithEvents btnGetJVOdds As System.Windows.Forms.Button
    Friend WithEvents ListRace As System.Windows.Forms.ListBox
    Friend WithEvents btnShowRace As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BottomLabel As System.Windows.Forms.ToolStripStatusLabel

End Class
