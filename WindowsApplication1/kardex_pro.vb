Imports MySql.Data.MySqlClient
Public Class kardex_pro
    Public Sub agregar_kardexpro(ByVal codigopro As String, ByVal cantpro_entrante As Integer)
        Conexion.open()
        Dim sqlquery As String = "INSERT INTO kardexpro(fecha_karpro,codigo_pro,usr_karpro,entra_karpro,sale_karpro,saldo_karpro,coment_karpro) VALUES ('curdate()','" & codigopro & "','" & login.MaskedTextBox1.Text & "', '" & cantpro_entrante & "','0','" & get_saldopro(codigopro) + cantpro_entrante & "','')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message + " Agregar_kardexpro()")
        End Try
        Conexion.close()
    End Sub

    Public Function get_saldopro(ByVal codigopro As String)
        Conexion.open()
        Dim dataadapter3 As MySqlDataAdapter
        Dim dataset3 As DataSet
        Dim sql3 As String = "SELECT saldo_karpro FROM kardexpro WHERE codigo_pro='" & codigopro & "' ORDER BY id_karpro DESC LIMIT 1 "
        dataadapter3 = New MySqlDataAdapter(sql3, Conexion.conn)
        dataset3 = New DataSet()
        dataadapter3.Fill(dataset3)
        If (dataset3.Tables(0).Rows.Count <> 0) Then
            Return (dataset3.Tables(0).Rows(0).Item(0).ToString())
        Else
            Return 0
        End If
        Conexion.close()
    End Function
    Public Sub inic_kardex_pro(ByVal codigo_pro As String)
        Conexion.open()
        Dim query_inic As String = "INSERT INTO kardexpro(fecha_karpro,codigo_pro,usr_karpro,entra_karpro,sale_karpro,saldo_karpro,coment_karpro) VALUES ('curdate()','" & codigo_pro & "','" & login.MaskedTextBox1.Text & "', '0','0','0','inic')"
        Dim cmd2 As New MySqlCommand(query_inic, Conexion.conn)
        Try
            cmd2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message + " inic_kardex_pro()")
        End Try
        Conexion.close()
    End Sub
    Private Sub kardex_pro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class