Public Class frmBuscarCliente

    Private dsCliente As dsDatos
    Public strFormSender As String = String.Empty


#Region "Validaciones"

   
    Private Sub frmBuscarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
        Me.Inicializar()
    End Sub
    Private Sub LlenarCombo()
        cmbBusqueda.Items.Insert(0, "Apellido / Razon Social")
        cmbBusqueda.Items.Insert(1, "C.U.I.T")
        cmbBusqueda.SelectedIndex = 0
    End Sub
    Private Sub Inicializar()
        Try
            lstClientes.DataSource = Nothing
            cmbBusqueda.SelectedIndex = 0
            txtSearch.Clear()
            If dsCliente IsNot Nothing Then dsCliente.Tables(TABLA_CLIENTES).Clear()
         
            '***************
            dsCliente = Nothing

            Dim oCliente As Cliente
            oCliente = New Cliente
            dsCliente = New dsDatos()


            oCliente.ListarClientes(cmbBusqueda.SelectedIndex, txtSearch.Text, dsCliente)
            oCliente.Dispose()

            txtSearch.AutoCompleteCustomSource.Clear()
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteCustomSource.AddRange((From row In dsCliente.Tables(TABLA_CLIENTES).Rows.Cast(Of DataRow)() _
                                                Select CStr(row(1))).ToArray())

            txtSearch.Focus()


                '***************
        Catch ex As Exception

        End Try

    End Sub
    'Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
    '    ' Me.Close()
    'End Sub

#End Region
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        dsCliente = Nothing

        Dim oCliente As Cliente
        oCliente = New Cliente
        dsCliente = New dsDatos()


        oCliente.ListarClientes(cmbBusqueda.SelectedIndex, txtSearch.Text, dsCliente)
        oCliente.Dispose()
        If dsCliente.Tables(TABLA_CLIENTES).Rows.Count > 0 Then
            LinkearCampos()
            Me.AcceptButton = btnCerrar
        End If
    End Sub

    Private Sub LinkearCampos()
        lstClientes.DataSource = dsCliente.Tables(TABLA_CLIENTES)
        lstClientes.DisplayMember = dsCliente.Tables(TABLA_CLIENTES).Columns(1).ToString() 'Nombre del cliente
        lstClientes.ValueMember = dsCliente.Tables(TABLA_CLIENTES).Columns(0).ToString() 'id del cliente
    End Sub
    

    Private Sub lstClientes_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lstClientes.DoubleClick, btnCerrar.Click
        If lstClientes.SelectedIndex = -1 Then
            MsgBox(SELECCIONE_VALOR_LISTA, MsgBoxStyle.Exclamation, APPLICATION_NAME)
        Else
            Dim strClienteSeleccionado As String = lstClientes.Text
            Dim oCliente As Cliente
            Dim strCuit As String = String.Empty
            oCliente = New Cliente

            strCuit = oCliente.TraerCUITcliente(strClienteSeleccionado)

            Select Case strFormSender
                Case frmEstadoCuentaListar.Name
                    frmEstadoCuentaListar._usrEstadoCuenta1.txtCliente.Text = strClienteSeleccionado
            End Select

            oCliente.Dispose()
            Me.Dispose()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class