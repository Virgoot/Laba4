namespace Laba6
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnGuessGame = new System.Windows.Forms.Button();
            this.btnArrayProcessing = new System.Windows.Forms.Button();
            this.btnChess = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnGuessGame
            //
            this.btnGuessGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGuessGame.Location = new System.Drawing.Point(50, 30);
            this.btnGuessGame.Name = "btnGuessGame";
            this.btnGuessGame.Size = new System.Drawing.Size(280, 50);
            this.btnGuessGame.TabIndex = 0;
            this.btnGuessGame.Text = "Игра «Угадай ответ»";
            this.btnGuessGame.UseVisualStyleBackColor = true;
            this.btnGuessGame.Click += new System.EventHandler(this.btnGuessGame_Click);
            //
            // btnArrayProcessing
            //
            this.btnArrayProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArrayProcessing.Location = new System.Drawing.Point(50, 100);
            this.btnArrayProcessing.Name = "btnArrayProcessing";
            this.btnArrayProcessing.Size = new System.Drawing.Size(280, 50);
            this.btnArrayProcessing.TabIndex = 1;
            this.btnArrayProcessing.Text = "Работа с массивами";
            this.btnArrayProcessing.UseVisualStyleBackColor = true;
            this.btnArrayProcessing.Click += new System.EventHandler(this.btnArrayProcessing_Click);
            //
            // btnChess
            //
            this.btnChess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChess.Location = new System.Drawing.Point(50, 170);
            this.btnChess.Name = "btnChess";
            this.btnChess.Size = new System.Drawing.Size(280, 50);
            this.btnChess.TabIndex = 2;
            this.btnChess.Text = "Шахматы";
            this.btnChess.UseVisualStyleBackColor = true;
            this.btnChess.Click += new System.EventHandler(this.btnChess_Click);
            //
            // btnAuthor
            //
            this.btnAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAuthor.Location = new System.Drawing.Point(50, 240);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(280, 40);
            this.btnAuthor.TabIndex = 3;
            this.btnAuthor.Text = "Об авторе";
            this.btnAuthor.UseVisualStyleBackColor = true;
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            //
            // btnExit
            //
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(50, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(280, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnChess);
            this.Controls.Add(this.btnArrayProcessing);
            this.Controls.Add(this.btnGuessGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnGuessGame;
        private System.Windows.Forms.Button btnArrayProcessing;
        private System.Windows.Forms.Button btnChess;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnExit;
    }
}
