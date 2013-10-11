Imports MySql.Data.MySqlClient
Public Class i_unidadmedida

    Private Sub i_unidadmedida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_datagridview()
    End Sub

    Sub agregar_um()
        Dim sqlquery As String = "insert into unidades_medida (nomum) values('" & Me.txtnomum.Text & "')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            Conexion.open()
            cmd.ExecuteNonQuery()
            Conexion.close()
            MessageBox.Show("Unidad de medida guardada con exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            llenar_datagridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.txtnomum.Text <> "") Then
            agregar_um()
        Else
            MessageBox.Show("el nombre de la unidad de medida no puede quedar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Sub llenar_datagridview()
        Conexion.open()
        Dim query As String = "SELECT nomum 'unidades de medidas' FROM unidades_medida"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "nomum")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
End Class