namespace OS2List
{
    partial class SpravochElemTS
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
            this.TelesysComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModulComboBox = new System.Windows.Forms.ComboBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CommentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.WayToGetWeightTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CatalogNumberTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TelesysComboBox
            // 
            this.TelesysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TelesysComboBox.FormattingEnabled = true;
            this.TelesysComboBox.Items.AddRange(new object[] {
            "BAKER",
            "COMBO",
            "COILTRACK",
            "EGSS",
            "Другое"});
            this.TelesysComboBox.Location = new System.Drawing.Point(125, 13);
            this.TelesysComboBox.Name = "TelesysComboBox";
            this.TelesysComboBox.Size = new System.Drawing.Size(195, 21);
            this.TelesysComboBox.TabIndex = 0;
            this.TelesysComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Телесистема:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(386, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 380);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Модуль системы:";
            // 
            // ModulComboBox
            // 
            this.ModulComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModulComboBox.FormattingEnabled = true;
            this.ModulComboBox.Location = new System.Drawing.Point(125, 40);
            this.ModulComboBox.Name = "ModulComboBox";
            this.ModulComboBox.Size = new System.Drawing.Size(195, 21);
            this.ModulComboBox.TabIndex = 3;
            this.ModulComboBox.SelectedIndexChanged += new System.EventHandler(this.ModulComboBox_SelectedIndexChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(345, 416);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CatalogNumberTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CommentRichTextBox);
            this.groupBox1.Controls.Add(this.WayToGetWeightTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.WeightTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 234);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Примечание:";
            // 
            // CommentRichTextBox
            // 
            this.CommentRichTextBox.Location = new System.Drawing.Point(146, 102);
            this.CommentRichTextBox.Name = "CommentRichTextBox";
            this.CommentRichTextBox.ReadOnly = true;
            this.CommentRichTextBox.Size = new System.Drawing.Size(213, 121);
            this.CommentRichTextBox.TabIndex = 11;
            this.CommentRichTextBox.Text = "";
            // 
            // WayToGetWeightTextBox
            // 
            this.WayToGetWeightTextBox.Location = new System.Drawing.Point(146, 76);
            this.WayToGetWeightTextBox.Name = "WayToGetWeightTextBox";
            this.WayToGetWeightTextBox.ReadOnly = true;
            this.WayToGetWeightTextBox.Size = new System.Drawing.Size(213, 20);
            this.WayToGetWeightTextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Способ определения:";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Location = new System.Drawing.Point(146, 50);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.ReadOnly = true;
            this.WeightTextBox.Size = new System.Drawing.Size(213, 20);
            this.WeightTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Вес:";
            // 
            // CatalogNumberTextBox
            // 
            this.CatalogNumberTextBox.Location = new System.Drawing.Point(146, 24);
            this.CatalogNumberTextBox.Name = "CatalogNumberTextBox";
            this.CatalogNumberTextBox.ReadOnly = true;
            this.CatalogNumberTextBox.Size = new System.Drawing.Size(213, 20);
            this.CatalogNumberTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Каталожный номер:";
            // 
            // SpravochElemTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 448);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ModulComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TelesysComboBox);
            this.Name = "SpravochElemTS";
            this.Text = "Справочник по элементам ТС";
            this.Load += new System.EventHandler(this.SpravochElemTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox TelesysComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox ModulComboBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox CommentRichTextBox;
        private System.Windows.Forms.TextBox WayToGetWeightTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CatalogNumberTextBox;
        private System.Windows.Forms.Label label6;
    }
}