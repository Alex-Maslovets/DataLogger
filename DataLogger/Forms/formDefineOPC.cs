using System;
using System.Windows.Forms;
using OPCSiemensDAAutomation;
using DataManager;
using Tools;

namespace DataLogger
{
    public partial class formDefineOPC : Form
    {
        public formDefineOPC()
        {
            InitializeComponent();
        }

        private void UpdateConfigState(ConfigState state)
        {
            if (state == ConfigState.Stopped)
            {
                SafeThread.SetEnableControl(textOPCNodeName, true);
                SafeThread.SetEnableControl(nudOPCUpdateRate, true);
                SafeThread.SetEnableControl(btnApply, true);
                SafeThread.SetEnableControl(btnTest, true);
            }
            else
            {
                SafeThread.SetEnableControl(textOPCNodeName, false);
                SafeThread.SetEnableControl(nudOPCUpdateRate, false);
                SafeThread.SetEnableControl(btnApply, false);
                SafeThread.SetEnableControl(btnTest, false);
            }
        }

        private void frmDefineOPC_Load(object sender, EventArgs e)
        {
            textOPCNodeName.Text = Config.Sets.Primary_OPC_Node;
            nudOPCUpdateRate.Value = Config.Sets.UpdateRate;           
            UpdateConfigState(Config.State);
            Config.StateChange += ConfigStateChange;
        }

        private void ConfigStateChange(object sender, ConfigStateEventArgs e)
        {
            UpdateConfigState(e.State);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Config.Sets.Primary_OPC_Node = textOPCNodeName.Text;
            Config.Sets.UpdateRate = (int)nudOPCUpdateRate.Value;
            Config.Save();
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                Exception exception = OPCSimaticNet.TestConnection(textOPCNodeName.Text);
                if (exception == null)
                {
                    MessageBox.Show("Success", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {


            }

        }
    }
}
