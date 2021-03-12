Public Class PuestoDeVenta
#Region "Propiedades"
    Public Property IDpuestoDeVenta As Integer
    Public Property PuestoVenta As String
    Public Property NumeroSerie As String
    Public Property Modelo As String
    Public Property Marca As String
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
    ''' Lista los puestos de venta
    ''' </summary>
    ''' <param name="strEmpresa">Cuenta de la que se quiere traer los puestos de venta</param>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarPuestosDeVenta(ByVal strEmpresa As String, ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            oDatos = conexion.ExecuteDataset(LISTAR_PUESTOS_DE_VENTAS_TODOS, _
                                            TABLA_PUESTOS_DE_VENTA, _
                                            "@cuenta", _
                                            strEmpresa, _
                                            True, _
                                            Nothing)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    ''' <summary>
    ''' Trae el ID de un puesto de venta
    ''' </summary>
    ''' <param name="strPuestoVenta ">Puesto de venta</param>
    ''' <returns>ID del puesto de venta</returns>
    ''' <remarks></remarks>
    Public Function TraerIDpuestoVenta(ByVal strPuestoVenta As String) As Integer
        Dim intID As Integer = 0
        Try
            conexion.Command.Parameters.Clear()
            intID = conexion.ExecuteSPScalar(TRAER_ID_PUESTO_DE_VENTA, _
                                             "@puestoventa", _
                                             strPuestoVenta)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function
#End Region
End Class
