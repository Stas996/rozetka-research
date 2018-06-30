using RozetkaResearch.BLL.Services;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RozetkaResearch
{
    public partial class Form1 : Form
    {
        private readonly OfferService _offerService;

        public Form1()
        {
            InitializeComponent();
            _offerService = new OfferService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenXML_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                try
                {
                    var text = File.ReadAllText(fileName);
                    var offers = _offerService.GetOffersFromXml(text);
                    var result = _offerService.Research(offers.Take(20));
                }
                catch (IOException)
                {
                }
            }
            //var urls = new[] 
            //{
            //    RozetkaUrls.GetSearchUrl("Кресло-качели Bambi M 2130-3 Blue (M 2130)"),
            //    RozetkaUrls.GetSearchUrl("Велосипед Turbo Trike M 3195-2A Green (M 3195)"),
            //    RozetkaUrls.GetSearchUrl("Стульчик для кормления Carrello Chef CRL-10001 Blue"),
            //    RozetkaUrls.GetSearchUrl("Конструктор Zhorya Гладиаторы ZYC-0872-1-2-3-4"),
            //    RozetkaUrls.GetSearchUrl("Конструктор Zhorya Гладиаторы ZYC 0889")
            //};
            //_researchService.Research(urls);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _offerService.Dispose();
        }
    }
}
