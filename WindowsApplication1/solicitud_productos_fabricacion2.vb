Imports MySql.Data.MySqlClient
Public Class solicitud_productos_fabricacion2
    Sub load_onfields()
        'carga datos del producto a fabricar en los textbox
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT nom_profab,umed_profab,familias.nom_familia FROM producto_fabricado left JOIN familias ON familias.idfamilia=producto_fabricado.id_profab WHERE id_profab='" & Me.TextBox1.Text & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Me.txtnombre.Text = dataset.Tables(0).Rows(0).Item(0).ToString()
            Me.txtunidadmedida.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
            Me.txtfamilia.Text = dataset.Tables(0).Rows(0).Item(2).ToString()
        Else
            Me.txtnombre.Text = ""
            Me.txtunidadmedida.Text = ""
            Me.txtfamilia.Text = ""
        End If
        Conexion.close()
    End Sub
    Function recorrer_datagrid()
        Dim contador As Integer
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If (DataGridView1.Item(4, i).Value.ToString() = "insuficiente") Then
                contador = contador + 1
            End If
        Next
        Return contador
    End Function
    Sub iniciar_datagrid()
        Conexion.open()
        Dim query As String = "SELECT id_profab'Codigo producto',producto_fabricado_materia_prima.codigo_mp'Codigo material',(cant_empleada)'Cant a utilizar',stock_mp'Cantidad disponible',IF(stock_mp < (cant_empleada),'insuficiente','Suficiente')'Disponibilidad' FROM producto_fabricado_materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=producto_fabricado_materia_prima.codigo_mp WHERE id_profab='" & Me.TextBox1.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Private Sub solicitud_productos_fabricacion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Button2.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        load_onfields()
        iniciar_datagrid()
        If (recorrer_datagrid() >= 1) Then
            Me.Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles cantfab.ValueChanged
        Conexion.open()
        Dim query As String = "SELECT id_profab'Codigo producto',producto_fabricado_materia_prima.codigo_mp'Codigo material',(cant_empleada * '" & Me.cantfab.Value & "')'Cant a utilizar',stock_mp'Cantidad disponible',IF(stock_mp < (cant_empleada * '" & Me.cantfab.Value & "'),'insuficiente','Suficiente')'Disponibilidad' FROM producto_fabricado_materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=producto_fabricado_materia_prima.codigo_mp WHERE id_profab='" & Me.TextBox1.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
        If (recorrer_datagrid() >= 1) Then
            Me.Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
        End If
    End Sub
End Class