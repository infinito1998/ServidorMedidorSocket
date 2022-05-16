using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServidorMedidorDAL.DAL;
using ServidorMedidorDAL.DTO;
using ServidorMedidorSocket.HebraCom;
using ServidorMedidorSocket.Operaciones;
using ServidorSocketUtils;

namespace ServidorMedidorSocket
{
    public partial class Program
    {
        private static IMedidorDAL medidorDAL = MedidorDALArchivo.GetInstancia();
        static bool Menu()
        {
            ServerSocket1 serverSocket1 = new ServerSocket1();
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer?");
            Console.WriteLine("1. Ingresar \n 2. Mostrar \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "0":
                    serverSocket1.Desconectar();
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }

        //Carlos Vallejos - Diego Ulloa
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();

            while (Menu()) ;




        }
        static void Ingresar()
        {
            
            Console.WriteLine("Ingrese Numero de medidor: ");
            string idMedidor = Console.ReadLine().Trim();
            Console.WriteLine("Numero de Medidor: {0}", idMedidor);
            Console.WriteLine("Ingrese Cantidad KiloWatts: ");
            int cKiloWatts = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("KiloWatts Consumidos: {0}", cKiloWatts);
            Console.WriteLine("Ingrese Día de Consumo: ");
            string fecha = Console.ReadLine().Trim();
            Console.WriteLine("Día de Consumo: {0}", fecha);
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
                Console.WriteLine("Agregado Correctamente");
                
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }
        }
        static void Mostrar()
        {
            List<Medidor> medidores = null;
            lock (medidorDAL)
            {
                medidores = medidorDAL.ObtenerMedidor();
            }
            foreach (Medidor medidor in medidores)
            {
                Console.WriteLine(medidor);
            }
        }
    }
}
