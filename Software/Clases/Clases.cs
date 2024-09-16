using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Clases
{
    public abstract class Personas{

        //Atributos y Propiedades GET y SET
        protected int ID { get; set; }
        protected int Cedula { get; set; }
        protected string Nombre_Completo { get; set; }
        protected short Celular { get; set; }
        protected short Fijo { get; set; }

    }
    public class Autores:Personas{

        //Atributos y Propiedades GET y SET
        private int Cod_Autor { get; set; }
        private string Seudonimo { get; set; }
        private string Pais_Origen { get; set; }
    }

    public class Usuarios:Personas{

        //Atributos y Propiedades GET y SET
        private int cedula{ get; set; }
        private int Cod_Usuario{ get; set; }
        private bool Estado { get; set; }
    }

    public class Categorias{

        //Atributos y Propiedades GET y SET
        [Key]  public int ID { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
        
        [NotMapped] public virtual ICollection<Libros>? Libros { get; set; }
    }

    public class Libros{

        //Atributos, ForeignKey y Propiedades GET y SET
        public int ID { get; set; }
        public int Cod_Libro { get; set; }
        public string Titulo { get; set; }
        public DateTime Año_Publicacion{ get; set; }
        public bool Estado { get; set; }
        public int Cant_Copias { get; set; }
        public int Categoria{ get; set; } [ForeignKey("Categoria")] public virtual Categorias? _Categoria { get; set; }   
    }

    public class Libro_Autor
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        public int Libro{ get; set; } [ForeignKey("Libro")] public virtual Libros? _Libro { get; set; }
        public int Autor{ get; set; } [ForeignKey("Autor")] public virtual Autores? _Autor { get; set; }    
    }

        public class Copias
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }   
        private string Notas_Estado { get; set; }
        private int Libro { get; set; }  [ForeignKey("Libro")] public virtual Libros? _Libro { get; set; }
    }

    public class Prestamos
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }
        private DateTime Fecha_Incio { get; set; }
        private int Usuario  { get; set; } [ForeignKey("Usuario")] public virtual Usuarios? _Usuario { get; set; }
    }

    public class Detalles
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }
        private DateTime Fecha_Final{ get; set; }
        private int Prestamo  { get; set; } [ForeignKey("Prestamo")] public virtual Prestamos? _Prestamo { get; set; }
        private int Copia  { get; set; } [ForeignKey("Copia")] public virtual Copias? _Copia { get; set; }
    }
}  