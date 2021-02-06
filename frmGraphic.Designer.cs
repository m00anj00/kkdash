
namespace kkdash
{
    partial class frmGraphic
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBG
            // 
            this.pictureBG.Location = new System.Drawing.Point(2, -1);
            this.pictureBG.Name = "pictureBG";
            this.pictureBG.Size = new System.Drawing.Size(1167, 590);
            this.pictureBG.TabIndex = 0;
            this.pictureBG.TabStop = false;
            this.pictureBG.Click += new System.EventHandler(this.pictureBG_Click);
            // 
            // frmGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 811);
            this.Controls.Add(this.pictureBG);
            this.Name = "frmGraphic";
            this.Text = "frmGraphic";
            this.Load += new System.EventHandler(this.frmGraphic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBG;
    }
}