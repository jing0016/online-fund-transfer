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
        if (Session["result"] == null)
        {
            Response.Redirect("FundTransferFrom.aspx");
        }

        if (Session["result"]!=null)
        {
            if((TransactionResult)Session["result"]== TransactionResult.SUCCESS)
            {
                Label6.Text = "Amout: $" + (String)Session["amount"] + " has been transferred.";
            }
            else
            {
                Label6.Text = "Transaction failed.";
            }

            Label1.Text += customers[(int)Session["selCustomerIndex"] - 1].ToString();

            if ((int)Session["accountTypeIndex"] == 0)
            {
                Label2.Text += customers[(int)Session["selCustomerIndex"] - 1].Checking.ToString();
            }
            else
            {
                Label2.Text += customers[(int)Session["selCustomerIndex"] - 1].Saving.ToString();
            }

            Label4.Text += (String)Session["selTransferee"];

            int customerId = 0;
            Int32.TryParse(((String)Session["selTransferee"]).Substring(0, 4), out customerId);

            if ((int)Session["accountTransfereeIndex"] == 0)
            {
                Label5.Text += Customer.GetCustomerById(customerId).Checking.ToString();
            }
            else
            {
                Label5.Text += Customer.GetCustomerById(customerId).Saving.ToString();
            }
        }

    }


    protected void btnResult_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("FundTransferFrom.aspx");
    }
}