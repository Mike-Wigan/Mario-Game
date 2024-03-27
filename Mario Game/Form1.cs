using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mario_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create an instance of the MainScreen
            level1 level1 = new level1();

            // Add UC to form and give focus
            this.Controls.Add(level1);
            level1.Focus();

            Form f = this.FindForm();
            f.Controls.Remove(this);

            WindowState = FormWindowState.Maximized;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
