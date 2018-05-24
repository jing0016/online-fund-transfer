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
        if (Session["selTransferee"] == null)
        {
            Response.Redirect("FundTransferFrom.aspx");
        }

        if (Session["selTransferee"]!=null)
        {
            Label1.Text += customers[(int)Session["selCustomerIndex"]-1].ToString();

            if ((int)Session["accountTypeIndex"] == 0)
            {
                Label2.Text += customers[(int)Session["selCustomerIndex"]-1].Checking.ToString();
            }
            else
            {
                Label2.Text += customers[(int)Session["selCustomerIndex"]-1].Saving.ToString();
            }
            Label3.Text = Label3.Text + "$" + (String)Session["amount"];

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


    protected void btnComfirmToBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferTo.aspx");
    }

    protected void btnComfirmToNext_Click(object sender, EventArgs e)
    {
        int customerId = 0;
        Int32.TryParse(((String)Session["selTransferee"]).Substring(0, 4), out customerId);


        TransferTransaction transaction = new TransferTransaction(Convert.ToDouble(Session["amount"]));

        if ((int)Session["accountTypeIndex"] == 0)
        {
            transaction.FromAccount = customers[(int)Session["selCustomerIndex"] - 1].Checking;
        }
        else
        {
            transaction.FromAccount = customers[(int)Session["selCustomerIndex"] - 1].Saving;
        }

        if ((int)Session["accountTransfereeIndex"] == 0)
        {
            transaction.ToAccount = Customer.GetCustomerById(customerId).Checking;
        }
        else
        {
            transaction.ToAccount = Customer.GetCustomerById(customerId).Saving;
        }

        TransactionResult result = transaction.Execute();
        Session["result"] = result;

        Response.Redirect("FundTransferResult.aspx");
    }
}