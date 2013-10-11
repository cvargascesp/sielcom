Imports MySql.Data.MySqlClient
Public Class i_familias

    Private Sub i_familias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_datagridview()
    End Sub



    Sub agregar_familia()
        Dim sqlquery As String = "insert into familias (nom_familia) values('" & Me.txtnomfamilia.Text & "')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            Conexion.open()
            cmd.ExecuteNonQuery()
            Conexion.close()
            MessageBox.Show("Familia Guardada con exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            llenar_datagridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.txtnomfamilia.Text <> "") Then
            agregar_familia()
       Else
            MessageBox.Show("el nombre de la familia no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub llenar_datagridview()
        Conexion.open()
        Dim query As String = "SELECT idfamilia 'ID Familia', nom_familia 'Nombre Familia' FROM familias"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class