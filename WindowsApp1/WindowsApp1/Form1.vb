Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ''' https://oreno-it2.info/archives/1079

        '子画面呼び出しボタン
        'ここでは、「Dim fm2 As New Form2」でForm２を新しく生成しています。
        'そして「fm2.Show()」でフォーム2を表示しています。このShowメソッドで表示した場合、親画面、子画面とも自由に触れる状態となります。

        Dim fm2 As New Form2
        'fm2.Show()
        fm2.ShowDialog()

        '子画面呼び出しボタン2
        'Dim fm2 As New Form2
        'fm2.StartPosition = FormStartPosition.CenterParent
        'fm2.Label1.Text = TextBox1.Text
        'fm2.ShowDialog()

        ''子画面呼び出しボタン3
        'Dim fm2 As New Form2
        'fm2.ShowDialog()

    End Sub
End Class
