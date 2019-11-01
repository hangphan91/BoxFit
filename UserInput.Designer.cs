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
            this.lblInput = new System.Windows.Forms.Label();
            this.btnBoxFittingVeritical = new System.Windows.Forms.Button();
            this.btnBoxFittingHorizontal = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btbSubmit = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkMultiplecontainers = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkMultiplecontainers);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 364);
            this.panel1.TabIndex = 0;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(57, 22);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(232, 31);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Pick an Algorithm:";
            // 
            // btnBoxFittingVeritical
            // 
            this.btnBoxFittingVeritical.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoxFittingVeritical.Location = new System.Drawing.Point(280, 75);
            this.btnBoxFittingVeritical.Name = "btnBoxFittingVeritical";
            this.btnBoxFittingVeritical.Size = new System.Drawing.Size(145, 70);
            this.btnBoxFittingVeritical.TabIndex = 3;
            this.btnBoxFittingVeritical.Text = "Box Fitting Vertical";
            this.btnBoxFittingVeritical.UseVisualStyleBackColor = true;
            this.btnBoxFittingVeritical.Click += new System.EventHandler(this.btnBoxFittingVeritical_Click);
            // 
            // btnBoxFittingHorizontal
            // 
            this.btnBoxFittingHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoxFittingHorizontal.Location = new System.Drawing.Point(63, 75);
            this.btnBoxFittingHorizontal.Name = "btnBoxFittingHorizontal";
            this.btnBoxFittingHorizontal.Size = new System.Drawing.Size(154, 70);
            this.btnBoxFittingHorizontal.TabIndex = 4;
            this.btnBoxFittingHorizontal.Text = "Box Fitting Horizontal";
            this.btnBoxFittingHorizontal.UseVisualStyleBackColor = true;
            this.btnBoxFittingHorizontal.Click += new System.EventHandler(this.btnBoxFittingHorizontal_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(182, 174);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(120, 30);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.Visible = false;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(182, 210);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(120, 30);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.Visible = false;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(102, 174);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(69, 25);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "Width:";
            this.lblWidth.Visible = false;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(102, 213);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(74, 25);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height:";
            this.lblHeight.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(239, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btbSubmit
            // 
            this.btbSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btbSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbSubmit.Location = new System.Drawing.Point(337, 305);
            this.btbSubmit.Name = "btbSubmit";
            this.btbSubmit.Size = new System.Drawing.Size(88, 38);
            this.btbSubmit.TabIndex = 10;
            this.btbSubmit.Text = "Submit";
            this.btbSubmit.UseVisualStyleBackColor = false;
            this.btbSubmit.Click += new System.EventHandler(this.btbSubmit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // chkMultiplecontainers
            // 
            this.chkMultiplecontainers.AutoSize = true;
            this.chkMultiplecontainers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMultiplecontainers.Location = new System.Drawing.Point(107, 255);
            this.chkMultiplecontainers.Name = "chkMultiplecontainers";
            this.chkMultiplecontainers.Size = new System.Drawing.Size(198, 29);
            this.chkMultiplecontainers.TabIndex = 11;
            this.chkMultiplecontainers.Text = "Multiple Containers";
            this.chkMultiplecontainers.UseVisualStyleBackColor = true;
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 364);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.CheckBox chkMultiplecontainers;
    }
}