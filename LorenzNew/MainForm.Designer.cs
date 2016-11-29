namespace LorenzNew
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corrDimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lyapunovToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectrumGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AKFGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poincareGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.paramToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.initConditionsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.attrTypetoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.построенияToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "Система";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.inputToolStripMenuItem.Text = "Задать параметры";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // построенияToolStripMenuItem
            // 
            this.построенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.corrDimensionToolStripMenuItem,
            this.lyapunovToolStripMenuItem});
            this.построенияToolStripMenuItem.Name = "построенияToolStripMenuItem";
            this.построенияToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.построенияToolStripMenuItem.Text = "Расчёты";
            // 
            // corrDimensionToolStripMenuItem
            // 
            this.corrDimensionToolStripMenuItem.Name = "corrDimensionToolStripMenuItem";
            this.corrDimensionToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.corrDimensionToolStripMenuItem.Text = "Корреляционная размерность";
            this.corrDimensionToolStripMenuItem.Click += new System.EventHandler(this.corrDimensionToolStripMenuItem_Click_1);
            // 
            // lyapunovToolStripMenuItem
            // 
            this.lyapunovToolStripMenuItem.Name = "lyapunovToolStripMenuItem";
            this.lyapunovToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.lyapunovToolStripMenuItem.Text = "Показатель Ляпунова";
            this.lyapunovToolStripMenuItem.Click += new System.EventHandler(this.lyapunovToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeGraphToolStripMenuItem,
            this.spectrumGraphToolStripMenuItem,
            this.AKFGraphToolStripMenuItem,
            this.poincareGraphToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.viewToolStripMenuItem.Text = "Построения";
            // 
            // timeGraphToolStripMenuItem
            // 
            this.timeGraphToolStripMenuItem.Name = "timeGraphToolStripMenuItem";
            this.timeGraphToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.timeGraphToolStripMenuItem.Text = "График во временной области";
            this.timeGraphToolStripMenuItem.Click += new System.EventHandler(this.timeGraphToolStripMenuItem_Click_1);
            // 
            // spectrumGraphToolStripMenuItem
            // 
            this.spectrumGraphToolStripMenuItem.Name = "spectrumGraphToolStripMenuItem";
            this.spectrumGraphToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.spectrumGraphToolStripMenuItem.Text = "График в частотной области";
            this.spectrumGraphToolStripMenuItem.Click += new System.EventHandler(this.spectrumGraphToolStripMenuItem_Click);
            // 
            // AKFGraphToolStripMenuItem
            // 
            this.AKFGraphToolStripMenuItem.Name = "AKFGraphToolStripMenuItem";
            this.AKFGraphToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.AKFGraphToolStripMenuItem.Text = "График АКФ";
            this.AKFGraphToolStripMenuItem.Click += new System.EventHandler(this.AKFGraphToolStripMenuItem_Click);
            // 
            // poincareGraphToolStripMenuItem
            // 
            this.poincareGraphToolStripMenuItem.Name = "poincareGraphToolStripMenuItem";
            this.poincareGraphToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.poincareGraphToolStripMenuItem.Text = "Сечение Пуанкаре";
            this.poincareGraphToolStripMenuItem.Click += new System.EventHandler(this.poincareGraphToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.helpToolStripMenuItem.Text = "Справка";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramToolStripStatusLabel,
            this.initConditionsToolStripStatusLabel,
            this.timeToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // paramToolStripStatusLabel
            // 
            this.paramToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.paramToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.paramToolStripStatusLabel.Name = "paramToolStripStatusLabel";
            this.paramToolStripStatusLabel.Size = new System.Drawing.Size(133, 19);
            this.paramToolStripStatusLabel.Text = "Значения параметров";
            // 
            // initConditionsToolStripStatusLabel
            // 
            this.initConditionsToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.initConditionsToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.initConditionsToolStripStatusLabel.Name = "initConditionsToolStripStatusLabel";
            this.initConditionsToolStripStatusLabel.Size = new System.Drawing.Size(122, 19);
            this.initConditionsToolStripStatusLabel.Text = "Начальные условия";
            // 
            // timeToolStripStatusLabel
            // 
            this.timeToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.timeToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.timeToolStripStatusLabel.Name = "timeToolStripStatusLabel";
            this.timeToolStripStatusLabel.Size = new System.Drawing.Size(140, 19);
            this.timeToolStripStatusLabel.Text = "Временные параметры";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attrTypetoolStripStatusLabel});
            this.statusStrip2.Location = new System.Drawing.Point(0, 24);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(17, 514);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            this.statusStrip2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // attrTypetoolStripStatusLabel
            // 
            this.attrTypetoolStripStatusLabel.Name = "attrTypetoolStripStatusLabel";
            this.attrTypetoolStripStatusLabel.Size = new System.Drawing.Size(15, 91);
            this.attrTypetoolStripStatusLabel.Text = "Тип аттрактора";
            this.attrTypetoolStripStatusLabel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Lorenz v2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeGraphToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel paramToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel initConditionsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem spectrumGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AKFGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poincareGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel attrTypetoolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel timeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corrDimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lyapunovToolStripMenuItem;
    }
}

