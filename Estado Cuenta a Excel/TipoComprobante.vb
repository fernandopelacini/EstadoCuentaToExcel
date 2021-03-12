Public Class TipoComprobante
#Region "Propiedades"
    Public Property IDtipoComprobante As Integer
    Public Property Descripcion As String
    Public Property Codigo As String
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
    ''' Lista los tipos de comprobante
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarTiposDeComprobante(ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            oDatos = conexion.ExecuteDataset(LISTAR_TIPOS_DE_COMPROBANTES_TODOS, _
                                            TABLA_TIPOS_DE_COMPROBANTES, _
                                            True, _
                                            Nothing, _
                                            Nothing)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub


    ''' <summary>
    ''' Trae el ID de un tipo de comprobante
    ''' </summary>
    ''' <param name="strComprobante">Tipo de comprobante</param>
    ''' <returns>ID del tipo de comprobante</returns>
    ''' <remarks></remarks>
    Public Function TraerIDtipoComprobante(ByVal strComprobante As String) As Integer
        Dim intID As Integer = 0
        Try
            conexion.Command.Parameters.Clear()
            intID = conexion.ExecuteSPScalar(TRAER_ID_TIPO_DE_COMPROBANTE, _
                                             "@descripcion", _
                                             strComprobante)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function

    ''' <summary>
    ''' Lista los tipos de comprobante para notas de credito
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarTiposDeComprobanteNotasDeCredito(ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            oDatos = conexion.ExecuteDataset(LISTAR_TIPOS_DE_COMPROBANTES_TODOS_NOTA_DE_CREDITO, _
                                            TABLA_TIPOS_DE_COMPROBANTES, _
                                            True, _
                                            Nothing, _
                                            Nothing)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub
#End Region
End Class
