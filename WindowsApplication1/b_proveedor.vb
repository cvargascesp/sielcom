Imports MySql.Data.MySqlClient
Public Class b_proveedor
    Dim binds As New BindingSource
    Private Sub b_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub b_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select rut as Rut, digito as Digito, nombre As Nombre, contacto as Contacto, direccion as Direccion, telefono1 as Telefono1, telefono2 as Telefono2, fax as Fax, region as Region, provincia as Provincia, comuna as Comuna, mail as Email, creado as CreadoPor, fechac as 'Fecha Creacion' from proveedor order by nombre"
        Dim Ds As New DataSet
        Dim Da As New MySqlDataAdapter(sql, Conexion.strConn)

        Da.Fill(Ds, "proveedor")

        binds = New BindingSource(Ds, "proveedor")
        DataGridView1.DataSource = binds

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus
        limpiarFlitros()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        binds.RemoveFilter()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        binds.Filter = "rut = '" & MaskedTextBox1.Text & "' and digito = '" & TextBox1.Text & "'"
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        limpiarFlitros()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        binds.Filter = "nombre like '%" & TextBox2.Text & "%'"
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        limpiarFlitros()
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida solo letras
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        binds.Filter = "contacto like '%" & TextBox3.Text & "%'"
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        limpiarFlitros()
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        binds.Filter = "direccion like '%" & TextBox4.Text & "%'"
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        limpiarFlitros()
        If ComboBox3.Items.Count = 0 Then
            'carca cb regiones
            Try
                Dim da2 As MySqlDataAdapter
                Dim ds2 As New DataSet
                Dim sql2 As String = "SELECT region_ordinal FROM regiones order by region_ordinal"

                da2 = New MySqlDataAdapter(sql2, Conexion.strConn)
                da2.Fill(ds2)
                ' asignar el DataSource al combobox  
                ComboBox1.DataSource = ds2.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox1.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString
            Catch ex As MySqlException
                MessageBox.Show("No se ha podido conectar al servidor")
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> 0 Then
            binds.Filter = "region = '" & ComboBox1.Text & "'"
        End If
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        limpiarFlitros()
        If ComboBox2.Items.Count = 0 Then
            'carga cb provincias
            Try
                Dim da2 As MySqlDataAdapter
                Dim ds2 As New DataSet
                Dim sql2 As String = "SELECT provincia_nombre FROM provincias order by provincia_nombre"

                da2 = New MySqlDataAdapter(sql2, Conexion.strConn)
                da2.Fill(ds2)
                'asignar el DataSource al combobox  
                ComboBox2.DataSource = ds2.Tables(0)

                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox2.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString
            Catch ex As MySqlException
                MessageBox.Show("No se ha podido conectar al servidor")
            End Try
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> 0 Then
            binds.Filter = "provincia = '" & ComboBox2.Text & "'"
        End If
    End Sub

    Private Sub ComboBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.GotFocus
        limpiarFlitros()
        If ComboBox3.Items.Count = 0 Then
            'carga cb comunas
            Try
                Dim da2 As MySqlDataAdapter
                Dim ds2 As New DataSet
                Dim sql2 As String = "select comuna_nombre from comunas order by comuna_nombre"

                da2 = New MySqlDataAdapter(sql2, Conexion.strConn)
                da2.Fill(ds2)
                'asignar el DataSource al combobox  
                ComboBox3.DataSource = ds2.Tables(0)
                ' Asignar el campo a la propiedad DisplayMember del combo   
                ComboBox3.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString
            Catch ex As MySqlException
                MessageBox.Show("No se ha podido conectar al servidor")
            End Try
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex <> 0 Then
            binds.Filter = "comuna = '" & ComboBox3.Text & "'"
        End If
    End Sub

    Private Sub TextBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        limpiarFlitros()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.CurrentRow.Selected = True Then
            Dim run As String = CStr(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
            Dim digito As String = CStr(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
            Dim n_proveedor As New n_proveedor
            n_proveedor.MaskedTextBox1.Text = run
            n_proveedor.TextBox1.Text = digito
            n_proveedor.ShowDialog()
        End If
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

    Private Sub TextBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        binds.Filter = "email like '%" & TextBox7.Text & "%'"
    End Sub

    Private Sub limpiarFlitros()
        MaskedTextBox1.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        binds.RemoveFilter()
    End Sub

End Class