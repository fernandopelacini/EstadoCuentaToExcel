<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarCliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lstClientes = New System.Windows.Forms.ListBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grpProveedor = New System.Windows.Forms.GroupBox()
        Me.cmbBusqueda = New System.Windows.Forms.ComboBox()
        Me.lblCriterio = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.grpProveedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstClientes
        '
        Me.lstClientes.ForeColor = System.Drawing.Color.Black
        Me.lstClientes.FormattingEnabled = True
        Me.lstClientes.Location = New System.Drawing.Point(3, 72)
        Me.lstClientes.Name = "lstClientes"
        Me.lstClientes.Size = New System.Drawing.Size(468, 160)
        Me.lstClientes.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.Black
        Me.btnCerrar.Location = New System.Drawing.Point(390, 239)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grpProveedor
        '
        Me.grpProveedor.Controls.Add(Me.cmbBusqueda)
        Me.grpProveedor.Controls.Add(Me.lblCriterio)
        Me.grpProveedor.Controls.Add(Me.btnBuscar)
        Me.grpProveedor.Controls.Add(Me.txtSearch)
        Me.grpProveedor.ForeColor = System.Drawing.Color.White
        Me.grpProveedor.Location = New System.Drawing.Point(3, 6)
        Me.grpProveedor.Name = "grpProveedor"
        Me.grpProveedor.Size = New System.Drawing.Size(478, 60)
        Me.grpProveedor.TabIndex = 6
        Me.grpProveedor.TabStop = False
        Me.grpProveedor.Text = "Busqueda"
        '
        'cmbBusqueda
        '
        Me.cmbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBusqueda.ForeColor = System.Drawing.Color.Black
        Me.cmbBusqueda.FormattingEnabled = True
        Me.cmbBusqueda.Location = New System.Drawing.Point(105, 21)
        Me.cmbBusqueda.Name = "cmbBusqueda"
        Me.cmbBusqueda.Size = New System.Drawing.Size(117, 21)
        Me.cmbBusqueda.TabIndex = 14
        '
        'lblCriterio
        '
        Me.lblCriterio.AutoSize = True
        Me.lblCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriterio.ForeColor = System.Drawing.Color.White
        Me.lblCriterio.Location = New System.Drawing.Point(8, 26)
        Me.lblCriterio.Name = "lblCriterio"
        Me.lblCriterio.Size = New System.Drawing.Size(92, 13)
        Me.lblCriterio.TabIndex = 13
        Me.lblCriterio.Text = "Criterio busqueda:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Estado_Cuenta_a_Excel.My.Resources.Resources.Search
        Me.btnBuscar.Location = New System.Drawing.Point(419, 21)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(49, 23)
        Me.btnBuscar.TabIndex = 12
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.Location = New System.Drawing.Point(239, 21)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(156, 20)
        Me.txtSearch.TabIndex = 9
        '
        'frmBuscarCliente
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(493, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpProveedor)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lstClientes)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmBuscarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - busqueda"
        Me.grpProveedor.ResumeLayout(False)
        Me.grpProveedor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstClientes As System.Windows.Forms.ListBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grpProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBusqueda As System.Windows.Forms.ComboBox
    Friend WithEvents lblCriterio As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
End Class
