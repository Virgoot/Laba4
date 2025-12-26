using System;
using System.Windows.Forms;

namespace Laba6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGuessGame_Click(object sender, EventArgs e)
        {
            GuessTheFunctionForm guessGameForm = new GuessTheFunctionForm();
            guessGameForm.ShowDialog();
        }

        private void btnArrayProcessing_Click(object sender, EventArgs e)
        {
            ArrayProcessingForm arrayForm = new ArrayProcessingForm();
            arrayForm.ShowDialog();
        }

        private void btnChess_Click(object sender, EventArgs e)
        {
            ChessForm chessForm = new ChessForm();
            chessForm.ShowDialog();
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            AuthorForm authorForm = new AuthorForm();
            authorForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
