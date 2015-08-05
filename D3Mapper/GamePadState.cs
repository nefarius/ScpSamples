using System;
using System.Windows.Forms;
using System.ComponentModel;

using ScpControl;
using ScpControl.ScpCore;
using ScpControl.Utilities;

namespace D3Mapper 
{
    public partial class GamePadState : ScpPadState 
    {
        // Mouse
        protected Boolean m_LMB = false;
        protected Boolean m_MMB = false;
        protected Boolean m_RMB = false;

        // Keyboard
        protected Boolean m_Esc = false;
        protected Boolean m_Tab = false;
        protected Boolean m_End = false;

        protected Boolean m_W   = false;
        protected Boolean m_A   = false;
        protected Boolean m_S   = false;
        protected Boolean m_D   = false;

        protected Boolean m_C   = false;
        protected Boolean m_R   = false;

        protected Boolean m_OB  = false;
        protected Boolean m_CB  = false;


        public GamePadState() 
        {
            InitializeComponent();
        }

        public GamePadState(IContainer container) 
        {
            container.Add(this);

            InitializeComponent();
        }


        protected override void SampleDs3(DsPacket Packet) 
        {
            Int32 Axis;

            base.SampleDs3(Packet);

            // Axis Control : Left Stick -> WASD
            Axis = Packet.Axis(Ds3Axis.LX);

            m_A = Button(m_A, Axis < (Centre - m_Threshold), Keys.A, false);
            m_D = Button(m_D, Axis > (Centre + m_Threshold), Keys.D, false);

            Axis = Packet.Axis(Ds3Axis.LY);

            m_W = Button(m_W, Axis < (Centre - m_Threshold), Keys.W, false);
            m_S = Button(m_S, Axis > (Centre + m_Threshold), Keys.S, false);

            // Mouse Buttons
            m_LMB = Mouse(m_LMB,  Packet.Button(Ds3Button.R2      ), KbmPost.MouseButtons.Left   );   // Attack
            m_MMB = Mouse(m_MMB,  Packet.Button(Ds3Button.L2      ), KbmPost.MouseButtons.Middle );   // Zoom
            m_RMB = Mouse(m_RMB,  Packet.Button(Ds3Button.Circle  ), KbmPost.MouseButtons.Right  );   // Jump

            // Keyboard Buttons
            m_OB  = Button(m_OB,  Packet.Button(Ds3Button.L1      ), Keys.OemOpenBrackets,  false);   // Next
            m_CB  = Button(m_CB,  Packet.Button(Ds3Button.R1      ), Keys.OemCloseBrackets, false);   // Prev

            m_Esc = Button(m_Esc, Packet.Button(Ds3Button.PS      ), Keys.Escape,           false);   // Menu
            m_End = Button(m_End, Packet.Button(Ds3Button.Cross   ), Keys.End,              true );   // Centre View

            m_R   = Button(m_R,   Packet.Button(Ds3Button.Triangle), Keys.R,                false);   // Reload
            m_C   = Button(m_C,   Packet.Button(Ds3Button.Square  ), Keys.C,                false);   // Crouch

            m_Tab = Button(m_Tab, Packet.Button(Ds3Button.Start),    Keys.Tab,              false);   // Open/close PDA
        }

        protected override void SampleDs4(DsPacket Packet) 
        {
            Int32 Axis;

            base.SampleDs4(Packet);

            // Axis Control : Left Stick -> WASD
            Axis = Packet.Axis(Ds4Axis.LX);

            m_A = Button(m_A, Axis < (Centre - m_Threshold), Keys.A, false);
            m_D = Button(m_D, Axis > (Centre + m_Threshold), Keys.D, false);

            Axis = Packet.Axis(Ds4Axis.LY);

            m_W = Button(m_W, Axis < (Centre - m_Threshold), Keys.W, false);
            m_S = Button(m_S, Axis > (Centre + m_Threshold), Keys.S, false);

            // Mouse Buttons
            m_LMB = Mouse(m_LMB,  Packet.Button(Ds4Button.R2      ), KbmPost.MouseButtons.Left   );   // Attack
            m_MMB = Mouse(m_MMB,  Packet.Button(Ds4Button.L2      ), KbmPost.MouseButtons.Middle );   // Zoom
            m_RMB = Mouse(m_RMB,  Packet.Button(Ds4Button.Circle  ), KbmPost.MouseButtons.Right  );   // Jump

            // Keyboard Buttons
            m_OB  = Button(m_OB,  Packet.Button(Ds4Button.L1      ), Keys.OemOpenBrackets,  false);   // Next
            m_CB  = Button(m_CB,  Packet.Button(Ds4Button.R1      ), Keys.OemCloseBrackets, false);   // Prev

            m_Esc = Button(m_Esc, Packet.Button(Ds4Button.PS      ), Keys.Escape,           false);   // Menu
            m_Tab = Button(m_Tab, Packet.Button(Ds4Button.TouchPad), Keys.Tab,              false);   // PDA
            m_End = Button(m_End, Packet.Button(Ds4Button.Cross   ), Keys.End,              true );   // Centre View

            m_R   = Button(m_R,   Packet.Button(Ds4Button.Triangle), Keys.R,                false);   // Reload
            m_C   = Button(m_C,   Packet.Button(Ds4Button.Square  ), Keys.C,                false);   // Crouch
        }


        protected override void Reset() 
        {
            base.Reset();

            m_LMB = Mouse (m_LMB, false, KbmPost.MouseButtons.Left  );
            m_MMB = Mouse (m_MMB, false, KbmPost.MouseButtons.Middle);
            m_RMB = Mouse (m_RMB, false, KbmPost.MouseButtons.Right );

            m_W   = Button(m_W,   false, Keys.W,                false);
            m_A   = Button(m_A,   false, Keys.A,                false);
            m_S   = Button(m_S,   false, Keys.S,                false);
            m_D   = Button(m_D,   false, Keys.D,                false);

            m_OB  = Button(m_OB,  false, Keys.OemOpenBrackets,  false);
            m_CB  = Button(m_CB,  false, Keys.OemCloseBrackets, false);

            m_Esc = Button(m_Esc, false, Keys.Escape,           false);
            m_Tab = Button(m_Tab, false, Keys.Tab,              false);
            m_End = Button(m_End, false, Keys.End,              true );

            m_R   = Button(m_R,   false, Keys.R,                false);
            m_C   = Button(m_C,   false, Keys.C,                false);
        }
    }
}
