Imports MySql.Data.MySqlClient
Public Class i_libro_pedido
    Private Sub i_libro_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        llenar_combobox_proveedores()
        preparar_datagrid()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (verifica_numoc_prov() = 1) Then
            MessageBox.Show("Numero de orden de compra para ese proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
            Me.fecha_ingreso.Enabled = False
            Me.fecha_tope.Enabled = False
            Me.txtoc_mp.Enabled = False
            Me.comboproveedor.Enabled = False
            cargar_mp_datagrid()
        End If
    End Sub

    Sub formatear_fechas()
        fecha_ingreso.Format = DateTimePickerFormat.Custom
        fecha_ingreso.CustomFormat = "yyyy-MM-dd"
        fecha_tope.Format = DateTimePickerFormat.Custom
        fecha_tope.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub llenar_combobox_proveedores()
        Dim ssql As String = "select * from proveedor"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.comboproveedor.Text
            da.Fill(ds)
            Me.comboproveedor.DataSource = ds.Tables(0)
            Me.comboproveedor.DisplayMember = "nombre"
            Me.comboproveedor.ValueMember = "rut"
            Me.comboproveedor.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub preparar_datagrid()
        Dim col1, col2, col3 As New DataGridViewTextBoxColumn
        Me.KeyPreview = True
        col1.Name = "Producto"
        DataGridView1.Columns.Add(col1)
        col2.Name = "Cantidad"
        DataGridView1.Columns.Add(col2)
        col3.Name = "Unidad de Medida"
        DataGridView1.Columns.Add(col3)
    End Sub

    Function verifica_numoc_prov()
        'verifica que no exista orden de compra asociada al mismo proveedor
        'retorna 1 cuando existe orden de compra asignada a ese proveedor y 0 cuando esta ok
        Conexion.open()
        Dim dataadapter2 As MySqlDataAdapter
        Dim dataset2 As DataSet
        Dim sql2 As String = "SELECT COUNT(*)'repetido' FROM orden_compramp_cabezera WHERE id_ordencompramp='" & Me.txtoc_mp.Text & "' AND rut='" & Me.comboproveedor.SelectedValue & "'"
        dataadapter2 = New MySqlDataAdapter(sql2, Conexion.conn)
        dataset2 = New DataSet()
        dataadapter2.Fill(dataset2)
        Return dataset2.Tables(0).Rows(0).Item(0).ToString()
        Conexion.close()
    End Function

    
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtmateriaprima.LostFocus
        'OPTIMIZAR anda mas paja ke la xuxa
        Conexion.open()
        Dim dataadapter3 As MySqlDataAdapter
        Dim dataset3 As DataSet
        Dim sql3 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.txtmateriaprima.Text & "' OR nombre_mp LIKE'" & Me.txtmateriaprima.Text & "'"
        dataadapter3 = New MySqlDataAdapter(sql3, Conexion.conn)
        dataset3 = New DataSet()
        dataadapter3.Fill(dataset3)
        If (dataset3.Tables(0).Rows.Count <> 0) Then
            Me.txt_unidadmedida.Text = dataset3.Tables(0).Rows(0).Item(4).ToString()
        Else
            Dim opcion As DialogResult = MessageBox.Show("producto no existe... Desea Crearlo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If opcion = Windows.Forms.DialogResult.Yes Then
                agregar_materia_prima.Show()
            End If
        End If
        Conexion.close()
    End Sub


    Sub cargar_mp_datagrid()
        Conexion.open()
        Dim dataadapter4 As MySqlDataAdapter
        Dim dataset4 As DataSet
        Dim sql4 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.txtmateriaprima.Text & "' OR nombre_mp LIKE'" & Me.txtmateriaprima.Text & "'"
        dataadapter4 = New MySqlDataAdapter(sql4, Conexion.conn)
        dataset4 = New DataSet()
        dataadapter4.Fill(dataset4)
        If (dataset4.Tables(0).Rows.Count <> 0) Then
            DataGridView1.Rows.Add(New String() {dataset4.Tables(0).Rows(0).Item(1).ToString(), Me.txtcantmp.Value, dataset4.Tables(0).Rows(0).Item(4).ToString()})
        End If
        Conexion.close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql6 As String
        Conexion.open()
        'se inserta cabezera
        Dim sql5 As String = "INSERT INTO orden_compramp_cabezera VALUES ('" & Me.txtoc_mp.Text & "', '" & Me.comboproveedor.SelectedValue & "', '" & Me.fecha_ingreso.Text & "', '" & Me.fecha_tope.Text & "' )"
        Dim cmd As New MySqlCommand(sql5, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        'se recorre el datagridview para insertar el detalle
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            sql6 = "INSERT INTO orden_compramp_detalle (id_ordencompramp, codigo_mp, cantidad_mp_oc) VALUES ('" & Me.txtoc_mp.Text & "','" & get_mp_sku(Me.txtmateriaprima.Text) & "','" & Me.txtcantmp.Text & "')"
            Dim cmd2 As New MySqlCommand(sql6, Conexion.conn)
            Try
                cmd2.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        Conexion.close()
    End Sub

    Function get_mp_sku(ByVal materiaprima As String)
        'saca el codigo del producto si se pasa el nombre o el codigo
        Dim dataadapter2 As MySqlDataAdapter
        Dim dataset2 As DataSet
        Dim sql2 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & materiaprima & "' OR nombre_mp LIKE'" & materiaprima & "'"
        MessageBox.Show(sql2)
        dataadapter2 = New MySqlDataAdapter(sql2, Conexion.conn)
        dataset2 = New DataSet()
        dataadapter2.Fill(dataset2)
        If (dataset2.Tables(0).Rows.Count <> 0) Then
            Return dataset2.Tables(0).Rows(0).Item(0).ToString()
        Else
            Return 0
        End If

    End Function
End Class