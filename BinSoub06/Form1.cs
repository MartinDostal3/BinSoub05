using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinSoub06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                // StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);
                BinaryWriter bw = new BinaryWriter(fs);
                while (fs.Position < fs.Length)
                {
                    double x = br.ReadDouble();
                    listBox1.Items.Add(x);
                    //if(x<0)
                    //{
                    //    x = 0;
                    //    bw.BaseStream.Position -= sizeof(Int32);
                    //    bw.Write(x);
                    //}
                    //if(x> 100)
                    //{
                    //    x = 0;
                    //    bw.BaseStream.Position -= sizeof(Int32);
                    //    bw.Write(x);
                    //}
                    //listBox2.Items.Add(x);
                  

                }
                fs.Close();



            }

            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor");

            }
        }
    }
}
