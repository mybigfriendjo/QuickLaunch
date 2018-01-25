using System;
using System.Drawing;
using System.Windows.Forms;
using QuickLaunch.app;
using QuickLaunch.storage;

namespace QuickLaunch {
    public partial class Main : Form {
        private readonly KeyboardHook hook = new KeyboardHook();
        private readonly NotifyIcon trayIcon;

        private Panel autoCompletePanel = new Panel();
        private ListView autoCompleteListView = new ListView();

        public Main() {
            InitializeComponent();

            hook.KeyPressed += hook_KeyPressed;
            hook.RegisterHotKey(app.ModifierKeys.None, Keys.F8);

            ContextMenu trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Fenster anzeigen", ShowWindow);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Beenden", ExitApplication);
            trayIcon = new NotifyIcon {
                Icon = Properties.Resources.lightningBolt,
                Text = "QuickLaunch",
                ContextMenu = trayMenu
            };
            trayIcon.DoubleClick += trayIcon_DoubleClick;
            trayIcon.Visible = true;

            autoCompletePanel.Visible = false;
            autoCompletePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            autoCompletePanel.ClientSize = new Size(1, 1);
            autoCompletePanel.Padding = new Padding(0);
            autoCompletePanel.Margin = new Padding(0);
            autoCompletePanel.BackColor = Color.Transparent;
            autoCompletePanel.ForeColor = Color.Transparent;
            autoCompletePanel.PerformLayout();
            autoCompletePanel.Controls.Add(autoCompleteListView);

            autoCompleteListView.Dock = DockStyle.Fill;
            autoCompleteListView.MultiSelect = false;
            autoCompleteListView.View = View.Details;
            autoCompleteListView.FullRowSelect = true;
            autoCompleteListView.Columns.Add("Image", -2, HorizontalAlignment.Left);
            autoCompleteListView.Columns.Add("Path", -2, HorizontalAlignment.Left);
            autoCompleteListView.Columns.Add("Tags", -2, HorizontalAlignment.Left);
            autoCompleteListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            autoCompleteListView.KeyDown += autoCompleteListView_KeyDown;
            autoCompleteListView.DoubleClick += autoCompleteListView_MouseDoubleClick;
        }

        private void autoCompleteListView_MouseDoubleClick(object sender, EventArgs e) {
            if (autoCompleteListView.Items.Count > 0) {
                if (autoCompleteListView.SelectedIndices.Count > 0) {
                    ExecuteCurrentSelection();
                }
            }
        }

        private void autoCompleteListView_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (autoCompleteListView.SelectedItems.Count > 0) {
                    ExecuteCurrentSelection();
                }
            } else if (e.KeyCode == Keys.Up) {
                MoveAutoCompleteSelection(-1);
            } else if (e.KeyCode == Keys.Down) {
                MoveAutoCompleteSelection(+1);
            } else {
                OnKeyDown(e);
            }
        }

        private void MoveAutoCompleteSelection(int direction) {
            if (autoCompleteListView.Visible) {
                if (autoCompleteListView.Items.Count > 0) {
                    autoCompleteListView.Select();
                    if (autoCompleteListView.SelectedIndices.Count == 0) {
                        autoCompleteListView.Items[0].Selected = true;
                    } else if (autoCompleteListView.SelectedIndices[0] + direction < 0) {
                        autoCompleteListView.Items[0].Selected = true;
                    } else if (autoCompleteListView.SelectedIndices[0] + direction > autoCompleteListView.Items.Count - 1) {
                        autoCompleteListView.Items[autoCompleteListView.Items.Count - 1].Selected = true;
                    } else {
                        autoCompleteListView.Items[autoCompleteListView.SelectedIndices[0] + direction].Selected = true;
                    }
                }
            }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e) {
            ShowAndSetFocus();
        }

        private void ShowWindow(object sender, EventArgs e) {
            ShowAndSetFocus();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e) {
            ShowAndSetFocus();
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE) {
                ShowAndSetFocus();
            }
            base.WndProc(ref m);
        }

        private void ShowAndSetFocus() {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            textLaunch.Clear();
            textLaunch.Focus();
        }

        private void ExitApplication(object sender, EventArgs e) {
            DisposeAndQuit();
        }

        private void DisposeAndQuit() {
            hook.Dispose();
            if (trayIcon != null) {
                trayIcon.Visible = false;
            }
            Dispose();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            switch (e.CloseReason) {
                case CloseReason.ApplicationExitCall:
                case CloseReason.TaskManagerClosing:
                case CloseReason.WindowsShutDown:
                    DisposeAndQuit();
                    break;
                default:
                    e.Cancel = true;
                    Hide();
                    break;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Hide();
            }
        }

        private void textLaunch_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    ExecuteCurrentSelection();
                    break;
                case Keys.Up:
                    MoveAutoCompleteSelection(-1);
                    break;
                case Keys.Down:
                    MoveAutoCompleteSelection(+1);
                    break;
                default:
                    OnKeyDown(e);
                    break;
            }
        }

        private void ExecuteCurrentSelection() {
            if (autoCompleteListView.SelectedItems.Count > 0) {
                // TODO: launch selected entry
            }
        }

        private void textLaunch_TextChanged(object sender, EventArgs e) {
            if (textLaunch.Text.Trim().Length >= 3) {
                autoCompletePanel.SuspendLayout();
                autoCompleteListView.BeginUpdate();
                autoCompleteListView.Items.Clear();
                foreach (LaunchEntry entry in LaunchRegistry.INSTANCE.Search(textLaunch.Text.Trim())) {
                    ListViewItem item = new ListViewItem(new[] { entry.Name }) {
                        ImageIndex = entry.ImageListIndex,
                        Tag = entry
                    };
                    autoCompleteListView.Items.Add(item);
                }
                autoCompleteListView.EndUpdate();

                if (ActiveForm != null) {
                    autoCompletePanel.Width = ActiveForm.Width - 22;
                }
                int remainingSpace = ClientSize.Height - textLaunch.Height - textLaunch.Location.Y;
                if (remainingSpace > 150) {
                    remainingSpace = 150;
                }
                autoCompletePanel.Height = remainingSpace;
                autoCompletePanel.Location = textLaunch.Location + new Size(0, textLaunch.Height);

                if (!Controls.Contains(autoCompletePanel)) {
                    Controls.Add(autoCompletePanel);
                }

                if (autoCompleteListView.Items.Count > 0) {
                    SetColWidthsToMaxWidth(autoCompleteListView);
                    autoCompletePanel.Show();
                    autoCompletePanel.BringToFront();
                    textLaunch.Focus();
                } else {
                    HideAutoCompleteList();
                }

                autoCompletePanel.ResumeLayout();
            } else {
                HideAutoCompleteList();
            }
        }

        private void SetColWidthsToMaxWidth(ListView viewToAdjust) {
            foreach (ColumnHeader col in viewToAdjust.Columns) {
                col.Width = 1;
                int width = col.Width;

                col.Width = -1;
                if (width < col.Width) {
                    width = col.Width;
                }
                col.Width = -2;
                if (width < col.Width) {
                    width = col.Width;
                }
                col.Width = width;
            }
        }

        private void HideAutoCompleteList() {
            autoCompletePanel.Hide();
            Controls.Remove(autoCompletePanel);
        }
    }
}
