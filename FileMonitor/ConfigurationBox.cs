using System;
using System.Windows.Forms;

namespace FileMonitor
{
    public partial class ConfigurationBox : Form
    {
        private Configuration _configuration;
        private int _minutes_yellow;
        private int _minutes_red;
        private int _minutes_refresh;
        private bool _isbusy;

        public ConfigurationBox(bool lTemCancel)
        {
            InitializeComponent();
            _configuration = ConfigutarionManager.Instance();
            BtnCancelar.Visible = lTemCancel;
            PreencherCampos();
        }
        public ConfigurationBox()
        {
            InitializeComponent();
            _configuration = ConfigutarionManager.Instance();
            PreencherCampos();
        }
        private void PreencherCampos()
        {
            if (_configuration.Folder == null)
            {
                _configuration.Folder = string.Empty;
            }
            if (_configuration.Icon == null)
            {
                _configuration.Icon = string.Empty;
            }
            if (_configuration.SubFolder == null)
            {
                _configuration.SubFolder = string.Empty;
            }
            _minutes_yellow = _configuration.Minutes_Yellow;
            _minutes_red = _configuration.Minutes_Red;
            _minutes_refresh = _configuration.Minutes_Refresh;

            EntAmarelo.Text = _minutes_yellow.ToString();
            EntVermelho.Text = _minutes_red.ToString();
            EntRefresh.Text = _minutes_refresh.ToString();

            EntPasta.Text = _configuration.Folder.Trim();
            EntSubPasta.Text = _configuration.SubFolder.Trim();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ChooseFolder()
        {
            using (var folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    EntPasta.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        private void BtnFolder_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            _configuration.Folder = EntPasta.Text.Trim();
            _configuration.Minutes_Yellow = _minutes_yellow;
            _configuration.Minutes_Red = _minutes_red;
            _configuration.Minutes_Refresh = _minutes_refresh;
            _configuration.SubFolder = EntSubPasta.Text.Trim();
            if (ConfigutarionManager.Save(_configuration) is Configuration)
            {
                this.Close();
            }
        }
        private void EntPasta_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(EntPasta.Text.Trim()) || _isbusy)
            {
                return;
            }

            _isbusy = true;

            if (!EntPasta.Text.EndsWith(@"\"))

            {
                EntPasta.Text += @"\";
            }

            if (EntPasta.Text.Substring(2).Contains(@"\\"))
            {
                if (EntPasta.Text.StartsWith(@"\\"))
                {
                    EntPasta.Text = @"\\" + EntPasta.Text.Substring(2).Replace(@"\\", @"\");
                }
                else
                {
                    EntPasta.Text = EntPasta.Text.Replace(@"\\", @"\");
                }
            }

            _isbusy = false;

        }
        private void EntAmarelo_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(EntAmarelo.Text.Trim()) || _isbusy)
            {
                return;
            }
            _isbusy = true;

            try
            {
                _minutes_yellow = Convert.ToInt32(EntAmarelo.Text.Trim());
            }
            catch (Exception ex)
            {
                _minutes_yellow = 0;
                EntAmarelo.Text = "0";
                EntAmarelo.Focus();
                MessageBox.Show("Verifique o valor informado para o 'Alerta' (Amarelo). " + ex.Message.Trim());
            }

            _isbusy = false;
        }
        private void EntVermelho_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(EntVermelho.Text.Trim()) || _isbusy)
            {
                return;
            }
            _isbusy = true;

            try
            {
                _minutes_red = Convert.ToInt32(EntVermelho.Text.Trim());
            }
            catch (Exception ex)
            {
                _minutes_red = 0;
                EntVermelho.Text = "0";
                MessageBox.Show("Verifique o valor informado para o 'Parada' (Vermelho). " + ex.Message.Trim());
            }

            _isbusy = false;
        }
        private void EntRefresh_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(EntRefresh.Text.Trim()) || _isbusy)
            {
                return;
            }
            _isbusy = true;

            try
            {
                _minutes_refresh = Convert.ToInt32(EntRefresh.Text.Trim());
            }
            catch (Exception ex)
            {
                _minutes_red = 0;
                EntRefresh.Text = "0";
                MessageBox.Show("Verifique o valor informado para o 'Timer'. " + ex.Message.Trim());
            }

            _isbusy = false;
        }

        private void EntSubPasta_Leave(object sender, EventArgs e)
        {
            if (string.Empty.Equals(EntSubPasta.Text.Trim()) || _isbusy)
            {
                return;
            }

            _isbusy = true;

            if (!EntSubPasta.Text.EndsWith(@"\"))

            {
                EntSubPasta.Text += @"\";
            }

            if (EntSubPasta.Text.Substring(2).Contains(@"\\"))
            {
                if (EntSubPasta.Text.StartsWith(@"\\"))
                {
                    EntSubPasta.Text = @"\\" + EntSubPasta.Text.Substring(2).Replace(@"\\", @"\");
                }
                else
                {
                    EntSubPasta.Text = EntPasta.Text.Replace(@"\\", @"\");
                }
            }

            _isbusy = false;


        }
    }
}
