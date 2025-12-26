using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba6
{
    public partial class ArrayProcessingForm : Form
    {
        private ArrayProcessor arrayProcessor;

        public ArrayProcessingForm()
        {
            InitializeComponent();
            // Делаем кнопки неактивными до создания массива
            DisableOperationButtons();
        }

        private void btnCreateDefault_Click(object sender, EventArgs e)
        {
            arrayProcessor = new ArrayProcessor();
            UpdateDataGridView();
        }

        private void btnCreateCustom_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSize.Text, out int size) && size > 0)
            {
                arrayProcessor = new ArrayProcessor(size);
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("Введите корректный размер массива (целое число больше 0).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenerateRandom_Click(object sender, EventArgs e)
        {
            if (arrayProcessor != null)
            {
                // В ArrayProcessor нет публичного метода для перегенерации,
                // поэтому создаем новый массив с тем же размером
                arrayProcessor = new ArrayProcessor(arrayProcessor.Size);
                UpdateDataGridView();
            }
            else
            {
                // Если массив еще не создан, генерируем массив по умолчанию
                btnCreateDefault_Click(sender, e);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            arrayProcessor.SortWithCocktailSort(); // Используем один из методов сортировки
            UpdateDataGridView();
            MessageBox.Show("Массив отсортирован.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindMinMax_Click(object sender, EventArgs e)
        {
            int min = arrayProcessor.FindMin();
            int max = arrayProcessor.FindMax();
            lblResult.Text = $"Результат: Мин: {min}, Макс: {max}";
            HighlightMinMax(min, max);
        }

        private void btnCalculateAverage_Click(object sender, EventArgs e)
        {
            double average = arrayProcessor.CalculateAverage();
            lblResult.Text = $"Результат: Среднее = {average:F2}";
            ResetHighlight();
        }

        private void UpdateDataGridView()
        {
            dgvArray.DataSource = null;
            // Преобразуем int[] в DataTable для удобного отображения
            var table = new System.Data.DataTable();
            table.Columns.Add("Value", typeof(int));
            for (int i = 0; i < arrayProcessor.Size; i++)
            {
                table.Rows.Add(arrayProcessor.Array[i]);
            }
            dgvArray.DataSource = table;
            dgvArray.Columns[0].HeaderText = "Значение";
            dgvArray.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Сбрасываем выделение и результат
            ResetHighlight();
            lblResult.Text = "Результат:";

            // Активируем кнопки
            EnableOperationButtons();
        }

        private void dgvArray_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // При ручном редактировании обновляем исходный массив
            if (arrayProcessor != null && e.RowIndex >= 0)
            {
                try
                {
                    int newValue = Convert.ToInt32(dgvArray.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    arrayProcessor.Array[e.RowIndex] = newValue;
                    ResetHighlight();
                    lblResult.Text = "Результат:";
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректное целое число.", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Возвращаем старое значение
                    dgvArray.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = arrayProcessor.Array[e.RowIndex];
                }
            }
        }

        private void HighlightMinMax(int min, int max)
        {
            foreach (DataGridViewRow row in dgvArray.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int val = Convert.ToInt32(row.Cells[0].Value);
                    if (val == min)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else if (val == max)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void ResetHighlight()
        {
             foreach (DataGridViewRow row in dgvArray.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void EnableOperationButtons()
        {
            btnSort.Enabled = true;
            btnFindMinMax.Enabled = true;
            btnCalculateAverage.Enabled = true;
        }

        private void DisableOperationButtons()
        {
            btnSort.Enabled = false;
            btnFindMinMax.Enabled = false;
            btnCalculateAverage.Enabled = false;
        }
    }
}
