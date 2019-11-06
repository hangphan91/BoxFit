using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boxfittingapp
{
    public partial class FixSizeContainer : Form
    {
        private MainForm _mainForm;
        public int Width { get; set; }
        public int Height { get; set; }
        public FixSizeContainer(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!txtHeight.Text.All(Char.IsDigit)|| string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                errorProvider.SetError(txtHeight, "Height contains number only");

            }
            if (!txtWidth.Text.All(Char.IsDigit)|| string.IsNullOrWhiteSpace(txtWidth.Text))
            {
                errorProvider.SetError(txtWidth, "Width contains number only");
            }
            if (!string.IsNullOrWhiteSpace(txtHeight.Text) && !string.IsNullOrWhiteSpace(txtWidth.Text))
            {
                errorProvider.Clear();
                Width = int.Parse(txtWidth.Text);
                Height = int.Parse(txtHeight.Text);
                _mainForm.SetContainerSizes(Width,Height);
                _mainForm.SetAlgorithmType(chkHorizontal.Checked);
                this.Dispose();
            }
        }

        private void BtnCanceling_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FixSizeContainer_Load(object sender, EventArgs e)
        {
            txtHeight.Text = _mainForm.MyContainer.Height.ToString();
            txtWidth.Text = _mainForm.MyContainer.Width.ToString();
        }

        private void ChkHorizontal_Click(object sender, EventArgs e)
        {
            chkVertical.Checked = false;
        }

        private void ChkVertical_Click(object sender, EventArgs e)
        {
            chkHorizontal.Checked = false;
        }
    }
}
