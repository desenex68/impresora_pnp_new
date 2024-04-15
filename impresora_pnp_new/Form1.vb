Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Descripcion"
        DataGridView1.Columns(1).Name = "Cantidad"
        DataGridView1.Columns(2).Name = "Precio"
        DataGridView1.Columns(3).Name = "Impuesto"
        DataGridView1.Columns(4).Name = "Total"


        Dim row As String() = New String() {"Cable USB", "1", "1,00", "16,00", "1,00"}
        DataGridView1.Rows.Add(row)
        row = New String() {"Mouse USB", "2", "1,00", "16,00", "2,00"}
        DataGridView1.Rows.Add(row)
        row = New String() {"Teclado USB", "3", "1,00", "16,00", "3,00"}
        DataGridView1.Rows.Add(row)
        row = New String() {"Audifonos USB", "4", "1,00", "16,00", "4,00"}
        DataGridView1.Rows.Add(row)

        DataGridView1.AllowUserToAddRows = False

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "hh:mm"
        DateTimePicker1.ShowUpDown = True

        DateTimePicker1.Value = Now()
        Txt_Fecha_Factura.Text = DateTimePicker1.Value.ToString("dd/MM/yyyy")
    End Sub

    'Imprimir Factura
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Cambios para Git
        ProgressBar1.Style = ProgressBarStyle.Marquee

        ProgressBar1.MarqueeAnimationSpeed = 10

        DateTimePicker1.Value = Now()
        Txt_Fecha_Factura.Text = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        Dim factura_generada As String = String.Empty
        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Imprimir_Factura_Fiscal_Pnp(puerto_com, Txt_Nombres.Text, Txt_Cedula.Text, DataGridView1, "Formato Libre", factura_generada)
            Txt_Factura.Text = factura_generada
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    'Devolver Factura
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim respuesta As String = String.Empty
        Dim numero_factura_comp As String = Txt_Factura.Text
        Dim serial_maquina As String = String.Empty

        Dim fecha_factura As String = String.Empty
        Dim hora_factura As String = String.Empty

        fecha_factura = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        fecha_factura = fecha_factura.Replace("/", "")

        hora_factura = DateTimePicker1.Value.ToString("hh:mm")
        hora_factura = hora_factura.Replace(":", "")

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            'Obtiene el Serial de la Impresora PnP
            respuesta = Serial_Impresora_Pnp(puerto_com, serial_maquina)
            respuesta = Devolucion_Factura_Fiscal_Pnp(puerto_com, Txt_Nombres.Text, Txt_Cedula.Text, numero_factura_comp, serial_maquina, fecha_factura, hora_factura, DataGridView1)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    'Reporte X
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Imprimir_Reporte_X_Pnp(puerto_com)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    'Reporte Z
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Imprimir_Reporte_Z_Pnp(puerto_com)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    'Obtener Serial de Impresora PNP
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim serial_impresora As String = String.Empty
        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Serial_Impresora_Pnp(puerto_com, serial_impresora)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show("Serial: " & serial_impresora & "    Mensaje: " & respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    'Abrir Gaveta
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Abrir_Gabeta_Pnp(puerto_com)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    'Reiniciar Impresora PNP
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim respuesta As String = String.Empty

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Reiniciar_Impresora_Pnp(puerto_com)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    'Obtener Puerto Com Abierto
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 10

        Dim puerto_com As String = String.Empty
        Dim respuesta As String = String.Empty

        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show("Puerto Com: " & puerto_com & "    Mensaje: " & respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim respuesta As String = String.Empty
        Dim fecha_desde As String = String.Empty
        Dim fecha_hasta As String = String.Empty
        Dim modo_mem As String = String.Empty

        fecha_desde = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        fecha_desde = fecha_desde.Replace("/", "")

        fecha_hasta = DateTimePicker1.Value.ToString("dd/MM/yyyy")
        fecha_hasta = fecha_hasta.Replace("/", "")

        modo_mem = "detallado"

        Dim puerto_com As String = String.Empty
        respuesta = Obtener_Puerto_COM_Pnp(puerto_com)
        If respuesta = "Puerto COM Abierto" Then
            respuesta = Reimprimir_Reporte_Z_Pnp(puerto_com, fecha_desde, fecha_hasta, modo_mem)
        End If

        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.MarqueeAnimationSpeed = 0
        ProgressBar1.Increment(100)

        MessageBox.Show(respuesta, "Mensaje de Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub Txt_Fecha_Factura_Leave(sender As Object, e As EventArgs) Handles Txt_Fecha_Factura.Leave
        If IsDate(Txt_Fecha_Factura.Text) = True Then
            Txt_Fecha_Factura.Text = Format(CDate(Txt_Fecha_Factura.Text), "dd/MM/yyyy")
        Else
            Txt_Fecha_Factura.Text = String.Empty
        End If
    End Sub
End Class
