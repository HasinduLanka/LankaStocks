﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LankaStocks.UserControls
{
    public partial class UIBasicSale : UserControl
    {
        public UIBasicSale()
        {
            InitializeComponent();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            Forms.frmRefund = new UIForms.FrmRefund();
            Forms.frmRefund.ShowDialog();
        }

        private void BtnIssue_Click(object sender, EventArgs e)
        {

        }
    }
}
