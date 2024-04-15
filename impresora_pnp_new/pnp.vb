Imports System.Runtime
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Management

Module pnp
    'Cambiar dll pnpdlltest.dll por pnpdll.dll si se va a usar la impresora PNP conectada por usb
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFultimo() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFcierrapuerto() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFabrepuerto(ByVal puerto As String) As IntPtr
    End Function
    'Cambios para Git
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFabrefiscal(ByVal razon As String, ByVal rif As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFrenglon(ByVal Descripcion As String, ByVal cantidad As String, ByVal monto As String, ByVal iva As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFComando(ByVal Comando As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFtotal() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFTfiscal(ByVal Texto As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFDevolucion(ByVal razon As String, ByVal rif As String, ByVal comp As String, ByVal maqui As String, ByVal fecha As String, ByVal hora As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFultimo(ByVal Texto As String) As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFrepx() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFrepz() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFSerial() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFGaveta() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFreset() As IntPtr
    End Function
    <DllImport("pnpdlltest.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi)>
    Private Function PFRepMemNF() As IntPtr
    End Function

    Public Function Imprimir_Factura_Fiscal_Pnp(ByVal numero_puerto As String, ByVal razon_social As String, ByVal cedula_rif As String, ByRef Grid_Principal As DataGridView, ByVal fin_linea As String, ByRef factura_generada As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            Return "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        'Abre la Factura Fiscal
        ptr = PFabrefiscal(razon_social, cedula_rif)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFultimo()
            Return "ERROR Iniciando la Factura"
        End If
        If result.Equals("TO") Then
            respuesta = "Iniciando la Factura Se excedió el tiempo de respuesta esperado del equipo."
        End If

        'Carga detalle de la Factura Fiscal
        For Each row As DataGridViewRow In Grid_Principal.Rows

            Dim descripcion_grid = CStr(row.Cells("Descripcion").Value)
            Dim descripcion_formato = Mid(descripcion_grid, 1, 25)

            Dim cantidad_grid As String = CStr(row.Cells("Cantidad").Value)
            Dim cantidad_formato As String = cantidad_grid.Replace(",", "")
            cantidad_formato = cantidad_formato.Replace(".", "")

            Dim precio_grid As String = CStr(row.Cells("Precio").Value)
            Dim precio_formato As String = precio_grid.Replace(",", ".")

            Dim impuesto_grid As String = CStr(row.Cells("impuesto").Value)
            Dim impuesto_formato As String = impuesto_grid.Replace(",", "")
            impuesto_formato = impuesto_formato.Replace(".", "")
            impuesto_formato = CInt(impuesto_formato).ToString("0000")

            ptr = PFrenglon(descripcion_formato, cantidad_formato, precio_formato, impuesto_formato)
            result = Marshal.PtrToStringAnsi(ptr)
            If result.Equals("ER") Then
                ptr = PFultimo()
                Return "ERROR En Renglon de Item"
            End If
            If result.Equals("TO") Then
                respuesta = "En Renglon de Item se excedió el tiempo de respuesta esperado del equipo."
            End If

        Next

        'Carga Texto en Factura Fiscal
        ptr = PFTfiscal(fin_linea)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFultimo()
            Return "ERROR en Texto Fiscal"
        End If
        If result.Equals("TO") Then
            respuesta = "En Texto Fiscal se excedió el tiempo de respuesta esperado del equipo."
        End If

        'Totaliza Factura Fiscal
        ptr = PFtotal()

        'Obtener Ultima Fatura
        ptr = PFultimo()
        result = Marshal.PtrToStringAnsi(ptr)
        Dim st_str As String = CStr(result)
        Dim resultado_array() As String = st_str.Split(",")
        For index As Integer = 0 To resultado_array.Length
            If index = 3 Then
                factura_generada = resultado_array(index)
                Exit For
            End If
        Next

        If respuesta = String.Empty Then
            respuesta = "Factura Generada " '& factura_generada
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Devolucion_Factura_Fiscal_Pnp(ByVal numero_puerto As String, ByVal razon_social As String, ByVal cedula_rif As String, ByVal numero_factura_comp As String, ByVal serial_maquina As String, ByVal fecha As String, ByVal hora As String, ByRef Grid_Principal As DataGridView) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            Return "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        'Devolución de la Factura Fiscal
        ptr = PFDevolucion(razon_social, cedula_rif, numero_factura_comp, serial_maquina, fecha, hora)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFultimo()
            Return "ERROR En Devolución de Factura"
        End If
        If result.Equals("TO") Then
            respuesta = "Iniciando la Devolución de Factura Se excedió el tiempo de respuesta esperado del equipo."
        End If

        'Carga detalle de la Factura Fiscal
        For Each row As DataGridViewRow In Grid_Principal.Rows

            Dim descripcion_grid = CStr(row.Cells("Descripcion").Value)
            Dim descripcion_formato = Mid(descripcion_grid, 1, 25)

            Dim cantidad_grid As String = CStr(row.Cells("Cantidad").Value)
            Dim cantidad_formato As String = cantidad_grid.Replace(",", "")
            cantidad_formato = cantidad_formato.Replace(".", "")

            Dim precio_grid As String = CStr(row.Cells("Precio").Value)
            Dim precio_formato As String = precio_grid.Replace(",", ".")

            Dim impuesto_grid As String = CStr(row.Cells("impuesto").Value)
            Dim impuesto_formato As String = impuesto_grid.Replace(",", "")
            impuesto_formato = impuesto_formato.Replace(".", "")
            impuesto_formato = CInt(impuesto_formato).ToString("0000")

            ptr = PFrenglon(descripcion_formato, cantidad_formato, precio_formato, impuesto_formato)
            result = Marshal.PtrToStringAnsi(ptr)

            If result.Equals("ER") Then
                ptr = PFultimo()
                Return "ERROR En Renglon de Item"
            End If
            If result.Equals("TO") Then
                respuesta = "En Renglon de Item se excedió el tiempo de respuesta esperado del equipo."
            End If

        Next

        'Totaliza Factura Fiscal Devuelta
        ptr = PFtotal()
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFultimo()
            Return "ERROR Cerrando la Factura Devuelta"
        End If
        If result.Equals("TO") Then
            respuesta = "Cerrando la Factura Devuelta se excedió el tiempo de respuesta esperado del equipo."
        End If

        If respuesta = String.Empty Then
            respuesta = "Factura Devuelta"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Imprimir_Reporte_X_Pnp(ByVal numero_puerto As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            Return "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        'Genera Reporte X en el equipo.
        ptr = PFrepx()
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFcierrapuerto()
            result = Marshal.PtrToStringAnsi(ptr)
            Return "ERROR Generando Reporte X en el Equipo"
        End If
        If result.Equals("TO") Then
            respuesta = "Generando Reporte X en el Equipo se excedió el tiempo de respuesta esperado del equipo."
        End If

        If respuesta = String.Empty Then
            respuesta = "Generando Reporte X"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Imprimir_Reporte_Z_Pnp(ByVal numero_puerto As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            Return "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        'Genera Reporte Z en el equipo.
        ptr = PFrepz()
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            ptr = PFcierrapuerto()
            result = Marshal.PtrToStringAnsi(ptr)
            Return "ERROR Generando Reporte Z en el Equipo"
        End If
        If result.Equals("TO") Then
            respuesta = "Generando Reporte Z en el Equipo se excedió el tiempo de respuesta esperado del equipo."
        End If

        If respuesta = String.Empty Then
            respuesta = "Generando Reporte Z"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Serial_Impresora_Pnp(ByVal numero_puerto As String, ByRef serial_pnp As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            respuesta = "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        ptr = PFSerial()
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            respuesta = "ERROR Obteniendo Serial"
        End If
        If result.Equals("TO") Then
            respuesta = "Obteniendo Serial se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        'Obtiene el serial de la impresora pnp
        ptr = PFultimo()
        result = Marshal.PtrToStringAnsi(ptr)
        Dim st_str As String = CStr(result)
        Dim resultado_array() As String = st_str.Split(",")
        For index As Integer = 0 To resultado_array.Length
            If index = 2 Then
                serial_pnp = resultado_array(index)
                Exit For
            End If
        Next

        If respuesta = String.Empty Then
            respuesta = "Serial Obtenido"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Abrir_Gabeta_Pnp(ByVal numero_puerto As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            respuesta = "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        ptr = PFGaveta()

        If respuesta = String.Empty Then
            respuesta = "Apertura de Gaveta"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Reiniciar_Impresora_Pnp(ByVal numero_puerto As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            respuesta = "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        ptr = PFreset()
        If result.Equals("ER") Then
            respuesta = "ERROR Reiniciando la Impresora"
        End If
        If result.Equals("TO") Then
            respuesta = "Reiniciando la Impresora se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        If respuesta = String.Empty Then
            respuesta = "Reinicida la Impresora"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

    Public Function Obtener_Puerto_COM_Pnp(ByRef numero_puerto As String) As String
        Dim respuesta As String = String.Empty

        Const PORT_NAME As String = "COM"
        'Dim sp As New IO.Ports.SerialPort
        Dim pn() As String = IO.Ports.SerialPort.GetPortNames
        For Each port As String In pn

            respuesta = String.Empty
            If port.IndexOf(PORT_NAME) <> -1 Then
                'MessageBox.Show(port)

                'Cierra todos los puertos
                Dim ptr As IntPtr = PFcierrapuerto()
                Dim result As String = Marshal.PtrToStringAnsi(ptr)

                numero_puerto = port.Replace("COM", "")

                'Apertura del puerto
                ptr = PFabrepuerto(numero_puerto)
                result = Marshal.PtrToStringAnsi(ptr)
                If result.Equals("ER") Then
                    respuesta = "ERROR Abriendo Puerto"
                End If
                If result.Equals("TO") Then
                    respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
                End If
                If result.Equals("NP") Then
                    respuesta = "ERROR Puerto No Abierto."
                End If

                If respuesta = String.Empty Then
                    respuesta = "Puerto COM Abierto"
                    Exit For
                End If
            End If

            ''Try
            ''    sp.PortName = port
            ''    '        sp.Open()
            ''    '        Label1.Text = port & " is not connected"
            ''    '        sp.Close()
            ''Catch ex As Exception
            ''    Label1.Text = port & " is connected to a device")
            ''End Try
        Next

        Return respuesta
    End Function

    Public Function Reimprimir_Reporte_Z_Pnp(ByVal numero_puerto As String, ByVal fecha_desde As String, ByVal fecha_hasta As String, ByVal modo_mem As String) As String
        Dim respuesta As String = String.Empty

        'Cierra todos los puertos
        Dim ptr As IntPtr = PFcierrapuerto()
        Dim result As String = Marshal.PtrToStringAnsi(ptr)

        'Apertura del puerto
        ptr = PFabrepuerto(numero_puerto)
        result = Marshal.PtrToStringAnsi(ptr)
        If result.Equals("ER") Then
            Return "ERROR Abriendo Puerto"
        End If
        If result.Equals("TO") Then
            respuesta = "Abriendo Puerto se excedió el tiempo de respuesta esperado del equipo."
        End If
        If result.Equals("NP") Then
            respuesta = "ERROR Puerto No Abierto."
        End If

        '''Reimprimir Reporte Z
        '''ptr = PFRepMemNF(fecha_desde, fecha_hasta, modo_mem)
        '''ptr = PfRepMemoriaNumero(fecha_desde, fecha_hasta, modo_mem)
        'result = Marshal.PtrToStringAnsi(ptr)
        'If result.Equals("ER") Then
        '    ptr = PFultimo()
        '    Return "ERROR Reimprimir Reporte Z"
        'End If
        'If result.Equals("TO") Then
        '    respuesta = "Reimprimir Reporte Z Se excedió el tiempo de respuesta esperado del equipo."
        'End If

        If respuesta = String.Empty Then
            respuesta = "Generando Reimpresión de Reporte Z"
        End If

        'Cierra todos los puertos
        ptr = PFcierrapuerto()
        result = Marshal.PtrToStringAnsi(ptr)

        Return respuesta
    End Function

End Module
