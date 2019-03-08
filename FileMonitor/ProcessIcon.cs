using FileMonitor.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace FileMonitor
{
    class ProcessIcon : IDisposable
    {
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
        }

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(MouseClick);
            ni.Icon = Resources.StatusOKComplete;
            ni.BalloonTipTitle = "File Monitor";
            ni.Text = "File  Monitor";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = new ContextMenus().Create();

            ConfigutarionManager.Instance().Icon = string.Empty;
            ConfigutarionManager.Save();

            while (string.IsNullOrEmpty(ConfigutarionManager.Instance().Folder))
            {
                new ConfigurationBox(false).ShowDialog();
            }

            RefreshStatus();
            DefineTimer();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    RefreshStatus();
                    //ni.ShowBalloonTip(5000);
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }
        private void DefineTimer()
        {
            var minutes = TimeSpan.FromMinutes(ConfigutarionManager.Instance().Minutes_Refresh);
            var miliseconds = minutes.TotalMilliseconds;
            var timer = new Timer
            {
                Interval = (int)miliseconds,
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        public bool RefreshStatus()
        {
            if (string.IsNullOrEmpty(ConfigutarionManager.Instance().Folder))
            {
                return false;
            }
            var retorno = false;
            var LastUpdate = GetLastUpdatedFile(ConfigutarionManager.Instance().Folder, ConfigutarionManager.Instance().SubFolder);
            var DifDate = DateTime.Now - LastUpdate;
            int difdate = (int)DifDate.TotalMinutes;

            var bkpicon = ConfigutarionManager.Instance().Icon;

            if ((int)DifDate.TotalMinutes > ConfigutarionManager.Instance().Minutes_Red)
            {
                ConfigutarionManager.Instance().Icon = "StatusError";
            }
            else if ((int)DifDate.TotalMinutes > ConfigutarionManager.Instance().Minutes_Yellow)
            {
                ConfigutarionManager.Instance().Icon = "StatusWarning";
            }
            else
            {
                ConfigutarionManager.Instance().Icon = "StatusOKComplete";
            }

            ConfigutarionManager.Instance().LastUpdate = LastUpdate;
            ConfigutarionManager.Save();

            switch (ConfigutarionManager.Instance().Icon)
            {
                case "StatusError":

                    ni.Icon = Resources.StatusError;
                    ni.BalloonTipIcon = ToolTipIcon.Error;
                    ni.BalloonTipText = "O serviço está sem receber arquivos há " + difdate.ToString() + " minutos ";
                    ni.BalloonTipText += "(Tolerância " + ConfigutarionManager.Instance().Minutes_Red.ToString() + " minutos). ";
                    ni.BalloonTipText += "\nData e Hora do ultimo recebimento: " + ConfigutarionManager.Instance().LastUpdate.ToString("dd/MM/yyyy HH:mm:ss");
                    break;
                case "StatusWarning":
                    ni.Icon = Resources.StatusWarning;
                    ni.BalloonTipIcon = ToolTipIcon.Warning;
                    ni.BalloonTipText = "O serviço está sem receber arquivos há " + difdate.ToString() + " minutos ";
                    ni.BalloonTipText += "(Tolerância = " + ConfigutarionManager.Instance().Minutes_Yellow.ToString() + " minutos). ";
                    ni.BalloonTipText += "\nData e Hora do ultimo recebimento: " + ConfigutarionManager.Instance().LastUpdate.ToString("dd/MM/yyyy HH:mm:ss");
                    break;
                default:
                    ni.Icon = Resources.StatusOKComplete;
                    ni.BalloonTipIcon = ToolTipIcon.Info;
                    ni.BalloonTipText = "Recebido um arquivo a " + difdate.ToString() + " minutos.\n";
                    ni.BalloonTipText += "Alterado o status para 'OK' \n";
                    ni.BalloonTipText += "Data e Hora do ultimo recebimento: " + ConfigutarionManager.Instance().LastUpdate.ToString("dd/MM/yyyy HH:mm:ss");
                    break;
            }
            if (ConfigutarionManager.Instance().Icon == "StatusError")
            {
                MessageBox.Show(ni.BalloonTipText.Replace("\n", "\n\n"), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ni.ShowBalloonTip(5000);
            }
            retorno = true;
            return retorno;
        }
        private DateTime GetLastUpdatedFile(string folder, string subFolder)
        {
            var retorno = DateTime.MinValue;

            try
            {
                var directory = new DirectoryInfo(folder);
                if (directory.Exists)
                {
                    var received = directory.GetFiles()
                                         .OrderByDescending(f => f.LastWriteTime)
                                         .FirstOrDefault();

                    var directory_archive = new DirectoryInfo(folder + subFolder);
                    if (directory_archive.Exists)
                    {
                        var archived = directory_archive.GetFiles()
                            .OrderByDescending(f => f.LastWriteTime)
                            .FirstOrDefault();

                        if (archived != null && archived.LastWriteTime > retorno)
                        {
                            retorno = archived.LastWriteTime;

                        }
                    }

                    if (received != null && received.LastWriteTime > retorno)
                    {
                        retorno = received.LastWriteTime;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar o arquivo mais novo: " + ex.ToString());
            }

            return retorno;
        }
    }
}
