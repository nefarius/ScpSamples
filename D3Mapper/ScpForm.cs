using System;
using System.Windows.Forms;
using System.Configuration;

using ScpControl;
using ScpControl.Utilities;

namespace D3Mapper
{
    public partial class ScpForm : Form
    {
        protected RegistrySettings Config = new RegistrySettings();
        protected String m_Selected, m_Active;

        public ScpForm()
        {
            InitializeComponent();

            cbPad.SelectedIndex = Config.Pad;

            tbMouseX.Value = Config.MouseX;
            tbMouseY.Value = Config.MouseY;
            tbThreshold.Value = Config.Threshold;

            cbXInverted.Checked = Config.XInverted;
            cbYInverted.Checked = Config.YInverted;

            cbActivate.Checked = Config.Activate;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Scp_All;

            m_Selected = m_Active = scpProxy.ActiveProfile;

            cbProfile.Items.Clear();
            cbProfile.Items.AddRange(scpProxy.Mapper.Profiles);

            try { cbProfile.SelectedItem = Config.Profile; }
            catch { cbProfile.SelectedItem = m_Active; }

            scpGps.Pad = (DsPadId)cbPad.SelectedIndex;

            scpGps.ScaleX = tbMouseX.Value * (cbXInverted.Checked ? -1 : +1);
            scpGps.ScaleY = tbMouseY.Value * (cbYInverted.Checked ? -1 : +1);
            scpGps.Threshold = tbThreshold.Value;
        }

        protected void Form_Close(object sender, FormClosingEventArgs e)
        {
            if (btnStop.Enabled)
            {
                btnStop_Click(sender, e);
            }

            Config.Save();
        }


        protected void tbMouseX_ValueChanged(object sender, EventArgs e)
        {
            scpGps.ScaleX = cbXInverted.Checked ? -tbMouseX.Value : tbMouseX.Value;
            Config.MouseX = tbMouseX.Value;
        }

        protected void tbMouseY_ValueChanged(object sender, EventArgs e)
        {
            scpGps.ScaleY = cbYInverted.Checked ? -tbMouseY.Value : tbMouseY.Value;
            Config.MouseY = tbMouseY.Value;
        }

        protected void tbThreshold_ValueChanged(object sender, EventArgs e)
        {
            scpGps.Threshold = tbThreshold.Value;
            Config.Threshold = tbThreshold.Value;
        }


        protected void cbXInverted_CheckedChanged(object sender, EventArgs e)
        {
            scpGps.ScaleX *= -1;
            Config.XInverted = cbXInverted.Checked;
        }

        protected void cbYInverted_CheckedChanged(object sender, EventArgs e)
        {
            scpGps.ScaleY *= -1;
            Config.YInverted = cbYInverted.Checked;
        }


        protected void cbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Selected = cbProfile.SelectedItem.ToString();
            Config.Profile = m_Selected;
        }

        protected void cbPad_SelectedIndexChanged(object sender, EventArgs e)
        {
            scpGps.Pad = (DsPadId)cbPad.SelectedIndex;
            Config.Pad = cbPad.SelectedIndex;
        }


        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (scpProxy.Start() && scpProxy.IsNativeFeedAvailable)
            {
                cbPad.Enabled = cbProfile.Enabled = false;

                if (cbActivate.Checked)
                {
                    scpProxy.Select(scpProxy.Mapper.Map[m_Selected]);
                }

                btnStop.Enabled = true;
                btnStart.Enabled = cbActivate.Enabled = false;
                btnStop.Focus();

                scpGps.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Native Feed is not available", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            scpProxy.Stop();

            cbPad.Enabled = cbProfile.Enabled = true;

            if (cbActivate.Checked)
            {
                scpProxy.Select(scpProxy.Mapper.Map[m_Active]);
            }

            btnStop.Enabled = false;
            btnStart.Enabled = cbActivate.Enabled = true;
            btnStart.Focus();

            scpGps.Enabled = false;
        }


        protected void Button_Enter(object sender, EventArgs e)
        {
            ThemeUtil.UpdateFocus(((Button)sender).Handle);
        }

        protected void TrackBar_Capture(object sender, EventArgs e)
        {
            ThemeUtil.UpdateFocus(((TrackBar)sender).Handle);
        }
    }

    [SettingsProvider(typeof(ScpControl.RegistryProvider))]
    public class RegistrySettings : ApplicationSettingsBase
    {
        [UserScopedSetting, DefaultSettingValue("false")]
        public Boolean XInverted
        {
            get { return (Boolean)this["XInverted"]; }
            set { this["XInverted"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("false")]
        public Boolean YInverted
        {
            get { return (Boolean)this["YInverted"]; }
            set { this["YInverted"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("false")]
        public Boolean Activate
        {
            get { return (Boolean)this["Activate"]; }
            set { this["Activate"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("5")]
        public Int32 MouseX
        {
            get { return (Int32)this["MouseX"]; }
            set { this["MouseX"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("5")]
        public Int32 MouseY
        {
            get { return (Int32)this["MouseY"]; }
            set { this["MouseY"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("25")]
        public Int32 Threshold
        {
            get { return (Int32)this["Threshold"]; }
            set { this["Threshold"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("0")]
        public Int32 Pad
        {
            get { return (Int32)this["Pad"]; }
            set { this["Pad"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("Default")]
        public String Profile
        {
            get { return (String)this["Profile"]; }
            set { this["Profile"] = value; }
        }
    }
}
