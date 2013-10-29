Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class bodega_compraventa

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n_producto As New n_producto
        n_producto.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim b_producto As New b_producto
        b_producto.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim n_proveedor As New n_proveedor
        n_proveedor.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim b_proveedor As New b_proveedor
        b_proveedor.ShowDialog()
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

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub bodega_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rellenaGrid()
        Timer1.Enabled = True
        Timer1.Interval = 2000
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        rellenaGrid()
    End Sub

    Private Sub rellenaGrid()
        Try
            Dim sql As String = Conexion.strCriticos
            Dim DsProveedor As New DataSet
            Dim DaProveedor As New MySqlDataAdapter(sql, Conexion.conn)

            DaProveedor.Fill(DsProveedor, "producto")
            With Me.DataGridView1
                .DataSource = DsProveedor.Tables("producto").DefaultView
            End With

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Enter(sender As Object, e As System.EventArgs) Handles DataGridView1.Enter
        Timer1.Stop()
    End Sub

    Private Sub DataGridView1_LostFocus(sender As Object, e As System.EventArgs) Handles DataGridView1.LostFocus
        Timer1.Start()
    End Sub

    Private Sub DataGridView1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Timer1.Stop()
        DataGridView1.Focus()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class