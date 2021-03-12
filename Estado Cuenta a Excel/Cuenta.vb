Public Class Cuenta
#Region "Propiedades"
    Public Property IDcuenta As Integer
    Public Property Cuenta As String
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

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Trae las cuentas (compañias) en la base de datos
    ''' </summary>
    ''' <param name="dsCuentas">Dataset donde se van a cargar las cuentas</param>
    ''' <remarks></remarks>
    Public Sub ListarCuentas(ByRef dsCuentas As DataSet, Optional ByVal strFiltro As String = "")
        Try
            dsCuentas = New DataSet
            conexion.Command.Parameters.Clear()
            If strFiltro = String.Empty Then
                dsCuentas = conexion.ExecuteDataset(LISTAR_CUENTAS_TODOS, TABLA_CUENTAS, True)
            Else
                dsCuentas = conexion.ExecuteDataset(LISTAR_CUENTAS, _
                                                    TABLA_CUENTAS, _
                                                    "@nombre", _
                                                    strFiltro, _
                                                    True)
            End If
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
        End Try
    End Sub

 
    ''' <summary>
    ''' Trae el ID de una cuenta (compañia)
    ''' </summary>
    ''' <param name="strNombreCuenta">Nombre de la cuenta del que se quiere buscar el ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TraerIDcuenta(ByVal strNombreCuenta As String) As Integer
        Dim intID As Integer = 0
        Try
            conexion.Command.Parameters.Clear()
            intID = conexion.ExecuteSPScalar(TRAER_ID_CUENTA, _
                                             "@nombrecuenta", _
                                             strNombreCuenta)

        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
            MsgBox(MENSAJE_ERROR, MsgBoxStyle.Critical, APPLICATION_NAME)
            Return intID
        End Try
        Return intID
    End Function

  
  

#End Region
End Class
