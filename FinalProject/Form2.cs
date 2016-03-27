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
        }

        private void radNewPrereq_CheckedChanged(object sender, EventArgs e) {
            if (radNewPrereq.Checked) {
                newPrereq(true);
                previousPrereq(false);
                materialsPrereq(false);
            }
        }
        private void newPrereq(bool option) {
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
        }
    }
}
