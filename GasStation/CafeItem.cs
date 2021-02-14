using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class CafeItem : UserControl
    {
        public event EventHandler<decimal> PriceChanged;
        
        public decimal TotalPrice { get; set; }
        
        public CafeItemInfo CafeItemInfo { get; }

        public CafeItem()
        {
            InitializeComponent();
            CafeItemInfo = new CafeItemInfo("Хот-дог", 4);
            FillItemInfo();
        }

        public CafeItem(CafeItemInfo cafeItemInfo)
        {
            CafeItemInfo = cafeItemInfo;
            InitializeComponent();
            FillItemInfo();
        }

        private void FillItemInfo()
        {
            ItemCheckbox.Text = CafeItemInfo.Title;
            ItemPrice.Text = CafeItemInfo.Price.ToString(CultureInfo.InvariantCulture);
            ItemCountNumeric.Value = CafeItemInfo.Count;
        }

        private void ItemCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ItemCountNumeric.Enabled = ItemCheckbox.Checked;
            RecalculatePrice();
        }

        private void ItemCountNumeric_ValueChanged(object sender, EventArgs e)
        {
            CafeItemInfo.Count = (int)ItemCountNumeric.Value;
            RecalculatePrice();
        }

        private void RecalculatePrice()
        {
            CafeItemInfo.TotalPrice = ItemCheckbox.Checked
                ? CafeItemInfo.Price * CafeItemInfo.Count
                : 0;

            PriceChanged?.Invoke(this, CafeItemInfo.TotalPrice);
        }
    }
}
