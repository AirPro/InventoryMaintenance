using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * A constructor is a special method that is used to initialize objects. 
 * The advantage of a constructor, is that it is called when an object of a class is created.
 */

namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        public frmNewItem()
        {
            InitializeComponent();
        }

        //Bob Freid Creates an instaance of the class invItem
        // Add a statement here that declares the inventory item.
        private InvItem invItem = null;

        // Add a method here that gets and returns a new item.
        public InvItem GetNewItem() // change this to GetItem to see if this changes anything from GetNewItem
        {
            this.ShowDialog();
            return invItem;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                // Bob Freid Add code here that creates a new item
                // and closes the form.
                invItem = new()
                {
                    ItemNo = Convert.ToInt32(txtItemNo.Text),
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text)
                };
                this.Close();
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNo) &&
                   Validator.IsInt32(txtItemNo) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewItem_Load(object sender, EventArgs e)
        {

        }
    }
}
