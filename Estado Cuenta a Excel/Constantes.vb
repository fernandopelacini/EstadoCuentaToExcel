Public Module Constantes
#Region "Mensajes"
    Public Const MENSAJE_ERROR As String = "Se ha producido un error. Por favor contacte con soporte"
    Public Const RED_NO_DISPONIBLE As String = "Se ha perdido la conexión con el servidor." + ControlChars.Cr + _
                                            "Verifique la misma o se perderán los cambios"
    Public Const RED_DISPONIBLE As String = "Se ha restablecido la conexión con el servidor."
    Public Const APPLICATION_NAME As String = "Verificacion Norte"
    Public Const CAMPO_OBLIGATORIO As String = "Campo obligatorio"
    Public Const MODULO_LIBERADO As String = "El módulo fue liberado correctamente."
    Public Const VALOR_COMBO As String = "Seleccione un valor del combo"
    Public Const PASS_NO_COINCIDE As String = "Las passwords no coinciden"
    Public Const CAMBIO_PASS_OK As String = "Su password se modificó con éxito." + ControlChars.Cr + _
                                 "Debe reiniciar la aplicacion para que los cambios tengan efecto."
    Public Const USUARIO_EXISTENTE As String = "El usuario ingresado ya existe en el sistema." + ControlChars.Cr + _
                                 "Por favor ingrese otro ID de usuario."
    Public Const BANCO_EXISTENTE As String = "El banco ingresado ya existe en el sistema." + ControlChars.Cr + _
                                 "Por favor ingrese otro banco."
    Public Const ROL_EXISTENTE As String = "El rol ingresado ya existe en el sistema." + ControlChars.Cr + _
                                "Por favor ingrese otro valor."
    Public Const CHEQUE_EXISTENTE As String = "El nro de cheque ingresado ya existe en el sistema." + ControlChars.Cr + _
                                "Por favor ingrese otro valor."
    Public Const PROVEEDOR_EXISTENTE As String = "El proveedor ingresado ya existe en el sistema." + ControlChars.Cr + _
                                "Por favor ingrese otro valor."
    Public Const CLIENTE_EXISTENTE As String = "El CUIT/L ingresado ya existe en el sistema." + ControlChars.Cr + _
                                "Por favor ingrese otro valor."
    Public Const CUENTA_CONTABLE_EXISTENTE As String = "La cuenta contable ingresada ya existe en el sistema." + ControlChars.Cr + _
                              "Por favor ingrese otro valor."
    Public Const EMPRESA_EXISTENTE As String = "La empresa ingresada ya existe en el sistema." + ControlChars.Cr + _
                             "Por favor ingrese otro valor."
    Public Const GASTO_EXISTENTE As String = "El gasto ingresado ya existe en el sistema." + ControlChars.Cr + _
                                "Por favor verifique sus datos."
    Public Const COMPRA_EXISTENTE As String = "La compra ingresada ya existe en el sistema." + ControlChars.Cr + _
                               "Por favor verifique sus datos."
    Public Const NOTA_CREDITO_EXISTENTE As String = "La nota de crédito ingresada ya existe en el sistema." + ControlChars.Cr + _
                             "Por favor verifique sus datos."
    Public Const FORMATO_CORREO_INCORRECTO As String = "La dirección de E-mail no tiene un formato valido." + ControlChars.Cr + _
                                 "Ejemplo: 'someone@example.com' """
    Public Const INGRESE_VALOR_BUSQUEDA As String = "Ingrese un valor para la busqueda"
    Public Const MODULO_BLOQUEADO As String = "No se pudo acceder al modulo seleccionado." + ControlChars.Cr + _
                                "El mismo se encuentra bloqueado por el usuario: "
    Public Const ARTICULO_EXISTENTE As String = "El articulo ingresado ya existe en el sistema." + ControlChars.Cr + _
                                 "Por favor ingrese otro articulo."
    Public Const FORMATO_INCORRECTO As String = "Formato incorrecto"
    Public Const USUARIO_O_PASS_INCORRECTA As String = "El usuario y/o el password ingresados son incorrectos."
    Public Const DATOS_GUARDO_OK As String = "Los datos se guardaron correctamente."
    Public Const DATOS_ACTUALIZO_OK As String = "Los datos se actualizarón correctamente."
    Public Const DATOS_ELIMINO_OK As String = "Los datos se eliminaron correctamente."
    Public Const CUIT_INCORRECTO As String = "El nro. de cuit/l ingresado no es valido."
    Public Const NO_HAY_DATOS As String = "No se encontraron datos de acuerdo a los criterios de busqueda"
    Public Const DESEA_CARGAR_NUEVO_CLIENTE As String = "Desea ingresar un nuevo cliente?"
    Public Const SELECCIONE_VALOR_LISTA As String = "Seleccione un valor de la lista para continuar."
    Public Const SELECCIONE_CRITERIO_BUSQUEDA As String = "Seleccione un criterio de busqueda"
    Public Const FECHA_INCORRECTA As String = "La fecha ingresada no es valida."
    Public Const NO_HAY_MENUES_CARGADOS As String = "No se encontraron Menues del sistema." + ControlChars.Cr + "Por favor contacte con soporte."
    Public Const CHEQUE_ASIGNO_OK As String = "El cheque fue asignado correctamente."
    Public Const NO_HAY_METODOS_PAGO_ASIGNADOS As String = "No se han seleccionado metodos de pago."
    Public Const METODO_PAGO_EXCEDE_MONTO_TOTAL As String = "Las formas de pago seleccionadas superan el total indicado." + ControlChars.Cr + _
                                                            "Desea continuar de todas formas?"

    Public Const FACTURA_NO_TIENE_ITEMS As String = "La factura no contiene items."
    Public Const NUMERO_COMPROBANTE_NO_VALIDO As String = "El n° de comprobante no es valido"
    Public Const SELECCIONE_REMITOS_A_CANCELAR As String = "Seleccione uno o más remitos a cancelar"
    Public Const IMPRESION_COMPROBANTE As String = "Se procederá a imprimir el comprobante"
    Public Const EFECTIVO_SUPERA_TOTAL As String = "El monto en efectivo supera al monto total"
    Public Const SELECCIONE_CLIENTE As String = "Seleccione un cliente"
    Public Const EL_CLIENTE As String = "El cliente: "
    Public Const NO_TIENE_REMITOS_ASOCIADOS As String = " No posee remitos."
    Public Const CAEA_NO_VALIDO As String = "El número de CAE no es válido." + ControlChars.Cr + "Por favor contacte con su supervisor."
    Public Const NO_APLICA As String = "N/A"
    Public Const FECHA_MINIMA_LISTADO As String = "1900-01-01 12:00:00"
    Public Const FECHA_MAXIMA_LISTADO As String = "9999-01-01 12:00:00"
    Public Const SERVICIO_AFIP_NO_DISPONIBLE As String = "Servicio Web AFIP no disponible. Intente nuevamente." + ControlChars.Cr + _
                                                        "De persistir el problema comunicarse con mesa de ayuda de AFIP al: 0800-999-2347" + ControlChars.Cr + _
                                                        "De Lunes a Viernes de 08:00 a 20:00 horas."
    Public Const SERVICIO_AFIP_ERROR As String = "Error en servicios AFIP. Vuelva a intentar nuevamente."
    Public Const CUIT_VERIFICADORA_DEL_NORTE As String = "30712017321"
    Public Const CUIT_INGRASSIA_ROSA_Y_SHINA As String = "33714814309"

    Public Const URL_WSFE_Produccion As String = "https://servicios1.afip.gov.ar/wsfev1/service.asmx"
    Public Const URL_WSFE_HOMOLOGACION As String = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx"

    Public Const URL_CENT_LISTAR_ULTIMAS_REVISIONES_DESARROLLO As String = "http://demo3.cent.gov.ar/rto/wsFacturacion/listarUltimasRevisiones"
    Public Const URL_CENT_LISTAR_ULTIMAS_REVISIONES_PRODUCCION As String = "http://rto.cent.gov.ar/rto/wsFacturacion/listarUltimasRevisiones"

    Public Const WEB_SERVICE_FACTURA_ELECTRONICA As String = "wsfe"
    Public Const WEB_SERVICE_CENT As String = "cent"

    Public Const ERROR_AUTORIZAR_COMPROBANTE As String = "Error al autorizar comprobante. Corrija los siguientes errores:"
    Public Const SITUACION_FISCAL_NO_CORRESPONDE As String = "El comprobante seleccionado no corresponde con la situación fiscal del cliente." + ControlChars.Cr + _
                                                              "Por favor elija el comprobante correcto."
    Public Const PROCEDERA_AUTORIZAR_COMPROBANTE_AFIP As String = "Se procedera a autorizar el comprobante en la AFIP." + ControlChars.Cr + _
                                                                 "Aguarde un instante por favor."

    Public Const PROCEDERA_OBTENER_DATOS_CENT As String = "Se procedera a obtener las revisiones de la CENT." + ControlChars.Cr + _
                                                                 "Aguarde un instante por favor."


    Public Const RECIBO_EXISTENTE As String = "El recibo ingresado ya existe en el sistema." + ControlChars.Cr + _
                             "Por favor ingrese otro numero de comprobante."
    Public Const FACTURAS_A As String = "FACTURAS A"
    Public Const FACTURAS_B As String = "FACTURAS B"
    Public Const NOTAS_DE_CREDITO_A As String = "NOTAS DE CREDITO A"
    Public Const FACTURAS_M As String = "FACTURAS M"
    Public Const NOTAS_DE_CREDITO_M As String = "NOTAS DE CREDITO M"

    Public Const METODO_PAGO_EFECTIVO As String = "Efectivo"
    Public Const METODO_PAGO_TARJETA_DEBITO As String = "Tarjeta Débito"
    Public Const METODO_PAGO_TARJETA_CREDITO As String = "Tarjeta Crédito"
    Public Const METODO_PAGO_CHEQUE As String = "Cheque"
    Public Const METODO_PAGO_TRANSFERENCIA As String = "Transferencia"
    Public Const METODO_PAGO_CUENTA_CORRIENTE As String = "Cuenta Corriente"

    Public Const WEB_REQUEST_AJAX_TRUE As String = "ajax=true"
    Public Const WEB_REQUEST_J_USER_NAME As String = "&j_username="
    Public Const WEB_REQUEST_J_PASSWORD As String = "&j_password="
    Public Const WEB_REQUEST_METHOD_POST As String = "POST"
    Public Const WEB_REQUEST_CONTENT_TYPE As String = "application/x-www-form-urlencoded"
    Public Const WEB_REQUEST_COD_TALLER_95 As String = "cod_taller=95"
    Public Const WEB_REQUEST_ULTIMA_REVISION As String = "&ultima="
    Public Const WEB_REQUEST_FORMAT_JSON As String = "&format=json"
    Public Const WEB_REQUEST_AUTHORIZATION_TOKEN As String = "&auth_token="
    Public Const WEB_REQUEST_VERSION_2003 As String = "&version2003=false"
#End Region

#Region "Data tables"
    Public Const DATA_TABLE_TOTALES As String = "dtTotales"
    Public Const DATA_TABLE_COBRANZAS As String = "dtCobranzas"
    Public Const DATA_TABLE_ESTADO_CUENTA As String = "dtEstadoCuenta"

#End Region

#Region "Tablas"
    Public Const TABLA_USUARIOS As String = "tblUsuarios"
    Public Const TABLA_ROLES As String = "tblRoles"
    Public Const TABLA_CLIENTES As String = "tblClientes"
    Public Const TABLA_CLIENTES_FACTURACION As String = "Clientes"
    Public Const TABLA_BANCOS As String = "tblBancos"
    Public Const TABLA_CHEQUES As String = "tblCheques"
    Public Const TABLA_BLOQUEOS As String = "tblBloqueos"
    Public Const TABLA_CUENTAS As String = "tblCuentas"
    Public Const TABLA_PROVEEDORES As String = "tblProveedores"
    Public Const TABLA_GASTOS As String = "tblGastos"
    Public Const TABLA_COMPRAS As String = "tblCompras"
    Public Const TABLA_MENUES As String = "tblMenu"
    Public Const TABLA_MENUES_X_ROL As String = "tblMenuXrol"
    Public Const TABLA_LOG_ACTIVIDADES As String = "tblActionLog"
    Public Const TABLA_CUENTAS_CONTABLES_COMPRAS As String = "tblCuentasCompras"
    Public Const TABLA_CUENTAS_CONTABLES_GASTOS As String = "tblCuentasGastos"
    Public Const TABLA_METODOS_DE_PAGO As String = "tblMetodosPago"
    Public Const TABLA_PAGOS_COMPRAS_Y_GASTOS As String = "tblPagosComprasGastos"
    Public Const TABLA_PUESTOS_DE_VENTA As String = "tblPuestosDeVenta"
    Public Const TABLA_TIPOS_DE_COMPROBANTES As String = "tblTiposComprobantes"
    Public Const TABLA_CONDICIONES_DE_IVA As String = "tblCondicionesIVA"
    Public Const TABLA_CAEA As String = "tblCAEA"
    Public Const TABLA_FACTURAS As String = "tblFacturas"
    Public Const TABLA_FACTURA_ITEMS As String = "tblFacturaItems"

    Public Const TABLA_ARTICULOS As String = "tblArticulos"
    Public Const TABLA_TARJETAS As String = "tblTarjetas"

    Public Const TABLA_AUTHENTICATION_REQUEST As String = "tblAuthenticationRequests"
    Public Const TABLA_CERTIFICADOS_PARAMETROS As String = "tblCertificadosParametros"

    Public Const TABLA_PAGOS_FACTURAS As String = "tblPagosFacturas"

    Public Const TABLA_CONSUMIDOR_FINAL As String = "tblConsumidorFinal"

    Public Const TABLA_PLANILLA As String = "tblPlanilla"

#End Region

#Region "Stored Procedures"

    Public Const VALIDAR_LOGIN As String = "validalogin"
    Public Const VALIDAR_USUARIO_NUEVO As String = "validarUsuarioNuevo"
    Public Const INSERTAR_USUARIO As String = "insertarUsuario"
    Public Const ACTUALIZAR_PASSWORD As String = "actualizarPassword"
    Public Const LISTAR_USUARIOS As String = "listarUsuarios"
    Public Const ACTUALIZAR_USUARIO As String = "actualizarUsuario"
    Public Const ELIMINAR_USUARIO As String = "eliminarUsuario"
    Public Const LISTAR_USUARIOS_TODOS As String = "listarUsuariosTodos"
    Public Const VALIDAR_ROL_NUEVO As String = "validarRoleNuevo"
    Public Const INSERTAR_ROL As String = "insertarRole"
    Public Const TRAER_ROLES As String = "traerRoles"
    Public Const INSERTAR_CLIENTE As String = "insertarCliente"
    Public Const TRAER_RAZON_SOCIAL_XCLIENTES As String = "traerClientes"
    Public Const INSERTAR_AUTOMOTOR As String = "insertarAutomotor"
    Public Const TRAER_ID_CLIENTE_X_RAZON_SOCIAL As String = "traerIdClientexRazonSocial"
    Public Const LISTAR_CLIENTES As String = "listarClientes"
    Public Const LISTAR_CLIENTES_TODOS As String = "listarClientesTodos"
    Public Const TRAER_AUTOMOTORES_X_CLIENTE As String = "traerAutomoresxCliente"
    Public Const LISTAR_AUTOMOTORES As String = "listarAutomotores"
    Public Const TRAER_FACTURAS As String = "traerFacturas"
    
    Public Const VALIDAR_BANCO_NUEVO As String = "validarBancoNuevo"
    Public Const INSERTAR_BANCO As String = "insertarBanco"
    Public Const LISTAR_BANCOS As String = "listarBancos"
    Public Const LISTAR_BANCOS_TODOS As String = "listarBancosTodos"
    Public Const ACTUALIZAR_BANCO As String = "actualizarBanco"
    Public Const ELIMINAR_BANCO As String = "eliminarBanco"
    Public Const VALIDAR_CHEQUE_NUEVO As String = "validarChequeNuevo"
    Public Const INSERTAR_CHEQUE As String = "insertarCheque"
    Public Const ACTUALIZAR_CHEQUE As String = "actualizarCheque"
    Public Const TRAER_CHEQUES As String = "traerCheques"
    Public Const TRAER_ID_BANCO As String = "traerIDbanco"
    Public Const IS_MODULO_BLOQUEADO As String = "isModuloBloqueado"
    Public Const LIMPIAR_MODULO_BLOQUEADO As String = "eliminarBloqueo"
    Public Const TRAER_TODOS_LOS_CHEQUES_SIN_ASIGNAR As String = "traerChequesTodosSinAsignar"
    Public Const TRAER_CHEQUES_SIN_ASIGNAR As String = "traerChequesSinAsignar"
    Public Const ELIMINAR_CHEQUE As String = "eliminarCheque"
    Public Const LISTAR_CHEQUES As String = "listarCheques"
    Public Const LISTAR_CHEQUES_TODOS As String = "listarChequesTodos"
    Public Const LISTAR_CUENTAS_TODOS As String = "traerCuentasTodas"
    Public Const INSERTAR_PROVEEDOR As String = "insertarProveedor"
    Public Const ACTUALIZAR_PROVEEDOR As String = "actualizarProveedor"
    Public Const VALIDAR_PROVEEDOR_NUEVO As String = "validarProveedorNuevo"
    Public Const ELIMINAR_PROVEEDOR As String = "eliminarProveedor"
    Public Const TRAER_ID_PROVEEDOR As String = "traerIDProveedor"
    Public Const TRAER_ID_ROL As String = "traerIDrol"
    Public Const LISTAR_PROVEEDORES As String = "listarProveedores"
    Public Const LISTAR_PROVEEDORES_TODOS As String = "listarProveedoresTodos"
    Public Const VALIDAR_GASTO_NUEVO As String = "validarGastoNuevo"
    Public Const INSERTAR_GASTO As String = "insertarGasto"
    Public Const ACTUALIZAR_GASTO As String = "actualizarGasto"
    Public Const ELIMINAR_GASTO As String = "eliminarGasto"
    Public Const LISTAR_GASTOS_TODOS As String = "listarGastosTodos"
    Public Const LISTAR_GASTOS As String = "listarGastos"
    Public Const LISTAR_GASTOS_X_FECHA As String = "listarGastosPorFecha"
    Public Const LISTAR_MENUES As String = "listarMenues"
    Public Const VALIDAR_COMPRA_NUEVA As String = "validarCompraNueva"
    Public Const INSERTAR_COMPRA As String = "insertarCompra"
    Public Const ACTUALIZAR_COMPRA As String = "actualizarCompra"
    Public Const ELIMINAR_COMPRA As String = "eliminarCompra"
    Public Const LISTAR_COMPRAS_TODAS As String = "listarComprasTodos"
    Public Const LISTAR_COMPRAS_X_FECHA As String = "listarComprasPorFecha"
    Public Const LISTAR_COMPRAS As String = "listarCompras"
    Public Const INSERTAR_MENUES_ROL As String = "insertarMenuesRol"
    Public Const LIMPIAR_MENUES_DEL_ROL As String = "limpiarMenuesDelRol"
    Public Const LISTAR_MENUES_X_ROL As String = "listarMenuesPorRol"
    Public Const ELIMINAR_ROL As String = "eliminarRol"
    Public Const LISTAR_ROLES As String = "listarRoles"
    Public Const ACTUALIZAR_ROL As String = "actualizarRol"
    Public Const TRAER_ACCESOS_DEL_ROL As String = "traerAccesosDelRol"
    Public Const LISTAR_LOG_DE_ACTIVIDADES As String = "listarLogActividades"
    Public Const LISTAR_LOG_ERRORES As String = "listarLogErrores"
    Public Const TRAER_ID_CUENTA As String = "traerIDcuenta"
    Public Const ASIGNAR_CHEQUE As String = "asignarCheque"
    Public Const DESASIGNAR_CHEQUE As String = "desasignarCheque"
    Public Const TRAER_CUIT_CLIENTE_X_RAZON_SOCIAL As String = "traerCUITClientexRazonSocial"
    Public Const TRAER_DATOS_PERSONALES_CLIENTE As String = "traerDatosPersonalesCliente"
    Public Const LISTAR_CUENTAS_CONTABLES_COMPRAS As String = "listarCuentasCompras"
    Public Const LISTAR_CUENTAS_CONTABLES_GASTOS As String = "listarCuentasGastos"
    Public Const TRAER_ID_CUENTA_CONTABLE_GASTO As String = "traerIDcuentaGasto"
    Public Const TRAER_ID_CUENTA_CONTABLE_COMPRA As String = "traerIDcuentaCompra"
    Public Const LISTAR_METODOS_DE_PAGO As String = "listarMetodosDePago"
    Public Const TRAER_ID_COMPRA As String = "traerIDCompra"
    Public Const TRAER_ID_GASTO As String = "traerIDGasto"
    Public Const INSERTAR_PAGOS_COMPRA_O_GASTO As String = "insertarPago"
    Public Const ELIMINAR_PAGOS_DE_COMPRA As String = "eliminarPagosCompra"
    Public Const ELIMINAR_PAGOS_DE_GASTO As String = "eliminarPagosGasto"
    Public Const TRAER_PAGOS_DE_COMPRA As String = "traerPagosCompra"
    Public Const TRAER_PAGOS_DE_GASTO As String = "traerPagosGasto"
    Public Const INSERTAR_CUENTA_CONTABLE_GASTO As String = "insertarCuentaGasto"
    Public Const VALIDAR_CUENTA_CONTABLE_GASTO_NUEVA As String = "validarCuentaContableGastoNueva"
    Public Const ACTUALIZAR_CUENTA_CONTABLE_GASTO As String = "actualizaCuentaContableGasto"
    Public Const LISTAR_CUENTAS_CONTABLES_GASTO_FILTRO As String = "listarCuentasGastosFiltro"

    Public Const INSERTAR_CUENTA_CONTABLE_COMPRA As String = "insertarCuentaCompra"
    Public Const VALIDAR_CUENTA_CONTABLE_COMPRA_NUEVA As String = "validarCuentaContableCompraNueva"
    Public Const ACTUALIZAR_CUENTA_CONTABLE_COMPRA As String = "actualizaCuentaContableCompra"
    Public Const LISTAR_CUENTAS_CONTABLES_COMPRA_FILTRO As String = "listarCuentasComprasFiltro"


    Public Const INSERTAR_EMPRESA As String = "insertarEmpresa"
    Public Const VALIDAR_EMPRESA_NUEVA As String = "validarEmpresaNueva"
    Public Const ACTUALIZAR_EMPRESA As String = "actualizarEmpresa"
    Public Const LISTAR_CUENTAS As String = "listarCuentas"

    Public Const VALIDAR_CLIENTE_NUEVO As String = "validarClienteNuevo"
    Public Const ACTUALIZAR_CLIENTE As String = "actualizarCliente"
    Public Const ELIMINAR_CLIENTE As String = "eliminarCliente"

    Public Const LISTAR_PUESTOS_DE_VENTAS_TODOS As String = "listarPuestosDeVentaTodos"
    Public Const LISTAR_TIPOS_DE_COMPROBANTES_TODOS As String = "listarTiposDeComprobantesTodos"
    Public Const LISTAR_CONDICIONES_DE_IVA_TODOS As String = "listarCondicionesIVAtodos"
    Public Const LISTAR_CAEA_DISPONIBLE As String = "listarCAEAdisponible"
    Public Const TRAER_FACTURA_PROXIMA As String = "traerProximoNumeroFactura"
    Public Const INSERTAR_FACTURA As String = "insertarFactura"
    Public Const INSERTAR_FACTURA_ITEMS As String = "insertarFacturaItems"
    Public Const TRAER_ID_CAEA As String = "traerIDCAEA"
    Public Const TRAER_ID_PUESTO_DE_VENTA As String = "traerIDPuestoVenta"
    Public Const TRAER_ID_TIPO_DE_COMPROBANTE As String = "traerIDtipoComprobante"
    Public Const TRAER_ID_FACTURA As String = "traerIDfactura"

    Public Const LISTAR_NOTAS_DE_CREDITO_TODAS As String = "listarNotasDeCreditoTodos"
    Public Const LISTAR_NOTAS_DE_CREDITO As String = "listarNotasDeCredito"

    Public Const LISTAR_REMITOS_A_CANCELAR_FACTURAS As String = "listarRemitosAcancelarFacturas"
    Public Const CANCELAR_REMITOS_CONTRA_FACTURA As String = "cancelarRemitosContraFactura"
    Public Const TRAER_REMITO_PROXIMO As String = "traerProximoNumeroRemito"
    Public Const TRAER_RECIBO_PROXIMO As String = "traerProximoNumeroRecibo"

    Public Const LISTAR_COBRANZAS As String = "listarCobranzas"
    Public Const INSERTAR_METODOS_PAGO_FACTURA As String = "insertarMetodosPagoFactura"


#Region "Facturas"
    Public Const CANCELAR_FACTURA As String = "cancelarFactura"
    Public Const BUSCAR_FACTURAS As String = "buscarFacturas"
    Public Const TRAER_ESTADO_DE_CUENTA As String = "traerEstadoCuenta"
    Public Const TRAER_ESTADO_DE_CUENTA2 As String = "traerEstadoCuenta2"
    Public Const TRAER_DATOS_FACTURA As String = "traerDatosFactura"
    Public Const TRAER_DATOS_FACTURA_ITEMS As String = "traerDatosFacturaItems"
    Public Const ELIMINAR_FACTURA As String = "eliminarFactura"
    Public Const GENERAR_IVA_VENTAS As String = "generarIVAventas"
#End Region

#Region "Recibos"
    Public Const VALIDAR_RECIBO_NUEVO As String = "validarReciboNuevo"
    Public Const BUSCAR_RECIBOS As String = "buscarRecibos"
    Public Const TRAER_DATOS_RECIBO As String = "traerDatosRecibo"
    Public Const TRAER_DETALLE_RECIBO As String = "traerDetalleRecibo"
#End Region


#Region "Condiciones frente al IVA"
    Public Const CONDICION_FISCAL_EXENTO As String = "Exento"
    Public Const CONDICION_FISCAL_RNA As String = "RNA"
    Public Const CONDICION_FISCAL_MONOTRIBUTO As String = "Monotributo"
    Public Const CONDICION_FISCAL_IVA_RESPONSABLE_INSCRIPTO As String = "IVA Responsable Inscripto"
    Public Const CONDICION_FISCAL_RESPONSABLE_NO_INSCRIPTO As String = "Responsable No Inscripto"
    Public Const CONDICION_FISCAL_RESPONSABLE_MONOTRIBUTO As String = "Responsable Monotributo"
    Public Const CONDICION_FISCAL_CONSUMIDOR_FINAL As String = "Consumidor Final"
    Public Const CONDICION_FISCAL_RESPONSABLE_INSCRIPTO As String = "Responsable Inscripto"
    Public Const CONDICION_FISCAL_NC As String = "NC"
#End Region

#Region "Consumidor Final"
    Public Const LISTAR_CONSUMIDOR_FINAL As String = "listarConsumidorFinal"


#End Region

#Region "Articulos"
    Public Const INSERTAR_ARTICULO As String = "insertarArticulo"
    Public Const ACTUALIZAR_ARTICULO As String = "actualizarArticulo"
    Public Const ELIMINAR_ARTICULO As String = "eliminarArticulo"
    Public Const VALIDAR_ARTICULO_NUEVO As String = "validarArticuloNuevo"
    Public Const LISTAR_ARTICULOS As String = "listarArticulos"
    Public Const TRAER_ID_ARTICULO As String = "traerIDarticulo"
#End Region

#Region "Tarjetas"
    Public Const LISTAR_TARJETAS As String = "listartarjetas"
    Public Const TRAER_ID_TARJETA As String = "traerIDtarjeta"
#End Region

#Region "Notas de credito"
    Public Const TRAER_NOTA_DE_CREDITO_PROXIMA As String = "traerProximoNumeroNotaCredito"
    Public Const LISTAR_TIPOS_DE_COMPROBANTES_TODOS_NOTA_DE_CREDITO As String = "listarTiposDeComprobantesNotasDeCredito"
#End Region

#Region "CAE"
    Public Const INSERTAR_CAE As String = "insertarCAEA"
#End Region

#Region "Authentication Request"
    Public Const INSERTAR_AUTHENTICATION_REQUEST As String = "insertarAuthenticationRequest"
    Public Const TRAER_AUTHENTICATION_REQUEST As String = "traerAuthenticationRequest"
#End Region

#Region "Certificados Parametros"
    Public Const TRAER_CERTIFICADOS_PARAMETROS As String = "traerCertificadosParametros"
#End Region

#Region "Planilla"
    Public Const INSERTAR_PLANILLA As String = "insertarPlanilla"
    Public Const LISTAR_PLANILLAS As String = "listarPlanillas"
#End Region

#End Region

#Region "Acciones"

    Public Const LOGIN As String = "Login al sistema"
    Public Const LOGOUT As String = "Logout del sistema"
    Public Const MODULO_CHEQUE As String = "Modulo de cheques"
    Public Const MODULO_USUARIO As String = "Modulo de usuarios"
    Public Const MODULO_ROLES As String = "Modulo de roles"
    Public Const MODULO_BANCO As String = "Modulo de banco"
    Public Const MODULO_PROVEEDORES As String = "Modulo de Proveedores"
    Public Const MODULO_CUENTAS_CONTABLES As String = "Modulo cuentas contables"
    Public Const MODULO_EMPRESAS As String = "Modulo Empresas"
    Public Const MODULO_GASTOS As String = "Modulo de gastos"
    Public Const MODULO_COMPRAS As String = "Modulo de compras"
    Public Const MODULO_CLIENTES As String = "Modulo de clientes"
    Public Const MODULO_VENTAS As String = "Modulo de Ventas "
    Public Const MODULO_NOTAS_DE_CREDITO As String = "Modulo de notas de credito"

    Public Const MODULO_ARTICULOS As String = "Modulo de articulos"

    'Public Const ABRE_FORM_NUEVO_USUARIO As String = "Abriendo form nuevo usuario"
    'Public Const ABRE_FORM_NUEVO_ROL As String = "Abriendo form nuevo rol"
    'Public Const ABRE_FORM_NUEVO_BANCO As String = "Abriendo form nuevo banco"
    'Public Const ABRE_FORM_EDICION_BANCO As String = "Abriendo form edicion banco"
    'Public Const ABRE_FORM_ELIMINAR_BANCO As String = "Abriendo form eliminar banco"
    'Public Const ABRE_FORM_LISTAR_BANCO As String = "Abriendo form listar bancos"
    'Public Const ABRE_FORM_NUEVO_CHEQUE As String = "Abriendo form nuevo cheque"
    'Public Const ABRE_FORM_EDICION_CHEQUE As String = "Abriendo form edicion cheque"
    'Public Const ABRE_FORM_ELIMINAR_CHEQUE As String = "Abriendo form eliminar cheque"
    'Public Const ABRE_FORM_LISTAR_CHEQUES As String = "Abriendo form de informe de cheques"
#Region "Cheques"
    Public Const MODULO_CHEQUE_ALTA As String = "Alta cheque"
    Public Const MODULO_CHEQUE_EDITA As String = "Modificacion cheque"
    Public Const MODULO_CHEQUE_ELIMINA As String = "Baja cheque"
    Public Const MODULO_CHEQUE_LISTA As String = "Lista cheque"
    Public Const MODULO_CHEQUE_ASIGNA As String = "Asigna cheque"
    Public Const MODULO_CHEQUE_EXPORTA As String = "Exporta cheque"
#End Region

#Region "Usuarios"
    Public Const MODULO_USUARIO_ALTA As String = "Alta usuario"
    Public Const MODULO_USUARIO_EDITA As String = "Modificacion usuario"
    Public Const MODULO_USUARIO_ELIMINA As String = "Baja usuario"
    Public Const MODULO_USUARIO_LISTA As String = "Lista usuario"
    Public Const MODULO_USUARIO_EXPORTA As String = "Exporta usuario"
    Public Const MODULO_USUARIO_CAMBIO_PASS As String = "Cambio de password"
#End Region

#Region "Roles"
    Public Const MODULO_ROL_ALTA As String = "Alta rol"
    Public Const MODULO_ROL_EDITA As String = "Modificacion rol"
    Public Const MODULO_ROL_ELIMINA As String = "Baja rol"
    Public Const MODULO_ROL_LISTA As String = "Lista rol"
    Public Const MODULO_ROL_EXPORTA As String = "Exporta rol"
#End Region

#Region "Proveedores"
    Public Const MODULO_PROVEEDOR_ALTA As String = "Alta proveedor"
    Public Const MODULO_PROVEEDOR_EDITA As String = "Modificacion proveedor"
    Public Const MODULO_PROVEEDOR_ELIMINA As String = "Baja proveedor"
    Public Const MODULO_PROVEEDOR_LISTA As String = "Lista proveedor"
    Public Const MODULO_PROVEEDOR_EXPORTA As String = "Exporta proveedor"
#End Region

#Region "Gastos"
    Public Const MODULO_GASTO_ALTA As String = "Alta gasto"
    Public Const MODULO_GASTO_EDITA As String = "Modificacion gasto"
    Public Const MODULO_GASTO_ELIMINA As String = "Baja gasto"
    Public Const MODULO_GASTO_LISTA As String = "Lista gasto"
    Public Const MODULO_GASTO_EXPORTA As String = "Exporta gasto"
#End Region

#Region "Cuentas Contables"
    Public Const MODULO_CUENTA_CONTABLE_GASTO_ALTA As String = "Alta cuenta gasto"
    Public Const MODULO_CUENTA_CONTABLE_COMPRA_ALTA As String = "Alta cuenta compra"
    Public Const MODULO_CUENTA_CONTABLE_EDICION As String = "Edicion cuenta contable"
    Public Const MODULO_CUENTA_CONTABLE_LISTA As String = "Listar cuenta contable"
    Public Const MODULO_CUENTA_CONTABLE_EXPORTA As String = "Exporta Cuenta contable"
#End Region

#Region "Clientes"
    Public Const MODULO_CLIENTE_ALTA As String = "Alta cliente"
    Public Const MODULO_CLIENTE_EDITA As String = "Modificacion cliente"
    Public Const MODULO_CLIENTE_ELIMINA As String = "Baja cliente"
    Public Const MODULO_CLIENTE_LISTA As String = "Lista cliente"
    Public Const MODULO_CLIENTE_EXPORTA As String = "Exporta cliente"
#End Region

#Region "Empresas"
    Public Const MODULO_EMPRESA_ALTA As String = "Alta empresa"
    Public Const MODULO_EMPRESA_EDICION As String = "Edicion empresa"
    Public Const MODULO_EMPRESA_LISTA As String = "Listar empresa"
    Public Const MODULO_EMPRESA_EXPORTA As String = "Exporta empresa"
#End Region

#Region "Compras"
    Public Const MODULO_COMPRA_ALTA As String = "Alta compra"
    Public Const MODULO_COMPRA_EDITA As String = "Modificacion compra"
    Public Const MODULO_COMPRA_ELIMINA As String = "Baja compra"
    Public Const MODULO_COMPRA_LISTA As String = "Lista compra"
    Public Const MODULO_COMPRA_EXPORTA As String = "Exporta compra"
#End Region

#Region "Facturacion"
    Public Const MODULO_FACTURACION_ALTA As String = "Generación de factura"
    Public Const MODULO_FACTURACION_IMPRIME As String = "Impresión de factura"
#End Region

#Region "Remitos"
    Public Const MODULO_REMITOS_ALTA As String = "Generación de REMITO"
    Public Const MODULO_REMITOS_IMPRIME As String = "Impresión de remito"
#End Region

#Region "Recibos"
    Public Const MODULO_RECIBOS_ALTA As String = "Generación de RECIBO"
    Public Const MODULO_RECIBOS_IMPRIME As String = "Impresión de recibo"
#End Region


#Region "Cobranzas"
    Public Const MODULO_COBRANZAS_LISTA As String = "Lista cobranza"
    Public Const MODULO_COBRANZAS_EXPORTA As String = "Exporta cobranza"
#End Region
#Region "Notas de credito"
    Public Const MODULO_NOTA_DE_CREDITO_ALTA As String = "Alta nota de credito"
    Public Const MODULO_NOTA_DE_CREDITO_EDITA As String = "Modificacion nota de credito"
    Public Const MODULO_NOTA_DE_CREDITO_ELIMINA As String = "Baja nota de credito"
    Public Const MODULO_NOTA_DE_CREDITO_LISTA As String = "Lista nota de credito"
    Public Const MODULO_NOTA_DE_CREDITO_EXPORTA As String = "Exporta nota de credito"
    Public Const MODULO_NOTA_DE_CREDITO_IMPRIME As String = "Imprime nota de credito"
#End Region
#Region "Bancos"
    Public Const MODULO_BANCO_ALTA As String = "Alta banco"
    Public Const MODULO_BANCO_EDITA As String = "Modificacion banco"
    Public Const MODULO_BANCO_ELIMINA As String = "Baja banco"
    Public Const MODULO_BANCO_LISTA As String = "Lista banco"
    Public Const MODULO_BANCO_EXPORTA As String = "Exporta banco"
#End Region

#Region "Articulos"
    Public Const MODULO_ARTICULO_ALTA As String = "Alta articulo"
    Public Const MODULO_ARTICULO_EDITA As String = "Modificacion articulo"
    Public Const MODULO_ARTICULO_ELIMINA As String = "Baja articulo"
    Public Const MODULO_ARTICULO_LISTA As String = "Lista articulo"
    Public Const MODULO_ARTICULO_EXPORTA As String = "Exporta articulo"
#End Region
#End Region

#Region "Reportes"
    Public Const REPORTE_FACTURAS As String = "rptFactura"
    Public Const REPORTE_REMITO As String = "rptRemito"
    Public Const REPORTE_RECIBO As String = "rptRecibo"
    Public Const REPORTE_NOTAS_DE_CREDITO As String = "rptNotaCredito"
#End Region
End Module



