using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Clases
{
    public abstract class Personas{

        //Atributos
        protected int ID = 0;
        protected int Cedula = 0;
        protected string Nombre_Completo = "";
        protected short Telefono_Celular = 0;
        protected short Telefono_Fijo = 0;
        
                //Propiedades GET y SET
        public int ID1 { get => ID; set => ID = value; }
        public int Cedula1 { get => Cedula; set => Cedula = value; }
        public string Nombre_Completo1 { get => Nombre_Completo; set => Nombre_Completo = value; }
        public short Telefono_Celular1 { get => Telefono_Celular; set => Telefono_Celular = value; }
        public short Telefono_Fijo1 { get => Telefono_Fijo; set => Telefono_Fijo = value; }

        public Personas()
        {
        }
        //Construtor Autores
        public Personas(int iD, string nombre_Completo)
        {
            ID = iD;
            Nombre_Completo = nombre_Completo;
        }
        //Construtor Usuarios
        public Personas(int iD, int cedula, string nombre_Completo,  short telefono_Celular, short telefono_Fijo)
        {
            ID = iD;
            Cedula = cedula;
            Nombre_Completo = nombre_Completo;
            Telefono_Celular = telefono_Celular;
            Telefono_Fijo = telefono_Fijo;
        }


    }
    public class Autores:Personas{

        //Atributos
        private int Cod_Autor = 0;
        private string Seudonimo = "";
        private string Pais_Origen = "";

        //Propiedades GET y SET
        public static int ID { get; }
        public static int Cedula { get; }
        public static string Nombre_Completo { get; }
        public int Cod_Autor1 { get => Cod_Autor; set => Cod_Autor = value; }
        public string Seudonimo1 { get => Seudonimo; set => Seudonimo = value; }
        public string Pais_Origen1 { get => Pais_Origen; set => Pais_Origen = value; }

        //Construtor
        public Autores(int iD, string nombre_Completo,int cod_Autor, string seudonimo, string pais_Origen) : base(iD,nombre_Completo)
        {
            Cod_Autor = cod_Autor;
            Seudonimo = seudonimo;
            Pais_Origen = pais_Origen;
        }



        //Metodos
    }

    public class Usuarios:Personas{


        //Atributos
        private int cedula=0;
        private int Cod_Usuario = 0;
        private bool Estado = false;

        //Construtor
        public Usuarios(){
        }

        public Usuarios(int iD, int cedula, string nombre_Completo, short telefono_Celular, short telefono_Fijo, int cod_Usuario, bool estado) : base (iD,cedula,nombre_Completo,telefono_Celular,telefono_Fijo)
        {
            Cod_Usuario = cod_Usuario;
            Estado = estado;
        }

        //Propiedades GET y SET
        public int Cod_Usuario1 { get => Cod_Usuario; set => Cod_Usuario = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
        //Metodos
    }
    public class Libros{

        //Atributos
        public int ID { get; set; }
        public int Cod_Libro { get; set; }
        public string Titulo { get; set; }
        public DateTime Año_Publicacion{ get; set; }
        public bool Estado { get; set; }
        public int Cant_Copias { get; set; }
        public int Categoria{ get; set; }
        [ForeignKey("Categorias")] public virtual Categorias? _Categoria { get; set; }
        
        //Construtor
        /*public Libros(int iD, int cod_Libro, string titulo, DateTime año_Publicacion, int cant_Copias)
        {
            ID = iD;
            Cod_Libro = cod_Libro;
            Titulo = titulo;
            Año_Publicacion = año_Publicacion;
            Cant_Copias = cant_Copias;
        }*/

        //Propiedades GET y SET


        //Metodos
    }
    public class Categorias{

        //Atributos
        [Key]  public int ID { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
        
        [NotMapped] public virtual ICollection<Libros>? Libros { get; set; }
        //Construtor
        /*public Categorias(int iD, string nombre, string descripcion)
        {
            ID = iD;
            Nombre = nombre;
            Descripcion = descripcion;
        }*/

        //Propiedades GET y SET


        //Metodos
    }
    public class Prestamos
    {
        //Atributos
        private int ID = 0;
        private DateTime Fecha_Incio = DateTime.Now;
        private Usuarios Cod_usuario = null;
        private List<Detalles> Detalles = new List<Detalles>();

        //Construtor
        public Prestamos(int iD, DateTime fecha_Incio, Usuarios cod_usuario)
        {
            ID = iD;
            Fecha_Incio = fecha_Incio;
            Cod_usuario = cod_usuario;
        }

        //Propiedades GET y SET
        public int ID1 { get => ID; set => ID = value; }
        public DateTime Fecha_Incio1 { get => Fecha_Incio; set => Fecha_Incio = value; }
        public Usuarios Cod_usuario1 { get => Cod_usuario; set => Cod_usuario = value; }
        //public List<Detalles> Detalles { get => detalles; set => detalles = value; }

        //Metodos
    }
    public class Copias
    {
        //Atributos
        private int ID = 0;   
        private bool Estado = true;
        private Libros Cod_Libro = null;

        //Construtor
        public Copias(int iD, bool estado, Libros cod_Libros){
            ID = iD;
            Cod_Libro = cod_Libros;
        }

        //Propiedades GET y SET
        public int ID1 { get => ID; set => ID = value; }
        public Libros Cod_Libro1 { get => Cod_Libro; set => Cod_Libro = value; }
        //Metodos
    }
    public class Libro_Autores
    {

        //Atributos
        private Libros ID_Libros = null;
        private Autores ID_Autores = null;

        //Construtor
        public Libro_Autores(Libros iD_Libros, Autores iD_Autores)
        {
            ID_Libros = iD_Libros;
            ID_Autores = iD_Autores;
        }
        //Propiedades GET y SET
        public Libros ID_Libros1 { get => ID_Libros; set => ID_Libros = value; }
        public Autores ID_Autores1 { get => ID_Autores; set => ID_Autores = value; }
    }
    public class Detalles
    {

        //Atributos
        private int ID = 0;
        private DateTime Fecha_Final = DateTime.Now;
        private Copias Copia_Libro = null;
        private Prestamos Pestramo = null;

        //Construtor
        public Detalles(int iD, DateTime fecha_Final, Copias copias, Prestamos pestramo)
        {
            ID = iD;
            Fecha_Final = fecha_Final;
            Copia_Libro = copias;
            Pestramo = pestramo;
        }

        //Propiedades GET y SET
        public int ID1 { get => ID; set => ID = value; }
        public DateTime Fecha_Final1 { get => Fecha_Final; set => Fecha_Final = value; }
        public Copias Copia_Libro1 { get => Copia_Libro; set => Copia_Libro = value; }
        public Prestamos Pestramo1 { get => Pestramo; set => Pestramo = value; }

    }
}  