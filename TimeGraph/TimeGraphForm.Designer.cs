namespace TimeGraph
{
    partial class TimeGraphForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeGraphForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dataChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графикФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ytToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ztToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.show_system_parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataChanged});
            this.statusStrip.Location = new System.Drawing.Point(0, 340);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 0;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графикФункцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // графикФункцииToolStripMenuItem
            // 
            this.графикФункцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xtToolStripMenuItem,
            this.ytToolStripMenuItem,
            this.ztToolStripMenuItem,
            this.yxToolStripMenuItem,
            this.zxToolStripMenuItem,
            this.zyToolStripMenuItem,
            this.toolStripSeparator1,
            this.show_system_parameters,
            this.toolStripSeparator2,
            this.сохранитьToolStripMenuItem});
            this.графикФункцииToolStripMenuItem.Name = "графикФункцииToolStripMenuItem";
            this.графикФункцииToolStripMenuItem.Size = new System.Drawing.Size(189, 20);
            this.графикФункцииToolStripMenuItem.Text = "График во временной области";
            // 
            // xtToolStripMenuItem
            // 
            this.xtToolStripMenuItem.Name = "xtToolStripMenuItem";
            this.xtToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.xtToolStripMenuItem.Text = "x(t)";
            this.xtToolStripMenuItem.Click += new System.EventHandler(this.xtToolStripMenuItem_Click);
            // 
            // ytToolStripMenuItem
            // 
            this.ytToolStripMenuItem.Name = "ytToolStripMenuItem";
            this.ytToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.ytToolStripMenuItem.Text = "y(t)";
            this.ytToolStripMenuItem.Click += new System.EventHandler(this.ytToolStripMenuItem_Click);
            // 
            // ztToolStripMenuItem
            // 
            this.ztToolStripMenuItem.Name = "ztToolStripMenuItem";
            this.ztToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.ztToolStripMenuItem.Text = "z(t)";
            this.ztToolStripMenuItem.Click += new System.EventHandler(this.ztToolStripMenuItem_Click);
            // 
            // yxToolStripMenuItem
            // 
            this.yxToolStripMenuItem.Name = "yxToolStripMenuItem";
            this.yxToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.yxToolStripMenuItem.Text = "y(x)";
            this.yxToolStripMenuItem.Click += new System.EventHandler(this.yxToolStripMenuItem_Click);
            // 
            // zxToolStripMenuItem
            // 
            this.zxToolStripMenuItem.Name = "zxToolStripMenuItem";
            this.zxToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.zxToolStripMenuItem.Text = "z(x)";
            this.zxToolStripMenuItem.Click += new System.EventHandler(this.zxToolStripMenuItem_Click);
            // 
            // zyToolStripMenuItem
            // 
            this.zyToolStripMenuItem.Name = "zyToolStripMenuItem";
            this.zyToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.zyToolStripMenuItem.Text = "z(y)";
            this.zyToolStripMenuItem.Click += new System.EventHandler(this.zyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // show_system_parameters
            // 
            this.show_system_parameters.Name = "show_system_parameters";
            this.show_system_parameters.Size = new System.Drawing.Size(317, 22);
            this.show_system_parameters.Text = "Отобразить название и параметры системы";
            this.show_system_parameters.Click += new System.EventHandler(this.show_system_parameters_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(314, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить график";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 24);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(584, 316);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // TimeGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimeGraphForm";
            this.Text = "График во временной области";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dataChanged;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графикФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ytToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ztToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem show_system_parameters;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}