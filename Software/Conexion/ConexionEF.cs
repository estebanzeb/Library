using Library.Clases;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Conexion
{
    public class ConexionEF
    {
        private string string_conexion = "server=DESKTOP-TRRJJFE;database=LIBRARY;Integrated Security=true;TrustServerCertificate=true;";
        // server=localhost;database=db_facturas;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;
        // server=localhost;database=db_facturas;Integrated Security=True;TrustServerCertificate=true;
        // server=localhost;database=LIBRARY;Integrated Security=True;TrustServerCertificate=true;



        public ConexionEF()
        {
            Console.WriteLine("\n\n\n\n CONEXION ENTITY FRAMEWORK A BASE DE DATOS (usted donde tiene esa terminal parquiada)");
        }

        public partial class Conexion : DbContext
        {
            public string? StringConnection { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//configuracion de la base de datos
            {
                optionsBuilder.UseSqlServer(this.StringConnection!, p => { });//El tipo de base de datos que vamos vincular, "!" no va a ser NULL
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//Instancia de SQL server para la base de datos
            }
            public DbSet<Personas>? PERSONAS { get; set; }
            //public DbSet<Usuarios>? Usuarios { get; set; }
            public DbSet<Libros>? LIBROS { get; set; }
            //public DbSet<Libro_Autores>? LIBRO_AUTOR { get; set; }
            //public DbSet<Copias>? COPIAS{ get; set; }
            //public DbSet<Prestamos>? PRESTAMOS { get; set; }
            //public DbSet<Detalles>? DETALLES { get; set;
            //public DbSet<Autores>? AUTORES { get; set; }
            //public DbSet<Categorias>? CATEGORIAS { get; set; } 
        }
        
        public void ObtenerPersonas(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_personas = conexion.PERSONAS.ToList(); 
            Console.WriteLine( "LISTA PERSONAS\n");
            foreach (var Persona in lista_personas)
            {
                Console.WriteLine(
                    Persona.ID.ToString() + "|" +
                    Persona.Cedula + "|" + 
                    Persona.Nombre + "|" + 
                    Persona.Numero + "|" + 
                    "\n"
                    );
            }
        }
        public void ObtenerLibros(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_libros = conexion.LIBROS.ToList(); 
            Console.WriteLine( "LISTA LIBROS\n");
            foreach (var Libro in lista_libros)
            {
                Console.WriteLine(
                    Libro.ID.ToString() + "|" +
                    Libro.Cod_Libro + "|" + 
                    Libro.Nombre_Libro + "|" + 
                    Libro.Año_Publicacion.ToString() + "|" + 
                    Libro.Autor + "|" + 
                    "\n"
                    );
            }
        }
    }
}