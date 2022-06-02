
namespace ItemsClassifier
{
    partial class ModelPredictModal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.csvFilePathLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.separatorTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.modelPathLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Распределение элементов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Файл с элементами для распределения (csv)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectCsvFile_Click);
            // 
            // csvFilePathLabel
            // 
            this.csvFilePathLabel.AutoSize = true;
            this.csvFilePathLabel.Location = new System.Drawing.Point(93, 75);
            this.csvFilePathLabel.Name = "csvFilePathLabel";
            this.csvFilePathLabel.Size = new System.Drawing.Size(74, 15);
            this.csvFilePathLabel.TabIndex = 4;
            this.csvFilePathLabel.Text = "Не выбрано";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Разделитель";
            // 
            // separatorTextBox
            // 
            this.separatorTextBox.Location = new System.Drawing.Point(12, 125);
            this.separatorTextBox.Name = "separatorTextBox";
            this.separatorTextBox.PlaceholderText = "Введите разделитель выбранного csv файла...";
            this.separatorTextBox.Size = new System.Drawing.Size(260, 23);
            this.separatorTextBox.TabIndex = 6;
            // 
            // saveModelPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(93, 243);
            this.outputPathLabel.Name = "saveModelPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(74, 15);
            this.outputPathLabel.TabIndex = 10;
            this.outputPathLabel.Text = "Не выбрано";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectOutputPath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Сохранить результат в";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = " ";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(136, 287);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(114, 26);
            this.button3.TabIndex = 11;
            this.button3.Text = "Распределить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // label4
            // 
            this.modelPathLabel.AutoSize = true;
            this.modelPathLabel.Location = new System.Drawing.Point(93, 186);
            this.modelPathLabel.Name = "label4";
            this.modelPathLabel.Size = new System.Drawing.Size(74, 15);
            this.modelPathLabel.TabIndex = 15;
            this.modelPathLabel.Text = "Не выбрано";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Выбрать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.selectModelPath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Путь к обученной модели";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = " ";
            // 
            // ModelPredictModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 325);
            this.Controls.Add(this.modelPathLabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.outputPathLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.separatorTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.csvFilePathLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModelPredictModal";
            this.Text = "ModelLearnModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label csvFilePathLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox separatorTextBox;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label modelPathLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
    }
}