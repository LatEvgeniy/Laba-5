
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btBuy = new System.Windows.Forms.Button();
            this.NumUpDownSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSell = new System.Windows.Forms.Button();
            this.lbProducts = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // btBuy
            // 
            this.btBuy.Location = new System.Drawing.Point(464, 79);
            this.btBuy.Name = "btBuy";
            this.btBuy.Size = new System.Drawing.Size(157, 38);
            this.btBuy.TabIndex = 0;
            this.btBuy.Text = "Запуск потоку переобліку";
            this.btBuy.UseVisualStyleBackColor = true;
            // 
            // NumUpDownSeconds
            // 
            this.NumUpDownSeconds.Location = new System.Drawing.Point(464, 53);
            this.NumUpDownSeconds.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDownSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownSeconds.Name = "NumUpDownSeconds";
            this.NumUpDownSeconds.Size = new System.Drawing.Size(29, 20);
            this.NumUpDownSeconds.TabIndex = 4;
            this.NumUpDownSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Час на протязі якого магазин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "поповнюється товарами (сек)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "зі швидкістью: 1 товар / сек";
            // 
            // btSell
            // 
            this.btSell.Location = new System.Drawing.Point(462, 169);
            this.btSell.Name = "btSell";
            this.btSell.Size = new System.Drawing.Size(157, 38);
            this.btSell.TabIndex = 8;
            this.btSell.Text = "Запуск потоку дій покупців";
            this.btSell.UseVisualStyleBackColor = true;
            // 
            // lbProducts
            // 
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.Location = new System.Drawing.Point(12, 9);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(444, 199);
            this.lbProducts.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 219);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.btSell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumUpDownSeconds);
            this.Controls.Add(this.btBuy);
            this.Name = "Form1";
            this.Text = "Магазин телефонів";
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBuy;
        private System.Windows.Forms.NumericUpDown NumUpDownSeconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSell;
        private System.Windows.Forms.ListBox lbProducts;
    }
}

