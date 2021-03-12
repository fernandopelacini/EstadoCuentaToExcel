Public Class CondicionIVA
#Region "Propiedades"
    Public Property IDIva As Integer
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
    ''' Lista las condiciones de IVA
    ''' </summary>
    ''' <param name="oDatos">Dataset con los datos cargados</param>
    ''' <remarks></remarks>
    Public Sub ListarCondicionesDeIVA(ByRef oDatos As DataSet)

        Try
            conexion.Command.Parameters.Clear()

            oDatos = conexion.ExecuteDataset(LISTAR_CONDICIONES_DE_IVA_TODOS, _
                                            TABLA_CONDICIONES_DE_IVA, _
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
