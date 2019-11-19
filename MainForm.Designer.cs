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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.paper = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPanel = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rectangularBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.removeColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnSuggestion = new System.Windows.Forms.Button();
            this.gridViewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsedPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WastedPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrangedBins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerWidthAndHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Suggestions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDrawPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.AutoScroll = true;
            this.paper.Controls.Add(this.btnSuggestion);
            this.paper.Controls.Add(this.btnSaveImage);
            this.paper.Controls.Add(this.btnSave);
            this.paper.Controls.Add(this.container);
            this.paper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paper.Location = new System.Drawing.Point(3, 3);
            this.paper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paper.Name = "paper";
            this.paper.Padding = new System.Windows.Forms.Padding(80, 40, 40, 40);
            this.paper.Size = new System.Drawing.Size(605, 507);
            this.paper.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Aqua;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(54, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save to Grid";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.lblBoxes.Location = new System.Drawing.Point(15, 165);
            this.lblBoxes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(52, 17);
            this.lblBoxes.TabIndex = 4;
            this.lblBoxes.Text = "lblBoxs";
            // 
            // btnUserInput
            // 
            this.btnUserInput.BackColor = System.Drawing.Color.Black;
            this.btnUserInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInput.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUserInput.Location = new System.Drawing.Point(223, 14);
            this.btnUserInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserInput.Name = "btnUserInput";
            this.btnUserInput.Size = new System.Drawing.Size(172, 63);
            this.btnUserInput.TabIndex = 5;
            this.btnUserInput.Text = "Select Algorithm";
            this.btnUserInput.UseVisualStyleBackColor = false;
            this.btnUserInput.Visible = false;
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
            this.btnMyContainer.BackColor = System.Drawing.Color.Black;
            this.btnMyContainer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMyContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyContainer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMyContainer.Location = new System.Drawing.Point(18, 14);
            this.btnMyContainer.Margin = new System.Windows.Forms.Padding(4);
            this.btnMyContainer.Name = "btnMyContainer";
            this.btnMyContainer.Size = new System.Drawing.Size(197, 63);
            this.btnMyContainer.TabIndex = 9;
            this.btnMyContainer.Text = "Set Container Size";
            this.btnMyContainer.UseVisualStyleBackColor = false;
            this.btnMyContainer.Click += new System.EventHandler(this.BtnMyContainer_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.AutoSize = true;
            this.txtWidth.Location = new System.Drawing.Point(15, 100);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(44, 17);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.AutoSize = true;
            this.txtHeight.Location = new System.Drawing.Point(15, 135);
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
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1026, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grid Panel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.dgvPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(40);
            this.panel2.Size = new System.Drawing.Size(1020, 507);
            this.panel2.TabIndex = 2;
            // 
            // dgvPanel
            // 
            this.dgvPanel.AllowUserToAddRows = false;
            this.dgvPanel.AllowUserToOrderColumns = true;
            this.dgvPanel.AutoGenerateColumns = false;
            this.dgvPanel.BackgroundColor = System.Drawing.Color.Azure;
            this.dgvPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPanel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPanel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowID,
            this.UsedPercent,
            this.WastedPercent,
            this.ArrangedBins,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.ContainerWidthAndHeight,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.Image,
            this.Suggestions});
            this.dgvPanel.DataSource = this.gridViewBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPanel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPanel.GridColor = System.Drawing.Color.Gray;
            this.dgvPanel.Location = new System.Drawing.Point(40, 40);
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPanel.RowHeadersWidth = 51;
            this.dgvPanel.RowTemplate.Height = 24;
            this.dgvPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPanel.Size = new System.Drawing.Size(940, 427);
            this.dgvPanel.TabIndex = 1;
            this.dgvPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvPanel_MouseDown);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(830, 474);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(147, 30);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeColumnToolStripMenuItem,
            this.removeRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 56);
            // 
            // removeRowToolStripMenuItem
            // 
            this.removeRowToolStripMenuItem.Image = global::boxfittingapp.Properties.Resources.red_delete_button;
            this.removeRowToolStripMenuItem.Name = "removeRowToolStripMenuItem";
            this.removeRowToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.removeRowToolStripMenuItem.Text = "Remove Row";
            this.removeRowToolStripMenuItem.Click += new System.EventHandler(this.RemoveRowToolStripMenuItem_Click);
            // 
            // removeColumnToolStripMenuItem
            // 
            this.removeColumnToolStripMenuItem.Image = global::boxfittingapp.Properties.Resources.red_delete_button;
            this.removeColumnToolStripMenuItem.Name = "removeColumnToolStripMenuItem";
            this.removeColumnToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.removeColumnToolStripMenuItem.Text = "Remove Column";
            this.removeColumnToolStripMenuItem.Click += new System.EventHandler(this.RemoveColumnToolStripMenuItem_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.Color.Aqua;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveImage.Location = new System.Drawing.Point(199, 14);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(121, 28);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Text = "Show Image";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
            // 
            // btnSuggestion
            // 
            this.btnSuggestion.BackColor = System.Drawing.Color.Aqua;
            this.btnSuggestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuggestion.Location = new System.Drawing.Point(338, 14);
            this.btnSuggestion.Name = "btnSuggestion";
            this.btnSuggestion.Size = new System.Drawing.Size(168, 28);
            this.btnSuggestion.TabIndex = 8;
            this.btnSuggestion.Text = "Get Suggestions Bins";
            this.btnSuggestion.UseVisualStyleBackColor = false;
            this.btnSuggestion.Click += new System.EventHandler(this.BtnSuggestion_Click);
            // 
            // gridViewBindingSource1
            // 
            this.gridViewBindingSource1.DataSource = typeof(boxfittingapp.Model.GridView);
            // 
            // RowID
            // 
            this.RowID.DataPropertyName = "RowID";
            this.RowID.Frozen = true;
            this.RowID.HeaderText = "Row ID";
            this.RowID.MinimumWidth = 6;
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Width = 125;
            // 
            // UsedPercent
            // 
            this.UsedPercent.DataPropertyName = "UsedPercent";
            this.UsedPercent.Frozen = true;
            this.UsedPercent.HeaderText = "Used Percent";
            this.UsedPercent.MinimumWidth = 6;
            this.UsedPercent.Name = "UsedPercent";
            this.UsedPercent.ReadOnly = true;
            this.UsedPercent.Width = 125;
            // 
            // WastedPercent
            // 
            this.WastedPercent.DataPropertyName = "WastedPercent";
            this.WastedPercent.Frozen = true;
            this.WastedPercent.HeaderText = "Wasted Percent";
            this.WastedPercent.MinimumWidth = 6;
            this.WastedPercent.Name = "WastedPercent";
            this.WastedPercent.ReadOnly = true;
            this.WastedPercent.Width = 125;
            // 
            // ArrangedBins
            // 
            this.ArrangedBins.DataPropertyName = "ArrangedBins";
            this.ArrangedBins.HeaderText = "ArrangedBins";
            this.ArrangedBins.MinimumWidth = 6;
            this.ArrangedBins.Name = "ArrangedBins";
            this.ArrangedBins.ReadOnly = true;
            this.ArrangedBins.Width = 125;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "NumberOfMyContainerUsed";
            this.dataGridViewTextBoxColumn18.HeaderText = "Used Containers ";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "WastedArea";
            this.dataGridViewTextBoxColumn10.HeaderText = "Wasted Area";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UsedArea";
            this.dataGridViewTextBoxColumn11.HeaderText = "Used Area";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TotalArea";
            this.dataGridViewTextBoxColumn12.HeaderText = "Total Area";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 125;
            // 
            // ContainerWidthAndHeight
            // 
            this.ContainerWidthAndHeight.DataPropertyName = "ContainerWidthAndHeight";
            this.ContainerWidthAndHeight.HeaderText = "Container Size";
            this.ContainerWidthAndHeight.MinimumWidth = 6;
            this.ContainerWidthAndHeight.Name = "ContainerWidthAndHeight";
            this.ContainerWidthAndHeight.ReadOnly = true;
            this.ContainerWidthAndHeight.Width = 125;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "MaxHeight";
            this.dataGridViewTextBoxColumn13.HeaderText = "Max Height";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 125;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "MaxWidth";
            this.dataGridViewTextBoxColumn14.HeaderText = "Max Width";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsHorizontal";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Is Horizontal";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "HasResult";
            this.dataGridViewCheckBoxColumn2.HeaderText = "HasResult";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 125;
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.HeaderText = "Image";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 125;
            // 
            // Suggestions
            // 
            this.Suggestions.DataPropertyName = "Suggestions";
            this.Suggestions.HeaderText = "Suggestions";
            this.Suggestions.MinimumWidth = 6;
            this.Suggestions.Name = "Suggestions";
            this.Suggestions.ReadOnly = true;
            this.Suggestions.Width = 125;
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangularBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource rectangularBoxBindingSource;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.DataGridView dgvPanel;
        private System.Windows.Forms.BindingSource gridViewBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn containerWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previuosBinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentGap1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentGap2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentContainerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousContainerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn myContainerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimizedBoxListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn myResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wastedAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usedAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isHorizontalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasResultDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMultipleContainersDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfMyContainerUsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gridViewBindingSource1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeRowToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnSuggestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsedPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn WastedPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrangedBins;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerWidthAndHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suggestions;
    }
}

