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
            Console.WriteLine("\n\n CONEXION ENTITY FRAMEWORK A BASE DE DATOS (usted donde tiene esa terminal parquiada)\n");
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
            public DbSet<Usuarios>? USUARIOS { get; set; }
            public DbSet<Libros>? LIBROS { get; set; }
            public DbSet<Copias>? COPIAS { get; set; }
            public DbSet<Prestamos>? PRESTAMOS { get; set; }
            public DbSet<Detalles>? DETALLES { get; set; }
            //public DbSet<Autores>? AUTORES { get; set; }
            //public DbSet<Categorias>? CATEGORIAS { get; set; } 
            //public DbSet<Libro_Autores>? LIBRO_AUTOR { get; set; }
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
        public void ObtenerUsuarios(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_usuarios = conexion.USUARIOS.Include(x => x._Persona).ToList(); 
            Console.WriteLine( "LISTA USUARIOS\n");
            foreach (var Usuario in lista_usuarios)
            {
                Console.WriteLine(
                    Usuario.Cod_Usuario.ToString() + "|" +
                    Usuario.Correo + "|" + 
                    Usuario.Contraseña + "|" + 
                    Usuario._Persona.ID.ToString() + "|" +
                    Usuario._Persona.Cedula + "|" + 
                    Usuario._Persona.Nombre + "|" + 
                    Usuario._Persona.Numero + "|" +  
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
                    Libro.Fecha_Publicacion.ToString("dddd dd,(M) MMMM,yyyy") + "|" + 
                    Libro.Autor + "|" + 
                    "\n"
                    );
            }
        }
        public void ObtenerCopias(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_copias = conexion.COPIAS.Include(x => x._Libro).ToList(); 
            Console.WriteLine( "LISTA COPIAS\n");
            foreach (var Copia in lista_copias)
            {
                Console.WriteLine(
                    Copia.ID + "|" +
                    Copia.Notas + "|" + 
                    Copia.Estado + "|" + 
                    Copia._Libro.Cod_Libro.ToString() + "|" +
                    Copia._Libro.Nombre_Libro + "|" + 
                    Copia._Libro.Fecha_Publicacion.ToString("dddd dd,(M) MMMM,yyyy") + "|" + 
                    Copia._Libro.Autor + "|" +  
                    "\n"
                    );
            }
        }
        public void ObtenerPrestamo(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_prestamos = conexion.PRESTAMOS.Include(x =>x._Usuario._Persona).ToList(); 
            Console.WriteLine( "LISTA PRESTAMOS\n");
            foreach (var Prestamo in lista_prestamos)
            {
                Console.WriteLine(
                    Prestamo.ID.ToString() + "|" +
                    Prestamo.Fecha_Inicio.ToString("dddd dd,(M) MMMM,yyyy") + "|" +
                    Prestamo._Usuario._Persona.ID + "|" +
                    Prestamo._Usuario._Persona.Cedula + "|" +
                    Prestamo._Usuario._Persona.Nombre + "|" + 
                    Prestamo._Usuario._Persona.Numero + "|" +    
                    Prestamo._Usuario.Cod_Usuario + "|" + 
                    Prestamo._Usuario.Correo + "|" + 
                    "\n"
                    );
            }
        }
        public void ObtenerDetalles(){
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;
            
            var lista_detalles = conexion.DETALLES.Include(x =>x._Copia._Libro).Include(x =>x._Prestamo._Usuario._Persona).ToList(); 
            Console.WriteLine( "LISTA DETALLES\n");
            foreach (var Detalle in lista_detalles)
            {
                Console.WriteLine(
                    Detalle.ID.ToString() + "|" +
                    Detalle.Fecha_Final.ToString("dddd dd,(M) MMMM,yyyy") + "|" +
                    Detalle._Copia.Notas + "|" +
                    Detalle._Copia.Estado + "|" +
                    Detalle._Copia._Libro.Cod_Libro + "|" +
                    Detalle._Copia._Libro.Nombre_Libro + "|" +
                    Detalle._Prestamo._Usuario._Persona.Cedula + "|" +
                    Detalle._Prestamo._Usuario._Persona.Nombre + "|" +
                    Detalle._Prestamo._Usuario._Persona.Numero + "|" +
                    Detalle._Prestamo._Usuario.Cod_Usuario + "|" +
                    Detalle._Prestamo._Usuario.Correo + "|" +
                    "\n"
                    );
            }
        }
    }
}