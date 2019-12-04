using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boxfittingapp
{
    public partial class UserInput : Form
    {
        public MainForm MainForm { get; set; }
        public Regex NumberOnly { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }


        public UserInput(MainForm mainForm, int inputWidth, int inputHeight)
        {
            InitializeComponent();
            MainForm = mainForm;
            txtWidth.Text = inputWidth.ToString();
            txtHeight.Text = inputHeight.ToString();
        }

        private void btnBoxFittingHorizontal_Click(object sender, EventArgs e)
        {
            txtWidth.Visible = true;
            txtHeight.Visible = false;
            lblHeight.Visible = false;
            txtWidth.Focus();
            lblWidth.Visible = true;
            IsVertical = false;
            IsHorizontal = true;
        }

        private void btnBoxFittingVeritical_Click(object sender, EventArgs e)
        {
            IsVertical = true;
            IsHorizontal = false;
            lblHeight.Visible = true;
            lblWidth.Visible = true;
            txtHeight.Visible = true;
            txtWidth.Visible = true;
            txtWidth.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btbSubmit_Click(object sender, EventArgs e)
        {
            if (IsHorizontal)
            {
                if (!string.IsNullOrWhiteSpace(txtWidth.Text) && txtWidth.Text.All(char.IsDigit))
                {
                    MainForm.SetMaxWidth(int.Parse(txtWidth.Text));
                    MainForm.SetAlgorithmType(true);
                    this.Dispose();
                    errorProvider.Clear();
                }
                else
                {
                    errorProvider.SetError(txtWidth, "Please Enter number only");
                }
               
            }
            else if (IsVertical)
            {
                if (!string.IsNullOrWhiteSpace(txtHeight.Text) && txtHeight.Text.All(char.IsDigit)&& !string.IsNullOrWhiteSpace(txtWidth.Text) && txtWidth.Text.All(char.IsDigit))
                {
                    errorProvider.Clear();
                    MainForm.SetMaxHeight(int.Parse(txtHeight.Text));
                    MainForm.SetMaxWidth(int.Parse(txtWidth.Text));
                    MainForm.SetAlgorithmType(false);
                    this.Dispose();
                }
                else if (!string.IsNullOrWhiteSpace(txtWidth.Text) && txtWidth.Text.All(char.IsDigit))
                {
                    errorProvider.SetError(txtWidth, "Please Enter number only.");
                }
                else if (!string.IsNullOrWhiteSpace(txtHeight.Text) && txtHeight.Text.All(char.IsDigit))
                {
                    errorProvider.SetError(txtHeight, "Please Enter number only.");
                }
            }
        }
    }
}
