Imports MySql.Data
Imports MySql.Data.MySqlClient

Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class inicio

    Private Sub inicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rellenaGrid()

        Timer1.Enabled = True
        Timer1.Interval = 2000
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cerrar Sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            login.Button5.Enabled = True
            login.MaskedTextBox1.Clear()
            login.TextBox1.Clear()
            login.TextBox2.Clear()
            login.ComboBox1.DataSource = Nothing
            Me.Close()
            login.Show()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        venta.Button6.Visible = True
        venta.Button5.Visible = False
        Me.Close()
        venta.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        caja.Button5.Visible = False
        caja.Button6.Visible = True
        Me.Close()
        caja.Show()
    End Sub

    Private Sub NuevoModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoModificarToolStripMenuItem.Click
        Dim n_usuario As New n_usuario
        n_usuario.Label6.Text = ""
        n_usuario.ShowDialog()
    End Sub

    Private Sub NuevoModificarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoModificarToolStripMenuItem1.Click
        Dim n_proveedor As New n_proveedor
        n_proveedor.ShowDialog()
    End Sub

    Private Sub Nuevo7ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo7ModificarToolStripMenuItem.Click
        Dim n_cliente As New n_cliente
        n_cliente.ShowDialog()
    End Sub

    Private Sub NuevoModificarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoModificarToolStripMenuItem2.Click
        Dim n_producto As New n_producto
        n_producto.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem4.Click
        Dim b_usuario As New b_usuario
        b_usuario.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem1.Click
        Dim b_proveedor As New b_proveedor
        b_proveedor.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem3.Click
        Dim b_producto As New b_producto
        b_producto.ShowDialog()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim n_usuario As New n_usuario
        n_usuario.MaskedTextBox1.Text = login.MaskedTextBox1.Text
        n_usuario.TextBox1.Text = login.TextBox2.Text
        n_usuario.MaskedTextBox1.Enabled = False
        n_usuario.TextBox1.Enabled = False
        n_usuario.TextBox2.Enabled = False
        n_usuario.ComboBox1.Enabled = False
        n_usuario.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem2.Click
        Dim b_cliente As New b_cliente
        b_cliente.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click
        venta.Button6.Visible = True
        venta.Button5.Visible = False
        Me.Close()
        venta.Show()
    End Sub

    Private Sub CajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CajaToolStripMenuItem.Click
        caja.Button5.Visible = False
        caja.Button6.Visible = True
        Me.Close()
        caja.Show()
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        Button5.PerformClick()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        bodega.Button5.Visible = False
        bodega.Button6.Visible = True
        Me.Close()
        bodega.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        empaque.Button6.Visible = True
        empaque.Button5.Visible = False
        Me.Close()
        empaque.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub DíaMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DíaMesToolStripMenuItem.Click
        i_venta.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        rellenaGrid()
    End Sub

    Private Sub ManualDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub rellenaGrid()
        Try
            Dim sql As String = Conexion.strCriticos
            Dim DsProveedor As New DataSet
            Dim DaProveedor As New MySqlDataAdapter(sql, Conexion.conn)

            DaProveedor.Fill(DsProveedor, "producto")

            DataGridView1.DataSource = DsProveedor
            DataGridView1.DataMember = "producto"

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub BodegaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BodegaToolStripMenuItem.Click
        bodega.Button5.Visible = False
        bodega.Button6.Visible = True
        Me.Close()
        bodega.Show()
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        i_stock.ShowDialog()
    End Sub

    Private Sub GananciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GananciasToolStripMenuItem.Click

    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendedoresToolStripMenuItem.Click

    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        Configuraciones.ShowDialog()
    End Sub

    Private Sub PorFamiliaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PorFamiliaToolStripMenuItem.Click

    End Sub

    Private Sub PorArtículoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PorArtículoToolStripMenuItem.Click
        i_ranking.ShowDialog()
    End Sub

    Private Sub DataGridView1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Timer1.Stop()
        DataGridView1.Focus()
    End Sub

    Private Sub DataGridView1_Leave(sender As System.Object, e As System.EventArgs) Handles DataGridView1.Leave
        Timer1.Start()
    End Sub

    Private Sub DataGridView1_Enter(sender As Object, e As System.EventArgs) Handles DataGridView1.Enter
        Timer1.Stop()
    End Sub
End Class