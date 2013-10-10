Public Class caja
    Dim c As Integer

    Private Sub caja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub
    Private Sub caja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            login.Button2.Visible = False
            login.Button5.Enabled = True
            login.ComboBox1.SelectedIndex = 0
            login.ComboBox1.Enabled = True
            login.MaskedTextBox1.Clear()
            login.TextBox1.Clear()
            login.TextBox2.Clear()
            login.ComboBox1.DataSource = Nothing
            login.Show()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            inicio.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim n_factura As New n_factura
        n_factura.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim n_boleta As New n_boleta
        n_boleta.Show()
        Me.Hide()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        Dim n_usuario As New n_usuario
        n_usuario.MaskedTextBox1.Text = login.MaskedTextBox1.Text
        n_usuario.TextBox1.Text = login.TextBox2.Text
        n_usuario.MaskedTextBox1.Enabled = False
        n_usuario.TextBox1.Enabled = False
        n_usuario.TextBox2.Enabled = False
        n_usuario.ComboBox1.Enabled = False
        n_usuario.Button3.Visible = False
        n_usuario.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem.Click
        Dim b_cliente As New b_cliente
        b_cliente.ShowDialog()
    End Sub

    Private Sub NuevoModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoModificarToolStripMenuItem.Click
        Dim n_cliente As New n_cliente
        n_cliente.ShowDialog()
    End Sub

    Private Sub btnBuscarVenta_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarVenta.Click
        b_buscarventa.ShowDialog()
    End Sub

    Private Sub VentaXFechaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VentaXFechaToolStripMenuItem.Click
        i_venta.ShowDialog()
    End Sub
End Class