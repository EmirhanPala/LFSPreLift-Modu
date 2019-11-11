using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SharpUpdate;

namespace LFSPreLift
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        private SharpUpdater updater;

        public Form1()
        {
            InitializeComponent();
            updater = new SharpUpdater(this);
            updater.DoUpdate();
        }

        #region SharpUpdate
        public string ApplicationName
        {
            get { return "LFSPreLift"; }
        }

        public string ApplicationID
        {
            get { return "LFSPreLift"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri("http://www.emirhanpala.com.tr/forum/guncelleme/prelift.xml"); }
        }

        public Form Context
        {
            get { return this; }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            PreLift_6H PreLift6H = new PreLift_6H();
            this.Hide();
            PreLift6H.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PreLift_6J PreLift6J = new PreLift_6J();
            this.Hide();
            PreLift6J.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PreLift_6M PreLift6M = new PreLift_6M();
            this.Hide();
            PreLift6M.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PreLift_6R PreLift6R = new PreLift_6R();
            this.Hide();
            PreLift6R.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
