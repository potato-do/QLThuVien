﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class thanhVien : UserControl
    {
        public thanhVien()
        {
            InitializeComponent();
        }

        private void btnThemMoiThanhVien_Click(object sender, EventArgs e)
        {
            themThanhVien themMoi = new themThanhVien();
            themMoi.Show();
        }
    }
}
