Imports MySql.Data.MySqlClient
Public Class b_cliente
    Dim binds As BindingSource

    Private Sub b_cliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub b_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select rut as Rut, digito as Digito, nombre As Nombre,giro as Giro, contacto as Contacto, direccion as Dirección, telefono1 as Telefono1, telefono2 as Telefono2, fax as Fax, region as Región, provincia as Provincia, comuna as Comuna, mail as Email,creado as CreadoPor,fechac as FechaCreación from cliente order by rut"
        Try
            Dim DsProveedor As New DataSet
            Dim DaProveedor As New MySqlDataAdapter(sql, Conexion.strConn)

            DaProveedor.Fill(DsProveedor, "cliente")
            binds = New BindingSource(DsProveedor, "cliente")

            DataGridView1.DataSource = binds
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.CurrentRow.Selected = True Then
            Dim run As String = CStr(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
            Dim digito As String = CStr(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
            Dim n_cliente As New n_cliente
            n_cliente.MaskedTextBox1.Text = run
            n_cliente.TextBox1.Text = digito
            n_cliente.ShowDialog()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida solo letras
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        'valida texto
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyz.-_@" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        binds.Filter = "rut='" & MaskedTextBox1.Text & "'and digito='" & TextBox1.Text & "'"
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        binds.Filter = "nombre like '%" & TextBox2.Text & "%'"
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        binds.Filter = "giro like '%" & TextBox8.Text & "%'"
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        binds.Filter = "contacto like '%" & TextBox3.Text & "%'"
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        binds.Filter = "dirección like '%" & TextBox4.Text & "%'"
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        binds.Filter = "email like '%" & TextBox7.Text & "%'"
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        If ComboBox1.Items.Count = 0 Then
            Try
                Dim sSql As String = "select region_id, region_ordinal from regiones order by region_id"
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(sSql, Conexion.strConn)

                da.Fill(dt)
                ComboBox1.DataSource = dt
                ComboBox1.DisplayMember = "region_ordinal"
                ComboBox1.ValueMember = "region_id"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        binds.Filter = "región = '" & ComboBox1.Text & "'"
        ComboBox2.DataSource = Nothing
        ComboBox3.DataSource = Nothing
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        If ComboBox2.Items.Count = 0 Then
            Try
                Dim sSql As String = "select provincia_id, provincia_nombre from provincias where region_id = '" & ComboBox1.SelectedValue & "' order by provincia_nombre"
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(sSql, Conexion.strConn)

                da.Fill(dt)

                ComboBox2.DataSource = dt
                ComboBox2.DisplayMember = "provincia_nombre"
                ComboBox2.ValueMember = "provincia_id"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        binds.Filter = "provincia = '" & ComboBox2.Text & "'"
        ComboBox3.DataSource = Nothing
    End Sub

    Private Sub ComboBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.GotFocus
        If ComboBox3.Items.Count = 0 Then
            Try
                Dim sSql As String = "select comuna_nombre from comunas where provincia_id = '" & ComboBox2.SelectedValue & "' order by comuna_nombre"
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(sSql, Conexion.strConn)

                da.Fill(dt)

                ComboBox3.DataSource = dt
                ComboBox3.DisplayMember = "comuna_nombre"
                ComboBox3.ValueMember = "comuna_nombre"
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        binds.Filter = "comuna = '" & ComboBox3.Text & "'"
    End Sub

    Private Sub limpiarFiltros()
        binds.RemoveFilter()
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Or TypeOf c Is MaskedTextBox Then
                c.Text = ""
            ElseIf TypeOf c Is ComboBox Then
                TryCast(c, ComboBox).SelectedIndex = -1
            End If
        Next
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus
        limpiarFiltros()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class