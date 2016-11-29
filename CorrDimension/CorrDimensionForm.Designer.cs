namespace CorrDimension
{
    partial class CorrDimensionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorrDimensionForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графикФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановкаРасчётаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dataChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графикФункцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // графикФункцииToolStripMenuItem
            // 
            this.графикФункцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xtToolStripMenuItem,
            this.остановкаРасчётаToolStripMenuItem});
            this.графикФункцииToolStripMenuItem.Name = "графикФункцииToolStripMenuItem";
            this.графикФункцииToolStripMenuItem.Size = new System.Drawing.Size(187, 20);
            this.графикФункцииToolStripMenuItem.Text = "Корреляционная размерность";
            // 
            // xtToolStripMenuItem
            // 
            this.xtToolStripMenuItem.Name = "xtToolStripMenuItem";
            this.xtToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.xtToolStripMenuItem.Text = "Запуск расчёта";
            this.xtToolStripMenuItem.Click += new System.EventHandler(this.xtToolStripMenuItem_Click);
            // 
            // остановкаРасчётаToolStripMenuItem
            // 
            this.остановкаРасчётаToolStripMenuItem.Name = "остановкаРасчётаToolStripMenuItem";
            this.остановкаРасчётаToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.остановкаРасчётаToolStripMenuItem.Text = "Остановка расчёта";
            this.остановкаРасчётаToolStripMenuItem.Click += new System.EventHandler(this.остановкаРасчётаToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataChanged,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 340);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // dataChanged
            // 
            this.dataChanged.Name = "dataChanged";
            this.dataChanged.Size = new System.Drawing.Size(202, 17);
            this.dataChanged.Text = "Расчётные данные были изменены";
            this.dataChanged.Visible = false;
            this.dataChanged.VisibleChanged += new System.EventHandler(this.dataChanged_VisibleChanged);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(584, 184);
            this.textBox1.TabIndex = 6;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // CorrDimensionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CorrDimensionForm";
            this.Text = "Корреляционная размерность";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CorrDimensionForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графикФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xtToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dataChanged;
        private System.Windows.Forms.ToolStripMenuItem остановкаРасчётаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label1;
    }
}