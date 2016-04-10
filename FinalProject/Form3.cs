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
    public partial class frmAddReq : Form {
        public frmAddReq() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAddLoc_Click(object sender, EventArgs e) {
            errProvider.Clear();
            string location = "";
            if (cboLocations.SelectedItem == null) {
                errProvider.SetError(cboLocations, "Select a location.");
                return;
            }
            location += cboLocations.SelectedItem;
            if (cboType.SelectedItem == null) {
                errProvider.SetError(cboType, "Select a Mission Type.");
                return;
            }
            location += " " + cboType.SelectedItem;
            if (cboRotation.Enabled) {
                if (cboRotation.SelectedItem == null) {
                    errProvider.SetError(cboRotation, "Select a Rotation.");
                    return;
                }
                location += " " + cboRotation.SelectedItem;
            }
            lstLocations.Items.Add(location);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e) {

            string selectedItem = (string)cboType.SelectedItem;
            if (selectedItem != null && (selectedItem.Equals("Defense") || selectedItem.Equals("Interception") || selectedItem.Equals("Survival"))) {
                cboRotation.Enabled = true;
            } else {
                cboRotation.Enabled = false;
            }
        }

        private void btnAddRequirement_Click(object sender, EventArgs e) {
            lblstatus.Text = "";
            errProvider.Clear();
            if (lstLocations.Items.Count == 0) {
                errProvider.SetError(lstLocations, "Not enough locations.");
                return;
            }
            if (lstLocations.Items.Count > 4) {
                errProvider.SetError(lstMaterials, "Too many locations. (Max 4)");
                return;
            }
            if (lstMaterials.Items.Count > 4) {
                errProvider.SetError(lstMaterials, "Too many items. (Max 4)");
            }
            int price;
            if (!int.TryParse(txtPrice.Text, out price)) {
                lblstatus.Text = "Invalid price.";
                return;
            }
            string[] req = new string[4];
            for (int i = 0; i < lstMaterials.Items.Count; i++) {
                req[i] = lstMaterials.Items[i].ToString();
            }
            this.requirementsTableAdapter.Insert(txtName.Text, req[0], req[1], req[2], req[3], price);
            this.Close();
        }

        private void btnAddMaterials_Click(object sender, EventArgs e) {
            int amount;
            errProvider.Clear();
            if (cboMaterials.SelectedItem == null) {
                errProvider.SetError(cboMaterials, "Select a material.");
                return;
            }
            if (!int.TryParse(txtMaterialAmt.Text, out amount)) {
                errProvider.SetError(txtMaterialAmt, "Invalid amount.");
                return;
            }

            lstMaterials.Items.Add(amount + " " + cboMaterials.SelectedItem.ToString());
        }

        private void btnRemoveLoc_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if (lstLocations.SelectedItem == null) {
                errProvider.SetError(lstLocations, "Select a location to remove.");
                return;
            }
            lstLocations.Items.Remove(lstLocations.SelectedItem);
        }

        private void frmAddReq_Load(object sender, EventArgs e) {
            cboRotation.Enabled = false;
        }
    }
}
