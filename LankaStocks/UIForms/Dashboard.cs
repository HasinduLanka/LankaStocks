﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LankaStocks.UserControls;
using LankaStocks.Setting;
using static LankaStocks.Core;
using System.Drawing;
using LankaStocks.UIHandle;
using LankaStocks.UIHandle.ContextM;
//41, 11, 31
namespace LankaStocks.UIForms
{
    public partial class Dashboard : Form
    {
        readonly UIMenu menuModern;
        readonly UIMenuA menuClassic;
        readonly MainContext CF = new MainContext();
        private FormContextMenu formContext;
        public Dashboard()
        {
            InitializeComponent();
            if (RemoteDBs.Settings.commonSettings.Get.Interface == MenuInterfaceType.Classic)
            {
                menuClassic = new UIMenuA { Dock = DockStyle.Fill };
                this.panel4.Controls.Add(menuClassic);
            }

            else
            {
                menuModern = new UIMenu { Dock = DockStyle.Fill };
                this.panel4.Controls.Add(menuModern);
            }

            Settings.LoadCtrlSettings(this);

            this.panel1.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;
            this.panel2.BackColor = RemoteDBs.Settings.commonSettings.Get.MenuColor;

            #region ContextMenu
            cmOQC.MenuItems.Add("Open Quick Sell Window", new EventHandler(Open_QC_Window_Click));
            btnIssueItem.ContextMenu = cmOQC;
            CF.button2.Click += Sign_Out_Click;
            CF.button3.Click += Restart_Click;
            CF.button4.Click += Help_Click;
            CF.button5.Click += Exit_Click;
            #endregion

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Core.Shutdown();
            Application.Restart();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Core.Shutdown();
            Application.Exit();
        }

        private void Sign_Out_Click(object sender, EventArgs e)
        {
            Forms.login.Show();
            this.Hide();
        }

        public List<string> i = new List<string>();
        readonly ContextMenu cmOQC = new ContextMenu();

        #region This Form

        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            if (panel2.Width < 35)
            {
                pblogo.Visible = false;
                btnabout.Text = "";
                btnSettings.Text = "";
            }
            else
            {
                pblogo.Visible = true;
                btnabout.Text = "About";
                btnSettings.Text = "Settings";
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Shutdown();
            Application.Exit();
        }

        private void BtnManageItem_Click(object sender, EventArgs e)
        {
            Forms.frmanageItems = new UIForms.FrmanageItems();
            Forms.frmanageItems.Show();
        }

        private void BtnManageData_Click(object sender, EventArgs e)
        {
            Forms.frmanageData = new UIForms.FrmanageData();
            Forms.frmanageData.Show();
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            Forms.frmSales = new UIForms.FrmSales();
            Forms.frmSales.Show();
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            Forms.frmTransaction = new UIForms.FrmTransaction();
            Forms.frmTransaction.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Forms.frmSettings = new UIForms.FrmSettings(true);
            Forms.frmSettings.ShowDialog();
        }

        private void Open_QC_Window_Click(object sender, EventArgs e)
        {
            Forms.frmQuickSale = new FrmQuickSale();
            Forms.frmQuickSale.ShowDialog();
        }
        #endregion

        private void Dashboard_Load(object sender, EventArgs e)
        {
            _ = new PanelMenu(panel2, btnhide, 34, panel2.Width);
            formContext = new FormContextMenu(btnhide, CF);
            if (RemoteDBs.Settings.commonSettings.Get.Interface == MenuInterfaceType.Classic)
            {
                menuClassic.labelTotal.Font = new Font(menuClassic.labelTotal.Font.Name.ToString(), menuClassic.labelTotal.Font.Size + 8);
                menuClassic.labelInNO.Font = new Font(menuClassic.labelInNO.Font.Name.ToString(), menuClassic.labelInNO.Font.Size + 2);
                menuClassic.xuiClock1.Font = new Font(menuClassic.xuiClock1.Font.Name.ToString(), menuClassic.xuiClock1.Font.Size + 10);
                menuClassic.btnIssue.Font = new Font(menuClassic.btnIssue.Font.Name.ToString(), menuClassic.btnIssue.Font.Size + 8);
            }
            else
            {
                foreach (Control s in menuModern.flPanel.Controls)
                {
                    s.Size = new Size(196, 296);
                }
                menuModern.uiBasicSale1.labelTotal.Font = new Font(menuModern.uiBasicSale1.labelTotal.Font.Name.ToString(), menuModern.uiBasicSale1.labelTotal.Font.Size + 5);
                menuModern.uiBasicSale1.labelInNO.Font = new Font(menuModern.uiBasicSale1.labelInNO.Font.Name.ToString(), menuModern.uiBasicSale1.labelInNO.Font.Size + 2);
                menuModern.uiBasicSale1.btnIssue.Font = new Font(menuModern.uiBasicSale1.btnIssue.Font.Name.ToString(), menuModern.uiBasicSale1.btnIssue.Font.Size + 5);
            }
        }
    }
}
