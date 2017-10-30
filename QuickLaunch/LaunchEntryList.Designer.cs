namespace QuickLaunch {
    partial class LaunchEntryList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchEntryList));
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewEntries = new System.Windows.Forms.TreeView();
            this.tableLayoutCategory = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonAddSubCategory = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.tableLayoutEntries = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddEntry = new System.Windows.Forms.Button();
            this.buttonDeleteEntry = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutCategory.SuspendLayout();
            this.tableLayoutEntries.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.treeViewEntries, 0, 1);
            this.tableLayoutMain.Controls.Add(this.tableLayoutCategory, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutEntries, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutMain.Size = new System.Drawing.Size(588, 410);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // treeViewEntries
            // 
            this.treeViewEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEntries.Location = new System.Drawing.Point(3, 33);
            this.treeViewEntries.Name = "treeViewEntries";
            this.treeViewEntries.Size = new System.Drawing.Size(144, 344);
            this.treeViewEntries.TabIndex = 0;
            // 
            // tableLayoutCategory
            // 
            this.tableLayoutCategory.ColumnCount = 5;
            this.tableLayoutCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutCategory.Controls.Add(this.buttonAddCategory, 1, 0);
            this.tableLayoutCategory.Controls.Add(this.buttonAddSubCategory, 2, 0);
            this.tableLayoutCategory.Controls.Add(this.buttonDeleteCategory, 3, 0);
            this.tableLayoutCategory.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutCategory.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutCategory.Name = "tableLayoutCategory";
            this.tableLayoutCategory.RowCount = 1;
            this.tableLayoutCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCategory.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutCategory.TabIndex = 1;
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddCategory.Image = global::QuickLaunch.Properties.Resources.package_add;
            this.buttonAddCategory.Location = new System.Drawing.Point(33, 3);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(24, 24);
            this.buttonAddCategory.TabIndex = 0;
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // buttonAddSubCategory
            // 
            this.buttonAddSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddSubCategory.Image = global::QuickLaunch.Properties.Resources.package_go;
            this.buttonAddSubCategory.Location = new System.Drawing.Point(63, 3);
            this.buttonAddSubCategory.Name = "buttonAddSubCategory";
            this.buttonAddSubCategory.Size = new System.Drawing.Size(24, 24);
            this.buttonAddSubCategory.TabIndex = 1;
            this.buttonAddSubCategory.UseVisualStyleBackColor = true;
            this.buttonAddSubCategory.Click += new System.EventHandler(this.buttonAddSubCategory_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteCategory.Image = global::QuickLaunch.Properties.Resources.package_delete;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(93, 3);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(24, 24);
            this.buttonDeleteCategory.TabIndex = 2;
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // tableLayoutEntries
            // 
            this.tableLayoutEntries.ColumnCount = 4;
            this.tableLayoutEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutEntries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutEntries.Controls.Add(this.buttonAddEntry, 1, 0);
            this.tableLayoutEntries.Controls.Add(this.buttonDeleteEntry, 2, 0);
            this.tableLayoutEntries.Location = new System.Drawing.Point(0, 380);
            this.tableLayoutEntries.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutEntries.Name = "tableLayoutEntries";
            this.tableLayoutEntries.RowCount = 1;
            this.tableLayoutEntries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutEntries.Size = new System.Drawing.Size(150, 30);
            this.tableLayoutEntries.TabIndex = 2;
            // 
            // buttonAddEntry
            // 
            this.buttonAddEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddEntry.Image = global::QuickLaunch.Properties.Resources.page_white_add;
            this.buttonAddEntry.Location = new System.Drawing.Point(48, 3);
            this.buttonAddEntry.Name = "buttonAddEntry";
            this.buttonAddEntry.Size = new System.Drawing.Size(24, 24);
            this.buttonAddEntry.TabIndex = 0;
            this.buttonAddEntry.UseVisualStyleBackColor = true;
            this.buttonAddEntry.Click += new System.EventHandler(this.buttonAddEntry_Click);
            // 
            // buttonDeleteEntry
            // 
            this.buttonDeleteEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteEntry.Image = global::QuickLaunch.Properties.Resources.page_white_delete;
            this.buttonDeleteEntry.Location = new System.Drawing.Point(78, 3);
            this.buttonDeleteEntry.Name = "buttonDeleteEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(24, 24);
            this.buttonDeleteEntry.TabIndex = 1;
            this.buttonDeleteEntry.UseVisualStyleBackColor = true;
            this.buttonDeleteEntry.Click += new System.EventHandler(this.buttonDeleteEntry_Click);
            // 
            // LaunchEntryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 410);
            this.Controls.Add(this.tableLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LaunchEntryList";
            this.Text = "LaunchEntryList";
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutCategory.ResumeLayout(false);
            this.tableLayoutEntries.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TreeView treeViewEntries;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCategory;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonAddSubCategory;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutEntries;
        private System.Windows.Forms.Button buttonAddEntry;
        private System.Windows.Forms.Button buttonDeleteEntry;
    }
}