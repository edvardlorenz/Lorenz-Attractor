using System;
using System.Linq;
using System.Windows.Forms;
using About;
using Datalib;
using Input;
using TimeGraph;
using SpectrumGraph;
using AKFGraph;
using PoincareGraph;
using calculate_attractor;
using CorrDimension;

namespace LorenzNew
{
    public partial class MainForm : Form
    {
        private readonly DataSingleton _ds = DataSingleton.getInstance;

        public MainForm()
        {
            InitializeComponent();
        }

        // Метод обновляет текст в информациональных полях формы
        private void UpdateInfoText()
        {
            paramToolStripStatusLabel.Text = "";
            if (_ds.parameter1Name[_ds.SystemNumber] != "")
                paramToolStripStatusLabel.Text += _ds.parameter1Name[_ds.SystemNumber] + @"=" + _ds.param1[_ds.SystemNumber] + @"  ";
            if (_ds.parameter2Name[_ds.SystemNumber] != "")
                paramToolStripStatusLabel.Text += _ds.parameter2Name[_ds.SystemNumber] + @"=" + _ds.param2[_ds.SystemNumber] + @"  ";
            if (_ds.parameter3Name[_ds.SystemNumber] != "")
                paramToolStripStatusLabel.Text += _ds.parameter3Name[_ds.SystemNumber] + @"=" + _ds.param3[_ds.SystemNumber] + @"  ";
            if (_ds.parameter4Name[_ds.SystemNumber] != "")
                paramToolStripStatusLabel.Text += _ds.parameter4Name[_ds.SystemNumber] + @"=" + _ds.param4[_ds.SystemNumber] + @"  ";
            if (_ds.parameter5Name[_ds.SystemNumber] != "")
                paramToolStripStatusLabel.Text += _ds.parameter5Name[_ds.SystemNumber] + @"=" + _ds.param5[_ds.SystemNumber];

            initConditionsToolStripStatusLabel.Text = "";
            initConditionsToolStripStatusLabel.Text += @"x0=" + _ds.x0[_ds.SystemNumber] + @"  ";
            initConditionsToolStripStatusLabel.Text += @"y0=" + _ds.y0[_ds.SystemNumber] + @"  ";
            initConditionsToolStripStatusLabel.Text += @"z0=" + _ds.z0[_ds.SystemNumber] + @"  ";

            timeToolStripStatusLabel.Text = "";
            timeToolStripStatusLabel.Text += @"Время=" + _ds.T[_ds.SystemNumber] + @"  ";
            timeToolStripStatusLabel.Text += @"Шаг=" + _ds.dt[_ds.SystemNumber] + @"  ";

            attrTypetoolStripStatusLabel.Text = _ds.SystemName[_ds.SystemNumber];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateInfoText();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form input = new InputForm();

            // Проверка: Если в фоне выполняются какие-то задачи, то изменять параметры нельзя.
            for (int i = 0; i < _ds.backgroundTask.Length; i++)
            {
                if (_ds.backgroundTask[i])
                {
                    MessageBox.Show(this, "В данный момент изменить параметры системы нельзя, поскольку расчитывается " + _ds.backgroundTaskName[i] + ".", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Показ формы ввода параметров
            input.ShowDialog();

            var index = _ds.SystemNumber;

            // Если параметры были изменены
            if (_ds.wasChanged)
            {
                // Пересчитываем значения системы
                calculate_attractor_facade.start(_ds.param1[index], _ds.param2[index], _ds.param3[index], _ds.param4[index], _ds.param5[index], _ds.x0[index], _ds.y0[index], _ds.z0[index], ref _ds.x, ref _ds.y, ref _ds.z, ref _ds.T[index], _ds.dt[index], _ds.SystemNumber);

                // Во всех открытых дочерних окнах выводим оповещение о том, что параметры системы были изменены
                foreach (var f in MdiChildren)
                {
                    if (f.Visible)
                    {
                        var ss = f.Controls["statusStrip"];
                        var sstr = ss as StatusStrip;

                        if (sstr != null)
                        {
                            sstr.Items[0].Visible = true;
                        }
                    }
                }
            }

            _ds.wasChanged = false;

            UpdateInfoText();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выход из приложения
            Application.Exit();
        }

        // Метод для унифицированного создания дочерней формы
        // TForm -- тип дочерней формы
        private void ShowSingleForm<TForm>()
        where TForm : Form, new()
        {
            // Проверка: Если параметры системы не были заданы, то предлагаем их ввести
            while (_ds.x == null || _ds.y == null || _ds.z == null)
            {
                inputToolStripMenuItem_Click(this, EventArgs.Empty);
            } 

            // Если форма этого типа уже есть, то фокусируемся на ней, иначе -- создаём новую
            TForm form = Application.OpenForms.OfType<TForm>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new TForm { MdiParent = this };
                form.Show();
            }
        }

        // Показываем форму временного графика
        private void timeGraphToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowSingleForm<TimeGraphForm>();
        }

        // Показываем форму графика спектра
        private void spectrumGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<SpectrumGraphForm>();
        }

        // Показываем форму графика АКФ
        private void AKFGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<AKFGraphForm>();
        }

        // Показываем форму графика Пуанкаре
        private void poincareGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSingleForm<PoincareGraphForm>();
        }

        // Показываем форму корреляционной размерности
        private void corrDimensionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowSingleForm<CorrDimensionForm>();
        }

        // Выводим значение показателя Ляпунова
        private void lyapunovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (_ds.x == null || _ds.y == null || _ds.z == null)
            {
                inputToolStripMenuItem_Click(this, EventArgs.Empty);
            }


            int index = _ds.SystemNumber;
            //выполняем пересчёт всей траектории перед расчётом для обновления координаты z для 
            //неавтономных уравнений
            calculate_attractor_facade.start_Lyapunov(_ds.param1[index], _ds.param2[index], _ds.param3[index], _ds.param4[index], _ds.param5[index], _ds.x0[index], _ds.y0[index], _ds.z0[index], ref _ds.x, ref _ds.y, ref _ds.z, ref _ds.T[index], _ds.dt[index], _ds.SystemNumber);

            Calculate_Lyapunov cl = new Calculate_Lyapunov();

           
            Double L = cl.Calculate(_ds.param1[index], _ds.param2[index], _ds.param3[index],
                    _ds.param4[index], _ds.param5[index], ref _ds.x, ref _ds.y, ref _ds.z, _ds.T[index], _ds.dt[index], _ds.SystemNumber);

            string str = L.ToString("G4");

            //пересчитываем траекторию для возвращения обработанных неавтономных уравнений
            calculate_attractor_facade.start(_ds.param1[index], _ds.param2[index], _ds.param3[index], _ds.param4[index], _ds.param5[index], _ds.x0[index], _ds.y0[index], _ds.z0[index], ref _ds.x, ref _ds.y, ref _ds.z, ref _ds.T[index], _ds.dt[index], _ds.SystemNumber);

            MessageBox.Show(this, "Старший показатель Ляпунова для заданных параметров системы составляет " + str, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Показываем форму об авторах
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new AboutForm();
            f.ShowDialog();
        }

        // Показываем справку
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Lorenz_v_2.0.chm");
        }
    }
}
