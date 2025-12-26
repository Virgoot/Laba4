using System;
using System.Windows.Forms;

namespace Laba6
{
    public partial class GuessTheFunctionForm : Form
    {
        private double correctAnswer;
        private int attemptsLeft;

        public GuessTheFunctionForm()
        {
            InitializeComponent();
            UpdateAttemptsLabel();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (ValidateInput(txtA.Text, out double a) && ValidateInput(txtB.Text, out double b))
            {
                correctAnswer = FunctionGame.CalculateFunction(a, b);

                if (double.IsNaN(correctAnswer))
                {
                    MessageBox.Show("Ошибка: подкоренное выражение cos(B) < 0, вычисление невозможно.", "Ошибка вычисления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Активируем элементы для угадывания
                lblGuess.Enabled = true;
                txtGuess.Enabled = true;
                btnGuess.Enabled = true;
                lblAttempts.Enabled = true;
                numAttempts.Enabled = true;

                attemptsLeft = (int)numAttempts.Value;
                UpdateAttemptsLabel();

                MessageBox.Show("Значение функции вычислено. Теперь попробуйте его угадать!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для A и B.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            if (attemptsLeft <= 0)
            {
                MessageBox.Show("У вас не осталось попыток.", "Попытки закончились", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput(txtGuess.Text, out double userAnswer))
            {
                attemptsLeft--;
                UpdateAttemptsLabel();

                if (Math.Abs(correctAnswer - userAnswer) < 0.01)
                {
                    MessageBox.Show("Поздравляю, вы угадали!", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
                else
                {
                    if (attemptsLeft > 0)
                    {
                        MessageBox.Show($"Неверно. Попробуйте еще раз. У вас осталось {attemptsLeft} попыток.", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"К сожалению, вы не угадали. Правильный ответ: {correctAnswer:F2}", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGame();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректный числовой ответ.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numAttempts_ValueChanged(object sender, EventArgs e)
        {
            attemptsLeft = (int)numAttempts.Value;
            UpdateAttemptsLabel();
        }

        private bool ValidateInput(string input, out double result)
        {
            return double.TryParse(input.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out result);
        }

        private void UpdateAttemptsLabel()
        {
            lblAttempts.Text = $"Попыток осталось: {attemptsLeft}";
        }

        private void ResetGame()
        {
            lblGuess.Enabled = false;
            txtGuess.Enabled = false;
            txtGuess.Clear();
            btnGuess.Enabled = false;
            lblAttempts.Enabled = false;
            numAttempts.Enabled = true; // Оставляем возможность изменить кол-во попыток для новой игры

            attemptsLeft = (int)numAttempts.Value;
            UpdateAttemptsLabel();
        }
    }
}
