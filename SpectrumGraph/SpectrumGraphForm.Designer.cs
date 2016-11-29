namespace SpectrumGraph
{
    partial class SpectrumGraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpectrumGraphForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dataChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графикФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.построитьСпектрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.отобразитьПараметрыСистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Spectr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spectr)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStripComboBox1,
            this.toolStripComboBox2,
            this.построитьСпектрToolStripMenuItem,
            this.toolStripSeparator1,
            this.отобразитьПараметрыСистемыToolStripMenuItem,
            this.toolStripSeparator2,
            this.сохранитьГрафикToolStripMenuItem});
            this.графикФункцииToolStripMenuItem.Name = "графикФункцииToolStripMenuItem";
            this.графикФункцииToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.графикФункцииToolStripMenuItem.Text = "Спектр";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "Модуль",
            "Аргумент",
            "Действительная часть",
            "Мнимая часть"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
            // 
            // построитьСпектрToolStripMenuItem
            // 
            this.построитьСпектрToolStripMenuItem.Name = "построитьСпектрToolStripMenuItem";
            this.построитьСпектрToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.построитьСпектрToolStripMenuItem.Text = "Построить спектр";
            this.построитьСпектрToolStripMenuItem.Click += new System.EventHandler(this.построитьСпектрToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // отобразитьПараметрыСистемыToolStripMenuItem
            // 
            this.отобразитьПараметрыСистемыToolStripMenuItem.Name = "отобразитьПараметрыСистемыToolStripMenuItem";
            this.отобразитьПараметрыСистемыToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.отобразитьПараметрыСистемыToolStripMenuItem.Text = "Отобразить назвение и параметры системы";
            this.отобразитьПараметрыСистемыToolStripMenuItem.Click += new System.EventHandler(this.отобразитьПараметрыСистемыToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(314, 6);
            // 
            // сохранитьГрафикToolStripMenuItem
            // 
            this.сохранитьГрафикToolStripMenuItem.Name = "сохранитьГрафикToolStripMenuItem";
            this.сохранитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.сохранитьГрафикToolStripMenuItem.Text = "Сохранить график";
            this.сохранитьГрафикToolStripMenuItem.Click += new System.EventHandler(this.сохранитьГрафикToolStripMenuItem_Click);
            // 
            // Spectr
            // 
            chartArea1.Name = "ChartArea1";
            this.Spectr.ChartAreas.Add(chartArea1);
            this.Spectr.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.Spectr.Legends.Add(legend1);
            this.Spectr.Location = new System.Drawing.Point(0, 24);
            this.Spectr.Margin = new System.Windows.Forms.Padding(2);
            this.Spectr.Name = "Spectr";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Spectr.Series.Add(series1);
            this.Spectr.Size = new System.Drawing.Size(584, 316);
            this.Spectr.TabIndex = 2;
            this.Spectr.Text = "chart1";
            // 
            // SpectrumGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.Spectr);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpectrumGraphForm";
            this.Text = "График в частотной области";
            this.Load += new System.EventHandler(this.SpectrumGraphForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spectr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dataChanged;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графикФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem построитьСпектрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафикToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart Spectr;
        private System.Windows.Forms.ToolStripMenuItem отобразитьПараметрыСистемыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}