using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jflap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        nfa cizim;
       

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cizim = new nfa(panel1,this.FindForm());

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            cizim.ciz(e.X,e.Y,ımageList1);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            cizim.cizik(e.X, e.Y);
        }

        private void button5_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            cizim.secenek(((Button)sender).Text,sender);
        }

        private void button5_LocationChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            cizim.secenek(((ToolStripButton)sender).Text, sender);
        }

        private void toolStripButton5_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void toolStripButton6_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
