Public Class Tarjeta
#Region "Propiedades"
    Public Property IDtarjeta As Integer
    Public Property Descripcion As String
#End Region



#Region "Metodos"
    ''' <summary>
    ''' Destruye el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' Lista las tarjetas
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarTarjetas(ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            oDatos = conexion.ExecuteDataset(LISTAR_TARJETAS, _
                                            TABLA_TARJETAS, _
                                            True, _
                                            Nothing, _
                                            Nothing)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    ''' <summary>
    ''' Trae el ID de una tarjeta
    ''' </summary>
    ''' <param name="strTarjeta">Nombre tarjeta</param>
    ''' <returns>ID </returns>
    ''' <remarks></remarks>
    Public Function TraerIDTarjeta(ByVal strTarjeta As String) As Integer
        Dim intID As Integer = 0
        Try
            conexion.Command.Parameters.Clear()
            intID = conexion.ExecuteSPScalar(TRAER_ID_TARJETA, _
                                             "@tarjeta", _
                                             strTarjeta)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function
#End Region
End Class
