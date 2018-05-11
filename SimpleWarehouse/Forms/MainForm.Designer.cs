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
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCheckBox6 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox5 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckbox3 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckbox2 = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckbox4 = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialRadioButton4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.InvoicesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.ExpensesBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.RevenueBtn.Location = new System.Drawing.Point(840, 654);
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
            this.LogoutBtn.Location = new System.Drawing.Point(1072, 654);
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
            this.RefreshButton.Location = new System.Drawing.Point(940, 654);
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
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(16, 130);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1133, 513);
            this.materialTabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.AddCategoryBtn);
            this.tabPage1.Controls.Add(this.SearchType);
            this.tabPage1.Controls.Add(this.SearchBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DataTableView);
            this.tabPage1.Controls.Add(this.EditBtn);
            this.tabPage1.Controls.Add(this.NewProductBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1125, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Продукти";
            // 
            // AddCategoryBtn
            // 
            this.AddCategoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCategoryBtn.AutoSize = true;
            this.AddCategoryBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddCategoryBtn.Depth = 0;
            this.AddCategoryBtn.Icon = null;
            this.AddCategoryBtn.Location = new System.Drawing.Point(688, 440);
            this.AddCategoryBtn.Margin = new System.Windows.Forms.Padding(4);
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
            this.SearchType.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchType.Location = new System.Drawing.Point(340, 429);
            this.SearchType.Margin = new System.Windows.Forms.Padding(4);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(199, 36);
            this.SearchType.TabIndex = 25;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBox.Location = new System.Drawing.Point(109, 429);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(224, 35);
            this.SearchBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 432);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
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
            this.DataTableView.Location = new System.Drawing.Point(8, 8);
            this.DataTableView.Margin = new System.Windows.Forms.Padding(4);
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
            this.EditBtn.Location = new System.Drawing.Point(1003, 440);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(4);
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
            this.NewProductBtn.Location = new System.Drawing.Point(866, 440);
            this.NewProductBtn.Margin = new System.Windows.Forms.Padding(4);
            this.NewProductBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewProductBtn.Name = "NewProductBtn";
            this.NewProductBtn.Primary = true;
            this.NewProductBtn.Size = new System.Drawing.Size(129, 36);
            this.NewProductBtn.TabIndex = 0;
            this.NewProductBtn.Text = "Нова Стока";
            this.NewProductBtn.UseVisualStyleBackColor = true;
            this.NewProductBtn.Click += new System.EventHandler(this.MaterialButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.materialCheckBox6);
            this.tabPage2.Controls.Add(this.materialCheckBox5);
            this.tabPage2.Controls.Add(this.materialCheckbox3);
            this.tabPage2.Controls.Add(this.materialCheckbox1);
            this.tabPage2.Controls.Add(this.materialCheckbox2);
            this.tabPage2.Controls.Add(this.materialCheckbox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1125, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Доставки";
            // 
            // materialCheckBox6
            // 
            this.materialCheckBox6.AutoSize = true;
            this.materialCheckBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialCheckBox6.Depth = 0;
            this.materialCheckBox6.Enabled = false;
            this.materialCheckBox6.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox6.Location = new System.Drawing.Point(0, 194);
            this.materialCheckBox6.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox6.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox6.Name = "materialCheckBox6";
            this.materialCheckBox6.Ripple = true;
            this.materialCheckBox6.Size = new System.Drawing.Size(181, 30);
            this.materialCheckBox6.TabIndex = 9;
            this.materialCheckBox6.Text = "materialCheckBox6";
            this.materialCheckBox6.UseVisualStyleBackColor = true;
            // 
            // materialCheckBox5
            // 
            this.materialCheckBox5.AutoSize = true;
            this.materialCheckBox5.Checked = true;
            this.materialCheckBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialCheckBox5.Depth = 0;
            this.materialCheckBox5.Enabled = false;
            this.materialCheckBox5.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox5.Location = new System.Drawing.Point(0, 158);
            this.materialCheckBox5.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox5.Name = "materialCheckBox5";
            this.materialCheckBox5.Ripple = true;
            this.materialCheckBox5.Size = new System.Drawing.Size(181, 30);
            this.materialCheckBox5.TabIndex = 8;
            this.materialCheckBox5.Text = "materialCheckBox5";
            this.materialCheckBox5.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox3
            // 
            this.materialCheckbox3.AutoSize = true;
            this.materialCheckbox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialCheckbox3.Depth = 0;
            this.materialCheckbox3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckbox3.Location = new System.Drawing.Point(0, 84);
            this.materialCheckbox3.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox3.Name = "materialCheckbox3";
            this.materialCheckbox3.Ripple = true;
            this.materialCheckbox3.Size = new System.Drawing.Size(180, 30);
            this.materialCheckbox3.TabIndex = 6;
            this.materialCheckbox3.Text = "materialCheckbox3";
            this.materialCheckbox3.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox1
            // 
            this.materialCheckbox1.AutoSize = true;
            this.materialCheckbox1.Checked = true;
            this.materialCheckbox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckbox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialCheckbox1.Depth = 0;
            this.materialCheckbox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckbox1.Location = new System.Drawing.Point(0, 10);
            this.materialCheckbox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox1.Name = "materialCheckbox1";
            this.materialCheckbox1.Ripple = true;
            this.materialCheckbox1.Size = new System.Drawing.Size(180, 30);
            this.materialCheckbox1.TabIndex = 4;
            this.materialCheckbox1.Text = "materialCheckbox1";
            this.materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox2
            // 
            this.materialCheckbox2.AutoSize = true;
            this.materialCheckbox2.Checked = true;
            this.materialCheckbox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckbox2.Depth = 0;
            this.materialCheckbox2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckbox2.Location = new System.Drawing.Point(0, 47);
            this.materialCheckbox2.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox2.Name = "materialCheckbox2";
            this.materialCheckbox2.Ripple = true;
            this.materialCheckbox2.Size = new System.Drawing.Size(180, 30);
            this.materialCheckbox2.TabIndex = 5;
            this.materialCheckbox2.Text = "materialCheckbox2";
            this.materialCheckbox2.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox4
            // 
            this.materialCheckbox4.AutoSize = true;
            this.materialCheckbox4.Depth = 0;
            this.materialCheckbox4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckbox4.Location = new System.Drawing.Point(0, 121);
            this.materialCheckbox4.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox4.Name = "materialCheckbox4";
            this.materialCheckbox4.Ripple = true;
            this.materialCheckbox4.Size = new System.Drawing.Size(180, 30);
            this.materialCheckbox4.TabIndex = 7;
            this.materialCheckbox4.Text = "materialCheckbox4";
            this.materialCheckbox4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.materialRadioButton4);
            this.tabPage3.Controls.Add(this.materialRadioButton1);
            this.tabPage3.Controls.Add(this.materialRadioButton2);
            this.tabPage3.Controls.Add(this.materialRadioButton3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1125, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Продажби";
            // 
            // materialRadioButton4
            // 
            this.materialRadioButton4.AutoSize = true;
            this.materialRadioButton4.Checked = true;
            this.materialRadioButton4.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialRadioButton4.Depth = 0;
            this.materialRadioButton4.Enabled = false;
            this.materialRadioButton4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton4.Location = new System.Drawing.Point(0, 121);
            this.materialRadioButton4.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton4.Name = "materialRadioButton4";
            this.materialRadioButton4.Ripple = true;
            this.materialRadioButton4.Size = new System.Drawing.Size(198, 30);
            this.materialRadioButton4.TabIndex = 15;
            this.materialRadioButton4.TabStop = true;
            this.materialRadioButton4.Text = "materialRadioButton4";
            this.materialRadioButton4.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(0, 10);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(198, 30);
            this.materialRadioButton1.TabIndex = 9;
            this.materialRadioButton1.Text = "materialRadioButton1";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(0, 47);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(198, 30);
            this.materialRadioButton2.TabIndex = 10;
            this.materialRadioButton2.Text = "materialRadioButton2";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton3.Location = new System.Drawing.Point(0, 84);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(198, 30);
            this.materialRadioButton3.TabIndex = 11;
            this.materialRadioButton3.Text = "materialRadioButton3";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1125, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Ревизия";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 63);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1346, 59);
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
            this.InvoicesBtn.Location = new System.Drawing.Point(727, 654);
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
            this.ExpensesBtn.Location = new System.Drawing.Point(614, 654);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 765);
            this.Controls.Add(this.ExpensesBtn);
            this.Controls.Add(this.InvoicesBtn);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.RevenueBtn);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.RefreshButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1067, 738);
            this.Name = "MainForm";
            this.Text = "Project WH";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton RevenueBtn;
        private MaterialSkin.Controls.MaterialFlatButton LogoutBtn;
        private MaterialSkin.Controls.MaterialFlatButton RefreshButton;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialRaisedButton EditBtn;
        private MaterialSkin.Controls.MaterialRaisedButton NewProductBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox6;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox5;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckbox3;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckbox1;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckbox2;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckbox4;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton4;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
        private MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TabPage tabPage4;
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
    }
}

