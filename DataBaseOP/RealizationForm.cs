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
    public partial class RealizationForm : Form
    {
        private readonly RealizationController realizationController;

        public RealizationForm()
        {
            InitializeComponent();
            realizationController = new RealizationController();
        }

        private void RealizationForm_Load(object sender, EventArgs e)
        {
            realizationController.GetAllRealizations(ref dataGridViewRealizations);
        }
    }
}
