namespace SimpleWarehouse.Forms
{
    partial class SpecificProductForm
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
            this.SubmitBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.VisibleCheckbox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.ProdNameField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ImportPriceField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SellPriceField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.QuantityField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.CategoriesField = new System.Windows.Forms.ComboBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SubmitBtn.AutoSize = true;
            this.SubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SubmitBtn.BackColor = System.Drawing.SystemColors.Window;
            this.SubmitBtn.Depth = 0;
            this.SubmitBtn.Icon = null;
            this.SubmitBtn.Location = new System.Drawing.Point(132, 294);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Primary = false;
            this.SubmitBtn.Size = new System.Drawing.Size(75, 36);
            this.SubmitBtn.TabIndex = 23;
            this.SubmitBtn.Text = "Запази";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Window;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(248, 294);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(68, 36);
            this.CancelBtn.TabIndex = 24;
            this.CancelBtn.Text = "Назад";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // VisibleCheckbox
            // 
            this.VisibleCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VisibleCheckbox.AutoSize = true;
            this.VisibleCheckbox.BackColor = System.Drawing.Color.White;
            this.VisibleCheckbox.Checked = true;
            this.VisibleCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VisibleCheckbox.Depth = 0;
            this.VisibleCheckbox.Font = new System.Drawing.Font("Roboto", 10F);
            this.VisibleCheckbox.Location = new System.Drawing.Point(156, 234);
            this.VisibleCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleCheckbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.VisibleCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.VisibleCheckbox.Name = "VisibleCheckbox";
            this.VisibleCheckbox.Ripple = true;
            this.VisibleCheckbox.Size = new System.Drawing.Size(26, 30);
            this.VisibleCheckbox.TabIndex = 25;
            this.VisibleCheckbox.UseVisualStyleBackColor = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(8, 238);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(137, 30);
            this.materialLabel1.TabIndex = 27;
            this.materialLabel1.Text = "Активна стока:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(8, 77);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(205, 30);
            this.materialLabel2.TabIndex = 28;
            this.materialLabel2.Text = "Име на продукт:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(8, 107);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(205, 30);
            this.materialLabel3.TabIndex = 29;
            this.materialLabel3.Text = "Количество:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel5.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(8, 137);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(205, 30);
            this.materialLabel5.TabIndex = 31;
            this.materialLabel5.Text = "Дост. цена:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel6.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(8, 167);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(205, 30);
            this.materialLabel6.TabIndex = 32;
            this.materialLabel6.Text = "Прод. цена:";
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel7.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(8, 203);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(137, 30);
            this.materialLabel7.TabIndex = 33;
            this.materialLabel7.Text = "Категория:";
            // 
            // ProdNameField
            // 
            this.ProdNameField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProdNameField.BackColor = System.Drawing.SystemColors.Window;
            this.ProdNameField.Depth = 0;
            this.ProdNameField.Hint = "Име";
            this.ProdNameField.Location = new System.Drawing.Point(156, 79);
            this.ProdNameField.MaxLength = 32767;
            this.ProdNameField.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProdNameField.Name = "ProdNameField";
            this.ProdNameField.PasswordChar = '\0';
            this.ProdNameField.SelectedText = "";
            this.ProdNameField.SelectionLength = 0;
            this.ProdNameField.SelectionStart = 0;
            this.ProdNameField.Size = new System.Drawing.Size(308, 23);
            this.ProdNameField.TabIndex = 34;
            this.ProdNameField.TabStop = false;
            this.ProdNameField.UseSystemPasswordChar = false;
            // 
            // ImportPriceField
            // 
            this.ImportPriceField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ImportPriceField.BackColor = System.Drawing.SystemColors.Window;
            this.ImportPriceField.Depth = 0;
            this.ImportPriceField.Hint = "0";
            this.ImportPriceField.Location = new System.Drawing.Point(156, 137);
            this.ImportPriceField.MaxLength = 32767;
            this.ImportPriceField.MouseState = MaterialSkin.MouseState.HOVER;
            this.ImportPriceField.Name = "ImportPriceField";
            this.ImportPriceField.PasswordChar = '\0';
            this.ImportPriceField.SelectedText = "";
            this.ImportPriceField.SelectionLength = 0;
            this.ImportPriceField.SelectionStart = 0;
            this.ImportPriceField.Size = new System.Drawing.Size(134, 23);
            this.ImportPriceField.TabIndex = 35;
            this.ImportPriceField.TabStop = false;
            this.ImportPriceField.UseSystemPasswordChar = false;
            // 
            // SellPriceField
            // 
            this.SellPriceField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SellPriceField.BackColor = System.Drawing.SystemColors.Window;
            this.SellPriceField.Depth = 0;
            this.SellPriceField.Hint = "0";
            this.SellPriceField.Location = new System.Drawing.Point(156, 172);
            this.SellPriceField.MaxLength = 32767;
            this.SellPriceField.MouseState = MaterialSkin.MouseState.HOVER;
            this.SellPriceField.Name = "SellPriceField";
            this.SellPriceField.PasswordChar = '\0';
            this.SellPriceField.SelectedText = "";
            this.SellPriceField.SelectionLength = 0;
            this.SellPriceField.SelectionStart = 0;
            this.SellPriceField.Size = new System.Drawing.Size(134, 23);
            this.SellPriceField.TabIndex = 36;
            this.SellPriceField.TabStop = false;
            this.SellPriceField.UseSystemPasswordChar = false;
            // 
            // QuantityField
            // 
            this.QuantityField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QuantityField.BackColor = System.Drawing.SystemColors.Window;
            this.QuantityField.Depth = 0;
            this.QuantityField.Hint = "0";
            this.QuantityField.Location = new System.Drawing.Point(156, 107);
            this.QuantityField.MaxLength = 32767;
            this.QuantityField.MouseState = MaterialSkin.MouseState.HOVER;
            this.QuantityField.Name = "QuantityField";
            this.QuantityField.PasswordChar = '\0';
            this.QuantityField.SelectedText = "";
            this.QuantityField.SelectionLength = 0;
            this.QuantityField.SelectionStart = 0;
            this.QuantityField.Size = new System.Drawing.Size(134, 23);
            this.QuantityField.TabIndex = 37;
            this.QuantityField.TabStop = false;
            this.QuantityField.Text = "0";
            this.QuantityField.UseSystemPasswordChar = false;
            // 
            // CategoriesField
            // 
            this.CategoriesField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CategoriesField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesField.Font = new System.Drawing.Font("Segoe UI", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoriesField.Location = new System.Drawing.Point(156, 203);
            this.CategoriesField.Name = "CategoriesField";
            this.CategoriesField.Size = new System.Drawing.Size(134, 27);
            this.CategoriesField.TabIndex = 38;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 268);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 13);
            this.LogLabel.TabIndex = 39;
            // 
            // SpecificProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 330);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.CategoriesField);
            this.Controls.Add(this.QuantityField);
            this.Controls.Add(this.SellPriceField);
            this.Controls.Add(this.ImportPriceField);
            this.Controls.Add(this.ProdNameField);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.VisibleCheckbox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.MinimumSize = new System.Drawing.Size(480, 330);
            this.Name = "SpecificProductForm";
            this.Text = "Продукт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton SubmitBtn;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialCheckBox VisibleCheckbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField ProdNameField;
        private MaterialSkin.Controls.MaterialSingleLineTextField ImportPriceField;
        private MaterialSkin.Controls.MaterialSingleLineTextField SellPriceField;
        private MaterialSkin.Controls.MaterialSingleLineTextField QuantityField;
        private System.Windows.Forms.ComboBox CategoriesField;
        private System.Windows.Forms.Label LogLabel;
    }
}