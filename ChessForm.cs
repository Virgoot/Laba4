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
            InitializeComponent();
            InitializeGameComponents();
            StartNewGame();
        }

        private void InitializeGameComponents()
        {
            // 1. Создаём и настраиваем DataGridView
            dgvBoard = new DataGridView();
            dgvBoard.Location = new Point(15, 15);
            dgvBoard.Name = "dgvBoard";
            dgvBoard.Size = new Size(532, 502);
            dgvBoard.AllowUserToAddRows = false;
            dgvBoard.AllowUserToDeleteRows = false;
            dgvBoard.AllowUserToResizeColumns = false;
            dgvBoard.AllowUserToResizeRows = false;
            dgvBoard.ReadOnly = true;
            dgvBoard.ScrollBars = ScrollBars.None;
            dgvBoard.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvBoard.MultiSelect = false;

            // 2. Устанавливаем количество строк и столбцов
            dgvBoard.ColumnCount = 8;
            dgvBoard.RowCount = 8;

            // 3. Теперь, когда строки и столбцы существуют, настраиваем их
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
                Location = new Point(15, 530),
                Name = "lblStatus",
                Size = new Size(360, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                Text = "Ход белых"
            };

            // Настройка Button
            btnNewGame = new Button
            {
                Location = new Point(377, 530),
                Name = "btnNewGame",
                Size = new Size(140, 30),
                Text = "Новая игра",
                UseVisualStyleBackColor = true
            };
            btnNewGame.Click += (sender, e) => StartNewGame();

            // 4. Добавляем всё на форму
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
                    dgvBoard.Rows[r].Cells[c].Style.BackColor = (r + c) % 2 == 0 ? Color.LightGray : Color.DimGray;

                    Piece piece = game.Board[r, c];
                    dgvBoard.Rows[r].Cells[c].Value = piece?.Symbol ?? ' ';

                    dgvBoard.Rows[r].Cells[c].Style.Font = new Font("Arial", 24F, FontStyle.Bold);
                    dgvBoard.Rows[r].Cells[c].Style.ForeColor = piece?.Color == "White" ? Color.White : Color.Black;
                    dgvBoard.Rows[r].Cells[c].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            dgvBoard.ClearSelection();
        }

        private void DgvBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (selectedRow == null)
            {
                Piece piece = game.Board[e.RowIndex, e.ColumnIndex];
                if (piece != null && piece.Color == game.CurrentPlayerColor)
                {
                    selectedRow = e.RowIndex;
                    selectedCol = e.ColumnIndex;
                    dgvBoard.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Gold;
                }
            }
            else
            {
                int startR = selectedRow.Value;
                int startC = selectedCol.Value;
                int endR = e.RowIndex;
                int endC = e.ColumnIndex;

                selectedRow = null;
                selectedCol = null;

                DrawBoard();

                if (startR == endR && startC == endC) return;

                MoveResult result = game.MakeMove(startR, startC, endR, endC);

                DrawBoard();

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
