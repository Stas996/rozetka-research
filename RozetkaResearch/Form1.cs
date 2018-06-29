using RozetkaResearch.BLL.Models;
using RozetkaResearch.BLL.Serializers;
using System;
using System.IO;
using System.Windows.Forms;

namespace RozetkaResearch
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

        private void btnOpenXML_Click(object sender, EventArgs e)
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(Offer[]));

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                try
                {
                    var text = File.ReadAllText(fileName);
                    Offer[] offers;
                    offers = XmlSerializer.Deserialize<Offer[]>(text);
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
