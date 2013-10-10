Imports MySql.Data.MySqlClient
Public Class agregar_materia_prima

    Private Sub agregar_materia_prima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combobox_familias()
    End Sub

    Sub llenar_combobox_familias()
        Dim ssql As String = "select * from familias"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = combofamilia.Text
            da.Fill(ds)

            combofamilia.DataSource = ds.Tables(0)
            combofamilia.DisplayMember = "nom_familia"
            combofamilia.ValueMember = "idfamilia"
            combofamilia.SelectedValue = actual
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub combofamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combofamilia.SelectedIndexChanged

    End Sub
End Class