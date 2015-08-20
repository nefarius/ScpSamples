using System;
using System.Configuration;
using System.Windows.Forms;
using DskMapper.Properties;
using ScpControl;
using ScpControl.ScpCore;
using ScpControl.Utilities;

namespace DskMapper
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
            cbMinimise.Checked = Config.Minimise;

            cbAutoStart.Checked = Config.AutoStart;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            Icon = Resources.Scp_All;

            scpProxy.Start();

            m_Selected = m_Active = scpProxy.ActiveProfile;

            cbProfile.Items.Clear();
            cbProfile.Items.AddRange(scpProxy.Mapper.Profiles);

            try
            {
                cbProfile.SelectedItem = Config.Profile;
            }
            catch
            {
                cbProfile.SelectedItem = m_Active;
            }

            scpGps.Pad = (DsPadId)cbPad.SelectedIndex;

            scpGps.ScaleX = tbMouseX.Value * (cbXInverted.Checked ? -1 : +1);
            scpGps.ScaleY = tbMouseY.Value * (cbYInverted.Checked ? -1 : +1);
            scpGps.Threshold = tbThreshold.Value;

            if (cbAutoStart.Checked) btnStart_Click(this, e);
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

        protected void cbActivate_CheckedChanged(object sender, EventArgs e)
        {
            Config.Activate = cbActivate.Checked;
        }

        protected void cbMinimise_CheckedChanged(object sender, EventArgs e)
        {
            Config.Minimise = cbMinimise.Checked;
        }

        protected void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoStart = cbAutoStart.Checked;
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
            if (scpProxy.IsNativeFeedAvailable)
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

                if (cbMinimise.Checked) WindowState = FormWindowState.Minimized;
            }
            else
            {
                MessageBox.Show(this, "Native Feed is not available", Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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

    [SettingsProvider(typeof(RegistryProvider))]
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

        [UserScopedSetting, DefaultSettingValue("false")]
        public Boolean Minimise
        {
            get { return (Boolean)this["Minimise"]; }
            set { this["Minimise"] = value; }
        }

        [UserScopedSetting, DefaultSettingValue("false")]
        public Boolean AutoStart
        {
            get { return (Boolean)this["AutoStart"]; }
            set { this["AutoStart"] = value; }
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