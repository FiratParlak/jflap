using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace jflap
{
    class nfa
    {
        Panel p;
        Form frm;
        int q;
        bool sur;
        int curX, curY;
        string secili;
        int btn1X;
        int btn1Y;
       
        bool tiklandiCiz;
        int ustundemi;
        Graphics fromGraphics = null;
        List<Button> listAdd = new List<Button>();
        List<Button> listRemove = new List<Button>();
        List<int> removeCount = new List<int>();
        public nfa(Panel p, Form f)
        {
            this.p = p;
            frm = f;
            q = 0;
            secili = "click";
            ustundemi = 0;
            p.Click += ileriGeri;
            
            fromGraphics = p.CreateGraphics();
            
        }

        public void ciz(int x, int y, ImageList ll)
        {
            if (secili == "ciz")
            {
                Point newLoc = new Point(x - 25, y - 25); 

                Button button1 = new Button();

                button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                //image
                button1.BackgroundImage = ll.Images[0];

                button1.BackgroundImageLayout = ImageLayout.Center;
                //button1.Size = button1.BackgroundImage.Size;
                //event
                button1.MouseUp += kalktı;
                button1.MouseDown += uzerinde;
                button1.MouseMove += panelCiz;
                button1.MouseMove += kaydir;
                button1.MouseHover += odakla;
                button1.MouseClick += cizgi;

                button1.TabIndex = q;
                button1.Enabled = false;
                button1.TabStop = true;
                button1.Size = new Size(52, 52);
                button1.Location = newLoc;
                int sayi = buttonText();
                //foreach (Button item in listAdd)
                //{
                //    if(sayi == int.Parse( item.Text.Substring(1)))
                //    {
                //        sayi = buttonText();
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}
                if (sayi == -1)
                {
                    
                    button1.Text = "q" + q;
                    button1.Name = "q" + q;
                    q++;
                }
                else
                {
                    
                    button1.Text = "q" + sayi;
                    button1.Name = "q" + sayi;
                    
                }




                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(new Rectangle(Point.Empty, button1.Size));
                button1.Region = new Region(gp); //Butonu Oval yaptık


                p.Controls.Add(button1);
                listAdd.Add(button1);
                button1.BringToFront();
                button1.FlatStyle = FlatStyle.Flat;
                button1.FlatAppearance.BorderSize = 0;

               
            }
        }
        public void gerisar()
        {
            removeCount.Add(int.Parse(listAdd.Last().Text.Substring(1)));
            listRemove.Add(listAdd.Last());
            p.Controls.Remove(listAdd.Last());
            listAdd.Remove(listAdd.Last());
        }
        public void ilerisar()
        {
            if (removeCount.LongCount() != 0)
            {
                removeCount.Remove(removeCount.Last());
            }
            if (removeCount.LongCount()!=0)
            {
                listAdd.Add(listRemove.Last());
                p.Controls.Add(listRemove.Last());

                listRemove.Remove(listRemove.Last());
            }
           
            
        }
        public void cizgi(object sender, MouseEventArgs e)
        {
            if (secili == "cizik")
            {

                
               
            }else if(secili == "kill")
            {
                listRemove.Add(((Button)sender));
                removeCount.Add(int.Parse(((Button)sender).Text.Substring(1)));
                removeCount.Sort();
                p.Controls.Remove((Button)sender);
            }

        }
        public void duzenle()
        {
            foreach (Button item in listAdd)
            {
                //removeCount.FindIndex(int.Parse( item.Text.Substring(1)));
            }
        }
        public void ileriGeri(object sender, EventArgs e)
        {
            if (secili == "ileri")
            {
               
               
                if (removeCount.LongCount() != 0)
                {
                    removeCount.Remove(removeCount.Last());
                    listAdd.Add(listRemove.Last());
                    p.Controls.Add(listRemove.Last());

                    listRemove.Remove(listRemove.Last());
                }

            }
            else if (secili == "geri")
            {
                if (listAdd.LongCount() != 0 )
                {
                    removeCount.Add(int.Parse(listAdd.Last().Text.Substring(1)));
                    removeCount.Sort();
                    listRemove.Add(listAdd.Last());
                    p.Controls.Remove(listAdd.Last());
                    listAdd.Remove(listAdd.Last());

                }
                
            }

        }
        private int buttonText()
        {
            int sayi;
            if(removeCount.LongCount()==0)
            {
                return -1;
            }
            else
            {
              
                sayi = removeCount.First();
                removeCount.Remove(removeCount.First());
                return sayi;
            }
            
            
        }
        private void panelCiz(object sender,MouseEventArgs e)
        {
            if(secili == "cizik" && tiklandiCiz && ustundemi <2)
            {
                
                fromGraphics.Clear(Color.White);

               
                
                Pen myPen = new Pen(Color.Black, 2);
                //form üzerine grafik çizileceğini belirtir--------------------



                SolidBrush drawBrush = new SolidBrush(Color.Black);
                Font drawFont = new Font("Times New Roman", 12, FontStyle.Bold);


                //çizgi çizimi-------------------------------------------------------------
                fromGraphics.DrawLine(myPen, btn1X, btn1Y, e.X + ((Button)sender).Left, e.Y + ((Button)sender).Top);
                
            }
        }
        public void cizik(int x, int y)
        {

        }
        private void odakla(object sender, EventArgs e)
        {
            if (secili == "cizik")
            {
                ustundemi++;
            }
        }

        private void kalktı(object sender, MouseEventArgs e)
        {
            sur = false;
            if(secili == "cizik")
            {

                SolidBrush drawBrush = new SolidBrush(Color.Black);
                Font drawFont = new Font("Times New Roman", 12, FontStyle.Bold);
                if (ustundemi == 1)
                {
                    Pen myPen = new Pen(Color.Black, 2);
                    fromGraphics.DrawLine(myPen, btn1X, btn1Y, ((Button)sender).Left + 25, ((Button)sender).Top + 25);
                    ustundemi=0;
                }
                else
                {                
                
                if (btn1X < Cursor.Position.X)
                {
                    fromGraphics.DrawString("çizgi", drawFont, drawBrush, btn1X, btn1Y);
                }
                if (btn1X > Cursor.Position.X)
                {
                    fromGraphics.DrawString("çizgi", drawFont, drawBrush, btn1Y, btn1X);
                }
                tiklandiCiz = false;
                 
                }
            }
            
        }
        private void uzerinde(object sender, MouseEventArgs e)
        {
            if (secili == "cizik")
            {
                
                btn1X = ((Button)sender).Left + 25;
                btn1Y = ((Button)sender).Top + 25;
                tiklandiCiz = true;
               
            }else if (secili == "click")
            {
                ((Button)sender).BringToFront();
                sur = true;
                curX = Cursor.Position.X - ((Button)sender).Left;
                curY = Cursor.Position.Y - ((Button)sender).Top;
            }
            
        }
        private void kaydir(object sender, MouseEventArgs e)
        {
            
            if (sur && secili =="click")
            {
                ((Button)sender).Left = Cursor.Position.X - curX;

                ((Button)sender).Top = Cursor.Position.Y - curY;
                
            }else if(sur && secili == "cizik")
            {
                
            }
        }
        public void secenek(string secim,object sender)
        {
            
            if (((ToolStripButton)sender).Text == "ciz")
            {
                foreach (Button item in p.Controls)
                {
                    item.Enabled = false;
                }
            }
            else
            {
                foreach (Button item in p.Controls)
                {
                    item.Enabled = true;
                }
            }
            secili = secim;
        }

        
        
    }
}
