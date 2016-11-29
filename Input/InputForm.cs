using System;
using System.Windows.Forms;
using Datalib;

namespace Input
{
    public partial class InputForm : Form
    {
        private readonly DataSingleton _ds = DataSingleton.getInstance;
        private int _index;
        
        public InputForm()
        {
            InitializeComponent();
        }

        private void updateChangesButton_Click(object sender, EventArgs e)
        {
            // Получаем введённые в форме значения и присваиваем их переменным
            _index = attrTypeComboBox.SelectedIndex;
            _ds.SystemNumber = _index;
            _ds.param1[_index] = Convert.ToDouble(param1UpDown.Value);
            _ds.param2[_index] = Convert.ToDouble(param2UpDown.Value);
            _ds.param3[_index] = Convert.ToDouble(param3UpDown.Value);
            _ds.param4[_index] = Convert.ToDouble(param4UpDown.Value);
            _ds.param5[_index] = Convert.ToDouble(param5UpDown.Value);
            _ds.x0[_index] = Convert.ToDouble(x0UpDown.Value);
            _ds.y0[_index] = Convert.ToDouble(y0UpDown.Value);
            _ds.z0[_index] = Convert.ToDouble(z0UpDown.Value);
            _ds.T[_index] = Convert.ToDouble(timeUpDown.Value);
            _ds.dt[_index] = Convert.ToDouble(stepUpDown.Value);
            _ds.wasChanged = true;

            // Проверка: Соотношение T и dt должно быть в пределах от 1000 до 100000000
            double N = _ds.T[_index] / _ds.dt[_index];
            if ((N < 1000) || (N > 10000000))
            {
                MessageBox.Show(this, "Неверно задан параметр T или dT. T и dT должны быть выбраны так, чтобы отношение T/dT было от 1000 до 10млн.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timeUpDown.Focus(); // Фокусируем ввод на поле ввода времени
            }
            else
            {
                Close();
            }
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            // Считываем значения переменных из Datalib и присваеваем их полям 
            attrTypeComboBox.DataSource = _ds.SystemName;
            attrTypeComboBox.SelectedIndex = _ds.SystemNumber;

            // Вывод подсказок при наведении на элементы формы
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;   // Интервал появления подсказки
            toolTip1.InitialDelay = 1000;   // Интервал перед появлением подсказки
            toolTip1.ReshowDelay = 500;     // Интервал перед появлением следующей подсказки

            toolTip1.ShowAlways = true;     // Показывать подсказки ВСЕГДА

            // Тексты подсказок для каждого элемента формы
            toolTip1.SetToolTip(this.attrTypeComboBox, "Система уравнений для моделирования");
            toolTip1.SetToolTip(this.param1UpDown, "Параметр системы");
            toolTip1.SetToolTip(this.param2UpDown, "Параметр системы");
            toolTip1.SetToolTip(this.param3UpDown, "Параметр системы");
            toolTip1.SetToolTip(this.param4UpDown, "Параметр системы");
            toolTip1.SetToolTip(this.param5UpDown, "Параметр системы");
            toolTip1.SetToolTip(this.x0UpDown, "Начальное значение координаты X");
            toolTip1.SetToolTip(this.y0UpDown, "Начальное значение координаты Y");
            toolTip1.SetToolTip(this.z0UpDown, "Начальное значение координаты Z");
            toolTip1.SetToolTip(this.timeUpDown, "Интервал времени вычисления");
            toolTip1.SetToolTip(this.stepUpDown, "Шаг вычисления");
        }

        private void attrTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Считываем значения переменных из Datalib и присваеваем их полям
            _index = attrTypeComboBox.SelectedIndex;

            param1Label.Text = _ds.parameter1Name[_index];
            param2Label.Text = _ds.parameter2Name[_index];
            param3Label.Text = _ds.parameter3Name[_index];
            param4Label.Text = _ds.parameter4Name[_index];
            param5Label.Text = _ds.parameter5Name[_index];

            param1UpDown.Value = (decimal)_ds.param1[_index];
            param2UpDown.Value = (decimal)_ds.param2[_index];
            param3UpDown.Value = (decimal)_ds.param3[_index];
            param4UpDown.Value = (decimal)_ds.param4[_index];
            param5UpDown.Value = (decimal)_ds.param5[_index];

            param1UpDown.Visible = param1Label.Text != "";
            param2UpDown.Visible = param2Label.Text != "";
            param3UpDown.Visible = param3Label.Text != "";
            param4UpDown.Visible = param4Label.Text != "";
            param5UpDown.Visible = param5Label.Text != "";

            x0UpDown.Value = (decimal)_ds.x0[_index];
            y0UpDown.Value = (decimal)_ds.y0[_index];
            z0UpDown.Value = (decimal)_ds.z0[_index];
            timeUpDown.Value = (decimal)_ds.T[_index];
            stepUpDown.Value = (decimal)_ds.dt[_index];
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Система не изменилась -- сбрасываем флаг
            _ds.wasChanged = false;
            Close();
        }
    }
}
