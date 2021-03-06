using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class MainForm : Form
    {
        private readonly List<GasInfo> _gasInfos;
        private readonly List<CafeItemInfo> _cafeItemInfos;

        public MainForm()
        {
            InitializeComponent();

            _gasInfos = GetGasInfos();
            _cafeItemInfos = GetCafeItemInfos();
            GasTypeCombobox.Items.AddRange(_gasInfos.ToArray());
            FillCafeItems();

            GetCafeItemsFromConfig();
        }

        private List<CafeItemInfo> GetCafeItemsFromConfig()
        {
            var result = new List<CafeItemInfo>();

            var items = ConfigurationManager.GetSection("cafeItemList");

            return result;
        }

        private List<GasInfo> GetGasInfos()
        {
            return new List<GasInfo>
            {
                new GasInfo("A-95", 28.90m),
                new GasInfo("A-92", 25.90m),
                new GasInfo("Propane", 13.00m),
                new GasInfo("DT", 22.90m),
            };
        }

        private List<CafeItemInfo> GetCafeItemInfos()
        {
            return new List<CafeItemInfo>
            {
                new CafeItemInfo("Хот-дог", 4.00m),
                new CafeItemInfo("Гамбургер", 5.40m),
                new CafeItemInfo("Картопля фрі", 7.20m),
                new CafeItemInfo("Кока-кола", 4.40m),
                new CafeItemInfo("Капучіно", 4.40m)
            };
        }

        private void FillCafeItems()
        {
            foreach (var cafeItemInfo in _cafeItemInfos)
            {
                var ci = new CafeItem(cafeItemInfo)
                {
                    Dock = DockStyle.Top
                };
                ci.PriceChanged += CalculateDisplayPrice;
                CafeItemsPanel.Controls.Add(ci);
            }
        }

        private void GasTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var index = GasTypeCombobox.SelectedIndex;

            var price = _gasInfos[index].Price;

            GasPriceText.Text = price.ToString(CultureInfo.InvariantCulture);
        }
        
        private void CalculateDisplayPrice(object sender, decimal price)
        {
            var totalPrice = _cafeItemInfos.Sum(c => c.TotalPrice);
            TotalPriceLbl.Text = totalPrice.ToString(CultureInfo.InvariantCulture);
        }
    }
}
