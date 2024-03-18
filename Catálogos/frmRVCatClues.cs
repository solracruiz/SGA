using MaterialSkin;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Catálogos
{
    public partial class frmRVCatClues : Form
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        string filtro = "";
        public frmRVCatClues()
        {
            InitializeComponent();
            
        }

        private void frmRVCatClues_Load(object sender, EventArgs e)
        {
            filtro = this.Tag.ToString();
            conn.AbrirBD();

            DataTable dt = new DataTable();

            string consulta = "select * from cat_clues where id>0 " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvClues.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsClues", dt);
            rvClues.LocalReport.DataSources.Add(rp);

            rvClues.RefreshReport();
            conn.cerrarBd();
        }

/*
            conn1.AbrirBD();
            cbxMunicipios.DisplayMember = "jurisdiccion";
            cbxMunicipios.ValueMember = "jurisdiccion";
            cbxMunicipios.DataSource = conn1.GetTable("select distinct jurisdiccion from cat_clues");
            //cbxMunicipios.Items.Add("TODOS");
            conn1.cerrarBd();
            cbxMunicipios.Text ="TODOS";
            //this.rvClues.RefreshReport();
        }

        private void cbxMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (cbxMunicipios.Text!="TODOS")
            {
                filtro = " where jurisdiccion='" + cbxMunicipios.Text + "'";
            }

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cat_clues " + filtro, conn.PropertyConexion);
            da.Fill(dt);

            rvClues.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsClues", dt);
            rvClues.LocalReport.DataSources.Add(rp);
            rvClues.RefreshReport();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }*/
    }
}
