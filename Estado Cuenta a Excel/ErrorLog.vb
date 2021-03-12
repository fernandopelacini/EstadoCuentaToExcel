Imports System.Text

Public Class ErrorLog

#Region "Propiedades"
    Public Shared Property IDerror As Integer
    Public Shared Property IDusuario As String
    Public Shared Property StackTrace As String
    Public Shared Property Type As String
    Public Shared Property Descripcion As String
    Public Shared Property FechaError As DateTime
#End Region

#Region "Metodos"
    Public Shared Sub Create(ByVal User As String, ByVal ex As Exception)
        Try

            Dim separador As String = "','"
            Dim query As New StringBuilder

            conexion.Command.Parameters.Clear()

            query.Append("INSERT INTO tblErrorLog values ('")
            query.Append(User)
            query.Append(separador)
            query.Append(Replace(ex.StackTrace, "'", "''"))
            query.Append(separador)
            query.Append(ex.GetType().Name)
            query.Append(separador)
            query.Append(Replace(ex.Message, "'", "''"))
            query.Append("',")
            query.Append("GetDate()")
            query.Append(",'")
            If Not ex.InnerException Is Nothing Then
         
                query.Append(Replace(ex.InnerException.ToString(), "'", "''"))

            End If
            query.Append(separador)
            query.Append(Replace(ex.Source, "'", "''"))
            query.Append("')")
            conexion.ExecuteNonQuery(query.ToString())

            query = Nothing
        Catch ex1 As Exception
            Dim archivoError As String = "C:\archivoError.txt"
            Dim sw As IO.StreamWriter

            If Not IO.File.Exists(archivoError) Then IO.File.CreateText(archivoError)

            sw = New IO.StreamWriter(archivoError, True, System.Text.Encoding.Default)

            sw.WriteLine(ex1.Message)

            sw.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Lista los logs de errores en un rango de fechas
    ''' </summary>
    ''' <param name="dteFechaDesde">Fecha inicio del error</param>
    ''' <param name="dteFechaHasta">Fecha limite del error</param>
    ''' <param name="oDatos">Dataset con los logs</param>
    ''' <remarks></remarks>
    Public Sub ListarLogErroresPorFecha(ByVal dteFechaDesde As DateTime, _
                      ByVal dteFechaHasta As DateTime, _
                      ByRef oDatos As dsDatos)

        Try
            conexion.Command.Parameters.Clear()
            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@fechaDesde", dteFechaDesde)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaHasta", dteFechaHasta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oDatos = conexion.ExecuteDataset(LISTAR_LOG_ERRORES, _
                                                TABLA_LOG_ACTIVIDADES, _
                                                True, _
                                                oParametros, _
                                                oDatos)

            oParametros = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    Public Sub Dispose()
        MyBase.Finalize()
    End Sub

    Public Shared Sub Create(ByVal User As String, ByVal code As String, ByVal mensaje As String)
        Try
            Dim str1 As String = "','"
            Dim stringbuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder()
            Funciones.conexion.Command.Parameters.Clear()
            stringbuilder1.Append("INSERT INTO tblErrorLog values ('")
            stringbuilder1.Append(User)
            stringbuilder1.Append(str1)
            stringbuilder1.Append(code)
            stringbuilder1.Append(str1)
            IIf(code = "Error CENT", stringbuilder1.Append("wsfe"), stringbuilder1.Append("cent"))
            stringbuilder1.Append(str1)
            stringbuilder1.Append(Strings.Replace(mensaje, "'", "''", 1, -1, CompareMethod.Binary))
            stringbuilder1.Append("',GetDate()")
            stringbuilder1.Append(",'','')") 'inner exception y stack trace
            'stringbuilder1.Append("')")
            Funciones.conexion.ExecuteNonQuery(stringbuilder1.ToString())
            stringbuilder1 = Nothing

        Catch exception1 As Exception
            Dim str2 As String = "C:\archivoError.txt"
            If (Not System.IO.File.Exists(str2)) Then
                System.IO.File.CreateText(str2)
            End If
            Dim streamwriter1 As System.IO.StreamWriter = New System.IO.StreamWriter(str2, True, System.Text.Encoding.Default)
            streamwriter1.WriteLine(exception1.Message)
            streamwriter1.Close()
        End Try
    End Sub


#End Region
End Class
