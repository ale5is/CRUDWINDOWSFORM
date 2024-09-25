using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
//hago referencia a la capa de negocio
using Negocio;

namespace Presentacion_UI
{
    public partial class frLocalidad : Form
    {
        public frLocalidad()
        {
            InitializeComponent();
            //intanacio el objeto en el constructor del form
            oBLLLoc = new BLLLocalidad();
            oBELoc = new BELocalidad();
        }

      
        private void FrLocalidad_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }


        BLLLocalidad oBLLLoc;
        BELocalidad oBELoc;

        void CargarGrilla()
        {
      
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLLoc.CargarListaLocalidades();
            //propiedad de la grilla para autosize de columnas
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //cambio color alternando las filas de la grilla
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkOrange;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            oBELoc = (BELocalidad)this.dataGridView1.CurrentRow.DataBoundItem;
            textcod.Text = oBELoc.Codigo.ToString();
            textNombre.Text = oBELoc.Localidad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                oBELoc.Localidad = textNombre.Text;
                oBLLLoc.Guardar(oBELoc);
                //actualizo nuevamente la grilla para que refresque los cambios
                CargarGrilla();
                //limpio los texbox
                Limpiar();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }


        //Asigno los valores al objeto
        void Asignar()
        {    
            oBELoc.Codigo = Convert.ToInt32(textcod.Text); 
            oBELoc.Localidad = textNombre.Text;
            
        }

        void Limpiar()
        {
            textcod.Text = string.Empty;
            textNombre.Text = null;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                //antes de eliminar voy a confirmar 
                DialogResult Respuesta;
                 Respuesta= MessageBox.Show("¿Confirma la eleminación de la Localidad?", "ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                  if(Respuesta == DialogResult.Yes)
                    {

                    
                  if (oBLLLoc.Baja(oBELoc)== false)
                    {MessageBox.Show("Para dar de baja la Localidad no debe estar asociada a nignún ALumno");}
                   else
                    {
                    //actualizo nuevamente la grilla para que refresque los cambios
                    CargarGrilla();
                    //limpio los texbox
                     Limpiar();
                    }
             
                }
                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            try
            {
                Asignar();
                oBLLLoc.Guardar(oBELoc);
                //actualizo nuevamente la grilla para que refresque los cambios
                CargarGrilla();
                //limpio los texbox
                Limpiar();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

    }
    
 }

