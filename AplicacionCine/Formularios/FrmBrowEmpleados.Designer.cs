namespace AplicacionCine.Formularios
{
    partial class FrmBrowEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowEmpleados));
            pnTotal = new Panel();
            pnInfo = new Panel();
            dvgEmpleados = new DataGridView();
            pnStatus = new Panel();
            ssInfo = new StatusStrip();
            tslUsuario = new ToolStripStatusLabel();
            tslRol = new ToolStripStatusLabel();
            tslEstado = new ToolStripStatusLabel();
            pnTop = new Panel();
            toolStrip1 = new ToolStrip();
            lbFiltroNombre = new ToolStripLabel();
            txtFiltroNombre = new ToolStripTextBox();
            lblFiltroTipo = new ToolStripLabel();
            tscbFiltroTipo = new ToolStripComboBox();
            tsbtBuscar = new ToolStripButton();
            tsbtLimpiar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbtNuevo = new ToolStripButton();
            tsbtModificar = new ToolStripButton();
            tsbtEliminar = new ToolStripButton();
            tsbtResetPass = new ToolStripButton();
            tsbtRefrescar = new ToolStripButton();
            pnTopBar = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            pnTotal.SuspendLayout();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgEmpleados).BeginInit();
            pnStatus.SuspendLayout();
            ssInfo.SuspendLayout();
            pnTop.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnTopBar.SuspendLayout();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnInfo);
            pnTotal.Controls.Add(pnStatus);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Controls.Add(pnTopBar);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(868, 554);
            pnTotal.TabIndex = 0;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(dvgEmpleados);
            pnInfo.Dock = DockStyle.Fill;
            pnInfo.Location = new Point(0, 65);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(868, 459);
            pnInfo.TabIndex = 3;
            // 
            // dvgEmpleados
            // 
            dvgEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgEmpleados.Dock = DockStyle.Fill;
            dvgEmpleados.Location = new Point(0, 0);
            dvgEmpleados.Name = "dvgEmpleados";
            dvgEmpleados.Size = new Size(868, 459);
            dvgEmpleados.TabIndex = 2;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(ssInfo);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 524);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(868, 30);
            pnStatus.TabIndex = 2;
            // 
            // ssInfo
            // 
            ssInfo.Dock = DockStyle.Fill;
            ssInfo.Items.AddRange(new ToolStripItem[] { tslUsuario, tslRol, tslEstado });
            ssInfo.Location = new Point(0, 0);
            ssInfo.Name = "ssInfo";
            ssInfo.Size = new Size(868, 30);
            ssInfo.TabIndex = 3;
            ssInfo.Text = "statusStrip1";
            // 
            // tslUsuario
            // 
            tslUsuario.Margin = new Padding(20, 3, 10, 2);
            tslUsuario.Name = "tslUsuario";
            tslUsuario.Size = new Size(47, 25);
            tslUsuario.Text = "Usuario";
            // 
            // tslRol
            // 
            tslRol.Margin = new Padding(0, 3, 10, 2);
            tslRol.Name = "tslRol";
            tslRol.Size = new Size(24, 25);
            tslRol.Text = "Rol";
            // 
            // tslEstado
            // 
            tslEstado.Name = "tslEstado";
            tslEstado.Size = new Size(42, 25);
            tslEstado.Text = "Estado";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(toolStrip1);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 31);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(868, 34);
            pnTop.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.Items.AddRange(new ToolStripItem[] { lbFiltroNombre, txtFiltroNombre, lblFiltroTipo, tscbFiltroTipo, toolStripSeparator1, tsbtBuscar, tsbtLimpiar, toolStripSeparator2, tsbtNuevo, tsbtModificar, tsbtEliminar, tsbtResetPass, tsbtRefrescar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(868, 34);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lbFiltroNombre
            // 
            lbFiltroNombre.Name = "lbFiltroNombre";
            lbFiltroNombre.Size = new Size(54, 31);
            lbFiltroNombre.Text = "Nombre:";
            // 
            // txtFiltroNombre
            // 
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.Size = new Size(100, 34);
            // 
            // lblFiltroTipo
            // 
            lblFiltroTipo.Name = "lblFiltroTipo";
            lblFiltroTipo.Size = new Size(34, 31);
            lblFiltroTipo.Text = "Tipo:";
            // 
            // tscbFiltroTipo
            // 
            tscbFiltroTipo.Name = "tscbFiltroTipo";
            tscbFiltroTipo.Size = new Size(121, 34);
            // 
            // tsbtBuscar
            // 
            tsbtBuscar.AutoSize = false;
            tsbtBuscar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtBuscar.Image = (Image)resources.GetObject("tsbtBuscar.Image");
            tsbtBuscar.ImageTransparentColor = Color.Magenta;
            tsbtBuscar.Name = "tsbtBuscar";
            tsbtBuscar.Size = new Size(31, 31);
            tsbtBuscar.Text = "toolStripButton1";
            // 
            // tsbtLimpiar
            // 
            tsbtLimpiar.AutoSize = false;
            tsbtLimpiar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtLimpiar.Image = (Image)resources.GetObject("tsbtLimpiar.Image");
            tsbtLimpiar.ImageTransparentColor = Color.Magenta;
            tsbtLimpiar.Name = "tsbtLimpiar";
            tsbtLimpiar.Size = new Size(31, 31);
            tsbtLimpiar.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 34);
            // 
            // tsbtNuevo
            // 
            tsbtNuevo.AutoSize = false;
            tsbtNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtNuevo.Image = (Image)resources.GetObject("tsbtNuevo.Image");
            tsbtNuevo.ImageTransparentColor = Color.Magenta;
            tsbtNuevo.Name = "tsbtNuevo";
            tsbtNuevo.Size = new Size(31, 31);
            tsbtNuevo.Text = "toolStripButton3";
            // 
            // tsbtModificar
            // 
            tsbtModificar.AutoSize = false;
            tsbtModificar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtModificar.Image = (Image)resources.GetObject("tsbtModificar.Image");
            tsbtModificar.ImageTransparentColor = Color.Magenta;
            tsbtModificar.Name = "tsbtModificar";
            tsbtModificar.Size = new Size(31, 31);
            tsbtModificar.Text = "toolStripButton4";
            // 
            // tsbtEliminar
            // 
            tsbtEliminar.AutoSize = false;
            tsbtEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtEliminar.Image = (Image)resources.GetObject("tsbtEliminar.Image");
            tsbtEliminar.ImageTransparentColor = Color.Magenta;
            tsbtEliminar.Name = "tsbtEliminar";
            tsbtEliminar.Size = new Size(31, 31);
            tsbtEliminar.Text = "toolStripButton5";
            // 
            // tsbtResetPass
            // 
            tsbtResetPass.AutoSize = false;
            tsbtResetPass.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtResetPass.Image = (Image)resources.GetObject("tsbtResetPass.Image");
            tsbtResetPass.ImageTransparentColor = Color.Magenta;
            tsbtResetPass.Name = "tsbtResetPass";
            tsbtResetPass.Size = new Size(31, 31);
            tsbtResetPass.Text = "toolStripButton6";
            // 
            // tsbtRefrescar
            // 
            tsbtRefrescar.AutoSize = false;
            tsbtRefrescar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbtRefrescar.Image = (Image)resources.GetObject("tsbtRefrescar.Image");
            tsbtRefrescar.ImageTransparentColor = Color.Magenta;
            tsbtRefrescar.Name = "tsbtRefrescar";
            tsbtRefrescar.Size = new Size(31, 31);
            tsbtRefrescar.Text = "toolStripButton7";
            // 
            // pnTopBar
            // 
            pnTopBar.Controls.Add(menuPrincipal);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new Point(0, 0);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new Size(868, 31);
            pnTopBar.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(868, 31);
            menuPrincipal.TabIndex = 2;
            menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 27);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // pasesToolStripMenuItem
            // 
            pasesToolStripMenuItem.Name = "pasesToolStripMenuItem";
            pasesToolStripMenuItem.Size = new Size(48, 27);
            pasesToolStripMenuItem.Text = "&Pases";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 27);
            gestiónToolStripMenuItem.Text = "&Gestión";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 27);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 34);
            // 
            // FrmBrowEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 554);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmBrowEmpleados";
            Text = "Lista de Empleados";
            pnTotal.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgEmpleados).EndInit();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            ssInfo.ResumeLayout(false);
            ssInfo.PerformLayout();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnTopBar.ResumeLayout(false);
            pnTopBar.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnTop;
        private Panel pnTopBar;
        private Panel pnStatus;
        private Panel pnInfo;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private StatusStrip ssInfo;
        private ToolStripStatusLabel tslUsuario;
        private ToolStripStatusLabel tslRol;
        private ToolStripStatusLabel tslEstado;
        private DataGridView dvgEmpleados;
        private ToolStrip toolStrip1;
        private ToolStripLabel lbFiltroNombre;
        private ToolStripTextBox txtFiltroNombre;
        private ToolStripLabel lblFiltroTipo;
        private ToolStripComboBox tscbFiltroTipo;
        private ToolStripButton tsbtBuscar;
        private ToolStripButton tsbtLimpiar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbtNuevo;
        private ToolStripButton tsbtModificar;
        private ToolStripButton tsbtEliminar;
        private ToolStripButton tsbtResetPass;
        private ToolStripButton tsbtRefrescar;
        private ToolStripSeparator toolStripSeparator2;
    }
}