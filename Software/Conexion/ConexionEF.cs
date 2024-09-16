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
        //public DbSet<Autores>? Autores { get; set; }
        //public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Categorias>? CATEGORIAS { get; set; }
        public DbSet<Libros>? LIBROS { get; set; }
        //public DbSet<Libro_Autores>? LIBRO_AUTOR { get; set; }
        //public DbSet<Copias>? COPIAS{ get; set; }
        //public DbSet<Prestamos>? PRESTAMOS { get; set; }
        //public DbSet<Detalles>? DETALLES { get; set; 
        }
        

        public void ObtenerLibros()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_libros = conexion.LIBROS.Include(x =>x._Categoria).ToList(); 
            Console.WriteLine( "LISTA LIBROS\n");
            foreach (var Libros in lista_libros)
            {
                Console.WriteLine(
                    Libros.ID.ToString() + "|" +
                    Libros.Cod_Libro + "|" + 
                    Libros.Titulo + "|" + 
                    Libros.Año_Publicacion.ToString() + "|" + 
                    Libros.Estado + "|" + 
                    Libros.Cant_Copias + "|" + 
                    Libros.Categoria + "|" +
                    Libros._Categoria.ID + "|" +
                    Libros._Categoria.Nombre + "|" +
                    Libros._Categoria.Descripcion +
                    "\n"
                    );
            }
        }

        public void ObtenerCategorias()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista_categorias = conexion.CATEGORIAS.ToList();

            Console.WriteLine( "LISTA CATEGORIAS\n");
            foreach (var Categorias in lista_categorias)
            {
                Console.WriteLine(
                    Categorias.ID.ToString() + "|" + 
                    Categorias.Nombre + "|" + 
                    Categorias.Descripcion 
                    + "\n");
            }
        }
    }
}