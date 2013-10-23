Imports MySql.Data.MySqlClient
Public Class e_materia_prima
    Sub llenar_combobox_unidadmedida()
        Dim ssql As String = "SELECT * FROM unidades_medida"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.unidadmedida_mp.Text
            da.Fill(ds)
            unidadmedida_mp.DataSource = ds.Tables(0)
            unidadmedida_mp.DisplayMember = "nomum"

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub llenar_combobox_familias()
        Dim ssql1 As String = "SELECT * FROM familias"
        Dim ds1 As New DataSet
        Dim da1 As New MySqlDataAdapter(ssql1, Conexion.conn)
        Try
            Dim actual As String = Me.combofamilia.Text
            da1.Fill(ds1)
            Me.combofamilia.DataSource = ds1.Tables(0)
            Me.combofamilia.DisplayMember = "nom_familia"
            Me.combofamilia.ValueMember = "idfamilia"
            Me.combofamilia.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub e_materia_prima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txt_nom_mp.Enabled = False
        Me.combofamilia.Enabled = False
        Me.unidadmedida_mp.Enabled = False
        Me.txt_ubicacion_mp.Enabled = False
        Me.txtstockcrit.Enabled = False

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bodega_materias_primas_principal.Show()
    End Sub

  



    Private Sub txtcodigo_mp_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo_mp.LostFocus
        Me.txt_nom_mp.Enabled = True
        Me.combofamilia.Enabled = True
        Me.unidadmedida_mp.Enabled = True
        Me.txt_ubicacion_mp.Enabled = True
        Me.txtstockcrit.Enabled = True
        llenar_combobox_unidadmedida()
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT * FROM materia_prima INNER JOIN familias ON familias.idfamilia=materia_prima.idfamilia WHERE codigo_mp='" & Me.txtcodigo_mp.Text & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        Me.unidadmedida_mp.Text = ""
        If (dataset.Tables(0).Rows.Count <> 0) Then
            llenar_combobox_familias()
            combofamilia.Text = ""
            Me.txt_nom_mp.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
            Me.combofamilia.SelectedValue = CInt(dataset.Tables(0).Rows(0).Item(7).ToString())
            'Me.combofamilia.SelectedText = CStr(dataset.Tables(0).Rows(0).Item(8).ToString())
            Me.unidadmedida_mp.SelectedText = dataset.Tables(0).Rows(0).Item(4).ToString()
            Me.txt_ubicacion_mp.Text = dataset.Tables(0).Rows(0).Item(3).ToString()
            Me.txtstockcrit.Value = CInt(dataset.Tables(0).Rows(0).Item(6).ToString())

        Else
            MessageBox.Show("el codigo de materia prima es invalido", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        Conexion.close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.open()
        Dim sql_update As String = " UPDATE materia_prima SET nombre_mp= '" & Me.txt_nom_mp.Text & "',idfamilia= '" & Me.combofamilia.SelectedValue & "',unidad_medida_mp= '" & Me.unidadmedida_mp.Text & "',ubicacion_mp= '" & Me.txt_ubicacion_mp.Text & "', stock_critico_mp='" & Me.txtstockcrit.Value & "' WHERE codigo_mp='" & Me.txtcodigo_mp.Text & "'"
        Dim cmd As New MySqlCommand(sql_update, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Datos modificados exitosamente", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
        Me.txt_nom_mp.Text = ""
        Me.combofamilia.Text = ""
        Me.unidadmedida_mp.Text = ""
        Me.txt_ubicacion_mp.Text = ""
        Me.txtcodigo_mp.Text = ""
        Me.txtstockcrit.Value = 0
    End Sub

End Class