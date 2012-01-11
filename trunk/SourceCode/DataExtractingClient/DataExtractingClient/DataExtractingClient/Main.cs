using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Runtime.Serialization;

namespace AdminClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            InitChannelGrid();
            txbServiceUrl.Text = @"http://localhost:6421/Service1.svc";
        }

        private void InitChannelGrid()
        { 
            gridChannel.Columns.Add("STT", "STT");
            gridChannel.Columns.Add("TenMaKenh", "Tên mã kênh");
            gridChannel.Columns.Add("LinkPhat", "Link phát");
            gridChannel.Columns.Add("NguonGoc", "Nguồn gốc");
            gridChannel.Columns.Add("MoTaRutTrich", "Mô tả rút trích");
            gridChannel.Columns.Add("MoTaKenh", "Mô tả kênh");
            gridChannel.Columns.Add("LinkHong", "Report link");
            gridChannel.Columns.Add("LichHong", "Report lich");

            gridChannel.Columns["STT"].Width = 50;
            gridChannel.Columns["TenMaKenh"].Width = 120;
            gridChannel.Columns["LinkPhat"].Width = 120;
            gridChannel.Columns["NguonGoc"].Width = 120;
            gridChannel.Columns["MoTaRutTrich"].Width = 150;
            gridChannel.Columns["MoTaKenh"].Width = 120;
            gridChannel.Columns["LinkHong"].Width = 120;
            gridChannel.Columns["LichHong"].Width = 120;
        }

        private string GetChannelListReqUrl()
        {
            return txbServiceUrl.Text.Trim() + "/kenhtv/getlist";
        }

        private string GetUpdateReqUrl()
        {
            return txbServiceUrl.Text.Trim() + "/kenhtv/getlist";
        }

        private void FocusRow(int index)
        {
            KenhTV_DTO channel = gridChannel.Rows[index].Tag as KenhTV_DTO;

            if (channel != null)
            {
                groupDetail.Tag = channel;

                txbChanCode.Text = channel.TenMaKenh;
                txbSourceLink.Text = channel.Link;
                txbSourcePage.Text = channel.NguonGoc;
                txbExtrDescr.Text = channel.MoTaRutTrich;
                txbChanDescr.Text = channel.MoTaKenh;
                txbLinkReport.Text = channel.LinkHong.ToString();
                txbScheReport.Text = channel.LichHong.ToString();
                ckbAvailable.Checked = channel.ConHoatDong;
            }
        }

        private void LoadChannelGrid()
        {
            HttpWebRequest request = WebRequest.Create(GetChannelListReqUrl()) as HttpWebRequest;
            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStream = response.GetResponseStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(KenhTV_DTO[]));

                KenhTV_DTO[] arrChannels = (KenhTV_DTO[])serializer.ReadObject(respStream);

                gridChannel.Rows.Clear();
                for (int i = 0; i < arrChannels.Count(); ++i)
                {
                    gridChannel.Rows.Add(i + 1,
                        arrChannels[i].TenMaKenh,
                        arrChannels[i].Link,
                        arrChannels[i].NguonGoc,
                        arrChannels[i].MoTaRutTrich,
                        arrChannels[i].MoTaKenh,
                        arrChannels[i].LinkHong,
                        arrChannels[i].LichHong
                        );

                    gridChannel.Rows[i].Tag = arrChannels[i];
                }

                if (gridChannel.Rows.Count > 0)
                    FocusRow(0);

                respStream.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadChannelGrid();
        }

        private byte[] GetBytes(KenhTV_DTO channel)
        {
            MemoryStream ms = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(KenhTV_DTO));
            serializer.WriteObject(ms, channel);
            byte[] rawBytes = ms.ToArray();
            byte[] result = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(rawBytes, 0, rawBytes.Length));

            ms.Close();

            return result;
        }

        private void UpdateChannel(KenhTV_DTO channel)
        {
            byte[] reqBody = GetBytes(channel);

            // marked: URI_STRING
            HttpWebRequest request = WebRequest.Create(txbServiceUrl.Text) as HttpWebRequest;
            request.Method = "PUT";
            request.ContentType = @"application/xml; charset=utf-8";

            request.ContentLength = reqBody.GetLength(0);
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(reqBody, 0, reqBody.GetLength(0));
            reqStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStream = response.GetResponseStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(int));

                int affectedRows = (int)serializer.ReadObject(respStream);
                if (affectedRows <= 0)
                    MessageBox.Show("Cập nhật không thành công.");
                else
                    LoadChannelGrid();

                respStream.Close();
            }
        }

        private void AddChannel(KenhTV_DTO channel)
        {
            byte[] reqBody = GetBytes(channel);
            
            HttpWebRequest request = WebRequest.Create(txbServiceUrl.Text + "/kenhtv/insert") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = @"application/xml; charset=utf-8";

            request.ContentLength = reqBody.Length;
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(reqBody, 0, reqBody.Length);
            reqStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStream = response.GetResponseStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(bool));

                bool result  = (bool)serializer.ReadObject(respStream);
                if (result == false)
                    Utilities.ShowFailureMsgbox("Thêm không thành công.");
                else
                    LoadChannelGrid();

                respStream.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            groupDetail.Tag = null;
            txbChanCode.Text = null;
            txbChanDescr.Text = null;
            txbSourceLink.Text = null;
            txbSourcePage.Text = null;
            txbExtrDescr.Text = null;
            txbLinkReport.Text = null;
            txbScheReport.Text = null;
            txbChanCode.Focus();
            ckbAvailable.Checked = true;

            gridChannel.ClearSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            KenhTV_DTO channel = new KenhTV_DTO();
            channel.TenMaKenh = txbChanCode.Text;
            channel.Link = txbSourceLink.Text;
            channel.MoTaKenh = txbChanDescr.Text;
            channel.MoTaRutTrich = txbExtrDescr.Text;
            channel.NguonGoc = txbSourcePage.Text;
            channel.ConHoatDong = ckbAvailable.Checked;

            int report = 0;
            if (int.TryParse(txbLinkReport.Text, out report))
                channel.LinkHong = report;

            if (int.TryParse(txbLinkReport.Text, out report))
                channel.LichHong = report;

            AddChannel(channel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            KenhTV_DTO channel = groupDetail.Tag as KenhTV_DTO;
            if (channel != null)
            {
                channel.TenMaKenh = txbChanCode.Text;
                channel.Link = txbSourceLink.Text;
                channel.MoTaKenh = txbChanDescr.Text;
                channel.MoTaRutTrich = txbExtrDescr.Text;
                channel.NguonGoc = txbSourcePage.Text;
                channel.ConHoatDong = ckbAvailable.Checked;

                int report = 0;
                if (int.TryParse(txbLinkReport.Text, out report))
                    channel.LinkHong = report;

                if (int.TryParse(txbLinkReport.Text, out report))
                    channel.LichHong = report;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadChannelGrid();
        }

        private void gridChannel_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            FocusRow(e.RowIndex);
        }
    }
}
