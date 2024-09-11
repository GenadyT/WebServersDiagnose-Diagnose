using WebServersDiagnose;
using SqlDataLayer;
using WebServersDispatcherApp;
using System.Windows.Forms;

namespace WebServersDispatcherApp
{
    public partial class frmDiagnose : Form
    {
        private WebServersDiagnose.WebServersManager webServersDispatcher;

        public frmDiagnose()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            string connectionString = System.Configuration.ConfigurationManager.
                ConnectionStrings["ConnectionString"].ConnectionString;

            webServersDispatcher = new WebServersDiagnose.WebServersManager(connectionString);  // Observer + Iterator
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            double interval = Convert.ToDouble(tbxDispatchInterval.Text);
            webServersDispatcher.Start(interval);

            tbaLog.Text += $"Start{System.Environment.NewLine}";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            webServersDispatcher.Stop();
            tbaLog.Text += $"Stop{System.Environment.NewLine}";
        }

        private void tbaLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
