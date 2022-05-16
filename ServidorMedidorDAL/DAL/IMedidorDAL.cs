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
        void AgregarMedidor(Medidor medidor);

        List<Medidor> ObtenerMedidor();
        List<Medidor> FiltrarMedidor(string nombre);
        
    }
}
