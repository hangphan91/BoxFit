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
            this.components = new System.ComponentModel.Container();
            this.paper = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.btnUserInput = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMyContainer = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.Label();
            this.tabDrawPanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gdw = new System.Windows.Forms.DataGridView();
            this.rectangularBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPanel = new System.Windows.Forms.DataGridView();
            this.paper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDrawPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.AutoScroll = true;
            this.paper.Controls.Add(this.container);
            this.paper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paper.Location = new System.Drawing.Point(3, 3);
            this.paper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paper.Name = "paper";
            this.paper.Padding = new System.Windows.Forms.Padding(80, 40, 40, 40);
            this.paper.Size = new System.Drawing.Size(605, 507);
            this.paper.TabIndex = 0;
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.container.Location = new System.Drawing.Point(54, 48);
            this.container.Name = "container";
            this.container.Padding = new System.Windows.Forms.Padding(40, 40, 0, 0);
            this.container.Size = new System.Drawing.Size(508, 438);
            this.container.TabIndex = 5;
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Location = new System.Drawing.Point(15, 214);
            this.lblBoxes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(52, 17);
            this.lblBoxes.TabIndex = 4;
            this.lblBoxes.Text = "lblBoxs";
            // 
            // btnUserInput
            // 
            this.btnUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInput.Location = new System.Drawing.Point(18, 14);
            this.btnUserInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserInput.Name = "btnUserInput";
            this.btnUserInput.Size = new System.Drawing.Size(228, 53);
            this.btnUserInput.TabIndex = 5;
            this.btnUserInput.Text = "Select Algorithm";
            this.btnUserInput.UseVisualStyleBackColor = true;
            this.btnUserInput.Click += new System.EventHandler(this.btnUserInput_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnMyContainer);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.btnUserInput);
            this.panel1.Controls.Add(this.lblBoxes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(608, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 507);
            this.panel1.TabIndex = 7;
            // 
            // btnMyContainer
            // 
            this.btnMyContainer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMyContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyContainer.Location = new System.Drawing.Point(18, 75);
            this.btnMyContainer.Margin = new System.Windows.Forms.Padding(4);
            this.btnMyContainer.Name = "btnMyContainer";
            this.btnMyContainer.Size = new System.Drawing.Size(228, 53);
            this.btnMyContainer.TabIndex = 9;
            this.btnMyContainer.Text = "My Container";
            this.btnMyContainer.UseVisualStyleBackColor = true;
            this.btnMyContainer.Click += new System.EventHandler(this.BtnMyContainer_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.AutoSize = true;
            this.txtWidth.Location = new System.Drawing.Point(15, 149);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(44, 17);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.AutoSize = true;
            this.txtHeight.Location = new System.Drawing.Point(15, 184);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(49, 17);
            this.txtHeight.TabIndex = 8;
            this.txtHeight.Text = "Height";
            // 
            // tabDrawPanel
            // 
            this.tabDrawPanel.Controls.Add(this.tabPage1);
            this.tabDrawPanel.Controls.Add(this.tabPage2);
            this.tabDrawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDrawPanel.Location = new System.Drawing.Point(0, 0);
            this.tabDrawPanel.Name = "tabDrawPanel";
            this.tabDrawPanel.SelectedIndex = 0;
            this.tabDrawPanel.Size = new System.Drawing.Size(1034, 542);
            this.tabDrawPanel.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.paper);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1026, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Draw Panel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPanel);
            this.tabPage2.Controls.Add(this.gdw);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1026, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grid Panel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gdw
            // 
            this.gdw.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdw.Location = new System.Drawing.Point(3, 3);
            this.gdw.Name = "gdw";
            this.gdw.RowHeadersWidth = 51;
            this.gdw.RowTemplate.Height = 24;
            this.gdw.Size = new System.Drawing.Size(1020, 507);
            this.gdw.TabIndex = 0;
            // 
            // dgvPanel
            // 
            this.dgvPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPanel.Location = new System.Drawing.Point(3, 3);
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.RowHeadersWidth = 51;
            this.dgvPanel.RowTemplate.Height = 24;
            this.dgvPanel.Size = new System.Drawing.Size(1020, 507);
            this.dgvPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1034, 542);
            this.Controls.Add(this.tabDrawPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.paper.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabDrawPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paper;
        private System.Windows.Forms.Button box2;
        private System.Windows.Forms.Button box;
        private System.Windows.Forms.Label lblBoxes;
        private System.Windows.Forms.Button btnUserInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtWidth;
        private System.Windows.Forms.Label txtHeight;
        private System.Windows.Forms.Button btnMyContainer;
        private System.Windows.Forms.TabControl tabDrawPanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gdw;
        private System.Windows.Forms.BindingSource rectangularBoxBindingSource;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.DataGridView dgvPanel;
    }
}

