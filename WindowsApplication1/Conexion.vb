Public Class Conexion
    Public Shared strConn As String = "server=sielcom.db.11889148.hostedresource.com;database=sielcom;user=sielcom;password=AAbbcc123#;port=3306;Connection Lifetime=86400"
    'Public Shared strConn As String = "server=localhost;database=sistema_jerplaz;user=root;password=gprl128x;port=3306;Connection Lifetime=86400"
    Public Shared conn As MySql.Data.MySqlClient.MySqlConnection
    Public Shared strCriticos As String = "select codigo as Código,nombre as Nombre,stock as Stock,critico as Critico, porvender 'Por vender',porllegar 'Por llegar', cast(fechapedido as date) as 'Fecha Pedido', descripcion as Descripción from producto where critico >= stock + porllegar - porvender"
    Public Shared Sub open()
        If conn.State <> ConnectionState.Open Then
            conn.Close()
            conn.Open()
            Dim sSQL As String = "SET character_set_results=latin1"
            Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(sSQL, Conexion.conn)
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Public Shared Sub close()
        conn.Close()
    End Sub
End Class
