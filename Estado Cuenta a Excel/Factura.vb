
Public Class Factura
#Region "Propiedades"
    Public Property IDfactura As Integer
    Public Property NumeroFactura As String
    Public Property IDcaea As CAEA
    Public Property IDpuestoVenta As PuestoDeVenta
    Public Property IDcliente As Cliente
    Public Property IDiva As CondicionIVA
    Public Property IDtipoComprobante As TipoComprobante
    Public Property FechaVenta As DateTime
    Public Property CondicionVenta As String
    Public Property Subtotal As Decimal
    Public Property Impuestos As Decimal
    Public Property IvaInscripto As Decimal
    Public Property IvaNoInscripto As Decimal
    Public Property Total As Decimal
    Public Property InformadaEnAFIP As Boolean
    Public Property Activo As Boolean
    Public Property Oblea As String
    Public Property Dominio As String
    Public Property IDusuario As String
    Public Property Categoria As String
    Public Property Titutlar As String 'SE USA EN LUGAR DEL ID DE CLIENTE AHORA. ON HOLD HASTA QUE NO ESTE EL WEBSERVICE
    Public Property AnioVehiculo As String
    Public Property CUIT As String
    Public Property PendienteDeFacturar As Boolean 'Se usa para los remitos cuando aun se no se facturo, el tipo de comprobante va a ser remito y este campo =1
    Public Property PendienteDeCobrar As Boolean ' Se utiliza para cuando se genero la factura pero no se cobro aun, no tiene un recibo por la factura.
    Public Property IDfacturaCancela As Integer 'Se usa para indicar el ID de la factura que cancela uno o varios remitos
    Public Property IDcuenta As Cuenta
    Public Property CantidadCuotas As SByte
    Public Property NumeroTransferencia As String
    Public Property Lote As String
    Public Property IDTarjeta As Tarjeta
    Public Property NumeroTarjeta As String
    Public Property TipoDocumento As Int16
    Public Property EsConsumidorFinal As Boolean

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
    ''' Inicializa el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        IDcaea = New CAEA()
        IDpuestoVenta = New PuestoDeVenta()
        IDcliente = New Cliente()
        IDiva = New CondicionIVA()
        IDtipoComprobante = New TipoComprobante()
        IDcuenta = New Cuenta()
        IDTarjeta = New Tarjeta
    End Sub

    ''' <summary>
    ''' Trae el proximo nro de factura dependiendo si es A o B y de que empresa.
    ''' </summary>
    ''' <param name="strTipoComprobante">Indica si es Factura A o B</param>
    ''' <param name="strNombreEmpresa">Nombre de la cuenta para la cual se quiere generar un comprobante</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerProximaFactura(ByVal strTipoComprobante As String,
                                        ByVal strNombreEmpresa As String) As Double
        Dim oLector As OleDb.OleDbDataReader
        Dim nroFactura As Int64 = 1
        Try

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            'oParameter = New OleDb.OleDbParameter("@puestoventa", strPuestoDeVenta)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@tipocomprobante", strTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@NombreEmpresa", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oLector = conexion.ExecuteReaderStoredProcedure(TRAER_FACTURA_PROXIMA, oParametros)

            oParametros = Nothing

            If oLector.HasRows Then
                oLector.Read()
                If Not oLector.IsDBNull(0) Then
                    nroFactura = CDbl(oLector.Item(0)) + 1
                End If

            End If

            oLector.Close()
            oLector = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
        Return nroFactura

    End Function

    ''' <summary>
    ''' Inserta una factura en la base
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NuevaFactura() As Boolean
        Try
            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            conexion.Command.Parameters.Clear()
            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@nrofactura", NumeroFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idcaea", IDcaea.IDCaea)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idpuestoventa", IDpuestoVenta.IDpuestoDeVenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idcliente", IDcliente.idCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idiva", IDiva.IDIva)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idtipocomprobante", IDtipoComprobante.IDtipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaventa", FechaVenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@condicionventa", CondicionVenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@subtotal", Subtotal)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@impuestos", Impuestos)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@ivainscripto", IvaInscripto)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@ivanoinscripto", IvaNoInscripto)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@total", Total)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idusuario", IDusuario)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@oblea", Oblea)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@dominio", Dominio)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@categoria", Categoria)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@titutlar", Titutlar)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@anoModelo", AnioVehiculo)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuit", IDcliente.Cuit)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@isPendienteDeFacturar", PendienteDeFacturar)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@isPendienteDeCobrar", PendienteDeCobrar)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idFacturaCancela", IDfacturaCancela)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idCuenta", IDcuenta.IDcuenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuotas", CantidadCuotas)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@transferencia", NumeroTransferencia)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@lote", Lote)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idtarjeta", IDTarjeta.IDtarjeta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nrotarjeta", NumeroTarjeta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@tipodocumento", TipoDocumento)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@esConsumidorFinal", EsConsumidorFinal)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteSPNonQuery(INSERTAR_FACTURA, oParametros)

            oParametros = Nothing



        Catch ex As Exception
            'No se guarda porque hay rollbck y se pierde el catch superior se encarga
            ErrorLog.Create(UsuarioLogin, ex)
            'MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            'Throw ex
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Trae el ID de una factura
    ''' </summary>
    ''' <param name="strNroFactura">nroFactura</param>
    ''' <returns>ID de la factura</returns>
    ''' <remarks></remarks>
    Public Function TraerIDFactura(ByVal strNroFactura As String, ByVal intIdCuenta As Int16, ByVal intTipoComprobante As Int16) As Integer
        Dim intID As Integer = 0
        Try
            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            conexion.Command.Parameters.Clear()
            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@nrofactura", strNroFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing


            oParameter = New OleDb.OleDbParameter("@idcuenta", intIdCuenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idTipoComprobante", intTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            intID = conexion.ExecuteSPScalar(TRAER_ID_FACTURA, oParametros)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function

 


    Public Sub BuscarFacturas(ByVal strEmpresa As String, ByVal strCliente As String, _
                              ByVal strValorBusqueda As String, _
                              ByVal strFechaInicio As String, _
                              ByVal strFechaFin As String, _
                              ByRef dsData As dsDatos)
        Try

            dsData = New dsDatos

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            If String.IsNullOrWhiteSpace(strValorBusqueda) Then strValorBusqueda = DBNull.Value.ToString


            oParameter = New OleDb.OleDbParameter("@nroFactura", strValorBusqueda)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cliente", strCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechainicio", strFechaInicio)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechafin", strFechaFin)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(BUSCAR_FACTURAS, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                             dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try
    End Sub

    ''' <summary>
    ''' Trae los datos que componen una factura
    ''' </summary>
    ''' <param name="intTipoComprobante">Indica si se va a buscar factura A  (1) or factura B (6)</param>
    ''' <param name="strFactura">Nro de factura de la que se van a traer los datos</param>
    ''' <param name="strCuenta">Empresa de la que se van a obtener los datos</param>
    ''' <param name="dsData">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub TraerDatosFactura(ByVal intTipoComprobante As SByte, ByVal strFactura As String, ByVal strCuenta As String, ByRef dsData As dsDatos)
        Try

            If dsData Is Nothing Then dsData = New dsDatos

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@idtipocomprobante", intTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nrofactura", strFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuenta", strCuenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(TRAER_DATOS_FACTURA, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                             dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try

    End Sub


    Public Sub EliminarFactura(ByVal intIdFactura As Integer)
        Try

            conexion.Command.Parameters.Clear()

            conexion.ExecuteSPNonQuery(ELIMINAR_FACTURA, "@idfactura", intIdFactura)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try

    End Sub

#End Region
#Region "Remitos"

    ''' <summary>
    ''' Lista los remitos pendientes de facturar
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarRemitosPendientesDeFacturar(ByVal strEmpresa As String, _
                                                 ByVal strCliente As String, _
                                                 ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@empresa", strEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cliente", strCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oDatos = conexion.ExecuteDataset(LISTAR_REMITOS_A_CANCELAR_FACTURAS, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                            Nothing)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza un remito cambiando el estado de pendiente de facturar y el ID de la factura que lo cancela.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CancelarRemitoContraFactura() As Boolean
        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@numeroFactura", NumeroFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idFacturaCancela", IDfacturaCancela)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteSPNonQuery(CANCELAR_REMITOS_CONTRA_FACTURA, oParametros)
            oParametros = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Trae el proximo nro de remito
    ''' </summary>
    ''' <param name="intTipoComprobante">ID de comprobante, sale de la tabla tbltiposcomprobantes</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerProximoRemito(ByVal intTipoComprobante As Byte,
                                       ByVal strNombreEmpresa As String) As Double
        Dim oLector As OleDb.OleDbDataReader
        Dim nroRemito As Double = 1
        Try

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            'oParameter = New OleDb.OleDbParameter("@puestoventa", strPuestoDeVenta)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idTipoComprobante", intTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oLector = conexion.ExecuteReaderStoredProcedure(TRAER_REMITO_PROXIMO, oParametros)

            oParametros = Nothing

            If oLector.HasRows Then
                oLector.Read()
                If Not oLector.IsDBNull(0) Then
                    nroRemito = CDbl(oLector.Item(0)) + 1
                End If

            End If

            oLector.Close()
            oLector = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
        Return nroRemito

    End Function

    ''' <summary>
    ''' Actualiza el estado a activo=0 de una factura al generar una nota de credito.
    ''' </summary>
    ''' <param name="intIDfacturAcancelar">ID de la factura a cancelar</param>
    ''' <remarks></remarks>
    Public Sub CancelarFactura(ByVal intIDfacturAcancelar As Integer)
        Try
            conexion.Command.Parameters.Clear()

            'Dim oParametros As OleDb.OleDbParameterCollection
            'Dim oParameter As OleDb.OleDbParameter

            'oParametros = conexion.Command.Parameters

            'oParameter = New OleDb.OleDbParameter("@nroFactura", strFacturaCancelada)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            'oParameter = New OleDb.OleDbParameter("@idcuenta", IDcuenta.IDcuenta)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            'conexion.ExecuteSPNonQuery(CANCELAR_FACTURA, oParametros)
            'oParametros = Nothing


            conexion.ExecuteSPNonQuery(CANCELAR_FACTURA, "@idFacturaACancelar", intIDfacturAcancelar)


        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try

    End Sub
#End Region

#Region "Recibos"
    ''' <summary>
    ''' Trae el proximo nro de recibo
    ''' </summary>
    ''' <param name="intTipoComprobante">ID de comprobante, sale de la tabla tbltiposcomprobantes</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerProximoRecibo(ByVal intTipoComprobante As Byte,
                                       ByVal strNombreEmpresa As String) As Double
        Dim oLector As OleDb.OleDbDataReader
        Dim nroRecibo As Double = 1
        Try

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            'oParameter = New OleDb.OleDbParameter("@puestoventa", strPuestoDeVenta)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idTipoComprobante", intTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oLector = conexion.ExecuteReaderStoredProcedure(TRAER_RECIBO_PROXIMO, oParametros)

            oParametros = Nothing

            If oLector.HasRows Then
                oLector.Read()
                If Not oLector.IsDBNull(0) Then
                    nroRecibo = CDbl(oLector.Item(0)) + 1
                End If

            End If

            oLector.Close()
            oLector = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
        Return nroRecibo

    End Function

    Public Sub InsertarMetodosDePago(ByVal intIDfactura As Integer, _
                        ByVal idBanco As Integer, _
                        ByVal nroCheque As String, _
                        ByVal sngMontoCheque As Single, _
                        ByVal sngEfectivo As Single, _
                        ByVal blnTerceros As Boolean, _
                        ByVal sngCredito As Single, _
                        ByVal sngDebito As Single, _
                        ByVal sngRetenciones As Single)

        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@idFactura", intIDfactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@idBanco", idBanco)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nroCheque", nroCheque)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@montoChque", sngMontoCheque)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@efectivo", sngEfectivo)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@terceros", blnTerceros)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@montoCredito", sngCredito)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@montoDebito", sngDebito)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@montoRetenciones", sngRetenciones)
            oParametros.Add(oParameter)
            oParameter = Nothing


            conexion.ExecuteSPNonQuery(INSERTAR_METODOS_PAGO_FACTURA, oParametros)

            oParametros = Nothing
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    Public Function IsReciboExistente(ByVal strNroRecibo As String, ByVal strNombreEmpresa As String) As Boolean
        Try
            Dim intRowCount As Integer = 0

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            conexion.Command.Parameters.Clear()
            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@nroRecibo", strNroRecibo)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuenta", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            intRowCount = conexion.ExecuteSPScalar(VALIDAR_RECIBO_NUEVO, oParametros)

            oParametros = Nothing

            If intRowCount > 0 Then
                Return True
            End If


        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return True
        End Try
        Return False
    End Function


    Public Sub BuscarRecibos(ByVal strEmpresa As String, ByVal strCliente As String, _
                           ByVal strValorBusqueda As String, _
                           ByVal strFechaInicio As String, _
                           ByVal strFechaFin As String, _
                           ByRef dsData As dsDatos)
        Try

            dsData = New dsDatos

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            If String.IsNullOrWhiteSpace(strValorBusqueda) Then strValorBusqueda = DBNull.Value.ToString


            oParameter = New OleDb.OleDbParameter("@nroFactura", strValorBusqueda)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cliente", strCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechainicio", strFechaInicio)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechafin", strFechaFin)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(BUSCAR_RECIBOS, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                             dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try
    End Sub

    ''' <summary>
    ''' Trae los datos que componen un recibo
    ''' </summary>
    ''' <param name="intTipoComprobante">Indica el comprobante que se va a buscar por ahora por default 36</param>
    ''' <param name="strFactura">Nro de recibo de la que se van a traer los datos</param>
    ''' <param name="strCuenta">Empresa de la que se van a obtener los datos</param>
    ''' <param name="dsData">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub TraerDatosRecibo(ByVal intTipoComprobante As SByte, ByVal strFactura As String, ByVal strCuenta As String, ByRef dsData As dsDatos)
        Try

            If dsData Is Nothing Then dsData = New dsDatos

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@idtipocomprobante", intTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@nrofactura", strFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuenta", strCuenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(TRAER_DATOS_RECIBO, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                             dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try

    End Sub


    ''' <summary>
    ''' Trae los datos que componen un recibo
    ''' </summary>
    ''' <param name="strFactura">Nro de recibo de la que se van a traer los datos</param>
    ''' <param name="strCuenta">Empresa de la que se van a obtener los datos</param>
    ''' <param name="dsData">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub TraerDetalleRecibo(ByVal strFactura As String, ByVal strCuenta As String, ByRef dsData As dsDatos)
        Try

            If dsData Is Nothing Then dsData = New dsDatos

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@nrofactura", strFactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuenta", strCuenta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(TRAER_DETALLE_RECIBO, _
                                            TABLA_PAGOS_FACTURAS, _
                                            True, _
                                            oParametros, _
                                             dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try

    End Sub


#End Region

#Region "Cobranzas"
    ''' <summary>
    ''' Lista los cheques
    ''' </summary>
    '''<param name="strNombreEmpresa">Nombre de la cuenta o empresa sobre la que se genera el listado</param>
    ''' <param name="dteFechaDesde">Fecha de inicio del informe</param>
    ''' <param name="dteFechaHasta">Fecha tope del informe</param>
    ''' <param name="strCriterioBusqueda">Contado o Cta Cte</param>
    ''' <param name="blnAmbasOpciones">Indica si se busca por los 2 criterios</param>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarCobranzas(ByVal strNombreEmpresa As String, _
                         ByVal dteFechaDesde As Date, _
                         ByVal dteFechaHasta As Date, _
                         ByVal strCriterioBusqueda As String, _
                         ByVal blnAmbasOpciones As Boolean, _
                         ByRef oDatos As dsDatos)

        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaDesde", Format(dteFechaDesde, formatoEscritura))
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaHasta", Format(dteFechaHasta, formatoEscritura))
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@criterioBusqueda", strCriterioBusqueda)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@incluirConsumidorFinal", blnAmbasOpciones)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteDataset(LISTAR_COBRANZAS, _
                                            DATA_TABLE_COBRANZAS, _
                                            True, _
                                            oParametros, _
                                            oDatos)

            oParametros = Nothing
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub
 
    ''' <summary>
    ''' Lalalala
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarConsumidorFinal(ByRef oDatos As dsDatos)

        Try
            conexion.Command.Parameters.Clear()

            'Dim oParametros As OleDb.OleDbParameterCollection
            'Dim oParameter As OleDb.OleDbParameter

            'oParametros = conexion.Command.Parameters

            conexion.ExecuteDataset(LISTAR_CONSUMIDOR_FINAL, TABLA_CONSUMIDOR_FINAL, True, Nothing, oDatos)

            ' oParametros = Nothing
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

#End Region

#Region "Estado de cuenta"
    ''' <summary>
    ''' Genera el estado de cuenta de un cliente.
    ''' </summary>
    ''' <param name="strFechaInicio">Fecha de incio de busqueda de datos</param>
    ''' <param name="strFechaFin">Fecha de fin de busqueda de datos</param>
    ''' <param name="strCliente">Razon social del cliente a buscar</param>
    ''' <param name="strEmpresa">Cuenta o empresa sobre la que se realiza la busqueda</param>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub GenerarEstadoDeCuenta(ByVal strFechaInicio As String, _
                                     ByVal strFechaFin As String, _
                                     ByVal strCliente As String, _
                                     ByVal strEmpresa As String, _
                                     ByRef oDatos As dsDatos, _
                                     ByVal strTableName As String,
                                     ByVal blnIncluirConsumidorFinal As Boolean)

        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@fechainicio", strFechaInicio)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechafin", strFechaFin)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@razonsocial", strCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuenta", strEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing


            If blnIncluirConsumidorFinal Then
                conexion.ExecuteDataset(TRAER_ESTADO_DE_CUENTA2, _
                                         strTableName, _
                                         True, _
                                         oParametros, _
                                         oDatos)
            Else
                conexion.ExecuteDataset(TRAER_ESTADO_DE_CUENTA, _
                                                strTableName, _
                                                True, _
                                                oParametros, _
                                                oDatos)
            End If
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub
 
    ''' <summary>
    ''' Genera el reporte de IVA Ventras
    ''' </summary>
    ''' <param name="strFechaInicio">Fecha de incio de busqueda de datos</param>
    ''' <param name="strFechaFin">Fecha de fin de busqueda de datos</param>
    ''' <param name="strEmpresa">Cuenta o empresa sobre la que se realiza la busqueda</param>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub GenerarIVAventas(ByVal strFechaInicio As String, _
                                     ByVal strFechaFin As String, _
                                     ByVal strEmpresa As String, _
                                     ByRef oDatos As dsDatos)

        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters


            oParameter = New OleDb.OleDbParameter("@nombreEmpresa", strEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechainicio", strFechaInicio)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechafin", strFechaFin)
            oParametros.Add(oParameter)
            oParameter = Nothing


            conexion.ExecuteDataset(GENERAR_IVA_VENTAS, _
                                            TABLA_FACTURAS, _
                                            True, _
                                            oParametros, _
                                            oDatos)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub



#End Region


#Region "Notas de Credito"
    ''' <summary>
    ''' Trae el proximo nro de nota de credito dependiendo si es A o B y de que empresa.
    ''' </summary>
    ''' <param name="strTipoComprobante">Indica si es Nota de Credito A o B</param>
    ''' <param name="strNombreEmpresa">Nombre de la cuenta para la cual se quiere generar un comprobante</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerProximaNotaDeCredito(ByVal strTipoComprobante As String,
                                        ByVal strNombreEmpresa As String) As Double
        Dim oLector As OleDb.OleDbDataReader
        Dim nroFactura As Int64 = 1
        Try

            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@tipocomprobante", strTipoComprobante)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@NombreEmpresa", strNombreEmpresa)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oLector = conexion.ExecuteReaderStoredProcedure(TRAER_NOTA_DE_CREDITO_PROXIMA, oParametros)

            oParametros = Nothing

            If oLector.HasRows Then
                oLector.Read()
                If Not oLector.IsDBNull(0) Then
                    nroFactura = CDbl(oLector.Item(0)) + 1
                End If

            End If

            oLector.Close()
            oLector = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
        Return nroFactura

    End Function
#End Region
End Class

Public Class FacturaItems
#Region "Propiedades"
    Public Property IDitemFactura As Integer
    Public Property IDfactura As Factura
    Public Property Descripcion As String
    Public Property Cantidad As Integer
    Public Property PrecioUnitario As Decimal
    Public Property Importe As Decimal
    Public Property IncluyeIVA As Boolean
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
    ''' Inicializa el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        IDfactura = New Factura()
    End Sub

    ''' <summary>
    ''' Inserta los items de una factura en la base
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NuevoItemFactura() As Boolean
        Try
            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            conexion.Command.Parameters.Clear()
            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@idfactura", IDfactura.IDfactura)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@descripcion", Descripcion)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cantidad", Cantidad)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@preciounitario", PrecioUnitario)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@importe", Importe)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@incluyeIva", IncluyeIVA)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteSPNonQuery(INSERTAR_FACTURA_ITEMS)

            oParametros = Nothing


        Catch ex As Exception
            'No se guarda porque hay rollbck y se pierde el catch superior se encarga
            'ErrorLog.Create(UsuarioLogin, ex)
            'MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Throw ex
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Trae los items de una factura
    ''' </summary>
    '''<param name="intIDFactura">ID de la factura que se quieren obtener los items</param>
    ''' <param name="dsData">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub TraerDatosFacturaItems(ByVal intIDFactura As Integer, ByRef dsData As dsDatos)
        Try

            If dsData Is Nothing Then dsData = New dsDatos

            If Not dsData.Tables(TABLA_FACTURA_ITEMS) Is Nothing Then dsData.Tables(TABLA_FACTURA_ITEMS).Clear()
            conexion.Command.Parameters.Clear()

            conexion.ExecuteDataset(TRAER_DATOS_FACTURA_ITEMS, TABLA_FACTURA_ITEMS, "@idfactura", intIDFactura, True, dsData)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

        End Try

    End Sub
#End Region


End Class