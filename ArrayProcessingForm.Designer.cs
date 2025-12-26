namespace Laba6
{
    partial class ArrayProcessingForm
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
            dgvArray = new DataGridView();
            lblSize = new Label();
            txtSize = new TextBox();
            btnCreateCustom = new Button();
            btnCreateDefault = new Button();
            btnGenerateRandom = new Button();
            btnSort = new Button();
            btnFindMinMax = new Button();
            btnCalculateAverage = new Button();
            lblResult = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvArray).BeginInit();
            SuspendLayout();
            // 
            // dgvArray
            // 
            dgvArray.AllowUserToAddRows = false;
            dgvArray.AllowUserToDeleteRows = false;
            dgvArray.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArray.Location = new Point(12, 15);
            dgvArray.Margin = new Padding(3, 4, 3, 4);
            dgvArray.Name = "dgvArray";
            dgvArray.RowHeadersWidth = 51;
            dgvArray.RowTemplate.Height = 24;
            dgvArray.Size = new Size(200, 532);
            dgvArray.TabIndex = 0;
            dgvArray.CellValueChanged += dgvArray_CellValueChanged;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSize.Location = new Point(230, 25);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(151, 20);
            lblSize.TabIndex = 1;
            lblSize.Text = "Размер массива:";
            // 
            // txtSize
            // 
            txtSize.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSize.Location = new Point(380, 21);
            txtSize.Margin = new Padding(3, 4, 3, 4);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(70, 26);
            txtSize.TabIndex = 2;
            // 
            // btnCreateCustom
            // 
            btnCreateCustom.Location = new Point(234, 62);
            btnCreateCustom.Margin = new Padding(3, 4, 3, 4);
            btnCreateCustom.Name = "btnCreateCustom";
            btnCreateCustom.Size = new Size(216, 38);
            btnCreateCustom.TabIndex = 3;
            btnCreateCustom.Text = "Создать";
            btnCreateCustom.UseVisualStyleBackColor = true;
            btnCreateCustom.Click += btnCreateCustom_Click;
            // 
            // btnCreateDefault
            // 
            btnCreateDefault.Location = new Point(234, 112);
            btnCreateDefault.Margin = new Padding(3, 4, 3, 4);
            btnCreateDefault.Name = "btnCreateDefault";
            btnCreateDefault.Size = new Size(216, 38);
            btnCreateDefault.TabIndex = 4;
            btnCreateDefault.Text = "Создать (по умолчанию)";
            btnCreateDefault.UseVisualStyleBackColor = true;
            btnCreateDefault.Click += btnCreateDefault_Click;
            // 
            // btnGenerateRandom
            // 
            btnGenerateRandom.Location = new Point(234, 162);
            btnGenerateRandom.Margin = new Padding(3, 4, 3, 4);
            btnGenerateRandom.Name = "btnGenerateRandom";
            btnGenerateRandom.Size = new Size(216, 38);
            btnGenerateRandom.TabIndex = 5;
            btnGenerateRandom.Text = "Сгенерировать случайно";
            btnGenerateRandom.UseVisualStyleBackColor = true;
            btnGenerateRandom.Click += btnGenerateRandom_Click;
            // 
            // btnSort
            // 
            btnSort.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSort.Location = new Point(234, 250);
            btnSort.Margin = new Padding(3, 4, 3, 4);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(216, 50);
            btnSort.TabIndex = 6;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // btnFindMinMax
            // 
            btnFindMinMax.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnFindMinMax.Location = new Point(234, 312);
            btnFindMinMax.Margin = new Padding(3, 4, 3, 4);
            btnFindMinMax.Name = "btnFindMinMax";
            btnFindMinMax.Size = new Size(216, 50);
            btnFindMinMax.TabIndex = 7;
            btnFindMinMax.Text = "Найти Мин/Макс";
            btnFindMinMax.UseVisualStyleBackColor = true;
            btnFindMinMax.Click += btnFindMinMax_Click;
            // 
            // btnCalculateAverage
            // 
            btnCalculateAverage.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCalculateAverage.Location = new Point(234, 375);
            btnCalculateAverage.Margin = new Padding(3, 4, 3, 4);
            btnCalculateAverage.Name = "btnCalculateAverage";
            btnCalculateAverage.Size = new Size(216, 50);
            btnCalculateAverage.TabIndex = 8;
            btnCalculateAverage.Text = "Среднее значение";
            btnCalculateAverage.UseVisualStyleBackColor = true;
            btnCalculateAverage.Click += btnCalculateAverage_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblResult.Location = new Point(230, 475);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(127, 25);
            lblResult.TabIndex = 9;
            lblResult.Text = "Результат:";
            // 
            // ArrayProcessingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 566);
            Controls.Add(lblResult);
            Controls.Add(btnCalculateAverage);
            Controls.Add(btnFindMinMax);
            Controls.Add(btnSort);
            Controls.Add(btnGenerateRandom);
            Controls.Add(btnCreateDefault);
            Controls.Add(btnCreateCustom);
            Controls.Add(txtSize);
            Controls.Add(lblSize);
            Controls.Add(dgvArray);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ArrayProcessingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Работа с массивами";
            ((System.ComponentModel.ISupportInitialize)dgvArray).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArray;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Button btnCreateCustom;
        private System.Windows.Forms.Button btnCreateDefault;
        private System.Windows.Forms.Button btnGenerateRandom;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnFindMinMax;
        private System.Windows.Forms.Button btnCalculateAverage;
        private System.Windows.Forms.Label lblResult;
    }
}
