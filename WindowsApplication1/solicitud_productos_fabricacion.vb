Imports MySql.Data.MySqlClient
Public Class solicitud_productos_fabricacion
    Private Sub solicitud_productos_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        preparar_datagrid()
        Me.comentamotivo.Enabled = False
    End Sub
    Sub formatear_fechas()
        fecha_solicitud.Format = DateTimePickerFormat.Custom
        fecha_solicitud.CustomFormat = "yyyy-MM-dd"
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
    Sub cargar_mp_datagrid()
        Conexion.open()
        Dim dataadapter4 As MySqlDataAdapter
        Dim dataset4 As DataSet
        Dim sql4 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.producto.Text & "' OR nombre_mp LIKE'" & Me.producto.Text & "'"
        dataadapter4 = New MySqlDataAdapter(sql4, Conexion.conn)
        dataset4 = New DataSet()
        dataadapter4.Fill(dataset4)
        If (dataset4.Tables(0).Rows.Count <> 0) Then
            DataGridView1.Rows.Add(New String() {dataset4.Tables(0).Rows(0).Item(1).ToString(), Me.cantidad.Value, dataset4.Tables(0).Rows(0).Item(4).ToString()})
        End If
        Conexion.close()
    End Sub

    Private Sub producto_LostFocus(sender As Object, e As EventArgs) Handles producto.LostFocus
        If Me.producto.Text <> "" Then
            Conexion.open()
            Dim dataadapter3 As MySqlDataAdapter
            Dim dataset3 As DataSet
            Dim sql3 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.producto.Text & "' OR nombre_mp LIKE'" & Me.producto.Text & "'"
            dataadapter3 = New MySqlDataAdapter(sql3, Conexion.conn)
            dataset3 = New DataSet()
            dataadapter3.Fill(dataset3)
            If (dataset3.Tables(0).Rows.Count <> 0) Then
                Me.umedida.Text = dataset3.Tables(0).Rows(0).Item(4).ToString()
            Else
                Dim opcion As DialogResult = MessageBox.Show("El producto Ingresado no es Valido", "Error")
                Me.producto.Text = ""
                Me.producto.Focus()


            End If

            Conexion.close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_mp_datagrid()
        Me.producto.Text = ""
        Me.cantidad.Text = " 0 "
        Me.umedida.Text = ""
        Me.producto.Focus()
    End Sub

    Private Sub motivo_LostFocus(sender As Object, e As EventArgs) Handles motivo.LostFocus
        If Me.motivo.Text <> "" And Me.motivo.Text = "Otro" Then
            Me.comentamotivo.Enabled = True
            Me.comentamotivo.Focus()
        End If
    End Sub

    
End Class