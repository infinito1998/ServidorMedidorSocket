using System;
using System.Collections.Generic;
using ServidorMedidorDAL.DAL;
using ServidorMedidorDAL.DTO;
using ServidorSocketUtils;

namespace ServidorMedidorSocket.HebraCom
{
    class HebraCliente
    {
        private static IMedidorDAL medidorDAL = MedidorDALArchivo.GetInstancia();
        private ClienteCom clienteCom;

        public HebraCliente(ClienteCom clienteCon)
        {
            this.clienteCom = clienteCon;
        }

        static bool BuscarMedidor(string respuesta)
        {
            List<Medidor> filtradas = medidorDAL.FiltrarMedidor(respuesta);
            bool codigo = false;
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
        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese Numero de medidor: ");
            string idMedidor = clienteCom.Leer();
            
            clienteCom.Escribir("Ingrese Cantidad KiloWatts: ");
            int cKiloWatts = Convert.ToInt32(clienteCom.Leer());
            
            clienteCom.Escribir("Ingrese Día de Consumo: ");
            string fecha = clienteCom.Leer();
            
            bool Confirmar = BuscarMedidor(idMedidor);
            if (Confirmar)
            {
                Medidor m = new Medidor()
                {
                    NombreMedidor = idMedidor,
                    Fecha = fecha,
                    Consumo = cKiloWatts
                };
                lock (medidorDAL)
                {
                    medidorDAL.AgregarMedidor(m);
                }
                Console.WriteLine("Numero de Medidor: {0}", idMedidor);
                Console.WriteLine("KiloWatts Consumidos: {0}", cKiloWatts);
                Console.WriteLine("Día de Consumo: {0}", fecha);
                Console.WriteLine("Agregado Correctamente");
                clienteCom.Escribir("OK ");
                clienteCom.Desconectar();
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
                clienteCom.Escribir("Error al Ingresar el Medidor. ");
                clienteCom.Desconectar();
            }
        }
    }
}
