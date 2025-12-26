namespace Laba6
{
    partial class GuessTheFunctionForm
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
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblGuess = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.lblAttemptsInfo = new System.Windows.Forms.Label();
            this.numAttempts = new System.Windows.Forms.NumericUpDown();
            this.lblAttempts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAttempts)).BeginInit();
            this.SuspendLayout();
            //
            // lblFormula
            //
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFormula.Location = new System.Drawing.Point(30, 20);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(394, 25);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "f = sin²(3π/4 + a/3) + √cos(b)";
            //
            // lblA
            //
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblA.Location = new System.Drawing.Point(50, 70);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(101, 20);
            this.lblA.TabIndex = 1;
            this.lblA.Text = "Введите A:";
            //
            // txtA
            //
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtA.Location = new System.Drawing.Point(160, 67);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 26);
            this.txtA.TabIndex = 2;
            //
            // lblB
            //
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblB.Location = new System.Drawing.Point(50, 110);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(100, 20);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "Введите B:";
            //
            // txtB
            //
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB.Location = new System.Drawing.Point(160, 107);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 26);
            this.txtB.TabIndex = 4;
            //
            // btnCalculate
            //
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(280, 67);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(130, 66);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Вычислить";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            //
            // lblGuess
            //
            this.lblGuess.AutoSize = true;
            this.lblGuess.Enabled = false;
            this.lblGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGuess.Location = new System.Drawing.Point(50, 210);
            this.lblGuess.Name = "lblGuess";
            this.lblGuess.Size = new System.Drawing.Size(135, 20);
            this.lblGuess.TabIndex = 6;
            this.lblGuess.Text = "Угадайте ответ:";
            //
            // txtGuess
            //
            this.txtGuess.Enabled = false;
            this.txtGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtGuess.Location = new System.Drawing.Point(190, 207);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(100, 26);
            this.txtGuess.TabIndex = 7;
            //
            // btnGuess
            //
            this.btnGuess.Enabled = false;
            this.btnGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGuess.Location = new System.Drawing.Point(310, 204);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(100, 32);
            this.btnGuess.TabIndex = 8;
            this.btnGuess.Text = "Проверить";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            //
            // lblAttemptsInfo
            //
            this.lblAttemptsInfo.AutoSize = true;
            this.lblAttemptsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAttemptsInfo.Location = new System.Drawing.Point(50, 160);
            this.lblAttemptsInfo.Name = "lblAttemptsInfo";
            this.lblAttemptsInfo.Size = new System.Drawing.Size(180, 20);
            this.lblAttemptsInfo.TabIndex = 9;
            this.lblAttemptsInfo.Text = "Количество попыток:";
            //
            // numAttempts
            //
            this.numAttempts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numAttempts.Location = new System.Drawing.Point(240, 158);
            this.numAttempts.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAttempts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numAttempts.Name = "numAttempts";
            this.numAttempts.Size = new System.Drawing.Size(50, 26);
            this.numAttempts.TabIndex = 10;
            this.numAttempts.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.numAttempts.ValueChanged += new System.EventHandler(this.numAttempts_ValueChanged);
            //
            // lblAttempts
            //
            this.lblAttempts.AutoSize = true;
            this.lblAttempts.Enabled = false;
            this.lblAttempts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAttempts.Location = new System.Drawing.Point(50, 250);
            this.lblAttempts.Name = "lblAttempts";
            this.lblAttempts.Size = new System.Drawing.Size(189, 20);
            this.lblAttempts.TabIndex = 11;
            this.lblAttempts.Text = "Попыток осталось: 3";
            //
            // GuessTheFunctionForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 291);
            this.Controls.Add(this.lblAttempts);
            this.Controls.Add(this.numAttempts);
            this.Controls.Add(this.lblAttemptsInfo);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.lblGuess);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblFormula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuessTheFunctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Игра «Угадай ответ»";
            ((System.ComponentModel.ISupportInitialize)(this.numAttempts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblGuess;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Label lblAttemptsInfo;
        private System.Windows.Forms.NumericUpDown numAttempts;
        private System.Windows.Forms.Label lblAttempts;
    }
}
