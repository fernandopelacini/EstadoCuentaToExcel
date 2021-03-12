<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _usrEstadoCuenta
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgrEstadoCuenta = New System.Windows.Forms.DataGridView()
        Me.colCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDebe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHaber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEsConsumidorFinal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblSaldoLeyenda = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.gpbFecha = New System.Windows.Forms.GroupBox()
        Me.chkFiltroFecha = New System.Windows.Forms.CheckBox()
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        CType(Me.dgrEstadoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgrEstadoCuenta
        '
        Me.dgrEstadoCuenta.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgrEstadoCuenta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgrEstadoCuenta.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrEstadoCuenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgrEstadoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrEstadoCuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCliente, Me.colFecha, Me.colComprobante, Me.colNroComprobante, Me.colDebe, Me.colHaber, Me.colEsConsumidorFinal})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgrEstadoCuenta.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgrEstadoCuenta.GridColor = System.Drawing.Color.DodgerBlue
        Me.dgrEstadoCuenta.Location = New System.Drawing.Point(16, 197)
        Me.dgrEstadoCuenta.Name = "dgrEstadoCuenta"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgrEstadoCuenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.dgrEstadoCuenta.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgrEstadoCuenta.Size = New System.Drawing.Size(865, 255)
        Me.dgrEstadoCuenta.TabIndex = 2
        '
        'colCliente
        '
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MaxInputLength = 100
        Me.colCliente.Name = "colCliente"
        Me.colCliente.ReadOnly = True
        Me.colCliente.Width = 200
        '
        'colFecha
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colFecha.DefaultCellStyle = DataGridViewCellStyle3
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        '
        'colComprobante
        '
        Me.colComprobante.HeaderText = "Comprobante"
        Me.colComprobante.MaxInputLength = 30
        Me.colComprobante.Name = "colComprobante"
        Me.colComprobante.ReadOnly = True
        Me.colComprobante.Width = 120
        '
        'colNroComprobante
        '
        Me.colNroComprobante.HeaderText = "N°"
        Me.colNroComprobante.Name = "colNroComprobante"
        Me.colNroComprobante.ReadOnly = True
        '
        'colDebe
        '
        DataGridViewCellStyle4.Format = "N"
        DataGridViewCellStyle4.NullValue = "0"
        Me.colDebe.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDebe.HeaderText = "Debe"
        Me.colDebe.MaxInputLength = 100
        Me.colDebe.Name = "colDebe"
        Me.colDebe.ReadOnly = True
        '
        'colHaber
        '
        DataGridViewCellStyle5.Format = "N"
        DataGridViewCellStyle5.NullValue = "0"
        Me.colHaber.DefaultCellStyle = DataGridViewCellStyle5
        Me.colHaber.HeaderText = "Haber"
        Me.colHaber.Name = "colHaber"
        Me.colHaber.ReadOnly = True
        '
        'colEsConsumidorFinal
        '
        Me.colEsConsumidorFinal.HeaderText = "Cons. Final"
        Me.colEsConsumidorFinal.Name = "colEsConsumidorFinal"
        Me.colEsConsumidorFinal.ReadOnly = True
        '
        'lblSaldoLeyenda
        '
        Me.lblSaldoLeyenda.AutoSize = True
        Me.lblSaldoLeyenda.Location = New System.Drawing.Point(668, 472)
        Me.lblSaldoLeyenda.Name = "lblSaldoLeyenda"
        Me.lblSaldoLeyenda.Size = New System.Drawing.Size(37, 13)
        Me.lblSaldoLeyenda.TabIndex = 3
        Me.lblSaldoLeyenda.Text = "Saldo:"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(711, 472)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(14, 13)
        Me.lblSaldo.TabIndex = 4
        Me.lblSaldo.Text = "0"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.CalendarForeColor = System.Drawing.Color.White
        Me.dtpFechaHasta.CalendarMonthBackground = System.Drawing.Color.LightSteelBlue
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.CornflowerBlue
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.White
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.DodgerBlue
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(100, 59)
        Me.dtpFechaHasta.MinDate = New Date(2011, 1, 25, 0, 0, 0, 0)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(107, 20)
        Me.dtpFechaHasta.TabIndex = 80
        Me.dtpFechaHasta.Value = New Date(2014, 12, 30, 0, 0, 0, 0)
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.Location = New System.Drawing.Point(19, 59)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaHasta.TabIndex = 79
        Me.lblFechaHasta.Text = "Hasta:"
        '
        'cmbCuenta
        '
        Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuenta.Enabled = False
        Me.cmbCuenta.ForeColor = System.Drawing.Color.Black
        Me.cmbCuenta.FormattingEnabled = True
        Me.cmbCuenta.Location = New System.Drawing.Point(396, 54)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(291, 21)
        Me.cmbCuenta.TabIndex = 75
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(312, 54)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(44, 13)
        Me.lblCuenta.TabIndex = 78
        Me.lblCuenta.Text = "Cuenta:"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.CalendarForeColor = System.Drawing.Color.White
        Me.dtpFechaDesde.CalendarMonthBackground = System.Drawing.Color.LightSteelBlue
        Me.dtpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.CornflowerBlue
        Me.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.White
        Me.dtpFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.DodgerBlue
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(100, 19)
        Me.dtpFechaDesde.MinDate = New Date(2011, 1, 25, 0, 0, 0, 0)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(107, 20)
        Me.dtpFechaDesde.TabIndex = 77
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.Location = New System.Drawing.Point(16, 25)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(41, 13)
        Me.lblFechaDesde.TabIndex = 76
        Me.lblFechaDesde.Text = "Desde:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(22, 161)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 81
        Me.lblCliente.Text = "Cliente:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Estado_Cuenta_a_Excel.My.Resources.Resources.Search
        Me.btnBuscar.Location = New System.Drawing.Point(502, 155)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(45, 23)
        Me.btnBuscar.TabIndex = 82
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.ForeColor = System.Drawing.Color.Black
        Me.txtCliente.Location = New System.Drawing.Point(106, 158)
        Me.txtCliente.MaxLength = 100
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(365, 20)
        Me.txtCliente.TabIndex = 83
        '
        'gpbFecha
        '
        Me.gpbFecha.Controls.Add(Me.lblFechaDesde)
        Me.gpbFecha.Controls.Add(Me.dtpFechaDesde)
        Me.gpbFecha.Controls.Add(Me.lblFechaHasta)
        Me.gpbFecha.Controls.Add(Me.dtpFechaHasta)
        Me.gpbFecha.ForeColor = System.Drawing.Color.White
        Me.gpbFecha.Location = New System.Drawing.Point(25, 35)
        Me.gpbFecha.Name = "gpbFecha"
        Me.gpbFecha.Size = New System.Drawing.Size(242, 100)
        Me.gpbFecha.TabIndex = 84
        Me.gpbFecha.TabStop = False
        Me.gpbFecha.Text = "Fecha"
        '
        'chkFiltroFecha
        '
        Me.chkFiltroFecha.AutoSize = True
        Me.chkFiltroFecha.Location = New System.Drawing.Point(25, 12)
        Me.chkFiltroFecha.Name = "chkFiltroFecha"
        Me.chkFiltroFecha.Size = New System.Drawing.Size(64, 17)
        Me.chkFiltroFecha.TabIndex = 85
        Me.chkFiltroFecha.Text = "Habilitar"
        Me.chkFiltroFecha.UseVisualStyleBackColor = True
        '
        'pgbProgreso
        '
        Me.pgbProgreso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.pgbProgreso.Location = New System.Drawing.Point(16, 472)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(595, 12)
        Me.pgbProgreso.TabIndex = 86
        '
        '_usrEstadoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Controls.Add(Me.pgbProgreso)
        Me.Controls.Add(Me.chkFiltroFecha)
        Me.Controls.Add(Me.gpbFecha)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.cmbCuenta)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.lblSaldoLeyenda)
        Me.Controls.Add(Me.dgrEstadoCuenta)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "_usrEstadoCuenta"
        Me.Size = New System.Drawing.Size(895, 505)
        CType(Me.dgrEstadoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFecha.ResumeLayout(False)
        Me.gpbFecha.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgrEstadoCuenta As System.Windows.Forms.DataGridView
    Friend WithEvents lblSaldoLeyenda As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents gpbFecha As System.Windows.Forms.GroupBox
    Friend WithEvents chkFiltroFecha As System.Windows.Forms.CheckBox
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents colCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDebe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHaber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEsConsumidorFinal As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
