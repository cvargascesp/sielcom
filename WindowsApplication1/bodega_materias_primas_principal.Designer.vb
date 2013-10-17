<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bodega_materias_primas_principal
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MateriasPrimasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarMateriaPrimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarMateriaPrimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnidadDeMedidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FamiliasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PcesoDeFabricacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitudDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaDeProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarProductosAFabricacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 64)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "kardex"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(377, 90)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 64)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Libro de recepcion de mercaderia"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(246, 90)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 64)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Informe de productos finales"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(138, 90)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(89, 64)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Libro de pedidos"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(356, 362)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Volver"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MateriasPrimasToolStripMenuItem, Me.ParametrosToolStripMenuItem, Me.OrdenesDeCompraToolStripMenuItem, Me.PcesoDeFabricacionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(642, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MateriasPrimasToolStripMenuItem
        '
        Me.MateriasPrimasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarMateriaPrimaToolStripMenuItem, Me.EditarMateriaPrimaToolStripMenuItem, Me.CatalogoToolStripMenuItem})
        Me.MateriasPrimasToolStripMenuItem.Name = "MateriasPrimasToolStripMenuItem"
        Me.MateriasPrimasToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.MateriasPrimasToolStripMenuItem.Text = "Materias Primas"
        '
        'AgregarMateriaPrimaToolStripMenuItem
        '
        Me.AgregarMateriaPrimaToolStripMenuItem.Name = "AgregarMateriaPrimaToolStripMenuItem"
        Me.AgregarMateriaPrimaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.AgregarMateriaPrimaToolStripMenuItem.Text = "Agregar Materia Prima"
        '
        'EditarMateriaPrimaToolStripMenuItem
        '
        Me.EditarMateriaPrimaToolStripMenuItem.Name = "EditarMateriaPrimaToolStripMenuItem"
        Me.EditarMateriaPrimaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.EditarMateriaPrimaToolStripMenuItem.Text = "Editar materia Prima"
        '
        'CatalogoToolStripMenuItem
        '
        Me.CatalogoToolStripMenuItem.Name = "CatalogoToolStripMenuItem"
        Me.CatalogoToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CatalogoToolStripMenuItem.Text = "Catalogo"
        '
        'ParametrosToolStripMenuItem
        '
        Me.ParametrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnidadDeMedidaToolStripMenuItem, Me.FamiliasToolStripMenuItem})
        Me.ParametrosToolStripMenuItem.Name = "ParametrosToolStripMenuItem"
        Me.ParametrosToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.ParametrosToolStripMenuItem.Text = "Parametros"
        '
        'UnidadDeMedidaToolStripMenuItem
        '
        Me.UnidadDeMedidaToolStripMenuItem.Name = "UnidadDeMedidaToolStripMenuItem"
        Me.UnidadDeMedidaToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UnidadDeMedidaToolStripMenuItem.Text = "Unidad de medida"
        '
        'FamiliasToolStripMenuItem
        '
        Me.FamiliasToolStripMenuItem.Name = "FamiliasToolStripMenuItem"
        Me.FamiliasToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.FamiliasToolStripMenuItem.Text = "Familias"
        '
        'OrdenesDeCompraToolStripMenuItem
        '
        Me.OrdenesDeCompraToolStripMenuItem.Name = "OrdenesDeCompraToolStripMenuItem"
        Me.OrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.OrdenesDeCompraToolStripMenuItem.Text = "Ordenes de Compra"
        '
        'PcesoDeFabricacionToolStripMenuItem
        '
        Me.PcesoDeFabricacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SolicitudDeProductosToolStripMenuItem, Me.EnProcesoToolStripMenuItem, Me.ConsultaDeProcesoToolStripMenuItem})
        Me.PcesoDeFabricacionToolStripMenuItem.Name = "PcesoDeFabricacionToolStripMenuItem"
        Me.PcesoDeFabricacionToolStripMenuItem.Size = New System.Drawing.Size(141, 20)
        Me.PcesoDeFabricacionToolStripMenuItem.Text = "Proceso de Fabricacion"
        '
        'SolicitudDeProductosToolStripMenuItem
        '
        Me.SolicitudDeProductosToolStripMenuItem.Name = "SolicitudDeProductosToolStripMenuItem"
        Me.SolicitudDeProductosToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.SolicitudDeProductosToolStripMenuItem.Text = "Solicitud de Productos"
        '
        'EnProcesoToolStripMenuItem
        '
        Me.EnProcesoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarProductosAFabricacionToolStripMenuItem, Me.EditarProcesoToolStripMenuItem})
        Me.EnProcesoToolStripMenuItem.Name = "EnProcesoToolStripMenuItem"
        Me.EnProcesoToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.EnProcesoToolStripMenuItem.Text = "En Proceso"
        '
        'ConsultaDeProcesoToolStripMenuItem
        '
        Me.ConsultaDeProcesoToolStripMenuItem.Name = "ConsultaDeProcesoToolStripMenuItem"
        Me.ConsultaDeProcesoToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ConsultaDeProcesoToolStripMenuItem.Text = "Consulta de Proceso"
        '
        'IngresarProductosAFabricacionToolStripMenuItem
        '
        Me.IngresarProductosAFabricacionToolStripMenuItem.Name = "IngresarProductosAFabricacionToolStripMenuItem"
        Me.IngresarProductosAFabricacionToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.IngresarProductosAFabricacionToolStripMenuItem.Text = "Ingresar productos a fabricacion"
        '
        'EditarProcesoToolStripMenuItem
        '
        Me.EditarProcesoToolStripMenuItem.Name = "EditarProcesoToolStripMenuItem"
        Me.EditarProcesoToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.EditarProcesoToolStripMenuItem.Text = "Editar Proceso"
        '
        'bodega_materias_primas_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 397)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "bodega_materias_primas_principal"
        Me.Text = "Gestion de materias Primas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MateriasPrimasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarMateriaPrimaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarMateriaPrimaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CatalogoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParametrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnidadDeMedidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FamiliasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PcesoDeFabricacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SolicitudDeProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnProcesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaDeProcesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarProductosAFabricacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarProcesoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
