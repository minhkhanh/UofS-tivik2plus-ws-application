using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace DataExtractingClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            HtmlWeb hweb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument hdoc = hweb.Load("http://thvl.vn/");
            richExtrDescr.Text = hdoc.DocumentNode.OuterHtml;

            Match m = new Regex(@"[\w-]+@([\w-]+\.)+[\w-]+").Match(richExtrDescr.Text);
            while (m.Success)
            {
                MessageBox.Show(m.Value);
                m = m.NextMatch();
            }

            
        }
    }
}
