using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prendas
{
    public partial class Form1 : Form
    {
        private List<RegistroPrenda> prendas = new List<RegistroPrenda>();

        public Form1()
        {
            InitializeComponent();
            cboTipoPrenda.Items.Add("Camisa");
            cboTipoPrenda.Items.Add("Pantalón");
            cboTipoPrenda.Items.Add("Vestido");
            cboTipoPrenda.Items.Add("Short");
            cboTipoPrenda.Items.Add("Falda");
            cboTipoPrenda.Items.Add("Chaqueta");
            cboTipoPrenda.Items.Add("Bufanda");
            cboTipoPrenda.Items.Add("Jogger");
            cboTipoPrenda.Items.Add("Jersey");
            cboTipoPrenda.Items.Add("Corset");

            cboMarca.Items.Add("Koaj");
            cboMarca.Items.Add("Tennis");
            cboMarca.Items.Add("Zara");
            cboMarca.Items.Add("Stop");
            cboMarca.Items.Add("Rifle");
            cboMarca.Items.Add("Tommy Hilfiger");
        }
        private void LimpiarCampos()
        {
            cboMarca.SelectedIndex = -1;
            cboTipoPrenda.SelectedIndex = -1;
            txtTalla.Text = "";
            txtPrecio.Text = "";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string marca = cboMarca.SelectedItem.ToString();
            string tipo = cboTipoPrenda.SelectedItem.ToString();
            string talla = txtTalla.Text;
            string precio = txtPrecio.Text;

            RegistroPrenda.Registrar(prendas, marca, tipo, talla, precio);

            dtgTabla.Rows.Add(marca, tipo, talla, precio);

            LimpiarCampos();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Excel|*.xlsx;*.xls";
            openFileDialog.Title = "Seleccionar archivo Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {

                    prendas = RegistroPrenda.Cargar(filePath);
                    dtgTabla.Rows.Clear();

                    foreach (RegistroPrenda prenda in prendas)
                    {
                        dtgTabla.Rows.Add(prenda.Marca, prenda.TipoPrenda, prenda.Talla, prenda.Precio);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
