
namespace kkdash
{
    partial class frmGraphic1
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
            this.pictureBG = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTopVal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBG
            // 
            this.pictureBG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBG.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBG.Location = new System.Drawing.Point(10, 10);
            this.pictureBG.Name = "pictureBG";
            this.pictureBG.Size = new System.Drawing.Size(800, 600);
            this.pictureBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBG.TabIndex = 0;
            this.pictureBG.TabStop = false;
            this.pictureBG.Click += new System.EventHandler(this.pictureBG_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 616);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTopVal
            // 
            this.txtTopVal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTopVal.Location = new System.Drawing.Point(178, 616);
            this.txtTopVal.Name = "txtTopVal";
            this.txtTopVal.Size = new System.Drawing.Size(143, 32);
            this.txtTopVal.TabIndex = 2;
            this.txtTopVal.Visible = false;
            // 
            // frmGraphic1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.txtTopVal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBG);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraphic1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel1";
            this.Load += new System.EventHandler(this.frmGraphic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBG;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTopVal;
    }
}