Public Class Cliente
#Region "Miembros"
    Public Property idCliente As Integer
    Public Property RazonSocial As String
    Public Property condicionIva As String
    Public Property Cuit As String
    Public Property Direccion As String
    Public Property CodigoPostal As String
    Public Property Localidad As String
    Public Property Provincia As String
    Public Property FormaPago As String
    Public Property FechaAlta As DateTime
    Public Property FechaModificacion As DateTime
    Public Property FechaBaja As DateTime
    Public Property Activo As Boolean
    Public Property Email As String
    Public Property Telefono As String
    Public Property Movil As String

#End Region
#Region "Metodos"
    ''' <summary>
    ''' Inserta un nuevo cliente en la base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NuevoCliente() As Boolean
        Try
            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            conexion.Command.Parameters.Clear()
            oParametros = conexion.Command.Parameters

            oParameter = New OleDb.OleDbParameter("@razonsocial", RazonSocial)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@condicionfiscal", condicionIva)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuit", Cuit)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@direccion", Direccion)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@codigopostal", CodigoPostal)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@localidad", Localidad)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@provincia", Provincia)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@formapago", FormaPago)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaAlta", FechaAlta)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@email", Email)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@telefono", Telefono)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@movil", Movil)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteSPNonQuery(INSERTAR_CLIENTE)

            oParametros = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Destruye el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        MyBase.Finalize()
    End Sub

    ' ''' <summary>
    ' ''' Trae los clientes en la base de datos
    ' ''' </summary>
    ' ''' <param name="strValorBusqueda">Nombre del cliente a buscar</param>
    ' ''' <param name="dsData">Dataset con los clientes</param>
    ' ''' <remarks></remarks>
    'Public Sub TraerClientesxNombre(ByVal strValorBusqueda As String, ByRef dsData As dsDatos)

    '    Try

    '        conexion.Command.Parameters.Clear()
    '        dsData = conexion.ExecuteDataset(TRAER_RAZON_SOCIAL_XCLIENTES, _
    '                                TABLA_CLIENTES, _
    '                              "@ValorBusqueda", _
    '                              strValorBusqueda,
    '                              True, _
    '                              dsData)


    '    Catch ex As Exception
    '        ErrorLog.Create(UsuarioLogin, ex)
    '        MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)

    '    End Try

    'End Sub

    ''' <summary>
    ''' Trae los clientes en el sistema
    ''' </summary>
    ''' <param name="intCampoBusqueda">campo por el cual se va buscar un cliente</param>
    ''' <param name="strValorBusqueda">Valor de busqueda</param>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarClientes(ByVal intCampoBusqueda As Integer, _
                              ByVal strValorBusqueda As String, _
                              ByRef oDatos As dsDatos)
        Try
            conexion.Command.Parameters.Clear()
            If String.IsNullOrWhiteSpace(strValorBusqueda) Then
                conexion.ExecuteDataset(LISTAR_CLIENTES_TODOS, _
                                                TABLA_CLIENTES, _
                                                True, _
                                                Nothing, _
                                                oDatos)
            Else
                Dim oParametros As OleDb.OleDbParameterCollection
                Dim oParameter As OleDb.OleDbParameter

                oParametros = conexion.Command.Parameters

                oParameter = New OleDb.OleDbParameter("@campoBusqueda", intCampoBusqueda)
                oParametros.Add(oParameter)
                oParameter = Nothing

                oParameter = New OleDb.OleDbParameter("@valorbusqueda", strValorBusqueda)
                oParametros.Add(oParameter)
                oParameter = Nothing

                oDatos = conexion.ExecuteDataset(LISTAR_CLIENTES, _
                                                TABLA_CLIENTES, _
                                                True, _
                                                oParametros, _
                                                oDatos)

                oParametros = Nothing
            End If
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

    ''' <summary>
    ''' Trae el ID de un cliente
    ''' </summary>
    ''' <param name="strRazonSocial">Razon social del cliente</param>
    ''' <returns>ID del cliente</returns>
    ''' <remarks></remarks>
    Public Function TraerIDCliente(ByVal strRazonSocial As String) As Integer
        Dim intID As Integer = 0
        Try
            conexion.Command.Parameters.Clear()
            intID = conexion.ExecuteSPScalar(TRAER_ID_CLIENTE_X_RAZON_SOCIAL, _
                                             "@razonsocial", _
                                             strRazonSocial)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function


    ''' <summary>
    ''' Trae un cliente dado una razon social
    ''' </summary>
    ''' <param name="strRazonSocial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerCUITcliente(ByVal strRazonSocial As String) As String
        Dim strcuit As String = String.Empty
        Dim dsCliente As dsDatos

        dsCliente = New dsDatos

        Try
            conexion.Command.Parameters.Clear()
            dsCliente = conexion.ExecuteDataset(TRAER_CUIT_CLIENTE_X_RAZON_SOCIAL, _
                                             TABLA_CLIENTES, _
                                             "@razonsocial", _
                                             strRazonSocial, _
                                             True, _
                                             dsCliente)

            If dsCliente.Tables(TABLA_CLIENTES).Rows.Count > 0 Then
                strcuit = dsCliente.Tables(TABLA_CLIENTES).Rows(0).Item("cuit").ToString()
            End If
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return strcuit
        End Try
        Return strcuit
    End Function
    ''' <summary>
    ''' Trae los datos personales de un cliente
    ''' Ej: Localidad, domicilio, telefono, etc
    ''' </summary>
    ''' <param name="strRazonSocial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerDatosPersonales(ByVal strRazonSocial As String) As Cliente

        Dim dsCliente As dsDatos
        dsCliente = New dsDatos

        Dim oCliente As Cliente
        oCliente = New Cliente

        Try
            conexion.Command.Parameters.Clear()
            dsCliente = conexion.ExecuteDataset(TRAER_DATOS_PERSONALES_CLIENTE, _
                                             TABLA_CLIENTES, _
                                             "@razonsocial", _
                                             strRazonSocial, _
                                             True, _
                                             dsCliente)

            If dsCliente.Tables(TABLA_CLIENTES).Rows.Count > 0 Then
                oCliente.Direccion = dsCliente.Tables(TABLA_CLIENTES).Rows(0).Item("direccion").ToString()
                oCliente.Localidad = dsCliente.Tables(TABLA_CLIENTES).Rows(0).Item("localidad").ToString()
                oCliente.condicionIva = dsCliente.Tables(TABLA_CLIENTES).Rows(0).Item("condicionFiscal").ToString()
            End If
            dsCliente.Dispose()
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return Nothing
        End Try
        Return ocliente
    End Function



    ''' <summary>
    ''' Verifica que el cliente no exista antes de ingresarlo
    ''' </summary>
    ''' <param name="strCUIT">Numero de cuit que se quiere ingresar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsClienteExistente(ByVal strCUIT As String) As Boolean
        'Public Function IsClienteExistente(ByVal strRazonSocial As String, Optional ByVal strCUIT As String = "") As Boolean
        Try
            Dim intRowCount As Integer = 0
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters

            'oParameter = New OleDb.OleDbParameter("@nombre", strRazonSocial)
            'oParametros.Add(oParameter)
            'oParameter = Nothing

            If Not String.IsNullOrEmpty(strCUIT) Then
                oParameter = New OleDb.OleDbParameter("@cuit", strCUIT)
                oParametros.Add(oParameter)
                oParameter = Nothing
            Else
                oParameter = New OleDb.OleDbParameter("@cuit", DBNull.Value)
                oParametros.Add(oParameter)
                oParameter = Nothing
            End If

            intRowCount = conexion.ExecuteSPScalar(VALIDAR_CLIENTE_NUEVO, oParametros)

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

    ''' <summary>
    ''' Actualiza un cliente en la base
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ActualizarCliente() As Boolean
        Try
            conexion.Command.Parameters.Clear()

            Dim oParametros As OleDb.OleDbParameterCollection
            Dim oParameter As OleDb.OleDbParameter

            oParametros = conexion.Command.Parameters
            oParameter = New OleDb.OleDbParameter("@razonsocial", RazonSocial)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@condicionfiscal", condicionIva)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@cuit", Cuit)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@direccion", Direccion)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@codigopostal", CodigoPostal)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@localidad", Localidad)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@provincia", Provincia)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@formapago", FormaPago)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@fechaModificacion", FechaModificacion)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@email", Email)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@telefono", Telefono)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@movil", Movil)
            oParametros.Add(oParameter)
            oParameter = Nothing

            oParameter = New OleDb.OleDbParameter("@id", idCliente)
            oParametros.Add(oParameter)
            oParameter = Nothing

            conexion.ExecuteSPNonQuery(ACTUALIZAR_CLIENTE, oParametros)
            oParametros = Nothing

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Elimina un cliente de la base seteando su estado a 0
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EliminarCliente() As Boolean
        Try
            conexion.Command.Parameters.Clear()

            conexion.ExecuteSPNonQuery(ELIMINAR_CLIENTE, "@id", idCliente)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return False
        End Try
        Return True
    End Function
#End Region
End Class


''' <summary>
''' Para manejar la tabla CLIENTES que trae los datos de la CENT
''' </summary>
''' <remarks></remarks>
Public Class ClienteCENT
#Region "Propiedades"
    Public Property PlaniNro As Integer 'Nro de planilla
    Public Property ReviFch As Date 'Fecha de la RTO
    Public Property ReviTpo As String 'Tipo de revision
    Public Property ReviUso As String 'Tipo de uso
    Public Property Jurisdicci As String 'Jurisdiccion
    Public Property JurisX As String '?? segun manual ni puta idea
    Public Property InicioFch As Date 'Inicio de la revision
    Public Property FinalFch As Date 'Fin de la revision
    Public Property GrabadoFch As Date 'Ultima modificacion del registro
    Public Property Hora As String 'Hora de la RTO
    Public Property Resultado As Integer 'Codigo de resultado de la RTO
    Public Property Observacio As String 'Observaciones de la RTO
    Public Property Anomalias As String 'Codigos de las anomalias detectadas
    Public Property VencFch As Date 'Vencimiento de la RTO
    Public Property Serie As String 'Serie del certificado emitido
    Public Property CertiNro As Integer 'N° del certificado emitido
    Public Property DocPresent As String 'Documentacion presentada
    Public Property DocPresDsc As String 'Descripcion de la documentacion presentada
    Public Property Dominio As String 'Dominio del vehiculo
    Public Property DominioFmt As String 'Formato del dominio del vehiculo
    Public Property DominioAnt As String 'Dominio anterior (vehiculos reempadronados)
    Public Property Categoria As String 'Categoria del vehiculo
    Public Property EmpLinea As String 'Linea (Colectivos)
    Public Property Interno As Integer 'Numero de interno
#End Region
End Class