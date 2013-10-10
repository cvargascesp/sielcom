Imports MySql.Data.MySqlClient

Public Class b_producto
    Dim binds As BindingSource

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub b_producto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox2.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySQLDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT nombre FROM producto group by nombre order by nombre"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox2.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox2.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox4.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT marca FROM producto group by marca order by marca"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox4.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox4.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox5.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT modelo FROM producto group by modelo order by modelo"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox5.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox5.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox6.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT categoria FROM producto group by categoria order by categoria"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox6.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox6.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox7.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT proveedor FROM producto group by proveedor order by proveedor"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox7.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox7.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox8.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox8.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT estado FROM producto group by estado order by estado"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox8.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox8.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox9.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox9.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT creado FROM producto group by creado order by creado"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox9.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox9.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        'TextBox1.Clear()
        'ComboBox2.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'cbLinea.Text = ""
        'binds.RemoveFilter()

        If ComboBox1.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT codigoint FROM producto group by codigoint order by codigoint"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            ComboBox1.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox1.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox2.Clear()
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        cbLinea.Text = ""
        binds.RemoveFilter()

    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox1.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        ComboBox9.Text = ""
        cbLinea.Text = ""
        binds.RemoveFilter()

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox5.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox6.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, " ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox7.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox8.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, " ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox9.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, " ABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text <> "" Then
            binds.Filter = "código like'%" & TextBox1.Text & "%'"
        End If
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text <> "" Then
            binds.Filter = "descripción like'%" & TextBox2.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.LostFocus
        If ComboBox1.Text <> "" Then
            binds.Filter = "interno like'%" & ComboBox1.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.LostFocus
        If ComboBox2.Text <> "" Then
            binds.Filter = "nombre like'%" & ComboBox2.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.LostFocus
        If ComboBox4.Text <> "" Then
            binds.Filter = "marca like'%" & ComboBox4.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.LostFocus
        If ComboBox5.Text <> "" Then
            binds.Filter = "modelo like'%" & ComboBox5.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.LostFocus
        If ComboBox6.Text <> "" Then
            binds.Filter = "categoria like'%" & ComboBox6.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox7.LostFocus
        If ComboBox7.Text <> "" Then
            binds.Filter = "proveedor like'%" & ComboBox7.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox8.LostFocus
        If ComboBox8.Text <> "" Then
            binds.Filter = "estado like'%" & ComboBox8.Text & "%'"
        End If
    End Sub

    Private Sub ComboBox9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox9.LostFocus
        If ComboBox9.Text <> "" Then
            binds.Filter = "creado like'%" & ComboBox9.Text & "%'"
        End If
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Text <> "" Then
            binds.Filter = "fecha ='" & CDate(DateTimePicker1.Text).ToString("yyyy-MM-dd") & "'"
        End If
    End Sub

    Private Sub b_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "select codigo as Código,codigoint as Interno,stock as Stock,critico as Critico,nombre as Nombre, precioventa as Precio,descripcion as Descripción,marca as Marca, modelo as Modelo, linea as Linea, categoria as Categoria, ubicacion as Ubicación, proveedor as Proveedor, cast(fechaingreso as date) as Fecha, estado as Estado, creado as Creado from producto"
        Try
            Dim DsProveedor As New DataSet
            Dim DaProveedor As New MySqlDataAdapter(sql, Conexion.conn)

            DaProveedor.Fill(DsProveedor, "producto")
            binds = New BindingSource(DsProveedor, "producto")

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

    Private Sub cbLinea_GotFocus(sender As Object, e As System.EventArgs) Handles cbLinea.GotFocus
        'TextBox1.Clear()
        'ComboBox1.Text = ""
        'TextBox2.Clear()
        'ComboBox4.Text = ""
        'ComboBox5.Text = ""
        'ComboBox6.Text = ""
        'ComboBox7.Text = ""
        'ComboBox8.Text = ""
        'ComboBox9.Text = ""
        'binds.RemoveFilter()

        If cbLinea.Items.Count = Nothing Then
            'carga datos para actualizar
            Dim sql2 As String
            Dim da As MySqlDataAdapter
            Dim ds As New DataSet

            sql2 = "SELECT distinct linea FROM producto group by linea order by linea"
            da = New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds)

            ' asignar el DataSource al combobox  
            cbLinea.DataSource = ds.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            cbLinea.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
        End If
    End Sub

    Private Sub cbLinea_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbLinea.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        'valida numeros y letras
        If InStr(1, "0123456789 ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub cbLinea_TextChanged(sender As Object, e As System.EventArgs) Handles cbLinea.LostFocus
        If cbLinea.Text <> "" Then
            binds.Filter = "linea like'%" & cbLinea.Text & "%'"
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim codigo
        Dim form1 As n_ticket = Me.Owner
        codigo = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        form1.TextBox4.Text = codigo
        Me.Hide()
    End Sub
End Class