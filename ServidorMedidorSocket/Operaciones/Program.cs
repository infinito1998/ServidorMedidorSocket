
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServidorMedidorDAL.DAL;
using ServidorMedidorDAL.DTO;

namespace ServidorMedidorSocket
{
    public partial class Program
    {
        static bool BuscarLectura(string respuesta)
        {
            List<Medidor> filtradas = medidorDAL.FiltrarLectura(respuesta);
            bool codigo=false;
            filtradas.ForEach(p => codigo = true);
            if (codigo)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static void IngresarLectura(Medidor m)
        {
            medidorDAL.AgregarLectura(m);
        }
    }
}
