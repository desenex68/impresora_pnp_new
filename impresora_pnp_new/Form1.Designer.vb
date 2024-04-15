<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Lab_Cedula = New System.Windows.Forms.Label()
        Me.Txt_Cedula = New System.Windows.Forms.TextBox()
        Me.Txt_Nombres = New System.Windows.Forms.TextBox()
        Me.Lab_Nombres = New System.Windows.Forms.Label()
        Me.Txt_Fin_Linea = New System.Windows.Forms.TextBox()
        Me.Lab_Fin_Linea = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Factura = New System.Windows.Forms.TextBox()
        Me.Txt_Fecha_Factura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lab_Cedula
        '
        Me.Lab_Cedula.Location = New System.Drawing.Point(19, 38)
        Me.Lab_Cedula.Name = "Lab_Cedula"
        Me.Lab_Cedula.Size = New System.Drawing.Size(73, 20)
        Me.Lab_Cedula.TabIndex = 2
        Me.Lab_Cedula.Text = "Cedula/Rif:"
        Me.Lab_Cedula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Cedula
        '
        Me.Txt_Cedula.Location = New System.Drawing.Point(107, 38)
        Me.Txt_Cedula.Name = "Txt_Cedula"
        Me.Txt_Cedula.ReadOnly = True
        Me.Txt_Cedula.Size = New System.Drawing.Size(459, 20)
        Me.Txt_Cedula.TabIndex = 3
        Me.Txt_Cedula.Text = "J-00032569-8"
        '
        'Txt_Nombres
        '
        Me.Txt_Nombres.Location = New System.Drawing.Point(107, 12)
        Me.Txt_Nombres.Name = "Txt_Nombres"
        Me.Txt_Nombres.ReadOnly = True
        Me.Txt_Nombres.Size = New System.Drawing.Size(459, 20)
        Me.Txt_Nombres.TabIndex = 1
        Me.Txt_Nombres.Text = "Inversiones Omega"
        '
        'Lab_Nombres
        '
        Me.Lab_Nombres.Location = New System.Drawing.Point(19, 12)
        Me.Lab_Nombres.Name = "Lab_Nombres"
        Me.Lab_Nombres.Size = New System.Drawing.Size(73, 20)
        Me.Lab_Nombres.TabIndex = 0
        Me.Lab_Nombres.Text = "Razon Social:"
        Me.Lab_Nombres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Fin_Linea
        '
        Me.Txt_Fin_Linea.Location = New System.Drawing.Point(107, 64)
        Me.Txt_Fin_Linea.Name = "Txt_Fin_Linea"
        Me.Txt_Fin_Linea.ReadOnly = True
        Me.Txt_Fin_Linea.Size = New System.Drawing.Size(459, 20)
        Me.Txt_Fin_Linea.TabIndex = 5
        Me.Txt_Fin_Linea.Text = "Formato Libre"
        '
        'Lab_Fin_Linea
        '
        Me.Lab_Fin_Linea.Location = New System.Drawing.Point(19, 64)
        Me.Lab_Fin_Linea.Name = "Lab_Fin_Linea"
        Me.Lab_Fin_Linea.Size = New System.Drawing.Size(73, 20)
        Me.Lab_Fin_Linea.TabIndex = 4
        Me.Lab_Fin_Linea.Text = "Fin de Linea:"
        Me.Lab_Fin_Linea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Location = New System.Drawing.Point(22, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(544, 114)
        Me.DataGridView1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 302)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 46)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Imprimir Factura"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(172, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 46)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Devolver Factura"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(300, 302)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 46)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Reporte X"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(428, 302)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(122, 46)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "Reporte Z"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(22, 469)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(544, 23)
        Me.ProgressBar1.TabIndex = 22
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(44, 354)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(122, 46)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Obtener Serial de Impresora PNP"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(173, 354)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(122, 46)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Abrir Gaveta"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(300, 354)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(122, 46)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "Reiniciar Impresora PNP"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(428, 354)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(122, 46)
        Me.Button8.TabIndex = 20
        Me.Button8.Text = "Obtener Puerto Com Abierto"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "No. Factura:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Factura
        '
        Me.Txt_Factura.Location = New System.Drawing.Point(114, 219)
        Me.Txt_Factura.Name = "Txt_Factura"
        Me.Txt_Factura.Size = New System.Drawing.Size(96, 20)
        Me.Txt_Factura.TabIndex = 8
        '
        'Txt_Fecha_Factura
        '
        Me.Txt_Fecha_Factura.Location = New System.Drawing.Point(114, 245)
        Me.Txt_Fecha_Factura.Name = "Txt_Fecha_Factura"
        Me.Txt_Fecha_Factura.Size = New System.Drawing.Size(96, 20)
        Me.Txt_Fecha_Factura.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fecha Factura:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Hora Factura:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(114, 271)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(53, 20)
        Me.DateTimePicker1.TabIndex = 12
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(44, 406)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(122, 46)
        Me.Button9.TabIndex = 21
        Me.Button9.Text = "Reimpresión de Z"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 503)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Fecha_Factura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Factura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Txt_Fin_Linea)
        Me.Controls.Add(Me.Lab_Fin_Linea)
        Me.Controls.Add(Me.Txt_Nombres)
        Me.Controls.Add(Me.Lab_Nombres)
        Me.Controls.Add(Me.Txt_Cedula)
        Me.Controls.Add(Me.Lab_Cedula)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Impresora PNP"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lab_Cedula As Label
    Friend WithEvents Txt_Cedula As TextBox
    Friend WithEvents Txt_Nombres As TextBox
    Friend WithEvents Lab_Nombres As Label
    Friend WithEvents Txt_Fin_Linea As TextBox
    Friend WithEvents Lab_Fin_Linea As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Factura As TextBox
    Friend WithEvents Txt_Fecha_Factura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button9 As Button
End Class
