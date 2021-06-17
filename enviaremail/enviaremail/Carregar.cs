using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enviaremail
{
    public partial class Carregar : Form
    {
        public Carregar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Start();
            progressBar1.Value = progressBar1.Value + 1;
            label2.Text = progressBar1.Value + "% concluido";

            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Seja Bem Vindo", "Boas Vindas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Visible = false;
                Email mn = new Email();
                mn.ShowDialog();
                Close();
            }

            progressBar1.PerformStep();
        }

        private void Carregar_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }
    }
}
