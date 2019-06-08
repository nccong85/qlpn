using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPN
{
    public partial class PrintFrm : Form
    {
        public PrintFrm()
        {
            InitializeComponent();
        }

        private void PrintFrm_Load(object sender, EventArgs e)
        {

            this.prisonListReportViewer.RefreshReport();
        }
    }
}
