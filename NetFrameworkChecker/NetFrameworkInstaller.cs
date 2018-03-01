using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace NetFrameworkChecker {

    public class NetFrameworkInstaller {

        private WebClient _webClient;
        private Stopwatch _sw = new Stopwatch();

        private string _url;
        private string _discLocation;
        private DownloadProgressChangedEventHandler _downloadProgressHandler;
        private Action<NetFrameworkInstaller> _downloadCompletedAction;

        public NetFrameworkInstaller(string url, string discLocation, DownloadProgressChangedEventHandler downloadProgressHandler, Action<NetFrameworkInstaller> downloadCompletedAction) {
            _url = url;
            _discLocation = discLocation;
            _downloadProgressHandler = downloadProgressHandler;
            _downloadCompletedAction = downloadCompletedAction;
        }

        private void DownloadFile(string urlAddress, string location, DownloadProgressChangedEventHandler progressHandler) {
            using (_webClient = new WebClient()) {
                _webClient.DownloadFileCompleted += CompletedDownload;
                _webClient.DownloadProgressChanged += progressHandler;
                _sw.Start();
                try {
                    _webClient.DownloadFileAsync(new Uri(urlAddress), location);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CompletedDownload(object sender, AsyncCompletedEventArgs e) {
            _sw.Reset();
            _downloadCompletedAction(this);

            // D:\Profiles\jcaillon\Downloads\NDP46-KB3045560-Web.exe /passive /promptrestart /showfinalerror /showrmui
            try {
                //Process.Start(_discLocation, "/passive /promptrestart /showfinalerror /showrmui");
                Process.Start(_discLocation, "");
            } catch (Exception) {
                //ignored
            }
        }

        public void Install() {
            DownloadFile(_url, _discLocation, _downloadProgressHandler);
        }

        public void Stop() {
            _webClient.CancelAsync();
        }
    }
}