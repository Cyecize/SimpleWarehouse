namespace SimpleWarehouse.Forms
{
    partial class RevenueForm
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRevised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddRevenueBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RevenueAmountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimeForRevenue = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.GoBackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new MaterialSkin.Controls.MaterialLabel();
            this.RevisedStartDate = new System.Windows.Forms.DateTimePicker();
            this.RevisedEndDate = new System.Windows.Forms.DateTimePicker();
            this.FindArchivedRevenues = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ArchivedRevenuesTable = new System.Windows.Forms.DataGridView();
            this.UsernameArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRevisedArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalAmountBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalRowsBox = new System.Windows.Forms.TextBox();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedRevenuesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 113);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(676, 288);
            this.materialTabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataTableView);
            this.tabPage1.Controls.Add(this.AddRevenueBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RevenueAmountBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DateTimeForRevenue);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавяне на оборот";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataTableView
            // 
            this.DataTableView.AllowUserToAddRows = false;
            this.DataTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Amount,
            this.Date,
            this.IsRevised});
            this.DataTableView.Location = new System.Drawing.Point(7, 6);
            this.DataTableView.MultiSelect = false;
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTableView.Size = new System.Drawing.Size(655, 199);
            this.DataTableView.TabIndex = 29;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.HeaderText = "Потр. име";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Сума";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 206;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // IsRevised
            // 
            this.IsRevised.HeaderText = "Ревизиран";
            this.IsRevised.Name = "IsRevised";
            this.IsRevised.ReadOnly = true;
            // 
            // AddRevenueBtn
            // 
            this.AddRevenueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddRevenueBtn.Location = new System.Drawing.Point(356, 233);
            this.AddRevenueBtn.Name = "AddRevenueBtn";
            this.AddRevenueBtn.Size = new System.Drawing.Size(88, 23);
            this.AddRevenueBtn.TabIndex = 28;
            this.AddRevenueBtn.Text = "Добави";
            this.AddRevenueBtn.UseVisualStyleBackColor = true;
            this.AddRevenueBtn.Click += new System.EventHandler(this.AddRevenueBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Сума:";
            // 
            // RevenueAmountBox
            // 
            this.RevenueAmountBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevenueAmountBox.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RevenueAmountBox.Location = new System.Drawing.Point(240, 233);
            this.RevenueAmountBox.Name = "RevenueAmountBox";
            this.RevenueAmountBox.Size = new System.Drawing.Size(110, 22);
            this.RevenueAmountBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Дата:";
            // 
            // DateTimeForRevenue
            // 
            this.DateTimeForRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimeForRevenue.CalendarFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeForRevenue.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeForRevenue.Location = new System.Drawing.Point(6, 233);
            this.DateTimeForRevenue.Name = "DateTimeForRevenue";
            this.DateTimeForRevenue.Size = new System.Drawing.Size(228, 23);
            this.DateTimeForRevenue.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TotalRowsBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TotalAmountBox);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ArchivedRevenuesTable);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.FindArchivedRevenues);
            this.tabPage2.Controls.Add(this.RevisedEndDate);
            this.tabPage2.Controls.Add(this.RevisedStartDate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(668, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Архив";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-2, 59);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(707, 48);
            this.materialTabSelector1.TabIndex = 27;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBackBtn.AutoSize = true;
            this.GoBackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoBackBtn.Depth = 0;
            this.GoBackBtn.Icon = null;
            this.GoBackBtn.Location = new System.Drawing.Point(620, 410);
            this.GoBackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GoBackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Primary = false;
            this.GoBackBtn.Size = new System.Drawing.Size(68, 36);
            this.GoBackBtn.TabIndex = 28;
            this.GoBackBtn.Text = "Назад";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogLabel.BackColor = System.Drawing.SystemColors.Window;
            this.LogLabel.Depth = 0;
            this.LogLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.LogLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogLabel.Location = new System.Drawing.Point(12, 404);
            this.LogLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(448, 30);
            this.LogLabel.TabIndex = 42;
            // 
            // RevisedStartDate
            // 
            this.RevisedStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisedStartDate.Location = new System.Drawing.Point(6, 236);
            this.RevisedStartDate.Name = "RevisedStartDate";
            this.RevisedStartDate.Size = new System.Drawing.Size(200, 20);
            this.RevisedStartDate.TabIndex = 0;
            // 
            // RevisedEndDate
            // 
            this.RevisedEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisedEndDate.Location = new System.Drawing.Point(212, 236);
            this.RevisedEndDate.Name = "RevisedEndDate";
            this.RevisedEndDate.Size = new System.Drawing.Size(200, 20);
            this.RevisedEndDate.TabIndex = 1;
            // 
            // FindArchivedRevenues
            // 
            this.FindArchivedRevenues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindArchivedRevenues.Location = new System.Drawing.Point(418, 236);
            this.FindArchivedRevenues.Name = "FindArchivedRevenues";
            this.FindArchivedRevenues.Size = new System.Drawing.Size(75, 20);
            this.FindArchivedRevenues.TabIndex = 2;
            this.FindArchivedRevenues.Text = "Търсене";
            this.FindArchivedRevenues.UseVisualStyleBackColor = true;
            this.FindArchivedRevenues.Click += new System.EventHandler(this.FindArchivedRevenues_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Начална дата:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "Крайна дата:";
            // 
            // ArchivedRevenuesTable
            // 
            this.ArchivedRevenuesTable.AllowUserToAddRows = false;
            this.ArchivedRevenuesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArchivedRevenuesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArchivedRevenuesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsernameArch,
            this.AmountArch,
            this.DateArch,
            this.IsRevisedArch});
            this.ArchivedRevenuesTable.Location = new System.Drawing.Point(6, 6);
            this.ArchivedRevenuesTable.MultiSelect = false;
            this.ArchivedRevenuesTable.Name = "ArchivedRevenuesTable";
            this.ArchivedRevenuesTable.ReadOnly = true;
            this.ArchivedRevenuesTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ArchivedRevenuesTable.Size = new System.Drawing.Size(656, 180);
            this.ArchivedRevenuesTable.TabIndex = 30;
            // 
            // UsernameArch
            // 
            this.UsernameArch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UsernameArch.HeaderText = "Потр. име";
            this.UsernameArch.Name = "UsernameArch";
            this.UsernameArch.ReadOnly = true;
            // 
            // AmountArch
            // 
            this.AmountArch.HeaderText = "Сума";
            this.AmountArch.Name = "AmountArch";
            this.AmountArch.ReadOnly = true;
            this.AmountArch.Width = 206;
            // 
            // DateArch
            // 
            this.DateArch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateArch.HeaderText = "Дата";
            this.DateArch.Name = "DateArch";
            this.DateArch.ReadOnly = true;
            // 
            // IsRevisedArch
            // 
            this.IsRevisedArch.HeaderText = "Ревизиран";
            this.IsRevisedArch.Name = "IsRevisedArch";
            this.IsRevisedArch.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 31;
            this.label5.Text = "Общо:";
            // 
            // TotalAmountBox
            // 
            this.TotalAmountBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalAmountBox.Enabled = false;
            this.TotalAmountBox.Location = new System.Drawing.Point(581, 192);
            this.TotalAmountBox.Name = "TotalAmountBox";
            this.TotalAmountBox.ReadOnly = true;
            this.TotalAmountBox.Size = new System.Drawing.Size(80, 20);
            this.TotalAmountBox.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(316, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 22);
            this.label6.TabIndex = 33;
            this.label6.Text = "Брой на записи:";
            // 
            // TotalRowsBox
            // 
            this.TotalRowsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalRowsBox.Enabled = false;
            this.TotalRowsBox.Location = new System.Drawing.Point(456, 192);
            this.TotalRowsBox.Name = "TotalRowsBox";
            this.TotalRowsBox.ReadOnly = true;
            this.TotalRowsBox.Size = new System.Drawing.Size(37, 20);
            this.TotalRowsBox.TabIndex = 34;
            // 
            // RevenueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "RevenueForm";
            this.Text = "RevenueForm";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchivedRevenuesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialFlatButton GoBackBtn;
        private System.Windows.Forms.DateTimePicker DateTimeForRevenue;
        private System.Windows.Forms.TextBox RevenueAmountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddRevenueBtn;
        private System.Windows.Forms.DataGridView DataTableView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRevised;
        private MaterialSkin.Controls.MaterialLabel LogLabel;
        private System.Windows.Forms.DataGridView ArchivedRevenuesTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FindArchivedRevenues;
        private System.Windows.Forms.DateTimePicker RevisedEndDate;
        private System.Windows.Forms.DateTimePicker RevisedStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsernameArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRevisedArch;
        private System.Windows.Forms.TextBox TotalRowsBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalAmountBox;
        private System.Windows.Forms.Label label5;
    }
}