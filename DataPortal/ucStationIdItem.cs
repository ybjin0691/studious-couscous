using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace MyClubB.DataPortal
{
    public partial class ucStationIdItem : UserControl
    {
        private string StationId { get; set; }
        public event EventHandler<string> StationIdChanged;

        public ucStationIdItem(string stationName, string stationId)
        {
            InitializeComponent();

            lblStationName.Text = stationName;
            lblStationId.Text = stationId;
            StationId = stationId;
        }

        private void ListBackground(bool isFlag)
        {
            if (isFlag)
            {
                pnList.BackColor = Color.WhiteSmoke;
                this.Cursor = Cursors.Hand;
            }
            else
            {
                pnList.BackColor = Color.White;
                this.Cursor = Cursors.Default;
            }
        }

        private void lblStationName_MouseHover(object sender, EventArgs e)
        {
            ListBackground(true);
        }

        private void lblStationName_MouseLeave(object sender, EventArgs e)
        {
            ListBackground(false);
        }

        private void lblStationId_MouseHover(object sender, EventArgs e)
        {
            ListBackground(true);
        }

        private void lblStationId_MouseLeave(object sender, EventArgs e)
        {
            ListBackground(false);
        }

        private void lblStationId_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(StationId);
            StationIdChanged?.Invoke(this, this.StationId);
        }

        private void lblStationName_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(StationId);
            StationIdChanged?.Invoke(this, this.StationId);
        }
    }
}
