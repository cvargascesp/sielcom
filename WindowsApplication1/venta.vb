Imports MySql.Data.MySqlClient
Public Class venta

    Private Sub venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaDatos()

        Timer1.Enabled = True
        Timer1.Interval = 1000

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n_ticket As New n_ticket
        n_ticket.TextBox1.Text = "TICKET"
        n_ticket.btnBoleta.Visible = True
        n_ticket.Button2.Visible = True
        n_ticket.Button3.Visible = True
        n_ticket.Button1.Visible = False
        n_ticket.Button4.Visible = False
        n_ticket.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            login.Button2.Visible = False
            login.Button5.Enabled = True
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
            Me.Close()
            inicio.Show()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim b_producto As New b_producto
        b_producto.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim n_ticket As New n_ticket
        n_ticket.TextBox1.Text = "COTIZACION"
        n_ticket.btnBoleta.Visible = False
        n_ticket.Button2.Visible = False
        n_ticket.Button3.Visible = False
        n_ticket.Button1.Visible = True
        n_ticket.Button4.Visible = True
        n_ticket.btnGrabarCotizacion.Visible = True
        n_ticket.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'carga grilla
        cargaDatos()

        Try
            'elimina ticket blanco
            Dim sql As String = "DELETE FROM ticket WHERE total=0"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            Conexion.open()
            cm.ExecuteNonQuery()
            Conexion.close()
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try

    End Sub

    Private Sub AcercaDeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem1.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub cargaDatos()
        Try
            Dim sql As String = "select responsable as Vendedor, numdocu as Codigo, total As Total from ticket where estado='TICKET' and total > 0 order by fechadocu desc"
            Dim DsProveedor As New DataSet
            Dim DaProveedor As New MySqlDataAdapter(sql, Conexion.conn)

            DaProveedor.Fill(DsProveedor, "proveedor")

            DataGridView1.DataSource = DsProveedor.Tables("proveedor").DefaultView
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub ModificarContraseñaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ModificarContraseñaToolStripMenuItem.Click
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

    Private Sub NuevoModificarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoModificarToolStripMenuItem.Click
        Dim n_cliente As New n_cliente
        n_cliente.ShowDialog()
    End Sub

    Private Sub VerBuscarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerBuscarToolStripMenuItem.Click
        Dim b_cliente As New b_cliente
        b_cliente.ShowDialog()
    End Sub
End Class