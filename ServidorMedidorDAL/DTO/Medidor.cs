using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMedidorDAL.DTO
{
    public class Medidor
    {
        private string nombreMedidor;
        private string fecha;
        private int consumo;

        public string NombreMedidor { get => nombreMedidor; set => nombreMedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Consumo { get => consumo; set => consumo = value; }
        public override string ToString()
        {
            return "iDMedidor : "+nombreMedidor + ", Consumo en KW: " + consumo + ", Fecha : " + fecha;
        }
    }

}
