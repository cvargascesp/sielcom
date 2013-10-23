<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class e_materia_prima
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_ubicacion_mp = New System.Windows.Forms.TextBox()
        Me.unidadmedida_mp = New System.Windows.Forms.ComboBox()
        Me.combofamilia = New System.Windows.Forms.ComboBox()
        Me.txt_nom_mp = New System.Windows.Forms.TextBox()
        Me.txtcodigo_mp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtstockcrit = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.txtstockcrit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Ubicacion:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Unidad Medida:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Familia:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Codigo:"
        '
        'txt_ubicacion_mp
        '
        Me.txt_ubicacion_mp.Location = New System.Drawing.Point(96, 152)
        Me.txt_ubicacion_mp.Name = "txt_ubicacion_mp"
        Me.txt_ubicacion_mp.Size = New System.Drawing.Size(155, 20)
        Me.txt_ubicacion_mp.TabIndex = 20
        '
        'unidadmedida_mp
        '
        Me.unidadmedida_mp.FormattingEnabled = True
        Me.unidadmedida_mp.Items.AddRange(New Object() {"Unidad", "Kilo", "Metro", "Caja", "Bolsa", "Palet", "Litro", "Jaba"})
        Me.unidadmedida_mp.Location = New System.Drawing.Point(96, 122)
        Me.unidadmedida_mp.Name = "unidadmedida_mp"
        Me.unidadmedida_mp.Size = New System.Drawing.Size(155, 21)
        Me.unidadmedida_mp.TabIndex = 19
        '
        'combofamilia
        '
        Me.combofamilia.FormattingEnabled = True
        Me.combofamilia.Location = New System.Drawing.Point(96, 87)
        Me.combofamilia.Name = "combofamilia"
        Me.combofamilia.Size = New System.Drawing.Size(155, 21)
        Me.combofamilia.TabIndex = 18
        '
        'txt_nom_mp
        '
        Me.txt_nom_mp.Location = New System.Drawing.Point(96, 57)
        Me.txt_nom_mp.MaximumSize = New System.Drawing.Size(155, 20)
        Me.txt_nom_mp.MinimumSize = New System.Drawing.Size(155, 20)
        Me.txt_nom_mp.Name = "txt_nom_mp"
        Me.txt_nom_mp.Size = New System.Drawing.Size(155, 20)
        Me.txt_nom_mp.TabIndex = 17
        '
        'txtcodigo_mp
        '
        Me.txtcodigo_mp.Location = New System.Drawing.Point(96, 26)
        Me.txtcodigo_mp.Name = "txtcodigo_mp"
        Me.txtcodigo_mp.Size = New System.Drawing.Size(155, 20)
        Me.txtcodigo_mp.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(38, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 33)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Guardar Cambios"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(162, 217)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 33)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtstockcrit
        '
        Me.txtstockcrit.Location = New System.Drawing.Point(96, 178)
        Me.txtstockcrit.Name = "txtstockcrit"
        Me.txtstockcrit.Size = New System.Drawing.Size(155, 20)
        Me.txtstockcrit.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Stock Critico"
        '
        'e_materia_prima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 262)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtstockcrit)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_ubicacion_mp)
        Me.Controls.Add(Me.unidadmedida_mp)
        Me.Controls.Add(Me.combofamilia)
        Me.Controls.Add(Me.txt_nom_mp)
        Me.Controls.Add(Me.txtcodigo_mp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(392, 300)
        Me.MinimumSize = New System.Drawing.Size(392, 300)
        Me.Name = "e_materia_prima"
        Me.Text = "Editar Materias Primas"
        CType(Me.txtstockcrit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ubicacion_mp As System.Windows.Forms.TextBox
    Friend WithEvents unidadmedida_mp As System.Windows.Forms.ComboBox
    Friend WithEvents combofamilia As System.Windows.Forms.ComboBox
    Friend WithEvents txt_nom_mp As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigo_mp As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtstockcrit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
