namespace OS2List
{
    partial class AddItemInTTNList
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
            this.ZavodNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ModulComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.WayToGetWeightTextBox = new System.Windows.Forms.TextBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.CloseDialogButton = new System.Windows.Forms.Button();
            this.ExistItemRadioButton = new System.Windows.Forms.RadioButton();
            this.NonExistItemRadioButton = new System.Windows.Forms.RadioButton();
            this.NonExistItemNameTextBox = new System.Windows.Forms.TextBox();
            this.SpravochnikButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PackageViewComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EdIzmerComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CatalogNumberTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).BeginInit();
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
            this.TelesysComboBox.Location = new System.Drawing.Point(165, 44);
            this.TelesysComboBox.Name = "TelesysComboBox";
            this.TelesysComboBox.Size = new System.Drawing.Size(252, 21);
            this.TelesysComboBox.TabIndex = 1;
            this.TelesysComboBox.SelectedIndexChanged += new System.EventHandler(this.TelesysComboBox_SelectedIndexChanged);
            // 
            // ZavodNumberTextBox
            // 
            this.ZavodNumberTextBox.Location = new System.Drawing.Point(165, 123);
            this.ZavodNumberTextBox.Name = "ZavodNumberTextBox";
            this.ZavodNumberTextBox.Size = new System.Drawing.Size(252, 20);
            this.ZavodNumberTextBox.TabIndex = 2;
            this.ZavodNumberTextBox.TextChanged += new System.EventHandler(this.ZavodNumberTextBox_TextChanged);
            this.ZavodNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZavodNumberTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Телесистема:";
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(40, 74);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(96, 13);
            this.ItemNameLabel.TabIndex = 5;
            this.ItemNameLabel.Text = "Модуль системы:";
            // 
            // ModulComboBox
            // 
            this.ModulComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModulComboBox.FormattingEnabled = true;
            this.ModulComboBox.Location = new System.Drawing.Point(165, 71);
            this.ModulComboBox.Name = "ModulComboBox";
            this.ModulComboBox.Size = new System.Drawing.Size(252, 21);
            this.ModulComboBox.TabIndex = 4;
            this.ModulComboBox.SelectedIndexChanged += new System.EventHandler(this.ModulComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Заводской номер:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // CountNumericUpDown
            // 
            this.CountNumericUpDown.Location = new System.Drawing.Point(165, 149);
            this.CountNumericUpDown.Name = "CountNumericUpDown";
            this.CountNumericUpDown.Size = new System.Drawing.Size(252, 20);
            this.CountNumericUpDown.TabIndex = 7;
            this.CountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Количество:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Масса груза:";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Enabled = false;
            this.WeightTextBox.Location = new System.Drawing.Point(165, 175);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.Size = new System.Drawing.Size(224, 20);
            this.WeightTextBox.TabIndex = 9;
            this.WeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WeightTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "кг.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Способ опредедления:";
            // 
            // WayToGetWeightTextBox
            // 
            this.WayToGetWeightTextBox.Enabled = false;
            this.WayToGetWeightTextBox.Location = new System.Drawing.Point(165, 201);
            this.WayToGetWeightTextBox.Name = "WayToGetWeightTextBox";
            this.WayToGetWeightTextBox.Size = new System.Drawing.Size(252, 20);
            this.WayToGetWeightTextBox.TabIndex = 13;
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(115, 299);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(75, 23);
            this.AddItemButton.TabIndex = 14;
            this.AddItemButton.Text = "Добавить";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.Location = new System.Drawing.Point(269, 299);
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CloseDialogButton.TabIndex = 15;
            this.CloseDialogButton.Text = "Закрыть";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Click += new System.EventHandler(this.CloseDialogButton_Click);
            // 
            // ExistItemRadioButton
            // 
            this.ExistItemRadioButton.AutoSize = true;
            this.ExistItemRadioButton.Location = new System.Drawing.Point(77, 12);
            this.ExistItemRadioButton.Name = "ExistItemRadioButton";
            this.ExistItemRadioButton.Size = new System.Drawing.Size(149, 17);
            this.ExistItemRadioButton.TabIndex = 16;
            this.ExistItemRadioButton.TabStop = true;
            this.ExistItemRadioButton.Text = "Существующий элемент";
            this.ExistItemRadioButton.UseVisualStyleBackColor = true;
            this.ExistItemRadioButton.CheckedChanged += new System.EventHandler(this.ExistItemRadioButton_CheckedChanged);
            // 
            // NonExistItemRadioButton
            // 
            this.NonExistItemRadioButton.AutoSize = true;
            this.NonExistItemRadioButton.Location = new System.Drawing.Point(269, 12);
            this.NonExistItemRadioButton.Name = "NonExistItemRadioButton";
            this.NonExistItemRadioButton.Size = new System.Drawing.Size(96, 17);
            this.NonExistItemRadioButton.TabIndex = 17;
            this.NonExistItemRadioButton.TabStop = true;
            this.NonExistItemRadioButton.Text = "Свой элемент";
            this.NonExistItemRadioButton.UseVisualStyleBackColor = true;
            this.NonExistItemRadioButton.CheckedChanged += new System.EventHandler(this.NonExistItemRadioButton_CheckedChanged);
            // 
            // NonExistItemNameTextBox
            // 
            this.NonExistItemNameTextBox.Location = new System.Drawing.Point(165, 71);
            this.NonExistItemNameTextBox.Name = "NonExistItemNameTextBox";
            this.NonExistItemNameTextBox.Size = new System.Drawing.Size(252, 20);
            this.NonExistItemNameTextBox.TabIndex = 18;
            this.NonExistItemNameTextBox.Visible = false;
            // 
            // SpravochnikButton
            // 
            this.SpravochnikButton.Location = new System.Drawing.Point(423, 69);
            this.SpravochnikButton.Name = "SpravochnikButton";
            this.SpravochnikButton.Size = new System.Drawing.Size(20, 23);
            this.SpravochnikButton.TabIndex = 19;
            this.SpravochnikButton.Text = "?";
            this.SpravochnikButton.UseVisualStyleBackColor = true;
            this.SpravochnikButton.Click += new System.EventHandler(this.SpravochnikButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Вид упаковки:";
            // 
            // PackageViewComboBox
            // 
            this.PackageViewComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PackageViewComboBox.FormattingEnabled = true;
            this.PackageViewComboBox.Items.AddRange(new object[] {
            "BACKER",
            "COMBO",
            "COILTRACK",
            "EGSS",
            "Другое"});
            this.PackageViewComboBox.Location = new System.Drawing.Point(165, 227);
            this.PackageViewComboBox.Name = "PackageViewComboBox";
            this.PackageViewComboBox.Size = new System.Drawing.Size(252, 21);
            this.PackageViewComboBox.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Ед. измерения:";
            // 
            // EdIzmerComboBox
            // 
            this.EdIzmerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EdIzmerComboBox.FormattingEnabled = true;
            this.EdIzmerComboBox.Items.AddRange(new object[] {
            "BACKER",
            "COMBO",
            "COILTRACK",
            "EGSS",
            "Другое"});
            this.EdIzmerComboBox.Location = new System.Drawing.Point(165, 254);
            this.EdIzmerComboBox.Name = "EdIzmerComboBox";
            this.EdIzmerComboBox.Size = new System.Drawing.Size(252, 21);
            this.EdIzmerComboBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Каталожный номер:";
            // 
            // CatalogNumberTextBox
            // 
            this.CatalogNumberTextBox.Enabled = false;
            this.CatalogNumberTextBox.Location = new System.Drawing.Point(165, 97);
            this.CatalogNumberTextBox.Name = "CatalogNumberTextBox";
            this.CatalogNumberTextBox.Size = new System.Drawing.Size(252, 20);
            this.CatalogNumberTextBox.TabIndex = 24;
            // 
            // AddItemInTTNList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 358);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CatalogNumberTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EdIzmerComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PackageViewComboBox);
            this.Controls.Add(this.SpravochnikButton);
            this.Controls.Add(this.NonExistItemNameTextBox);
            this.Controls.Add(this.NonExistItemRadioButton);
            this.Controls.Add(this.ExistItemRadioButton);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.WayToGetWeightTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.ModulComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ZavodNumberTextBox);
            this.Controls.Add(this.TelesysComboBox);
            this.Name = "AddItemInTTNList";
            this.Text = "Добавить элемент в ТТН";
            this.Load += new System.EventHandler(this.AddItemInTTNList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TelesysComboBox;
        private System.Windows.Forms.TextBox ZavodNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.ComboBox ModulComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CountNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WayToGetWeightTextBox;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button CloseDialogButton;
        private System.Windows.Forms.RadioButton ExistItemRadioButton;
        private System.Windows.Forms.RadioButton NonExistItemRadioButton;
        private System.Windows.Forms.TextBox NonExistItemNameTextBox;
        private System.Windows.Forms.Button SpravochnikButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PackageViewComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox EdIzmerComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CatalogNumberTextBox;
    }
}