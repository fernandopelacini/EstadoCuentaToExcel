Public Class _usrEstadoCuenta

    Private Sub _usrEstadoCuenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        CargaComboCuentas()
        Inicializar()
    End Sub
    Public Sub Inicializar()
        dgrEstadoCuenta.Rows.Clear()
        lblSaldo.Text = 0
        cmbCuenta.SelectedIndex = 0
        chkFiltroFecha.Checked = False
        gpbFecha.Enabled = False
        pgbProgreso.Minimum = 0
        pgbProgreso.Maximum = 100
        pgbProgreso.Value = 0
        dtpFechaDesde.Value = GetServerDate()
        dtpFechaHasta.Value = dtpFechaDesde.Value
        dtpFechaDesde.MaxDate = dtpFechaDesde.Value
        dtpFechaHasta.MaxDate = dtpFechaDesde.Value
    End Sub
    Private Sub CargaComboCuentas()
        Dim oCuenta As Cuenta
        Dim dsCuentas As DataSet

        Try

            oCuenta = New Cuenta
            dsCuentas = New DataSet
            oCuenta.ListarCuentas(dsCuentas)
            cmbCuenta.Items.Clear()
            If dsCuentas.Tables(TABLA_CUENTAS).Rows.Count > 0 Then
                For i = 0 To dsCuentas.Tables(TABLA_CUENTAS).Rows.Count
                    If i = 0 Or i = 5 Then
                        Dim oRow As DataRow
                        oRow = dsCuentas.Tables(TABLA_CUENTAS).Rows(i)
                        cmbCuenta.Items.Add(oRow.Item(1).ToString())
                    End If
                Next
                cmbCuenta.SelectedIndex = 0
            End If
            dsCuentas.Dispose()
        Catch ex As Exception
            'Do nothing
        End Try

    End Sub

    Private Sub dtpFechaDesde_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        dtpFechaHasta.MinDate = dtpFechaDesde.Value
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        My.Forms.frmBuscarCliente.strFormSender = Me.Parent.Name
        My.Forms.frmBuscarCliente.ShowDialog()
    End Sub

    Private Sub chkFiltroFecha_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFiltroFecha.CheckedChanged
        If chkFiltroFecha.Checked Then
            gpbFecha.Enabled = True
        Else
            gpbFecha.Enabled = False
            dtpFechaDesde.Value = Today
        End If
    End Sub
End Class
