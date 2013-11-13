Imports MySql.Data.MySqlClient

Public Class i_productofabricado
   Sub llenar_combobox_unidadmedida()
        Dim ssql As String = "SELECT nomum FROM unidades_medida"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = combofamilia.Text
            da.Fill(ds)
            Me.comboum.DataSource = ds.Tables(0)
            Me.comboum.DisplayMember = "nomum"
            Me.comboum.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub llenar_combobox_familia()
        Dim ssql As String = "select * from familias"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.combofamilia.Text
            da.Fill(ds)
            Me.combofamilia.DataSource = ds.Tables(0)
            Me.combofamilia.DisplayMember = "nom_familia"
            Me.combofamilia.ValueMember = "idfamilia"
            Me.combofamilia.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub llenar_datagridview()
        Conexion.open()
        Dim query As String = "SELECT id_profab'Codigo',nom_profab'Nombre Producto', umed_profab'Unidad de medida', familias.nom_familia'familia' FROM producto_fabricado INNER JOIN familias ON familias.idfamilia=producto_fabricado.idfamila"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Sub agregar_producto_fabricado(ByVal codigo As Integer, ByVal nombre_profab As String, ByVal umed As String, ByVal familia As Integer)
        Conexion.open()
        Dim sqlquery As String = "INSERT INTO producto_fabricado VALUES ('" & codigo & "','" & nombre_profab & "','" & umed & "', '" & familia & "')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("producto a fabricar guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            llenar_datagridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub

    Private Sub i_productofabricado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combobox_familia()
        llenar_combobox_unidadmedida()
        llenar_datagridview()
    End Sub
    Function verificar_codigo_existente(ByVal codigo As Integer)
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT COUNT(id_profab) FROM producto_fabricado WHERE id_profab='" & codigo & "' UNION ALL (SELECT COUNT(codigo) FROM producto WHERE codigo='" & codigo & "')"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Dim mp As Integer = dataset.Tables(0).Rows(0).Item(0).ToString()
            Dim producto As Integer = dataset.Tables(0).Rows(1).Item(0).ToString()
            If (mp >= 1 Or producto >= 1) Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
            Conexion.close()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (verificar_codigo_existente(Me.txtcodigo.Text) = True) Then
            agregar_producto_fabricado(Me.txtcodigo.Text, Me.txtnombre.Text, Me.comboum.Text, Me.combofamilia.SelectedValue)
        Else
            MessageBox.Show("Ese codigo ya existe en algun producto", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class