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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        agregar_producto_fabricado(Me.txtcodigo.Text, Me.txtnombre.Text, Me.comboum.Text, Me.combofamilia.SelectedValue)
    End Sub
End Class