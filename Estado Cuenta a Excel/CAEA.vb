
Public Class CAEA
#Region "Propiedades"
    Public Property IDCaea As Integer
    Public Property CAEA As String
    Public Property Cuit As String
    Public Property FechaProceso As DateTime
    Public Property FechaTopeInforme As DateTime
    Public Property FechaVigenteDesde As DateTime
    Public Property FechaVigenteHasta As DateTime
    Public Property UniqueID As String
    Public Property Activo As Boolean
#End Region

#Region "Metodos"
  

    ''' <summary>
    ''' Destruye el objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Dispose()
        MyBase.Finalize()
    End Sub


#End Region
End Class
