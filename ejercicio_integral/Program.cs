using System.Xml;

namespace ejercicio_integral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputadoraVirtual[] maquinas = new ComputadoraVirtual[4];

            maquinas[0] = new ProcesoDeDatos("DataProc1", "1.0", "Linux","db_source_1", "db_dest_1");
            maquinas[1] = new ProcesoDeDatos("DataProc2", "1.0", "Linux","db_source_2", "db_dest_2");
            maquinas[2] = new Aplicacion("App1", "2.1", "Windows","Python", "3.10", "postgres://db1.example.com");
            maquinas[3] = new Aplicacion("App2", "2.1", "Windows","Node.js", "18", "mongodb://db2.example.com");

            Console.WriteLine("=== Levantar máquinas virtuales ===");
            foreach(var compu in maquinas)
            {
                compu.levantar();
            }


            Console.WriteLine("\n=== Bajar todas las máquinas virtuales ===");
            foreach (var compu in maquinas)
            {
                compu.bajar();
            }

            Console.WriteLine("\n=== Procesos Finalizados ===");

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
                    Console.WriteLine($"{this.nombre} ha sido bajada, Estado: {this.estado}");

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
                    Console.WriteLine($"Proceso {this.nombre} levantado correctamente, datos de origen almacenados:{this.datosDeOrigen}, datos de fin almacenados: {this.datosDeFin}, Estado: {this.estado}");
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
