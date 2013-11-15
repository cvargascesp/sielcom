Imports System.IO
Imports System.Xml
Public Class rrhh_sueldos
   
    Private Sub rrhh_sueldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Me.Label2.Text = Me.WebBrowser1.Document.GetElementById("uf").GetAttribute("innerText")
    End Sub
End Class