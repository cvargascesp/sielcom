Imports MySql.Data.MySqlClient
Public Class n_factura
    Dim rebaja, forma, cant As Integer
    Dim codigo, codigoint As String
    Dim iva As Decimal = My.Settings.iva / 100

    Dim fpago() As String = {"formas de pago", "EFECTIVO", "CHEQUE", "DEBITO", "CREDITO", "ORDENDECOMPRA"}

    Private Sub n_factura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub n_factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label28.Text = Now.Date
        Label13.Text = ""
        Label9.Text = ""
        Label14.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label23.Text = ""
        Label10.Text = login.lblUsuario.Text
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        imprimir.ShowDialog()
        Me.Close()
        caja.Show()
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text <> "" Then
            'verifica si existe ticket
            Dim r As Integer
            Dim sql As String = "SELECT COUNT(*) FROM ticket WHERE numdocu ='" & TextBox2.Text & "' and estado='TICKET'"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            Conexion.open()
            r = cm.ExecuteScalar()
            Conexion.close()
            If r <> 0 Then
                'carga la grilla
                Try
                    Dim sql2 As String = "select d.codigo as Producto,d.cantidad as Cantidad,p.nombre as Descripción,p.marca as Marca,d.precioventa as Precio,d.total as Total from ticketdetalle d join producto p on(d.codigo=p.codigo) where numdocu='" & TextBox2.Text & "'"
                    Dim Ds2 As New DataSet
                    Dim Da2 As New MySqlDataAdapter(sql2, Conexion.conn)

                    Da2.Fill(Ds2, "ticketdetalle")
                    DataGridView1.DataSource = Ds2.Tables("ticketdetalle")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
                    DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

                Catch err As MySqlException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try


                'carga total
                Try
                    Dim ds5 As New DataSet
                    Dim sql5 As String = "SELECT total,responsable,cliente FROM ticket where numdocu='" & TextBox2.Text & "'"
                    Dim da5 As New MySqlDataAdapter(sql5, Conexion.conn)

                    da5.Fill(ds5, "ticket")

                    Label22.Text = CInt(ds5.Tables(0).Rows(0)(0)).ToString("##,###,##0")
                    Label13.Text = ds5.Tables(0).Rows(0)(1).ToString()
                    MaskedTextBox1.Text = ds5.Tables(0).Rows(0)(2).ToString()

                    'Carga cliente
                    If MaskedTextBox1.Text <> "  .   ." Then
                        TextBox19.Text = " "
                    End If
                Catch err As MySqlException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try

                TextBox4.Focus()
            Else
                MessageBox.Show("Número Documento NO Existe", "Verifique Ticket", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TextBox2.Text = ""
                TextBox2.Focus()
            End If
        Else
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox9.Text <> "" And TextBox2.Text <> "" And TextBox4.Text <> "" And MaskedTextBox1.Text <> "" And TextBox19.Text <> "" Then
            If CInt(TextBox9.Text) >= CInt(Label33.Text) Then
                Conexion.open()
                Dim trx As MySqlTransaction = Conexion.conn.BeginTransaction

                Try
                    'verifica si existe factura
                    Dim r As Integer
                    Dim sql As String = "SELECT COUNT(*) FROM boleta WHERE tipodocu = 'FACTURA' and numdocu ='" & TextBox4.Text & "'"
                    Dim cm As New MySqlCommand(sql, Conexion.conn)
                    r = cm.ExecuteScalar()
                    If r <> 0 Then
                        MessageBox.Show("Numero Factura Ya Existe", "Verifique Factura", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        trx.Rollback()
                    Else

                        'inserta nueva boleta
                        Dim sqlboleta As String = "INSERT INTO boleta(tipodocu,numdocu,cliente,vendedor,fechadocu,responsable,numticket,neto,iva,total,pago,formapago,cuotas,vuelto,estado,recibef,rutrecibef,recintof)" &
                             "VALUES(" &
                             "'FACTURA', " &
                             TextBox4.Text & ", '" &
                             MaskedTextBox1.Text & "','" &
                             Label13.Text & "','" &
                             Now.Date.ToString("yyyy-MM-dd") & "', '" &
                             Label10.Text & "', '" &
                             TextBox2.Text & "', " &
                             Label22.Text.Replace(".", "") & ", " &
                             Label31.Text.Replace(".", "") & ", " &
                             Label33.Text.Replace(".", "") & ", " &
                             TextBox9.Text & ", '" &
                             fpago(forma) & "', " &
                             IIf(ComboBox1.Text = "", "0", ComboBox1.Text) & ", " &
                             Label20.Text.Replace(".", "") & ", " &
                             "'EMITIDA', '" &
                             TextBox3.Text & "', '" &
                             MaskedTextBox2.Text & "', '" &
                             TextBox5.Text &
                             "')"
                        Dim cm3 As New MySqlCommand(sqlboleta, Conexion.conn)
                        cm3.ExecuteNonQuery()

                        For Each row As DataGridViewRow In DataGridView1.Rows
                            codigo = row.Cells(0).Value
                            cant = row.Cells(1).Value

                            Dim sqlprod As String = "select stock, porvender from producto where codigo = '" & codigo & "' for update"
                            Dim cmdprod As New MySqlCommand(sqlprod, Conexion.conn)

                            Dim rd As MySqlDataReader = cmdprod.ExecuteReader()

                            If rd.Read() Then
                                Dim stock As Integer = rd.GetInt32("stock")
                                Dim porvender As Integer = rd.GetInt32("porvender")

                                rd.Close()

                                Dim sqlprodupd As String = "UPDATE producto SET stock = @stock, porvender = @vender where codigo = @codigo"
                                Dim cmdprodupd As New MySqlCommand(sqlprodupd, Conexion.conn)
                                If cant > 0 Then
                                    stock = stock - cant
                                    porvender = porvender - cant
                                Else
                                    stock = stock + cant
                                    porvender = porvender + cant
                                End If
                                cmdprodupd.Parameters.AddWithValue("@stock", stock)
                                cmdprodupd.Parameters.AddWithValue("@vender", porvender)
                                cmdprodupd.Parameters.AddWithValue("@codigo", codigo)
                                cmdprodupd.ExecuteNonQuery()
                            End If
                        Next
                        'actualiza datos
                        Dim sql2 As String = "UPDATE ticket SET estado ='PAGADO' where numdocu='" & TextBox2.Text & "'"
                        Dim cm2 As New MySqlCommand(sql2, Conexion.conn)
                        cm2.ExecuteNonQuery()

                        trx.Commit()

                        'envia datos a facturacion
                        Dim factura As New factura
                        factura.Label1.Text = Label9.Text
                        factura.Label2.Text = Label14.Text
                        factura.Label3.Text = Label17.Text
                        factura.Label4.Text = Label18.Text
                        factura.Label5.Text = MaskedTextBox1.Text
                        factura.Label18.Text = TextBox19.Text
                        factura.Label6.Text = TextBox4.Text
                        factura.Label7.Text = Label28.Text
                        factura.Label8.Text = fpago(forma)
                        'label9 oc
                        'detalle
                        factura.Label10.Text = Label34.Text
                        factura.Label11.Text = TextBox3.Text
                        factura.Label13.Text = MaskedTextBox2.Text
                        factura.Label12.Text = TextBox5.Text
                        factura.Label14.Text = Label28.Text
                        factura.Label15.Text = Label22.Text
                        factura.Label16.Text = Label31.Text
                        factura.Label17.Text = Label33.Text
                        factura.Label19.Text = TextBox2.Text
                        factura.Show()
                        Me.Close()
                        caja.Show()
                    End If

                Catch err As MySqlException
                    trx.Rollback()
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    trx.Rollback()
                    MessageBox.Show(err.Message)
                End Try
                Conexion.close()
            Else
                MessageBox.Show("El Pago debe ser Igual o Superior al Total", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Complete Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar la Factura?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            caja.Show()
        End If
    End Sub

    Private Sub TextBox9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = ""
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        If TextBox2.Text <> "" And TextBox19.Text = " " Then
            'carga datos cliente
            Try
                Dim ds5 As New DataSet
                Dim sqlcliente As String = "select * from cliente where rut = '" & MaskedTextBox1.Text & "'"
                Dim dacliente As New MySqlDataAdapter(sqlcliente, Conexion.conn)
                dacliente.Fill(ds5, "cliente")

                If ds5.Tables("cliente").Rows.Count > 0 Then
                    Dim row = ds5.Tables("cliente").Rows(0)
                    TextBox19.Text = row("digito")
                    Label9.Text = row("nombre")
                    Label14.Text = row("giro")
                    Label17.Text = row("direccion")
                    Label18.Text = row("comuna")
                    Label23.Text = row("telefono1")
                Else
                    Label9.Text = ""
                    Label14.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label23.Text = ""
                    Dim resp As DialogResult = MessageBox.Show("Cliente no existe, desea crearlo ahora?", "Crear cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    If resp = DialogResult.Yes Then
                        Dim cliente_nuevo As New n_cliente
                        cliente_nuevo.MaskedTextBox1.Text = MaskedTextBox1.Text
                        cliente_nuevo.TextBox1.Text = ""
                        cliente_nuevo.ShowDialog()
                    ElseIf resp = DialogResult.Cancel Then
                        MaskedTextBox1.Text = ""
                        TextBox19.Text = ""
                        DataGridView1.Focus()
                        Exit Sub
                    End If
                    TextBox19.Text = ""
                    MaskedTextBox1.Focus()
                End If
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox2.Text <> "" And TextBox4.Text <> "" Then
            limpiaBotones()
            Button5.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 2
            Panel1.Visible = True
            ComboBox1.Visible = False
            ComboBox1.SelectedIndex = 0
            Label29.Visible = False
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox2.Text <> "" And TextBox4.Text <> "" Then
            limpiaBotones()
            Button7.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 3
            Panel1.Visible = True
            ComboBox1.Visible = False
            ComboBox1.SelectedIndex = 0
            Label29.Visible = False
            TextBox9.Text = Label33.Text
            TextBox9.Enabled = False
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If TextBox2.Text <> "" And TextBox4.Text <> "" Then
            limpiaBotones()
            Button6.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 4
            Panel1.Visible = True
            ComboBox1.Visible = True
            ComboBox1.SelectedIndex = 0
            Label29.Visible = True
            TextBox9.Text = Label33.Text
            TextBox9.Enabled = False
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox2.Text <> "" And TextBox4.Text <> "" Then
            limpiaBotones()
            Button8.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 5
            Panel1.Visible = True
            ComboBox1.Visible = True
            ComboBox1.SelectedIndex = 0
            Label29.Visible = True
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If TextBox2.Text <> "" And TextBox4.Text <> "" Then
            limpiaBotones()
            Button9.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 1
            Panel1.Visible = True
            ComboBox1.Visible = False
            Label29.Visible = False
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Dim pago As Integer = 0
        If TextBox9.Text <> "" Then
            pago = CInt(TextBox9.Text)
        End If
        If Label33.Text <> "" Then
            Label20.Text = (pago - CInt(Label33.Text)).ToString("##,###,##0")
        End If
    End Sub

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida solo letras
        If InStr(1, " abcdefghijklmnñopqrstuvwxyz" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox2.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Label22_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label22.TextChanged
        If Label22.Text <> "" Then
            Label31.Text = Math.Round(CInt(Label22.Text) * iva, 0).ToString("##,###,##0")
        End If
    End Sub

    Private Sub Label31_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label31.TextChanged
        If Label31.Text <> 0 Then
            Label33.Text = (CInt(Label22.Text) + CInt(Label31.Text)).ToString("##,###,##0")
        End If
    End Sub

    Private Sub Label33_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label33.TextChanged
        Label34.Text = Num2Text(CInt(Label33.Text))
    End Sub

    Private Sub limpiaBotones()
        Button5.BackColor = System.Drawing.SystemColors.Control
        Button6.BackColor = System.Drawing.SystemColors.Control
        Button7.BackColor = System.Drawing.SystemColors.Control
        Button8.BackColor = System.Drawing.SystemColors.Control
        Button9.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub MaskedTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.LostFocus
        TextBox19.Text = " "
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
End Class