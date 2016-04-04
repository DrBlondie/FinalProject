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
            addReq.Show();
        }

        private void frmAddEdit_Load(object sender, EventArgs e) {
            radNewPrereq.Checked = true;
           
            ItemNamesDataSet.ItemNamesDataTable table = this.itemNamesTableAdapter.GetData();
            foreach (ItemNamesDataSet.ItemNamesRow row in table) {
                if (!row.Type.Equals("Warframe")) {
                    lstExistingItems.Items.Add(row.Name);
                }
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

                MaterialRequirement item = new MaterialRequirement();
                item.name = cboMaterials.SelectedItem.ToString();
                item.amount = amount;
                lstRequirements.Items.Add(amount);
            }
        }
    }
    struct MaterialRequirement {
        public string name;
        public int amount;

        public override string ToString() {
            return amount + " " + name;
        }
    }
}
