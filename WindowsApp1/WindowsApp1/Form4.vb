Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load

        'DataTableのデータをDataGridViewにセットしてフォームに表示
        Me.DataGridView1.DataSource = CreateDataSet()

        '追加で、以下の場合は、反転可能
        'Dim cst As New CDataTable()
        'Me.DataGridView1.DataSource = cst.SwapXY(Me.DataGridView1.DataSource, "年度")

    End Sub

    Private Sub Form4_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Function CreateDataSet() As DataTable
        'データセット作成
        Dim ds As New DataSet()

        ''テーブル作成
        'Dim dt As DataTable
        ''データテーブル宣言
        'dt = ds.Tables.Add("sample")

        '或いは、
        Dim dt As New DataTable("sample")
        'という書き方

        '列項目作成
        dt.Columns.Add("店舗")
        dt.Columns.Add("2017年")
        dt.Columns.Add("2018年")
        dt.Columns.Add("2019年")

        '1行目
        dt.Rows.Add({1, 100, 110, 120})
        '2行目
        dt.Rows.Add({2, 200, 210, 220})
        '3行目
        dt.Rows.Add({3, 300, 310, 320})
        '4行目
        dt.Rows.Add({4, 400, 410, 420})
        '5行目
        dt.Rows.Add({5, 500, 510, 520})

        '或いは、
        'DataRow宣言
        Dim dtRow As DataRow
        '99行目
        dtRow = dt.NewRow
        dtRow("店舗") = "99"
        dtRow("2017年") = "2017"
        dtRow("2018年") = "2018"
        dtRow("2019年") = "2019"
        '行追加
        dt.Rows.Add(dtRow)
        'という追加パターン

        'DataTableのデータをセット
        CreateDataSet = dt

    End Function

End Class
