namespace SimpleWarehouse.Forms
{
    partial class LoginForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.DbLabel = new System.Windows.Forms.Label();
            this.LogLabel = new System.Windows.Forms.Label();
            this.FirstRunBtn = new System.Windows.Forms.Button();
            this.ChooseDatabaseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Enter Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Login with Username";
            // 
            // PasswordField
            // 
            this.PasswordField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordField.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordField.HideSelection = false;
            this.PasswordField.Location = new System.Drawing.Point(16, 172);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(261, 29);
            this.PasswordField.TabIndex = 18;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // UsernameField
            // 
            this.UsernameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameField.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameField.Location = new System.Drawing.Point(17, 118);
            this.UsernameField.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(261, 29);
            this.UsernameField.TabIndex = 17;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.Location = new System.Drawing.Point(17, 205);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(261, 38);
            this.LoginBtn.TabIndex = 16;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // DbLabel
            // 
            this.DbLabel.AutoSize = true;
            this.DbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DbLabel.Location = new System.Drawing.Point(14, 69);
            this.DbLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DbLabel.Name = "DbLabel";
            this.DbLabel.Size = new System.Drawing.Size(69, 17);
            this.DbLabel.TabIndex = 22;
            this.DbLabel.Text = "Database";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLabel.Location = new System.Drawing.Point(14, 258);
            this.LogLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(0, 17);
            this.LogLabel.TabIndex = 23;
            // 
            // FirstRunBtn
            // 
            this.FirstRunBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstRunBtn.Location = new System.Drawing.Point(163, 282);
            this.FirstRunBtn.Name = "FirstRunBtn";
            this.FirstRunBtn.Size = new System.Drawing.Size(114, 24);
            this.FirstRunBtn.TabIndex = 21;
            this.FirstRunBtn.Text = "Първо стартиране";
            this.FirstRunBtn.UseVisualStyleBackColor = true;
            this.FirstRunBtn.Click += new System.EventHandler(this.FirstRunBtn_Click);
            // 
            // ChooseDatabaseBtn
            // 
            this.ChooseDatabaseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseDatabaseBtn.Location = new System.Drawing.Point(215, 65);
            this.ChooseDatabaseBtn.Name = "ChooseDatabaseBtn";
            this.ChooseDatabaseBtn.Size = new System.Drawing.Size(65, 24);
            this.ChooseDatabaseBtn.TabIndex = 24;
            this.ChooseDatabaseBtn.Text = "Избор";
            this.ChooseDatabaseBtn.UseVisualStyleBackColor = true;
            this.ChooseDatabaseBtn.Click += new System.EventHandler(this.ChooseDatabaseBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 318);
            this.Controls.Add(this.ChooseDatabaseBtn);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.DbLabel);
            this.Controls.Add(this.FirstRunBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.LoginBtn);
            this.MinimumSize = new System.Drawing.Size(250, 300);
            this.Name = "LoginForm";
            this.Sizable = false;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label DbLabel;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Button FirstRunBtn;
        private System.Windows.Forms.Button ChooseDatabaseBtn;
    }
}