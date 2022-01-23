using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace LearningCwithFramework
{
    class _03_Threads
    {
        #region teoria
        /*
        Threads vs Tasks

        Pag 40
                      Threads (Hilos)                           |                               Tasks(Tareas)
        
        -Son creados como procesos en primer plano.             |   -Son creados como procesos en segundo plano.
        Un programa no terminará nunca que tenga un hilo en     |   Una task puede terminarse aburptamente si todos los hilos en primer
        primer plano aun corriendo. Se pueden setear para       |   plano terminan.
        que corran en segundo plano.                            |
        -Los corre el sistema operativo.                        |   -Los corre el CLR? (no se, estoy adivinando, pero no el SO).
        -No terminan mientras quede algo por hacer excepto que  |   -Pueden ser terminados aun con cosas por hacer. Si todos los
        salte una excepcion. O se los aborte intencionalmente.  |    Hilos en primer plano terminan, se mueren los en segundo plano               
        - Tienen una prodiedad Priority, que puede cambiar      |   -No tienen Priority.
        durante la ejecucion, mayor prioridad que una task,     |    
        por lo que mayor tiempo de proceso es asignado          |
        - No pueden entregarle un resultado a otro Thread, pero |   -Pueden entregar resultados.
        pueden usar variables compartidas (puede generar        |
        problemas de sincronizacion)                            | 
        -No se puede crear un hilo de continuacion, en cambio   |   -Se puede crear una tarea de continuación.
        proveen un método "join" que pausa un hilo, hasta que   |
        otro termine.                                           |
        -No se puede agregar excepcion sobre el resultado de un |
        Thread, las excepciones deben manejarse dentro.         |   -Se pueden agregar excepciones sobre el resultado.

         */

        #endregion

        #region Creación

        ///*
        //En la creacion de un Hilo se puede pasar el nombre del metodo que se va a ejecutar, una vez creado, se puede llamar al método
        //"Start" para que comience su ejecución.
        //*/
        //static void ThreadHello()
        //{
        //    Console.WriteLine("Hello from the thread");
        //    Thread.Sleep(2000);
        //}
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(ThreadHello);
        //    thread.Start();
        //    Console.ReadKey();
        //}

        #endregion

        #region Creación con lambda 
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        Console.WriteLine("Hello from the thread");
        //        Thread.Sleep(1000);
        //    });

        //    thread.Start();
        //    Console.WriteLine("Press a key to end.");
        //    Console.ReadKey();
        //}
        #endregion

        #region Pasando Datos a un Hilo

        ///*
        //Se puede pasar datos a un Hilo, a través del Delegate "ParameterizedThreadStart" que especifica un método de hilo que acepta un único objeto
        // de parametros. El objeto pasado al Hilo, es colocado luego en el método Start.
        //*/

        //static void WorkOnData(object data)
        //{
        //    Console.WriteLine("Working on: {0}", data);
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Press a Key");
        //    Console.ReadKey();
        //    Console.WriteLine("Finishing Work");
        //    Console.ReadKey();
        //}
        //static void Main(string[] args)
        //{
        //    ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
        //    Thread thread = new Thread(ps);
        //    thread.Start(99);
        //    Console.ReadKey();
        //}


        #endregion

        #region Pasando datos con expresión lambda
        //static void WorkOnData(object data)
        //{
        //    Console.WriteLine("Working on: {0}", data);
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Press a Key");
        //    Console.ReadKey();
        //    Console.WriteLine("Finishing Work");
        //    Console.ReadKey();
        //}
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread((data) =>
        //    {
        //        WorkOnData(data);
        //    });
        //    thread.Start(99);
        //}

        /*
         OJO:  El parametro pasado al Hilo es un objeto pasado por referencia, por lo que no hay forma de conocer su tipo en tiempo de compilación.
         */

        #endregion

        #region Abortar un Hilo

        //static void Main(string[] args)
        //{
        //    Thread tickThread = new Thread(() =>
        //    {
        //        while (true)
        //        {
        //            Console.WriteLine("Tick");
        //            Thread.Sleep(1000);
        //        }
        //    });
        //    tickThread.Start();
        //    Console.WriteLine("Press a key to stop the clock");
        //    Console.ReadKey();
        //    tickThread.Abort();
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();
        //}

        /*
         OJO: Esta forma de abortar un hilo puede dejar recursos abiertos. Una mejor forma se detalla abajo.
         */


        #endregion

        #region Abortar un Hilo de forma segura

        //static bool tickRunning; // flag variable
        //static void Main(string[] args)
        //{
        //    tickRunning = true;
        //    Thread tickThread = new Thread(() =>
        //    {
        //        while (tickRunning)
        //        {
        //            Console.WriteLine("Tick");
        //            Thread.Sleep(1000);
        //        }
        //    });
        //    tickThread.Start();
        //    Console.WriteLine("Press a key to stop the clock");
        //    Console.ReadKey();
        //    tickRunning = false;
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();
        //}

        #endregion

        #region Sincronizacion de Hilos con Join
        ///*
        // Cuando un Hilo llama al metodo join de otro Hilo, quien llama a join es detenido hasta que el otro Hilo termina.
        // */
        //static void Main(string[] args)
        //{
        //    Thread threadToWaitFor = new Thread(() =>
        //    {
        //        Console.WriteLine("Thread starting");
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Thread done");
        //    });
        //    threadToWaitFor.Start();
        //    Console.WriteLine("Joining thread");
        //    threadToWaitFor.Join(); //Este join vendria a ser un "Espera hasta que este HIlo termine, y despues segui"
        //    Console.WriteLine("Press a key to exit");
        //    Console.ReadKey();

        //}



        #endregion

        #region ThreadStatic Attribute

        /*
         Si en un programa con varios hilos funcionando, se necesita que cada hilo cuente con variables propias no compartidas por
         los dititnos hilos, se pueden utilizar variables marcadas con el atributo threadStatic como se muestra en el ejemplo
         OJO: segun stackoverflow si se necesita inicializar las variables threadstatic con algun valor, en varios hilos, solo se
         va a inicializar en el primer hilo que llame a esa variable, el resto de los hilos se van a encontrar con una variable
         sin inicializar
        */

        //public class example {
        //    [ThreadStatic] static double previous = 0.0;   //<-- Estas variables podrian ser usadas por mas de un hilo y cada
        //    [ThreadStatic] static double sum = 0.0;         //hilo tendria su propia copia
        //}

        #endregion

        #region ThreadLocal

        ///*
        // ThreadLocal va a inicializar las variables, en cada hilo. A diferencia de threadstatic que lo hace solo para el primer hilo
        // */


        //public static ThreadLocal<Random> RandomGenerator =
        //new ThreadLocal<Random>(() =>
        //    {
        //        return new Random(2);
        //    });

        //public static int GetRandom(int value) {
        //    return new Random(2).Next(value);
        //}

        //static void Main(string[] args)
        //{
        //    Thread t1 = new Thread(() =>
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine("t1: {0}", RandomGenerator.Value.Next(10));
        //            //Console.WriteLine("t1: {0}", GetRandom(10));
        //            Thread.Sleep(500);
        //        }
        //    });
        //    Thread t2 = new Thread(() =>
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            Console.WriteLine("t2: {0}", RandomGenerator.Value.Next(10));
        //            //Console.WriteLine("t2: {0}", GetRandom(10));
        //            Thread.Sleep(500);
        //        }
        //    });
        //    t1.Start();
        //    t2.Start();
        //    Console.ReadKey();

        //}

        #endregion

        #region threadstatic vs threadlocal

        // https://www.youtube.com/watch?v=8KrkMWrjyuE

        #endregion

        #region Thread Context
        ///*
        // Los hilos exponen un rango de informacion de contexto en donde algunos items se pueden leer, y otros se pueden leer y escribir. 
        // items: prioridad, nombre, primero o segundo plano, cultura y seguridad.
        // */
        //static void DisplayThread(Thread t)
        //{
        //    Console.WriteLine("Name: {0}", t.Name);
        //    Console.WriteLine("Culture: {0}", t.CurrentCulture);
        //    Console.WriteLine("Priority: {0}", t.Priority);
        //    Console.WriteLine("Context: {0}", t.ExecutionContext);
        //    Console.WriteLine("IsBackground?: {0}", t.IsBackground);
        //    Console.WriteLine("IsPool?: {0}", t.IsThreadPoolThread);
        //}
        //static void Main(string[] args)
        //{
        //    //Creo que aca el current Thread seria el que esta ejecutando el Main
        //    Thread.CurrentThread.Name = "Main method";
        //    DisplayThread(Thread.CurrentThread);
        //    Console.ReadKey();
        //}

        //////Otra forma de ver las caracteristicas es usando directamente thread.currenththread

        ////static void ThreadHello()
        ////{
        ////    Console.WriteLine("Hello from the thread");
        ////    Thread.Sleep(2000);
        ////    Console.WriteLine("Name: {0}", Thread.CurrentThread.Name);
        ////    Console.WriteLine("Culture: {0}", Thread.CurrentThread.CurrentCulture);
        ////    Console.WriteLine("Priority: {0}", Thread.CurrentThread.Priority);
        ////    Console.WriteLine("Context: {0}", Thread.CurrentThread.ExecutionContext);
        ////    Console.WriteLine("IsBackground?: {0}", Thread.CurrentThread.IsBackground);
        ////    Console.WriteLine("IsPool?: {0}", Thread.CurrentThread.IsThreadPoolThread);

        ////}
        ////static void Main(string[] args)
        ////{
        ////    Thread thread = new Thread(ThreadHello);
        ////    thread.Start();
        ////    Console.ReadKey();
        ////}


        #endregion

        #region ThreadPool
        ///*
        //Los hilos, como todo lo demas en C#, son objetos. Un ThreadPool es una coleccion de Hilos que se pueden reutilizar. En vez de crear un Hilo,
        //es posible buscar que hilo queremos ejecutar, de entre los que se encuentran en el threadpool.
        //Thread provee un método llamado QueueUserWorkItem, el cual coloca el hilo en una cola de hilos a correr (si hay suficientes recursos
        //se ejecutan al momento, los que no se puedan ejecutar entraran en cola hasta que se liberen recursos).
        //El hilo de trabajo es provisto como un WaitCallBack delegate. Hay dos versiones de este delegado, en la primera (la usada en el ejemplo) 
        //se acepta un objeto que puede ser utilizado para proveer informacion del estado.

        //IMPORTANTE:
        //El ThreadPool restringe la cantidad de hilos activos(corriendo), y por esto no todos los hilos comienzan al mismo tiempo. 
        //Un dispositivo puede sobrecargarse de hilos si muchos se disparan. ThreadPool los pone en una cola cuando es necesario.
        //En algunas situaciones no es recomendable usar un ThreadPool:
        //    - Si se necesitan un gran numero de hilos que se quedan esperando mucho tiempo, puede bloquear el threadpool, ya que contiene un
        //    numero finito de hilos.
        //    - No se puede manejar la prioridad de los hilos dentro de un threadPool
        //    - Los hilos de un threadPool corren SIEMPRE en segundo plano.
        //    - variables locales no se limpian cuando un hilo las usa. No deberian usarse variables locales con threadpool.
        //     */

        //static void DoWork(object stateNumber)
        //{
        //    Console.WriteLine("Doing work: {0}", stateNumber);
        //    Thread.Sleep(500);
        //    Console.WriteLine("Work finished: {0}", stateNumber);
        //}
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        int stateNumber = i;
        //        ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
        //    }
        //    Console.ReadKey();
        //}

        #endregion

        #region async and await

        ///*
        //Las Tasks (tareas) son especialmente útiles cuando el sistema puede hacer algo mas, mientras espera una respuesta. Por ejemplo, la interfaz
        //de usuario puede seguir respondiendo a acciones de usuario, mientras una tarea en segundo plano termina. 
        //La aplicación debe contener codigo que cree la task, que de la señal de comenzar a ejecutarla, que devuelva posibles excepciones, y que
        //informe de su finalización.  Para esto tenemos async y await.
        //La palabra reservada Async marca un metodo como Asíncrono y los métodos asincornos deben contener uno o mas acciones que serán "esperadas"
        //(awaited). 
        //Las acciones que pueden ser "Esperadas" (awaited) deben devolver una Task o una Task<T> (en caso de que devuelvan un result de un tipo determinado).

        //Cuando un método es marcado como Async, el compilador interpreta que este método debe ser tratado de forma especial ya que contiene una o mas 
        //tareas que deben ser esperadas (awaited).  "await" precede a una llamada que devolvera una tarea (task) a ser esperada. El compilador ejecutara
        //el flujo de instrucciones hasta llegar al await, y luego devolvera el flujo a quien sea que haya llamado al método marcado con Async. Cuando 
        //la tarea termine, el flujo continuara desde el await en adelante.

        //*/

        ///*
        // El codigo proporcionado por el libro para ejemplificar no funciona porque necesita wpf. Asique hago mi propio ejemplo con ayuda de google
        // Tener en cuenta que el metodo main no se puede poner como async, y por eso se deriva a otro metodo la ejecucion.
        //*/


        ///*
        //NOTA SOBRE EXCEPCIONES:
        //Para que un metodo asincrono devuelva una excepcion en caso de que algo vaya mal, simplemente hay que encerrar la clausula que contenga
        //el await entre try y catch.  Sin embargo, el metodo awaited debe devolver un resultado para que funcione, no se va a levantar la excepcion
        //si devuelve void. Por eso nunca deberian usarse awaited methods que devuelvan void.

        //*/


        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Comienza hilo MAIN");
        //    callMethod();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine("MAIN");
        //    }
        //    Console.ReadKey();
        //}

        //public static async void callMethod()
        //{
        //    Console.WriteLine("Comienza Hilo callMethod, el hilo main se detiene a esperar que termine callMethod");
        //    Method2("A");                       // El hilo de callMethod tiene el flujo, y ejecuta Method2-A hasta que termine

        //    task2();                            //Se lanza hilo en segundo plano que ejecuta task2
        //    Method2("B");                       //El hilo de callMethod ejecuta Method2-B, mietras que el hilo del task2 se ejecuta tambien.
        //                                        //El hilo de callMethod ejecuta Method2-B hasta que termine, recien ahi, ejecuta task1

        //    Task<int> task = task1();           //Se lanza task1, pero como tiene await, devuelve el flujo al MAIN. 
        //    int count = await task;             //El Hilo de Main y el del callMethod (que esta ejecutando task1) funcionan al mismo tiempo

        //    Method2("C");                       //se lanza method2-c recien cuando el await libere el flujo al terminar el task1.
        //    Method3(count);                     //se ejecuta method3 al terminar method2-C en conjunto con el hilo del main, que aun se ejecuta.
        //}

        //public static async Task<int> task1()
        //{
        //    int count = 0;
        //    await Task.Run(() =>
        //    {
        //        for (int i = 0; i < 30; i++)
        //        {
        //            Console.WriteLine("     Task 1");
        //            count += 1;
        //            if (i == 29)
        //                Console.WriteLine("---------------------     FINAL DEL Task 1  ---------------------");
        //        }
        //    });
        //    return count;
        //}

        //public static void Method2(string id)
        //{
        //    Console.WriteLine("-----Comienza METHOD2-" + id + "-----");
        //    for (int i = 0; i < 50; i++)
        //    {
        //        Console.WriteLine("             Method 2:" + id);
        //    }
        //    Console.WriteLine("-----Termina METHOD2-" + id + "------");
        //}

        //public static void Method3(int count)
        //{
        //    Console.WriteLine("Total count is " + count);
        //}

        //public static void task2()
        //{

        //    Console.WriteLine("---------------------     COMIENZA Task 2 en hilo aparte ---------------------");
        //    Task task = Task.Run(() =>
        //    {
        //        for (int i = 0; i < 50; i++)
        //        {

        //            Console.WriteLine("                  Task 2");
        //            if (i == 49)
        //                Console.WriteLine("---------------------     TERMINA Task 2 en hilo aparte ---------------------");
        //        }
        //    });

        //    return;
        //}


        #endregion

        #region await parallel tasks
        /*
         Un método asincrono puede contener varios awaits.  Si es necesario esperar que todas las tareas terminen antes de continuar se utiliza
         Task.WhenAll como en el ejemplo:

        static async Task<IEnumerable<string>> FetchWebPages(string [] urls)
        {
         var tasks = new List<Task<String>>();
         foreach (string url in urls)
         {
         tasks.Add(FetchWebPage(url));
         }
         return await Task.WhenAll(tasks);
        }

        Teneer en cuenta que esto no es una buena practica. Ya que se desconoce el orden en que las tareas pueden terminar

        Adicionalmente, también existe un Task.WhenAny() que se dispara cuando al menos una de las tareas termino

        A TENER EN CUENTA:
        WhenAll y WaitAll, ambos reciben una lista de referencias de tasks.  Sin embargo WaitAll no devuelve ningun resultado. Mientras
        que Whenall si. Ademas WhenAll puede usar await.

         */

        #endregion

        #region concurrent collections

        /*
        La frase "Thread Safe" describe elementos de codigo que funcionan correctamente cuando son utilizados por multiples prosesos (tasks) al mismo
        tiempo. Las standard collections (List, Queue, Dictionary) no son Thread Safe. .Net nos provee con otras librerias que si son thread safe para
        estos casos:
            1 - BlockingCollection<T>
            2 - ConcurrentQueue<T>
            3 - ConcurrentBag<T>
            3 - ConcurrentDictionary<TKey, TValue>
        */

        #region BlockingCollection
        /*
         Es mejor entender las tareas como "Productoras" o "Consumidoras" de datos. Una Tarea que produzca y al mismo tiempo consuma, es suseptible
         a "deadly embrance". De la misma manera si un tarea A espera algo de la tarea B, y a su vez la tarea B espera algo de la tarea A, pasa 
         lo mismo, "deadly embrance". Para solucionar estos problemas .net nos propone usar BlockingCollection, en donde una tarea se va a bloquear
         si intenta consumir algo que no existe hasta que haya algo para consumir. Igualmente una tarea productora se va a bloquear, si no hay espacio
         donde guardar su producto, hasta que haya espacio. 
         
         En el codigo de ejemplo se intentan ingresar 10 items, en un blockingcollection de tamaño 5. La tarea se bloqueara hasta que una segunda
         tarea consuma algunos espacios.
         */

        /*
         NOTA: La clase BloquingCollection puede servir como wrapper de cualquiera de las clases concurrent collection, por ejemplo
         para envolver un ConcurrentStack en el codigo de abajo deberiamos reemplazar por esto:
         
            BlockingCollection<int> data = new BlockingCollection<int>(new ConcurrentStack<int>(), 5);

         Y los items colocados y sacados del stack estarian en orden Last in - First Out
         */

        //static void Main(string[] args)
        //{
        //    // Blocking collection that can hold 5 items
        //    BlockingCollection<int> data = new BlockingCollection<int>(5);
        //    Task.Run(() =>
        //    {
        //        // attempt to add 10 items to the collection - blocks after 5th
        //        for (int i = 0; i < 11; i++)
        //        {
        //            data.Add(i);
        //            Console.WriteLine("Data {0} ---ADDED--- sucessfully.", i);
        //        }
        //        // indicate we have no more to add
        //        data.CompleteAdding();  //En este caso esto se puede comentar e igual funciona, porque el while de abajo siempre va a ser true

        //    });

        //Console.ReadKey();
        //    Console.WriteLine("Reading collection");
        //    Task.Run(() =>
        //    {
        //        while (!data.IsCompleted)
        //        {
        //            try   //Este try es util, porque puede ser que entre cuando isCompleted es false, e inmediatamente despues sea true
        //            {
        //                int v = data.Take();
        //                Console.WriteLine("Data {0} taken sucessfully.", v);
        //            }
        //            catch (InvalidOperationException) { }
        //        }
        //    });
        //    Console.ReadKey();
        //}

        #endregion

        #region ConcurrentQueue
        //    /*
        //     VER NOTA EN BLOCKINGCOLLECTION
        //     */
        //static void Main(string[] args) {
        //    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        //    queue.Enqueue("Rob");
        //    queue.Enqueue("Miles");
        //    string str;
        //    if (queue.TryPeek(out str))
        //        Console.WriteLine("Peek: {0}", str);
        //    if (queue.TryDequeue(out str))
        //        Console.WriteLine("Dequeue: {0}", str);
        //    if (queue.TryDequeue(out str))
        //        Console.WriteLine("Dequeue: {0}", str);
        //    if (queue.TryDequeue(out str))
        //        Console.WriteLine("Dequeue: {0}", str);  //Este no se imprime porque el tryDequeue devuelve false
        //    Console.ReadKey();
        //}

        #endregion

        #region ConcurrentStack
        //    /*
        //     VER NOTA EN BLOCKINGCOLLECTION
        //     */
        //static void Main(string[] args) {
        //    ConcurrentStack<string> stack = new ConcurrentStack<string>();
        //    stack.Push("Rob");
        //    stack.Push("Miles");
        //    string str;
        //    if (stack.TryPeek(out str))
        //        Console.WriteLine("Peek: {0}", str);
        //    if (stack.TryPop(out str))
        //        Console.WriteLine("Pop: {0}", str);
        //    if (stack.TryPop(out str))
        //        Console.WriteLine("Pop: {0}", str);

        //    Console.ReadKey();

        //}

        #endregion

        #region ConcurrentBag

        ///*
        // VERN NOTA EN BLOCKINGCOLLECTION

        //En este caso los items se colocan y se sacan sin ningun orden en particular.
        //OJO: Según el libro TryPeek puede fallar, porque podes "peekear" un item, y despues cuando le haces tryTake, te puede traer otro.
        //pero lo he probado, y no he podido hacer que falle. Me trae siempre lo que "peekea"
        // */
        //static void Main(string[] args) {
        //    ConcurrentBag<string> bag = new ConcurrentBag<string>();
        //    bag.Add("Rob");
        //    bag.Add("Miles");
        //    bag.Add("Hull");
        //    string str;
        //    if (bag.TryPeek(out str))
        //        Console.WriteLine("Peek: {0}", str);
        //    if (bag.TryTake(out str))
        //        Console.WriteLine("Take: {0}", str);

        //    Console.ReadKey();
        //}


        #endregion

        #region concurrentDictionary

        //    /*
        //        VER NOTA EN BLOCKINGCOLLECTION 

        //        Tener en cuenta:
        //            - Si al tratar de hacer un TrayAdd el objeto ya exise, devuelve false.
        //            - TryUpdate recibe el valor a updetear, y el valor anterior. Esto se debe a que si dos procesos quieren aumentar en una la edad
        //            rob podria llegar a incrementar su edad dos veces. En cambio de esta forma solo lo va a incrementar si el valor es actual es
        //            igual al que recibe como valor anterior.
        //     */
        //static void Main(string[] args) {

        //    ConcurrentDictionary<string, int> ages = new ConcurrentDictionary<string, int>();
        //    if (ages.TryAdd("Rob", 21))
        //        Console.WriteLine("Rob added successfully.");
        //    Console.WriteLine("Rob's age: {0}", ages["Rob"]);
        //    // Set Rob's age to 22 if it is 21
        //    if (ages.TryUpdate("Rob", 22, 21))
        //        Console.WriteLine("Age updated successfully");
        //    Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
        //    // Increment Rob's age atomically using factory method
        //    Console.WriteLine("Rob's age updated to: {0}",
        //     ages.AddOrUpdate("Rob", 1, (name, age) => age = age + 1));
        //    Console.WriteLine("Rob's new age: {0}", ages["Rob"]);
        //    Console.ReadKey();
        //}

        #endregion

        #endregion

        #region Managing Multithreading

        #region condición de carrera
        /* 
            Este programa sirve como referencia para comprar contra otro programa multihilo. Simplemente suma todos los valores dentro de un array 
        */

        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void Main(string[] args)
        //{
        //    long total = 0;
        //    DateTime started = DateTime.Now; 
        //    for (int i = 0; i < items.Length; i++)
        //        total = total + items[i];
        //    DateTime finished = DateTime.Now;
        //
        //    Console.WriteLine("The total is: {0}", total + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}

        //

        /*
         Este otro programa también va a sumar todos los elementos del array, pero cada hilo va a ir sumando una porcion del array
         En este caso, el resultado es distinto. Lo que pasa es que hay muchos threads inentando escribir sobre sharedTotal. A veces un
         thread toma el valor, se bloquea, otro trade toma el valor y actualiza, despues el primer thread actualiza tambien, y ya se
         descoñeta el resultado...  Y ensima, tarda mas tiempo... una poronga de programa.
         Este comportamiento en los threads es conocido como "Condicion de carrera", y hay que evitarlo a toda costa. Muchas veces un 
         programa asi puede funcionar bien en una pc, pero en otra con menos (o incluso mas) recursos, puede fallar. 
        */
        //
        //static long sharedTotal;
        //// make an array that holds the values 0 to 5000000
        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void addRangeOfValues(int start, int end)
        //{
        //    while (start < end)
        //    {
        //        sharedTotal = sharedTotal + items[start];
        //        start++;
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    List<Task> tasks = new List<Task>();
        //    int rangeSize = 1000;
        //    int rangeStart = 0;
        //    DateTime started = DateTime.Now;
        //    while (rangeStart < items.Length)
        //    {
        //        int rangeEnd = rangeStart + rangeSize;
        //        if (rangeEnd > items.Length)
        //            rangeEnd = items.Length;
        //        // create local copies of the parameters
        //        int rs = rangeStart;
        //        int re = rangeEnd;
        //        tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
        //        rangeStart = rangeEnd;
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    DateTime finished = DateTime.Now;
        //    Console.WriteLine("The total is: {0}", sharedTotal + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}


        #endregion

        #region Locking
        /*
         Los programas pueden implementar Locking para que una operacion se realize de forma atómica. Es decir, que una operacion bajo lock
         no podra ser interrumpida por otro proceso hasta que termine.
         Este programa soluciona el problema de condicion de carrera del programa anterior, utlizando locking.

        Igualmente el tiempo sigue siendo mayor en multithreading... 
        Esto es porque con locking, si bien se previene el mal funcionamiento de la condición de carrera, también se previenen los beneficios
        que podría aportar el multithreading...  Her - Mo - So !!  :-/
        
          
         */
        //static object sharedTotalLock = new object();
        //static long sharedTotal;
        //// make an array that holds the values 0 to 5000000
        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void addRangeOfValues(int start, int end)
        //{
        //    while (start < end)
        //    {
        //        lock (sharedTotalLock)
        //        {
        //            sharedTotal = sharedTotal + items[start];
        //        }
        //        start++;
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    List<Task> tasks = new List<Task>();
        //    int rangeSize = 1000;
        //    int rangeStart = 0;
        //    DateTime started = DateTime.Now;
        //    while (rangeStart < items.Length)
        //    {
        //        int rangeEnd = rangeStart + rangeSize;
        //        if (rangeEnd > items.Length)
        //            rangeEnd = items.Length;
        //        // create local copies of the parameters
        //        int rs = rangeStart;
        //        int re = rangeEnd;
        //        tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
        //        rangeStart = rangeEnd;
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    DateTime finished = DateTime.Now;
        //    Console.WriteLine("The total is: {0}", sharedTotal + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}



        /*
            En esta otra version del programa, cada hilo escribe su resultado en un subtotal, y cada subtotal se suma una sola vez, en sharetotal 
            Sin embargo, si bien el tiempo mejora a 1400 ms aprox, todavia esta por arriba de los 300ms que lo hace un solo hilo.
         
            Esto es porque siempre locking va a dejar procesos en espera. Lo ideal es que el proceso que quede lockeado siempre sea corto,
            por ejemplo, nunca deberia lockearse un proceso de escritura/lectura 
         */

        //static object sharedTotalLock = new object();
        //static long sharedTotal;
        //// make an array that holds the values 0 to 5000000
        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void addRangeOfValues(int start, int end)
        //{
        //    long subTotal = 0;
        //    while (start < end)
        //    {
        //        subTotal = subTotal + items[start];
        //        start++;
        //    }
        //    lock (sharedTotalLock)
        //    {
        //        sharedTotal = sharedTotal + subTotal;
        //    }
        //}
        //
        //static void Main(string[] args)
        //{
        //    List<Task> tasks = new List<Task>();
        //    int rangeSize = 1000;
        //    int rangeStart = 0;
        //    DateTime started = DateTime.Now;
        //    while (rangeStart < items.Length)
        //    {
        //        int rangeEnd = rangeStart + rangeSize;
        //        if (rangeEnd > items.Length)
        //            rangeEnd = items.Length;
        //        // create local copies of the parameters
        //        int rs = rangeStart;
        //        int re = rangeEnd;
        //        tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
        //        rangeStart = rangeEnd;
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    DateTime finished = DateTime.Now;
        //    Console.WriteLine("The total is: {0}", sharedTotal + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}


        #endregion

        #region Monitor

        /*
         Un monitor es similar a un lock, pero tiene distinta sintaxis. Los Monitores permiten asegurar que solo un thread puede acceder
         a un objeto a la misma vez. En este caso el codigo que debe ser atomico se envuelve entre Monitor.Enter y Monitor.Exit.
         Los metodos Enter y Exit son pasados como referencias a un objeto que sera usad como un cerrojo (lock). 
         */

        /*
        Si el codigo atomica lanza una excepcion hay que tener cuidado de liberar el cerrojo. En el caso de Locking que vimos arriba, 
        el cerrojo se libera automaticamente, pero en el caso de los monitores hay que hacerlo manualmente. En el ejemplo que vimos el codigo
        atomico nunca va a tirar una excepcion, pero en el caso de que sea posible lo mejor es asegurar la liberacion del cerrojo poniendola
        en el bloque finally de un try catch:

        Monitor.Enter(lockObject);
        try
        {
         // code that might throw an exception
        }
        finally
        {
         Monitor.Exit(lockObject);
        }

        En caso de que una excepcion se levante, hay que manejar el codigo de la manera mas limpia posible, ya que seguramente una
        operación no termino de ejecutarse correctamente.

        ¿Cuándo usar monitor en vez de locking? 
        Cuando sea necesario chequear si cierto objeto esta bloqueado o no, antes de ejecutar cierta accion. La idea es que si el
        objeto esta bloqueado, se puede hacer alguna otra cosa antes de volver a intentarlo

        if (Monitor.TryEnter(lockObject))
        {
         // code controlled by the lock
        }
        else
        {
         // do something else because the lock object is in use
        }

        Tambien existen sobrecargas para tryEnter en donde se puede pasar, donde se le pasa una variable flag que nos dice cuando fue que el
        objeto estaba bloqueado o no, y una cantidad de tiempo antes de volver a intentar.


        */





        //static object sharedTotalLock = new object();
        //static long sharedTotal;
        //// make an array that holds the values 0 to 5000000
        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static void addRangeOfValues(int start, int end)
        //{
        //    long subTotal = 0;
        //    while (start < end)
        //    {
        //        subTotal = subTotal + items[start];
        //        start++;
        //    }
        //    Monitor.Enter(sharedTotalLock);
        //    sharedTotal = sharedTotal + subTotal;
        //    Monitor.Exit(sharedTotalLock);
        //}
        //static void Main(string[] args)
        //{
        //    List<Task> tasks = new List<Task>();
        //    int rangeSize = 1000;
        //    int rangeStart = 0;
        //    DateTime started = DateTime.Now;
        //    while (rangeStart < items.Length)
        //    {
        //        int rangeEnd = rangeStart + rangeSize;
        //        if (rangeEnd > items.Length)
        //            rangeEnd = items.Length;
        //        // create local copies of the parameters
        //        int rs = rangeStart;
        //        int re = rangeEnd;
        //        tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
        //        rangeStart = rangeEnd;
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    DateTime finished = DateTime.Now;
        //    Console.WriteLine("The total is: {0}", sharedTotal + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}



        #endregion

        #region deadlockis con multithreads


        /*
        Cualquier objeto manejado por refernecia puede ser utilizado como cerrojo (lock). La parte bloqueada del codigo deberia contener
        solamente las tareas (tasks) cooperativas (o concurrentes). 
        Es importante considerar qué objeto se utilizará como cerrojo. Lo más aconsejable sería utilizar un objeto especifico que funcione como
        cerrojo pero se puede usar cualquiera. No se aconseja usar "this" ni objetos de datos, porque puede ser confuso.

        Se desaconseja totalmente usar strings. .Net utiliza un pool de string en tiempo de compilación, y cada vez que se asigna texto a un
        string, ese texto va a parar al pool. Si mas adelante ese mismo texto se asigna a otro string, lo que hace es pasarle una referencia
        hacia el string anterior. Esto puede generar problemas al usar un string como cerrojo, ya que si dos objetos tienen el mismo texto
        como cerrojo, en realidad van a tener una referencia hacia el mismo objeto.
         */


        /*
        Este codigo es un Ejemplo de deadlock con locking.  
         */

        //static object lock1 = new object();
        //static object lock2 = new object();
        //static void Method1()
        //{
        //    lock (lock1)
        //    {
        //        Console.WriteLine("Method 1 got lock 1");
        //        Console.WriteLine("Method 1 waiting for lock 2");
        //        lock (lock2)
        //        {
        //            Console.WriteLine("Method 1 got lock 2");
        //        }
        //        Console.WriteLine("Method 1 released lock 2");
        //    }
        //    Console.WriteLine("Method 1 released lock 1");
        //}
        //
        //static void Method2()
        //{
        //    lock (lock2)
        //    {
        //        Console.WriteLine("Method 2 got lock 2");
        //        Console.WriteLine("Method 2 waiting for lock 1");
        //        lock (lock1)
        //        {
        //            Console.WriteLine("Method 2 got lock 1");
        //        }
        //        Console.WriteLine("Method 2 released lock 1");
        //    }
        //    Console.WriteLine("Method 2 released lock 2");
        //}

        // //Con este Main sale bien, porque los metodos no sn concurrentes
        //static void Main(string[] args)
        //{
        //    Method1();
        //    Method2();
        //    Console.WriteLine("Methods complete. Press any key to exit.");
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    Task t1 = Task.Run(() => Method1());
        //    Task t2 = Task.Run(() => Method2());
        //    Console.WriteLine("waiting for Task 2");
        //    t2.Wait();
        //    Console.WriteLine("Tasks complete. Press any key to exit.");
        //    Console.ReadKey();
        //}


        #endregion

        #region interlocked operations
        /*
        Cuando en ejemplos anteiores utilizamos multiples task para sumar elementos de un array, tuvimos que protejer el acceso a sharedTotal
        a traves de un lock, o de un array que fuera "thread Safe".  Hay otra forma de lograr esto y es a través de la clase Interlocked.
        Interlocked provee una serie de operaciones "Thread safe" que se pueden aplicar a una variable:  Incrementar (Increment),
        decrementar (decrement), intercambiar (exchange una variable por otra) y sumar (Add)
        
        También existen metodos Compare y exchange que pueden utilizarse para hacer un programa multi-tasking que busque en un array
        el valor mas alto.
        
        El siguiente ejemplo es una muestra de interlocked.Add

        */

        //static int[] items = Enumerable.Range(0, 50000001).ToArray();
        //static long sharedTotal;
        //static void addRangeOfValues(int start, int end)
        //{
        //    long subTotal = 0;
        //    while (start < end)
        //    {
        //        subTotal = subTotal + items[start];
        //        start++;
        //    }
        //    Interlocked.Add(ref sharedTotal, subTotal);
        //}
        //
        //static void Main(string[] args)
        //{
        //    List<Task> tasks = new List<Task>();
        //    int rangeSize = 1000;
        //    int rangeStart = 0;
        //    DateTime started = DateTime.Now;
        //    while (rangeStart < items.Length)
        //    {
        //        int rangeEnd = rangeStart + rangeSize;
        //        if (rangeEnd > items.Length)
        //            rangeEnd = items.Length;
        //        // create local copies of the parameters
        //        int rs = rangeStart;
        //        int re = rangeEnd;
        //        tasks.Add(Task.Run(() => addRangeOfValues(rs, re)));
        //        rangeStart = rangeEnd;
        //    }
        //    Task.WaitAll(tasks.ToArray());
        //    DateTime finished = DateTime.Now;
        //    Console.WriteLine("The total is: {0}", sharedTotal + " and the process took " + (finished - started).TotalMilliseconds.ToString() + " ms");
        //    Console.ReadKey();
        //}



        #endregion

        #region variables volatiles

        /*
         Pag 68
         El codigo fuente de un programa en c#, pasa por varios estados antes de que realmente se ejecute. A veces incluso el orden de los
         statements puede variar un poco, en orden de mejorar algunos aspectos de su ejecución. En algunas oportunidades una variable puede
         ser leida desde cache, en vez de ser re-leida desde memoria. En un programa de con un hilo simple esto no trae ninguna consecuencia,
         pero en un programa multi-hilo, puede darse el caso que el programa utlice una variable desde cache, siendo que otro hilo en realidad
         ha hecho una actualización sobre dicha variable.  Para que esto no pase C# nos provee la palabra reservada "volatil" para asegurar
         que cada vez que se lea el valor de la variable, se lea desde memoria, y no cache.

         volatile int miVariable;

         */

        #endregion

        #region cancelando task

        //Pag 69

        /*
         Los Hilos pueden abortarse en cualquier momento, en cambio las tareas deben hacer uso de un token de cancelación para que terminen
         cuando se lo soliciten.
        */

        /*
        El bucle dentro de este programa es controlado por una instancia de la clase CancellationTokenSource. Esta instancia es compartida entre
        la tarea y el hilo en primer plano. La propiedad IsCancellationRequested hará que el bucle se detenga cuando adquiera un valor de true.
        Esto nos deja la oportunidad de limpiar y liberar recursos cuando se le pida terminarse.
        */


        //static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //static void Clock()
        //{
        //    while (!cancellationTokenSource.IsCancellationRequested)
        //    {
        //        Console.WriteLine("Tick");
        //        Thread.Sleep(500);
        //    }
        //    Console.WriteLine("Limpio recursos");
        //}
        //static void Main(string[] args)
        //{
        //    Task.Run(() => Clock());
        //    Console.WriteLine("Press any key to stop the clock");
        //    Console.ReadKey();
        //    cancellationTokenSource.Cancel();
        //    Console.WriteLine("Clock stopped");
        //    Console.ReadKey();
        //}

        #endregion

        #region Cancelando task con una excepcion

        /*
        
            En este caso se hace uso del método ThrowIfCancellationRequested, que tira una excepcion de tipo OperationCancelledException
            cuando se ejecuta el método Cancel del token. 
            
        */

        //static void Clock(CancellationToken cancellationToken)
        //{
        //    int tickCount = 0;
        //    while (!cancellationToken.IsCancellationRequested && tickCount < 20)
        //    {
        //        tickCount++;
        //        Console.WriteLine("Tick");
        //        Thread.Sleep(500);
        //    }
        //    try
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();
        //    }
        //    catch (Exception e) {
        //        Console.WriteLine(e.Message);
        //    }

        //}
        //static void Main(string[] args)
        //{
        //    CancellationTokenSource cancellationTokenSource =  new CancellationTokenSource();
        //    Task clock = Task.Run(() => Clock(cancellationTokenSource.Token));
        //    Console.WriteLine("Press any key to stop the clock");
        //    Console.ReadKey();
        //    if (clock.IsCompleted)
        //    {
        //        Console.WriteLine("Clock task completed");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            cancellationTokenSource.Cancel();
        //            clock.Wait();
        //        }
        //        catch (AggregateException ex)
        //        {
        //            Console.WriteLine("Clock stopped: {0}",
        //            ex.InnerExceptions[0].ToString());
        //        }
        //    }
        //    Console.ReadKey();
        //}

        #endregion

        #region Implementando Métodos "Thread Save"

        /*
            Siempre que se cree una clase para ser usada con hilos multiples, hay que tener en cuenta que todos sus metodos sean thread Safe. Pero
            tambien hay que considerar que la implementacion sea la correcta, ya que hemos visto anteriormente como un lock mal usado puede hacer
            a un metodo thread safe, pero a su vez, quitarle todas las ventajes de una ejecución multihilo. Hay que tener especial cuidado con
            cualquier objeto que sea pasado por referencia, ya que otra referencia a ese mismo objeto puede ocacionar que los valores se actualicen
            antes o despues de ejecutar cierta operación. Estos errores pueden ser esporadicos y muy dificiles de encontrar una vez ya esten en 
            funcionamiento...
            Una forma de evitar estos errores de pasaje por referencia, es hacer objetos struct type (averiguar que es eso), ya que ellos son
            pasados siempre por valor, la otra es hacer una operación atómica que copie los valores de la referencia del objeto en variables
            locales.

         */

        #endregion

        #endregion

        /*
         Programming is not a place to show how clever you are, because it is more important that it
         is a place where you create code that is easy to understand. It is very unlikely that your “clever”
         construction will be more efficient than a much simpler one. And even if your clever construction is a bit faster,
         person time (the time spent by someone trying to understand your “clever” code) is much more expensive than computer time. 
         */

    }
}
