using System;
using System.Windows.Forms;
using System.ComponentModel;

using ScpControl;
using ScpControl.Utilities;

namespace GtaMapper 
{
    public partial class GamePadState : ScpPadState 
    {
        protected Boolean m_MouseButtons = false, m_Cheats = false, m_ViceCity = false;

        // Macro Definitions
        protected Keys[] m_Guns;
        protected Keys[] m_HP;
        protected Keys[] m_Armor;
        protected Keys[] m_Police;

        protected Keys[] m_GT_Guns   = { Keys.G, Keys.U, Keys.N, Keys.S, Keys.G, Keys.U, Keys.N, Keys.S, Keys.G, Keys.U, Keys.N, Keys.S, };
        protected Keys[] m_GT_HP     = { Keys.G, Keys.E, Keys.S, Keys.U, Keys.N, Keys.D, Keys.H, Keys.E, Keys.I, Keys.T, };
        protected Keys[] m_GT_Armor  = { Keys.T, Keys.O, Keys.R, Keys.T, Keys.O, Keys.I, Keys.S, Keys.E, };
        protected Keys[] m_GT_Police = { Keys.N, Keys.O, Keys.P, Keys.O, Keys.L, Keys.I, Keys.C, Keys.E, Keys.P, Keys.L, Keys.E, Keys.A, Keys.S, Keys.E, };

        protected Keys[] m_VC_Guns   = { Keys.P, Keys.R, Keys.O, Keys.F, Keys.E, Keys.S, Keys.S, Keys.I, Keys.O, Keys.N, Keys.A, Keys.L, Keys.T, Keys.O, Keys.O, Keys.L, Keys.S, };
        protected Keys[] m_VC_HP     = { Keys.A, Keys.S, Keys.P, Keys.I, Keys.R, Keys.I, Keys.N, Keys.E, };
        protected Keys[] m_VC_Armor  = { Keys.P, Keys.R, Keys.E, Keys.C, Keys.I, Keys.O, Keys.U, Keys.S, Keys.P, Keys.R, Keys.O, Keys.T, Keys.E, Keys.C, Keys.T, Keys.I, Keys.O, Keys.N, };
        protected Keys[] m_VC_Police = { Keys.L, Keys.E, Keys.A, Keys.V, Keys.E, Keys.M, Keys.E, Keys.A, Keys.L, Keys.O, Keys.N, Keys.E, };

        // Mouse
        protected Boolean m_LMB = false;
        protected Boolean m_RMB = false;

        // Keyboard
        protected Boolean m_Esc = false;
        protected Boolean m_PgU = false;
        protected Boolean m_PgD = false;
        protected Boolean m_Ins = false;

        // Macro
        protected Boolean m_MaU = false;
        protected Boolean m_MaR = false;
        protected Boolean m_MaD = false;
        protected Boolean m_MaL = false;


        public Boolean MouseButtons 
        {
            get { return m_MouseButtons; }
            set { lock (this) { m_MouseButtons = value; } }
        }

        public Boolean Cheats 
        {
            get { return m_Cheats; }
            set { lock (this) { m_Cheats = value; } }
        }

        public Boolean ViceCity 
        {
            get { return m_ViceCity; }
            set 
            {
                lock(this)
                {
                    m_ViceCity = value;

                    if (m_ViceCity)
                    {
                        m_Guns   = m_VC_Guns;
                        m_HP     = m_VC_HP;
                        m_Armor  = m_VC_Armor;
                        m_Police = m_VC_Police;
                    }
                    else
                    {
                        m_Guns   = m_GT_Guns;
                        m_HP     = m_GT_HP;
                        m_Armor  = m_GT_Armor;
                        m_Police = m_GT_Police;
                    }
                }
            }
        }


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
            base.SampleDs3(Packet);

            if (m_MouseButtons)
            {
                m_LMB = Mouse(m_LMB, Packet.Button(Ds3Button.R1), KbmPost.MouseButtons.Left );
                m_RMB = Mouse(m_RMB, Packet.Button(Ds3Button.L1), KbmPost.MouseButtons.Right);
            }

            m_Esc = Button(m_Esc, Packet.Button(Ds3Button.PS), Keys.Escape,   false);
            m_PgU = Button(m_PgU, Packet.Button(Ds3Button.R2), Keys.PageUp,   true );
            m_PgD = Button(m_PgD, Packet.Button(Ds3Button.L2), Keys.PageDown, true );

            if (m_Cheats)
            {
                m_MaU = Macro(m_MaU, Packet.Button(Ds3Button.Up   ), m_Guns  );
                m_MaL = Macro(m_MaL, Packet.Button(Ds3Button.Left ), m_HP    );
                m_MaR = Macro(m_MaR, Packet.Button(Ds3Button.Right), m_Armor );
                m_MaD = Macro(m_MaD, Packet.Button(Ds3Button.Down ), m_Police);
            }
        }

        protected override void SampleDs4(DsPacket Packet) 
        {
            base.SampleDs4(Packet);

            if (m_MouseButtons)
            {
                m_LMB = Mouse(m_LMB, Packet.Button(Ds4Button.R1), KbmPost.MouseButtons.Left );
                m_RMB = Mouse(m_RMB, Packet.Button(Ds4Button.L1), KbmPost.MouseButtons.Right);
            }

            m_Esc = Button(m_Esc, Packet.Button(Ds4Button.PS      ), Keys.Escape,   false);
            m_PgU = Button(m_PgU, Packet.Button(Ds4Button.R2      ), Keys.PageUp,   true );
            m_PgD = Button(m_PgD, Packet.Button(Ds4Button.L2      ), Keys.PageDown, true );
            m_Ins = Button(m_Ins, Packet.Button(Ds4Button.TouchPad), Keys.Insert,   true );

            if (m_Cheats)
            {
                m_MaU = Macro(m_MaU, Packet.Button(Ds4Button.Up   ), m_Guns  );
                m_MaL = Macro(m_MaL, Packet.Button(Ds4Button.Left ), m_HP    );
                m_MaR = Macro(m_MaR, Packet.Button(Ds4Button.Right), m_Armor );
                m_MaD = Macro(m_MaD, Packet.Button(Ds4Button.Down ), m_Police);
            }
        }


        protected override void Reset() 
        {
            base.Reset();

            m_LMB = Mouse (m_LMB, false, KbmPost.MouseButtons.Left );
            m_RMB = Mouse (m_RMB, false, KbmPost.MouseButtons.Right);

            m_Esc = Button(m_Esc, false, Keys.Escape,   false);
            m_PgU = Button(m_PgU, false, Keys.PageUp,   true );
            m_PgD = Button(m_PgD, false, Keys.PageDown, true );
            m_Ins = Button(m_Ins, false, Keys.Insert,   true );

            m_MaU = Macro (m_MaU, false, m_Guns  );
            m_MaL = Macro (m_MaL, false, m_HP    );
            m_MaR = Macro (m_MaR, false, m_Armor );
            m_MaD = Macro (m_MaD, false, m_Police);
        }
    }
}
