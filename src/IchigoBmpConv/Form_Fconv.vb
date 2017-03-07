Public Class Form_Fconv
    Dim bmpfile As String       'ビットマップファイル名
    Dim bm As Bitmap            'ビットマップデータ
    Dim fdata(32 * 24) As Byte  '変換したフォントデータ
    Dim fsize As Integer        'フォントデータサイズ

    '画像ファイルのロード
    Function loadBitmapFile(fname As String) As Integer
        Dim x As Integer
        Dim y As Integer
        Dim c1, c2, c3, c4 As Color
        Dim d As Byte
        Dim i As Integer

        '画像のロード
        Try
            bm = Image.FromFile(fname)
        Catch ex As OutOfMemoryException
            loadBitmapFile = 3
            Exit Function
        Catch ex As System.IO.FileNotFoundException
            loadBitmapFile = 4
            Exit Function
        Catch ex As Exception
            loadBitmapFile = 5
            Exit Function
        End Try

        If bm.PixelFormat <> Imaging.PixelFormat.Format1bppIndexed Then
            loadBitmapFile = 1
            Exit Function
        End If
        '画像の大きさチェック
        If bm.Height > 48 Or bm.Width > 64 Then
            'If bm.Width > 64 Then
            loadBitmapFile = 2
            Exit Function
        End If

        i = 0
        'フォントデータの変換(大きさが奇数の場合、最後の行・列は破棄する)
        For y = 0 To bm.Height - 1 - (bm.Height Mod 2) Step 2
            For x = 0 To bm.Width - 1 - (bm.Width Mod 2) Step 2
                d = 0
                c1 = bm.GetPixel(x, y)
                c2 = bm.GetPixel(x + 1, y)
                c3 = bm.GetPixel(x, y + 1)
                c4 = bm.GetPixel(x + 1, y + 1)
                If (c1.R) Then
                    d = d + 1
                End If
                If (c2.R) Then
                    d = d + 2
                End If
                If (c3.R) Then
                    d = d + 4
                End If
                If (c4.R) Then
                    d = d + 8
                End If
                d = d + &H80
                fdata(i) = d
                i = i + 1
            Next
        Next
        fsize = bm.Height * bm.Width / 4
        loadBitmapFile = 0
    End Function

    '選択画像の処理
    Private Sub LoadBitmap(file As String)
        Dim rc As Integer
        rc = loadBitmapFile(bmpfile)

        If rc = 1 Or rc = 3 Then
            MessageBox.Show(Me, "指定したファイルは、モノクロビットマップ形式ではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If rc = 4 Then
            MessageBox.Show(Me, "指定したファイルが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If rc = 5 Then
            MessageBox.Show(Me, "画像ファイルの読み込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If rc = 2 Then
            MessageBox.Show(Me, "画像のサイズが64x48ドットを超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '画面に画像情報の表示
        PictureBox1.Image = bm
        TextBox1.Text = bmpfile
        Label2.Text = PictureBox1.Image.Width & "x" & PictureBox1.Image.Height
        'ボタン操作を有効にする
        BtnOutTxData.Enabled = True
        BtnOutBinData.Enabled = True
        BtnOutSRC.Enabled = True
    End Sub


    ' 画像ファイルの指定
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnRefFile.Click

        'ダイアログ画面表示
        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            bmpfile = OpenFileDialog1.FileName
            LoadBitmap(bmpfile)
        End If
    End Sub

    '終了
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    'テキスト出力
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnOutTxData.Click
        Dim i As Integer
        Dim textFile As System.IO.StreamWriter

        '出力ファイル名の指定
        If (SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If

        Try
            textFile = New System.IO.StreamWriter(SaveFileDialog1.FileName, False, System.Text.Encoding.Default)
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルのオープンに失敗しました。", "テキスト形式出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        For i = 0 To fsize - 1
            Try
                textFile.Write("#" & Hex(fdata(i)) & ",")
                If i Mod 10 = 9 Then
                    textFile.Write(vbNewLine)
                End If
            Catch ex As Exception
                MessageBox.Show(Me, "ファイルの書き込みに失敗しました。", "テキスト形式出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        Next
        textFile.Close()
        MessageBox.Show(Me, "ファイルを出力しました。", "テキスト形式出力", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        BtnOutTxData.Enabled = False
        BtnOutBinData.Enabled = False
        BtnOutSRC.Enabled = False
        NumericUpDown1.Enabled = False
    End Sub

    'バイナリ出力
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BtnOutBinData.Click
        Dim binFile As System.IO.FileStream
        Dim wmode As System.IO.FileMode

        '出力ファイル名の指定
        If (SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If
        If CheckBox1.Checked = True Then
            wmode = IO.FileMode.Append
        Else
            wmode = IO.FileMode.Create
        End If
        Try
            binFile = New System.IO.FileStream(SaveFileDialog1.FileName, wmode, IO.FileAccess.Write)
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルのオープンに失敗しました。", "バイナリ形式出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Try
            binFile.Write(fdata, 0, fsize)
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルの出力に失敗しました。", "バイナリ形式出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        binFile.Close()
        MessageBox.Show(Me, "ファイルを出力しました。", "バイナリ形式出力", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    'IchigoJam BASIC用のソースを出力
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles BtnOutSRC.Click
        If CkBox_romsrc.CheckState = CheckState.Unchecked Then
            '表示用ソースの出力
            OutSrcForIchigo()
        Else
            'EEPROM書き込み用ソースの出力
            If bm.Height = 48 And bm.Width = 64 Then
                OutSrcForEEPROM()
            Else
                MessageBox.Show(Me, "EEPROM書き込み用ソース出力時は" & vbCr & "画像ファイルサイズは64x48のみ有効です。" _
                                , "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Sub OutSrcForIchigo()
        Dim i As Integer
        Dim h, w As Integer
        Dim binFile As System.IO.FileStream
        Dim str_top() As Byte
        Dim str_end() As Byte
        Dim str_end2() As Byte
        Dim str_end3() As Byte
        Dim str_end4() As Byte
        Dim str_newLine() As Byte
        Dim str_Hex() As Byte

        str_Hex = {48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70}
        str_top = {49, 48, 48, 63, 34}  '行の先頭: 行番号 ?" '
        str_end = {&H22}                '1行が32文字以内の場合 ";" を付けない
        str_end2 = {&H22, 59}           '1行が32文字の場合 ";" を付ける
        str_end3 = {49, 48, 48, 32, 71, 79, 84, 79, 32, 49, 48, 48} '最終行 "GOTO NNN"
        str_end4 = {&H22, 59, &H3A, &H50, &H4F, &H4B, &H45, &H20, &H23, &H42, &H46, &H46, &H2C, &H23, 48, 48} '32x24の場合の対応
        str_newLine = {&HD, &HA}        '改行文字


        h = (bm.Height - (bm.Height Mod 2)) / 2
        w = (bm.Width - (bm.Width Mod 2)) / 2

        '出力ファイル名の指定
        If (SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If
        Try
            binFile = New System.IO.FileStream(SaveFileDialog1.FileName, IO.FileMode.Create, IO.FileAccess.Write)
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルのオープンに失敗しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Try
            For i = 0 To h - 1
                str_top(0) = 49 + i \ 10
                str_top(1) = 48 + (i Mod 10)
                binFile.Write(str_top, 0, 5)
                If w = 32 Then
                    If i = 23 Then
                        '1行が32文字で、行が24行の場合、スクロール対策で最後の1文字をPOKEで書く
                        str_end4(14) = str_Hex(fdata(w * h - 1) \ 16)
                        str_end4(15) = str_Hex(fdata(w * h - 1) Mod 16)
                        binFile.Write(fdata, i * w, w - 1)
                        binFile.Write(str_end4, 0, 16)
                        binFile.Write(str_newLine, 0, 2)
                    Else
                        '1行が32文字の場合、最後に";"を付ける
                        binFile.Write(fdata, i * w, w)
                        binFile.Write(str_end2, 0, 2)
                        binFile.Write(str_newLine, 0, 2)
                    End If
                Else
                    '1行が32文字以内の場合、最後に";"を付けない
                    binFile.Write(fdata, i * w, w)
                    binFile.Write(str_end, 0, 1)
                    binFile.Write(str_newLine, 0, 2)
                End If
            Next
            '最終行のGOTO文の付加
            str_end3(0) = 49 + h \ 10
            str_end3(1) = 48 + (h Mod 10)
            str_end3(9) = 49 + h \ 10
            str_end3(10) = 48 + (h Mod 10)
            binFile.Write(str_end3, 0, 12)
            binFile.Write(str_newLine, 0, 2)

            ' ファイル書き込みエラー処理
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルの書き込みに失敗しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            binFile.Close()
            Exit Sub
        End Try

        binFile.Close()
        MessageBox.Show(Me, "ファイルを出力しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'EEPROM書き込みのためのIchigoJamソース出力
    Sub OutSrcForEEPROM()
        Dim i As Integer
        Dim h, w As Integer
        Dim binFile As System.IO.FileStream
        Dim str_top() As Byte
        Dim str_end() As Byte
        Dim str_end2() As Byte
        Dim str_end3() As Byte
        Dim str_end4() As Byte
        Dim str_newLine() As Byte
        Dim str_Hex() As Byte
        Dim str_cmd As String
        Dim ary_char() As Char
        Dim s(2) As Byte

        str_Hex = {48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70}
        str_top = {49, 48, 48, 39}  '行の先頭: 行番号＋コメント記号
        str_end = {&H22}                '1行が32文字以内の場合 ";" を付けない
        str_end2 = {&H22, 59}           '1行が32文字の場合 ";" を付ける
        str_end3 = {49, 48, 48, 32, 71, 79, 84, 79, 32, 49, 48, 48} '最終行 "GOTO NNN"
        str_end4 = {&H22, 59, &H3A, &H50, &H4F, &H4B, &H45, &H20, &H23, &H42, &H46, &H46, &H2C, &H23, 48, 48} '32x24の場合の対応
        str_newLine = {&HD, &HA}        '改行文字

        h = (bm.Height - (bm.Height Mod 2)) / 2
        w = (bm.Width - (bm.Width Mod 2)) / 2

        str_cmd = "340 A=" & NumericUpDown1.Value & ":D=#C04:F=(A-100)%64*#400:FORI=0TO" & (h - 1) & vbNewLine & _
                  "350 POKE#8D0,F>>8,F&#FF:B=I2CW(80,#8D0,2,D," & w & "):D=D+" & (w + 6) & ":F=F+" & w & ":NEXT" & vbNewLine

        'データを&H80～&H8Fから A～Qに変更する
        'For i = 0 To h * w - 1
        'fdata(i) = fdata(i) - &H80 + Asc("A")
        'Next

        '出力ファイル名の指定
        If (SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK) Then
            Exit Sub
        End If
        Try
            binFile = New System.IO.FileStream(SaveFileDialog1.FileName, IO.FileMode.Create, IO.FileAccess.Write)
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルのオープンに失敗しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Try
            For i = 0 To h - 1
                '行番号＋コメント記号
                str_top(0) = 49 + i \ 10
                str_top(1) = 48 + (i Mod 10)
                binFile.Write(str_top, 0, 4)

                'データの出力
                binFile.Write(fdata, i * w, w)
                binFile.Write(str_newLine, 0, 2)
            Next

            ary_char = str_cmd.ToCharArray()
            For i = 0 To ary_char.Length - 1
                s(0) = CByte(AscW(ary_char(i)))
                binFile.Write(s, 0, 1)
            Next

            ' ファイル書き込みエラー処理
        Catch ex As Exception
            MessageBox.Show(Me, "ファイルの書き込みに失敗しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
            binFile.Close()
            Exit Sub
        End Try

        binFile.Close()
        MessageBox.Show(Me, "ファイルを出力しました。", "ソース出力", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CkBox_romsrc_CheckedChanged(sender As Object, e As EventArgs) Handles CkBox_romsrc.CheckedChanged
        If CkBox_romsrc.CheckState = CheckState.Checked Then
            NumericUpDown1.Enabled = True
        Else
            NumericUpDown1.Enabled = False
        End If
    End Sub

    Private Sub Form_Fconv_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim s() As String = e.Data.GetData("FileDrop", False)
        bmpfile = s(0)
        LoadBitmap(bmpfile)
    End Sub

    Private Sub Form_Fconv_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
End Class
