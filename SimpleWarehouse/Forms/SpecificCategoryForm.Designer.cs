namespace SimpleWarehouse.Forms
{
    partial class SpecificCategoryForm
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
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SubmitBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.CategoriesField = new System.Windows.Forms.ComboBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.CategoryNameField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.LogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Window;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(266, 213);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(68, 36);
            this.CancelBtn.TabIndex = 26;
            this.CancelBtn.Text = "Назад";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SubmitBtn.AutoSize = true;
            this.SubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SubmitBtn.BackColor = System.Drawing.SystemColors.Window;
            this.SubmitBtn.Depth = 0;
            this.SubmitBtn.Icon = null;
            this.SubmitBtn.Location = new System.Drawing.Point(150, 213);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Primary = false;
            this.SubmitBtn.Size = new System.Drawing.Size(75, 36);
            this.SubmitBtn.TabIndex = 25;
            this.SubmitBtn.Text = "Запази";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // CategoriesField
            // 
            this.CategoriesField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CategoriesField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesField.Font = new System.Drawing.Font("Segoe UI", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoriesField.Location = new System.Drawing.Point(205, 71);
            this.CategoriesField.Name = "CategoriesField";
            this.CategoriesField.Size = new System.Drawing.Size(134, 27);
            this.CategoriesField.TabIndex = 40;
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel7.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(12, 71);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(137, 30);
            this.materialLabel7.TabIndex = 39;
            this.materialLabel7.Text = "Над категория:";
            // 
            // CategoryNameField
            // 
            this.CategoryNameField.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CategoryNameField.BackColor = System.Drawing.SystemColors.Window;
            this.CategoryNameField.Depth = 0;
            this.CategoryNameField.Hint = "Име";
            this.CategoryNameField.Location = new System.Drawing.Point(205, 104);
            this.CategoryNameField.MaxLength = 32767;
            this.CategoryNameField.MouseState = MaterialSkin.MouseState.HOVER;
            this.CategoryNameField.Name = "CategoryNameField";
            this.CategoryNameField.PasswordChar = '\0';
            this.CategoryNameField.SelectedText = "";
            this.CategoryNameField.SelectionLength = 0;
            this.CategoryNameField.SelectionStart = 0;
            this.CategoryNameField.Size = new System.Drawing.Size(263, 23);
            this.CategoryNameField.TabIndex = 42;
            this.CategoryNameField.TabStop = false;
            this.CategoryNameField.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 102);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(205, 30);
            this.materialLabel2.TabIndex = 41;
            this.materialLabel2.Text = "Име на категория:";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(13, 136);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 13);
            this.LogLabel.TabIndex = 43;
            // 
            // SpecificCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.CategoryNameField);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.CategoriesField);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.MaximumSize = new System.Drawing.Size(490, 290);
            this.MinimumSize = new System.Drawing.Size(480, 270);
            this.Name = "SpecificCategoryForm";
            this.Text = "Нова Категория";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialFlatButton SubmitBtn;
        private System.Windows.Forms.ComboBox CategoriesField;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField CategoryNameField;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Label LogLabel;
    }
}