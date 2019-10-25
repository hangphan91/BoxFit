namespace boxfittingapp
{
    partial class MainForm
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
            this.paper = new System.Windows.Forms.Panel();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.txtHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.Label();
            this.paper.SuspendLayout();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.Controls.Add(this.lblBoxes);
            this.paper.Controls.Add(this.container);
            this.paper.Controls.Add(this.txtHeight);
            this.paper.Controls.Add(this.txtWidth);
            this.paper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paper.Location = new System.Drawing.Point(0, 0);
            this.paper.Margin = new System.Windows.Forms.Padding(2);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(1257, 687);
            this.paper.TabIndex = 0;
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Location = new System.Drawing.Point(901, 26);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(40, 13);
            this.lblBoxes.TabIndex = 4;
            this.lblBoxes.Text = "lblBoxs";
            // 
            // container
            // 
            this.container.AutoScroll = true;
            this.container.AutoSize = true;
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.container.Location = new System.Drawing.Point(51, 26);
            this.container.Margin = new System.Windows.Forms.Padding(2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(818, 641);
            this.container.TabIndex = 3;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.Container_Paint);
            // 
            // txtHeight
            // 
            this.txtHeight.AutoSize = true;
            this.txtHeight.Location = new System.Drawing.Point(11, 370);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(38, 13);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.AutoSize = true;
            this.txtWidth.Location = new System.Drawing.Point(401, 11);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(35, 13);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "Width";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 687);
            this.Controls.Add(this.paper);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.paper.ResumeLayout(false);
            this.paper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paper;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button box2;
        private System.Windows.Forms.Button box;
        private System.Windows.Forms.Label txtHeight;
        private System.Windows.Forms.Label txtWidth;
        private System.Windows.Forms.Label lblBoxes;
    }
}

