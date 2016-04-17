namespace FinalProject {
    partial class frmSearch {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cboSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnViewReq = new System.Windows.Forms.Button();
            this.requirementsDataSet = new FinalProject.RequirementsDataSet();
            this.requirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requirementsTableAdapter = new FinalProject.RequirementsDataSetTableAdapters.RequirementsTableAdapter();
            this.dgvRequirements = new System.Windows.Forms.DataGridView();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirement1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirement2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirement3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirement4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNamesDataSet = new FinalProject.ItemNamesDataSet();
            this.itemNamesTableAdapter = new FinalProject.ItemNamesDataSetTableAdapters.ItemNamesTableAdapter();
            this.itemNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.craftingTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNamesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNamesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 96);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(127, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 252);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 305);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit Item";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cboSearchBy
            // 
            this.cboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchBy.FormattingEnabled = true;
            this.cboSearchBy.Items.AddRange(new object[] {
            "Item",
            "Type"});
            this.cboSearchBy.Location = new System.Drawing.Point(12, 45);
            this.cboSearchBy.Name = "cboSearchBy";
            this.cboSearchBy.Size = new System.Drawing.Size(127, 24);
            this.cboSearchBy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search by:.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search for:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 401);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.craftingTimeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn1});
            this.dgvItems.DataSource = this.itemNamesBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(162, 12);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(585, 372);
            this.dgvItems.TabIndex = 8;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(327, 404);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(92, 39);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // btnViewReq
            // 
            this.btnViewReq.Location = new System.Drawing.Point(12, 179);
            this.btnViewReq.Name = "btnViewReq";
            this.btnViewReq.Size = new System.Drawing.Size(127, 47);
            this.btnViewReq.TabIndex = 10;
            this.btnViewReq.Text = "View Requirements";
            this.btnViewReq.UseVisualStyleBackColor = true;
            this.btnViewReq.Click += new System.EventHandler(this.btnViewReq_Click);
            // 
            // requirementsDataSet
            // 
            this.requirementsDataSet.DataSetName = "RequirementsDataSet";
            this.requirementsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requirementsBindingSource
            // 
            this.requirementsBindingSource.DataMember = "Requirements";
            this.requirementsBindingSource.DataSource = this.requirementsDataSet;
            // 
            // requirementsTableAdapter
            // 
            this.requirementsTableAdapter.ClearBeforeFill = true;
            // 
            // dgvRequirements
            // 
            this.dgvRequirements.AllowUserToAddRows = false;
            this.dgvRequirements.AllowUserToDeleteRows = false;
            this.dgvRequirements.AutoGenerateColumns = false;
            this.dgvRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequirements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNameDataGridViewTextBoxColumn,
            this.requirement1DataGridViewTextBoxColumn,
            this.requirement2DataGridViewTextBoxColumn,
            this.requirement3DataGridViewTextBoxColumn,
            this.requirement4DataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn});
            this.dgvRequirements.DataSource = this.requirementsBindingSource;
            this.dgvRequirements.Location = new System.Drawing.Point(162, 12);
            this.dgvRequirements.Name = "dgvRequirements";
            this.dgvRequirements.ReadOnly = true;
            this.dgvRequirements.RowTemplate.Height = 24;
            this.dgvRequirements.Size = new System.Drawing.Size(585, 372);
            this.dgvRequirements.TabIndex = 11;
            this.dgvRequirements.Visible = false;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requirement1DataGridViewTextBoxColumn
            // 
            this.requirement1DataGridViewTextBoxColumn.DataPropertyName = "Requirement 1";
            this.requirement1DataGridViewTextBoxColumn.HeaderText = "Requirement 1";
            this.requirement1DataGridViewTextBoxColumn.Name = "requirement1DataGridViewTextBoxColumn";
            this.requirement1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requirement2DataGridViewTextBoxColumn
            // 
            this.requirement2DataGridViewTextBoxColumn.DataPropertyName = "Requirement 2";
            this.requirement2DataGridViewTextBoxColumn.HeaderText = "Requirement 2";
            this.requirement2DataGridViewTextBoxColumn.Name = "requirement2DataGridViewTextBoxColumn";
            this.requirement2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requirement3DataGridViewTextBoxColumn
            // 
            this.requirement3DataGridViewTextBoxColumn.DataPropertyName = "Requirement 3";
            this.requirement3DataGridViewTextBoxColumn.HeaderText = "Requirement 3";
            this.requirement3DataGridViewTextBoxColumn.Name = "requirement3DataGridViewTextBoxColumn";
            this.requirement3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requirement4DataGridViewTextBoxColumn
            // 
            this.requirement4DataGridViewTextBoxColumn.DataPropertyName = "Requirement 4";
            this.requirement4DataGridViewTextBoxColumn.HeaderText = "Requirement 4";
            this.requirement4DataGridViewTextBoxColumn.Name = "requirement4DataGridViewTextBoxColumn";
            this.requirement4DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.FillWeight = 50F;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 50;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemNamesDataSet
            // 
            this.itemNamesDataSet.DataSetName = "ItemNamesDataSet";
            this.itemNamesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemNamesTableAdapter
            // 
            this.itemNamesTableAdapter.ClearBeforeFill = true;
            // 
            // itemNamesBindingSource
            // 
            this.itemNamesBindingSource.DataMember = "ItemNames";
            this.itemNamesBindingSource.DataSource = this.itemNamesDataSet;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // craftingTimeDataGridViewTextBoxColumn
            // 
            this.craftingTimeDataGridViewTextBoxColumn.DataPropertyName = "Crafting Time";
            this.craftingTimeDataGridViewTextBoxColumn.HeaderText = "Crafting Time";
            this.craftingTimeDataGridViewTextBoxColumn.Name = "craftingTimeDataGridViewTextBoxColumn";
            this.craftingTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            this.priceDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 455);
            this.Controls.Add(this.dgvRequirements);
            this.Controls.Add(this.btnViewReq);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSearchBy);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmSearch";
            this.Text = "Warframe Item Finder";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNamesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemNamesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cboSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnReset;
        private ItemNamesDataSet itemNamesDataSet;
        private ItemNamesDataSetTableAdapters.ItemNamesTableAdapter itemNamesTableAdapter;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Button btnViewReq;
        private RequirementsDataSet requirementsDataSet;
        private System.Windows.Forms.BindingSource requirementsBindingSource;
        private RequirementsDataSetTableAdapters.RequirementsTableAdapter requirementsTableAdapter;
        private System.Windows.Forms.DataGridView dgvRequirements;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirement1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirement2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirement3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirement4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn craftingTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource itemNamesBindingSource;
    }
}

