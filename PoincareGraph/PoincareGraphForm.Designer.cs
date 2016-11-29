namespace PoincareGraph
{
    partial class PoincareGraphForm
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoincareGraphForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графикФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцияПоследовательностиДляYToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцияПоследовательностиДляXToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.функцияПоследовательностиДляYToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.функцияПоследовательностиДляXToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.функцияПоследовательностиДляYToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dataChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem,
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem,
            this.toolStripSeparator2,
            this.ShowToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveToolStripMenuItem});
            this.графикФункцииToolStripMenuItem.Name = "графикФункцииToolStripMenuItem";
            this.графикФункцииToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.графикФункцииToolStripMenuItem.Text = "Сечение Пуанкаре";
            // 
            // xtToolStripMenuItem
            // 
            this.xtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oXYToolStripMenuItem,
            this.функцияПоследовательностиДляYToolStripMenuItem1});
            this.xtToolStripMenuItem.Name = "xtToolStripMenuItem";
            this.xtToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.xtToolStripMenuItem.Text = "Построить сечение плоскостью YOZ";
            this.xtToolStripMenuItem.Click += new System.EventHandler(this.xtToolStripMenuItem_Click);
            // 
            // oXYToolStripMenuItem
            // 
            this.oXYToolStripMenuItem.Name = "oXYToolStripMenuItem";
            this.oXYToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.oXYToolStripMenuItem.Text = "Функция последования для Y";
            this.oXYToolStripMenuItem.Click += new System.EventHandler(this.oXYToolStripMenuItem_Click);
            // 
            // функцияПоследовательностиДляYToolStripMenuItem1
            // 
            this.функцияПоследовательностиДляYToolStripMenuItem1.Name = "функцияПоследовательностиДляYToolStripMenuItem1";
            this.функцияПоследовательностиДляYToolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.функцияПоследовательностиДляYToolStripMenuItem1.Text = "Функция последования для Z";
            this.функцияПоследовательностиДляYToolStripMenuItem1.Click += new System.EventHandler(this.функцияПоследовательностиДляYToolStripMenuItem1_Click);
            // 
            // построитьСечениеПлоскостьюXOZToolStripMenuItem
            // 
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.функцияПоследовательностиДляXToolStripMenuItem1,
            this.функцияПоследовательностиДляYToolStripMenuItem2});
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem.Name = "построитьСечениеПлоскостьюXOZToolStripMenuItem";
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem.Text = "Построить сечение плоскостью XOZ";
            this.построитьСечениеПлоскостьюXOZToolStripMenuItem.Click += new System.EventHandler(this.построитьСечениеПлоскостьюXOZToolStripMenuItem_Click);
            // 
            // функцияПоследовательностиДляXToolStripMenuItem1
            // 
            this.функцияПоследовательностиДляXToolStripMenuItem1.Name = "функцияПоследовательностиДляXToolStripMenuItem1";
            this.функцияПоследовательностиДляXToolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.функцияПоследовательностиДляXToolStripMenuItem1.Text = "Функция последования для X";
            this.функцияПоследовательностиДляXToolStripMenuItem1.Click += new System.EventHandler(this.функцияПоследовательностиДляXToolStripMenuItem1_Click);
            // 
            // функцияПоследовательностиДляYToolStripMenuItem2
            // 
            this.функцияПоследовательностиДляYToolStripMenuItem2.Name = "функцияПоследовательностиДляYToolStripMenuItem2";
            this.функцияПоследовательностиДляYToolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.функцияПоследовательностиДляYToolStripMenuItem2.Text = "Функция последования для Z";
            this.функцияПоследовательностиДляYToolStripMenuItem2.Click += new System.EventHandler(this.функцияПоследовательностиДляYToolStripMenuItem2_Click);
            // 
            // построитьСечениеПлоскостьюXOYToolStripMenuItem
            // 
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.функцияПоследовательностиДляXToolStripMenuItem2,
            this.функцияПоследовательностиДляYToolStripMenuItem3});
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem.Name = "построитьСечениеПлоскостьюXOYToolStripMenuItem";
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem.Text = "Построить сечение плоскостью XOY";
            this.построитьСечениеПлоскостьюXOYToolStripMenuItem.Click += new System.EventHandler(this.построитьСечениеПлоскостьюXOYToolStripMenuItem_Click);
            // 
            // функцияПоследовательностиДляXToolStripMenuItem2
            // 
            this.функцияПоследовательностиДляXToolStripMenuItem2.Name = "функцияПоследовательностиДляXToolStripMenuItem2";
            this.функцияПоследовательностиДляXToolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.функцияПоследовательностиДляXToolStripMenuItem2.Text = "Функция последования для X";
            this.функцияПоследовательностиДляXToolStripMenuItem2.Click += new System.EventHandler(this.функцияПоследовательностиДляXToolStripMenuItem2_Click);
            // 
            // функцияПоследовательностиДляYToolStripMenuItem3
            // 
            this.функцияПоследовательностиДляYToolStripMenuItem3.Name = "функцияПоследовательностиДляYToolStripMenuItem3";
            this.функцияПоследовательностиДляYToolStripMenuItem3.Size = new System.Drawing.Size(235, 22);
            this.функцияПоследовательностиДляYToolStripMenuItem3.Text = "Функция последования для Y";
            this.функцияПоследовательностиДляYToolStripMenuItem3.Click += new System.EventHandler(this.функцияПоследовательностиДляYToolStripMenuItem3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(314, 6);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.ShowToolStripMenuItem.Text = "Отобразить название и параметры системы";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить график";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataChanged});
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
            // chart1
            // 
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Format = "G4";
            chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.Title = "X";
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Format = "G4";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY.Title = "Y";
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.IsSoftShadows = false;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 24);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(584, 316);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.Name = "Title1";
            this.chart1.Titles.Add(title1);
            // 
            // PoincareGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PoincareGraphForm";
            this.Text = "Сечение Пуанкаре";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графикФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xtToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dataChanged;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem построитьСечениеПлоскостьюXOZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьСечениеПлоскостьюXOYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem функцияПоследовательностиДляYToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem функцияПоследовательностиДляXToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem функцияПоследовательностиДляYToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem функцияПоследовательностиДляXToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem функцияПоследовательностиДляYToolStripMenuItem3;
    }
}