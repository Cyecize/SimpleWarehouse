namespace SimpleWarehouse.Forms
{
    partial class CreateUserForm
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
            this.PasswordConfirm = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.RolesDropdown = new System.Windows.Forms.ComboBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.UsernameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SubmitBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.LogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordConfirm
            // 
            this.PasswordConfirm.BackColor = System.Drawing.SystemColors.Window;
            this.PasswordConfirm.Depth = 0;
            this.PasswordConfirm.Hint = "Парола отново";
            this.PasswordConfirm.Location = new System.Drawing.Point(121, 129);
            this.PasswordConfirm.MaxLength = 32767;
            this.PasswordConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordConfirm.Name = "PasswordConfirm";
            this.PasswordConfirm.PasswordChar = '\0';
            this.PasswordConfirm.SelectedText = "";
            this.PasswordConfirm.SelectionLength = 0;
            this.PasswordConfirm.SelectionStart = 0;
            this.PasswordConfirm.Size = new System.Drawing.Size(242, 23);
            this.PasswordConfirm.TabIndex = 52;
            this.PasswordConfirm.TabStop = false;
            this.PasswordConfirm.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 129);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(103, 30);
            this.materialLabel3.TabIndex = 51;
            this.materialLabel3.Text = "Парола:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.SystemColors.Window;
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Hint = "Парола";
            this.PasswordBox.Location = new System.Drawing.Point(121, 99);
            this.PasswordBox.MaxLength = 32767;
            this.PasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '\0';
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.Size = new System.Drawing.Size(242, 23);
            this.PasswordBox.TabIndex = 50;
            this.PasswordBox.TabStop = false;
            this.PasswordBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 99);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(103, 30);
            this.materialLabel1.TabIndex = 49;
            this.materialLabel1.Text = "Парола:";
            // 
            // RolesDropdown
            // 
            this.RolesDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RolesDropdown.Font = new System.Drawing.Font("Segoe UI", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RolesDropdown.Location = new System.Drawing.Point(121, 158);
            this.RolesDropdown.Name = "RolesDropdown";
            this.RolesDropdown.Size = new System.Drawing.Size(242, 27);
            this.RolesDropdown.TabIndex = 48;
            // 
            // materialLabel7
            // 
            this.materialLabel7.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(12, 159);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(83, 30);
            this.materialLabel7.TabIndex = 47;
            this.materialLabel7.Text = "Права:";
            // 
            // UsernameBox
            // 
            this.UsernameBox.BackColor = System.Drawing.SystemColors.Window;
            this.UsernameBox.Depth = 0;
            this.UsernameBox.Hint = "Име (Латиница)";
            this.UsernameBox.Location = new System.Drawing.Point(121, 70);
            this.UsernameBox.MaxLength = 32767;
            this.UsernameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.PasswordChar = '\0';
            this.UsernameBox.SelectedText = "";
            this.UsernameBox.SelectionLength = 0;
            this.UsernameBox.SelectionStart = 0;
            this.UsernameBox.Size = new System.Drawing.Size(242, 23);
            this.UsernameBox.TabIndex = 46;
            this.UsernameBox.TabStop = false;
            this.UsernameBox.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 70);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(103, 30);
            this.materialLabel2.TabIndex = 45;
            this.materialLabel2.Text = "Потр. Име:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Window;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(207, 196);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(68, 36);
            this.CancelBtn.TabIndex = 54;
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
            this.SubmitBtn.Location = new System.Drawing.Point(91, 196);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Primary = false;
            this.SubmitBtn.Size = new System.Drawing.Size(75, 36);
            this.SubmitBtn.TabIndex = 53;
            this.SubmitBtn.Text = "Запази";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(13, 264);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(35, 13);
            this.LogLabel.TabIndex = 55;
            this.LogLabel.Text = "label1";
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 289);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.PasswordConfirm);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.RolesDropdown);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.materialLabel2);
            this.Name = "CreateUserForm";
            this.Sizable = false;
            this.Text = "EditUsersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordConfirm;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox RolesDropdown;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField UsernameBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialFlatButton SubmitBtn;
        private System.Windows.Forms.Label LogLabel;
    }
}