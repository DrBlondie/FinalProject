using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject {
    public partial class frmAddEdit : Form {
        public frmAddEdit() {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            errProvider.Clear();
            int time;
            int price;
            if(!int.TryParse(txtTime.Text, out time)) {
                errProvider.SetError(txtTime, "Invalid Time.");
                return;
            }
            if(!int.TryParse(txtPrice.Text, out price)) {
                errProvider.SetError(txtPrice, "Invalid price");
                return;
            }
            if(lstRequirements.Items.Count < 3) {
                errProvider.SetError(lstRequirements, "Not enough requirements.");
                return;
            }
            if (txtItemName.Text.Equals("")) {
                errProvider.SetError(txtItemName, "Please enter the name.");
                return;
            }
            if(cboType.SelectedItem == null) {
                errProvider.SetError(cboType, "Please select a type.");
                return;
            }

            string[] req = new string[4];
            for (int i = 0; i < lstRequirements.Items.Count; i++) {
                req[i] = lstRequirements.Items[i].ToString();
            }
            this.requirementsTableAdapter.Insert(txtItemName.Text, req[0], req[1], req[2], req[3], price);
            this.itemNamesTableAdapter.Insert(txtItemName.Text, cboType.SelectedItem.ToString(), price, time);
            this.Close();
        }

        private void radNewPrereq_CheckedChanged(object sender, EventArgs e) {
            if (radNewPrereq.Checked) {
                newPrereq(true);
                previousPrereq(false);
                materialsPrereq(false);
            }
        }
        private void newPrereq(bool option) {
            btnAddReq.Enabled = !option;
            btnAddNewReq.Enabled = option;            
        }
        private void previousPrereq(bool option) {
            lblExisting.Enabled = option;
            lstExistingItems.Enabled = option;
        }
        private void materialsPrereq(bool option) {
            lblMaterials.Enabled = option;
            lblMatAmount.Enabled = option;
            cboMaterials.Enabled = option;
            txtMaterialAmount.Enabled = option;
        }

        private void radExistingPrereq_CheckedChanged(object sender, EventArgs e) {
            if (radExistingPrereq.Checked) {
                newPrereq(false);
                previousPrereq(true);
                materialsPrereq(false);
            }
        }

        private void radMaterial_CheckedChanged(object sender, EventArgs e) {
            if (radMaterial.Checked) {
                newPrereq(false);
                previousPrereq(false);
                materialsPrereq(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAddNewReq_Click(object sender, EventArgs e) {
            frmAddReq addReq = new frmAddReq();
            addReq.ShowDialog();
            updateItems();
        }

        private void frmAddEdit_Load(object sender, EventArgs e) {
            radNewPrereq.Checked = true;
            updateItems();
        }

        private void updateItems() {
            lstExistingItems.Items.Clear();
            RequirementsDataSet.RequirementsDataTable table = this.requirementsTableAdapter.GetData();
            foreach (RequirementsDataSet.RequirementsRow row in table) {
                lstExistingItems.Items.Add(row.Item_Name);
            }
        }

        private void btnAddReq_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if (radExistingPrereq.Checked) {
                if(lstExistingItems.SelectedItem == null) {
                    errProvider.SetError(lstExistingItems, "Select an item.");
                    return;
                }
                lstRequirements.Items.Add(lstExistingItems.SelectedItem);
                return;
            }
            if (radMaterial.Checked) {
                if(cboMaterials.SelectedItem == null) {
                    errProvider.SetError(cboMaterials, "Select an item.");
                    return;
                }
                int amount;
                if(!int.TryParse(txtMaterialAmount.Text, out amount)) {
                    errProvider.SetError(txtMaterialAmount, "Invalid amount.");
                    return;
                }
                lstRequirements.Items.Add(amount + " " + cboMaterials.SelectedItem.ToString());
            }
        }
    }
}
