using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;
using PosSystem.Model;
using System.Data.Entity;
using System.Drawing;

namespace PosSystem
{
    public partial class Main : Form
    {
        private readonly DbModel _context;

        public Main()
        {
            InitializeComponent();
            _context = new DbModel();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        void PopulateDataGridView()
        {
            StockListGrid.DataSource = _context.ProductMasters.Include(c => c.ProductDetails).
                Select(s => new { s.Id, s.ItemName, s.ProductCatagory.CatagoryName, s.Unit, s.UnitValue, s.ProductDetails.Quantity,
                    s.ProductDetails.PurchasePrice, s.ProductDetails.SalePrice, s.ProductDetails.StockEntryDate, s.ProductDetails.ExpireDate }).ToList();
        }

        private void StockListGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
