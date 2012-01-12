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
        private int _lastIndex = -1;

        public Main()
        {
            InitializeComponent();

            InitChannelGrid();
            txbServiceUrl.Text = @"http://localhost:5021/Service1.svc";
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
            //gridChannel.Columns.Add("LichHong", "Report lịch");
            gridChannel.Columns.Add("ConHoatDong", "Còn hoạt động");

            gridChannel.Columns["STT"].Width = 50;
            gridChannel.Columns["TenMaKenh"].Width = 120;
            gridChannel.Columns["LinkPhat"].Width = 120;
            gridChannel.Columns["NguonGoc"].Width = 120;
            gridChannel.Columns["MoTaRutTrich"].Width = 150;
            gridChannel.Columns["MoTaKenh"].Width = 120;
            gridChannel.Columns["LinkHong"].Width = 120;
            //gridChannel.Columns["LichHong"].Width = 120;
            gridChannel.Columns["ConHoatDong"].Width = 120;
        }

        private string GetChannelListReqUrl()
        {
            return txbServiceUrl.Text.Trim() + "/kenhtv/getlist";
        }

        private string GetUpdateReqUrl()
        {
            return txbServiceUrl.Text.Trim() + "/kenhtv/update";
        }

        private string GetInsertReqUrl()
        {
            return txbServiceUrl.Text.Trim() + "/insertkenhtv";
        }

        private string GetDeleteReqUrl(int id)
        {
            return txbServiceUrl.Text.Trim() + "/kenhtv/delete?maKenh=" + id.ToString();
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
                //txbScheReport.Text = channel.LichHong.ToString();
                ckbAvailable.Checked = channel.ConHoatDong;
            }
        }

        private void LoadChannelGrid(int rowIdx)
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
                        arrChannels[i].LichHong,
                        arrChannels[i].ConHoatDong
                        );

                    gridChannel.Rows[i].Tag = arrChannels[i];
                }

                if (rowIdx >= 0 && rowIdx < gridChannel.Rows.Count)
                    FocusRow(rowIdx);
                else if (gridChannel.Rows.Count > 0)
                    FocusRow(0);

                respStream.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadChannelGrid(0);
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
            HttpWebRequest request = WebRequest.Create(GetUpdateReqUrl()) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = @"application/xml; charset=utf-8";

            request.ContentLength = reqBody.GetLength(0);
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(reqBody, 0, reqBody.GetLength(0));
            reqStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStream = response.GetResponseStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(bool));

                bool affectedRows = (bool)serializer.ReadObject(respStream);
                if (affectedRows == false)
                    DialogUtil.ShowFailureMsgbox("Cập nhật không thành công.");
                else
                {
                    LoadChannelGrid(-1);
                }

                respStream.Close();
            }
        }

        private void AddChannel(KenhTV_DTO channel)
        {
            byte[] reqBody = GetBytes(channel);

            HttpWebRequest request = WebRequest.Create(GetInsertReqUrl()) as HttpWebRequest;
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

                bool result = (bool)serializer.ReadObject(respStream);
                if (result == false)
                    DialogUtil.ShowFailureMsgbox("Thêm không thành công.");
                else
                {
                    LoadChannelGrid(gridChannel.RowCount - 1);
                }

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
            //txbScheReport.Text = null;
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

            //if (int.TryParse(txbScheReport.Text, out report))
            //    channel.LichHong = report;

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

                //if (int.TryParse(txbScheReport.Text, out report))
                //    channel.LichHong = report;

                UpdateChannel(channel);
            }
        }

        private void DeleteChannel(int id)
        {
            HttpWebRequest request = WebRequest.Create(GetDeleteReqUrl(id)) as HttpWebRequest;
            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStream = response.GetResponseStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(bool));

                bool affectedRows = (bool)serializer.ReadObject(respStream);
                if (affectedRows == false)
                    DialogUtil.ShowFailureMsgbox("Xóa không thành công.");
                else
                    LoadChannelGrid(0);

                respStream.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KenhTV_DTO channel = groupDetail.Tag as KenhTV_DTO;
            if (channel != null)
            {
                DeleteChannel(channel.MaKenh);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadChannelGrid(0);
        }

        private void gridChannel_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            FocusRow(e.RowIndex);
        }
    }
}
