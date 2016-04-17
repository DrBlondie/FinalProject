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
            this.itemNamesTableAdapter.ResetTable(this.itemNamesDataSet.ItemNames);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmSearch_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'requirementsDataSet.Requirements' table. You can move, or remove it, as needed.
            this.requirementsTableAdapter.Fill(this.requirementsDataSet.Requirements);
            // TODO: This line of code loads data into the 'itemNamesDataSet.ItemNames' table. You can move, or remove it, as needed.
            this.itemNamesTableAdapter.Fill(this.itemNamesDataSet.ItemNames);
            dgvItems.MultiSelect = false;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnReset_Click(object sender, EventArgs e) {
            errProvider.Clear();
            this.itemNamesTableAdapter.ResetTable(this.itemNamesDataSet.ItemNames);
            dgvItems.Visible = true;
            dgvRequirements.Visible = false;
        }

        private void btnViewReq_Click(object sender, EventArgs e) {
            

            errProvider.Clear();
            if(dgvItems.SelectedRows.Count == 0) {
                errProvider.SetError(dgvItems, "Please select a row.");
                return;
            }
            string item = dgvItems.SelectedRows[0].Cells[0].Value.ToString();
            DataTable table = new DataTable();
            for(int i = 0; i < dgvRequirements.Columns.Count; i++) {
                table.Columns.Add(dgvRequirements.Columns[i].Name.ToString());
            }
            addRequirement(item, table);
            dgvRequirements.DataSource = table;
            dgvRequirements.Visible = true;
            dgvItems.Visible = false;
        }
        private void addRequirement(string name, DataTable table) {
            DataTable requirements = requirementsTableAdapter.Requirements(name);
            if (requirements.Rows.Count == 0) {
                return;
            }
            var row = table.NewRow();
            row.ItemArray = requirements.Rows[0].ItemArray;
            table.ImportRow(row);
            for (int i = 0; i < 4; i++) {
                if (requirements.Rows[0][i + 1] == null) {
                    continue;
                }
                string temp = requirements.Rows[0][i + 1].ToString();
                if(temp.Equals("")) {
                    continue;
                }
                if (temp != null && (temp[0] >= 48 && temp[0] <= 57)) {
                    temp = temp.Substring(2);
                }
                addRequirement(temp, table);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if (dgvItems.SelectedRows.Count == 0) {
                errProvider.SetError(dgvItems, "Please select a row.");
                return;
            }
            string item = dgvItems.SelectedRows[0].Cells[0].Value.ToString();
            frmAddEdit edit = new frmAddEdit();
            edit.SetEditItem(item);
            edit.ShowDialog();
            this.itemNamesTableAdapter.ResetTable(this.itemNamesDataSet.ItemNames);
        }
    }
}
