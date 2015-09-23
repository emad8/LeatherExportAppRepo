using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Model;
using DataAccess.App_Code;
using System.IO;

namespace LeatherExportApp.forms
{
    public partial class formEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = sqlCategory;
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee _Employee = new Employee();
            _Employee.Name = Name.Text;
            _Employee.Contact_No = CN.Text;
            _Employee.NIC_No = NIC.Text;
            _Employee.Category = int.Parse(ddlCategory.SelectedValue);

            if (FileUpload.HasFile)
            {
                _Employee.Picture = GetImageBytes();
            }
            

            _Employee.IsDeleted = false;


            

            lblMessage.Text = Employee_DA.insertEmployee(_Employee);
            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearFields();
            }

        }

        protected void ImageUpload_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);

            HttpPostedFile _HttpPostedFile = FileUpload.PostedFile;

            byte[] bytes = ReadFile(_HttpPostedFile);

            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;

            //if (String.IsNullOrEmpty( (string)Session["FileUpload"]) && FileUpload.HasFile)
            //{
            //    Session["FileUpload"] = FileUpload;
            //}
            //// Next time submit and Session has values but FileUpload is Blank 
            //// Return the values from session to FileUpload 
            //else if (Session["FileUpload"] != null && (!FileUpload.HasFile))
            //{
            //    FileUpload = (FileUpload)Session["FileUpload"];
            //} 
        }

        private byte[] ReadFile(HttpPostedFile file)
        {
            byte[] data = new Byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);
            return data;
        }

        protected byte[] GetImageBytes()
        {
            Stream fs = FileUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            return bytes;
        }

        protected void ClearFields()
        {
            ddlCategory.SelectedIndex = 0;
            

            Name.Text = "";
            CN.Text = "";
            NIC.Text = "";
            

            
        }
    }
}