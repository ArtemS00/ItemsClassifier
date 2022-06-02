
namespace ItemsClassifier
{
    partial class SetCategoryModal
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.shopCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.supplierCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(181, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 32);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 174);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 32);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Категория магазина";
            // 
            // shopCategoryComboBox
            // 
            this.shopCategoryComboBox.FormattingEnabled = true;
            this.shopCategoryComboBox.Location = new System.Drawing.Point(13, 32);
            this.shopCategoryComboBox.Name = "shopCategoryComboBox";
            this.shopCategoryComboBox.Size = new System.Drawing.Size(267, 23);
            this.shopCategoryComboBox.TabIndex = 5;
            // 
            // supplierCategoryComboBox
            // 
            this.supplierCategoryComboBox.FormattingEnabled = true;
            this.supplierCategoryComboBox.Location = new System.Drawing.Point(13, 79);
            this.supplierCategoryComboBox.Name = "supplierCategoryComboBox";
            this.supplierCategoryComboBox.Size = new System.Drawing.Size(267, 23);
            this.supplierCategoryComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Категория поставщика";
            // 
            // SetCategoryModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 218);
            this.Controls.Add(this.supplierCategoryComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shopCategoryComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "SetCategoryModal";
            this.Text = "SetCategoryModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox shopCategoryComboBox;
        private System.Windows.Forms.ComboBox supplierCategoryComboBox;
        private System.Windows.Forms.Label label2;
    }
}