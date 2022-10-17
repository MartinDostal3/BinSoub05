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

namespace binSoub07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("../../sport.txt");
            FileStream fs = new FileStream("../../sport.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                char[] sep = { ';' };
                string[] radek = line.Split(sep);
               
                int osc = int.Parse(radek[0]);
                string jmeno = radek[1];
                string prijmeni = radek[2];
                char pohlavi = char.Parse(radek[3]);
                int vyska = int.Parse(radek[4]);
                int hmotnost = int.Parse(radek[5]);

                bw.Write(osc);
                bw.Write(jmeno);
                bw.Write(prijmeni);
                bw.Write(pohlavi);
                bw.Write(vyska);
                bw.Write(hmotnost);
            }
            sr.Close();
            fs.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
               
                /* string[] radek = {osc.ToString(), jmeno, prijmeni, pohlavi.ToString(), vyska.ToString(), hmotnost.ToString()};

                 for(int i = 0; i < radek.Length; i++)
                 {
                     textBox1.Line = radek;
                 }*/

                int osc = br.ReadInt32();
                textBox1.Text += osc;
                textBox1.Text += " ";
                string jmeno = br.ReadString();
                textBox1.Text += jmeno;
                textBox1.Text += " ";
                string prijmeni = br.ReadString();
                textBox1.Text += prijmeni;
                textBox1.Text += " ";
                char pohlavi = br.ReadChar();
                textBox1.Text += pohlavi;
                textBox1.Text += " ";
                int vyska = br.ReadInt32();
                textBox1.Text += vyska;
                textBox1.Text += " ";
                int hmotnost = br.ReadInt32();
                textBox1.Text += hmotnost;
                textBox1.Text += "\r\n";

                





            }
            fs.Close();
        }
    }
}
