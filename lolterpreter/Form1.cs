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
using System.Text.RegularExpressions;

namespace lolterpreter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            openFileDialog1.Filter = "lol files (*.lol)|*.lol";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;

                    textBox1.Text = text;

                    //split per line
                    string[] perLine = text.Split('\n');
                    foreach (string word in perLine)
                    {
                        Regex delimiter = new Regex(@"^(?<hi>HAI|KTHXBYE)");
                        Match match = delimiter.Match(word);

                        if (match.Success)
                        {
                            LexemeTable.Rows.Add(match.Groups["hi"].Value, "Program Delimeter");
                            
                        }

                        Regex gimmeh = new Regex(@"^(?<gimmeh>GIMMEH)\s(?<vari>.+)");
                        match = gimmeh.Match(word);
                        if (match.Success)
                        {
                            LexemeTable.Rows.Add(match.Groups["gimmeh"].Value, "Input Keyword");
                            LexemeTable.Rows.Add(match.Groups["vari"].Value, "Variable name");

                        }

                        Regex visLit = new Regex("^(?<vis>VISIBLE) (?<d1>\")(?<vari>.+)(?< d1 >\")");
                        match = gimmeh.Match(word);
                        if (match.Success)
                        {
                            LexemeTable.Rows.Add(match.Groups["gimmeh"].Value, "Input Keyword");
                            LexemeTable.Rows.Add(match.Groups["vari"].Value, "Variable name");

                        }
                    }
                    
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
