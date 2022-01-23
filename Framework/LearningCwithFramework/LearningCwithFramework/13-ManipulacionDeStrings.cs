using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _13_ManipulacionDeStrings
    {
    }

    #region  El tipo string

    /*
    Teoricamente un string puede albergar hasta 2GB de texto. Sin embargo en la práctica es menos que eso.
    Los strings son inmutables, lo que significa que cada vez que se modifica, lo que realmente hae es crear un
    nuevo string. Esto asegura que los string sean thread safe. Esto puede ser un problema si se editan muchas 
    cadenas de texto, ya que van a quedar muchos objetos inalcanzables. 
    Sin embargo, el tipo StringBuilder provee un string mutable. Lo veremos más adelante.
    */

    #region string intering

    /*
    Cuando un programa se compila utiliza un proceso llamado string interning para mejorar la eficiencia de los string.
    Ya habiamos explicado que cuando se crea un string va a parar a una coleccion, y si existe otro string igual, se usa
    una referencia hacia el mismo objeto. Esta coleccion de string se crea al momento de compilacion, si en cambio, tengo
    un string que es por ejemplo el resultado de una concatenacion. Ese string va a tener un valor recien cuando se 
    concatene, es decir, en tiempo de ejecucion. Es posible agregar ese string a la coleccion mediante Intern

    string h1 = "he";
    string h2 = "llo";
    string s3 = h1 + h2;
    s3 = string.Intern(s3);

    Igualmente, esto no es recomendable, a menos que se haya detectado un problema en el perfomance de strings, lo cual
    seria muy raro, en casos sumamente particulares.

    */

    #endregion

    #endregion

    #region StringBuilder

    /*
    El tipo StringBuilder es muy util cuando se escriben programas que crean strings. Puede mejorar la velocidad y ademas
    ahorrarle trabajo al recolector de basura. La idea de este tipo es que provee un string mutable, es decir, no se va a 
    crear un nuevo objeto si lo modificamos, lo que es mejor para el recolector.

    */

    //class Program {

    //    static void Main(string[] args) {

    //        StringBuilder fullNameBuilder = new StringBuilder();
    //        fullNameBuilder.Append("Nombre");
    //        fullNameBuilder.Append(" ");
    //        fullNameBuilder.Append("Apellido");
    //        Console.WriteLine(fullNameBuilder.ToString());
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region StringWriter
    /*
    StringWriter esta basado en StringBuilder. Implementa la interfaz TextWriter, lo que permite que los programas enviar su
    output a un string. Ejemplo:
    */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        StringWriter writer = new StringWriter();
    //        writer.WriteLine("Hello World");
    //        writer.WriteLine("Bye Bye cruel World");
    //        writer.Close();
    //        Console.Write(writer.ToString());
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region StringReader
    /*
    Pag 211
    StringReader implementa la inetrfaz TextReader, que es una forma conveniente de obtener un input string que un programa
    necesita leer desde un stream. Notar en el ejemplo que cada linea,se guarda en distinta variable.
    */
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string dataString = @"Rob Miles
    //        21";
    //        StringReader dataStringReader = new StringReader(dataString);
    //        string name = dataStringReader.ReadLine();
    //        int age = int.Parse(dataStringReader.ReadLine());
    //        dataStringReader.Close();
    //        Console.WriteLine("Name: {0} Age: {1}", name, age);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Busqueda en  strings

    /*
    C# provee de una variedad de métodos que permiten buscar dentro de un string. Se iran viendo más abajo. Tener en cuenta que
    los strings son inmutables, eso hace que una operacino replace, no reemplaza realmente, sino que crea un nuevo string.
    */

    #region Contains
    /*Pag 212 - Nada nuevo*/
    #endregion

    #region StartsWith y EndsWith (Tambien TrimStart, TrimEnd y Trim)

    /*
    Pag 212
    Estos métodos solo funcionan cuando los string en los que se esta aplicando no comienzan con un espacio en blanco.
    Los Metodos TrimStart, TrimEnd, y Trim, se usan para remover los espacios en blanco de adelante, de atras o de adelante y
    atras respectivamente.
    */

    #endregion

    #region IndexOf y SubString

    /*
    El método IndexOf devuelve el un int, que es la posicion de la primera aparicion del caracter que se esta buscando. 
    LastIndexOf, devuelve la ultima ocurrencia. Hay sobrecargas de estos métodos que permiten establecer el caracter inicial
    de la busqueda. Esto se puede utilizar para con el método SubString para extraer una porcion de texto.
    */

    //class Program {
    //    static void Main(string[] args) {
    //        string input = " Rob Miles";
    //        int nameStart = input.IndexOf("Rob");
    //        string name = input.Substring(nameStart, 3);
    //        Console.Write(name);
    //        Console.ReadKey();
    //    }
    //}

    #endregion






    #endregion

    #region Replace
    /*
    Pag 213 nada nuevo
    */
    #endregion

    #region Split

    /*
    Pag 213 - Nada nuevo
    */

    #endregion

    #region String comparison and cultures
    /*
    Dependiendo de la cultura, el simbolo "ae" , puede ser distinto o no de las dos letras a e.  Se puede especificar que cultura
    usar en la comparacion
    */
    //class Program {
    //    static void Main(string[] args) {
    //        // Default comparison fails because the strings are different
    //        if (!"encyclopædia".Equals("encyclopaedia"))
    //            Console.WriteLine("Unicode encyclopaedias are not equal");
    //        // Set the curent culture for this thread to EN-US
    //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
    //        // Using the current culture the strings are equal
    //        if ("encyclopædia".Equals("encyclopaedia", StringComparison.CurrentCulture))
    //            Console.WriteLine("Culture comparison encyclopaedias are equal");
    //        // We can use the IgnoreCase option to perform comparisions that ignore case
    //        if ("encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.CurrentCultureIgnoreCase))
    //            Console.WriteLine("Case culture comparison encyclopaedias are equal");
    //        if (!"encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.OrdinalIgnoreCase))
    //            Console.WriteLine("Ordinal comparison encyclopaedias are not equal");
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region Format strings

    /*
    El método WriteLine recibe un string que puede tener placeholders definidos por {}. Dentro del placeholder, el primer numero
    hace referencia a la variable a la que se refiere (seria el numero del orden del que aparece), luego una coma, y el numero de
    lugares que debe ocupar (si es numero negativo, se usa justificado), luego : y va la informacion de formato. La informacion
    puede ser D para un decimal, X para hexagesimal, N para floatin point, y el ultimo numero es la cantidad de decimales.
    */

    //class Program {
    //    static void Main(string[] args) {
    //        int i = 99;
    //        double pi = 3.141592654;
    //        Console.WriteLine(" {0,-10:D}{0, -10:X}{1,5:N2}", i, pi);
    //        Console.WriteLine(" {0,10:D}{0, 10:X}{1,-5:N2}", i, pi);
    //        Console.Read();
    //    }

    //}

    /*
    Es posible pasarle format string a varios tipos de  dato de .net  DateTime acepta un monton de formatos pr ejemplo. 
    Cualquier clase que implemente la interfaz IFormattable, tiene un metodo ToString(), que puede utilizarse con format strings.
    Ejemplo:
    */
    //class Program
    //{
    //    class MusicTrack : IFormattable
    //    {
    //        string Artist { get; set; }
    //        string Title { get; set; }
    //        // ToString that implements the formatting behavior
    //        public string ToString(string format, IFormatProvider formatProvider)  //<-- Ver mas abajo
    //        {
    //            // Select the default behavior if no format specified
    //            if (string.IsNullOrWhiteSpace(format))
    //                format = "G";
    //            switch (format)
    //            {
    //                case "A": return Artist;
    //                case "T": return Title;
    //                case "G": // default format
    //                case "F": return Artist + " " + Title;
    //                default:
    //                    throw new FormatException("Format specifier was invalid.");
    //            }
    //        }
    //        // ToString that overrides the behavior in the base class
    //        public override string ToString()
    //        {
    //            return Artist + " " + Title;
    //        }
    //        public MusicTrack(string artist, string title)
    //        {
    //            Artist = artist;
    //            Title = title;
    //        }
    //    }

    //    static void Main(string[] args){

    //        MusicTrack song = new MusicTrack(artist: "Rob Miles", title: "My Way");
    //        Console.WriteLine("Track: {0:F}", song);
    //        Console.WriteLine("Artist: {0:A}", song);
    //        Console.WriteLine("Title: {0:T}", song);
    //        Console.ReadKey();

    //    }
    //}

    /*
     El segundo parametro es un objeto que implmenta IFormatProvider, en caso de que no se especifique, c# interpreta que hay que usar el 
     culture del Thread.Current  

    En caso de querer enviar un IFormatProvider, hay que hacer algo asi:

    double bankBalance = 123.45;
    CultureInfo usProvider = new CultureInfo("en-US");
    Console.WriteLine("US balance: {0}", bankBalance.ToString("C", usProvider));
    CultureInfo ukProvider = new CultureInfo("en-GB");
    Console.WriteLine("UK balance: {0}", bankBalance.ToString("C", ukProvider));
     */


    #endregion

    #region String Interpolation

    /*
    En linea 306 de abajo el numero dentro del placeholder hace referencia al orden en que aparecen las vaiables.
    En linea 307, se usa el nombre de la variable, esto es string interpolation, y necesita que adelante del string vaya el $
    */

    //class Program {
    //    static void Main(string[] args) {

    //        string name = "Rob";
    //        int age = 21;
    //        Console.WriteLine("Your name is {0} and your age is {1,-5:D}", name, age);
    //        Console.WriteLine($"Your name is {name} and your age is {age,-5:D}", name, age);
    //        Console.ReadKey();
    //    }

    //}

    #endregion

}
