using DataGridViewTextButton.DataGridViewElements;
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
            this.AddCategoryBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SearchType = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.RevisionTab = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.InvoicesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.ExpensesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new System.Windows.Forms.Label();
            this.CurrentTabLabel = new System.Windows.Forms.Label();
            this.SalesTotalMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.materialTabControl1.SuspendLayout();
            this.ProductsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.DeliveriesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveriesDataGridView)).BeginInit();
            this.SalesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
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
            this.RevenueBtn.Location = new System.Drawing.Point(595, 524);
            this.RevenueBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RevenueBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.RevenueBtn.Name = "RevenueBtn";
            this.RevenueBtn.Primary = false;
            this.RevenueBtn.Size = new System.Drawing.Size(75, 36);
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
            this.LogoutBtn.Location = new System.Drawing.Point(787, 524);
            this.LogoutBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LogoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Primary = false;
            this.LogoutBtn.Size = new System.Drawing.Size(67, 36);
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
            this.RefreshButton.Location = new System.Drawing.Point(678, 524);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RefreshButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Primary = true;
            this.RefreshButton.Size = new System.Drawing.Size(101, 36);
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
            this.materialTabControl1.Location = new System.Drawing.Point(12, 106);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(850, 417);
            this.materialTabControl1.TabIndex = 25;
            // 
            // ProductsTab
            // 
            this.ProductsTab.BackColor = System.Drawing.Color.White;
            this.ProductsTab.Controls.Add(this.AddCategoryBtn);
            this.ProductsTab.Controls.Add(this.SearchType);
            this.ProductsTab.Controls.Add(this.SearchBox);
            this.ProductsTab.Controls.Add(this.label1);
            this.ProductsTab.Controls.Add(this.DataTableView);
            this.ProductsTab.Controls.Add(this.EditBtn);
            this.ProductsTab.Controls.Add(this.NewProductBtn);
            this.ProductsTab.Location = new System.Drawing.Point(4, 22);
            this.ProductsTab.Name = "ProductsTab";
            this.ProductsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProductsTab.Size = new System.Drawing.Size(842, 391);
            this.ProductsTab.TabIndex = 0;
            this.ProductsTab.Text = "Продукти";
            // 
            // AddCategoryBtn
            // 
            this.AddCategoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCategoryBtn.AutoSize = true;
            this.AddCategoryBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddCategoryBtn.Depth = 0;
            this.AddCategoryBtn.Icon = null;
            this.AddCategoryBtn.Location = new System.Drawing.Point(486, 349);
            this.AddCategoryBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddCategoryBtn.Name = "AddCategoryBtn";
            this.AddCategoryBtn.Primary = true;
            this.AddCategoryBtn.Size = new System.Drawing.Size(140, 36);
            this.AddCategoryBtn.TabIndex = 26;
            this.AddCategoryBtn.Text = "НОВА КАТЕГОРИЯ";
            this.AddCategoryBtn.UseVisualStyleBackColor = true;
            this.AddCategoryBtn.Click += new System.EventHandler(this.AddCategoryBtn_Click);
            // 
            // SearchType
            // 
            this.SearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchType.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchType.Location = new System.Drawing.Point(255, 349);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(150, 29);
            this.SearchType.TabIndex = 25;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBox.Location = new System.Drawing.Point(82, 349);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(169, 29);
            this.SearchBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Търсене: ";
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
            this.DataTableView.Location = new System.Drawing.Point(6, 6);
            this.DataTableView.MultiSelect = false;
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTableView.Size = new System.Drawing.Size(832, 337);
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
            this.EditBtn.Location = new System.Drawing.Point(742, 349);
            this.EditBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Primary = true;
            this.EditBtn.Size = new System.Drawing.Size(94, 36);
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
            this.NewProductBtn.Location = new System.Drawing.Point(630, 349);
            this.NewProductBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewProductBtn.Name = "NewProductBtn";
            this.NewProductBtn.Primary = true;
            this.NewProductBtn.Size = new System.Drawing.Size(106, 36);
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
            this.DeliveriesTab.Location = new System.Drawing.Point(4, 22);
            this.DeliveriesTab.Name = "DeliveriesTab";
            this.DeliveriesTab.Padding = new System.Windows.Forms.Padding(3);
            this.DeliveriesTab.Size = new System.Drawing.Size(842, 391);
            this.DeliveriesTab.TabIndex = 1;
            this.DeliveriesTab.Text = "Доставки";
            // 
            // DeliveriesTotalMoney
            // 
            this.DeliveriesTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeliveriesTotalMoney.Location = new System.Drawing.Point(504, 362);
            this.DeliveriesTotalMoney.Multiline = true;
            this.DeliveriesTotalMoney.Name = "DeliveriesTotalMoney";
            this.DeliveriesTotalMoney.ReadOnly = true;
            this.DeliveriesTotalMoney.Size = new System.Drawing.Size(81, 22);
            this.DeliveriesTotalMoney.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Общо:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // RefreshDeliveriesAction
            // 
            this.RefreshDeliveriesAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshDeliveriesAction.Location = new System.Drawing.Point(591, 362);
            this.RefreshDeliveriesAction.Name = "RefreshDeliveriesAction";
            this.RefreshDeliveriesAction.Size = new System.Drawing.Size(83, 23);
            this.RefreshDeliveriesAction.TabIndex = 3;
            this.RefreshDeliveriesAction.Text = "Обновяване";
            this.RefreshDeliveriesAction.UseVisualStyleBackColor = true;
            this.RefreshDeliveriesAction.Click += new System.EventHandler(this.RefreshDeliveriesAction_Click);
            // 
            // SaveDeliveryBtn
            // 
            this.SaveDeliveryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDeliveryBtn.Location = new System.Drawing.Point(680, 362);
            this.SaveDeliveryBtn.Name = "SaveDeliveryBtn";
            this.SaveDeliveryBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveDeliveryBtn.TabIndex = 2;
            this.SaveDeliveryBtn.Text = "Запазване";
            this.SaveDeliveryBtn.UseVisualStyleBackColor = true;
            // 
            // CancelDeliveryBtn
            // 
            this.CancelDeliveryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDeliveryBtn.Location = new System.Drawing.Point(761, 362);
            this.CancelDeliveryBtn.Name = "CancelDeliveryBtn";
            this.CancelDeliveryBtn.Size = new System.Drawing.Size(75, 23);
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
            this.DeliveriesDataGridView.Location = new System.Drawing.Point(5, 5);
            this.DeliveriesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveriesDataGridView.Name = "DeliveriesDataGridView";
            this.DeliveriesDataGridView.RowTemplate.Height = 24;
            this.DeliveriesDataGridView.Size = new System.Drawing.Size(832, 350);
            this.DeliveriesDataGridView.TabIndex = 0;
            // 
            // SalesTab
            // 
            this.SalesTab.BackColor = System.Drawing.Color.White;
            this.SalesTab.Controls.Add(this.SalesTotalMoney);
            this.SalesTab.Controls.Add(this.label3);
            this.SalesTab.Controls.Add(this.button1);
            this.SalesTab.Controls.Add(this.button2);
            this.SalesTab.Controls.Add(this.button3);
            this.SalesTab.Controls.Add(this.SalesDataGridView);
            this.SalesTab.Location = new System.Drawing.Point(4, 22);
            this.SalesTab.Name = "SalesTab";
            this.SalesTab.Padding = new System.Windows.Forms.Padding(3);
            this.SalesTab.Size = new System.Drawing.Size(842, 391);
            this.SalesTab.TabIndex = 2;
            this.SalesTab.Text = "Продажби";
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
            this.SalesDataGridView.Location = new System.Drawing.Point(5, 5);
            this.SalesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.RowTemplate.Height = 24;
            this.SalesDataGridView.Size = new System.Drawing.Size(832, 350);
            this.SalesDataGridView.TabIndex = 1;
            // 
            // RevisionTab
            // 
            this.RevisionTab.Location = new System.Drawing.Point(4, 22);
            this.RevisionTab.Name = "RevisionTab";
            this.RevisionTab.Padding = new System.Windows.Forms.Padding(3);
            this.RevisionTab.Size = new System.Drawing.Size(842, 391);
            this.RevisionTab.TabIndex = 3;
            this.RevisionTab.Text = "Ревизия";
            this.RevisionTab.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 51);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1010, 48);
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
            this.InvoicesBtn.Location = new System.Drawing.Point(502, 524);
            this.InvoicesBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.InvoicesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.InvoicesBtn.Name = "InvoicesBtn";
            this.InvoicesBtn.Primary = false;
            this.InvoicesBtn.Size = new System.Drawing.Size(85, 36);
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
            this.ExpensesBtn.Location = new System.Drawing.Point(409, 524);
            this.ExpensesBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ExpensesBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ExpensesBtn.Name = "ExpensesBtn";
            this.ExpensesBtn.Primary = false;
            this.ExpensesBtn.Size = new System.Drawing.Size(85, 36);
            this.ExpensesBtn.TabIndex = 27;
            this.ExpensesBtn.Text = "РАЗХОДИ";
            this.ExpensesBtn.UseVisualStyleBackColor = true;
            this.ExpensesBtn.Click += new System.EventHandler(this.ExpensesBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(9, 600);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 13);
            this.LogLabel.TabIndex = 28;
            // 
            // CurrentTabLabel
            // 
            this.CurrentTabLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTabLabel.AutoSize = true;
            this.CurrentTabLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentTabLabel.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTabLabel.Location = new System.Drawing.Point(762, 77);
            this.CurrentTabLabel.MinimumSize = new System.Drawing.Size(100, 22);
            this.CurrentTabLabel.Name = "CurrentTabLabel";
            this.CurrentTabLabel.Size = new System.Drawing.Size(100, 22);
            this.CurrentTabLabel.TabIndex = 27;
            this.CurrentTabLabel.Text = "Търсене: ";
            // 
            // SalesTotalMoney
            // 
            this.SalesTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesTotalMoney.Location = new System.Drawing.Point(504, 362);
            this.SalesTotalMoney.Multiline = true;
            this.SalesTotalMoney.Name = "SalesTotalMoney";
            this.SalesTotalMoney.ReadOnly = true;
            this.SalesTotalMoney.Size = new System.Drawing.Size(81, 22);
            this.SalesTotalMoney.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Общо:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(591, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Обновяване";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(680, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Запазване";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(761, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Отказ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 622);
            this.Controls.Add(this.CurrentTabLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.ExpensesBtn);
            this.Controls.Add(this.InvoicesBtn);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.RevenueBtn);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.RefreshButton);
            this.MinimumSize = new System.Drawing.Size(800, 600);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visible;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

