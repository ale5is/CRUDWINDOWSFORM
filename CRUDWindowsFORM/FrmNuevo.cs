using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWindowsFORM
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
         public FrmNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            PeopleDB oPeopleDB = new PeopleDB();
            PeopleDB.People opeople = oPeopleDB.Get((int)Id);
            txtName.Text = opeople.Name;
            txtEdad.Text = opeople.Age.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                PeopleDB oPeople = new PeopleDB();
                if (Id == null) { 
                oPeople.Add(txtName.Text, Convert.ToInt32(txtEdad.Text));
                }
                else
                {
                    oPeople.Update(txtName.Text, Convert.ToInt32(txtEdad.Text), (int)Id);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}
