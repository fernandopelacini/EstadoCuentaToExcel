<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCuentaListar
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGenerarEstadoCuenta = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me._usrEstadoCuenta1 = New Estado_Cuenta_a_Excel._usrEstadoCuenta()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.Black
        Me.btnCerrar.Location = New System.Drawing.Point(731, 154)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(68, 23)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGenerarEstadoCuenta
        '
        Me.btnGenerarEstadoCuenta.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGenerarEstadoCuenta.ForeColor = System.Drawing.Color.Black
        Me.btnGenerarEstadoCuenta.Location = New System.Drawing.Point(547, 154)
        Me.btnGenerarEstadoCuenta.Name = "btnGenerarEstadoCuenta"
        Me.btnGenerarEstadoCuenta.Size = New System.Drawing.Size(68, 23)
        Me.btnGenerarEstadoCuenta.TabIndex = 2
        Me.btnGenerarEstadoCuenta.Text = "Generar"
        Me.ToolTip1.SetToolTip(Me.btnGenerarEstadoCuenta, "Genera el estado de cuenta")
        Me.btnGenerarEstadoCuenta.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 400
        Me.ToolTip1.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolTip1.ForeColor = System.Drawing.Color.White
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnImprimir.ForeColor = System.Drawing.Color.Black
        Me.btnImprimir.Image = Global.Estado_Cuenta_a_Excel.My.Resources.Resources.Excel_icon
        Me.btnImprimir.Location = New System.Drawing.Point(639, 154)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(68, 23)
        Me.btnImprimir.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprime el estado de cuenta")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        '_usrEstadoCuenta1
        '
        Me._usrEstadoCuenta1.BackColor = System.Drawing.Color.LightSteelBlue
        Me._usrEstadoCuenta1.ForeColor = System.Drawing.Color.White
        Me._usrEstadoCuenta1.Location = New System.Drawing.Point(-8, -2)
        Me._usrEstadoCuenta1.Name = "_usrEstadoCuenta1"
        Me._usrEstadoCuenta1.Size = New System.Drawing.Size(897, 493)
        Me._usrEstadoCuenta1.TabIndex = 1
        '
        'frmEstadoCuentaListar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(897, 511)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnGenerarEstadoCuenta)
        Me.Controls.Add(Me._usrEstadoCuenta1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEstadoCuentaListar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de cuenta"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents _usrEstadoCuenta1 As _usrEstadoCuenta
    Friend WithEvents btnGenerarEstadoCuenta As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
