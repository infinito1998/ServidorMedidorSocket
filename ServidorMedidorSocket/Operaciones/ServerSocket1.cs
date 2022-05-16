using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMedidorSocket.Operaciones
{
    internal class ServerSocket1
    {
        private Socket cliente;
        private StreamReader reader;
        private StreamWriter writer;
        

        //<CR><LF>
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Desconectar()
        {
            try
            {   
                    // error de instancia. pero es como nos eneseñó
                    this.cliente.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
