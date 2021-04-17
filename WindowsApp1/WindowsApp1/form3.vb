Imports System.Data.SqlClient

Public Class form3
    Private Sub form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 接続文字列。環境に合わせて修正してください
        Dim connectionString As String = "SERVER=localhost\SQLEXPRESS;UID=sa;PWD=as;DATABASE=DC_PKG"

        Using connection As New SqlConnection(connectionString)
            ' コネクションを開く
            connection.Open()

            ' SqlDataAdapter.FillSchemaでDataTableにテーブル情報を設定
            Dim dataTable As DataTable = New DataTable()
            Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM sys.objects WHERE 1 = 1", connection)
            dataAdapter.FillSchema(dataTable, SchemaType.Source)

            ' dataTable.Columnsでテーブル項目の情報を取得できる
            ' ここではListに入れ直してデータグリッドビューで表示できるようにしている
            Dim columnList As New List(Of DataColumn)
            For Each column As DataColumn In dataTable.Columns
                columnList.Add(column)
            Next

            ' 画面に表示
            ' 全ての項目情報をデータグリッドビューで表示
            Me.DataGridView1.DataSource = columnList

            ' PrimaryKeyプロパティは主キー項目の配列
            Me.DataGridView1.DataSource = dataTable.PrimaryKey

        End Using
    End Sub
End Class