using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProCore.Connector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            LoadEndPoints();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (ApiHelper.GetTokenInfo(ConfigurationSettings.AppSettings.Get("accessToken"), txtBaseUrl.Text))
            {
                label1.Text = ApiHelper.GetData(txtBaseUrl.Text, txtDataEndPoint.Text);

            }
            else
            {
                ApiHelper.RefreshAccessToken(txtBaseUrl.Text, ConfigurationSettings.AppSettings.Get("refreshToken"));
               label1.Text = ApiHelper.GetData(txtBaseUrl.Text, txtDataEndPoint.Text);
            }
        }

        private void LoadEndPoints()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream("EndPoints.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("EndPoint");
            //for (i = 0; i <= xmlnode.Count - 1; i++)
           // List<string> endPoints = new List<string>();
            foreach (XmlNode node in xmlnode)
            {
                lstViewEndPoints.Items.Add(node.InnerText);
            }
            
        }

        private void lstViewEndPoints_Click(object sender, EventArgs e)
        {
            txtDataEndPoint.Text = lstViewEndPoints.SelectedItems[0].Text;
        }
    }
}
