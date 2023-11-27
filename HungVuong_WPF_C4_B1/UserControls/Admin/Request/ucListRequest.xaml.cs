using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace HungVuong_WPF_C4_B1
{
    /// <summary>
    /// Interaction logic for ucListRequest.xaml
    /// </summary>
    public partial class ucListRequest : UserControl
    {
        public event ButtonClickHandle buttonClick;
        public delegate void ButtonClickHandle();

        public ucListRequest()
        {
            InitializeComponent();

            XmlDocument doc = new XmlDocument();

            doc.Load(Path.RequestXml);

            XmlNodeList nodes = doc.SelectNodes(Path.AllRequest);

            doc.Save(Path.RequestXml);

            foreach(XmlNode node in nodes)
            {
                if(node.Attributes["Reason"].Value.Length > 50)
                    dgRequests.Items.Add(new { Request = node.Attributes["Request"].Value, Reason = node.Attributes["Reason"].Value.Substring(0, 50) + "...", ReasonTemp = node.Attributes["Reason"].Value, CustomerID = node.Attributes["CustomerID"].Value });
                else 
                    dgRequests.Items.Add(new { Request = node.Attributes["Request"].Value, Reason = node.Attributes["Reason"].Value, ReasonTemp = node.Attributes["Reason"].Value, CustomerID = node.Attributes["CustomerID"].Value });
            }
        }

        private void DeleteAndSaveXml(dynamic item)
        {
            dgRequests.Items.Remove(item);
            List<dynamic> requestLst = new List<dynamic>();
            foreach (var request in dgRequests.Items)
            {
                requestLst.Add(request);
            }

            XMLFileManager.WriteRequest(requestLst);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dynamic item = dgRequests.SelectedItem;
            var confirmRequest = new ConfirmRequest(window);
            confirmRequest.Tag = item.CustomerID;
            confirmRequest.txtRequest.Text = item.Request;
            confirmRequest.txtReason.Text = item.ReasonTemp;
            window.Content = confirmRequest;

            window.ShowDialog();

            if(window.DialogResult == true)
                DeleteAndSaveXml(item);
            else
                DeleteAndSaveXml(item);

            buttonClick?.Invoke();
        }
    }
}
