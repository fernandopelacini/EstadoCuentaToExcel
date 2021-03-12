Public Class Excel
    Private excel As Microsoft.Office.Interop.Excel.Application
    Private wBook As Microsoft.Office.Interop.Excel.Workbook
    Private wSheet As Microsoft.Office.Interop.Excel.Worksheet

#Region "Metodos"
    ''' <summary>
    ''' Destruye el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' Instacia el objeto excel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        excel = New Microsoft.Office.Interop.Excel.Application
    End Sub

    ''' <summary>
    ''' Exporta los datos a excel
    ''' </summary>
    ''' <param name="dtDatos">Datatable con los datos a exportar</param>
    ''' <param name="strExcelFileName">Nombre con el que se va a guardar el archivo</param>
    ''' <remarks></remarks>
    Public Sub Exportar(ByVal dtDatos As DataTable, ByVal strExcelFileName As String)
        Try
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim dt As System.Data.DataTable = dtDatos
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

                Next
            Next
            wSheet.Columns.AutoFit()


            Dim strFileName As String = Application.StartupPath & strExcelFileName & Now.Second & ".xlsx"
            Dim blnFileOpen As Boolean = False

            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If


            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try

    End Sub
#End Region

End Class
