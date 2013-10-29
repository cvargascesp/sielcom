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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MateriasPrimasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarMateriaPrimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarMateriaPrimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KardexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PcesoDeFabricacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitudDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IngresarProductosAFabricacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaDeProcesoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParametrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnidadDeMedidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FamiliasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenesDeCompraToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibroDePedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibroDeRecepcionDeMercaderiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MateriasPrimasToolStripMenuItem, Me.PcesoDeFabricacionToolStripMenuItem, Me.ParametrosToolStripMenuItem, Me.OrdenesDeCompraToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(647, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MateriasPrimasToolStripMenuItem
        '
        Me.MateriasPrimasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarMateriaPrimaToolStripMenuItem, Me.EditarMateriaPrimaToolStripMenuItem, Me.CatalogoToolStripMenuItem, Me.KardexToolStripMenuItem})
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
        'KardexToolStripMenuItem
        '
        Me.KardexToolStripMenuItem.Name = "KardexToolStripMenuItem"
        Me.KardexToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.KardexToolStripMenuItem.Text = "Kardex"
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
        'ConsultaDeProcesoToolStripMenuItem
        '
        Me.ConsultaDeProcesoToolStripMenuItem.Name = "ConsultaDeProcesoToolStripMenuItem"
        Me.ConsultaDeProcesoToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ConsultaDeProcesoToolStripMenuItem.Text = "Consulta de Proceso"
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
        Me.OrdenesDeCompraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenesDeCompraToolStripMenuItem1, Me.LibroDePedidosToolStripMenuItem, Me.LibroDeRecepcionDeMercaderiaToolStripMenuItem})
        Me.OrdenesDeCompraToolStripMenuItem.Name = "OrdenesDeCompraToolStripMenuItem"
        Me.OrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.OrdenesDeCompraToolStripMenuItem.Text = "Ordenes de Compra"
        '
        'OrdenesDeCompraToolStripMenuItem1
        '
        Me.OrdenesDeCompraToolStripMenuItem1.Name = "OrdenesDeCompraToolStripMenuItem1"
        Me.OrdenesDeCompraToolStripMenuItem1.Size = New System.Drawing.Size(253, 22)
        Me.OrdenesDeCompraToolStripMenuItem1.Text = "Ordenes de  Compra"
        '
        'LibroDePedidosToolStripMenuItem
        '
        Me.LibroDePedidosToolStripMenuItem.Name = "LibroDePedidosToolStripMenuItem"
        Me.LibroDePedidosToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.LibroDePedidosToolStripMenuItem.Text = "Libro de Pedidos"
        '
        'LibroDeRecepcionDeMercaderiaToolStripMenuItem
        '
        Me.LibroDeRecepcionDeMercaderiaToolStripMenuItem.Name = "LibroDeRecepcionDeMercaderiaToolStripMenuItem"
        Me.LibroDeRecepcionDeMercaderiaToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.LibroDeRecepcionDeMercaderiaToolStripMenuItem.Text = "Libro de Recepcion de Mercaderia"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(240, 496)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "© 2013 Copyright Orion System Ltda."
        '
        'PictureBox1
        '
        Me.PictureBox1.ImageLocation = ".\Resources\Secundario.jpg"
        Me.PictureBox1.Location = New System.Drawing.Point(0, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(646, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 52
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(623, 258)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock Critico de Materias Primas:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(602, 224)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(536, 456)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 53)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bodega_materias_primas_principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(647, 518)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "bodega_materias_primas_principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion de materias Primas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents KardexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibroDePedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibroDeRecepcionDeMercaderiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
