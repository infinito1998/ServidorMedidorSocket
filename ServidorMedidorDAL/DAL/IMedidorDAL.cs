using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServidorMedidorDAL.DTO;

namespace ServidorMedidorDAL.DAL
{
    public interface IMedidorDAL
    {
        void AgregarLectura(Medidor medidor);

        List<Medidor> ObtenerLectura();
        List<Medidor> FiltrarLectura(string nombre);
        
    }
}
