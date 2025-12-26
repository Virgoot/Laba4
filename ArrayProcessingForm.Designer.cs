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
            this.dgvArray = new System.Windows.Forms.DataGridView();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.btnCreateCustom = new System.Windows.Forms.Button();
            this.btnCreateDefault = new System.Windows.Forms.Button();
            this.btnGenerateRandom = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnFindMinMax = new System.Windows.Forms.Button();
            this.btnCalculateAverage = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArray)).BeginInit();
            this.SuspendLayout();
            //
            // dgvArray
            //
            this.dgvArray.AllowUserToAddRows = false;
            this.dgvArray.AllowUserToDeleteRows = false;
            this.dgvArray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArray.Location = new System.Drawing.Point(12, 12);
            this.dgvArray.Name = "dgvArray";
            this.dgvArray.RowHeadersWidth = 51;
            this.dgvArray.RowTemplate.Height = 24;
            this.dgvArray.Size = new System.Drawing.Size(200, 426);
            this.dgvArray.TabIndex = 0;
            this.dgvArray.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArray_CellValueChanged);
            //
            // lblSize
            //
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSize.Location = new System.Drawing.Point(230, 20);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(147, 20);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Размер массива:";
            //
            // txtSize
            //
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSize.Location = new System.Drawing.Point(380, 17);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(70, 26);
            this.txtSize.TabIndex = 2;
            //
            // btnCreateCustom
            //
            this.btnCreateCustom.Location = new System.Drawing.Point(234, 50);
            this.btnCreateCustom.Name = "btnCreateCustom";
            this.btnCreateCustom.Size = new System.Drawing.Size(216, 30);
            this.btnCreateCustom.TabIndex = 3;
            this.btnCreateCustom.Text = "Создать";
            this.btnCreateCustom.UseVisualStyleBackColor = true;
            this.btnCreateCustom.Click += new System.EventHandler(this.btnCreateCustom_Click);
            //
            // btnCreateDefault
            //
            this.btnCreateDefault.Location = new System.Drawing.Point(234, 90);
            this.btnCreateDefault.Name = "btnCreateDefault";
            this.btnCreateDefault.Size = new System.Drawing.Size(216, 30);
            this.btnCreateDefault.TabIndex = 4;
            this.btnCreateDefault.Text = "Создать (по умолчанию)";
            this.btnCreateDefault.UseVisualStyleBackColor = true;
            this.btnCreateDefault.Click += new System.EventHandler(this.btnCreateDefault_Click);
            //
            // btnGenerateRandom
            //
            this.btnGenerateRandom.Location = new System.Drawing.Point(234, 130);
            this.btnGenerateRandom.Name = "btnGenerateRandom";
            this.btnGenerateRandom.Size = new System.Drawing.Size(216, 30);
            this.btnGenerateRandom.TabIndex = 5;
            this.btnGenerateRandom.Text = "Сгенерировать случайно";
            this.btnGenerateRandom.UseVisualStyleBackColor = true;
            this.btnGenerateRandom.Click += new System.EventHandler(this.btnGenerateRandom_Click);
            //
            // btnSort
            //
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSort.Location = new System.Drawing.Point(234, 200);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(216, 40);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            //
            // btnFindMinMax
            //
            this.btnFindMinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFindMinMax.Location = new System.Drawing.Point(234, 250);
            this.btnFindMinMax.Name = "btnFindMinMax";
            this.btnFindMinMax.Size = new System.Drawing.Size(216, 40);
            this.btnFindMinMax.TabIndex = 7;
            this.btnFindMinMax.Text = "Найти Мин/Макс";
            this.btnFindMinMax.UseVisualStyleBackColor = true;
            this.btnFindMinMax.Click += new System.EventHandler(this.btnFindMinMax_Click);
            //
            // btnCalculateAverage
            //
            this.btnCalculateAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculateAverage.Location = new System.Drawing.Point(234, 300);
            this.btnCalculateAverage.Name = "btnCalculateAverage";
            this.btnCalculateAverage.Size = new System.Drawing.Size(216, 40);
            this.btnCalculateAverage.TabIndex = 8;
            this.btnCalculateAverage.Text = "Среднее значение";
            this.btnCalculateAverage.UseVisualStyleBackColor = true;
            this.btnCalculateAverage.Click += new System.EventHandler(this.btnCalculateAverage_Click);
            //
            // lblResult
            //
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(230, 380);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(125, 25);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Результат:";
            //
            // ArrayProcessingForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCalculateAverage);
            this.Controls.Add(this.btnFindMinMax);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnGenerateRandom);
            this.Controls.Add(this.btnCreateDefault);
            this.Controls.Add(this.btnCreateCustom);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.dgvArray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArrayProcessingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Работа с массивами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArray)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
