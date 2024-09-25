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
    public partial class frAlumno : Form
    {
        public frAlumno()
        {
            InitializeComponent();
            //instancio los objetos en el constructor del formulario
            oBLLAlu = new BLLAlumno();
            oBLLLoc= new BLLLocalidad();
            oBEAlu = new BEAlumno();
            oBELoc = new BELocalidad();


        }

        BLLAlumno oBLLAlu;
        BLLLocalidad oBLLLoc;
        BEAlumno oBEAlu;
        BELocalidad oBELoc;
        private void frAlumno_Load(object sender, EventArgs e)
        {
            CargarComboLocalidad();
            CargarGrilla();
        }


        //cargo el combo localidad
        void CargarComboLocalidad()
        {
             comboBox1.DataSource = null;
            //llamo al metodo  de la BLL para cargar Localidades que me devuelve una lista
            comboBox1.DataSource = oBLLLoc.CargarListaLocalidades();
            //aclaro cual es el valor y lo que se desea mostrar en el combo
            comboBox1.ValueMember = "Codigo";
            //la variable publica de la clase
            comboBox1.DisplayMember = "Localidad";
            comboBox1.Refresh();
        }

        void CargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            //llamo al metodo cargar alumnos de Alumno que me devuelve una lista
            this.dataGridView1.DataSource = oBLLAlu.CargarListaAlumnos();
            //propiedad de la grilla para autosize de columnas
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //cambio color alternando las filas de la grilla
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
            //cambio el nombre de la columna oLocalidad x Localidad
            this.dataGridView1.Columns["oBELocalidad"].HeaderText = "Localidad";
        }
        //Asigno los valores al objeto
        void Asignar()
        {
            try
            {
                oBEAlu.Codigo = Convert.ToInt32(textcod.Text); 
                oBEAlu.Nombre = textNombre.Text;
                oBEAlu.Apellido = textApe.Text;
                oBEAlu.DNI = Convert.ToInt32(txtDNI.Text);
                oBEAlu.FechaNac = this.dateTimePicker1.Value;
                oBEAlu.Edad = oBEAlu.Calcular_Edad();
                oBEAlu.oBELocalidad = (BELocalidad)this.comboBox1.SelectedItem;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        // metodo limpiar
        void Limpiar()
        {
            textNombre.Text = null;
            textApe.Text = null;
            textEdad.Text = null;
            txtDNI.Text = null;
            textcod.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creo un objeto de la BLL para acceder al metodo
            BLLPrueba oPrueba = new BLLPrueba();
       
            //uso el metodo testconnection que me dice el estado de la conexion., Y USO EL CONSTRUCTOR DE MessageBox
            MessageBox.Show(oPrueba.TestCX(),"PROBANDO",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                oBEAlu.Nombre = textNombre.Text;
                oBEAlu.Apellido = textApe.Text;
                oBEAlu.DNI = Convert.ToInt32(txtDNI.Text);
                oBEAlu.FechaNac = this.dateTimePicker1.Value;
                oBEAlu.Edad = oBEAlu.Calcular_Edad();
                oBEAlu.oBELocalidad = (BELocalidad)this.comboBox1.SelectedItem;
                oBLLAlu.AltaAlumno(oBEAlu);
                CargarGrilla();
                Limpiar();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            oBEAlu = (BEAlumno)this.dataGridView1.CurrentRow.DataBoundItem;
            textcod.Text = oBEAlu.Codigo.ToString();
            textNombre.Text = oBEAlu.Nombre;
            textApe.Text = oBEAlu.Apellido;
            txtDNI.Text = oBEAlu.DNI.ToString();
            textEdad.Text = oBEAlu.Edad.ToString();
            comboBox1.Text = oBEAlu.oBELocalidad.Localidad;
            this.dateTimePicker1.Value = oBEAlu.FechaNac;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                oBLLAlu.ModifAlumno(oBEAlu);
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
                Respuesta = MessageBox.Show("¿Confirma la eleminación del Alumno?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    oBLLAlu.BajaAlumno(oBEAlu);
                    CargarGrilla();
                    Limpiar();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
