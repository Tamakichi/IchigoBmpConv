<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Fconv
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BtnRefFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnOutTxData = New System.Windows.Forms.Button()
        Me.BtnOutBinData = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BtnOutSRC = New System.Windows.Forms.Button()
        Me.CkBox_romsrc = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(15, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 73)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(161, 19)
        Me.TextBox1.TabIndex = 1
        '
        'BtnRefFile
        '
        Me.BtnRefFile.Location = New System.Drawing.Point(179, 13)
        Me.BtnRefFile.Name = "BtnRefFile"
        Me.BtnRefFile.Size = New System.Drawing.Size(68, 22)
        Me.BtnRefFile.TabIndex = 2
        Me.BtnRefFile.Text = "参照"
        Me.BtnRefFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "bmp"
        Me.OpenFileDialog1.Filter = "BMP ファイル|*.bmp|すべてのファイル|*.*"
        Me.OpenFileDialog1.Title = "ファイルの選択"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(246, 120)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(69, 30)
        Me.BtnExit.TabIndex = 3
        Me.BtnExit.Text = "終了"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnOutTxData
        '
        Me.BtnOutTxData.Location = New System.Drawing.Point(82, 120)
        Me.BtnOutTxData.Name = "BtnOutTxData"
        Me.BtnOutTxData.Size = New System.Drawing.Size(75, 30)
        Me.BtnOutTxData.TabIndex = 4
        Me.BtnOutTxData.Text = "テキスト出力"
        Me.BtnOutTxData.UseVisualStyleBackColor = True
        '
        'BtnOutBinData
        '
        Me.BtnOutBinData.Location = New System.Drawing.Point(163, 120)
        Me.BtnOutBinData.Name = "BtnOutBinData"
        Me.BtnOutBinData.Size = New System.Drawing.Size(77, 30)
        Me.BtnOutBinData.TabIndex = 6
        Me.BtnOutBinData.Text = "バイナリ出力"
        Me.BtnOutBinData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "画像サイズ："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(161, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 12)
        Me.Label2.TabIndex = 8
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "プログラム ファイル|*.bas;*.txt|すべてのファイル|*.*"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(85, 55)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(165, 16)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "追記モード(バイナリのみ有効)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BtnOutSRC
        '
        Me.BtnOutSRC.Location = New System.Drawing.Point(12, 120)
        Me.BtnOutSRC.Name = "BtnOutSRC"
        Me.BtnOutSRC.Size = New System.Drawing.Size(67, 30)
        Me.BtnOutSRC.TabIndex = 10
        Me.BtnOutSRC.Text = "ソース出力"
        Me.BtnOutSRC.UseVisualStyleBackColor = True
        '
        'CkBox_romsrc
        '
        Me.CkBox_romsrc.AutoSize = True
        Me.CkBox_romsrc.Location = New System.Drawing.Point(85, 77)
        Me.CkBox_romsrc.Name = "CkBox_romsrc"
        Me.CkBox_romsrc.Size = New System.Drawing.Size(219, 16)
        Me.CkBox_romsrc.TabIndex = 11
        Me.CkBox_romsrc.Text = "EEPROM書き込み(ソース出力のみ有効)"
        Me.CkBox_romsrc.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(234, 94)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {227, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(67, 19)
        Me.NumericUpDown1.TabIndex = 12
        Me.NumericUpDown1.Value = New Decimal(New Integer() {163, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(104, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "書き込みプログラム番号："
        '
        'Form_Fconv
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 157)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.CkBox_romsrc)
        Me.Controls.Add(Me.BtnOutSRC)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnOutBinData)
        Me.Controls.Add(Me.BtnOutTxData)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnRefFile)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "Form_Fconv"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Ichigo画像コンバータ"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents BtnRefFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnOutTxData As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnOutBinData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents BtnOutSRC As System.Windows.Forms.Button
    Friend WithEvents CkBox_romsrc As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
