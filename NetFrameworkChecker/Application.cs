using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NetFrameworkChecker {
    public partial class Application : Form {
        public Application() {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);

            Text = (!string.IsNullOrEmpty(Start.InitialApplicationName) ? Start.InitialApplicationName + " - " : "") + @".NET framework checker";

            var available = NetFrameworkVersion.IsVersionAvailable(Start.VersionNeeded);

            neededVersion.Text = Start.VersionNeeded;
            
            checkBoxInstalled.Text = available? "Yes" : "No";
            checkBoxInstalled.Checked = available;
            
            if (available) {
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
            
            foreach(var v in NetFrameworkVersion.GetVersionFromRegistry()) {
                listBox1.Items.Add(v);
            }
        }

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
            // D:\Profiles\jcaillon\Downloads\NDP46-KB3045560-Web.exe /passive /promptrestart /showfinalerror /showrmui
        }
    }
}
