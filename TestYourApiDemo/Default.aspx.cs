using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using RestSharp.Authenticators;

namespace TestYourApiDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TokenKey"] != null && Session["MackAddress"] != null)
            {
                if (CheckMackAndTocken())
                {
                    if (!IsPostBack)
                    {
                        UserListBind();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public bool CheckMackAndTocken()
        {
            string TokenKey = Session["TokenKey"].ToString();
            string MackAddress = Session["MackAddress"].ToString();
            string url = "http://kundan.webtechsolution.net/api/ValidLogin";
            string body = "{\"TokenKey\":\"" + TokenKey + "\",\"DeviceInfo\":\"" + MackAddress + "\"}";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic S3VuZGFuOjEyMzQ=");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            JObject jobj = JObject.Parse(content);
            string statusCode = jobj["StatusCode"].ToString();
            if (statusCode == "200")
            {
                return true;
            }
            else
            {
                Session["TokenKey"] = null;
                Session["MackAddress"] = null;
                return false;
            }

        }
        public void UserListBind()
        {
            string url = "http://kundan.webtechsolution.net/api/GetAllUser";
            string body = @"";
            var client = new RestClient(url);
            client.Timeout = -1;
            string username = "Kundan";
            string password = "1234";
            client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            //content = "\"{\\\"StatusCode\\\":200,\\\"StatusMsg\\\":\\\"SucessfullyFetchData\\\",\\\"Data\\\":[{\\\"Id\\\":1,\\\"MobileNo\\\":\\\"9798501225\\\",\\\"Name\\\":\\\"KundanSinghRana\\\",\\\"Email\\\":\\\"kundanmth@gmail.com\\\",\\\"Address\\\":\\\"Delhi,India\\\",\\\"City\\\":\\\"Noida,Up\\\",\\\"PinCode\\\":\\\"201301\\\",\\\"UserName\\\":\\\"kundan12\\\",\\\"Pass\\\":\\\"1234\\\",\\\"Token\\\":null},{\\\"Id\\\":2,\\\"MobileNo\\\":\\\"7982516747\\\",\\\"Name\\\":\\\"UjjwallSingh\\\",\\\"Email\\\":\\\"ujjwall@gmail.com\\\",\\\"Address\\\":\\\"Delhi\\\",\\\"City\\\":\\\"Delhi\\\",\\\"PinCode\\\":\\\"201301\\\",\\\"UserName\\\":\\\"kundan12\\\",\\\"Pass\\\":\\\"1234\\\",\\\"Token\\\":null},{\\\"Id\\\":4,\\\"MobileNo\\\":\\\"123456\\\",\\\"Name\\\":\\\"Kundan\\\",\\\"Email\\\":\\\"kunda@gmail.com\\\",\\\"Address\\\":\\\"Delhi,India\\\",\\\"City\\\":\\\"Noida,Up\\\",\\\"PinCode\\\":\\\"201301\\\",\\\"UserName\\\":\\\"kundan12\\\",\\\"Pass\\\":\\\"1234\\\",\\\"Token\\\":null},{\\\"Id\\\":2014,\\\"MobileNo\\\":\\\"12345567799\\\",\\\"Name\\\":\\\"kkkk\\\",\\\"Email\\\":\\\"ksgfgfg@gmail.com\\\",\\\"Address\\\":\\\"Peeragarhi\\\",\\\"City\\\":\\\"Delhi\\\",\\\"PinCode\\\":\\\"110087\\\",\\\"UserName\\\":null,\\\"Pass\\\":null,\\\"Token\\\":null},{\\\"Id\\\":2017,\\\"MobileNo\\\":\\\"1234556779\\\",\\\"Name\\\":\\\"kkkk\\\",\\\"Email\\\":\\\"ksgfgfg@gmail.com\\\",\\\"Address\\\":\\\"Peeragarhi\\\",\\\"City\\\":\\\"Delhi\\\",\\\"PinCode\\\":\\\"110087\\\",\\\"UserName\\\":null,\\\"Pass\\\":null,\\\"Token\\\":null},{\\\"Id\\\":2018,\\\"MobileNo\\\":\\\"9747546575\\\",\\\"Name\\\":\\\"Ks\\\",\\\"Email\\\":\\\"ksr@gmail.com\\\",\\\"Address\\\":\\\"Delhi,India\\\",\\\"City\\\":\\\"Delhi\\\",\\\"PinCode\\\":\\\"110096\\\",\\\"UserName\\\":null,\\\"Pass\\\":null,\\\"Token\\\":null},{\\\"Id\\\":2020,\\\"MobileNo\\\":\\\"9575865976\\\",\\\"Name\\\":\\\"KsRana\\\",\\\"Email\\\":\\\"ksr@gmail.com\\\",\\\"Address\\\":\\\"Delhi,India\\\",\\\"City\\\":\\\"Delhi\\\",\\\"PinCode\\\":\\\"110096\\\",\\\"UserName\\\":null,\\\"Pass\\\":null,\\\"Token\\\":null}]}\"";
            JObject jObject = JObject.Parse(content);
            string statusCode = jObject["StatusCode"].ToString();
            if (statusCode == "200")
            {
                string Data = jObject["Data"].ToString();
                JArray Arr = JArray.Parse(Data);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("MobileNo"), new DataColumn("Name"), new DataColumn("Email"), new DataColumn("Address"), new DataColumn("City"), new DataColumn("PinCode") });
                for (int i = 0; i < Arr.Count; i++)
                {
                    string MobileNo = Arr[i]["MobileNo"].ToString();
                    string Name = Arr[i]["Name"].ToString();
                    string Email = Arr[i]["Email"].ToString();
                    string Address = Arr[i]["Address"].ToString();
                    string City = Arr[i]["City"].ToString();
                    string PinCode = Arr[i]["PinCode"].ToString();
                    dt.Rows.Add(MobileNo, Name, Email, Address, City, PinCode);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (statusCode == "201")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "http://kundan.webtechsolution.net/api/GetUserByMobileNo";
            string body = "{\"Mobile\":\"" + txtSearchMobile.Text.Trim() + "\"}";
            var client = new RestClient(url);
            client.Timeout = -1;
            string UserName = "Kundan";
            string Pass = "1234";
            client.Authenticator = new HttpBasicAuthenticator(UserName, Pass);
            var request = new RestRequest(Method.POST);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            //content = "{\"StatusCode\":200,\"StatusMsg\":\"SucessfullyFetchData\",\"Data\":{\"Mobile\":\"9798501225\",\"Name\":\"KundanSinghRana\",\"Email\":\"kundanmth@gmail.com\",\"Address\":\"Delhi,India\",\"City\":\"Noida,Up\",\"PinCode\":\"201301\"}}";
            JObject jObject = JObject.Parse(content);
            string statusCode = jObject["StatusCode"].ToString();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("MobileNo"), new DataColumn("Name"), new DataColumn("Email"), new DataColumn("Address"), new DataColumn("City"), new DataColumn("PinCode") });
            if (statusCode == "200")
            {
                string MobileNo = jObject["Data"]["Mobile"].ToString();
                string Name = jObject["Data"]["Name"].ToString();
                string Email = jObject["Data"]["Email"].ToString();
                string Address = jObject["Data"]["Address"].ToString();
                string City = jObject["Data"]["City"].ToString();
                string PinCode = jObject["Data"]["PinCode"].ToString();


                txtMobileNo.Text = MobileNo;
                TxtName.Text = Name;
                txtEmail.Text = Email;
                txtAddress.Text = Address;
                txtCity.Text = City;
                txtPinCode.Text = PinCode;

                dt.Rows.Add(MobileNo, Name, Email, Address, City, PinCode);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (statusCode == "201")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else if (statusCode == "401")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string url = "http://kundan.webtechsolution.net/api/UserRegisteration";
            string body = "{\"Name\":\"" + TxtName.Text.Trim() + "\",\"Mobile\":\"" + txtMobileNo.Text.Trim() + "\",\"Email\":\"" + txtEmail.Text.Trim() + "\",\"Address\":\"" + txtAddress.Text.Trim() + "\",\"PinCode\":\"" + txtPinCode.Text.Trim() + "\",\"City\":\"" + txtCity.Text.Trim() + "\"}";
            var client = new RestClient(url);
            client.Timeout = -1;
            string UserName = "Kundan";
            string Pass = "1234";
            client.Authenticator = new HttpBasicAuthenticator(UserName, Pass);
            var request = new RestRequest(Method.POST);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            //content = "{\"StatusCode\":200,\"StatusMsg\":\"SucessfullyFetchData\",\"Data\":{\"Mobile\":\"9798501225\",\"Name\":\"KundanSinghRana\",\"Email\":\"kundanmth@gmail.com\",\"Address\":\"Delhi,India\",\"City\":\"Noida,Up\",\"PinCode\":\"201301\"}}";
            JObject jObject = JObject.Parse(content);
            string statusCode = jObject["StatusCode"].ToString();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("MobileNo"), new DataColumn("Name"), new DataColumn("Email"), new DataColumn("Address"), new DataColumn("City"), new DataColumn("PinCode") });
            if (statusCode == "200")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                msgsuccess.InnerText = StatusMsg;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#ConformationModel').modal();", true);
                UserListBind();
            }
            else if (statusCode == "201")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else if (statusCode == "401")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMobile = (Label)GridView1.Rows[e.RowIndex].FindControl("lblMobileNo");
            string url = "http://kundan.webtechsolution.net/api/DeleteUserData";
            string body = "{\"Mobile\":\"" + lblMobile.Text.Trim() + "\"}";
            var client = new RestClient(url);
            client.Timeout = -1;
            string UserName = "Kundan";
            string Pass = "1234";
            client.Authenticator = new HttpBasicAuthenticator(UserName, Pass);
            var request = new RestRequest(Method.POST);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            JObject jObject = JObject.Parse(content);
            string statusCode = jObject["StatusCode"].ToString();
            DataTable dt = new DataTable();
            if (statusCode == "200")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                msgsuccess.InnerText = StatusMsg;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#ConformationModel').modal();", true);
            }
            else if (statusCode == "201")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else if (statusCode == "206")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            GridView1.EditIndex = -1;
            UserListBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            UserListBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            UserListBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox lblMobile = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMobile");
            TextBox lblName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox lblEmail = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox lblAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox lblCity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCity");
            TextBox lblPinCode = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPincode");
            string url = "http://kundan.webtechsolution.net/api/UpdateUserDatils";
            string body = "{\"Name\":\"" + lblName.Text.Trim() + "\",\"Mobile\":\"" + lblMobile.Text.Trim() + "\",\"Email\":\"" + lblEmail.Text.Trim() + "\",\"Address\":\"" + lblAddress.Text.Trim() + "\",\"PinCode\":\"" + lblPinCode.Text.Trim() + "\",\"City\":\"" + lblCity.Text.Trim() + "\"}";
            var client = new RestClient(url);
            client.Timeout = -1;
            string UserName = "Kundan";
            string Pass = "1234";
            client.Authenticator = new HttpBasicAuthenticator(UserName, Pass);
            var request = new RestRequest(Method.POST);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            JObject jObject = JObject.Parse(content);
            string statusCode = jObject["StatusCode"].ToString();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("MobileNo"), new DataColumn("Name"), new DataColumn("Email"), new DataColumn("Address"), new DataColumn("City"), new DataColumn("PinCode") });
            if (statusCode == "200")
            {
                GridView1.EditIndex = -1;
                UserListBind();
                string StatusMsg = jObject["StatusMsg"].ToString();
                msgsuccess.InnerText = StatusMsg;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#ConformationModel').modal();", true);
            }
            else if (statusCode == "201")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else if (statusCode == "401")
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
            else
            {
                string StatusMsg = jObject["StatusMsg"].ToString();
                string Data = jObject["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
        }
    }
}