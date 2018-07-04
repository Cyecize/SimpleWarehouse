namespace SimpleWarehouse.Forms
{
    partial class ChangePasswordForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.OldPasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.NewPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfPassBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SubmitBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(13, 248);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(51, 13);
            this.LogLabel.TabIndex = 0;
            this.LogLabel.Text = "LogLabel";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 23);
            this.label9.TabIndex = 29;
            this.label9.Text = "Стара парола:";
            // 
            // OldPasswordBox
            // 
            this.OldPasswordBox.BackColor = System.Drawing.SystemColors.Window;
            this.OldPasswordBox.Depth = 0;
            this.OldPasswordBox.Hint = "Стара парола";
            this.OldPasswordBox.Location = new System.Drawing.Point(175, 86);
            this.OldPasswordBox.MaxLength = 32767;
            this.OldPasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.OldPasswordBox.Name = "OldPasswordBox";
            this.OldPasswordBox.PasswordChar = '\0';
            this.OldPasswordBox.SelectedText = "";
            this.OldPasswordBox.SelectionLength = 0;
            this.OldPasswordBox.SelectionStart = 0;
            this.OldPasswordBox.Size = new System.Drawing.Size(242, 23);
            this.OldPasswordBox.TabIndex = 53;
            this.OldPasswordBox.TabStop = false;
            this.OldPasswordBox.UseSystemPasswordChar = false;
            // 
            // NewPassBox
            // 
            this.NewPassBox.BackColor = System.Drawing.SystemColors.Window;
            this.NewPassBox.Depth = 0;
            this.NewPassBox.Hint = "**********";
            this.NewPassBox.Location = new System.Drawing.Point(175, 120);
            this.NewPassBox.MaxLength = 32767;
            this.NewPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewPassBox.Name = "NewPassBox";
            this.NewPassBox.PasswordChar = '\0';
            this.NewPassBox.SelectedText = "";
            this.NewPassBox.SelectionLength = 0;
            this.NewPassBox.SelectionStart = 0;
            this.NewPassBox.Size = new System.Drawing.Size(242, 23);
            this.NewPassBox.TabIndex = 55;
            this.NewPassBox.TabStop = false;
            this.NewPassBox.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 23);
            this.label2.TabIndex = 54;
            this.label2.Text = "Нова парола:";
            // 
            // ConfPassBox
            // 
            this.ConfPassBox.BackColor = System.Drawing.SystemColors.Window;
            this.ConfPassBox.Depth = 0;
            this.ConfPassBox.Hint = "**********";
            this.ConfPassBox.Location = new System.Drawing.Point(176, 155);
            this.ConfPassBox.MaxLength = 32767;
            this.ConfPassBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfPassBox.Name = "ConfPassBox";
            this.ConfPassBox.PasswordChar = '\0';
            this.ConfPassBox.SelectedText = "";
            this.ConfPassBox.SelectionLength = 0;
            this.ConfPassBox.SelectionStart = 0;
            this.ConfPassBox.Size = new System.Drawing.Size(242, 23);
            this.ConfPassBox.TabIndex = 57;
            this.ConfPassBox.TabStop = false;
            this.ConfPassBox.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 23);
            this.label3.TabIndex = 56;
            this.label3.Text = "Парола отново";
            // 
            // CancelBtn
            // 
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.BackColor = System.Drawing.SystemColors.Window;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(237, 199);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(68, 36);
            this.CancelBtn.TabIndex = 59;
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
            this.SubmitBtn.Location = new System.Drawing.Point(121, 199);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Primary = false;
            this.SubmitBtn.Size = new System.Drawing.Size(75, 36);
            this.SubmitBtn.TabIndex = 58;
            this.SubmitBtn.Text = "Запази";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 275);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.ConfPassBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NewPassBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OldPasswordBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LogLabel);
            this.Name = "ChangePasswordForm";
            this.Sizable = false;
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialSingleLineTextField OldPasswordBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField NewPassBox;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialSingleLineTextField ConfPassBox;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
        private MaterialSkin.Controls.MaterialFlatButton SubmitBtn;
    }
}