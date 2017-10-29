namespace OS2List.Forms
{
    partial class HistoryMovement
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
            this.SentTTNDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrintTTNButton = new System.Windows.Forms.Button();
            this.ShowTTNButton = new System.Windows.Forms.Button();
            this.CreatedTTNDataGridView = new System.Windows.Forms.DataGridView();
            this.DataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberTTNColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderPartColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderFIOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderPermissionClolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverFIOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverCarNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverListNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedFIOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DetailsCreatedTTNDataGridView = new System.Windows.Forms.DataGridView();
            this.ModulNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZavodInventNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdIzmerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WayToGetWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedTTNDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsCreatedTTNDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SentTTNDateTimePicker
            // 
            this.SentTTNDateTimePicker.Location = new System.Drawing.Point(883, 12);
            this.SentTTNDateTimePicker.Name = "SentTTNDateTimePicker";
            this.SentTTNDateTimePicker.Size = new System.Drawing.Size(155, 20);
            this.SentTTNDateTimePicker.TabIndex = 0;
            this.SentTTNDateTimePicker.ValueChanged += new System.EventHandler(this.SentTTNDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата составления ТТН:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PrintTTNButton);
            this.groupBox1.Controls.Add(this.ShowTTNButton);
            this.groupBox1.Controls.Add(this.CreatedTTNDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 195);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Созданные ТТН:";
            // 
            // PrintTTNButton
            // 
            this.PrintTTNButton.Location = new System.Drawing.Point(871, 48);
            this.PrintTTNButton.Name = "PrintTTNButton";
            this.PrintTTNButton.Size = new System.Drawing.Size(149, 23);
            this.PrintTTNButton.TabIndex = 2;
            this.PrintTTNButton.Text = "Печать ТТН";
            this.PrintTTNButton.UseVisualStyleBackColor = true;
            // 
            // ShowTTNButton
            // 
            this.ShowTTNButton.Location = new System.Drawing.Point(871, 19);
            this.ShowTTNButton.Name = "ShowTTNButton";
            this.ShowTTNButton.Size = new System.Drawing.Size(149, 23);
            this.ShowTTNButton.TabIndex = 1;
            this.ShowTTNButton.Text = "Открыть ТТН в Excel";
            this.ShowTTNButton.UseVisualStyleBackColor = true;
            this.ShowTTNButton.Click += new System.EventHandler(this.ShowTTNButton_Click);
            // 
            // CreatedTTNDataGridView
            // 
            this.CreatedTTNDataGridView.AllowUserToAddRows = false;
            this.CreatedTTNDataGridView.AllowUserToDeleteRows = false;
            this.CreatedTTNDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CreatedTTNDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataColumn,
            this.NumberTTNColumn,
            this.SenderPartColumn,
            this.SenderFIOColumn,
            this.SenderPermissionClolumn,
            this.DriverFIOColumn,
            this.DriverCarNumberColumn,
            this.DriverListNumber,
            this.RequestedFIOColumn});
            this.CreatedTTNDataGridView.Location = new System.Drawing.Point(6, 19);
            this.CreatedTTNDataGridView.Name = "CreatedTTNDataGridView";
            this.CreatedTTNDataGridView.ReadOnly = true;
            this.CreatedTTNDataGridView.Size = new System.Drawing.Size(859, 170);
            this.CreatedTTNDataGridView.TabIndex = 0;
            this.CreatedTTNDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CreatedTTNDataGridView_CellClick);
            // 
            // DataColumn
            // 
            this.DataColumn.HeaderText = "Дата отправки";
            this.DataColumn.Name = "DataColumn";
            this.DataColumn.ReadOnly = true;
            // 
            // NumberTTNColumn
            // 
            this.NumberTTNColumn.HeaderText = "Номер ТТН";
            this.NumberTTNColumn.Name = "NumberTTNColumn";
            this.NumberTTNColumn.ReadOnly = true;
            // 
            // SenderPartColumn
            // 
            this.SenderPartColumn.HeaderText = "Партия-отправитель";
            this.SenderPartColumn.Name = "SenderPartColumn";
            this.SenderPartColumn.ReadOnly = true;
            this.SenderPartColumn.Width = 120;
            // 
            // SenderFIOColumn
            // 
            this.SenderFIOColumn.HeaderText = "ФИО отправителя";
            this.SenderFIOColumn.Name = "SenderFIOColumn";
            this.SenderFIOColumn.ReadOnly = true;
            // 
            // SenderPermissionClolumn
            // 
            this.SenderPermissionClolumn.HeaderText = "Разрешил отправление";
            this.SenderPermissionClolumn.Name = "SenderPermissionClolumn";
            this.SenderPermissionClolumn.ReadOnly = true;
            // 
            // DriverFIOColumn
            // 
            this.DriverFIOColumn.HeaderText = "ФИО водителя";
            this.DriverFIOColumn.Name = "DriverFIOColumn";
            this.DriverFIOColumn.ReadOnly = true;
            // 
            // DriverCarNumberColumn
            // 
            this.DriverCarNumberColumn.HeaderText = "Номер машины водителя";
            this.DriverCarNumberColumn.Name = "DriverCarNumberColumn";
            this.DriverCarNumberColumn.ReadOnly = true;
            // 
            // DriverListNumber
            // 
            this.DriverListNumber.HeaderText = "Номер путевого листа";
            this.DriverListNumber.Name = "DriverListNumber";
            this.DriverListNumber.ReadOnly = true;
            // 
            // RequestedFIOColumn
            // 
            this.RequestedFIOColumn.HeaderText = "ФИО затребовавшего";
            this.RequestedFIOColumn.Name = "RequestedFIOColumn";
            this.RequestedFIOColumn.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DetailsCreatedTTNDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1026, 234);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отправленное оборудование согласно ТТН:";
            // 
            // DetailsCreatedTTNDataGridView
            // 
            this.DetailsCreatedTTNDataGridView.AllowUserToAddRows = false;
            this.DetailsCreatedTTNDataGridView.AllowUserToDeleteRows = false;
            this.DetailsCreatedTTNDataGridView.AllowUserToOrderColumns = true;
            this.DetailsCreatedTTNDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailsCreatedTTNDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModulNameColumn,
            this.ZavodInventNumber,
            this.CountColumn,
            this.EdIzmerColumn,
            this.PackageColumn,
            this.WeightColumn,
            this.WayToGetWeightColumn});
            this.DetailsCreatedTTNDataGridView.Location = new System.Drawing.Point(6, 19);
            this.DetailsCreatedTTNDataGridView.Name = "DetailsCreatedTTNDataGridView";
            this.DetailsCreatedTTNDataGridView.Size = new System.Drawing.Size(1014, 209);
            this.DetailsCreatedTTNDataGridView.TabIndex = 1;
            // 
            // ModulNameColumn
            // 
            this.ModulNameColumn.HeaderText = "Наименование оборудования";
            this.ModulNameColumn.Name = "ModulNameColumn";
            this.ModulNameColumn.ReadOnly = true;
            this.ModulNameColumn.Width = 250;
            // 
            // ZavodInventNumber
            // 
            this.ZavodInventNumber.HeaderText = "Заводской/Инвентарный номер";
            this.ZavodInventNumber.Name = "ZavodInventNumber";
            this.ZavodInventNumber.ReadOnly = true;
            this.ZavodInventNumber.Width = 150;
            // 
            // CountColumn
            // 
            this.CountColumn.HeaderText = "Количество, шт";
            this.CountColumn.Name = "CountColumn";
            this.CountColumn.ReadOnly = true;
            // 
            // EdIzmerColumn
            // 
            this.EdIzmerColumn.HeaderText = "Ед. измерения";
            this.EdIzmerColumn.Name = "EdIzmerColumn";
            this.EdIzmerColumn.ReadOnly = true;
            // 
            // PackageColumn
            // 
            this.PackageColumn.HeaderText = "Вид упаковки";
            this.PackageColumn.Name = "PackageColumn";
            this.PackageColumn.ReadOnly = true;
            this.PackageColumn.Width = 130;
            // 
            // WeightColumn
            // 
            this.WeightColumn.HeaderText = "Вес, кг";
            this.WeightColumn.Name = "WeightColumn";
            this.WeightColumn.ReadOnly = true;
            // 
            // WayToGetWeightColumn
            // 
            this.WayToGetWeightColumn.HeaderText = "Способ определения массы";
            this.WayToGetWeightColumn.Name = "WayToGetWeightColumn";
            this.WayToGetWeightColumn.ReadOnly = true;
            this.WayToGetWeightColumn.Width = 140;
            // 
            // HistoryMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 497);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SentTTNDateTimePicker);
            this.Name = "HistoryMovement";
            this.Text = "История товарно-транспортных накладных";
            this.Load += new System.EventHandler(this.HistoryMovement_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreatedTTNDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailsCreatedTTNDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker SentTTNDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PrintTTNButton;
        private System.Windows.Forms.Button ShowTTNButton;
        private System.Windows.Forms.DataGridView CreatedTTNDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DetailsCreatedTTNDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberTTNColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderPartColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderFIOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderPermissionClolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverFIOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverCarNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverListNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedFIOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModulNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZavodInventNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdIzmerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WayToGetWeightColumn;
    }
}