Imports System.Text

Public Class ApplicationLog
#Region "Propiedades"
    Public Property ID As Integer
    Public Property IDaccion As String
    Public Property IDusuario As String
    Public Property Descripcion As String
    Public Property FechaLog As DateTime
#End Region

#Region "Metodos"
    ''' <summary>
    ''' Crea una entrada en la tabla de logs
    ''' </summary>
    ''' <param name="strEvento">Evento que ocurre</param>
    ''' <param name="strDescripcion">Descripcion del evento</param>
    ''' <remarks></remarks>
    Public Shared Sub Create(ByVal strEvento As String, ByVal strDescripcion As String)
        Try

            Dim separador As String = "','"
            Dim query As New StringBuilder

            conexion.Command.Parameters.Clear()

            query.Append("INSERT INTO tblActionLog values ('")
            query.Append(strEvento)
            query.Append(separador)
            query.Append(UsuarioLogin)
            query.Append(separador)
            query.Append(strDescripcion)
            query.Append("',") 'separador)
            query.Append("GetDATE()")
            query.Append(")")
            conexion.ExecuteNonQuery(query.ToString())
            query = Nothing
        Catch ex1 As Exception
            ErrorLog.Create(UsuarioLogin, ex1)
        End Try
    End Sub

    ''' <summary>
    ''' Destruye el objeto
    ''' </summary>
    ''' <remarks></remarks>l
    Public Sub Dispose()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' Lista los logs de actividades en un rango de fechas
    ''' </summary>
    ''' <param name="dteFechaDesde">Fecha inicio del log</param>
    ''' <param name="dteFechaHasta">Fecha limite del log</param>
    ''' <param name="oDatos">Dataset con los logs</param>
    ''' <remarks></remarks>
    Public Sub ListarLogActividadesPorFecha(ByVal dteFechaDesde As DateTime, _
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

            oDatos = conexion.ExecuteDataset(LISTAR_LOG_DE_ACTIVIDADES, _
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
#End Region
End Class
