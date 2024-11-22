using System;
using System.Windows.Forms;

namespace WeatherAssistant
{
    public partial class frmInputDialog : Form
    {
        public int ProblemNumber { get; private set; }

        public frmInputDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInput.Text, out int problemNumber))
            {
                ProblemNumber = problemNumber;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("請輸入有效的題號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
