using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestYourApiDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TokenKey"] = null;
            Session["MackAddress"] = null;
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            Random rd = new Random();
            string TokenKey = "Kundan" + rd.Next(111111, 999999);
            string MacAddress = GetMacAddress();
            string url = "http://kundan.webtechsolution.net/api/LoginUser";
            string body = "{\"UserName\":\"" + txtUserName.Text.Trim() + "\",\"Password\":\"" + txtPassword.Text.Trim() + "\",\"TokenKey\":\"" + TokenKey + "\",\"DeviceInfo\":\"" + MacAddress + "\"}";
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
                Session["TokenKey"] = TokenKey;
                Session["MackAddress"] = MacAddress;
                Response.Redirect("Default.aspx");
            }
            else
            {
                string StatusMsg = jobj["StatusMsg"].ToString();
                string Data = jobj["Data"].ToString();
                msgerror.InnerText = StatusMsg;
                msgerror1.InnerText = Data;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#AlertModel').modal();", true);
            }
        }

        static string GetMacAddress()
        {
            string macAddress = string.Empty;
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = networkInterface.GetPhysicalAddress().ToString();
                    break; // Use the first operational network interface found
                }
            }

            return macAddress;
        }
    }
}