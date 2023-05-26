using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // Add a statement here that declares the list of items.
        // Bob Freid Creates an empty list
        private List<InvItem> invItems = null;

        //Bob Freid Retrieves a data list from the data source
        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // Add a statement here that gets the list of items.
            
            invItems = InvItemDB.GetItems();
            FillItemListBox();
        }

        // Bob Freid Loads the list into the form
        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // Add code here that loads the list box with the items in the list.
            
            foreach (InvItem i in invItems)
            {
                lstItems.Items.Add(i.GetDisplayText("\t"));
            }
        }

        // Bob Freid Creates a new datya element to bwe added to the list
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add code here that creates an instance of the New Item form
            
            frmNewItem newNewItem = new();
            InvItem invItem = newNewItem.GetNewItem();
            // and then gets a new item from that form.
            if (invItem != null)
            {
                invItems.Add(invItem);
                InvItemDB.SaveItems(invItems);
                FillItemListBox();
            }
        }

        // Bob Freid Deletes a data record from the form
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                // Add code here that displays a dialog box to confirm
                // the deletion and then removes the item from the list,
                // saves the list of products, and refreshes the list box
                // if the deletion is confirmed.

                InvItem invItem = invItems[i];
                string message = "Are you sure you want to delete " + invItem.Description + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo);

                if (button == DialogResult.Yes)
                {
                    invItems.Remove(invItem);
                    InvItemDB.SaveItems(invItems);
                    FillItemListBox();
                }
            }
        }

        // Bob Freid Closes the Form and the Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
