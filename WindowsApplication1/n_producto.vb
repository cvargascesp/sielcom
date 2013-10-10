Imports MySql.Data.MySqlClient
Public Class n_producto
    Dim producto As Integer
    Public iva As Decimal = My.Settings.iva / 100
    Dim existe As Integer
    Dim fechapedido As DateTime = Nothing
    Dim pedidoanterior As Integer
    Dim margen_ant, venta_ant
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        Try
            If ComboBox1.Items.Count = Nothing Then
                Dim actual As String = ComboBox1.Text
                'carga datos para actualizar
                Dim ds As New DataSet
                Dim sql2 As String = "SELECT distinct marca FROM producto order by marca"
                Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
                Conexion.open()
                da.Fill(ds)
                ' asignar el DataSource al combobox  
                ComboBox1.DataSource = ds.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox1.DisplayMember = "marca"
                ComboBox1.ValueMember = "marca"
                ComboBox1.SelectedValue = actual
            End If
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        Try
            If ComboBox2.Items.Count = Nothing Then
                Dim actual As String = ComboBox2.Text
                'carga datos para actualizar
                Dim ds As New DataSet
                Dim sql2 As String = "SELECT distinct categoria FROM producto order by categoria"
                Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
                Conexion.open()
                da.Fill(ds)
                ' asignar el DataSource al combobox  
                ComboBox2.DataSource = ds.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox2.DisplayMember = "categoria"
                ComboBox2.ValueMember = "categoria"
                ComboBox2.SelectedValue = actual
            End If
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub ComboBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.GotFocus
        Try
            If ComboBox3.Items.Count = Nothing Then
                Dim actual As String = ComboBox3.Text
                'carga datos para actualizar
                Dim ds As New DataSet
                Dim sql2 As String = "SELECT nombre FROM proveedor order by nombre"
                Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
                Conexion.open()
                da.Fill(ds)
                ' asignar el DataSource al combobox  
                ComboBox3.DataSource = ds.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox3.DisplayMember = "nombre"
                ComboBox3.ValueMember = "nombre"
                ComboBox3.SelectedValue = actual
            End If
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    'Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    'valida numeros y letras
    '    If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJLKMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
    'e.KeyChar = ""
    'End If
    'End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'valida numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        'valida numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        'valida numeros 
        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        'valida numeros 
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox10_leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.Leave
        If TextBox10.Text <> "" AndAlso TextBox10.Text <> venta_ant OrElse TextBox8.Text = "" Then
            If TextBox7.Text <> "0" And TextBox7.Text <> "" And TextBox10.Text <> "0" And TextBox10.Text <> "" Then
                Label19.Text = CInt(TextBox10.Text) - CInt(TextBox7.Text)
                Label23.Text = CInt(Label19.Text) * CInt(NumericUpDown1.Value)

                Dim neto = CInt(TextBox10.Text) / (1 + iva)
                Dim margen = (Decimal.Round(neto, 0) - CInt(TextBox7.Text)) / CInt(TextBox7.Text) * 100

                TextBox8.Text = Decimal.Round(margen, 2)
            End If
            venta_ant = CInt(TextBox10.Text)
            margen_ant = CDec(TextBox8.Text)
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If NumericUpDown1.Text >= 1 And TextBox7.Text <> "" Then
            Label21.Text = CInt(TextBox7.Text) * CInt(NumericUpDown1.Value)
        End If
        Dim porc As Integer
        If TextBox8.Text = "" Then
            TextBox10.Clear()
        ElseIf TextBox8.Text <> "" And TextBox7.Text <> "" Then
            porc = ((CInt(TextBox7.Text) * CInt(TextBox8.Text)) / 100) + CInt(TextBox7.Text)
            porc = (CInt(porc) * iva) + porc
            TextBox10.Text = porc
        End If
    End Sub

    Private Sub n_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub n_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label17.Text = Now.Date
        Label19.Text = ""
        Label21.Text = ""
        Label23.Text = ""
        Label26.Text = ""
        Label28.Text = ""
        Label29.Text = ""
        Label31.Text = ""
        Label33.Text = ""

        'carga usuario responsable
        Label35.Text = login.lblUsuario.Text

        Try
            'carga ultimo codigo producto
            Dim r As Integer
            Conexion.open()
            Dim sql2 As String = "SELECT COUNT(codigoint) FROM producto"
            Dim cm2 As New MySqlCommand(sql2, Conexion.conn)
            r = cm2.ExecuteScalar()
            Conexion.close()
            producto = r + 1
            Label25.Text = producto
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Text >= 1 And TextBox7.Text <> "" Then
            Label21.Text = CInt(TextBox7.Text) * CInt(NumericUpDown1.Value)
            Label23.Text = CInt(Label19.Text) * CInt(NumericUpDown1.Value)
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Try
            'verifica si existe producto
            existe = 0
            Conexion.open()
            Dim sql As String = "SELECT COUNT(*) FROM producto WHERE codigo ='" & TextBox1.Text & "' limit 1"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            existe = cm.ExecuteScalar()
            Conexion.close()
            If existe <> 0 Then
                Dim resul As DialogResult
                resul = MessageBox.Show("Desea Actualizar Datos", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If resul = Windows.Forms.DialogResult.Yes Then
                    cargaDatos()
                Else
                    TextBox1.Clear()
                    TextBox1.Focus()
                End If
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub ComboBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.GotFocus
        If ComboBox6.Items.Count = Nothing Then
            Dim actual As String = ComboBox6.Text
            'carga datos para actualizar
            Dim ds As New DataSet
            Dim sql2 As String = "SELECT distinct modelo FROM producto order by modelo"
            Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
            Conexion.open()
            da.Fill(ds)
            ' asignar el DataSource al combobox  
            ComboBox6.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox6.DisplayMember = "modelo"
            ComboBox6.ValueMember = "modelo"
            ComboBox6.SelectedValue = actual
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'valida que no hayan datos vacios
            If TextBox1.Text <> "" And NumericUpDown1.Value >= 1 And TextBox7.Text <> "" And TextBox10.Text <> "" Then
                Dim sql As String
                If existe = 0 Then
                    'inserta un nuevo producto
                    sql = "INSERT INTO producto (codigo,codigoint,nombre,descripcion,marca,modelo,linea,categoria,proveedor,ubicacion,umedida,stock,critico,porvender,porllegar,fechapedido,preciouni,margen,precioventa,utilidaduni,estado,fechaingreso,creado)" & _
                     "VALUES('" & TextBox1.Text & "','" & Label25.Text & "','" & txtNombre.Text & "', '" & TextBox4.Text & "', '" & ComboBox1.Text & "', '" & ComboBox6.Text & "', '" & cbLinea.Text & "', '" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & txtUbicacion.Text & "','" & txtUmedida.Text & "'," & NumericUpDown1.Value & "," & NumericUpDown2.Value & "," & nupPorvender.Value & "," & nupPorllegar.Value & ", " & IIf(fechapedido = Nothing, "NULL", "'" & fechapedido.ToString("yyyy-MM-dd HH:mm:ss") & "'") & "," & TextBox7.Text & "," & TextBox8.Text.Replace(",", ".") & "," & TextBox10.Text & ",0,'NUEVO','" & CDate(Label17.Text).Date.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:ss") & "','" & Label35.Text & "')"
                    Console.Write(sql)
                Else
                    'modificar un producto
                    sql = "UPDATE producto SET " &
                        "codigo = '" & TextBox1.Text &
                        "', codigoint = '" & Label25.Text &
                        "', nombre = '" & txtNombre.Text &
                         "', descripcion = '" & TextBox4.Text &
                        "', marca = '" & ComboBox1.Text &
                        "', modelo = '" & ComboBox6.Text &
                        "', linea = '" & cbLinea.Text &
                        "', categoria = '" & ComboBox2.Text &
                        "', proveedor = '" & ComboBox3.Text &
                        "', ubicacion = '" & txtUbicacion.Text &
                        "', umedida = '" & txtUmedida.Text &
                        "', stock = " & NumericUpDown1.Value &
                        ", critico = " & NumericUpDown2.Value &
                        ", porvender = " & nupPorvender.Value &
                        ", porllegar = " & nupPorllegar.Value &
                        ", fechapedido = " & IIf(fechapedido = Nothing, "NULL", "'" & fechapedido.ToString("yyyy-MM-dd HH:mm:ss") & "'") &
                        ", preciouni = " & TextBox7.Text &
                        ", margen = " & TextBox8.Text.Replace(",", ".") &
                        ", precioventa = " & TextBox10.Text &
                        " WHERE codigo = '" & TextBox1.Text & "'"
                End If

                Dim cm3 As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                cm3.ExecuteNonQuery()
                Conexion.close()
                producto = producto + 1
                Label25.Text = producto
                MessageBox.Show("Producto Guardado con Exito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
            Else
                MessageBox.Show("Complete Información Requerida", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        Conexion.close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        'cambia texto a MAYUSCULAS
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ,.-_" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-_,." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-,._" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox6.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-_,./\" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.LostFocus
        If ComboBox3.Text <> "" Then
            Try
                'verifica si existe proveedor
                Dim r As Integer
                Conexion.open()
                Dim sql As String = "SELECT COUNT(*) FROM proveedor WHERE nombre ='" & ComboBox3.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                r = cm.ExecuteScalar()
                Conexion.close()
                If r = 0 Then
                    Dim resul As DialogResult
                    resul = MessageBox.Show("Proveedor NO Existe, Desea Crearlo", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If resul = Windows.Forms.DialogResult.Yes Then
                        Dim n_proveedor As New n_proveedor
                        n_proveedor.TextBox2.Text = ComboBox3.Text
                        n_proveedor.ShowDialog()
                        ComboBox3.DataSource = Nothing
                    End If
                End If
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        If existe = 0 AndAlso ComboBox2.ValueMember <> "" Then
            If ComboBox2.Text.Length >= 3 Then
                Label25.Text = ""
                Me.Label25.Text = ComboBox2.Text.Substring(0, 3) & CStr(producto)
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Imprimir Código de Barra?", "Crear Código", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text <> "" Then
                If My.Settings.imp_tickets <> "" Then
                    PrintDocument1.PrinterSettings.PrinterName = My.Settings.imp_tickets
                    PrintDocument1.Print()
                End If
            Else
                MessageBox.Show("Ingrese Información Requerida", "Generar Código", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibir.Click
        'datos para form
        n_recibestock.cbProveedor.Text = ComboBox3.Text
        n_recibestock.txtCodigo.Text = TextBox1.Text
        n_recibestock.txtPrecioventa.Text = TextBox10.Text
        n_recibestock.lblPorllegar.Text = nupPorllegar.Value
        n_recibestock.txtMargen.Text = TextBox8.Text

        n_recibestock.ShowDialog()
        If n_recibestock.DialogResult = Windows.Forms.DialogResult.OK Then
            cargaDatos()
        End If
    End Sub

    Private Sub cargaDatos()
        'carga datos 
        Dim ds2 As New DataSet
        Dim sql2 As String = "SELECT * FROM producto where codigo='" & TextBox1.Text & "'"
        Dim da2 As New MySqlDataAdapter(sql2, Conexion.conn)
        Conexion.open()
        da2.Fill(ds2, "producto")


        Dim sql3 As String = "select * from facturacompra where codigo = '" & TextBox1.Text & "' and cantidad > 0 order by fechaingreso desc limit 1"
        Dim da3 As New MySqlDataAdapter(sql3, Conexion.conn)
        da3.Fill(ds2, "factura")

        If ds2.Tables.Count > 1 AndAlso ds2.Tables(1).Rows.Count > 0 Then
            Label28.Text = ds2.Tables(1).Rows(0)("cantidad").ToString()
            Label29.Text = ds2.Tables(1).Rows(0)("preciouni").ToString()
            Label31.Text = ds2.Tables(1).Rows(0)("precioventa").ToString()
            Label33.Text = ds2.Tables(1).Rows(0)("fechaingreso").ToString
        End If
        'carga datos para actualizar
        Label25.Text = ds2.Tables(0).Rows(0)("codigoint").ToString()
        Label26.Text = ds2.Tables(0).Rows(0)("stock").ToString()
        txtNombre.Text = ds2.Tables(0).Rows(0)("nombre").ToString()
        TextBox4.Text = ds2.Tables(0).Rows(0)("descripcion").ToString
        txtUmedida.Text = ds2.Tables(0).Rows(0)("umedida").ToString
        ComboBox1.Text = ds2.Tables(0).Rows(0)("marca").ToString()
        ComboBox6.Text = ds2.Tables(0).Rows(0)("modelo").ToString()
        cbLinea.Text = ds2.Tables(0).Rows(0)("linea").ToString()
        ComboBox2.Text = ds2.Tables(0).Rows(0)("categoria").ToString()
        ComboBox3.Text = ds2.Tables(0).Rows(0)("proveedor").ToString
        NumericUpDown1.Value = ds2.Tables(0).Rows(0)("stock")
        NumericUpDown2.Value = ds2.Tables(0).Rows(0)("critico")
        nupPorllegar.Value = ds2.Tables(0).Rows(0)("porllegar")
        pedidoanterior = nupPorllegar.Value
        fechapedido = IIf(IsDBNull(ds2.Tables(0).Rows(0)("fechapedido")), Nothing, ds2.Tables(0).Rows(0)("fechapedido"))
        nupPorvender.Value = ds2.Tables(0).Rows(0)("porvender")
        TextBox7.Text = ds2.Tables(0).Rows(0)("preciouni")
        TextBox8.Text = ds2.Tables(0).Rows(0)("margen")
        TextBox10.Text = ds2.Tables(0).Rows(0)("precioventa")
        txtUbicacion.Text = ds2.Tables(0).Rows(0)("ubicacion").ToString
    End Sub

    Private Sub nupPorllegar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nupPorllegar.LostFocus
        If nupPorllegar.Value > 0 Then
            fechapedido = Now
        Else
            fechapedido = Nothing
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        LinearWinForm1.Data = TextBox1.Text
        e.Graphics.DrawImage(LinearWinForm1.drawBarcode(), 15, 25)
    End Sub

    Private Sub cbLinea_GotFocus(sender As Object, e As System.EventArgs) Handles cbLinea.GotFocus
        Try
            If cbLinea.Items.Count = Nothing Then
                Dim actual As String = cbLinea.Text
                'carga datos para actualizar
                Dim ds As New DataSet
                Dim sql2 As String = "SELECT distinct linea FROM producto order by linea"
                Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
                Conexion.open()
                da.Fill(ds)
                ' asignar el DataSource al combobox  
                cbLinea.DataSource = ds.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                cbLinea.DisplayMember = "linea"
                cbLinea.ValueMember = "linea"
                cbLinea.SelectedValue = actual
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub cbLinea_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbLinea.KeyPress
        'cambia texto a MAYUSCULAS
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox8_Leave(sender As Object, e As System.EventArgs) Handles TextBox8.Leave
        Dim porc As Integer
        If TextBox8.Text <> "" AndAlso TextBox8.Text <> margen_ant OrElse TextBox10.Text = "" Then
            If TextBox8.Text <> "0" And TextBox8.Text <> "" Then
                porc = ((CInt(TextBox7.Text) * CInt(TextBox8.Text)) / 100) + CInt(TextBox7.Text)
                porc = (CInt(porc) * iva) + porc
                TextBox10.Text = porc
            End If
            venta_ant = CInt(TextBox10.Text)
            margen_ant = CDec(TextBox7.Text)
        End If
    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub
End Class