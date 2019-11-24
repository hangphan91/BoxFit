namespace boxfittingapp
{
    partial class UserInput
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btbSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.btnBoxFittingHorizontal = new System.Windows.Forms.Button();
            this.btnBoxFittingVeritical = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btbSubmit);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lblHeight);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.btnBoxFittingHorizontal);
            this.panel1.Controls.Add(this.btnBoxFittingVeritical);
            this.panel1.Controls.Add(this.lblInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 448);
            this.panel1.TabIndex = 0;
            // 
            // btbSubmit
            // 
            this.btbSubmit.BackColor = System.Drawing.Color.Cyan;
            this.btbSubmit.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btbSubmit.FlatAppearance.BorderSize = 2;
            this.btbSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btbSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbSubmit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btbSubmit.Location = new System.Drawing.Point(449, 346);
            this.btbSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btbSubmit.Name = "btbSubmit";
            this.btbSubmit.Size = new System.Drawing.Size(117, 47);
            this.btbSubmit.TabIndex = 10;
            this.btbSubmit.Text = "Submit";
            this.btbSubmit.UseVisualStyleBackColor = false;
            this.btbSubmit.Click += new System.EventHandler(this.btbSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Cyan;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(319, 346);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 47);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(136, 262);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(93, 29);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height:";
            this.lblHeight.Visible = false;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(136, 214);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(85, 29);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "Width:";
            this.lblWidth.Visible = false;
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(243, 258);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(159, 36);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.Visible = false;
            // 
            // txtWidth
            // 
            this.txtWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(243, 214);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(159, 36);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.Visible = false;
            this.txtWidth.WordWrap = false;
            // 
            // btnBoxFittingHorizontal
            // 
            this.btnBoxFittingHorizontal.BackColor = System.Drawing.Color.Cyan;
            this.btnBoxFittingHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoxFittingHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoxFittingHorizontal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBoxFittingHorizontal.Location = new System.Drawing.Point(84, 92);
            this.btnBoxFittingHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoxFittingHorizontal.Name = "btnBoxFittingHorizontal";
            this.btnBoxFittingHorizontal.Size = new System.Drawing.Size(205, 86);
            this.btnBoxFittingHorizontal.TabIndex = 4;
            this.btnBoxFittingHorizontal.Text = "Box Fitting Horizontal";
            this.btnBoxFittingHorizontal.UseVisualStyleBackColor = false;
            this.btnBoxFittingHorizontal.Click += new System.EventHandler(this.btnBoxFittingHorizontal_Click);
            // 
            // btnBoxFittingVeritical
            // 
            this.btnBoxFittingVeritical.BackColor = System.Drawing.Color.Cyan;
            this.btnBoxFittingVeritical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoxFittingVeritical.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoxFittingVeritical.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBoxFittingVeritical.Location = new System.Drawing.Point(373, 92);
            this.btnBoxFittingVeritical.Margin = new System.Windows.Forms.Padding(4);
            this.btnBoxFittingVeritical.Name = "btnBoxFittingVeritical";
            this.btnBoxFittingVeritical.Size = new System.Drawing.Size(193, 86);
            this.btnBoxFittingVeritical.TabIndex = 3;
            this.btnBoxFittingVeritical.Text = "Box Fitting Vertical";
            this.btnBoxFittingVeritical.UseVisualStyleBackColor = false;
            this.btnBoxFittingVeritical.Click += new System.EventHandler(this.btnBoxFittingVeritical_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(76, 27);
            this.lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(291, 39);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Pick an Algorithm:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(615, 448);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserInput";
            this.Text = "User Input";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBoxFittingHorizontal;
        private System.Windows.Forms.Button btnBoxFittingVeritical;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btbSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}