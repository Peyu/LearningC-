#define DIAGNOSTICS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _17_Debug
    {
    }

    #region Creación y administración de directivas de compilacion preprocesadas (preprocessor compiler directives)    
    /*
     El compilador de C# es un programa que toma el codigo fuente, y lo convierte en MSIL que sera almacenado en un archivo assembly.
     Es posible modificar el comportamiento del compilador, asignandole directivas de compilación. Estas sentencias son precedidas por
     numeral #
     */

    #region #if #else #elif, #undefine
    /*
    Una forma de investigar el comportamiento de un programa es agregar código que produzca mensajes de diagnóstico acerca de lo que el
    programa esta haciendo. Esto a veces es llamado "Instrumentación". 
    Es posible utilizat boolean flags para decidir si se produciran los mensjaes de diagnóstico o no. Por ejemplo, el siguiente código 
    contiene un booleano DebugMode que puede ser seteado to true para prodcir mensajes de diagnostico.
    
     */

    //public class MusicTrack
    //{
    //    public static bool DebugMode = false;
    //    public string Artist { get; set; }
    //    public string Title { get; set; }
    //    public int Length { get; set; }
    //    // ToString that overrides the behavior in the base class
    //    public override string ToString()
    //    {
    //        return Artist + " " + Title + " " + Length.ToString() + " seconds long";
    //    }
    //    public MusicTrack(string artist, string title, int length)
    //    {
    //        Artist = artist;
    //        Title = title;
    //        Length = length;
    //        if (DebugMode)
    //        {
    //            Console.WriteLine("Music track created: {0}", this.ToString());
    //        }
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MusicTrack.DebugMode = true;
    //        MusicTrack m = new MusicTrack(artist: "Rob Miles", title: "My Way",
    //        length: 150);
    //        Console.ReadKey();
    //    }
    //}

    /*
     Esto puede parecer muy util, pero tiene la desventaja de que el codigo que genera los mensajes de diagnóstico son shippeados con el
     resto del codigo al momento de compilación.  Una forma de evitar que se compile el codigo con mensajes de diagnótico, es con la utilizaciíon
     de #if y #define

        RECORDAR #DEFINE siempre va en la linea 1 del codigo... mirar arriba! (ctrl+g 1)

        NOTA:  Los symbolos condicionales de compilacion (como por ejemplo el #define) también pueden setearse desde las propiedades
        de una aplicación. VER PAG 296

        NOTA 2:  Por defecto el sistema contiene un symbol de condición de compilacion llamado DEBUG, que se pone en true cuando estamos en 
        debug mode.  Tambien se puede usar eso para asegurarnos de que el codigo de diagnostico no va a ser shippeado en el assembly.

        NOTA3:  Con la misma logica puede usarse #else i #elif

        NOTA 4:  #undefine puede utilizarse para des-definir una variable definida fuera del codigo (Imagino que desde las properties por ej)
     
     */
    //class Program
    //{
    //    public class MusicTrack
    //    {
    //        public static bool DebugMode = false;
    //        public string Artist { get; set; }
    //        public string Title { get; set; }
    //        public int Length { get; set; }
    //        // ToString that overrides the behavior in the base class
    //        public override string ToString()
    //        {
    //            return Artist + " " + Title + " " + Length.ToString() + " seconds long";
    //        }
    //        public MusicTrack(string artist, string title, int length)
    //        {
    //            Artist = artist;
    //            Title = title;
    //            Length = length;
    //            #if DIAGNOSTICS
    //                Console.WriteLine("Music track created: {0}", this.ToString());
    //            #endif
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        MusicTrack.DebugMode = true;
    //        MusicTrack m = new MusicTrack(artist: "Rob Miles", title: "My Way",
    //        length: 150);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Administración de ejecución de métodos con  atributos condicionales
    /*
    Ya se vio en attribute. PAG 297 solo lo refresca. 
    */
    #endregion

    #region #obsolete

    /*
    Clases, interfaces, métodos y atributos, pueden marcarse como Obsolote cuadno existe un método mas adecuado que hace lo mismo.
    Al atributo obsolete se le pasa un booleano que va a definir si el compilador debe enviar un warning (false) o si debe terminar la
    aplicación con un error(true)

    ejemplo de uso:

    [Obsolete ("This method is obsolete. Call NewMethod instead.", false)]
    public string OldMethod()

    */

    #endregion

    #region #warning y #error

    /*
    #warning despliega un warning en la lista de errores de salida
    
    #error sirve para que niegue la ejecucion cuando ciertos condicionales estan presentes. Por ejemplo:
    
    #if DIAGNOSTICS && DEBUG
    #error Cannot run with both diagnostics and debug enabled
    #endif

    */

    #endregion

    #region #pragma warning disable and restore

    /*
    Pag 299
    Se pueden desactivar los mensajes de warning de cierta sección de código con pragma warning disable

    #pragma warning disable
    public async Task<IActionResult> Resume()
    {
        return View();
    }
    #pragma warning restore


    Tambien se pueden desactivar warnings especificos con lo siguiente:

    #pragma warning disable CS1998   

    Y se pueden poner mas de una, separandolas con coma.
     
    */

    #endregion

    #region Identificación de errores con #line 
    /*
    Es posible determinar la linea de codigo hacia la que un mensaje de error va a apuntar cuando se genere una excepcion, con el uso de #line

    Ejemplo:

    static void Exploder()
     {
        #line 1 "kapow.ninja"
        throw new Exception("Bang");
        #line default
     }
    
    Esto va a cambiar el stacktrace que va a mostrar la pagina web si explota.  Esto puede ser confuso, ya que va a ocultar el verdadero error
    que esta largando la compilacion. Pero pede ser util también. Usar con mucho cuidado.


    */
    #endregion

    #region ocultar codigo con #line

    /*
     Es posible especificar el debugger que hay lineas de codigo que no nos interesa debuggear, para que de esa forma las saltee del step by step

    #line hidden
    // The debugger will not step through these statements
    Console.WriteLine("You haven't seen me");
    #line default

     */

    #endregion

    #region ocultar codigo con DebuggerStepThrough
    /*
    
    Tambien es posible saltearse codigo del step by step con el atributo DebuggerStepThrough

    [DebuggerStepThrough]
    public void Update()
    {
     ….
    }

     */

    #endregion

    #region configuration Build

    /*
     Ya hemos visto que el compilador crea #Debug o #release booleans que determinan la forma en que el compilador va a efectuar ciertas tareas.
     Es posible crear mas configuraciones con el Configuration Manager, VER PAG 301
     
     */

    #endregion

    #region Database files

    /*
     VER PAG 304
     */
    #endregion

    #region Symbol servers
    
    /*
     Ver PAG 306
     */
    #endregion



    #endregion
}
