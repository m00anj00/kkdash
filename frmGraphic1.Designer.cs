
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
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.pnlDirections = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBG)).BeginInit();
            this.pnlDirections.SuspendLayout();
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
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(816, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save and close";
            this.btnSave.UseVisualStyleBackColor = false;
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
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(67, 11);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(47, 28);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "é";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(13, 45);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(47, 28);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "ç";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(67, 79);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(47, 28);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "ê";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(121, 45);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(47, 28);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "è";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // pnlDirections
            // 
            this.pnlDirections.BackColor = System.Drawing.Color.White;
            this.pnlDirections.Controls.Add(this.button1);
            this.pnlDirections.Controls.Add(this.btnRight);
            this.pnlDirections.Controls.Add(this.btnDown);
            this.pnlDirections.Controls.Add(this.btnLeft);
            this.pnlDirections.Controls.Add(this.btnUp);
            this.pnlDirections.Location = new System.Drawing.Point(629, 616);
            this.pnlDirections.Name = "pnlDirections";
            this.pnlDirections.Size = new System.Drawing.Size(181, 115);
            this.pnlDirections.TabIndex = 7;
            this.pnlDirections.Visible = false;
            this.pnlDirections.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDirections_Paint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(67, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGraphic1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.pnlDirections);
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
            this.pnlDirections.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBG;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTopVal;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Panel pnlDirections;
        private System.Windows.Forms.Button button1;
    }
}