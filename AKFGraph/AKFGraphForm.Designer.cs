namespace AKFGraph
{
    partial class AKFGraphForm
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
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AKFGraphForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.графикФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rxτToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ryτToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пОстроитьRzτToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.остановитьРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showSystemParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.dataChanged = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.endTimeLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chartAutCh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAutCh)).BeginInit();
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
            this.rxτToolStripMenuItem,
            this.ryτToolStripMenuItem,
            this.пОстроитьRzτToolStripMenuItem,
            this.toolStripSeparator1,
            this.остановитьРасчетToolStripMenuItem,
            this.toolStripSeparator2,
            this.showSystemParameter,
            this.toolStripSeparator3,
            this.сохранитьToolStripMenuItem});
            this.графикФункцииToolStripMenuItem.Name = "графикФункцииToolStripMenuItem";
            this.графикФункцииToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.графикФункцииToolStripMenuItem.Text = "АКФ";
            this.графикФункцииToolStripMenuItem.Click += new System.EventHandler(this.dataChanged_VisibleChanged);
            // 
            // rxτToolStripMenuItem
            // 
            this.rxτToolStripMenuItem.Name = "rxτToolStripMenuItem";
            this.rxτToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.rxτToolStripMenuItem.Text = "Построить Rx(τ)";
            this.rxτToolStripMenuItem.Click += new System.EventHandler(this.rxτToolStripMenuItem_Click);
            // 
            // ryτToolStripMenuItem
            // 
            this.ryτToolStripMenuItem.Name = "ryτToolStripMenuItem";
            this.ryτToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.ryτToolStripMenuItem.Text = "Построить Ry(τ)";
            this.ryτToolStripMenuItem.Click += new System.EventHandler(this.ryτToolStripMenuItem_Click);
            // 
            // пОстроитьRzτToolStripMenuItem
            // 
            this.пОстроитьRzτToolStripMenuItem.Name = "пОстроитьRzτToolStripMenuItem";
            this.пОстроитьRzτToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.пОстроитьRzτToolStripMenuItem.Text = "Построить Rz(τ)";
            this.пОстроитьRzτToolStripMenuItem.Click += new System.EventHandler(this.пОстроитьRzτToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(314, 6);
            // 
            // остановитьРасчетToolStripMenuItem
            // 
            this.остановитьРасчетToolStripMenuItem.Name = "остановитьРасчетToolStripMenuItem";
            this.остановитьРасчетToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.остановитьРасчетToolStripMenuItem.Text = "Остановить расчёт";
            this.остановитьРасчетToolStripMenuItem.Click += new System.EventHandler(this.остановитьРасчетToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(314, 6);
            // 
            // showSystemParameter
            // 
            this.showSystemParameter.Name = "showSystemParameter";
            this.showSystemParameter.Size = new System.Drawing.Size(317, 22);
            this.showSystemParameter.Text = "Отобразить название и параметры системы";
            this.showSystemParameter.Click += new System.EventHandler(this.showSystemParameters_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(314, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить график";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataChanged,
            this.toolStripProgressBar1,
            this.endTimeLabel1});
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
            // endTimeLabel1
            // 
            this.endTimeLabel1.Name = "endTimeLabel1";
            this.endTimeLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // chartAutCh
            // 
            this.chartAutCh.AllowDrop = true;
            chartArea1.Name = "ChartArea1";
            this.chartAutCh.ChartAreas.Add(chartArea1);
            this.chartAutCh.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chartAutCh.Legends.Add(legend1);
            this.chartAutCh.Location = new System.Drawing.Point(0, 24);
            this.chartAutCh.Margin = new System.Windows.Forms.Padding(1);
            this.chartAutCh.Name = "chartAutCh";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAutCh.Series.Add(series1);
            this.chartAutCh.Size = new System.Drawing.Size(584, 316);
            this.chartAutCh.TabIndex = 0;
            this.chartAutCh.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            title1.Name = "Title1";
            title2.Name = "Title2";
            this.chartAutCh.Titles.Add(title1);
            this.chartAutCh.Titles.Add(title2);
            // 
            // AKFGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.chartAutCh);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AKFGraphForm";
            this.Text = "Автокорреляционная функция (АКФ)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AKFGraphForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAutCh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem графикФункцииToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel dataChanged;
        private System.Windows.Forms.ToolStripMenuItem showSystemParameter;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAutCh;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem остановитьРасчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rxτToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ryτToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пОстроитьRzτToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel endTimeLabel1;
    }
}