namespace SimpleWarehouse.Forms
{
    partial class DisableUserForm
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
            this.LogLabel = new System.Windows.Forms.Label();
            this.IsUserEnabledCheckbox = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.UsersListBox = new System.Windows.Forms.ComboBox();
            this.SelectedUsernameBox = new System.Windows.Forms.TextBox();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SubmitBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 257);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(35, 13);
            this.LogLabel.TabIndex = 0;
            this.LogLabel.Text = "label1";
            // 
            // IsUserEnabledCheckbox
            // 
            this.IsUserEnabledCheckbox.AutoSize = true;
            this.IsUserEnabledCheckbox.BackColor = System.Drawing.Color.White;
            this.IsUserEnabledCheckbox.Checked = true;
            this.IsUserEnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsUserEnabledCheckbox.Depth = 0;
            this.IsUserEnabledCheckbox.Font = new System.Drawing.Font("Roboto", 10F);
            this.IsUserEnabledCheckbox.Location = new System.Drawing.Point(204, 135);
            this.IsUserEnabledCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.IsUserEnabledCheckbox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.IsUserEnabledCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.IsUserEnabledCheckbox.Name = "IsUserEnabledCheckbox";
            this.IsUserEnabledCheckbox.Ripple = true;
            this.IsUserEnabledCheckbox.Size = new System.Drawing.Size(26, 30);
            this.IsUserEnabledCheckbox.TabIndex = 26;
            this.IsUserEnabledCheckbox.UseVisualStyleBackColor = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(12, 75);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(189, 30);
            this.materialLabel7.TabIndex = 48;
            this.materialLabel7.Text = "Изберете потребител:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 105);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(189, 30);
            this.materialLabel1.TabIndex = 49;
            this.materialLabel1.Text = "Избран потребител:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 135);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(189, 30);
            this.materialLabel2.TabIndex = 50;
            this.materialLabel2.Text = "Активен:";
            // 
            // UsersListBox
            // 
            this.UsersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UsersListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsersListBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersListBox.Location = new System.Drawing.Point(207, 70);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(150, 29);
            this.UsersListBox.TabIndex = 51;
            // 
            // SelectedUsernameBox
            // 
            this.SelectedUsernameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectedUsernameBox.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedUsernameBox.Location = new System.Drawing.Point(207, 105);
            this.SelectedUsernameBox.Name = "SelectedUsernameBox";
            this.SelectedUsernameBox.ReadOnly = true;
            this.SelectedUsernameBox.Size = new System.Drawing.Size(150, 29);
            this.SelectedUsernameBox.TabIndex = 52;
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Window;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(224, 171);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(68, 36);
            this.CancelBtn.TabIndex = 56;
            this.CancelBtn.Text = "Назад";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.AutoSize = true;
            this.SubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SubmitBtn.BackColor = System.Drawing.SystemColors.Window;
            this.SubmitBtn.Depth = 0;
            this.SubmitBtn.Icon = null;
            this.SubmitBtn.Location = new System.Drawing.Point(108, 171);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Primary = false;
            this.SubmitBtn.Size = new System.Drawing.Size(75, 36);
            this.SubmitBtn.TabIndex = 55;
            this.SubmitBtn.Text = "Запази";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // DisableUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 295);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.SelectedUsernameBox);
            this.Controls.Add(this.UsersListBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.IsUserEnabledCheckbox);
            this.Controls.Add(this.LogLabel);
            this.Name = "DisableUserForm";
            this.Sizable = false;
            this.Text = "DisableUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogLabel;
        private MaterialSkin.Controls.MaterialCheckBox IsUserEnabledCheckbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox UsersListBox;
        private System.Windows.Forms.TextBox SelectedUsernameBox;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialFlatButton SubmitBtn;
    }
}