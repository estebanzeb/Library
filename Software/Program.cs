using ConsoleApp.Conexion;
/*using Clases;//Instaciamos todas las clases

Usuarios user = new Usuarios(1,1231321312,"esteba",1234,123,001,true);
Autores au= new Autores(1,"adsvs",0011,"ja","Medellpin");
//Libros lib = new Libros(123, 32312312, "dsvs",DateTime(1999,1,1),12);

Console.WriteLine(user.Cedula1);
Console.WriteLine(au.Cedula1);*/


var conexionEF = new ConexionEF();
//conexionEF.GuardarPeliculas();
conexionEF.ObtenerCategorias();
conexionEF.ObtenerLibros();
