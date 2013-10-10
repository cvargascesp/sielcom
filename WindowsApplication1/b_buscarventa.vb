Imports MySql.Data.MySqlClient

Public Class b_buscarventa
    Dim bind As BindingSource

    Private Sub b_buscarventa_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub b_buscarventa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select * from boleta"
        Dim ds As New DataSet

        Dim da As New MySqlDataAdapter(sql, Conexion.conn)

        Conexion.open()
        da.Fill(ds, "boleta")
        bind = New BindingSource(ds, "boleta")

        DataGridView1.DataSource = bind
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiaFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiaFiltro.Click
        txtDocumento.Text = ""
        cbTipoDocumento.SelectedIndex = -1
        cbFormaPago.SelectedIndex = -1
        cbCliente.Text = ""
        cbVendedor.Text = ""
        txtTotal.Text = ""
        dtFecha.Text = ""
        dtFechaHasta.Text = ""
        bind.RemoveFilter()
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        Dim y As String
        bind.RemoveFilter()

        If cbTipoDocumento.Text <> "" Then
            bind.Filter = "tipodocu = '" & cbTipoDocumento.Text & "'"
        End If

        If txtDocumento.Text <> "" Then
            y = ""
            If bind.Filter <> "" Then
                y = " and "
            End If
            bind.Filter += y + "numdocu = " & txtDocumento.Text
        End If

        If cbCliente.Text <> "" Then
            y = ""
            If bind.Filter <> "" Then
                y = " and "
            End If
            bind.Filter += y + "cliente = '" & cbCliente.Text & "'"
        End If

        If txtTotal.Text <> "" Then
            y = ""
            If bind.Filter <> "" Then
                y = " and "
            End If
            bind.Filter += y + "total = " & txtTotal.Text
        End If

        If cbVendedor.Text <> "" Then
            y = ""
            If bind.Filter <> "" Then
                y = " and "
            End If
            bind.Filter += y + "vendedor = '" & cbVendedor.Text & "'"
        End If

        If dtFecha.Text <> "" And dtFechaHasta.Text <> "" Then
            y = ""
            If bind.Filter <> "" Then
                y = " and "
            End If
            bind.Filter += y + "fechadocu >= '" & dtFecha.Text & "' and fechadocu <= '" & dtFechaHasta.Text & "'"
        End If
    End Sub

    Private Sub AnularTransacciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AnularTransacciónToolStripMenuItem.Click
        Dim codigo As String
        Dim cant As Integer

        Dim resp As DialogResult = MessageBox.Show("Está seguro de anular los registros marcados?", "Anular Transacciones", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If resp = Windows.Forms.DialogResult.Yes Then

            Dim datarows As DataGridViewSelectedRowCollection = DataGridView1.SelectedRows()
            Dim ids As List(Of String) = New List(Of String)

            For Each row As DataGridViewRow In datarows
                If row.Cells("numdocu").Value > 0 Then
                    ids.Add(row.Cells("numdocu").Value)
                End If
            Next
            If ids.ToArray.Length > 0 Then
                Dim ssql As String = "delete from agenda where id in (@ids)"
                ssql = ssql.Replace("@ids", String.Join(",", ids.ToArray()))

                'Anular transacción
                Conexion.open()
                Dim trx As MySqlTransaction = Conexion.conn.BeginTransaction

                Try
                    'verifica si existe boleta
                    Dim ds As New DataSet
                    Dim sql As String = "SELECT b.numdocu, b.numticket, t.codigo, t.cantidad FROM boleta b join ticketdetalle t on (b.numticket=t.numdocu) WHERE b.estado = 'EMITIDA' and b.numdocu in (@ids)"
                    sql = sql.Replace("@ids", String.Join(",", ids.ToArray()))
                    Dim da As New MySqlDataAdapter(sql, Conexion.conn)
                    da.Fill(ds, "trxs")
                    If ds.Tables("trxs").Rows.Count = 0 Then
                        MessageBox.Show("No se seleccionaron transacciones en la BD", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        trx.Rollback()
                    Else
                        'anula las trxs
                        Dim sqlboleta As String = "UPDATE boleta set estado = 'ANULADA' where numdocu in (@ids)"
                        sqlboleta = sqlboleta.Replace("@ids", String.Join(",", ids.ToArray()))
                        Dim cm3 As New MySqlCommand(sqlboleta, Conexion.conn)
                        cm3.ExecuteNonQuery()

                        For Each row As DataRow In ds.Tables("trxs").Rows()
                            codigo = row("codigo").ToString
                            cant = row("cantidad").ToString

                            Dim sqlprod As String = "select stock from producto where codigo = '" & codigo & "' for update"
                            Dim cmdprod As New MySqlCommand(sqlprod, Conexion.conn)

                            Dim rd As MySqlDataReader = cmdprod.ExecuteReader()

                            If rd.Read() Then
                                Dim stock As Integer = rd.GetInt32("stock")

                                rd.Close()

                                Dim sqlprodupd As String = "UPDATE producto SET stock = @stock where codigo = @codigo"
                                Dim cmdprodupd As New MySqlCommand(sqlprodupd, Conexion.conn)
                                If cant > 0 Then
                                    stock = stock + cant
                                Else
                                    stock = stock - cant
                                End If
                                cmdprodupd.Parameters.AddWithValue("@stock", stock)
                                cmdprodupd.Parameters.AddWithValue("@codigo", codigo)
                                cmdprodupd.ExecuteNonQuery()
                            End If
                        Next

                        trx.Commit()

                        MessageBox.Show("Registros anulados")
                        For Each fila As DataGridViewRow In datarows
                            fila.Cells("estado").Value = "ANULADA"
                            'fila.DefaultCellStyle.BackColor = Color.Salmon
                        Next
                    End If

                Catch err As MySqlException
                    trx.Rollback()
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
                Conexion.close()

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Rows(e.RowIndex).Cells("estado").Value = "ANULADA" Then
            e.CellStyle.BackColor = Color.Salmon
        End If
    End Sub


    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            With DataGridView1
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class