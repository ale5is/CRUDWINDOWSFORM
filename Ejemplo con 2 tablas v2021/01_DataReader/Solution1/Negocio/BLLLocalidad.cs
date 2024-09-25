using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
   public class BLLLocalidad
    {

        #region "Propiedades"
        //propiedades de Localidad

        public int Codigo { get; set; }
        public string Localidad { get; set; }


        #endregion

        //Metodos de la clase Localidad

        #region "Metodos"

        public override string ToString()
        {
            return Codigo + " " + Localidad;
        }

        public List<BLLLocalidad> CargarListaLocalidades()
        {  //instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            return oDatos.LeerLocalidades();
        }

        public bool Existe_Localidades_Asociadas(BLLLocalidad oLoc)
        {
            //instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            return oDatos.Existe_Localidades_Asociadas(oLoc);
        }

      public int AltaLoc(BLLLocalidad oLoc)
        {//instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            return oDatos.AltaLocalidad(oLoc);
        }

        public int ModifLoc(BLLLocalidad oLoc)
        {//instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            return oDatos.ModificarLocalidad(oLoc);
        }

      public  int BajaLoc(BLLLocalidad oLoc)
        {  //instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            if (oLoc.Existe_Localidades_Asociadas(oLoc) == false)
            { return oDatos.BajaLocalidad(oLoc); }
            else
                return 0;

        }

        #endregion
    }
}
