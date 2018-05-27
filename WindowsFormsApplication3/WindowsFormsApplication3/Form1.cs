using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string old;
      
            old = textBox1.Text;
            

            string kirb = "АӘБВГҒДЕЖЗИЙІКҚЛМНҢОӨПРСТУҮҰФХЫЭ"; // creating cirillic alphabet
            string kirm = "аәбвгғдежзийікқлмнңоөпрстуүұфхыэ";
         

            string latm = "aábvgģdejzĭĭikqlmnńoóprstýúufhye"; // creating Latin alphabet
            string latb = "AÁBVGĢDEJZĬĬIKQLMNŃOÓPRSTÝÚUFHYE";
           
            if (comboBox1.SelectedIndex == 1) // for cirillic alphabet
            {
                for (int i = 0; i < old.Length; i++)
                    for (int j = 0; j < kirb.Length; j++) // replacing corresponding characters
                    {
                        if (old[i] == kirb[j]) old = old.Replace(old[i], latb[j]);
                        else if (old[i] == kirm[j]) old = old.Replace(old[i], latm[j]);
                    }
                for (int i = 0; i < old.Length; i++) // special (not single) characters
                {
                    if (old[i] == 'я')
                    {
                       old = old.Remove(i, 1);
                       old = old.Insert(i,"ia");
                    }
                    else if (old[i] == 'ю')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "iý");
                    }
                    else if (old[i] == 'ш')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "sh");
                    }
                    else if (old[i] == 'ч')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "ch");
                    }
                    if (old[i] == 'Я')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "Ia");
                    }
                    else if (old[i] == 'Ю')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "Iý");
                    }
                    else if (old[i] == 'Ш')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "Sh");
                    }
                    else if (old[i] == 'Ч')
                    {
                        old = old.Remove(i, 1);
                        old = old.Insert(i, "Ch");
                    }
                }
                
            }
            else // for Latin alphabet
            {
                for (int i = 0; i < old.Length; i++)
                    for (int j = 0; j < latb.Length; j++)
                    {
                        if (old[i] == latb[j]) old = old.Replace(old[i], kirb[j]); // replacing correcponding characters
                        else if (old[i] == latm[j]) old = old.Replace(old[i], kirm[j]);

                    }
            }


            
            textBox2.Text = old; //Output the result
        }

      

        private void офАлфавитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            { 

                textBox1.Text = File.ReadAllText(ofd.FileName);
                
            }
            button1_Click(sender,e);

            File.WriteAllText(ofd.FileName, textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 1;
        }
    }
}
