''' <summary>
''' DataTable関連の操作クラス
''' </summary>
Public Class CDataTable

    Public Sub New()

    End Sub

    ''' <summary>
    ''' DataTableの行列の入れ替え
    ''' </summary>
    ''' <param name="src">元のDataTable</param>
    ''' <param name="newColName">行列入れ替え後の最初のカラム名</param>
    ''' <returns>行列入れ替え後のDataTable</returns>
    Public Function SwapXY(ByVal src As DataTable, ByVal newColName As String) As DataTable

        Dim ret As New DataTable(src.TableName)

        '列の追加
        ret.Columns.Add(newColName)
        For y As Integer = 0 To src.Rows.Count - 1
            ret.Columns.Add(src.Rows(y)(0))
        Next

        '列を行に変換
        For x As Integer = 1 To src.Columns.Count - 1

            Dim dr As DataRow = ret.NewRow()

            dr(newColName) = src.Columns(x).ColumnName

            For y As Integer = 0 To src.Rows.Count - 1
                dr(ret.Columns(y + 1).ColumnName) = src.Rows(y)(x)
            Next

            ret.Rows.Add(dr)
        Next

        SwapXY = ret

    End Function

End Class
