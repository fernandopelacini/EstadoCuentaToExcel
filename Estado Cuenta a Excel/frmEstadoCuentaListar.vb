Public Class frmEstadoCuentaListar
    Public blnIncluirConsumidorFinal As Boolean = False
    Private strcliente, strfechainicio, strfechafin, strCuenta As String


    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub frmEstadoCuentaListar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = _usrEstadoCuenta1.btnBuscar
  
        _usrEstadoCuenta1.dgrEstadoCuenta.Columns("colEsConsumidorFinal").Visible = False
  

    End Sub

    Private Sub btnGenerarEstadoCuenta_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarEstadoCuenta.Click
        If Validar() Then
            Dim oEstadoCuenta As Factura
            Dim dsEstadoCuenta As dsDatos

            oEstadoCuenta = New Factura
            dsEstadoCuenta = New dsDatos
            _usrEstadoCuenta1.pgbProgreso.Value = 0

            _usrEstadoCuenta1.dgrEstadoCuenta.Rows.Clear()
            _usrEstadoCuenta1.lblSaldo.Text = 0
            ObtenerFiltros()
            
            oEstadoCuenta.GenerarEstadoDeCuenta(strfechainicio, strfechafin, strcliente, strCuenta, dsEstadoCuenta, TABLA_FACTURAS, blnIncluirConsumidorFinal)

            oEstadoCuenta.Dispose()

            If dsEstadoCuenta.Tables(TABLA_FACTURAS).Rows.Count > 0 Then
                _usrEstadoCuenta1.pgbProgreso.Maximum = dsEstadoCuenta.Tables(TABLA_FACTURAS).Rows.Count
                CargarGrillaEstadoCuenta(dsEstadoCuenta)
            Else
                MsgBox(NO_HAY_DATOS, MsgBoxStyle.Exclamation, APPLICATION_NAME)
            End If

        End If
    End Sub

    Private Sub ObtenerFiltros()
        If _usrEstadoCuenta1.chkFiltroFecha.Checked Then
            strfechainicio = Format(_usrEstadoCuenta1.dtpFechaDesde.Value.Date, formatoEscritura)
            strfechafin = Format(_usrEstadoCuenta1.dtpFechaHasta.Value.Date, formatoEscritura)
        Else
            strfechainicio = FECHA_MINIMA_LISTADO
            strfechafin = FECHA_MAXIMA_LISTADO
        End If
        strcliente = _usrEstadoCuenta1.txtCliente.Text
        strCuenta = _usrEstadoCuenta1.cmbCuenta.SelectedItem.ToString()

    End Sub

    Private Function Validar() As Boolean
        If String.IsNullOrWhiteSpace(_usrEstadoCuenta1.txtCliente.Text) Then
            SetError(_usrEstadoCuenta1.txtCliente, CAMPO_OBLIGATORIO, Color.Yellow)
            Return False
        End If
        Return True
    End Function

    Private Sub CargarGrillaEstadoCuenta(ByVal dsEstado As DataSet)
        Dim posicion As Integer = 0
        For Each oRow As DataRow In dsEstado.Tables(TABLA_FACTURAS).Rows
            With _usrEstadoCuenta1
                posicion = .dgrEstadoCuenta.Rows.Add()
                .dgrEstadoCuenta.Rows(posicion).Cells("colCliente").Value = .txtCliente.Text
                .dgrEstadoCuenta.Rows(posicion).Cells("colFecha").Value = CDate(oRow(0).ToString())
                .dgrEstadoCuenta.Rows(posicion).Cells("colComprobante").Value = oRow(1).ToString()
                .dgrEstadoCuenta.Rows(posicion).Cells("colNroComprobante").Value = oRow(2).ToString()
                If oRow(3) < 0 Then 'Facturas
                    .dgrEstadoCuenta.Rows(posicion).Cells("colDebe").Value = (Format(Math.Abs(CDec(oRow(3).ToString())), "N"))
                    .dgrEstadoCuenta.Rows(posicion).Cells("colHaber").Value = Format(CDec(0), "N")
                ElseIf InStr(oRow(1).ToString(), "NOTA") > 0 Then 'Notas de credito al DEBE en negativo para que den los numeros
                    .dgrEstadoCuenta.Rows(posicion).Cells("colDebe").Value = (Format(CDec(-oRow(3).ToString()), "N"))
                    .dgrEstadoCuenta.Rows(posicion).Cells("colHaber").Value = Format(CDec(0), "N")
                Else
                    .dgrEstadoCuenta.Rows(posicion).Cells("colDebe").Value = Format(CDec(0), "N")
                    .dgrEstadoCuenta.Rows(posicion).Cells("colHaber").Value = Format(CDec(oRow(3).ToString()), "N")
                End If
                .lblSaldo.Text += CDec(oRow(3))
            End With
            _usrEstadoCuenta1.pgbProgreso.Value += 1
        Next
        _usrEstadoCuenta1.lblSaldo.Text = "$ " & Format(CDec(_usrEstadoCuenta1.lblSaldo.Text), "N")
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Try
            If _usrEstadoCuenta1.dgrEstadoCuenta.Rows.Count > 0 Then
                Dim oEstadoCuenta As Factura
                Dim dsEstadoCuenta As dsDatos

                oEstadoCuenta = New Factura
                dsEstadoCuenta = New dsDatos

                _usrEstadoCuenta1.pgbProgreso.Value = 0
                _usrEstadoCuenta1.pgbProgreso.Maximum = 100

                ObtenerFiltros()
                oEstadoCuenta.GenerarEstadoDeCuenta(strfechainicio, strfechafin, strcliente, strCuenta, dsEstadoCuenta, DATA_TABLE_ESTADO_CUENTA, blnIncluirConsumidorFinal)
                oEstadoCuenta.Dispose()

                dsEstadoCuenta.Tables(DATA_TABLE_ESTADO_CUENTA).Columns.Remove("isConsumidorFinal")



                MostrarReporte(dsEstadoCuenta)

            End If
        Catch ex As Exception
            ErrorLog.Create(UsuarioLogin, ex)
        End Try

    End Sub
    Private Sub MostrarReporte(ByVal dsEstado As dsDatos)
        'Dim oEstado As Factura
        'oEstado = New Factura

        Dim oExcel As Excel
        oExcel = New Excel

        oExcel.Exportar(dsEstado.Tables(DATA_TABLE_ESTADO_CUENTA), Format(Date.Now, formatoEscritura) + "Cuenta")

        'oEstado.MostrarReporte(dsEstado)
        'oEstado.Dispose()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim dsEstado As dsDatos
        dsEstado = e.Argument

      
        MostrarReporte(dsEstado)
    End Sub
End Class