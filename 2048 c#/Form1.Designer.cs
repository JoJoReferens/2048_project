namespace _2048_c_
{
    partial class game
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScoreCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScoreCount
            // 
            this.ScoreCount.AutoSize = true;
            this.ScoreCount.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreCount.Location = new System.Drawing.Point(24, 43);
            this.ScoreCount.Name = "ScoreCount";
            this.ScoreCount.Size = new System.Drawing.Size(91, 25);
            this.ScoreCount.TabIndex = 16;
            this.ScoreCount.Text = "SCORE: 0";
            this.ScoreCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 338);
            this.Controls.Add(this.ScoreCount);
            this.Name = "Form1";
            this.Text = "2048";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ScoreCount;
    }
}

