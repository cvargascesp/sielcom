Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Public Class n_recibestock

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'grabar facturacompra
        Dim ssql As String = "insert into facturacompra (factura,proveedor,codigo,cantidad,preciouni,precioventa,totalcompra,estado,fechaingreso,creado)" &
                            " values(@factura,@proveedor,@codigo,@cantidad,@unitario,@venta,@total,@estado,@fecha,@creador)"
        Dim cmd As New MySqlCommand(ssql, Conexion.conn)
        cmd.Parameters.AddWithValue("@factura", txtFactura.Text)
        cmd.Parameters.AddWithValue("@proveedor", cbProveedor.Text)
        cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text)
        cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text)
        cmd.Parameters.AddWithValue("@unitario", txtPreciouni.Text)
        cmd.Parameters.AddWithValue("@venta", txtPrecioventa.Text)
        cmd.Parameters.AddWithValue("@total", txtTotalcompra.Text)
        cmd.Parameters.AddWithValue("@estado", "ACTIVO")
        cmd.Parameters.AddWithValue("@fecha", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        cmd.Parameters.AddWithValue("@creador", login.lblUsuario.Text)

        Dim ssql2 As String = "update producto set stock = stock + @stock, porllegar = @llegar, fechapedido = NULL, preciouni = @unitario, margen = @margen, precioventa = @venta, utilidaduni = @utilidad, estado = 'COMPRADO' where codigo = @codigo"
        Dim cmd2 As New MySqlCommand(ssql2, Conexion.conn)

        cmd2.Parameters.AddWithValue("@stock", txtCantidad.Text)
        cmd2.Parameters.AddWithValue("@llegar", 0)
        cmd2.Parameters.AddWithValue("@codigo", txtCodigo.Text)
        cmd2.Parameters.AddWithValue("@unitario", txtPreciouni.Text)
        cmd2.Parameters.AddWithValue("@margen", txtMargen.Text.Replace(",", "."))
        cmd2.Parameters.AddWithValue("@venta", txtPrecioventa.Text)
        cmd2.Parameters.AddWithValue("@utilidad", CInt(txtPrecioventa.Text) - CInt(txtPreciouni.Text))

        Dim trans As MySqlTransaction
        Conexion.open()
        trans = Conexion.conn.BeginTransaction()
        Try
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            trans.Commit()
            Conexion.close()

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub n_recibestock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub n_recibestock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCantidad.Text = ""
        txtPreciouni.Text = ""
        txtTotalcompra.Text = ""
        'carga combobox con proveedores
        Dim ssql As String = "select nombre from proveedor order by nombre"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = cbProveedor.Text
            da.Fill(ds)

            cbProveedor.DataSource = ds.Tables(0)
            cbProveedor.DisplayMember = "nombre"
            cbProveedor.ValueMember = "nombre"
            cbProveedor.SelectedValue = actual
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.ActiveControl = txtFactura
    End Sub

    Private Sub txtfactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactura.KeyPress
        '  e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cbProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbProveedor.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        'valida numeros y letras
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPreciouni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPreciouni.KeyPress
        'valida numeros y letras
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPrecioventa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioventa.KeyPress
        'valida numeros y letras
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        'calcula total compra
        txtTotalcompra.Text = CInt(IIf(txtPreciouni.Text <> "", txtPreciouni.Text, "0")) * CInt(IIf(txtCantidad.Text <> "", txtCantidad.Text, "0"))
    End Sub

    Private Sub txtPreciouni_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPreciouni.TextChanged
        'calcula total compra
        txtTotalcompra.Text = CInt(IIf(txtPreciouni.Text <> "", txtPreciouni.Text, "0")) * CInt(IIf(txtCantidad.Text <> "", txtCantidad.Text, "0"))
    End Sub

    Private Sub txtMargen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMargen.KeyPress
        'valida numeros y letras
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btnRecalculaVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalculaVenta.Click
        Dim porc As Integer
        If txtMargen.Text <> "" And txtPreciouni.Text <> "" Then
            porc = ((CInt(txtPreciouni.Text) * CInt(txtMargen.Text)) / 100) + CInt(txtPreciouni.Text)
            porc = (CInt(porc) * n_producto.iva) + porc
            txtPrecioventa.Text = porc
        End If
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged

    End Sub
End Class
