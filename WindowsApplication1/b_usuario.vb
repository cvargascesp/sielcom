Imports MySql.Data.MySqlClient
Public Class b_usuario
    Dim binds As BindingSource

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            binds.Filter = "run='" & MaskedTextBox1.Text & "' and digito='" & TextBox1.Text & "'"
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        MaskedTextBox1.Clear()
        TextBox1.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        binds.RemoveFilter()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo letras
        If InStr(1, "abcdefghuiklmnñopqrstuvwxyz " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text <> "" Then
            binds.Filter = "nombres like '%" & TextBox2.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        MaskedTextBox1.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox2.SelectedIndex = 0
        binds.RemoveFilter()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> 0 Then
            binds.Filter = "cuenta= '" & ComboBox1.Text & "'"
        End If
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        MaskedTextBox1.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = 0
        binds.RemoveFilter()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> 0 Then
            binds.Filter = "permiso= '" & ComboBox2.Text & "'"
        End If
    End Sub

    Private Sub b_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        Try
            Dim sql As String = "select run as Run, digito as Digito, nombre As Nombres, cuenta as Cuenta, permiso as Permiso,creado as CreadoPor,fechac as FechaCreación from usuario order by nombre"
            Dim DsCliente As New DataSet
            Dim DaCliente As New MySqlDataAdapter(sql, Conexion.conn)

            DaCliente.Fill(DsCliente, "usuario")
            binds = New BindingSource(DsCliente, "usuario")

            DataGridView1.DataSource = binds
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        binds.RemoveFilter()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.CurrentRow.Selected = True Then
            Dim run As String = CStr(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
            Dim digito As String = CStr(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
            Dim n_usuario As New n_usuario
            n_usuario.MaskedTextBox1.Text = run
            n_usuario.TextBox1.Text = digito
            Me.Hide()
            n_usuario.ShowDialog()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class