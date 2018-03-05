using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;



namespace NetFrameworkChecker {
    public partial class Application : Form {
        private Timer _timer;
        private NetFrameworkInstaller _installer;

        public Application() {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) {
            downloadBar.Hide();
            downloadPercent.Hide();

            MinimumSize = Size;

            RefreshUi();
            _timer = new Timer {
                Interval = 1000
            };
            _timer.Tick += (sender, args) => RefreshUi();
            _timer.Start();
            
            base.OnShown(e);
        }

        private void RefreshUi() {
            Text = (!string.IsNullOrEmpty(Start.InitialApplicationName) ? Start.InitialApplicationName + " - " : "") + @".NET framework checker";

            NetFrameworkVersion.RefreshVersionList();

            NetVersionAvailable = NetFrameworkVersion.IsVersionAvailable(Start.VersionNeeded);

            neededVersion.Text = Start.VersionNeeded;
            
            checkBoxInstalled.Text = NetVersionAvailable? "Yes" : "No";
            checkBoxInstalled.Checked = NetVersionAvailable;
            
            if (NetVersionAvailable) {
                buttonInstall.Hide();
                message2.Hide();
                checkBoxInstalled.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            } else {
                checkBoxInstalled.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                message.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                message2.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                message.Text = @"You do not have the required version of .net installed to run " + (!string.IsNullOrEmpty(Start.InitialApplicationName) ? Start.InitialApplicationName : "this application") + @".";
                message2.Text = @"Click the install button to start the web installation or install it manually (see links above)";
            }
            
            listBox1.Items.Clear();
            foreach(var v in NetFrameworkVersion.GetVersionFromRegistry()) {
                listBox1.Items.Add(v);
            }
        }

        public bool NetVersionAvailable { get; set; }

        private void buttonOk_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(NetFrameworkVersion.GetVersionUrl(Start.VersionNeeded, NetFrameworkVersion.InstallerType.Webclient));
        }

        private void linkOffline_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(NetFrameworkVersion.GetVersionUrl(Start.VersionNeeded, NetFrameworkVersion.InstallerType.Full));
        }

        private void buttonInstall_Click(object sender, EventArgs e) {
            buttonInstall.Enabled = false;
            
            _installer = new NetFrameworkInstaller(NetFrameworkVersion.GetVersionUrl(Start.VersionNeeded, NetFrameworkVersion.InstallerType.Webclient),  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dotNetInstaller_v" + Start.VersionNeeded + ".exe"), ProgressHandler, OnCompleteDownload);
            _installer.Install();

            downloadBar.Show();
            downloadPercent.Show();
        }

        private void OnCompleteDownload(NetFrameworkInstaller obj) {
            downloadBar.Hide();
            downloadPercent.Hide();
        }

        private void ProgressHandler(object o, DownloadProgressChangedEventArgs e) {
            downloadBar.Value = e.ProgressPercentage;
            downloadPercent.Text = e.ProgressPercentage + @"%";
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (!NetVersionAvailable) {
                var answer = MessageBox.Show(@"If you choose not to install the required microsoft .net framework," + Environment.NewLine + (!string.IsNullOrEmpty(Start.InitialApplicationName) ? Start.InitialApplicationName : "this application") + @" will either not start or crash unexpectedly!" + Environment.NewLine + Environment.NewLine + @"SEX : Make sure to read this message before leaving!", @".net required version unavailable", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }
            }

            if (_installer != null) {
                _installer.Stop();
            }
            _timer.Stop();
            base.OnClosing(e);
        }

        private void label_startdownload_Click(object sender, EventArgs e)
        {

        }
    }
}
