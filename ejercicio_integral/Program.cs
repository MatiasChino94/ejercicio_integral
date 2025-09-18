using System.Xml;

namespace ejercicio_integral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        class ComputadoraVirtual
        {
            public string? nombre;
            public string? version;
            public string? sistemaOperativo;
            public string estado = "down";

            public ComputadoraVirtual()
            {

            }

            public ComputadoraVirtual(string nombre, string version, string sistemaOperativo)
            {
                this.nombre = nombre;
                this.version = version; 
                this.sistemaOperativo = sistemaOperativo;
            }

            public virtual void levantar()
            {
                if(this.estado == "down")
                {
                    this.estado = "up";
                }
                else
                {
                    Console.WriteLine($"{this.nombre} ya se encuentra levantado correctamente");
                }
            }

            public void bajar()
            {
                if (this.estado == "up")
                {
                    this.estado = "down";
                    Console.WriteLine($"{this.nombre} ha sido bajada.");

                }
                else
                {
                    Console.WriteLine($"{this.nombre} ya se encuentra bajada correctamente.");
                }
            }
                

        }

        class ProcesoDeDatos : ComputadoraVirtual
        {
            public string? datosDeOrigen;
            public string? datosDeFin;

            public ProcesoDeDatos()
            {

            }

            public ProcesoDeDatos(string nombre, string version, string sistemaOperativo, string datosDeOrigen, string datosDeFin) : base(nombre, version, sistemaOperativo)
            {
               this.datosDeOrigen = datosDeOrigen;
               this.datosDeFin = datosDeFin;    
            }

            public override void levantar()
            {
                if (this.estado == "down")
                {
                    this.estado = "up";
                    Console.WriteLine($"Proceso {this.nombre} levantado correctamente, datos de origen almacenados:{this.datosDeOrigen}, datos de fin almacenados: {this.datosDeFin}");
                }
                else
                {
                    Console.WriteLine($"{this.nombre} ya se encuentra levantado correctamente");
                }
            }

        }

        class Aplicacion : ComputadoraVirtual
        {
            public string? lenguaje;
            public string? versionLenguaje;
            public string? baseDeDatos;

            public Aplicacion()
            {

            }

            public Aplicacion(string nombre, string version, string sistemaOperativo, string lenguaje, string versionLenguaje, string baseDeDatos) : base(nombre, version, sistemaOperativo)
            {
                this.lenguaje = lenguaje;
                this.versionLenguaje = versionLenguaje;
                this.baseDeDatos = baseDeDatos;

            }


            public override void levantar()
            {
                if (this.estado == "down")
                {
                    this.estado = "up";
                    Console.WriteLine($"Lenguaje: {this.lenguaje}, version: {this.versionLenguaje} intalado correctamente, acceso : {this.baseDeDatos}, Estado: {this.estado}");
                }
                else
                {
                    Console.WriteLine("ya se encuentra levantado correctamente");
                }
            }


        }


        
    }
}
