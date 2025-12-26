using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba6
{
    public partial class ChessForm : Form
    {
        private ChessGame game;
        private DataGridView dgvBoard;
        private Label lblStatus;
        private Button btnNewGame;

        private int? selectedRow = null;
        private int? selectedCol = null;

        public ChessForm()
        {
            InitializeComponent(); // Этот метод будет создан в Designer.cs
            InitializeGameComponents(); // А этот - создадим мы сами
            StartNewGame();
        }

        private void InitializeGameComponents()
        {
            // Настройка DataGridView
            dgvBoard = new DataGridView
            {
                Location = new Point(12, 12),
                Name = "dgvBoard",
                Size = new Size(482, 482),
                ColumnCount = 8,
                RowCount = 8,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                ScrollBars = ScrollBars.None,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                MultiSelect = false
            };

            // Настройка колонок и строк
            for (int i = 0; i < 8; i++)
            {
                dgvBoard.Columns[i].Width = 60;
                dgvBoard.Rows[i].Height = 60;
                dgvBoard.Columns[i].Name = ((char)('A' + i)).ToString();
                dgvBoard.Rows[i].HeaderCell.Value = (8 - i).ToString();
            }
            dgvBoard.RowHeadersWidth = 50;

            dgvBoard.CellClick += DgvBoard_CellClick;

            // Настройка Label
            lblStatus = new Label
            {
                Location = new Point(12, 500),
                Name = "lblStatus",
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                Text = "Ход белых"
            };

            // Настройка Button
            btnNewGame = new Button
            {
                Location = new Point(350, 500),
                Name = "btnNewGame",
                Size = new Size(140, 30),
                Text = "Новая игра",
                UseVisualStyleBackColor = true
            };
            btnNewGame.Click += (sender, e) => StartNewGame();

            // Добавляем компоненты на форму
            this.Controls.Add(dgvBoard);
            this.Controls.Add(lblStatus);
            this.Controls.Add(btnNewGame);
        }

        private void StartNewGame()
        {
            game = new ChessGame();
            selectedRow = null;
            selectedCol = null;
            dgvBoard.Enabled = true;
            DrawBoard();
            UpdateStatusLabel("Ход белых");
        }

        private void DrawBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    // Цвет клетки
                    dgvBoard.Rows[r].Cells[c].Style.BackColor = (r + c) % 2 == 0 ? Color.WhiteSmoke : Color.DarkGray;

                    // Фигура
                    Piece piece = game.Board[r, c];
                    dgvBoard.Rows[r].Cells[c].Value = piece?.Symbol ?? ' ';

                    // Стиль текста
                    dgvBoard.Rows[r].Cells[c].Style.Font = new Font("Arial", 24F, FontStyle.Bold);
                    dgvBoard.Rows[r].Cells[c].Style.ForeColor = piece?.Color == "White" ? Color.Black : Color.DarkRed;
                    dgvBoard.Rows[r].Cells[c].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
             // Сбрасываем выделение
            dgvBoard.ClearSelection();
        }

        private void DgvBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (selectedRow == null) // Первый клик - выбор фигуры
            {
                Piece piece = game.Board[e.RowIndex, e.ColumnIndex];
                if (piece != null && piece.Color == game.CurrentPlayerColor)
                {
                    selectedRow = e.RowIndex;
                    selectedCol = e.ColumnIndex;
                    dgvBoard.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Gold; // Подсветка
                }
            }
            else // Второй клик - ход
            {
                int startR = selectedRow.Value;
                int startC = selectedCol.Value;
                int endR = e.RowIndex;
                int endC = e.ColumnIndex;

                selectedRow = null; // Сбрасываем выбор
                selectedCol = null;

                // Снимаем подсветку
                DrawBoard();

                if (startR == endR && startC == endC) return; // Клик по той же клетке - отмена выбора

                MoveResult result = game.MakeMove(startR, startC, endR, endC);

                // Обновляем доску после хода
                DrawBoard();

                // Обрабатываем результат хода
                ProcessMoveResult(result);
            }
        }

        private void ProcessMoveResult(MoveResult result)
        {
             string nextPlayer = game.WhiteTurn ? "белых" : "черных";
             string message = $"Ход {nextPlayer}";

             switch (result)
             {
                case MoveResult.InvalidMove:
                     message = "Неверный ход! " + message;
                     break;
                case MoveResult.KingInCheck:
                     message = "Так ходить нельзя, король под шахом! " + message;
                     break;
                case MoveResult.Check:
                     message = $"Шах! {message}";
                     break;
                case MoveResult.Checkmate:
                     message = $"МАТ! {(game.WhiteTurn ? "Черные" : "Белые")} победили!";
                     EndGame(message);
                     return;
             }
             UpdateStatusLabel(message);
        }

        private void UpdateStatusLabel(string text)
        {
            lblStatus.Text = text;
        }

        private void EndGame(string message)
        {
            UpdateStatusLabel(message);
            dgvBoard.Enabled = false;
        }
    }
}
