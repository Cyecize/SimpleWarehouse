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
            this.label7 = new System.Windows.Forms.Label();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRevised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddRevenueBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RevenueAmountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimeForRevenue = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TotalRowsBoxArchive = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TotalAmountBoxArchive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ArchivedRevenuesTable = new System.Windows.Forms.DataGridView();
            this.UsernameArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRevisedArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FindArchivedRevenues = new System.Windows.Forms.Button();
            this.RevisedEndDate = new System.Windows.Forms.DateTimePicker();
            this.RevisedStartDate = new System.Windows.Forms.DateTimePicker();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.GoBackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new MaterialSkin.Controls.MaterialLabel();
            this.LblCommentSearchArchive = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalRowsBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TotalAmountBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.materialTabControl1.Location = new System.Drawing.Point(16, 139);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(901, 354);
            this.materialTabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TotalRowsBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.TotalAmountBox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.CommentBox);
            this.tabPage1.Controls.Add(this.DataTableView);
            this.tabPage1.Controls.Add(this.AddRevenueBtn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RevenueAmountBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DateTimeForRevenue);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(893, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавяне на оборот";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(315, 256);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 28);
            this.label7.TabIndex = 31;
            this.label7.Text = "Коментар:";
            // 
            // CommentBox
            // 
            this.CommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CommentBox.Location = new System.Drawing.Point(320, 287);
            this.CommentBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(179, 27);
            this.CommentBox.TabIndex = 30;
            this.CommentBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommentBox_KeyUp);
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
            this.Comment,
            this.IsRevised});
            this.DataTableView.Location = new System.Drawing.Point(9, 7);
            this.DataTableView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataTableView.MultiSelect = false;
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.RowHeadersWidth = 51;
            this.DataTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTableView.Size = new System.Drawing.Size(873, 222);
            this.DataTableView.TabIndex = 29;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.HeaderText = "Потр. име";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Сума";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 206;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.HeaderText = "Дата";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Коментар";
            this.Comment.MinimumWidth = 6;
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 125;
            // 
            // IsRevised
            // 
            this.IsRevised.HeaderText = "Ревизиран";
            this.IsRevised.MinimumWidth = 6;
            this.IsRevised.Name = "IsRevised";
            this.IsRevised.ReadOnly = true;
            this.IsRevised.Width = 125;
            // 
            // AddRevenueBtn
            // 
            this.AddRevenueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddRevenueBtn.Location = new System.Drawing.Point(663, 287);
            this.AddRevenueBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddRevenueBtn.Name = "AddRevenueBtn";
            this.AddRevenueBtn.Size = new System.Drawing.Size(117, 28);
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
            this.label2.Location = new System.Drawing.Point(503, 256);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "Сума:";
            // 
            // RevenueAmountBox
            // 
            this.RevenueAmountBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevenueAmountBox.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RevenueAmountBox.Location = new System.Drawing.Point(508, 287);
            this.RevenueAmountBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevenueAmountBox.Name = "RevenueAmountBox";
            this.RevenueAmountBox.Size = new System.Drawing.Size(145, 26);
            this.RevenueAmountBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 256);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Дата:";
            // 
            // DateTimeForRevenue
            // 
            this.DateTimeForRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimeForRevenue.CalendarFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeForRevenue.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeForRevenue.Location = new System.Drawing.Point(8, 287);
            this.DateTimeForRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DateTimeForRevenue.Name = "DateTimeForRevenue";
            this.DateTimeForRevenue.Size = new System.Drawing.Size(303, 27);
            this.DateTimeForRevenue.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.LblCommentSearchArchive);
            this.tabPage2.Controls.Add(this.TotalRowsBoxArchive);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TotalAmountBoxArchive);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ArchivedRevenuesTable);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.FindArchivedRevenues);
            this.tabPage2.Controls.Add(this.RevisedEndDate);
            this.tabPage2.Controls.Add(this.RevisedStartDate);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(893, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Архив";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TotalRowsBoxArchive
            // 
            this.TotalRowsBoxArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalRowsBoxArchive.Enabled = false;
            this.TotalRowsBoxArchive.Location = new System.Drawing.Point(608, 236);
            this.TotalRowsBoxArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TotalRowsBoxArchive.Name = "TotalRowsBoxArchive";
            this.TotalRowsBoxArchive.ReadOnly = true;
            this.TotalRowsBoxArchive.Size = new System.Drawing.Size(48, 22);
            this.TotalRowsBoxArchive.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(421, 234);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 28);
            this.label6.TabIndex = 33;
            this.label6.Text = "Брой на записи:";
            // 
            // TotalAmountBoxArchive
            // 
            this.TotalAmountBoxArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalAmountBoxArchive.Enabled = false;
            this.TotalAmountBoxArchive.Location = new System.Drawing.Point(775, 236);
            this.TotalAmountBoxArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TotalAmountBoxArchive.Name = "TotalAmountBoxArchive";
            this.TotalAmountBoxArchive.ReadOnly = true;
            this.TotalAmountBoxArchive.Size = new System.Drawing.Size(105, 22);
            this.TotalAmountBoxArchive.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(691, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Общо:";
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
            this.CommentArch,
            this.IsRevisedArch});
            this.ArchivedRevenuesTable.Location = new System.Drawing.Point(8, 7);
            this.ArchivedRevenuesTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ArchivedRevenuesTable.MultiSelect = false;
            this.ArchivedRevenuesTable.Name = "ArchivedRevenuesTable";
            this.ArchivedRevenuesTable.ReadOnly = true;
            this.ArchivedRevenuesTable.RowHeadersWidth = 51;
            this.ArchivedRevenuesTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ArchivedRevenuesTable.Size = new System.Drawing.Size(875, 222);
            this.ArchivedRevenuesTable.TabIndex = 30;
            // 
            // UsernameArch
            // 
            this.UsernameArch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UsernameArch.HeaderText = "Потр. име";
            this.UsernameArch.MinimumWidth = 6;
            this.UsernameArch.Name = "UsernameArch";
            this.UsernameArch.ReadOnly = true;
            // 
            // AmountArch
            // 
            this.AmountArch.HeaderText = "Сума";
            this.AmountArch.MinimumWidth = 6;
            this.AmountArch.Name = "AmountArch";
            this.AmountArch.ReadOnly = true;
            this.AmountArch.Width = 206;
            // 
            // DateArch
            // 
            this.DateArch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateArch.HeaderText = "Дата";
            this.DateArch.MinimumWidth = 6;
            this.DateArch.Name = "DateArch";
            this.DateArch.ReadOnly = true;
            // 
            // CommentArch
            // 
            this.CommentArch.HeaderText = "Коментар";
            this.CommentArch.MinimumWidth = 6;
            this.CommentArch.Name = "CommentArch";
            this.CommentArch.ReadOnly = true;
            this.CommentArch.Width = 125;
            // 
            // IsRevisedArch
            // 
            this.IsRevisedArch.HeaderText = "Ревизиран";
            this.IsRevisedArch.MinimumWidth = 6;
            this.IsRevisedArch.Name = "IsRevisedArch";
            this.IsRevisedArch.ReadOnly = true;
            this.IsRevisedArch.Width = 125;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 28);
            this.label4.TabIndex = 27;
            this.label4.Text = "Крайна дата:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 260);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 28);
            this.label3.TabIndex = 26;
            this.label3.Text = "Начална дата:";
            // 
            // FindArchivedRevenues
            // 
            this.FindArchivedRevenues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FindArchivedRevenues.Location = new System.Drawing.Point(729, 287);
            this.FindArchivedRevenues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FindArchivedRevenues.Name = "FindArchivedRevenues";
            this.FindArchivedRevenues.Size = new System.Drawing.Size(100, 25);
            this.FindArchivedRevenues.TabIndex = 2;
            this.FindArchivedRevenues.Text = "Търсене";
            this.FindArchivedRevenues.UseVisualStyleBackColor = true;
            this.FindArchivedRevenues.Click += new System.EventHandler(this.FindArchivedRevenues_Click);
            // 
            // RevisedEndDate
            // 
            this.RevisedEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisedEndDate.Location = new System.Drawing.Point(283, 290);
            this.RevisedEndDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisedEndDate.Name = "RevisedEndDate";
            this.RevisedEndDate.Size = new System.Drawing.Size(265, 22);
            this.RevisedEndDate.TabIndex = 1;
            // 
            // RevisedStartDate
            // 
            this.RevisedStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisedStartDate.Location = new System.Drawing.Point(8, 290);
            this.RevisedStartDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisedStartDate.Name = "RevisedStartDate";
            this.RevisedStartDate.Size = new System.Drawing.Size(265, 22);
            this.RevisedStartDate.TabIndex = 0;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-3, 73);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(949, 59);
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
            this.GoBackBtn.Location = new System.Drawing.Point(854, 513);
            this.GoBackBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.GoBackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Primary = false;
            this.GoBackBtn.Size = new System.Drawing.Size(80, 36);
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
            this.LogLabel.Location = new System.Drawing.Point(16, 497);
            this.LogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(597, 37);
            this.LogLabel.TabIndex = 42;
            // 
            // LblCommentSearchArchive
            // 
            this.LblCommentSearchArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblCommentSearchArchive.Location = new System.Drawing.Point(556, 290);
            this.LblCommentSearchArchive.Margin = new System.Windows.Forms.Padding(4);
            this.LblCommentSearchArchive.Multiline = true;
            this.LblCommentSearchArchive.Name = "LblCommentSearchArchive";
            this.LblCommentSearchArchive.Size = new System.Drawing.Size(165, 22);
            this.LblCommentSearchArchive.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(551, 261);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 28);
            this.label8.TabIndex = 44;
            this.label8.Text = "Коментар:";
            // 
            // TotalRowsBox
            // 
            this.TotalRowsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalRowsBox.Enabled = false;
            this.TotalRowsBox.Location = new System.Drawing.Point(602, 235);
            this.TotalRowsBox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalRowsBox.Name = "TotalRowsBox";
            this.TotalRowsBox.ReadOnly = true;
            this.TotalRowsBox.Size = new System.Drawing.Size(48, 22);
            this.TotalRowsBox.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(415, 233);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 28);
            this.label9.TabIndex = 37;
            this.label9.Text = "Брой на записи:";
            // 
            // TotalAmountBox
            // 
            this.TotalAmountBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalAmountBox.Enabled = false;
            this.TotalAmountBox.Location = new System.Drawing.Point(769, 235);
            this.TotalAmountBox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalAmountBox.Name = "TotalAmountBox";
            this.TotalAmountBox.ReadOnly = true;
            this.TotalAmountBox.Size = new System.Drawing.Size(105, 22);
            this.TotalAmountBox.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(685, 232);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 28);
            this.label10.TabIndex = 35;
            this.label10.Text = "Общо:";
            // 
            // RevenueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.GoBackBtn);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(933, 554);
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
        private MaterialSkin.Controls.MaterialLabel LogLabel;
        private System.Windows.Forms.DataGridView ArchivedRevenuesTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FindArchivedRevenues;
        private System.Windows.Forms.DateTimePicker RevisedEndDate;
        private System.Windows.Forms.DateTimePicker RevisedStartDate;
        private System.Windows.Forms.TextBox TotalRowsBoxArchive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TotalAmountBoxArchive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CommentBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRevised;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsernameArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRevisedArch;
        private System.Windows.Forms.TextBox LblCommentSearchArchive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TotalRowsBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TotalAmountBox;
        private System.Windows.Forms.Label label10;
    }
}