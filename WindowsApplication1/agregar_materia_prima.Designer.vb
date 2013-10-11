<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class agregar_materia_prima
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcodigo_mp = New System.Windows.Forms.TextBox()
        Me.txt_nom_mp = New System.Windows.Forms.TextBox()
        Me.combofamilia = New System.Windows.Forms.ComboBox()
        Me.unidadmedida_mp = New System.Windows.Forms.ComboBox()
        Me.txt_ubicacion_mp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Familia:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha Creacion:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(131, 27)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(155, 20)
        Me.DateTimePicker1.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Unidad Medida:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Ubicacion:"
        '
        'txtcodigo_mp
        '
        Me.txtcodigo_mp.Location = New System.Drawing.Point(133, 61)
        Me.txtcodigo_mp.Name = "txtcodigo_mp"
        Me.txtcodigo_mp.Size = New System.Drawing.Size(155, 20)
        Me.txtcodigo_mp.TabIndex = 10
        '
        'txt_nom_mp
        '
        Me.txt_nom_mp.Location = New System.Drawing.Point(133, 92)
        Me.txt_nom_mp.Name = "txt_nom_mp"
        Me.txt_nom_mp.Size = New System.Drawing.Size(155, 20)
        Me.txt_nom_mp.TabIndex = 11
        '
        'combofamilia
        '
        Me.combofamilia.FormattingEnabled = True
        Me.combofamilia.Location = New System.Drawing.Point(133, 122)
        Me.combofamilia.Name = "combofamilia"
        Me.combofamilia.Size = New System.Drawing.Size(155, 21)
        Me.combofamilia.TabIndex = 12
        '
        'unidadmedida_mp
        '
        Me.unidadmedida_mp.FormattingEnabled = True
        Me.unidadmedida_mp.Items.AddRange(New Object() {"Unidad", "Kilo", "Metro", "Caja", "Bolsa", "Palet", "Litro", "Jaba"})
        Me.unidadmedida_mp.Location = New System.Drawing.Point(133, 157)
        Me.unidadmedida_mp.Name = "unidadmedida_mp"
        Me.unidadmedida_mp.Size = New System.Drawing.Size(155, 21)
        Me.unidadmedida_mp.TabIndex = 13
        '
        'txt_ubicacion_mp
        '
        Me.txt_ubicacion_mp.Location = New System.Drawing.Point(133, 187)
        Me.txt_ubicacion_mp.Name = "txt_ubicacion_mp"
        Me.txt_ubicacion_mp.Size = New System.Drawing.Size(155, 20)
        Me.txt_ubicacion_mp.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(96, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 46)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'agregar_materia_prima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(351, 291)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_ubicacion_mp)
        Me.Controls.Add(Me.unidadmedida_mp)
        Me.Controls.Add(Me.combofamilia)
        Me.Controls.Add(Me.txt_nom_mp)
        Me.Controls.Add(Me.txtcodigo_mp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "agregar_materia_prima"
        Me.Text = "Agregar materia Prima"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo_mp As System.Windows.Forms.TextBox
    Friend WithEvents txt_nom_mp As System.Windows.Forms.TextBox
    Friend WithEvents combofamilia As System.Windows.Forms.ComboBox
    Friend WithEvents unidadmedida_mp As System.Windows.Forms.ComboBox
    Friend WithEvents txt_ubicacion_mp As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
