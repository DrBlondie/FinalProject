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
    public partial class frmSearch : Form {
        public frmSearch() {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if (cboSearchBy.Text.Equals("")) {
                errProvider.SetError(cboSearchBy, "Please select something to search by.");
                return;
            }
            if (txtSearch.Text.Equals("")) {
                errProvider.SetError(txtSearch, "Please enter something to search for.");
                return;
            }
            if (cboSearchBy.Text.Equals("Item")) {
                this.itemNamesTableAdapter.SearchName(this.itemNamesDataSet.ItemNames, txtSearch.Text);
            } else {
                this.itemNamesTableAdapter.SearchType(this.itemNamesDataSet.ItemNames, txtSearch.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            errProvider.Clear();
            frmAddEdit addForm = new frmAddEdit();
            addForm.ShowDialog();
            dgvItems.DataSource = this.itemNamesTableAdapter.ResetTables();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmSearch_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'requirementsDataSet.Requirements' table. You can move, or remove it, as needed.
            this.requirementsTableAdapter.Fill(this.requirementsDataSet.Requirements);
            // TODO: This line of code loads data into the 'itemNamesDataSet.ItemNames' table. You can move, or remove it, as needed.
            this.itemNamesTableAdapter.Fill(this.itemNamesDataSet.ItemNames);

        }

        private void btnReset_Click(object sender, EventArgs e) {
            errProvider.Clear();
            dgvItems.DataSource = this.itemNamesTableAdapter.ResetTables();
        }

        private void btnViewReq_Click(object sender, EventArgs e) {
            errProvider.Clear();
            DataGridViewSelectedRowCollection rows = dgvItems.SelectedRows;
            if(rows.Count == 0) {
                errProvider.SetError(dgvItems, "Please select an entire row.");
                return;
            }
            if (rows.Count > 1) {
                errProvider.SetError(dgvItems, "Please select only one row.");
                return;
            }
            DataRow myRow = (rows[0].DataBoundItem as DataRowView).Row;
            dgvItems.DataSource = this.requirementsTableAdapter.GetData();
            dgvItems.Update();
        }
    }


}
