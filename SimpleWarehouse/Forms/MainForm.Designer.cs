﻿using DataGridViewTextButton.DataGridViewElements;
using MaterialSkin.Controls;

namespace SimpleWarehouse.Forms
{
    partial class MainForm
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
            this.RevenueBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogoutBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.RefreshButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.ProductsTab = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.AddCategoryBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SearchType = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.NewProductBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.DeliveriesTab = new System.Windows.Forms.TabPage();
            this.DeliveriesTotalMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshDeliveriesAction = new System.Windows.Forms.Button();
            this.SaveDeliveryBtn = new System.Windows.Forms.Button();
            this.CancelDeliveryBtn = new System.Windows.Forms.Button();
            this.DeliveriesDataGridView = new System.Windows.Forms.DataGridView();
            this.SalesTab = new System.Windows.Forms.TabPage();
            this.SalesTotalMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SalesRefreshBtn = new System.Windows.Forms.Button();
            this.SaveSaleBtn = new System.Windows.Forms.Button();
            this.SalesCancelBtn = new System.Windows.Forms.Button();
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.RevisionTab = new System.Windows.Forms.TabPage();
            this.RevisionSalesPlusRevisionTotalTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RevisionCancelBtn = new System.Windows.Forms.Button();
            this.RevisionSaveBtn = new System.Windows.Forms.Button();
            this.RevisionRefreshBtn = new System.Windows.Forms.Button();
            this.RevisionStartDateLabel = new System.Windows.Forms.Label();
            this.RevisionSubTotalTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RevisionSalesRevenueTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RevisionRevenueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RevisionExpensesTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BeginRevisionBtn = new System.Windows.Forms.Button();
            this.RevisionDataGridView = new System.Windows.Forms.DataGridView();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.InvoicesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.ExpensesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new System.Windows.Forms.Label();
            this.CurrentTabLabel = new System.Windows.Forms.Label();
            this.materialTabControl1.SuspendLayout();
            this.ProductsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.DeliveriesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveriesDataGridView)).BeginInit();
            this.SalesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
            this.RevisionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RevisionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RevenueBtn
            // 
            this.RevenueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevenueBtn.AutoSize = true;
            this.RevenueBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RevenueBtn.Depth = 0;
            this.RevenueBtn.Enabled = false;
            this.RevenueBtn.Icon = null;
            this.RevenueBtn.Location = new System.Drawing.Point(823, 653);
            this.RevenueBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.RevenueBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RevenueBtn.Name = "RevenueBtn";
            this.RevenueBtn.Primary = false;
            this.RevenueBtn.Size = new System.Drawing.Size(90, 36);
            this.RevenueBtn.TabIndex = 23;
            this.RevenueBtn.Text = "ОБОРОТ";
            this.RevenueBtn.UseVisualStyleBackColor = true;
            this.RevenueBtn.Click += new System.EventHandler(this.RevenueBtn_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutBtn.AutoSize = true;
            this.LogoutBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogoutBtn.Depth = 0;
            this.LogoutBtn.Icon = null;
            this.LogoutBtn.Location = new System.Drawing.Point(1076, 653);
            this.LogoutBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.LogoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Primary = false;
            this.LogoutBtn.Size = new System.Drawing.Size(80, 36);
            this.LogoutBtn.TabIndex = 22;
            this.LogoutBtn.Text = "Изход";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.AutoSize = true;
            this.RefreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RefreshButton.Depth = 0;
            this.RefreshButton.Icon = null;
            this.RefreshButton.Location = new System.Drawing.Point(945, 653);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.RefreshButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Primary = true;
            this.RefreshButton.Size = new System.Drawing.Size(122, 36);
            this.RefreshButton.TabIndex = 21;
            this.RefreshButton.Text = "Презареди";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl1.Controls.Add(this.ProductsTab);
            this.materialTabControl1.Controls.Add(this.DeliveriesTab);
            this.materialTabControl1.Controls.Add(this.SalesTab);
            this.materialTabControl1.Controls.Add(this.RevisionTab);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(16, 130);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1133, 513);
            this.materialTabControl1.TabIndex = 25;
            // 
            // ProductsTab
            // 
            this.ProductsTab.BackColor = System.Drawing.Color.White;
            this.ProductsTab.Controls.Add(this.label9);
            this.ProductsTab.Controls.Add(this.AddCategoryBtn);
            this.ProductsTab.Controls.Add(this.SearchType);
            this.ProductsTab.Controls.Add(this.SearchBox);
            this.ProductsTab.Controls.Add(this.DataTableView);
            this.ProductsTab.Controls.Add(this.EditBtn);
            this.ProductsTab.Controls.Add(this.NewProductBtn);
            this.ProductsTab.Location = new System.Drawing.Point(4, 25);
            this.ProductsTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductsTab.Name = "ProductsTab";
            this.ProductsTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductsTab.Size = new System.Drawing.Size(1125, 484);
            this.ProductsTab.TabIndex = 0;
            this.ProductsTab.Text = "Продукти";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(8, 449);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Търсене:";
            // 
            // AddCategoryBtn
            // 
            this.AddCategoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCategoryBtn.AutoSize = true;
            this.AddCategoryBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddCategoryBtn.Depth = 0;
            this.AddCategoryBtn.Icon = null;
            this.AddCategoryBtn.Location = new System.Drawing.Point(705, 438);
            this.AddCategoryBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddCategoryBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddCategoryBtn.Name = "AddCategoryBtn";
            this.AddCategoryBtn.Primary = true;
            this.AddCategoryBtn.Size = new System.Drawing.Size(170, 36);
            this.AddCategoryBtn.TabIndex = 26;
            this.AddCategoryBtn.Text = "НОВА КАТЕГОРИЯ";
            this.AddCategoryBtn.UseVisualStyleBackColor = true;
            this.AddCategoryBtn.Click += new System.EventHandler(this.AddCategoryBtn_Click);
            // 
            // SearchType
            // 
            this.SearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchType.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchType.Location = new System.Drawing.Point(352, 438);
            this.SearchType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(199, 36);
            this.SearchType.TabIndex = 25;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBox.Location = new System.Drawing.Point(119, 438);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(224, 35);
            this.SearchBox.TabIndex = 24;
            // 
            // DataTableView
            // 
            this.DataTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Category,
            this.ProductName,
            this.Quantity,
            this.ImportPrice,
            this.SellPrice,
            this.Visible});
            this.DataTableView.Location = new System.Drawing.Point(8, 7);
            this.DataTableView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataTableView.MultiSelect = false;
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTableView.Size = new System.Drawing.Size(1109, 415);
            this.DataTableView.TabIndex = 22;
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Код на продукт";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Category.HeaderText = "Категория";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.HeaderText = "Име";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Количество";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // ImportPrice
            // 
            this.ImportPrice.HeaderText = "Дост. цена";
            this.ImportPrice.Name = "ImportPrice";
            this.ImportPrice.ReadOnly = true;
            // 
            // SellPrice
            // 
            this.SellPrice.HeaderText = "Прод. цена";
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.ReadOnly = true;
            // 
            // Visible
            // 
            this.Visible.HeaderText = "Видим";
            this.Visible.Name = "Visible";
            this.Visible.ReadOnly = true;
            this.Visible.Width = 50;
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.AutoSize = true;
            this.EditBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditBtn.Depth = 0;
            this.EditBtn.Icon = null;
            this.EditBtn.Location = new System.Drawing.Point(1027, 438);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EditBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Primary = true;
            this.EditBtn.Size = new System.Drawing.Size(114, 36);
            this.EditBtn.TabIndex = 21;
            this.EditBtn.Text = "Редакция";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // NewProductBtn
            // 
            this.NewProductBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NewProductBtn.AutoSize = true;
            this.NewProductBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewProductBtn.Depth = 0;
            this.NewProductBtn.Icon = null;
            this.NewProductBtn.Location = new System.Drawing.Point(883, 438);
            this.NewProductBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewProductBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewProductBtn.Name = "NewProductBtn";
            this.NewProductBtn.Primary = true;
            this.NewProductBtn.Size = new System.Drawing.Size(129, 36);
            this.NewProductBtn.TabIndex = 0;
            this.NewProductBtn.Text = "Нова Стока";
            this.NewProductBtn.UseVisualStyleBackColor = true;
            this.NewProductBtn.Click += new System.EventHandler(this.MaterialButton1_Click);
            // 
            // DeliveriesTab
            // 
            this.DeliveriesTab.BackColor = System.Drawing.Color.White;
            this.DeliveriesTab.Controls.Add(this.DeliveriesTotalMoney);
            this.DeliveriesTab.Controls.Add(this.label2);
            this.DeliveriesTab.Controls.Add(this.RefreshDeliveriesAction);
            this.DeliveriesTab.Controls.Add(this.SaveDeliveryBtn);
            this.DeliveriesTab.Controls.Add(this.CancelDeliveryBtn);
            this.DeliveriesTab.Controls.Add(this.DeliveriesDataGridView);
            this.DeliveriesTab.Location = new System.Drawing.Point(4, 25);
            this.DeliveriesTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeliveriesTab.Name = "DeliveriesTab";
            this.DeliveriesTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeliveriesTab.Size = new System.Drawing.Size(1125, 484);
            this.DeliveriesTab.TabIndex = 1;
            this.DeliveriesTab.Text = "Доставки";
            // 
            // DeliveriesTotalMoney
            // 
            this.DeliveriesTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeliveriesTotalMoney.Location = new System.Drawing.Point(672, 446);
            this.DeliveriesTotalMoney.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeliveriesTotalMoney.Multiline = true;
            this.DeliveriesTotalMoney.Name = "DeliveriesTotalMoney";
            this.DeliveriesTotalMoney.ReadOnly = true;
            this.DeliveriesTotalMoney.Size = new System.Drawing.Size(107, 26);
            this.DeliveriesTotalMoney.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(588, 438);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "Общо:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RefreshDeliveriesAction
            // 
            this.RefreshDeliveriesAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshDeliveriesAction.Location = new System.Drawing.Point(788, 446);
            this.RefreshDeliveriesAction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshDeliveriesAction.Name = "RefreshDeliveriesAction";
            this.RefreshDeliveriesAction.Size = new System.Drawing.Size(111, 28);
            this.RefreshDeliveriesAction.TabIndex = 3;
            this.RefreshDeliveriesAction.Text = "Обновяване";
            this.RefreshDeliveriesAction.UseVisualStyleBackColor = true;
            this.RefreshDeliveriesAction.Click += new System.EventHandler(this.RefreshDeliveriesAction_Click);
            // 
            // SaveDeliveryBtn
            // 
            this.SaveDeliveryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDeliveryBtn.Location = new System.Drawing.Point(907, 446);
            this.SaveDeliveryBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveDeliveryBtn.Name = "SaveDeliveryBtn";
            this.SaveDeliveryBtn.Size = new System.Drawing.Size(100, 28);
            this.SaveDeliveryBtn.TabIndex = 2;
            this.SaveDeliveryBtn.Text = "Запазване";
            this.SaveDeliveryBtn.UseVisualStyleBackColor = true;
            this.SaveDeliveryBtn.Click += new System.EventHandler(this.SaveDeliveryBtn_Click);
            // 
            // CancelDeliveryBtn
            // 
            this.CancelDeliveryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDeliveryBtn.Location = new System.Drawing.Point(1015, 446);
            this.CancelDeliveryBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelDeliveryBtn.Name = "CancelDeliveryBtn";
            this.CancelDeliveryBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelDeliveryBtn.TabIndex = 1;
            this.CancelDeliveryBtn.Text = "Отказ";
            this.CancelDeliveryBtn.UseVisualStyleBackColor = true;
            this.CancelDeliveryBtn.Click += new System.EventHandler(this.CancelDeliveryBtn_Click);
            // 
            // DeliveriesDataGridView
            // 
            this.DeliveriesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeliveriesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DeliveriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeliveriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeliveriesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DeliveriesDataGridView.Location = new System.Drawing.Point(7, 6);
            this.DeliveriesDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeliveriesDataGridView.Name = "DeliveriesDataGridView";
            this.DeliveriesDataGridView.RowTemplate.Height = 24;
            this.DeliveriesDataGridView.Size = new System.Drawing.Size(1109, 431);
            this.DeliveriesDataGridView.TabIndex = 0;
            // 
            // SalesTab
            // 
            this.SalesTab.BackColor = System.Drawing.Color.White;
            this.SalesTab.Controls.Add(this.SalesTotalMoney);
            this.SalesTab.Controls.Add(this.label3);
            this.SalesTab.Controls.Add(this.SalesRefreshBtn);
            this.SalesTab.Controls.Add(this.SaveSaleBtn);
            this.SalesTab.Controls.Add(this.SalesCancelBtn);
            this.SalesTab.Controls.Add(this.SalesDataGridView);
            this.SalesTab.Location = new System.Drawing.Point(4, 25);
            this.SalesTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SalesTab.Name = "SalesTab";
            this.SalesTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SalesTab.Size = new System.Drawing.Size(1125, 484);
            this.SalesTab.TabIndex = 2;
            this.SalesTab.Text = "Продажби";
            // 
            // SalesTotalMoney
            // 
            this.SalesTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesTotalMoney.Location = new System.Drawing.Point(672, 446);
            this.SalesTotalMoney.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SalesTotalMoney.Multiline = true;
            this.SalesTotalMoney.Name = "SalesTotalMoney";
            this.SalesTotalMoney.ReadOnly = true;
            this.SalesTotalMoney.Size = new System.Drawing.Size(107, 26);
            this.SalesTotalMoney.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(588, 438);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 28);
            this.label3.TabIndex = 29;
            this.label3.Text = "Общо:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SalesRefreshBtn
            // 
            this.SalesRefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesRefreshBtn.Location = new System.Drawing.Point(788, 446);
            this.SalesRefreshBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SalesRefreshBtn.Name = "SalesRefreshBtn";
            this.SalesRefreshBtn.Size = new System.Drawing.Size(111, 28);
            this.SalesRefreshBtn.TabIndex = 28;
            this.SalesRefreshBtn.Text = "Обновяване";
            this.SalesRefreshBtn.UseVisualStyleBackColor = true;
            this.SalesRefreshBtn.Click += new System.EventHandler(this.SalesRefreshBtn_Click);
            // 
            // SaveSaleBtn
            // 
            this.SaveSaleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSaleBtn.Location = new System.Drawing.Point(907, 446);
            this.SaveSaleBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveSaleBtn.Name = "SaveSaleBtn";
            this.SaveSaleBtn.Size = new System.Drawing.Size(100, 28);
            this.SaveSaleBtn.TabIndex = 27;
            this.SaveSaleBtn.Text = "Запазване";
            this.SaveSaleBtn.UseVisualStyleBackColor = true;
            this.SaveSaleBtn.Click += new System.EventHandler(this.SaveSaleBtn_Click);
            // 
            // SalesCancelBtn
            // 
            this.SalesCancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesCancelBtn.Location = new System.Drawing.Point(1015, 446);
            this.SalesCancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SalesCancelBtn.Name = "SalesCancelBtn";
            this.SalesCancelBtn.Size = new System.Drawing.Size(100, 28);
            this.SalesCancelBtn.TabIndex = 26;
            this.SalesCancelBtn.Text = "Отказ";
            this.SalesCancelBtn.UseVisualStyleBackColor = true;
            this.SalesCancelBtn.Click += new System.EventHandler(this.SalesCancelBtn_Click);
            // 
            // SalesDataGridView
            // 
            this.SalesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.SalesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.SalesDataGridView.Location = new System.Drawing.Point(7, 6);
            this.SalesDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.RowTemplate.Height = 24;
            this.SalesDataGridView.Size = new System.Drawing.Size(1109, 431);
            this.SalesDataGridView.TabIndex = 1;
            // 
            // RevisionTab
            // 
            this.RevisionTab.Controls.Add(this.RevisionSalesPlusRevisionTotalTextBox);
            this.RevisionTab.Controls.Add(this.label8);
            this.RevisionTab.Controls.Add(this.RevisionCancelBtn);
            this.RevisionTab.Controls.Add(this.RevisionSaveBtn);
            this.RevisionTab.Controls.Add(this.RevisionRefreshBtn);
            this.RevisionTab.Controls.Add(this.RevisionStartDateLabel);
            this.RevisionTab.Controls.Add(this.RevisionSubTotalTextBox);
            this.RevisionTab.Controls.Add(this.label7);
            this.RevisionTab.Controls.Add(this.RevisionSalesRevenueTextBox);
            this.RevisionTab.Controls.Add(this.label6);
            this.RevisionTab.Controls.Add(this.RevisionRevenueTextBox);
            this.RevisionTab.Controls.Add(this.label5);
            this.RevisionTab.Controls.Add(this.RevisionExpensesTextBox);
            this.RevisionTab.Controls.Add(this.label4);
            this.RevisionTab.Controls.Add(this.BeginRevisionBtn);
            this.RevisionTab.Controls.Add(this.RevisionDataGridView);
            this.RevisionTab.Location = new System.Drawing.Point(4, 25);
            this.RevisionTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionTab.Name = "RevisionTab";
            this.RevisionTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionTab.Size = new System.Drawing.Size(1125, 484);
            this.RevisionTab.TabIndex = 3;
            this.RevisionTab.Text = "Ревизия";
            this.RevisionTab.UseVisualStyleBackColor = true;
            this.RevisionTab.Click += new System.EventHandler(this.RevisionTab_Click);
            // 
            // RevisionSalesPlusRevisionTotalTextBox
            // 
            this.RevisionSalesPlusRevisionTotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionSalesPlusRevisionTotalTextBox.Location = new System.Drawing.Point(517, 452);
            this.RevisionSalesPlusRevisionTotalTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionSalesPlusRevisionTotalTextBox.Multiline = true;
            this.RevisionSalesPlusRevisionTotalTextBox.Name = "RevisionSalesPlusRevisionTotalTextBox";
            this.RevisionSalesPlusRevisionTotalTextBox.ReadOnly = true;
            this.RevisionSalesPlusRevisionTotalTextBox.Size = new System.Drawing.Size(107, 20);
            this.RevisionSalesPlusRevisionTotalTextBox.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(429, 452);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 38;
            this.label8.Text = "Р+Прод.:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RevisionCancelBtn
            // 
            this.RevisionCancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevisionCancelBtn.Location = new System.Drawing.Point(799, 444);
            this.RevisionCancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionCancelBtn.Name = "RevisionCancelBtn";
            this.RevisionCancelBtn.Size = new System.Drawing.Size(100, 28);
            this.RevisionCancelBtn.TabIndex = 37;
            this.RevisionCancelBtn.Text = "Отмяна";
            this.RevisionCancelBtn.UseVisualStyleBackColor = true;
            this.RevisionCancelBtn.Click += new System.EventHandler(this.RevisionCancelBtn_Click);
            // 
            // RevisionSaveBtn
            // 
            this.RevisionSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevisionSaveBtn.Location = new System.Drawing.Point(691, 444);
            this.RevisionSaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionSaveBtn.Name = "RevisionSaveBtn";
            this.RevisionSaveBtn.Size = new System.Drawing.Size(100, 28);
            this.RevisionSaveBtn.TabIndex = 36;
            this.RevisionSaveBtn.Text = "Запази";
            this.RevisionSaveBtn.UseVisualStyleBackColor = true;
            this.RevisionSaveBtn.Click += new System.EventHandler(this.RevisionSaveBtn_Click);
            // 
            // RevisionRefreshBtn
            // 
            this.RevisionRefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevisionRefreshBtn.Location = new System.Drawing.Point(907, 446);
            this.RevisionRefreshBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionRefreshBtn.Name = "RevisionRefreshBtn";
            this.RevisionRefreshBtn.Size = new System.Drawing.Size(100, 28);
            this.RevisionRefreshBtn.TabIndex = 35;
            this.RevisionRefreshBtn.Text = "Обнови";
            this.RevisionRefreshBtn.UseVisualStyleBackColor = true;
            this.RevisionRefreshBtn.Click += new System.EventHandler(this.RevisionRefreshBtn_Click);
            // 
            // RevisionStartDateLabel
            // 
            this.RevisionStartDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionStartDateLabel.AutoSize = true;
            this.RevisionStartDateLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevisionStartDateLabel.Location = new System.Drawing.Point(211, 453);
            this.RevisionStartDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RevisionStartDateLabel.Name = "RevisionStartDateLabel";
            this.RevisionStartDateLabel.Size = new System.Drawing.Size(107, 19);
            this.RevisionStartDateLabel.TabIndex = 34;
            this.RevisionStartDateLabel.Text = "Начална дата:";
            this.RevisionStartDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RevisionSubTotalTextBox
            // 
            this.RevisionSubTotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionSubTotalTextBox.Location = new System.Drawing.Point(517, 426);
            this.RevisionSubTotalTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionSubTotalTextBox.Multiline = true;
            this.RevisionSubTotalTextBox.Name = "RevisionSubTotalTextBox";
            this.RevisionSubTotalTextBox.ReadOnly = true;
            this.RevisionSubTotalTextBox.Size = new System.Drawing.Size(107, 20);
            this.RevisionSubTotalTextBox.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(429, 426);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Ревизия:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RevisionSalesRevenueTextBox
            // 
            this.RevisionSalesRevenueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionSalesRevenueTextBox.Location = new System.Drawing.Point(313, 426);
            this.RevisionSalesRevenueTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionSalesRevenueTextBox.Multiline = true;
            this.RevisionSalesRevenueTextBox.Name = "RevisionSalesRevenueTextBox";
            this.RevisionSalesRevenueTextBox.ReadOnly = true;
            this.RevisionSalesRevenueTextBox.Size = new System.Drawing.Size(107, 20);
            this.RevisionSalesRevenueTextBox.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(211, 426);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Продажби:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RevisionRevenueTextBox
            // 
            this.RevisionRevenueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionRevenueTextBox.Location = new System.Drawing.Point(95, 425);
            this.RevisionRevenueTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionRevenueTextBox.Multiline = true;
            this.RevisionRevenueTextBox.Name = "RevisionRevenueTextBox";
            this.RevisionRevenueTextBox.ReadOnly = true;
            this.RevisionRevenueTextBox.Size = new System.Drawing.Size(107, 20);
            this.RevisionRevenueTextBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 426);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "Приходи:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RevisionExpensesTextBox
            // 
            this.RevisionExpensesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RevisionExpensesTextBox.Location = new System.Drawing.Point(95, 453);
            this.RevisionExpensesTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionExpensesTextBox.Multiline = true;
            this.RevisionExpensesTextBox.Name = "RevisionExpensesTextBox";
            this.RevisionExpensesTextBox.ReadOnly = true;
            this.RevisionExpensesTextBox.Size = new System.Drawing.Size(107, 20);
            this.RevisionExpensesTextBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 453);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Разходи:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BeginRevisionBtn
            // 
            this.BeginRevisionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BeginRevisionBtn.Location = new System.Drawing.Point(1015, 446);
            this.BeginRevisionBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BeginRevisionBtn.Name = "BeginRevisionBtn";
            this.BeginRevisionBtn.Size = new System.Drawing.Size(100, 28);
            this.BeginRevisionBtn.TabIndex = 24;
            this.BeginRevisionBtn.Text = "Начало";
            this.BeginRevisionBtn.UseVisualStyleBackColor = true;
            this.BeginRevisionBtn.Click += new System.EventHandler(this.BeginRevisionBtn_Click);
            // 
            // RevisionDataGridView
            // 
            this.RevisionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RevisionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RevisionDataGridView.Location = new System.Drawing.Point(8, 7);
            this.RevisionDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RevisionDataGridView.MultiSelect = false;
            this.RevisionDataGridView.Name = "RevisionDataGridView";
            this.RevisionDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RevisionDataGridView.Size = new System.Drawing.Size(1109, 415);
            this.RevisionDataGridView.TabIndex = 23;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 63);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1347, 59);
            this.materialTabSelector1.TabIndex = 17;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // InvoicesBtn
            // 
            this.InvoicesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoicesBtn.AutoSize = true;
            this.InvoicesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InvoicesBtn.Depth = 0;
            this.InvoicesBtn.Enabled = false;
            this.InvoicesBtn.Icon = null;
            this.InvoicesBtn.Location = new System.Drawing.Point(703, 653);
            this.InvoicesBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.InvoicesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.InvoicesBtn.Name = "InvoicesBtn";
            this.InvoicesBtn.Primary = false;
            this.InvoicesBtn.Size = new System.Drawing.Size(103, 36);
            this.InvoicesBtn.TabIndex = 26;
            this.InvoicesBtn.Text = "ФАКТУРИ";
            this.InvoicesBtn.UseVisualStyleBackColor = true;
            this.InvoicesBtn.Click += new System.EventHandler(this.InvoicesBtn_Click);
            // 
            // ExpensesBtn
            // 
            this.ExpensesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpensesBtn.AutoSize = true;
            this.ExpensesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExpensesBtn.Depth = 0;
            this.ExpensesBtn.Enabled = false;
            this.ExpensesBtn.Icon = null;
            this.ExpensesBtn.Location = new System.Drawing.Point(579, 653);
            this.ExpensesBtn.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.ExpensesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ExpensesBtn.Name = "ExpensesBtn";
            this.ExpensesBtn.Primary = false;
            this.ExpensesBtn.Size = new System.Drawing.Size(103, 36);
            this.ExpensesBtn.TabIndex = 27;
            this.ExpensesBtn.Text = "РАЗХОДИ";
            this.ExpensesBtn.UseVisualStyleBackColor = true;
            this.ExpensesBtn.Click += new System.EventHandler(this.ExpensesBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 738);
            this.LogLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 17);
            this.LogLabel.TabIndex = 28;
            this.LogLabel.Click += new System.EventHandler(this.LogLabel_Click);
            // 
            // CurrentTabLabel
            // 
            this.CurrentTabLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTabLabel.AutoSize = true;
            this.CurrentTabLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentTabLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTabLabel.Location = new System.Drawing.Point(1016, 95);
            this.CurrentTabLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentTabLabel.MinimumSize = new System.Drawing.Size(133, 27);
            this.CurrentTabLabel.Name = "CurrentTabLabel";
            this.CurrentTabLabel.Size = new System.Drawing.Size(133, 28);
            this.CurrentTabLabel.TabIndex = 27;
            this.CurrentTabLabel.Text = "Търсене: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 766);
            this.Controls.Add(this.CurrentTabLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.ExpensesBtn);
            this.Controls.Add(this.InvoicesBtn);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.RevenueBtn);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.RefreshButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1067, 738);
            this.Name = "MainForm";
            this.Text = "Project WH";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.ProductsTab.ResumeLayout(false);
            this.ProductsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.DeliveriesTab.ResumeLayout(false);
            this.DeliveriesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveriesDataGridView)).EndInit();
            this.SalesTab.ResumeLayout(false);
            this.SalesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
            this.RevisionTab.ResumeLayout(false);
            this.RevisionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RevisionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton RevenueBtn;
        private MaterialSkin.Controls.MaterialFlatButton LogoutBtn;
        private MaterialSkin.Controls.MaterialFlatButton RefreshButton;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage ProductsTab;
        private MaterialSkin.Controls.MaterialRaisedButton EditBtn;
        private MaterialSkin.Controls.MaterialRaisedButton NewProductBtn;
        private System.Windows.Forms.TabPage DeliveriesTab;
        private MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage RevisionTab;
        private System.Windows.Forms.DataGridView DataTableView;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private new System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Visible;
        private System.Windows.Forms.ComboBox SearchType;
        private MaterialRaisedButton AddCategoryBtn;
        private MaterialFlatButton InvoicesBtn;
        private MaterialFlatButton ExpensesBtn;
        private System.Windows.Forms.DataGridView DeliveriesDataGridView;
        private System.Windows.Forms.TabPage SalesTab;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.DataGridView SalesDataGridView;
        private System.Windows.Forms.Label CurrentTabLabel;
        private System.Windows.Forms.Button CancelDeliveryBtn;
        private System.Windows.Forms.Button RefreshDeliveriesAction;
        private System.Windows.Forms.Button SaveDeliveryBtn;
        private System.Windows.Forms.TextBox DeliveriesTotalMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SalesTotalMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SalesRefreshBtn;
        private System.Windows.Forms.Button SaveSaleBtn;
        private System.Windows.Forms.Button SalesCancelBtn;
        private System.Windows.Forms.DataGridView RevisionDataGridView;
        private System.Windows.Forms.Button BeginRevisionBtn;
        private System.Windows.Forms.TextBox RevisionExpensesTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RevisionSubTotalTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RevisionSalesRevenueTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RevisionRevenueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button RevisionSaveBtn;
        private System.Windows.Forms.Button RevisionRefreshBtn;
        private System.Windows.Forms.Label RevisionStartDateLabel;
        private System.Windows.Forms.Button RevisionCancelBtn;
        private System.Windows.Forms.TextBox RevisionSalesPlusRevisionTotalTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

