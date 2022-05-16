using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServidorMedidorDAL.DTO;

namespace ServidorMedidorDAL.DAL
{
    public class MedidorDALArchivo : IMedidorDAL
    {
        private MedidorDALArchivo()
        {

        }
        private static MedidorDALArchivo instancia;
        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MedidorDALArchivo();
            }
            return instancia;
        }

        private static string archivo = "idMedidor.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;       //ctrl + . para agregar algo
        private static string archivo2 = "medidor.txt";
        private static string ruta2 = Directory.GetCurrentDirectory() + "/" + archivo2;
        public void AgregarMedidor(Medidor medidor)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta2, true))
                {
                    string texto = medidor.NombreMedidor + ";"
                                 + medidor.Fecha + ";"
                                 + medidor.Consumo + ";";
                    writer.WriteLine(texto);
                    writer.Flush();      // confirma que llegaron los datos al .txt
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al escribir en archivo" + ex.Message);
            }

        }


        public List<Medidor> ObtenerMedidor()
        {
            List<Medidor> medidor = new List<Medidor>();
            using (StreamReader reader = new StreamReader(ruta2))
            {
                string texto;
                do
                {
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        string[] textoarr = texto.Trim().Split(';');
                        string nombre = textoarr[0];
                        string fecha = textoarr[1];
                        int consumo = Convert.ToInt32(textoarr[2]);
                        Medidor m = new Medidor()
                        {
                            NombreMedidor = nombre,
                            Fecha = fecha,
                            Consumo = consumo
                        };
                        medidor.Add(m);
                    }

                } while (texto != null);

            }
            return medidor;
        }

        public List<Medidor> FiltrarMedidor(string nombre)
        {
            return ObtenerMedidor().FindAll(p => p.NombreMedidor == nombre);
 
        }


    }
}
