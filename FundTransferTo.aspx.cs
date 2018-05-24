using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    List<Customer> customers = Customer.GetAllCustomers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["selCustomerIndex"] == null)
        {
            Response.Redirect("FundTransferFrom.aspx");
        }

        if(!IsPostBack)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (i != (int)Session["selCustomerIndex"]-1)
                {
                    ListItem item = new ListItem(customers[i].ToString());
                    selectTransferee.Items.Add(item);
                }

            }
        }

        if (Session["selTransferee"] != null && Session["accountTransfereeIndex"] != null)
        {
            if (!IsPostBack)
            {
                selectTransferee.SelectedValue = (String)Session["selTransferee"];

                btnToAccount.SelectedIndex = (int)Session["accountTransfereeIndex"];

                int customerId = 0;
                Int32.TryParse(((String)Session["selTransferee"]).Substring(0, 4), out customerId);
                btnToAccount.Items[0].Text = Customer.GetCustomerById(customerId).Checking.ToString();
                btnToAccount.Items[1].Text = Customer.GetCustomerById(customerId).Saving.ToString();
            }


        }


    }


    protected void selectTransferee_SelectedIndexChanged(object sender, EventArgs e)
    {

        int customerIndex = selectTransferee.SelectedIndex;
        
        if (customerIndex == 0)
        {
            btnToAccount.Items[0].Text = "Checking";
            btnToAccount.Items[1].Text = "Saving";
            return;
        }

        int customerId = 0;
        Int32.TryParse(selectTransferee.Items[selectTransferee.SelectedIndex].Value.Substring(0,4),out customerId);
        btnToAccount.Items[0].Text = Customer.GetCustomerById(customerId).Checking.ToString();
        btnToAccount.Items[1].Text = Customer.GetCustomerById(customerId).Saving.ToString();
    }

    protected void btnTransferToBack_Click(object sender, EventArgs e)
    {
        Response.BufferOutput = true;
        Response.Redirect("FundTransferFrom.aspx");
    }


    protected void btnTansferToNext_Click(object sender, EventArgs e)
    {
        Response.BufferOutput = true;
        Session["selTransferee"] = selectTransferee.Items[selectTransferee.SelectedIndex].Value;
        Session["accountTransfereeIndex"] = btnToAccount.SelectedIndex;
        Response.Redirect("FundTransferConfirmation.aspx");
    }
}