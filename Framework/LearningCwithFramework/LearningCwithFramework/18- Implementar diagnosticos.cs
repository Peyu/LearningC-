using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _18__Implementar_diagnosticos
    {
    }

    #region Debug y Trace clases
    /*
    El espacio de nombres System.Diagnostics contiene las clases Debug y Trace que se utilizan para tracear la ejecución de un programa.Estas clases
    contienen métodos con los que se puede tracear un programa en ejecución. WriteLineIf escribe un mensage de debug si cierta condicion se cumple.    
    */

    //El mensaje que genera esto se va a ver en la ventana output o salida de vs
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Debug.WriteLine("Starting the program");
    //        Debug.Indent();
    //        Debug.WriteLine("Inside a function");
    //        Debug.Unindent();
    //        Debug.WriteLine("Outside a function");
    //        string customerName = "Rob";
    //        Debug.WriteLineIf(string.IsNullOrEmpty(customerName), "The name is empty");
    //    }
    //}

    /*
    Si el programa no esta compilado en modo debug, el mensaje no se mostrará.  Para que se muestre en produccion se debe hacer lo mismo,
    pero con el objeto Trace, en lugar de Debug.
    Trace contiene tambien los métodos TraceInformation, TraceWarning y TraceError.

    */



    #endregion

    #region Assertion en Debug y Trace
    /*
    Un "assert" es un statmente que uno hace creyendo que va a ser true.  Por ejemplo "El usuario nunca va a ser null"
    Debug.Assert puede chequear que las assertions tengan el resultado esperado. Tambien existe para Trace.
    Si el resultado de la assertion es true, todo bien, si da false se le pregunta al usuario si se desea continuar.
    */

    //class Program {
    //    public static void Main(string[] args) {
    //        string customerName = "Rob";
    //        Debug.Assert(!string.IsNullOrWhiteSpace(customerName));
    //        customerName = "";
    //        Debug.Assert(!string.IsNullOrWhiteSpace(customerName));
    //    }

    //}

    #endregion

    #region Utilización de listeners para extracción de informacion de tracing.

    /*
    Por defecto, las clases Debug y Trace envian su salida (output) a la ventana "salida" o "output" de visual studio. Esto es útil
    durante el desarrollo, pero una vez en producción no tiene sentido. Un programa puede adjuntar objetos listeners a Debug o Trace
    para que servian como destino de los mensajes de tracing.
    
    En el ejemplo se adjunta una instancia de ConsoleTraceListener a la coleccion de objetos listener que acepta los outputs de la clase
    Trace. Cuando este programa se ejecuta los mensajes también se despliegan en la consola.
    */

    //class Program {
    //    static void Main(string[] args) {
    //        TraceListener consoleListener = new ConsoleTraceListener();
    //        Trace.Listeners.Add(consoleListener);
    //        Trace.TraceInformation("This is an information message");
    //        Trace.TraceWarning("This is a warning message");
    //        Trace.TraceError("This is an error message");
    //    }
    //}


    /*
    Tipos de traceListener:

    ConsoleTraceListener Sends the output to the console.
    DelimitedTextTraceListener Sends the output to a TextWriter
    EventLogTraceListener Sends the output to the Event log
    EventSchemaTraceListener Sends the output to an XML encoded file compliant with the Event log schema
    TextWriterTraceListener Sends the output to a given TextWriter
    XMLWriterTraceListener Sends XML formatted output to an XML writer


    
    */

    #endregion

    #region Traceo utilizando la clase TradeSource

    /*
     * PAG 311 
    Debug y Trace nos proporcionan una forma de tracear a través de mensajes. Si queremos administrar una solución más completa, podemos
    utilizar la clase TradeSource.

    Una instancia de la clase TradeSource creará eventos que pueden ser utilizados como trazas para los programas.

    En el ejemplo se crean cuatro eventos. El mas simple contiene el tipo de evento y el número. Se puede también agregar un texto en un
    string y ademas el método TraceData nos permite agregar información a un evento en forma de coleccion de referncias de objeto.

    //*/
    //class Program {
    //    static void Main(string[] args)
    //    {
    //        TraceSource trace = new TraceSource("Tracer", SourceLevels.All);
    //        trace.TraceEvent(TraceEventType.Start, 10000);
    //        trace.TraceEvent(TraceEventType.Warning, 10001);
    //        trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
    //        trace.TraceData(TraceEventType.Information, 1003, new object[] { "Note 1", "Message 2" });
    //        trace.Flush();
    //        trace.Close();

    //    }
    //}

    /*
     A cada evento se le asgina un tipo y un número. El número es solo in integer que identifica al evento. Cuando se diseña el tracing en la
     aplicación se puede determinar que rango de valores va a significar que Por ejemplo: del 1 al 100 errores de red. 

     Hay un rango de tipos de evento que son especificados por valor del enum TraceEventType. Estos eventos son, por orden de gravedad:

        - Stop, Start, Suspend, Reasume, Transfer:  Son eventos de actividad. No significan que algo salio mal. Solo que algo paso.

        -Verbose: Eventos que proporcionan información detallada de alguna actividad del sistema. Esto puede icluir mensajes de cuando
        se entra o sale de metodos, cuando se construyen o destruyen objetos, y muchas cosas cas

        - Information: Proporcionan información significativa sobre la ejecución normal del programa.

        -Warning: Indican un evento de warning. un login que fallo, una operación que tardó más tiempo del esperado, una trasnacción determinada
        que comenzó o terminó, bajos recursos de memoria.

        -Error: Indica patapufs...

        -Critical:  Indica un patapuf en donde la aplicación alcanza un estado de donde no puede salir. Tal vez una excepción no controlada

        A menos que se especifique lo contrario, los eventos serán enviados a la ventana de output, pero se le puede agregar un tracelistener
        para enviarlo a cualquier otro lugar.
     */


    #endregion

    #region Utilizar Traceswitch para controlar la salida del traceo 
    /*
    El objeto TraceSwitch contiene una propiedad Level que se puede setear para determinar el nivel del output del traceo. 

    En el ejemplo se crea una instancia de TraceSwitch llamada control y se setea el nivel en "Warning". Esta variable es luego utilizada
    para cntrolar el output del traceo: primero hacia la consola, y luego hacia la clase Trace. Tener en cuenta que el nivel de control
    setea el valor base. es decir que los mensajes de error tambien se enviaran, ya que son mayores que el nivel de warning.

    */

    //class Program {

    //    static void Main(string[] args) {

    //        TraceSwitch control = new TraceSwitch("Control", "Control the trace output");
    //        control.Level = TraceLevel.Warning;
    //        if (control.TraceWarning) //<-- devuelve un bool si acepta ese tipo de errores. 
    //        {
    //            Console.WriteLine("An error has occurred");
    //        }
    //        Trace.WriteLineIf(control.TraceWarning, "A warning message");
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region Utilizar SourceSwitch para controlar el traceo
    /*
    Sourceswitch puede utilizarse para controlar el comportamiento de un objeto TraceSource. Funciona de la misma forma que TraceSwitch
    */

    ////class Program {
    ////    static void Main(string[] args) {
    ////        TraceSource trace = new TraceSource("Tracer", SourceLevels.All);
    ////        SourceSwitch control = new SourceSwitch("control", "Controls the tracing");
    ////        control.Level = SourceLevels.Information;
    ////        trace.Switch = control;
    ////        trace.TraceEvent(TraceEventType.Start, 10000);
    ////        trace.TraceEvent(TraceEventType.Warning, 10001);
    ////        trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
    ////        trace.TraceEvent(TraceEventType.Information, 10003, "Some information", new object[] { "line1", "line2" });
    ////        trace.Flush();
    ////        trace.Close();
    ////    }
    ////}

    #endregion

    #region Configuracion de traceo en archivos config
    /*
    Se puede configurar el traceo a través de keys en archivos .config   se puede ver mas en PAG 313 
    */

    #endregion

    #region Clase StopWatch
    /*
        la clase Stopwatch nos brinda una forma fácil de medir el tiempo transcurrido. Se utiliza para medir la perfomance de un programa.
        En el ejemplo se comparan los tiempos de un supuesto metodo que funciona secuencialmente y otro que funciona en paralelo.

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    sequentialTest();
    stopwatch.Stop();
    Console.WriteLine("Sequential time in milliseconds: {0}",
     stopwatch.ElapsedMilliseconds);
    stopwatch.Restart();
    parallelTest();
    stopwatch.Stop();
    Console.WriteLine("Parallel loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
    */

    #endregion

    #region Diagnosticos con Visual Studio
    /*
    VS proporciona herramientas para testear el perfomance. Esplicación bastante escueta pero introductoria en 314 
    */
    #endregion

    #region  Monitorear contadores de performance desde Windows
    /*
    Windows tiene un gran número de contadores de performance. Estos pueden verse desde el Perormance Monitor, al cual podemos acceder ejecutando
    perfmon desde powershell.  
    */

    #endregion

    #region Leer los contadores de performance
    /*
    
    Un identificador de Performance es identificado por su nombre de categoria, su nombre de counter, y su nombre de instancia.
    
   Para crear un contador, tenemos que desde windows ejecutar perfmon, y agregarlo. Hay muchas categorias. hice la prueba de generar
   un .net cache monitor y funciono.  Pero si no esta agregado desde perfmon, no va a funcionar...  Es un poco porongo porque windows
   traduce el nombre de algunos de los monitores, y en el codigo hay que poner el nombre en ingles...


    En el ejemplo se lee el contador de performance de tiempo de procesador

     */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        PerformanceCounter processor = new PerformanceCounter(
    //        categoryName: "Processor Information",
    //        counterName: "% Processor Time",
    //        instanceName: "_Total");

    //        //PerformanceCounter DotNetCache = new PerformanceCounter(
    //        //categoryName: ".Net Memory Cache 4.0",
    //        //counterName: "Cache Hits",
    //        //instanceName: "_lm_w3svc_2_root:default");


    //        Console.WriteLine("Press any key to stop");
    //        while (true)
    //        {
    //            Console.WriteLine("Processor time {0}", processor.NextValue());
    //            //Console.WriteLine(".Net Cache {0}", DotNetCache.NextValue());
    //            Thread.Sleep(500);
    //            if (Console.KeyAvailable)
    //                break;
    //        }
    //    }
    //}

    #endregion

    #region Crear contadores de performance propios
    /*
     * Es posible crear nuestros propios contadores, pero hay que tener privilegios de administrador en la pc.
     * Se puede ver mas en PAG 318
     
     */

    #endregion

    #region Escribir y leer event log de windows.   
    /*
    Ya hemos visto como enviar eventos a la consola de output o incluso un archivo... Es posible tambien enviarlo al log event de windows.
    Solo se puede hacer si se tienen privilegios de administrador y correr VS también como adminitrador.
    Mas info en PAg 321
     */

    #endregion

}
