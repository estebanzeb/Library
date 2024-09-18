using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Clases
{
    public class Personas{
        //Atributos y Propiedades GET y SET
        public int ID { get; set; }
        public int? Cedula { get; set; }//string? "NOT NULL"
        public string? Nombre { get; set; }
        public int Numero { get; set; }
    }

    /*public class Autores:Personas{

        //Atributos y Propiedades GET y SET
        public int? Cod_Autor { get; set; }
        public string Seudonimo { get; set; }
        public string Pais_Origen { get; set; }
    }*/

    public class Usuarios{
        //Atributos y Propiedades GET y SET
        public int? Cod_Usuario{ get; set; }
        public int? Correo{ get; set; }
        public int? Contraseña{ get; set; }
        public int Persona { get; set; }[ForeignKey("Persona")] public virtual Personas? _Persona { get; set; } 
    }

    /*public class Categorias{

        //Atributos y Propiedades GET y SET
        [Key]  public int ID { get; set; }
        public string? Nombre{ get; set; }
        public string Descripcion{ get; set; }
        
        [NotMapped] public virtual ICollection<Libros>? Libros { get; set; }
    }*/

    public class Libros{
        //Atributos, ForeignKey y Propiedades GET y SET
        public int ID { get; set; }
        public int? Cod_Libro { get; set; }
        public string? Nombre_Libro{ get; set; }
        public DateTime Año_Publicacion{ get; set; }
        public string Autor { get; set; }
    }

   /* public class Libro_Autor
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        public int Libro{ get; set; } [ForeignKey("Libro")] public virtual Libros? _Libro { get; set; }
        public int Autor{ get; set; } [ForeignKey("Autor")] public virtual Autores? _Autor { get; set; }    
    }*/

        public class Copias{
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }   
        private string Notas { get; set; }
        private bool Estado { get; set; }
        private int Libro { get; set; }  [ForeignKey("Libro")] public virtual Libros? _Libro { get; set; }
    }

    public class Prestamos{
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }
        private DateTime? Fecha_Incio { get; set; }
        private int Usuario  { get; set; } [ForeignKey("Usuario")] public virtual Usuarios? _Usuario { get; set; }
    }

    public class Detalles
    {
        //Atributos, ForeignKey y Propiedades GET y SET
        private int ID { get; set; }
        private DateTime? Fecha_Final{ get; set; }
        private int Prestamo  { get; set; } [ForeignKey("Prestamo")] public virtual Prestamos? _Prestamo { get; set; }
        private int Copia  { get; set; } [ForeignKey("Copia")] public virtual Copias? _Copia { get; set; }
    }
}  