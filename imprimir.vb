Imports System
Imports System.Drawing.Printing
Public Class imprimir

    Private Sub imprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        Timer1.Enabled = True
        Timer1.Interval = 10


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 1
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Me.Hide()
            'limpiar
        End If
    End Sub
End Class