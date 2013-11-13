Imports MySql.Data.MySqlClient
Public Class n_boleta
    Dim rebaja, forma, cant As Integer
    Dim codigo, codigoint As String
    Dim boleta As Integer = 0
    Dim desde_ticket As Boolean = False

    Dim fpago() As String = {"formas de pago", "EFECTIVO", "CHEQUE", "DEBITO", "CREDITO", "ORDENDECOMPRA"}

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar la Boleta?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then

            If TextBox2.Text <> "" Then
                Conexion.open()
                For Each r As DataGridViewRow In DataGridView1.Rows
                    Dim sqlprod As String = "select porvender from producto where codigo = '" & r.Cells(0).Value.ToString & "' for update"
                    Dim sqlprodupd As String = "update producto set porvender = porvender - " & r.Cells(1).Value.ToString & " where codigo = '" & r.Cells(0).Value.ToString & "'"

                    Dim cmdprod As New MySqlCommand(sqlprod, Conexion.conn)
                    Dim cmdprodupd As New MySqlCommand(sqlprodupd, Conexion.conn)

                    cmdprod.ExecuteNonQuery()
                    cmdprodupd.ExecuteNonQuery()
                Next

                Dim sql1 As String = "delete from ticket where numdocu = '" & TextBox2.Text & "'"
                Dim cmdsel As New MySqlCommand(sql1, Conexion.conn)
                cmdsel.ExecuteNonQuery()
                Conexion.close()
            End If

            Me.Close()
            If desde_ticket Then
                venta.Show()
            Else
                caja.Show()
            End If

        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo numeros y letras
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


    Private Sub TextBox9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = ""
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text <> "" And Label22.Text <> "" Then
            Label20.Text = (CInt(TextBox9.Text) - CInt(Label22.Text)).ToString("##,###,##0")
        End If
    End Sub

    Private Sub n_boleta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox3.Text = Now.Date
        Label5.Text = ""
        Label14.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label23.Text = ""
        Label9.Text = login.lblUsuario.Text

        desde_ticket = False
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
                    Label5.Text = ds5.Tables(0).Rows(0)(1).ToString()
                    MaskedTextBox1.Text = ds5.Tables(0).Rows(0)(2).ToString()

                    'Carga cliente
                    If MaskedTextBox1.Text.Length > 0 Then
                        Dim sqlcliente As String = "select * from cliente where rut = '" & MaskedTextBox1.Text & "'"
                        Dim dacliente As New MySqlDataAdapter(sqlcliente, Conexion.conn)
                        dacliente.Fill(ds5, "cliente")

                        If ds5.Tables("cliente").Rows.Count > 0 Then
                            Dim row = ds5.Tables("cliente").Rows(0)
                            TextBox19.Text = row("digito")
                            Label16.Text = row("nombre")
                            Label14.Text = row("giro")
                            Label17.Text = row("direccion")
                            Label18.Text = row("comuna")
                            Label23.Text = row("telefono1")
                        End If
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox9.Text <> "" And TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            If CInt(TextBox9.Text) >= CInt(Label22.Text) Then
                Conexion.open()

                'verificar si es sin numero de boleta entonces buscar correlativo SIN BOLETA
                If TextBox4.Text = "" Or TextBox4.Text = "0" Then
                    Dim sb As Integer
                    Dim sqlsb As String = "select correlativo + 1 from correlativos where tipo = 'SIN BOLETA' for update"
                    Dim cmdsb As New MySqlCommand(sqlsb, Conexion.conn)
                    sb = cmdsb.ExecuteScalar
                    Dim updsb As String = "update correlativos set correlativo = correlativo + 1 where tipo = 'SIN BOLETA'"
                    cmdsb = New MySqlCommand(updsb, Conexion.conn)
                    cmdsb.ExecuteNonQuery()
            
                    TextBox4.Text = sb
                End If

                Dim trx As MySqlTransaction = Conexion.conn.BeginTransaction

                Try
                    'verifica si existe boleta
                    Dim r As Integer
                    Dim sql As String = "SELECT COUNT(*) FROM boleta WHERE tipodocu = 'BOLETA' and numdocu ='" & TextBox4.Text & "'"
                    Dim cm As New MySqlCommand(sql, Conexion.conn)
                    r = cm.ExecuteScalar()
                    If r <> 0 Then
                        MessageBox.Show("Numero Boleta Ya Existe", "Verifique Boleta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        trx.Rollback()
                    Else
                        'inserta nueva boleta
                        Dim sqlboleta As String = "INSERT INTO boleta(tipodocu,numdocu,cliente,vendedor,fechadocu,responsable,numticket,neto,iva,total,pago,formapago,cuotas,vuelto,estado)" &
                             "VALUES(" &
                             "'BOLETA', " &
                             TextBox4.Text & ", '" &
                             MaskedTextBox1.Text & "','" &
                             Label5.Text & "','" &
                             Now.Date.ToString("yyyy-MM-dd") & "', '" &
                             Label9.Text & "', '" &
                             TextBox2.Text & "', " &
                             Label22.Text.Replace(".", "") & ", " &
                             "0, " &
                             Label22.Text.Replace(".", "") & ", " &
                             TextBox9.Text & ", '" &
                             fpago(forma) & "', " &
                             IIf(ComboBox1.Text = "", "0", ComboBox1.Text) & ", " &
                             Label20.Text.Replace(".", "") & ", " &
                             "'EMITIDA'" &
                             ")"
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
                                kardex_pro.kardexpro_salida(codigo, cant)
                            End If
                        Next

                        'actualiza datos
                        Dim sql2 As String = "UPDATE ticket SET estado ='PAGADO' where numdocu='" & TextBox2.Text & "'"
                        Dim cm2 As New MySqlCommand(sql2, Conexion.conn)
                        cm2.ExecuteNonQuery()
                        trx.Commit()

                        If My.Settings.imp_tickets <> "" Then
                            PrintDocument1.PrinterSettings.PrinterName = My.Settings.imp_tickets
                            PrintDocument1.Print()
                        End If

                        TextBox3.Text = Now.Date
                        TextBox2.Text = ""
                        Label5.Text = ""
                        Label14.Text = ""
                        Label16.Text = ""
                        Label17.Text = ""
                        Label18.Text = ""
                        Label23.Text = ""

                        boleta = boleta + 1
                        DataGridView1.DataSource = Nothing
                        TextBox4.Text = boleta

                        limpiaBotones()
                        Panel1.Hide()

                        TextBox2.Focus()

                        If desde_ticket Then
                            Me.Close()
                            venta.Show()
                        End If

                    End If

                Catch err As MySqlException
                    trx.Rollback()
                    MessageBox.Show(err.Message)
                Catch err As Exception
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
        If TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            limpiaBotones()
            Button4.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 1
            Panel1.Visible = True
            ComboBox1.Visible = False
            Label13.Visible = False
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            limpiaBotones()
            Button5.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 2
            Panel1.Visible = True
            ComboBox1.Visible = False
            ComboBox1.SelectedIndex = 0
            Label13.Visible = False
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            limpiaBotones()
            Button7.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 3
            Panel1.Visible = True
            ComboBox1.Visible = False
            ComboBox1.SelectedIndex = 0
            Label13.Visible = False
            TextBox9.Text = Label22.Text
            TextBox9.Enabled = False
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            limpiaBotones()
            Button6.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 4
            Panel1.Visible = True
            ComboBox1.Visible = True
            ComboBox1.SelectedIndex = 0
            Label13.Visible = True
            TextBox9.Text = Label22.Text
            TextBox9.Enabled = False
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox2.Text <> "" Then 'And TextBox4.Text <> "" Then
            limpiaBotones()
            Button8.BackColor = System.Drawing.SystemColors.ActiveCaption
            forma = 5
            Panel1.Visible = True
            ComboBox1.Visible = True
            ComboBox1.SelectedIndex = 0
            Label13.Visible = True
            TextBox9.Text = ""
            TextBox9.Enabled = True
        Else
            MessageBox.Show("Ingrese Información Requerida", "Pagar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub limpiaBotones()
        Button4.BackColor = System.Drawing.SystemColors.Control
        Button5.BackColor = System.Drawing.SystemColors.Control
        Button6.BackColor = System.Drawing.SystemColors.Control
        Button7.BackColor = System.Drawing.SystemColors.Control
        Button8.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text <> "" Then
            boleta = CInt(TextBox4.Text)
        End If
    End Sub

    Private Sub TextBox19_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.Leave
        If TextBox19.Text <> "" Then
            Dim sqlcliente As String = "select * from cliente where rut = '" & MaskedTextBox1.Text & "' and digito = '" & TextBox19.Text & "'"
            Dim ds5 As New DataSet
            Dim dacliente As New MySqlDataAdapter(sqlcliente, Conexion.conn)
            dacliente.Fill(ds5, "cliente")

            If ds5.Tables("cliente").Rows.Count > 0 Then
                Dim row = ds5.Tables("cliente").Rows(0)
                TextBox19.Text = row("digito")
                Label16.Text = row("nombre")
                Label14.Text = row("giro")
                Label17.Text = row("direccion")
                Label18.Text = row("comuna")
                Label23.Text = row("telefono1")
            Else
                Label16.Text = ""
                Label14.Text = ""
                Label17.Text = ""
                Label18.Text = ""
                Label23.Text = ""
                Dim resp As DialogResult = MessageBox.Show("Cliente no existe, desea crearlo ahora?", "Crear cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                If resp = DialogResult.Yes Then
                    Dim cliente_nuevo As New n_cliente
                    cliente_nuevo.MaskedTextBox1.Text = MaskedTextBox1.Text
                    cliente_nuevo.TextBox1.Text = TextBox19.Text
                    cliente_nuevo.ShowDialog()
                ElseIf resp = DialogResult.Cancel Then
                    MaskedTextBox1.Text = ""
                    TextBox19.Text = ""
                    DataGridView1.Focus()
                    Exit Sub
                End If
                TextBox19.Focus()
            End If
        End If
    End Sub

    Private Sub n_boleta_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        If TextBox2.Text <> "" Then
            desde_ticket = True
            TextBox4.Focus()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("LIBRERIA Cerro Grande", Label3.Font, Brushes.Black, 50, 0)
        e.Graphics.DrawString("Detalle:", Label3.Font, Brushes.Black, 15, 25)
        Dim posy As Integer = 50
        For Each fila As DataGridViewRow In DataGridView1.Rows
            e.Graphics.DrawString(fila.Cells(0).Value, New Font("Calibri", 8), Brushes.Black, 2, posy)
            If fila.Cells(2).Value.ToString.Length > 20 Then
                e.Graphics.DrawString(fila.Cells(2).Value.ToString.Substring(0, 20), New Font("Calibri", 8), Brushes.Black, 77, posy)
            Else
                e.Graphics.DrawString(fila.Cells(2).Value, New Font("Calibri", 8), Brushes.Black, 77, posy)
            End If
            e.Graphics.DrawString(fila.Cells(1).Value, New Font("Calibri", 8), Brushes.Black, 193, posy)
            e.Graphics.DrawString(fila.Cells(4).Value, New Font("Calibri", 8), Brushes.Black, 212, posy)

            'e.Graphics.DrawString(CInt(Label20.Text).ToString("##,###,##0"), New Font("Calibri", 15.75, FontStyle.Bold), Brushes.Black, 20, posy)
            posy += 15
        Next
        posy += 5
        e.Graphics.DrawString("TOTAL $", New Font("Corbel", 15.75, FontStyle.Bold), Brushes.Black, 20, posy)
        e.Graphics.DrawString(CInt(Label22.Text).ToString("##,###,##0"), New Font("Calibri", 15.75, FontStyle.Bold), Brushes.Black, 120, posy)
        posy += 25
        e.Graphics.DrawString("GRACIAS POR SU COMPRA", New Font("Microsoft Sans Serif", 8.25), Brushes.Black, 50, posy)
    End Sub
End Class