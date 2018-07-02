using RozetkaResearch.BLL.Models;
using RozetkaResearch.BLL.Services;
using RozetkaResearch.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozetkaResearch
{
    public partial class MainForm : Form
    {
        private readonly OfferService _offerService;

        private List<Offer> _currentOffers;
        private List<ResearchOffer> _researchOffers;

        private bool _isResearch = false;
        private bool _isOfferLoading = false;
        private DateTime _expirationDate;

        public MainForm()
        {
            InitializeComponent();
            _offerService = new OfferService();
            _currentOffers = new List<Offer>();
            _researchOffers = new List<ResearchOffer>();
            _expirationDate = DateTime.ParseExact("07/05/2018", "MM/dd/yyyy", null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SecurityLoader.IsExpiredDate(_expirationDate))
            {
                this.Close();
            };
            RefreshElements();
        }

        private void RefreshElements()
        {
            txtYmlUrl.Enabled = !_isResearch && !_isOfferLoading;
            chkFromDevice.Enabled = !_isResearch && !_isOfferLoading;
            lblResearchStatus.Visible = _isResearch;
            btnOpenXML.Enabled = !_isResearch && !_isOfferLoading;
            btnResearch.Enabled = !_isResearch && !_isOfferLoading && _currentOffers.Count > 0;
            btnReport.Enabled = !_isResearch && _researchOffers.Count > 0;
        }

        private async void btnOpenXML_Click(object sender, EventArgs e)
        {
            if (chkFromDevice.Checked)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileName = openFileDialog.FileName;
                    try
                    {
                        var text = File.ReadAllText(fileName);
                        _currentOffers = _offerService.GetOffersFromXml(text).ToList();
                        lblProcess.Text = $"Найдено {_currentOffers.Count} товаров";
                    }
                    catch (IOException)
                    {
                    }
                }
                return;
            }

            lblProcess.Text = "Идет загрузка...";
            _isOfferLoading = true;
            RefreshElements();

            var webClient = new HttpClient();
            var ymlResponse = await webClient.GetAsync(txtYmlUrl.Text);
            var ymlContent = await ymlResponse.Content.ReadAsStringAsync();

            _currentOffers = _offerService.GetOffersFromXml(ymlContent).ToList();
            lblProcess.Text = $"Найдено {_currentOffers.Count} товаров";
            _isOfferLoading = false;
            RefreshElements();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _offerService.Dispose();
            if (SecurityLoader.IsExpiredDate(_expirationDate))
            {
                SecurityLoader.RemoveCurrentApp();
            }
        }

        private async void btnResearch_Click(object sender, EventArgs e)
        {
            _researchOffers = new List<ResearchOffer>();
            _isResearch = true;
            RefreshElements();
            var callback = new Action<int, int, bool>( async (i, count, isComplete) =>
            {
                if (isComplete)
                {
                    _isResearch = false;
                    RefreshElements();
                    await GenerateReport();
                    return;
                }
                lblProcess.Text = $"Исследовано {i} товаров из {_currentOffers.Count}";
                lblProcess.Refresh();
                if (count > 0)
                {
                    lblResearchStatus.Text = $"Найдено {count} товаров с ценами дешевле ваших";
                    lblResearchStatus.Refresh();
                }
            });

           await _offerService.ResearchAsync(_currentOffers.ToArray(), callback, _researchOffers);
        }

        private async void btnReport_Click(object sender, EventArgs e)
        {
            await GenerateReport();
        }

        private async Task GenerateReport()
        {
            var content = string.Join("<hr/>", _researchOffers.Select(x => x.Html()));
            var contentBuilder = new StringBuilder($"<h2>Найдено {_researchOffers.Count} товаров с ценами дешевле ваших</h2>");
            contentBuilder.Append(content);
            string template;
            using (var reader = new StreamReader("report.tpl"))
            {
                template = await reader.ReadToEndAsync();
            }
            using (var writer = new StreamWriter("research.html"))
            {
                await writer.WriteLineAsync(template.Replace("{researchContent}", contentBuilder.ToString()));
            }
            System.Diagnostics.Process.Start("research.html");
        }

        private void lblResearchStatus_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
