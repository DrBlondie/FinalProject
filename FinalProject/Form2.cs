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
        private bool edit = false;
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
            string location = "";
            if (cboLocations.SelectedItem == null) {
                errProvider.SetError(cboLocations, "Select a location.");
                return;
            }
            location += cboLocations.SelectedItem;
            if (cboType.Enabled) {
                if (cboType.SelectedItem == null) {
                    errProvider.SetError(cboType, "Select a Mission Type.");
                    return;
                }
                location += " " + cboType.SelectedItem;
            }
            if (cboRotation.Enabled) {
                if (cboRotation.SelectedItem == null) {
                    errProvider.SetError(cboRotation, "Select a Rotation.");
                    return;
                }
                location += " " + cboRotation.SelectedItem;
            }
            if (lstRequirements.Items.Count > 4) {
                errProvider.SetError(lstRequirements, "Too many requirements.");
                return;
            }
            if (txtItemName.Text.Equals("")) {
                errProvider.SetError(txtItemName, "Please enter the name.");
                return;
            }
            if(cboItemType.SelectedItem == null) {
                errProvider.SetError(cboItemType, "Please select a type.");
                return;
            }

            string[] req = new string[4];
            for (int i = 0; i < lstRequirements.Items.Count; i++) {
                req[i] = lstRequirements.Items[i].ToString();
            }
            if (edit) {
                this.requirementsTableAdapter.Update(req[0], req[1], req[2], req[3], price, location, txtItemName.Text);
                this.itemNamesTableAdapter.Update(time, price, txtItemName.Text);
            } else {
                this.requirementsTableAdapter.Insert(txtItemName.Text, req[0], req[1], req[2], req[3], price, location);
                this.itemNamesTableAdapter.Insert(txtItemName.Text, cboItemType.SelectedItem.ToString(), price, time);
            }
            this.Close();
        }

        private void radNewPrereq_CheckedChanged(object sender, EventArgs e) {
            if (radNewPrereq.Checked) {
                previousPrereq(false);
                materialsPrereq(false);
                newPrereq(true);
            }
        }
        private void newPrereq(bool option) {
            btnAddReq.Enabled = !option;
            btnAddNewReq.Enabled = option;            
        }
        private void previousPrereq(bool option) {
            lblExisting.Enabled = option;
            lstExistingItems.Enabled = option;
            txtAmount.Enabled = option;
            lblAmount.Enabled = option;
            btnEditReq.Enabled = option;
        }
        private void materialsPrereq(bool option) {
            lblMaterials.Enabled = option;
            lblAmount.Enabled = option;
            cboMaterials.Enabled = option;
            txtAmount.Enabled = option;
        }

        private void radExistingPrereq_CheckedChanged(object sender, EventArgs e) {
            if (radExistingPrereq.Checked) {
                newPrereq(false);
                materialsPrereq(false);
                previousPrereq(true);
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
            if (!edit) {

                cboRotation.Enabled = false;
            }
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
                if(txtAmount.Text.Equals("") || txtAmount.Text.Equals("0")) {
                    lstRequirements.Items.Add(lstExistingItems.SelectedItem);
                } else {
                    int amount;
                    if (!int.TryParse(txtAmount.Text, out amount)) {
                        errProvider.SetError(txtAmount, "Invalid amount.");
                        return;
                    }
                    lstRequirements.Items.Add(amount + " " + lstExistingItems.SelectedItem);
                }
                return;
            }
            if (radMaterial.Checked) {
                if(cboMaterials.SelectedItem == null) {
                    errProvider.SetError(cboMaterials, "Select an item.");
                    return;
                }
                int amount;
                if(!int.TryParse(txtAmount.Text, out amount)) {
                    errProvider.SetError(txtAmount, "Invalid amount.");
                    return;
                }
                lstRequirements.Items.Add(amount + " " + cboMaterials.SelectedItem.ToString());
            }
        }

        private void btnDeleteRequirement_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if (lstRequirements.SelectedItem == null) {
                errProvider.SetError(lstRequirements, "Please select a requirement to delete.");
                return;
            }
            lstRequirements.Items.RemoveAt(lstRequirements.SelectedIndex);
        }
        public void SetEditItem(string name) {
            edit = true;
            DataTable table = itemNamesTableAdapter.GetByName(name);
            txtItemName.Text = table.Rows[0][0].ToString();
            txtItemName.Enabled = false;
            cboItemType.SelectedIndex = cboItemType.FindStringExact(table.Rows[0][1].ToString());
            cboItemType.Enabled = false;
            txtTime.Text = table.Rows[0][2].ToString();
            txtPrice.Text = table.Rows[0][3].ToString();
            btnAdd.Text = "Edit Requirement";
            DataTable req = requirementsTableAdapter.Requirements(name);
            if(req.Rows.Count == 0) {
                return;
            }
            for(int i = 0; i < 4; i++) {
                lstRequirements.Items.Add(req.Rows[0][1 + i]);
            }
            string loc = req.Rows[0][6].ToString();
            
            string[] location = loc.Split(' ');
            
            if (location[0].Equals("Vaulted")) {
                cboLocations.SelectedIndex = cboLocations.FindStringExact(location[0]);
                cboRotation.Enabled = false;
                cboType.Enabled = false;
                return;
            } else if(location.Length == 4) {
                
                cboLocations.SelectedIndex = cboLocations.FindStringExact(location[0] + " " + location[1]);
                cboType.SelectedIndex = cboType.FindStringExact(location[2]);
                cboRotation.SelectedIndex = cboRotation.FindStringExact(location[3]);
                cboRotation.Enabled = true;
            } else {

                cboLocations.SelectedIndex = cboLocations.FindString(location[0] + " " + location[1]);
                cboType.SelectedIndex = cboType.FindStringExact(location[2]);
                cboRotation.Enabled = false;
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e) {

            string selectedItem = (string)cboType.SelectedItem;
            if (selectedItem != null && (selectedItem.Equals("Defense") || selectedItem.Equals("Interception") || selectedItem.Equals("Survival"))) {
                cboRotation.Enabled = true;
            } else {
                cboRotation.Enabled = false;
            }
        }
        private void cboLocations_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedItem = (string)cboLocations.SelectedItem;
            if (selectedItem != null && selectedItem.Equals("Vaulted")) {
                cboRotation.Enabled = false;
                cboType.Enabled = false;
            } else {
                cboRotation.Enabled = true;
                cboType.Enabled = true;
            }
        }

        private void btnEditReq_Click(object sender, EventArgs e) {
            if(lstExistingItems.SelectedItem == null) {
                errProvider.SetError(lstExistingItems, "Select a requirement to edit.");
                return;
            }
            string name = lstExistingItems.SelectedItem.ToString();
            if(this.itemNamesTableAdapter.Exists(name) > 0) {
                errProvider.SetError(lstExistingItems, "Cannot edit item from this form. Use main form.");
                return;
            }
            frmAddReq edit = new frmAddReq();
            
            edit.editReq(lstExistingItems.SelectedItem.ToString());
            edit.ShowDialog();
        }
    }
}
