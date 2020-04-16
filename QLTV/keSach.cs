﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class keSach : UserControl
    {
        public keSach()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themKeSach n = new themKeSach();
            n.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            keSach_Load(sender, e);
        }

        private void keSach_Load(object sender, EventArgs e)
        {
            //đổ dữ liệu ra bảng
            var adap = new SqlDataAdapter(@"select * from Ke", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;

            //đổ dữ liệu ra box
            txtMaKe.DataBindings.Clear();
            txtMaKe.DataBindings.Add("text", dataGridView1.DataSource, "MaKe");
            txtChatLieu.DataBindings.Clear();
            txtChatLieu.DataBindings.Add("text", dataGridView1.DataSource, "ChatLieu");
            txtSucChua.DataBindings.Clear();
            txtSucChua.DataBindings.Add("text", dataGridView1.DataSource, "SLChua");
            txtSLSach.DataBindings.Clear();
            txtSLSach.DataBindings.Add("text", dataGridView1.DataSource, "SLSach");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Q1 = "Bạn có muốn thay đổi dữ liệu này";
            DialogResult result = MessageBox.Show(Q1,"Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(@"update Ke set MaKe = '" + txtMaKe.Text + "',ChatLieu = N'" + txtChatLieu.Text + "',SLChua='" + txtSucChua.Text + "',SLSach='" + txtSLSach.Text + "' where MaKe='"+txtMaKe.Text+"'", Form1.conn);
                Form1.conn.Open();
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Đã cập nhật mới!!");
            }
            keSach_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Q1 = "Bạn có muốn xóa";
            DialogResult result = MessageBox.Show(Q1, "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(@"delete from Ke where MaKe = '"+txtMaKe.Text+"'", Form1.conn);
                Form1.conn.Open();
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Đã xóa!!");
                
            }
            keSach_Load(sender, e);
        }
    }
}
