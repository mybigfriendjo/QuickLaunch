using System;
using System.Windows.Forms;
using QuickLaunch.storage;

namespace QuickLaunch {
    public partial class LaunchEntryList : Form {
        public LaunchEntryList() {
            InitializeComponent();

            foreach (LaunchEntry entry in LaunchRegistry.INSTANCE.Entries) {
                if (entry.IsGroup) {
                    TreeNode group = new TreeNode(entry.Name);
                    treeViewEntries.Nodes.Add(group);
                    GenerateChildren(group, entry);
                    continue;
                }
                TreeNode item = new TreeNode(entry.Name) {
                    Tag = entry
                };
                treeViewEntries.Nodes.Add(item);
            }

            if (treeViewEntries.Nodes.Count>0) {
                treeViewEntries.SelectedNode = treeViewEntries.Nodes[0];
            }
            
        }

        private static void GenerateChildren(TreeNode current, LaunchEntry entry) {
            foreach (LaunchEntry child in entry.Children) {
                if (child.IsGroup) {
                    TreeNode group = new TreeNode(child.Name);
                    current.Nodes.Add(group);
                    GenerateChildren(group, child);
                    continue;
                }
                TreeNode item = new TreeNode(child.Name) {
                    Tag = child
                };
                current.Nodes.Add(item);
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e) {
            // TODO: 
        }

        private void buttonAddSubCategory_Click(object sender, EventArgs e) {
            // TODO: 
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e) {
            // TODO: 
        }

        private void buttonAddEntry_Click(object sender, EventArgs e) {
            // TODO: 
        }

        private void buttonDeleteEntry_Click(object sender, EventArgs e) {
            // TODO: 
        }
    }
}
