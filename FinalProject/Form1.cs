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

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmAddEdit addForm = new frmAddEdit();
            addForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
