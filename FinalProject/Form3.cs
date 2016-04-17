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
        private bool edit = false;
        public frmAddReq() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
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

        private void btnAddRequirement_Click(object sender, EventArgs e) {
            lblstatus.Text = "";
            errProvider.Clear();
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
            int price;
            if (!int.TryParse(txtPrice.Text, out price)) {
                lblstatus.Text = "Invalid price.";
                return;
            }
            string[] req = new string[4];
            for (int i = 0; i < lstMaterials.Items.Count; i++) {
                req[i] = lstMaterials.Items[i].ToString();
            }
            if (edit) {
                this.requirementsTableAdapter.Update(req[0], req[1], req[2], req[3], price, location, txtName.Text);
            } else {
                this.requirementsTableAdapter.Insert(txtName.Text, req[0], req[1], req[2], req[3], price, location);
            }
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

        private void frmAddReq_Load(object sender, EventArgs e) {
            if (!edit) {
                cboRotation.Enabled = false;
            }
        }
        public void editReq(string name) {
            DataTable req = requirementsTableAdapter.Requirements(name);
            if (req.Rows.Count == 0) {
                return;
            }
            edit = true;
            btnAddRequirement.Text = "Edit Requirement";
            txtName.Text = req.Rows[0][0].ToString();
            txtName.Enabled = false;
            for (int i = 0; i < 4; i++) {
                lstMaterials.Items.Add(req.Rows[0][1 + i]);
            }
            txtPrice.Text = req.Rows[0][5].ToString();
            string loc = req.Rows[0][6].ToString();
            string[] location = loc.Split(' ');
            if (location[0].Equals("Vaulted")) {
                cboLocations.SelectedIndex = cboLocations.FindStringExact(location[0]);
                cboRotation.Enabled = false;
                cboType.Enabled = false;
                return;
            } else if (location.Length == 4) {

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
    }
}
