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
            this.container = new System.Windows.Forms.Panel();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.btnUserInput = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWidth = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.Label();
            this.btnMyContainer = new System.Windows.Forms.Button();
            this.paper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.AutoScroll = true;
            this.paper.Controls.Add(this.container);
            this.paper.Location = new System.Drawing.Point(116, 52);
            this.paper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(993, 724);
            this.paper.TabIndex = 0;
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(993, 721);
            this.container.TabIndex = 3;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.Container_Paint);
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Location = new System.Drawing.Point(23, 242);
            this.lblBoxes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(52, 17);
            this.lblBoxes.TabIndex = 4;
            this.lblBoxes.Text = "lblBoxs";
            // 
            // btnUserInput
            // 
            this.btnUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInput.Location = new System.Drawing.Point(21, 15);
            this.btnUserInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUserInput.Name = "btnUserInput";
            this.btnUserInput.Size = new System.Drawing.Size(228, 53);
            this.btnUserInput.TabIndex = 5;
            this.btnUserInput.Text = "Select Algorithm";
            this.btnUserInput.UseVisualStyleBackColor = true;
            this.btnUserInput.Click += new System.EventHandler(this.btnUserInput_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblResult.Location = new System.Drawing.Point(21, 76);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(64, 25);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnMyContainer);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.btnUserInput);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.lblBoxes);
            this.panel1.Location = new System.Drawing.Point(1116, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 724);
            this.panel1.TabIndex = 7;
            // 
            // txtWidth
            // 
            this.txtWidth.AutoSize = true;
            this.txtWidth.Location = new System.Drawing.Point(23, 177);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(44, 17);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.AutoSize = true;
            this.txtHeight.Location = new System.Drawing.Point(23, 212);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 17);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.Text = "Height";
            // 
            // btnMyContainer
            // 
            this.btnMyContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyContainer.Location = new System.Drawing.Point(283, 15);
            this.btnMyContainer.Margin = new System.Windows.Forms.Padding(4);
            this.btnMyContainer.Name = "btnMyContainer";
            this.btnMyContainer.Size = new System.Drawing.Size(228, 53);
            this.btnMyContainer.TabIndex = 9;
            this.btnMyContainer.Text = "My Container";
            this.btnMyContainer.UseVisualStyleBackColor = true;
            this.btnMyContainer.Click += new System.EventHandler(this.BtnMyContainer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1676, 846);
            this.Controls.Add(this.paper);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.paper.ResumeLayout(false);
            this.paper.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paper;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button box2;
        private System.Windows.Forms.Button box;
        private System.Windows.Forms.Label lblBoxes;
        private System.Windows.Forms.Button btnUserInput;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtWidth;
        private System.Windows.Forms.Label txtHeight;
        private System.Windows.Forms.Button btnMyContainer;
    }
}

