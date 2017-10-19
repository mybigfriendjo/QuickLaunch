using System;
using System.Windows.Forms;
using QuickLaunch.app;

namespace QuickLaunch {
    public partial class Main : Form {
        private readonly KeyboardHook hook = new KeyboardHook();
        private readonly NotifyIcon trayIcon;
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
                Text = "Telefonbuch",
                ContextMenu = trayMenu
            };
            trayIcon.DoubleClick += trayIcon_DoubleClick;
            trayIcon.Visible = true;
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
    }
}
