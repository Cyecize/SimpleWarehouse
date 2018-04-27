namespace SimpleWarehouse.Forms
{
    partial class ErrorForm
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
            this.ErrorBox = new System.Windows.Forms.TextBox();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // ErrorBox
            // 
            this.ErrorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorBox.Enabled = false;
            this.ErrorBox.Font = new System.Drawing.Font("Segoe UI", 18.33962F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorBox.Location = new System.Drawing.Point(12, 71);
            this.ErrorBox.Multiline = true;
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(376, 275);
            this.ErrorBox.TabIndex = 0;
            this.ErrorBox.Text = "This is a sampl eagea gae ae ejab a hae auobu baeuo aeg aee error message";
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(180, 359);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(41, 36);
            this.materialFlatButton2.TabIndex = 23;
            this.materialFlatButton2.Text = "OK";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.ErrorBox);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ErrorForm";
            this.Text = "Грешка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ErrorBox;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
    }
}