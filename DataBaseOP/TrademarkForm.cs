using DataBaseOP.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOP
{
    public partial class TrademarkForm : Form
    {
        private readonly TrademarkController trademarkController;

        public TrademarkForm()
        {
            InitializeComponent();
            trademarkController = new TrademarkController();
        }

        private void TrademarkForm_Load(object sender, EventArgs e)
        {
            trademarkController.GetAllTrademarks(ref dataGridViewTrademarks);
        }
    }
}
