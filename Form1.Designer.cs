namespace boxfittingapp
{
    partial class Form1
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
            this.container = new System.Windows.Forms.Panel();
            this.txtHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.Label();
            this.txtMyString = new System.Windows.Forms.TextBox();
            this.paper.SuspendLayout();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.Controls.Add(this.txtMyString);
            this.paper.Controls.Add(this.container);
            this.paper.Controls.Add(this.txtHeight);
            this.paper.Controls.Add(this.txtWidth);
            this.paper.Location = new System.Drawing.Point(-6, 11);
            this.paper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(1560, 832);
            this.paper.TabIndex = 0;
            // 
            // container
            // 
            this.container.AutoScroll = true;
            this.container.AutoScrollMargin = new System.Drawing.Size(500, 500);
            this.container.AutoScrollMinSize = new System.Drawing.Size(400, 400);
            this.container.AutoSize = true;
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.container.Location = new System.Drawing.Point(202, 36);
            this.container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1090, 734);
            this.container.TabIndex = 3;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.Container_Paint);
            // 
            // txtHeight
            // 
            this.txtHeight.AutoSize = true;
            this.txtHeight.Location = new System.Drawing.Point(149, 459);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 17);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Text = "Height";
            // 
            // txtWidth
            // 
            this.txtWidth.AutoSize = true;
            this.txtWidth.Location = new System.Drawing.Point(670, 17);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(44, 17);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "Width";
            // 
            // txtMyString
            // 
            this.txtMyString.Location = new System.Drawing.Point(1350, 334);
            this.txtMyString.Multiline = true;
            this.txtMyString.Name = "txtMyString";
            this.txtMyString.Size = new System.Drawing.Size(165, 309);
            this.txtMyString.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 846);
            this.Controls.Add(this.paper);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.TextBox txtMyString;
    }
}

