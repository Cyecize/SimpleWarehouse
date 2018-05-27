namespace SimpleWarehouse.Forms
{
    partial class SearchProductForm
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
            this.GoBackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.DataTableView = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectProductBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new System.Windows.Forms.Label();
            this.SearchType = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoBackBtn.AutoSize = true;
            this.GoBackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GoBackBtn.Depth = 0;
            this.GoBackBtn.Icon = null;
            this.GoBackBtn.Location = new System.Drawing.Point(647, 371);
            this.GoBackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GoBackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Primary = false;
            this.GoBackBtn.Size = new System.Drawing.Size(68, 36);
            this.GoBackBtn.TabIndex = 23;
            this.GoBackBtn.Text = "Назад";
            this.GoBackBtn.UseVisualStyleBackColor = true;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_Click);
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
            this.DataTableView.Location = new System.Drawing.Point(12, 73);
            this.DataTableView.MultiSelect = false;
            this.DataTableView.Name = "DataTableView";
            this.DataTableView.ReadOnly = true;
            this.DataTableView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTableView.Size = new System.Drawing.Size(707, 289);
            this.DataTableView.TabIndex = 24;
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
            // SelectProductBtn
            // 
            this.SelectProductBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectProductBtn.AutoSize = true;
            this.SelectProductBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectProductBtn.Depth = 0;
            this.SelectProductBtn.Icon = null;
            this.SelectProductBtn.Location = new System.Drawing.Point(573, 371);
            this.SelectProductBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SelectProductBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SelectProductBtn.Name = "SelectProductBtn";
            this.SelectProductBtn.Primary = false;
            this.SelectProductBtn.Size = new System.Drawing.Size(66, 36);
            this.SelectProductBtn.TabIndex = 25;
            this.SelectProductBtn.Text = "Избор";
            this.SelectProductBtn.UseVisualStyleBackColor = true;
            this.SelectProductBtn.Click += new System.EventHandler(this.SelectProductBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 410);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 13);
            this.LogLabel.TabIndex = 26;
            // 
            // SearchType
            // 
            this.SearchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchType.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchType.Location = new System.Drawing.Point(278, 368);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(150, 29);
            this.SearchType.TabIndex = 29;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBox.Location = new System.Drawing.Point(103, 368);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(169, 29);
            this.SearchBox.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Търсене: ";
            // 
            // SearchProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 451);
            this.Controls.Add(this.SearchType);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.SelectProductBtn);
            this.Controls.Add(this.DataTableView);
            this.Controls.Add(this.GoBackBtn);
            this.MinimumSize = new System.Drawing.Size(731, 451);
            this.Name = "SearchProductForm";
            this.Text = "SearchProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.DataTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton GoBackBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private new System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Visible;
        private MaterialSkin.Controls.MaterialFlatButton SelectProductBtn;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ComboBox SearchType;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataTableView;
    }
}