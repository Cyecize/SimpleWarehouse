namespace SimpleWarehouse.Forms
{
    partial class ConfirmActionForm
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
            this.ConfirmTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.CancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // ConfirmTextBox
            // 
            this.ConfirmTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmTextBox.Enabled = false;
            this.ConfirmTextBox.Location = new System.Drawing.Point(12, 69);
            this.ConfirmTextBox.Multiline = true;
            this.ConfirmTextBox.Name = "ConfirmTextBox";
            this.ConfirmTextBox.ReadOnly = true;
            this.ConfirmTextBox.Size = new System.Drawing.Size(304, 153);
            this.ConfirmTextBox.TabIndex = 0;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.AutoSize = true;
            this.ConfirmBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmBtn.Depth = 0;
            this.ConfirmBtn.Icon = null;
            this.ConfirmBtn.Location = new System.Drawing.Point(146, 229);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ConfirmBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Primary = false;
            this.ConfirmBtn.Size = new System.Drawing.Size(96, 36);
            this.ConfirmBtn.TabIndex = 27;
            this.ConfirmBtn.Text = "Потвърди";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.AutoSize = true;
            this.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelBtn.Depth = 0;
            this.CancelBtn.Icon = null;
            this.CancelBtn.Location = new System.Drawing.Point(250, 229);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Primary = false;
            this.CancelBtn.Size = new System.Drawing.Size(65, 36);
            this.CancelBtn.TabIndex = 28;
            this.CancelBtn.Text = "Отказ";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ConfirmActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 280);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.ConfirmTextBox);
            this.MinimumSize = new System.Drawing.Size(328, 280);
            this.Name = "ConfirmActionForm";
            this.Sizable = false;
            this.Text = "ConfirmActionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConfirmTextBox;
        private MaterialSkin.Controls.MaterialFlatButton ConfirmBtn;
        private MaterialSkin.Controls.MaterialFlatButton CancelBtn;
    }
}