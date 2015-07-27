namespace D3Mapper
{
    partial class ScpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scpProxy = new ScpControl.ScpProxy(this.components);
            this.cbPad = new System.Windows.Forms.ComboBox();
            this.cbActivate = new System.Windows.Forms.CheckBox();
            this.cbProfile = new System.Windows.Forms.ComboBox();
            this.gbT = new System.Windows.Forms.GroupBox();
            this.tbThreshold = new System.Windows.Forms.TrackBar();
            this.gbY = new System.Windows.Forms.GroupBox();
            this.cbYInverted = new System.Windows.Forms.CheckBox();
            this.tbMouseY = new System.Windows.Forms.TrackBar();
            this.gbX = new System.Windows.Forms.GroupBox();
            this.tbMouseX = new System.Windows.Forms.TrackBar();
            this.cbXInverted = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.scpGps = new D3Mapper.GamePadState(this.components);
            this.gbT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).BeginInit();
            this.gbY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseY)).BeginInit();
            this.gbX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseX)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPad
            // 
            this.cbPad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPad.FormattingEnabled = true;
            this.cbPad.Items.AddRange(new object[] {
            "Pad 1",
            "Pad 2",
            "Pad 3",
            "Pad 4"});
            this.cbPad.Location = new System.Drawing.Point(324, 247);
            this.cbPad.Name = "cbPad";
            this.cbPad.Size = new System.Drawing.Size(98, 21);
            this.cbPad.TabIndex = 18;
            this.cbPad.SelectedIndexChanged += new System.EventHandler(this.cbPad_SelectedIndexChanged);
            // 
            // cbActivate
            // 
            this.cbActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActivate.AutoSize = true;
            this.cbActivate.Location = new System.Drawing.Point(181, 251);
            this.cbActivate.Name = "cbActivate";
            this.cbActivate.Size = new System.Drawing.Size(137, 17);
            this.cbActivate.TabIndex = 17;
            this.cbActivate.Text = "Activate Profile on Start";
            this.cbActivate.UseVisualStyleBackColor = true;
            // 
            // cbProfile
            // 
            this.cbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfile.FormattingEnabled = true;
            this.cbProfile.Location = new System.Drawing.Point(12, 247);
            this.cbProfile.Name = "cbProfile";
            this.cbProfile.Size = new System.Drawing.Size(163, 21);
            this.cbProfile.TabIndex = 16;
            this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbProfile_SelectedIndexChanged);
            // 
            // gbT
            // 
            this.gbT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbT.Controls.Add(this.tbThreshold);
            this.gbT.Location = new System.Drawing.Point(12, 162);
            this.gbT.Name = "gbT";
            this.gbT.Size = new System.Drawing.Size(408, 69);
            this.gbT.TabIndex = 15;
            this.gbT.TabStop = false;
            this.gbT.Text = "Threshold";
            // 
            // tbThreshold
            // 
            this.tbThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThreshold.Location = new System.Drawing.Point(6, 19);
            this.tbThreshold.Maximum = 25;
            this.tbThreshold.Minimum = 1;
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(326, 45);
            this.tbThreshold.TabIndex = 0;
            this.tbThreshold.Value = 20;
            this.tbThreshold.ValueChanged += new System.EventHandler(this.tbThreshold_ValueChanged);
            this.tbThreshold.MouseCaptureChanged += new System.EventHandler(this.TrackBar_Capture);
            // 
            // gbY
            // 
            this.gbY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbY.Controls.Add(this.cbYInverted);
            this.gbY.Controls.Add(this.tbMouseY);
            this.gbY.Location = new System.Drawing.Point(12, 87);
            this.gbY.Name = "gbY";
            this.gbY.Size = new System.Drawing.Size(408, 69);
            this.gbY.TabIndex = 14;
            this.gbY.TabStop = false;
            this.gbY.Text = "Mouse Y Scaling";
            // 
            // cbYInverted
            // 
            this.cbYInverted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYInverted.AutoSize = true;
            this.cbYInverted.Location = new System.Drawing.Point(338, 19);
            this.cbYInverted.Name = "cbYInverted";
            this.cbYInverted.Size = new System.Drawing.Size(65, 17);
            this.cbYInverted.TabIndex = 1;
            this.cbYInverted.Text = "Inverted";
            this.cbYInverted.UseVisualStyleBackColor = true;
            this.cbYInverted.CheckedChanged += new System.EventHandler(this.cbYInverted_CheckedChanged);
            // 
            // tbMouseY
            // 
            this.tbMouseY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMouseY.Location = new System.Drawing.Point(6, 19);
            this.tbMouseY.Maximum = 25;
            this.tbMouseY.Minimum = 1;
            this.tbMouseY.Name = "tbMouseY";
            this.tbMouseY.Size = new System.Drawing.Size(326, 45);
            this.tbMouseY.TabIndex = 0;
            this.tbMouseY.Value = 10;
            this.tbMouseY.ValueChanged += new System.EventHandler(this.tbMouseY_ValueChanged);
            this.tbMouseY.MouseCaptureChanged += new System.EventHandler(this.TrackBar_Capture);
            // 
            // gbX
            // 
            this.gbX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbX.Controls.Add(this.tbMouseX);
            this.gbX.Controls.Add(this.cbXInverted);
            this.gbX.Location = new System.Drawing.Point(12, 12);
            this.gbX.Name = "gbX";
            this.gbX.Size = new System.Drawing.Size(408, 69);
            this.gbX.TabIndex = 13;
            this.gbX.TabStop = false;
            this.gbX.Text = "Mouse X Scaling";
            // 
            // tbMouseX
            // 
            this.tbMouseX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMouseX.Location = new System.Drawing.Point(6, 19);
            this.tbMouseX.Maximum = 25;
            this.tbMouseX.Minimum = 1;
            this.tbMouseX.Name = "tbMouseX";
            this.tbMouseX.Size = new System.Drawing.Size(326, 45);
            this.tbMouseX.TabIndex = 0;
            this.tbMouseX.Value = 10;
            this.tbMouseX.ValueChanged += new System.EventHandler(this.tbMouseX_ValueChanged);
            this.tbMouseX.MouseCaptureChanged += new System.EventHandler(this.TrackBar_Capture);
            // 
            // cbXInverted
            // 
            this.cbXInverted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbXInverted.AutoSize = true;
            this.cbXInverted.Location = new System.Drawing.Point(338, 19);
            this.cbXInverted.Name = "cbXInverted";
            this.cbXInverted.Size = new System.Drawing.Size(65, 17);
            this.cbXInverted.TabIndex = 1;
            this.cbXInverted.Text = "Inverted";
            this.cbXInverted.UseVisualStyleBackColor = true;
            this.cbXInverted.CheckedChanged += new System.EventHandler(this.cbXInverted_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(266, 286);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.Enter += new System.EventHandler(this.Button_Enter);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(347, 286);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.Enter += new System.EventHandler(this.Button_Enter);
            // 
            // scpGps
            // 
            this.scpGps.Enabled = false;
            this.scpGps.Pad = ScpControl.DsPadId.One;
            this.scpGps.Proxy = this.scpProxy;
            this.scpGps.ScaleX = 0;
            this.scpGps.ScaleY = 0;
            this.scpGps.Threshold = 0;
            // 
            // ScpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 321);
            this.Controls.Add(this.cbPad);
            this.Controls.Add(this.cbActivate);
            this.Controls.Add(this.cbProfile);
            this.Controls.Add(this.gbT);
            this.Controls.Add(this.gbY);
            this.Controls.Add(this.gbX);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.MinimumSize = new System.Drawing.Size(450, 360);
            this.Name = "ScpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doom 3 Mapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Close);
            this.Load += new System.EventHandler(this.Form_Load);
            this.gbT.ResumeLayout(false);
            this.gbT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).EndInit();
            this.gbY.ResumeLayout(false);
            this.gbY.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseY)).EndInit();
            this.gbX.ResumeLayout(false);
            this.gbX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScpControl.ScpProxy scpProxy;
        private System.Windows.Forms.ComboBox cbPad;
        private System.Windows.Forms.CheckBox cbActivate;
        private System.Windows.Forms.ComboBox cbProfile;
        private System.Windows.Forms.GroupBox gbT;
        private System.Windows.Forms.TrackBar tbThreshold;
        private System.Windows.Forms.GroupBox gbY;
        private System.Windows.Forms.CheckBox cbYInverted;
        private System.Windows.Forms.TrackBar tbMouseY;
        private System.Windows.Forms.GroupBox gbX;
        private System.Windows.Forms.TrackBar tbMouseX;
        private System.Windows.Forms.CheckBox cbXInverted;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private GamePadState scpGps;
    }
}

