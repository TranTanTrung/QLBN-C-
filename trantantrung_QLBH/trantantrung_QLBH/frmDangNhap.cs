using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace trantantrung_QLBH
{
    public partial class frmDangNhap : Form
    {
        public static SqlConnection con;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.trantantrung123;
            try
            {
                con.Open();
                string tk = txtMaNhanVien.Text.Trim().ToString();
                string mk = txtTenNhanVien.Text.Trim().ToString();
                string sql = "Select *From TKNHANVIEN WHERE TENTK=N'" + tk + "' and MATKHAU= N'" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                if(dta.Read() == true) 
                {
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
