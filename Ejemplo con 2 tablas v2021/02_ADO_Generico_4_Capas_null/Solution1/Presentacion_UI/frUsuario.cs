using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using BE;


namespace Presentacion_UI
{
    public partial class frUsuario : Form
    {
        public frUsuario()
        {
            InitializeComponent();
            oBLLusu = new BLLUsuario();
            oBEusu = new BEUsuario();
        }

        BLLUsuario oBLLusu;
        BEUsuario oBEusu;

        private void frAlumno_Load(object sender, EventArgs e)
        {
             CargarGrilla();
        }


        void CargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo cargar usuario de BLLUsuario que me devuelve una lista
            this.dataGridView1.DataSource = oBLLusu.CargarListaUsuarios();
            //propiedad de la grilla para autosize de columnas
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //cambio color alternando las filas de la grilla
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
   
        }
        //Asigno los valores al objeto
        void Asignar()
        {
            try
            {               
                oBEusu.Codigo = Convert.ToInt32(textcod.Text); 
                oBEusu.Nombre = textNombre.Text;
                oBEusu.Apellido = textApe.Text;
                oBEusu.Usuario = textmail.Text;
                oBEusu.Psw = textpsw.Text;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        // metodo limpiar
        void Limpiar()
        {
            textNombre.Text = null;
            textApe.Text = null;
            textmail.Text = null;
             textcod.Text = null;
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                oBEusu.Nombre = textNombre.Text;
                oBEusu.Apellido = textApe.Text;
              //  oBEusu.Usuario = textmail.Text;
                //oBEusu.Psw = textpsw.Text;
                oBLLusu.Guardar(oBEusu);
                CargarGrilla();
                Limpiar();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            oBEusu = (BEUsuario)this.dataGridView1.CurrentRow.DataBoundItem;
            textcod.Text = oBEusu.Codigo.ToString();
            textNombre.Text = oBEusu.Nombre;
            textApe.Text = oBEusu.Apellido;
            textmail.Text = oBEusu.Usuario;
            textpsw.Text = oBEusu.Psw;
     
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                oBLLusu.Guardar(oBEusu);
                CargarGrilla();
                Limpiar();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void BtnELiminar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                DialogResult Respuesta;
                Respuesta = MessageBox.Show("¿Confirma la eleminación del Usuario?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBLLusu.BajaUsuario(oBEusu);
                    CargarGrilla();
                    Limpiar();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
