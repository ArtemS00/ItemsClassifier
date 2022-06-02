
namespace ItemsClassifier
{
    partial class ItemsClassificationModal
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.classificationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.criticalValueTextBox = new System.Windows.Forms.TextBox();
            this.criticalValueLabel = new System.Windows.Forms.Label();
            this.behaviorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.separatorTextBox = new System.Windows.Forms.TextBox();
            this.csvFilePathLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.distributeItemsButton = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.setCategoryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 483);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.classificationTypeComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.settingsGroupBox);
            this.panel1.Controls.Add(this.separatorTextBox);
            this.panel1.Controls.Add(this.csvFilePathLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.selectFileButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.distributeItemsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 483);
            this.panel1.TabIndex = 0;
            // 
            // classificationTypeComboBox
            // 
            this.classificationTypeComboBox.FormattingEnabled = true;
            this.classificationTypeComboBox.Location = new System.Drawing.Point(12, 133);
            this.classificationTypeComboBox.Name = "classificationTypeComboBox";
            this.classificationTypeComboBox.Size = new System.Drawing.Size(253, 23);
            this.classificationTypeComboBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип распределения";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.criticalValueTextBox);
            this.settingsGroupBox.Controls.Add(this.criticalValueLabel);
            this.settingsGroupBox.Controls.Add(this.behaviorTypeComboBox);
            this.settingsGroupBox.Controls.Add(this.label1);
            this.settingsGroupBox.Location = new System.Drawing.Point(9, 165);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(263, 136);
            this.settingsGroupBox.TabIndex = 9;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Настройки распределения";
            this.settingsGroupBox.Visible = false;
            // 
            // criticalValueTextBox
            // 
            this.criticalValueTextBox.Location = new System.Drawing.Point(6, 97);
            this.criticalValueTextBox.Name = "criticalValueTextBox";
            this.criticalValueTextBox.Size = new System.Drawing.Size(251, 23);
            this.criticalValueTextBox.TabIndex = 3;
            // 
            // criticalValueLabel
            // 
            this.criticalValueLabel.AutoSize = true;
            this.criticalValueLabel.Location = new System.Drawing.Point(6, 79);
            this.criticalValueLabel.Name = "criticalValueLabel";
            this.criticalValueLabel.Size = new System.Drawing.Size(132, 15);
            this.criticalValueLabel.TabIndex = 2;
            this.criticalValueLabel.Text = "Критическое значение";
            // 
            // behaviorTypeComboBox
            // 
            this.behaviorTypeComboBox.FormattingEnabled = true;
            this.behaviorTypeComboBox.Location = new System.Drawing.Point(6, 42);
            this.behaviorTypeComboBox.Name = "behaviorTypeComboBox";
            this.behaviorTypeComboBox.Size = new System.Drawing.Size(250, 23);
            this.behaviorTypeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поведение при спорных категориях";
            // 
            // separatorTextBox
            // 
            this.separatorTextBox.Location = new System.Drawing.Point(12, 84);
            this.separatorTextBox.Name = "separatorTextBox";
            this.separatorTextBox.PlaceholderText = "Введите разделитель выбранного csv файла...";
            this.separatorTextBox.Size = new System.Drawing.Size(253, 23);
            this.separatorTextBox.TabIndex = 8;
            // 
            // csvFilePathLabel
            // 
            this.csvFilePathLabel.AutoSize = true;
            this.csvFilePathLabel.Location = new System.Drawing.Point(93, 31);
            this.csvFilePathLabel.Name = "csvFilePathLabel";
            this.csvFilePathLabel.Size = new System.Drawing.Size(74, 15);
            this.csvFilePathLabel.TabIndex = 8;
            this.csvFilePathLabel.Text = "Не выбрано";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Разделитель";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(12, 27);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton.TabIndex = 7;
            this.selectFileButton.Text = "Выбрать";
            this.selectFileButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Файл с элементами для распределения (csv)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = " ";
            // 
            // saveButton
            // 
            this.distributeItemsButton.Location = new System.Drawing.Point(54, 438);
            this.distributeItemsButton.Name = "saveButton";
            this.distributeItemsButton.Size = new System.Drawing.Size(168, 33);
            this.distributeItemsButton.TabIndex = 2;
            this.distributeItemsButton.Text = "Распределить";
            this.distributeItemsButton.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.Size = new System.Drawing.Size(902, 483);
            this.dataGrid.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.setCategoryButton);
            this.panel2.Controls.Add(this.addCategoryButton);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.filterLabel);
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 483);
            this.panel2.TabIndex = 12;
            // 
            // saveToFileButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 438);
            this.saveButton.Name = "saveToFileButton";
            this.saveButton.Size = new System.Drawing.Size(101, 32);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(164, 438);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 32);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(15, 13);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(122, 15);
            this.filterLabel.TabIndex = 2;
            this.filterLabel.Text = "Фильтр по названию";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 23);
            this.textBox1.TabIndex = 3;
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(15, 66);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(250, 30);
            this.addCategoryButton.TabIndex = 4;
            this.addCategoryButton.Text = "Добавить категорию магазина";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            // 
            // setCategoryButton
            // 
            this.setCategoryButton.Location = new System.Drawing.Point(15, 106);
            this.setCategoryButton.Name = "setCategoryButton";
            this.setCategoryButton.Size = new System.Drawing.Size(250, 40);
            this.setCategoryButton.TabIndex = 5;
            this.setCategoryButton.Text = "Установить категорию магазина для категории поставщика";
            this.setCategoryButton.UseVisualStyleBackColor = true;
            // 
            // ItemsClassificationModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 483);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ItemsClassificationModal";
            this.Text = "ItemsClassificationModal";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button distributeItemsButton;
        private System.Windows.Forms.Label csvFilePathLabel;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox separatorTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox classificationTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox criticalValueTextBox;
        private System.Windows.Forms.Label criticalValueLabel;
        private System.Windows.Forms.ComboBox behaviorTypeComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button setCategoryButton;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}