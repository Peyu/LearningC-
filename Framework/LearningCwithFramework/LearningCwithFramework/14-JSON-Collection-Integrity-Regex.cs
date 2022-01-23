using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LearningCwithFramework
{
    class _14_JSON_Collection_Integrity_Regex
    {
    }

    #region JSON

    /*Info sobre estructura y que es en 237*/

    /*
    La mejor libreria para trabajar con JSON, es la de newtonsoft.
    
    A TENER MUY EN CUENTA:
        - Si se requiere guardar y cargar propiedades privadas, se deben marcar con el atributo [JsonProperty]
        - No se necesita la interfaz [Serializable] para Serializar.
        - Cuando se va a cargar una clasa desde un JSON es necesario especificar el tipo. La propiedad Lenght de MuscTrack de
        nuestro ejemplo se convertira automaticamente en in int. Deserializer determina el tipo utilizando reflection.
        -No hay ninguna forma de garantizar que el contenido de un Json no ha sido alterado antes de volver a formar un objeto. De ser
        necesario chequear la integridad, es necesario agregar algún tipo de CHECKSUM o HASH. Ver encriptacion mas adelante.

     
    */
    //class Program
    //{
    //    class MusicTrack
    //    {
    //        public string Artist { get; set; }
    //        public string Title { get; set; }
    //        public int Length { get; set; }
    //        // ToString that overrides the behavior in the base class
    //        public override string ToString()
    //        {
    //            return Artist + " " + Title + " " + Length.ToString() + "seconds long";
    //        }
    //        public MusicTrack(string artist, string title, int length)
    //        {
    //            Artist = artist;
    //            Title = title;
    //            Length = length;
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        MusicTrack track = new MusicTrack(artist: "Rob Miles", title: "My Way",
    //        length: 150);
    //        string json = JsonConvert.SerializeObject(track);
    //        Console.Write("JSON: ");
    //        Console.WriteLine(json);
    //        MusicTrack trackRead = JsonConvert.DeserializeObject<MusicTrack>(json);
    //        Console.Write("Read back: ");
    //        Console.WriteLine(trackRead);
    //        List<MusicTrack> album = new List<MusicTrack>();
    //        string[] trackNames = new[] { "My Way", "Your Way", "Their Way", "The Wrong Way" };
    //        foreach (string trackName in trackNames)
    //        {
    //            MusicTrack newTrack = new MusicTrack(artist: "Rob Miles",
    //            title: trackName, length: 150);
    //            album.Add(newTrack);
    //        }
    //        string jsonArray = JsonConvert.SerializeObject(album);
    //        Console.Write("JSON: ");
    //        Console.WriteLine(jsonArray);
    //        List<MusicTrack> albumRead = JsonConvert.DeserializeObject<List<MusicTrack>>
    //        (jsonArray);
    //        Console.WriteLine("Read back: ");
    //        foreach (MusicTrack readTrack in albumRead)
    //        {
    //            Console.WriteLine(readTrack);
    //        }
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region XML

    /* e la misma forma que lo hicimos con JSON, es posible serializar y deserializar objetos XML, aunque es un proceso un poco mas
     pesado.
     
     A TENER EN CUENTA:
        - XML serialization solo puede guardar y cargar propiedades publicas. Si se necesitan serializar propiedades privadas
        habria que usar  Data Contract serializer (No se que es eso, pero dice que se ve en chapter 4)
        - Para que funcione la serilizacion la clase debe tener un constructor vacio.
        - XML deserialization devuelve una referencia a una clase, necesita ser casteada al tipo correcto.
        - XML documents, tienen adjunto un esquema (schema) que contiene los items que un documento debe contener para ser válido.
        Los esquemas pueden utilizarse para validar automáticamente el esquema de un documento. 
        ( https://docs.microsoft.com/en-us/dotnet/standard/data/xml/reading-and-writing-xml-schemas)
        - Los elementos de un documento XML, ademas de las propiedades, puede contener atributos. Por ejemplo la propiedad length
        del ejemplo, podria tener un atributo que especifique que es un int. y que representa segundos.

     */

    //public class MusicTrack
    //{
    //    public string Artist { get; set; }
    //    public string Title { get; set; }
    //    public int Length { get; set; }
    //    // Parameterless constructor required by the XML serializer

    //    public MusicTrack()
    //    {
    //    }
    //    public MusicTrack(string artist, string title, int length)
    //    {
    //        Artist = artist;
    //        Title = title;
    //        Length = length;
    //    }

    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MusicTrack track = new MusicTrack(artist: "Rob Miles", title: "My Way",
    //        length: 150);
    //        XmlSerializer musicTrackSerializer = new XmlSerializer(typeof(MusicTrack));
    //        TextWriter serWriter = new StringWriter();
    //        musicTrackSerializer.Serialize(textWriter: serWriter, o: track);
    //        serWriter.Close();
    //        string trackXML = serWriter.ToString();
    //        Console.WriteLine("Track XML");
    //        Console.WriteLine(trackXML);
    //        TextReader serReader = new StringReader(trackXML);
    //        MusicTrack trackRead =
    //        musicTrackSerializer.Deserialize(serReader) as MusicTrack;
    //        Console.Write("Read back: ");
    //        Console.WriteLine(trackRead);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Eligiendo la colección correcta
    /*
    Esto tambien se verá (Imagino que con mayor profundidad) en el siguiente capitulo
    
    Queue -> Cuando necesitamos una cola.
    Stack -> cuando necesitamos una Pila.
    array -> Cuando necesitamos un índice y conocemos de antemano el número de elementos.
    List<T> -> Cuando necesitamos un índice y no conocemos el número de elementos.
    LinkedList<T> -> Si se necesitan realizar multiples inserciones y eliminaciones de elementos. No tiene índice, pero es enumerable
    (https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1)

    IComparable -> Si se necesita tener los elementos en cierto orden, se puede agregar el metodo Compareto() a los objetos,
    hacerlos implementar IComparable y luego utilizar una List, que tiene el método sort. 
    Dictionary<TKey,TValue> -> Cuando se necesita un diccionario de tipo clave-valor (también conocido como array asociativo)
    
    TODO OBJETO QUE IMPLEMETE IEnumerable O IQueryable<T> PUEDE SER ACCEDIDO MEDIANTE LINQ QUERY.
    
    IQueryable es más eficiente que IEnumerable ya que filtra los resultados desde la base de datos. 
     
    */



    #endregion

    #region integridad
    /* Pag 246 a 253 tiene info de como crear un proyecto, que a proposito no funciona porque no especifica como configuarar la Bd*/

    #region Integridad en la llamada a Metodos
    /*
    Pag 254 

    Basicamente esta seccion dice que a la hora de llamar a un metodo que reciba una referencia a un objeto, hay que considerar en vez de
    pasarle el objeto real, una copia.  De esta manera el metodo tiene alguna sentencia maliciosa, se va a ejecutar sobre una copia que
    no va a alterar el objeto original.

    Tener en cuenta que se puede copiar un objeto de forma deep copy (copiando cada uno de los obejtos dentro del objeto) o
    haciendo una shallow copy (pasando la referencia de objetos dentro del objeto).  Obviamente la shalow copy tiene los mismos
    problemas de integridad.

    Obviamente también, es preferible usar acciones atomicas a la hora de guardar datos dentro de un objeto. Guardaer el 
    nombre de un artista con un metodo y el apellido en otro metodo, puede crear un objeto incompleto si alguna de las dos falla.
    */



    #endregion

    #region regex 

    // Algunos simbolos de regex
    /*
    . -> Cualquier caracter
    + -> uno o mas del caracter anterior
    .+ -> Matchearia cualquier cosa que tenga un caracter o mas
     .+:.+:.+  ->  cualquier cantidad de caracteres seguido de : cualquier cant caracteres seguido de : cuaquier cant de caracteres
     [ch - ch]  -> matchea cualquier cosa en el rango de ch a ch. Ejemplo [0-9], [a-z]
     [0-9]+  -> marchea con uno o mas numeros entre 0 y 9
     $ -> El caracter que precede este simbolo va a estar al final del string.  Ejemplo [0-9].$  cualquier caracter al final, un solo caracter,no numero
     @ -> no consifera lo que viene adelante como caracter de escape.
     ^ -> El comienzo del string
     | -> or

        Ejemplo de todo:   
        string regexToMatch = @"^([a-z]|[A-Z]| )+:([a-z]|[A-Z]| )+:[0-9]+$";

        Comienza con cualquier numero de caracteres mayor a uno, entre la a y la z, mayuscula o minuscula, seguido de :
        cualquier numero de caracteres mayor a uno, entre la a y la z, mayuscula o minuscula, seguido de :
        cualquier cantidad de numeros (mas de uno) entre 0 y 9 y un caracter final.
        (https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expressions.)
    */

    //Pag 256 
    #region regex Replace
    /*
    Los objetos regex cuentan con un método Replace, con el cual se puede reemplazar cualquier substring que matchee con la expresion. 
    
        El metodo IsMatch devuelve true cuando matchea.

         
    */

    //class Program {

    //    static void Main(string[] args) {
    //        string input = "Rob Mary David Jenny Chris Imogen Rodney";
    //        string regularExpressionToMatch = " +";
    //        string patternToReplace = ",";
    //        string replaced = Regex.Replace(input, regularExpressionToMatch, patternToReplace);
    //        Console.WriteLine(replaced);

    //        Console.WriteLine("Otro ejemplo de regex");
    //        string input2 = "Rob Miles:My Way:120";
    //        string regexToMatch = ".+:.+:.+";
    //        if (Regex.IsMatch(input2, regexToMatch))
    //            Console.WriteLine("Valid music track description");
    //        Console.ReadKey();


    //    }

    //}



    #endregion




    #endregion

    #region TryParse

    /*
     Nada demasaido nuevo aqui, pero no conocia esa forma de cambiar el contenido de una variable con "out"

     */
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int result;
    //        if (int.TryParse("99", out result))
    //            Console.WriteLine("This is a valid number");
    //        else
    //            Console.WriteLine("This is not a valid number");

    //        Console.WriteLine("Lo que contiene result es {0}", result);
    //        Console.ReadKey();
    //    }
    //}
    /*
     Sin ganas de traducir...
    *    int.Parse will throw an exception if the supplied argument is null or if a string does not
        contain text that represents a valid value.
    •	 int.TryParse will return false if the supplied argument is null or if a string does not
        contain text that represents a valid value.
    •	 Convert.ToInt32 will throw an exception if the supplied string argument does not
        contain text that represents a valid value. It will not, however, throw an exception if
        the supplied argument is null. It instead returns the default value for that type. If the
        supplied argument is null the ToInt32 method returns 0.
     
     */

    #endregion


    #endregion




}
