using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransferFrom : System.Web.UI.Page
{
    List<Customer> customers = Customer.GetAllCustomers();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                ListItem item = new ListItem(customers[i].ToString());
                selectTransferor.Items.Add(item);
            }


        }
        if (Session["selCustomerIndex"] != null && Session["amount"] != null && Session["accountTypeIndex"] != null)
        {
            if(!IsPostBack)
            {
                selectTransferor.SelectedIndex = (int)Session["selCustomerIndex"];
                txtBoxAmount.Text = (String)Session["amount"];
                btnFromAccount.SelectedIndex = (int)Session["accountTypeIndex"];
                btnFromAccount.Items[0].Text = customers[selectTransferor.SelectedIndex - 1].Checking.ToString();
                btnFromAccount.Items[1].Text = customers[selectTransferor.SelectedIndex - 1].Saving.ToString();
            }
            

        }


    }


    protected void selectTransferor_SelectedIndexChanged(object sender, EventArgs e)
    {

        int customerIndex = selectTransferor.SelectedIndex;

        if (selectTransferor.SelectedIndex == 0)
        {
            btnFromAccount.Items[0].Text = "Checking";
            btnFromAccount.Items[1].Text = "Saving";
            return;
        }
        btnFromAccount.Items[0].Text = customers[customerIndex - 1].Checking.ToString();
        btnFromAccount.Items[1].Text = customers[customerIndex - 1].Saving.ToString();


    }

    protected void btnTansferForm_Click(object sender, EventArgs e)
    {
        Session["selCustomerIndex"] = selectTransferor.SelectedIndex;
        Session["accountTypeIndex"] = btnFromAccount.SelectedIndex;
        Session["amount"] = txtBoxAmount.Text;
        Response.BufferOutput = true;
        Response.Redirect("FundTransferTo.aspx");
    }

    protected void btnFromAccount_SelectedIndexChanged(object sender, EventArgs e)
    {

        int customerIndex = selectTransferor.SelectedIndex;
        int accountIndex = btnFromAccount.SelectedIndex;
        if (accountIndex == 0)
        {
            if(customers[customerIndex - 1].Status== CustomerStatus.REGULAR)
            {
                amountRangeValidator.MaximumValue = CheckingAccount.MaxTransferAmount.ToString();
                amountRangeValidator.ErrorMessage = "<br /><br />Maximum amount for regular customer transfer from checking account is " + CheckingAccount.MaxTransferAmount.ToString();
            }
            else
            {
                amountRangeValidator.MaximumValue = customers[customerIndex - 1].Checking.Balance.ToString();
            }
            
        }
        else
        {
            amountRangeValidator.MaximumValue = customers[customerIndex - 1].Saving.Balance.ToString();
        }

       
    }
}