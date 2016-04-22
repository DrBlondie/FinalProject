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
        private List<Item> itemList;
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
            itemList = new List<Item>();
            DataTable itemNames = itemNamesTableAdapter.GetData();
            foreach(DataRow el in itemNames.Rows) {
                DataTable requirement = requirementsTableAdapter.Requirements(el[0].ToString());
                if(requirement.Rows.Count == 0) {
                    continue;
                }
                DataRow reqRows = requirement.Rows[0];
                string[] reqs = new string[4];
                for(int i = 0; i < 4; i++) {
                    reqs[i] = reqRows[1 + i].ToString();
                }
                itemList.Add(new Item(el[0].ToString(),reqs,(int)el[3], (int)el[2], reqRows[6].ToString(),el[1].ToString()));
            }

        }

        private void btnReset_Click(object sender, EventArgs e) {
            errProvider.Clear();
            this.itemNamesTableAdapter.ResetTable(this.itemNamesDataSet.ItemNames);
            dgvItems.Visible = true;
            dgvRequirements.Visible = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSearch.Enabled = true;
        }

        private void btnViewReq_Click(object sender, EventArgs e) {
            errProvider.Clear();
            if(dgvItems.SelectedRows.Count == 0) {
                errProvider.SetError(dgvItems, "Please select a row.");
                return;
            }
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = false;
            string item = dgvItems.SelectedRows[0].Cells[0].Value.ToString();
            DataTable table = new DataTable();
            for(int i = 0; i < dgvRequirements.Columns.Count; i++) {
                table.Columns.Add(dgvRequirements.Columns[i].HeaderText);
            }
            addRequirement(item, table);
            dgvRequirements.Columns.Clear();
            dgvRequirements.AutoGenerateColumns = true;
            dgvRequirements.DataSource = table;
            dgvRequirements.Visible = true;
            dgvItems.Visible = false;
        }
        private void addRequirement(string name, DataTable table) {
            Item currentItem = findItemByName(name);
            if(currentItem == null) {
                addRequirementByRequirement(name, table);
            } else {
                addRequirementByItem(currentItem, table);
            }
        }
        private void addRequirementByRequirement(string name, DataTable table) {
            DataTable requirements = this.requirementsTableAdapter.Requirements(name);
            if(requirements.Rows.Count == 0) {
                return;
            }
            var row = table.NewRow();
            row.ItemArray = requirements.Rows[0].ItemArray;
            table.Rows.Add(row);
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
        public void addRequirementByItem(Item currentItem, DataTable table) {
            object[] items = new object[7];
            items[0] = currentItem.Name;
            for (int i = 0; i < 4; i++) {
                items[i + 1] = currentItem.Requirements[i];
            }
            items[5] = currentItem.Price;
            items[6] = currentItem.Location;
            var row = table.NewRow();
            row.ItemArray = items;
            table.Rows.Add(row);
            for (int i = 0; i < 4; i++) {
                if (items[i + 1] == null) {
                    continue;
                }
                string temp = items[i + 1].ToString();
                if (temp.Equals("")) {
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
        private Item findItemByName(string name) {
            foreach(Item el in itemList) {
                if (el.Name.Equals(name)) {
                    return el;
                }
            }
            return null;
        }
    }
}
