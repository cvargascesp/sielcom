Imports MySql.Data.MySqlClient
Public Class n_ticket
    Dim ticket As Integer
    Dim a As Integer = 0
    Dim rebaja As Integer
    Dim total As Integer
    Dim stock As String
    Dim cotnueva As Integer = 0

    Private Sub n_ticket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub
    Private Sub n_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox3.Text = Now.Date
        'Label8.Text = "0"
        'Label13.Text = "0"

        If TextBox1.Text = "COTIZACION" Then
            cbCotizacion.Visible = True
            btnElimCotizacion.Visible = True
        End If

        Label6.Text = "0"
        Label21.Text = ""

        ActiveControl = TextBox4
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar la Venta?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            venta.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text <> "" And Label8.Text <> "" Then
            'actualiza ticket
            grabaTicket()

            If My.Settings.imp_tickets <> "" Then
                PrintDocument1.PrinterSettings.PrinterName = My.Settings.imp_tickets
                PrintDocument1.Print()
            End If

            Me.Hide()
            venta.Show()
        Else
            MessageBox.Show("Complete Campos Requeridos", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo numeros y letras
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    'Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
    '    If DataGridView1.SelectedRows.Count <> 0 Then
    '        Dim codigo As String = CStr(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
    '        Dim cantidad As String = CStr(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
    '        Dim nombre As String = CStr(DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value)
    '        Dim descripcion As String = CStr(DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value)
    '        Dim precio As String = CStr(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value)

    '        Dim m_boleta As New m_boleta
    '        m_boleta.TextBox1.Text = codigo
    '        m_boleta.TextBox2.Text = cantidad
    '        m_boleta.TextBox3.Text = nombre
    '        m_boleta.TextBox4.Text = descripcion
    '        m_boleta.TextBox5.Text = precio
    '        m_boleta.Label6.Text = Label6.Text
    '        DataGridView1.DataSource = Nothing
    '        m_boleta.ShowDialog()
    '        'muestra producto en grilla
    '        Try
    '            Dim sql4 As String = "select codigopro as Código,cantidadpro as Cantidad,nombrepro as Nombre,descripcionpro as Descripción,preciopro as Precio from ticket WHERE numdocu  ='" & Label6.Text & "'"
    '            Dim Ds4 As New DataSet
    '            Dim Da4 As New MySqlDataAdapter(sql4, Conexion.conn)

    '            Da4.Fill(Ds4, "ticket")

    '            DataGridView1.DataSource = Ds4.Tables("ticket").DefaultView
    '            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
    '            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    '            'TextBox4.Clear()
    '        Catch err As MySQLException
    '            MessageBox.Show(err.Message)
    '        Catch err As Exception
    '            MessageBox.Show(err.Message)
    '        End Try
    '        'carga total
    '        Try
    '            Dim ds5 As New DataSet
    '            Dim sql5 As String = "SELECT sum(preciopro*cantidadpro),descuento,total FROM ticket where numdocu='" & Label6.Text & "'"
    '            Dim da5 As New MySqlDataAdapter(sql5, Conexion.conn)

    '            da5.Fill(ds5)

    '            Label8.Text = ds5.Tables(0).Rows(0)(0).ToString()
    '            Label13.Text = ds5.Tables(0).Rows(0)(1).ToString()
    '            Label20.Text = Label8.Text
    '        Catch err As MySQLException
    '            MessageBox.Show(err.Message)
    '        Catch err As Exception
    '            MessageBox.Show(err.Message)
    '        End Try
    '    End If
    'End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text <> "" Then
            Try
                Dim sql As String = "select count(*) from producto where codigo = '" & TextBox4.Text & "'"
                Dim cmd As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                Dim r As Integer = cmd.ExecuteScalar
                Conexion.close()
                If r = 0 Then
                    MessageBox.Show("Producto no existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TextBox4.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        Else
            Exit Sub
        End If

        If ComboBox1.Text <> "" Then
            Try
                Conexion.open()
                'verifica si existe ticket
                Dim r As Integer
                Dim sql As String = "SELECT COUNT(*) FROM ticket WHERE numdocu ='" & Label6.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                r = cm.ExecuteScalar()
                If r = 0 Or TextBox1.Text = "COTIZACION" Then
                    'verifica si hay stock
                    Dim r0 As Integer
                    Dim sql0 As String = "SELECT stock-porvender FROM producto WHERE codigo ='" & TextBox4.Text & "'"
                    Dim cm0 As New MySqlCommand(sql0, Conexion.conn)
                    r0 = cm0.ExecuteScalar()
                    If r0 >= NumericUpDown1.Value Then
                        'agrega producto a la grilla
                        Dim sql5 As String = "select codigo, codigoint, nombre, descripcion, marca, modelo, preciouni, precioventa from producto WHERE codigo ='" & TextBox4.Text & "'"
                        Dim cmd As New MySqlCommand(sql5, Conexion.conn)
                        Dim rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then
                            DataGridView1.Rows.Add(rd.GetString("codigo"),
                                                    rd.GetString("nombre"),
                                                    rd.GetString("marca"),
                                                    NumericUpDown1.Value,
                                                    rd.GetInt32("precioventa"),
                                                    NumericUpDown1.Value * rd.GetInt32("precioventa"),
                                                    rd.GetString("descripcion"),
                                                    rd.GetString("modelo"),
                                                    rd.GetInt32("preciouni"),
                                                    0
                                                    )
                            total = total + NumericUpDown1.Value * rd.GetInt32("precioventa")
                        End If

                        rd.Close()
                        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
                        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                    Else
                        MessageBox.Show("No Hay Stock Suficiente : Disponible " & r0 & " und.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("error al crear ticket.  Ya existe el documento")
                End If
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            Conexion.close()

            'calcula totales
            If total > 0 Then
                Label8.Text = total.ToString("##,###,##0")
                If TextBox5.Text <> "" Then
                    Label13.Text = Math.Round(total * CInt(TextBox5.Text) / 100, 0).ToString("##,###,##0")
                End If
                Label20.Text = (total - CInt(Label13.Text)).ToString("##,###,##0")
            End If
            NumericUpDown1.Value = 1
            TextBox4.Text = ""
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text <> "" Then
            Label13.Text = Math.Round(CInt(Label8.Text) * CInt(TextBox5.Text) / 100, 0).ToString("##,###,##0")
            Label20.Text = (CInt(Label8.Text) - CInt(Label13.Text)).ToString("##,###,##0")
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        'verifica si existe rut
        Dim r As Integer
        Dim sql As String = "SELECT COUNT(*) FROM cliente WHERE rut ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox6.Text & "'"
        Dim cm As New MySqlCommand(sql, Conexion.conn)
        Conexion.open()
        r = cm.ExecuteScalar()
        Conexion.close()
        If r = 0 Then
            Dim resul As DialogResult
            resul = MessageBox.Show("Cliente NO Existe, Desea Ingresar Nuevo Cliente", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If resul = Windows.Forms.DialogResult.Yes Then
                Dim n_cliente As New n_cliente
                n_cliente.MaskedTextBox1.Text = MaskedTextBox1.Text
                n_cliente.TextBox1.Text = TextBox6.Text
                n_cliente.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ComboBox1_GotFocus(sender As Object, e As System.EventArgs) Handles ComboBox1.GotFocus
        'carca cb trabajadores
        If ComboBox1.Items.Count = 0 Then
            Try
                Dim ds2 As New DataSet
                Dim sql2 As String = "SELECT nombre FROM usuario where " & IIf(login.lblUsuario.Text = "ADMINISTRADOR", "cuenta='ADMINISTRADOR' or ", "") & "cuenta='VENTAS' order by nombre"
                Dim da2 As New MySqlDataAdapter(sql2, Conexion.conn)

                da2.Fill(ds2)
                ' asignar el DataSource al combobox  
                ComboBox1.DataSource = ds2.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox1.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString

            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If cotnueva = 0 Then
            cotnueva = 1
        End If
        If Label6.Text = "0" Then
            Try
                Dim sql As String = "select correlativo + 1 from correlativos where tipo = 'TICKET' for update"
                Dim sqlu As String = "update correlativos set correlativo = correlativo + 1 where tipo = 'TICKET'"
                Dim cmd As New MySqlCommand(sql, Conexion.conn)
                Dim cmd2 As New MySqlCommand(sqlu, Conexion.conn)
                Conexion.open()
                ticket = cmd.ExecuteScalar
                cmd2.ExecuteNonQuery()
                Conexion.close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        Me.Label6.Text = Me.ComboBox1.Text.Substring(0, 3) + CStr(ticket)
        TextBox4.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And Label20.Text <> "" Then
            Button1.Visible = False
            Button4.Visible = False
            GroupBox2.Visible = False

            grabaTicket()

            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Top = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = False
            'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)

            If My.Settings.imp_cotizaciones <> "" Then
                PrintDocument2.PrinterSettings.PrinterName = My.Settings.imp_cotizaciones
                PrintDocument2.Print()
            End If

            Me.Close()
            venta.Show()
        Else
            MessageBox.Show("Complete información requerida", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar la Cotización?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            venta.Show()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        LinearWinForm1.Data = Label6.Text
        e.Graphics.DrawString("LIBRERIA.", Label3.Font, Brushes.Black, 70, 0)
        e.Graphics.DrawImage(LinearWinForm1.drawBarcode(), 15, 25)
        e.Graphics.DrawString("TOTAL $", New Font("Corbel", 15.75, FontStyle.Bold), Brushes.Black, 20, 110)
        e.Graphics.DrawString(CInt(Label20.Text).ToString("##,###,##0"), New Font("Calibri", 15.75, FontStyle.Bold), Brushes.Black, 120, 110)
        e.Graphics.DrawString("GRACIAS POR SU COMPRA", New Font("Microsoft Sans Serif", 8.25), Brushes.Black, 50, 140)
    End Sub

    Private Sub grabaTicket()

        Conexion.open()
        Dim trx As MySqlTransaction = Conexion.conn.BeginTransaction()

        Try
            Dim sql1 As String = "select numdocu from ticket where numdocu = '" & Label6.Text & "'"
            Dim cmdsel As New MySqlCommand(sql1, Conexion.conn)
            Dim sel = cmdsel.ExecuteScalar

            If sel <> "" Then
                sql1 = "delete from ticket where numdocu = '" & Label6.Text & "'"
                cmdsel = New MySqlCommand(sql1, Conexion.conn)
                cmdsel.ExecuteNonQuery()
            End If

            Dim sqlticket As String = "insert into ticket(numdocu,responsable,fechadocu,cliente,neto,descuento,total,estado)" &
                                " VALUES('" & Label6.Text & "', '" & ComboBox1.Text & "', '" & CDate(TextBox3.Text).ToString("yyyy-MM-dd") & "','" & MaskedTextBox1.Text & "', " & Label8.Text.Replace(".", "") & ", " & Label13.Text.Replace(".", "") & ", " & Label20.Text.Replace(".", "") & ", '" & TextBox1.Text & "') "
            '" ON DUPLICATE KEY UPDATE neto = " & Label8.Text.Replace(".", "") & ", descuento = " & Label13.Text.Replace(".", "") & ", total = " & Label20.Text.Replace(".", "")
            Dim cmdticket As New MySqlCommand(sqlticket, Conexion.conn)

            cmdticket.ExecuteNonQuery()

            Dim i As Integer
            For Each r As DataGridViewRow In DataGridView1.Rows
                i = i + 1
                Dim sqlitem As String = "insert into ticketdetalle (numdocu,numero,codigo,cantidad,preciocosto,precioventa,descuento,total)" &
                                        " values('" &
                                        Label6.Text & "', " &
                                        i & ", '" &
                                        r.Cells(0).Value.ToString & "', " &
                                        r.Cells(3).Value.ToString & ", " &
                                        r.Cells(8).Value.ToString & ", " &
                                        r.Cells(4).Value.ToString & ", " &
                                        r.Cells(9).Value.ToString & ", " &
                                        r.Cells(5).Value.ToString & ")"
                '" on duplicate key update codigo = '" & r.Cells(0).Value.ToString & "', " &
                '" cantidad = " & r.Cells(3).Value.ToString & ", " &
                '" preciocosto = " & r.Cells(8).Value.ToString & ", " &
                '" precioventa = " & r.Cells(4).Value.ToString & ", " &
                '" descuento = " & r.Cells(9).Value.ToString & ", " &
                '" total = " & r.Cells(5).Value.ToString
                Dim cmd As New MySqlCommand(sqlitem, Conexion.conn)

                cmd.ExecuteNonQuery()

                If TextBox1.Text = "TICKET" Then
                    Dim sqlprod As String = "select porvender from producto where codigo = '" & r.Cells(0).Value.ToString & "' for update"
                    Dim sqlprodupd As String = "update producto set porvender = porvender + " & r.Cells(3).Value.ToString & " where codigo = '" & r.Cells(0).Value.ToString & "'"

                    Dim cmdprod As New MySqlCommand(sqlprod, Conexion.conn)
                    Dim cmdprodupd As New MySqlCommand(sqlprodupd, Conexion.conn)

                    cmdprod.ExecuteNonQuery()
                    cmdprodupd.ExecuteNonQuery()
                End If

            Next
            trx.Commit()
        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        Dim balance As Integer = 0
        For counter = 0 To (DataGridView1.Rows.Count - 1)
            balance = balance + Integer.Parse(DataGridView1.Rows(counter).Cells("valortotal").Value.ToString())
        Next

        total = balance
        'If total > 0 Then
        Label8.Text = total.ToString("##,###,##0")
        If TextBox5.Text <> "" Then
            Label13.Text = Math.Round(total * CInt(TextBox5.Text) / 100, 0).ToString("##,###,##0")
        End If
        Label20.Text = (total - CInt(Label13.Text)).ToString("##,###,##0")
        'End If
    End Sub

    Private Sub btnBoleta_Click(sender As System.Object, e As System.EventArgs) Handles btnBoleta.Click
        If ComboBox1.Text <> "" And Label8.Text <> "" Then
            'actualiza ticket
            grabaTicket()

            Me.Hide()
            n_boleta.TextBox2.Text = Label6.Text
            n_boleta.Show()

        Else
            MessageBox.Show("Complete Campos Requeridos", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        e.Graphics.DrawString("LIBRERIA Cerro Grande", New Font("Corbel", 9.75, FontStyle.Bold), Brushes.Black, 50, 0)
        e.Graphics.DrawString("Cotización: " + Label6.Text, New Font("Corbel", 9.75, FontStyle.Bold), Brushes.Black, 15, 25)
        Dim posy As Integer = 50
        For Each fila As DataGridViewRow In DataGridView1.Rows
            e.Graphics.DrawString(fila.Cells(0).Value, New Font("Calibri", 8), Brushes.Black, 2, posy)
            If fila.Cells(1).Value.ToString.Length > 20 Then
                e.Graphics.DrawString(fila.Cells(1).Value.ToString.Substring(0, 20), New Font("Calibri", 8), Brushes.Black, 77, posy)
            Else
                e.Graphics.DrawString(fila.Cells(1).Value, New Font("Calibri", 8), Brushes.Black, 77, posy)
            End If
            e.Graphics.DrawString(fila.Cells(3).Value, New Font("Calibri", 8), Brushes.Black, 193, posy)
            e.Graphics.DrawString(fila.Cells(4).Value, New Font("Calibri", 8), Brushes.Black, 212, posy)

            'e.Graphics.DrawString(CInt(Label20.Text).ToString("##,###,##0"), New Font("Calibri", 15.75, FontStyle.Bold), Brushes.Black, 20, posy)
            posy += 15
        Next
        posy += 5
        e.Graphics.DrawString("TOTAL $", New Font("Corbel", 15.75, FontStyle.Bold), Brushes.Black, 20, posy)
        e.Graphics.DrawString(CInt(Label20.Text).ToString("##,###,##0"), New Font("Calibri", 15.75, FontStyle.Bold), Brushes.Black, 120, posy)
        posy += 25
        'e.Graphics.DrawString("GRACIAS POR SU COMPRA", New Font("Microsoft Sans Serif", 8.25), Brushes.Black, 50, posy)
    End Sub

    Private Sub cbCotizacion_GotFocus(sender As Object, e As System.EventArgs) Handles cbCotizacion.GotFocus
        If cotnueva = 0 Then
            cotnueva = 2
        End If
        If cbCotizacion.Items.Count = 0 Then
            'carca cb trabajadores
            If ComboBox1.Items.Count = 0 Then
                Try
                    Dim ds2 As New DataSet
                    Dim sql2 As String = "SELECT nombre FROM usuario where " & IIf(login.lblUsuario.Text = "ADMINISTRADOR", "cuenta='ADMINISTRADOR' or ", "") & "cuenta='VENTAS' order by nombre"
                    Dim da2 As New MySqlDataAdapter(sql2, Conexion.conn)

                    da2.Fill(ds2)
                    ' asignar el DataSource al combobox  
                    ComboBox1.DataSource = ds2.Tables(0)
                    ' Asignar el campo a la propiedad DisplayMember del combo   
                    ComboBox1.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString

                Catch err As MySqlException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
            End If

            Try
                Dim ds1 As New DataSet
                Dim sql1 As String = "SELECT numdocu FROM ticket where estado = 'COTIZACION'"
                Dim da1 As New MySqlDataAdapter(sql1, Conexion.conn)

                da1.Fill(ds1)
                ' asignar el DataSource al combobox  
                cbCotizacion.DataSource = ds1.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                cbCotizacion.DisplayMember = ds1.Tables(0).Columns(0).Caption.ToString
                cbCotizacion.ValueMember = ds1.Tables(0).Columns(0).Caption.ToString

            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub cbCotizacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCotizacion.SelectedIndexChanged
        If cotnueva = 1 Then
            Exit Sub
        End If
        If cbCotizacion.Items.Count > 0 Then
            Dim sql As String = "select t.numdocu, t.responsable, d.codigo, d.cantidad, d.precioventa, p.nombre, p.marca, p.descripcion, p.modelo, p.preciouni " &
                                " from ticket as t join ticketdetalle as d on(t.numdocu = d.numdocu) " &
                                " join producto as p on (d.codigo = p.codigo) " &
                                " where t.numdocu = '" + cbCotizacion.Text + "'"
            Dim ds1 As New DataSet
            Dim da1 As New MySqlDataAdapter(sql, Conexion.conn)

            da1.Fill(ds1)

            DataGridView1.Rows.Clear()

            If ds1.Tables(0).Rows.Count > 0 Then
                ComboBox1.Text = ds1.Tables(0).Rows(0)("responsable").ToString
                Label6.Text = ds1.Tables(0).Rows(0)("numdocu").ToString

                total = 0

                For Each fila As DataRow In ds1.Tables(0).Rows
                    DataGridView1.Rows.Add(fila("codigo"),
                            fila("nombre"),
                            fila("marca"),
                            fila("cantidad"),
                            fila("precioventa"),
                            fila("cantidad") * fila("precioventa"),
                            fila("descripcion"),
                            fila("modelo"),
                            fila("preciouni"),
                            0
                            )
                    total = total + fila("cantidad") * fila("precioventa")
                Next

                'calcula totales
                If total > 0 Then
                    Label8.Text = total.ToString("##,###,##0")
                    If TextBox5.Text <> "" Then
                        Label13.Text = Math.Round(total * CInt(TextBox5.Text) / 100, 0).ToString("##,###,##0")
                    End If
                    Label20.Text = (total - CInt(Label13.Text)).ToString("##,###,##0")
                End If
                NumericUpDown1.Value = 1
                TextBox4.Text = ""
                TextBox4.Focus()

            End If
        End If
    End Sub

    Private Sub btnElimCotizacion_Click(sender As System.Object, e As System.EventArgs) Handles btnElimCotizacion.Click
        If Label6.Text <> "" Then
            Dim sql1 As String = "delete from ticket where numdocu = '" & Label6.Text & "'"
            Dim cmdsel As New MySqlCommand(sql1, Conexion.conn)
            Conexion.open()
            cmdsel.ExecuteNonQuery()
            Conexion.close()
            Me.Close()
            venta.Show()
        End If
    End Sub

    Private Sub btnGrabarCotizacion_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarCotizacion.Click
        If ComboBox1.Text <> "" And Label20.Text <> "" Then
            Button1.Visible = False
            Button4.Visible = False
            GroupBox2.Visible = False

            grabaTicket()

            Me.Close()
            venta.Show()
        Else
            MessageBox.Show("Complete información requerida", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim nbuscador = New b_producto
        nbuscador.Owner = Me
        nbuscador.ShowDialog()
        TextBox4.Focus()
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class