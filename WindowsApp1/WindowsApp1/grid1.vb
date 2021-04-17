Public Class grid1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim serverName As String = "localhost\SQLEXPRESS"
        Dim dataBase As String = "DC_PKG"
        Dim userid As String = "sa"
        Dim pwd As String = "as"
        Dim dread As SqlClient.SqlDataReader
        Dim str As String = String.Empty

        Try
            Dim dgvRowCnt As Integer

            'DataGridView初期化（行データクリア）
            DataGridView1.Rows.Clear()

            Using conn As New SqlClient.SqlConnection()

                conn.ConnectionString =
                    " Data Source = " & serverName &
                    ";Initial Catalog = " & dataBase &
                    ";User ID = " & userid &
                    ";Password =" & pwd

                conn.Open()

                Using cmd As New SqlClient.SqlCommand()

                    cmd.Connection = conn

                    cmd.CommandText =
                            "SELECT * " & ControlChars.NewLine &
                            "FROM  FTRN11 " & ControlChars.NewLine &
                            "WHERE sale_date BETWEEN @date_St AND @date_End  " & ControlChars.NewLine &
                            "ORDER BY  plu_cd " & ControlChars.NewLine

                    cmd.Parameters.Add("@date_St", SqlDbType.VarChar).Value = 20210303
                    cmd.Parameters.Add("@date_End", SqlDbType.VarChar).Value = 20210303

                    dread = cmd.ExecuteReader()

                    Do While dread.Read()

                        Dim iIdx As Integer
                        Dim col_a As String, col_b As String, col_c As Integer, col_d As Integer


                        iIdx = dread.GetOrdinal("sale_date")    '列番号を取得
                        col_a = dread.GetString(iIdx)           'グリッド列へ設定（列の型に合わせて値を設定）

                        iIdx = dread.GetOrdinal("plu_cd")
                        col_b = dread.GetString(iIdx)

                        iIdx = dread.GetOrdinal("sale_amt")
                        col_c = dread.GetDecimal(iIdx)


                        iIdx = dread.GetOrdinal("sale_qty")
                        col_d = dread.GetDecimal(iIdx)

                        'DataGridViewコントロールにデータを追加
                        DataGridView1.Rows.Add(col_a, col_b, col_c, col_d)

                    Loop

                End Using



                dgvRowCnt = DataGridView1.Rows.Count

                'DataGridViewコントロールの選択モードを行選択モードにする
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                'DataGridViewコントロールの新規行（最終行）を非表示にする。
                DataGridView1.AllowUserToAddRows = False

                Label1.Text = "表示が完了しました。"

                Label2.Text = "行数は、「" & dgvRowCnt & "」行です。"
            End Using

        Catch ex As Exception

            Label1.Text = Err.Description

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dgvRowCnt As Integer

        Try

            dgvRowCnt = DataGridView1.Rows.Count

            Label1.Text = "表示されているDataGridViewの行数は、「" & dgvRowCnt & "」行です。"

        Catch ex As Exception

            Label1.Text = Err.Description

        End Try
    End Sub

    'Private Sub grid1_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    '列ヘッダーの背景色をアイボリーにする
    '    DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red

    '    '行ヘッダーの背景色をライムにする
    '    DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lime
    '    ''列のセルのテキストの書式を地域通貨として指定する
    '    'DataGridView1.Columns("sale_amt").DefaultCellStyle.Format = "c"
    'End Sub
End Class