using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningCwithFramework
{

    #region Teoria
    /*
    Delegate:  Es una referencia a un método de una clase. A un evento publicador se le da un delegado que describe el método en el 
    suscriptor a ese evento. El evento publicador entonces puede llamar al suscriptor cuando el evento se dispare.

    Action Delegate:  Las Librerias de .Net proveen un conjunto de type delegates predefinidos. El más simple de ellos es "Action" que
    representa una referencia hacia un método que no devuelve nada (void) y que no acepta ningún parámetro. Se puede usar un"Action" para
    crear un punto de enlace con un suscriptor.

    A TENER EN CUENTA:
    - Los metodos subscriptos a un evento, no necesariamente se ejecutaran en el orden en que fueron añadidos.
    - Los delegados añadidos a un evento, son ejecutados en el mismo hilo donde se ejecute el evento publicado. Si un delegado bloquea el hilo,
    todo el mecanismo de publicacion queda bloqueado. Esto quiere decir que suscriptores maliciosos o mal escritos tienen la habilidad de
    bloquear el mecanismo de publicacion de eventos.
    - El objeto delegado contiene un metodo GetInvokationList que contiene la lista de todos los subscritpos a dicho evento.
    - Si un metodo es suscripto dos veces a un mismo delegado, el dispararse el evento, el metodo suscripto se ejecutara dos veces.

    */
    #endregion


    #region Ejemplo de delegate Action

    //class Alarm {
    //
    //    // Delegate for the alarm event
    //
    //    //public Action OnAlarmRaised { get; set; }
    //    /* 
    //        publicar un delegado sin la palabra reservada event, lo hace vulnerable a que codigo externo a la clase Alarm pueda disparar la
    //        alarma llamdo al metodo OnAlarmRaised, tambien codigo externo podria sobreescribir el metodo y borrar los suscriptores.
    //        Marcando un delegado como "event" el miembro OnAlarmRaised es creado como un campo de datos (data field) en vez de como una propiedad.
    //        Ya no tiene get y set, y el codigo externo ya no es peligroso. Y solamente puede ser llamado desde el interior de la clase
    //    */
    //
    //    public event Action OnAlarmRaised = delegate { };
    //
    //
    //    // Called to raise an alarm
    //    public void RaiseAlarm()
    //    {
    //        // Only raise the alarm if someone has
    //        // subscribed.
    //
    //        //if (OnAlarmRaised != null)
    //        //{
    //        //    OnAlarmRaised();
    //        //}
    //
    //        OnAlarmRaised?.Invoke();   //Si el evento se ha creado con la palabra reservada "event" no hace falta el ? para verificar que no sea null
    //
    //    }
    //    class Program
    //    {
    //        // Method that must run when the alarm is raised
    //        static void AlarmListener1()
    //        {
    //            Console.WriteLine("Alarm listener 1 called");
    //        }
    //        // Method that must run when the alarm is raised
    //        static void AlarmListener2()
    //        {
    //            Console.WriteLine("Alarm listener 2 called");
    //        }
    //        static void Main(string[] args)
    //        {
    //            // Create a new alarm
    //            Alarm alarm = new Alarm();
    //            // Connect the two listener methods
    //            alarm.OnAlarmRaised += AlarmListener1;  //Se suscribe al evento
    //            alarm.OnAlarmRaised += AlarmListener2;   
    //            // raise the alarm
    //            alarm.RaiseAlarm();
    //            Console.WriteLine("Alarm raised");
    //
    //            alarm.OnAlarmRaised -= AlarmListener1;   //Desuscribirse al evento
    //            alarm.RaiseAlarm();
    //            Console.WriteLine("Alarm raised");
    //
    //            Console.ReadKey();
    //
    //        }
    //    }
    //
    //}

    #endregion

    #region creacion de eventos con predefinidos (built-in) delegate types
    /*
    Los event delegates creados hasta ahora han hecho uso de la clase Action. Esto funciona, pero en realidad los eventos deberian hacer uso de la
    clase EventHandler en vez de Action. Esto se debe a que los eventHandlers estan diseñados para permitir a los suscriptores recibir datos 
    acerca de un evento. Un eventhandler puede pasar datos, o simplemente avisar que un evento se ha disparado.

    El delegate eventhandler hace referencia a un metodo del subscriptor que recibe dos paramentros. El primer parametro es una referencia hacia
    el objeto que dispara el evento, el segundo es una referencia a un objeto de tipo EventArgs.Empty, para indicar que este evento no produce
    datos, y que solo indica que un evento se ha disperado.
    La firma del método a pasar al delegado debe contemplar dichos parametros. El método AlarmListener1 puede ser usado con este tipo de delegados

     */
    #region ejemplo con eventhandler que no recibe argumentos
    //class Alarm
    //{
    //    // Delegate for the alarm event
    //    public event EventHandler OnAlarmRaised = delegate { };
    //    // Called to raise an alarm
    //    // Does not provide any event arguments
    //    public void RaiseAlarm()
    //    {
    //        // Raises the alarm
    //        // The event handler receivers a reference to the alarm that is
    //        // raising this event
    //        OnAlarmRaised(this, EventArgs.Empty);
    //    }
    //}
    //class Prog
    //{
    //    // Method that must run when the alarm is raised
    //    private static void AlarmListener1(object sender, EventArgs e)
    //    {
    //        // Only the sender is valid as this event doesn't have arguments
    //        Console.WriteLine("Alarm listener 1 called");
    //    }
    //    // Method that must run when the alarm is raised
    //    static void AlarmListener2(object sender, EventArgs e)
    //    {
    //        Console.WriteLine("Alarm listener 2 called");
    //    }
    //    static void Main(string[] args)
    //    {
    //        // Create a new alarm
    //        Alarm alarm = new Alarm();
    //        // Connect the two listener methods
    //        alarm.OnAlarmRaised += AlarmListener1;  //Se suscribe al evento
    //        alarm.OnAlarmRaised += AlarmListener2;
    //        // raise the alarm
    //        alarm.RaiseAlarm();
    //        Console.WriteLine("Alarm raised");

    //        alarm.OnAlarmRaised -= AlarmListener1;   //Desuscribirse al evento
    //        alarm.RaiseAlarm();
    //        Console.WriteLine("Alarm raised");

    //        Console.ReadKey();

    //    }
    //}
    #endregion

    #region ejemplo con eventhandler que si recibe argumentos
    //    /*
    //     En este caso el eventHandler recibe un objeto clase AlarmEventArg que es una subclase de EventArgs, y que le agrega una propiedad Location.
    //     De ser necesario se le pueden agregar mas propiedades.

    //     Como el eventhandler recibe referencias de un mismo objeto, es posible usarlo como bandera entre distintos "disparos" del evento. 
    //     Ver ejemplo abajo. igualmente esto puede llegar a traer consecuencias inesperados si no se usa con cuidado.
    //     */

    //class Alarm
    //{
    //    // Delegate for the alarm event
    //    public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };
    //    // Called to raise an alarm
    //    // Does not provide any event arguments
    //    public void RaiseAlarm(string location)
    //    {
    //        // Raises the alarm
    //        // The event handler receivers a reference to the alarm that is
    //        // raising this event
    //        OnAlarmRaised(this, new AlarmEventArgs(location));
    //    }
    //}
    //class AlarmEventArgs : EventArgs
    //{
    //    public string Location { get; set; }
    //    public AlarmEventArgs(string location)
    //    {
    //        Location = location;
    //    }
    //}
    //class Prog
    //{
    //    // Method that must run when the alarm is raised
    //    private static void AlarmListener1(object sender, AlarmEventArgs e)
    //    {
    //        // Only the sender is valid as this event doesn't have arguments
    //        Console.WriteLine("Alarm listener 1 called from "  + e.Location  );
    //        e.Location = "ya fui disparado";
    //    }
    //    // Method that must run when the alarm is raised
    //    static void AlarmListener2(object sender, AlarmEventArgs e)
    //    {
    //        if (e.Location == "ya fui disparado")
    //        {
    //            Console.WriteLine("He recibido una bandera de que la alarma ya esta disparada");
    //        }
    //        else {
    //            Console.WriteLine("Esta alarma nunca ha sido disparada antes");
    //        }

    //    }
    //    static void Main(string[] args)
    //    {
    //        // Create a new alarm
    //        Alarm alarm = new Alarm();
    //        // Connect the two listener methods
    //        alarm.OnAlarmRaised += AlarmListener2;
    //        alarm.OnAlarmRaised += AlarmListener1;  //Se suscribe al evento
    //        alarm.OnAlarmRaised += AlarmListener2;
    //        // raise the alarm
    //        alarm.RaiseAlarm("Main");
    //        Console.WriteLine("Alarm raised");


    //        Console.ReadKey();

    //    }
    //}

    #endregion

    #region Excepciones en suscriptores
    /*
    
    Cuando un eventhandler se dispara, se notifica a todos sus suscriptores. Que pasa si uno de esos suscriptores levanta una excepcion no
    controlada? Pues que se cortan las llamadas a los demas suscriptores y quedaran sin ser notificados.
    Para evitar esto cada eventhandler puede ser llamado de forma individual y luego una excepsion agregada que contiene los detallaes de todas
    las excepciones lanzadas puede ser creado.
    El método GetInvokationList es utilizado en el delegado para obtener una lista de los suscriptores. Luego se itera sobre esta lista y el
    método DinamicInvoke de cada suscriptor es llamado. Cualquier excepcion que haya sido levantada por un suscriptor es capturada y añadida a una
    lista de excepciones. Las excepciones capturadas son entregadas luego como TypeInvokationException.
    
    */


    //class Alarm
    //{
    //    // Delegate for the alarm event
    //    public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };
    //    // Called to raise an alarm
    //    // Does not provide any event arguments
    //    public void RaiseAlarm(string location)
    //    {
    //        List<Exception> exceptionList = new List<Exception>();
    //        foreach (Delegate handler in OnAlarmRaised.GetInvocationList())
    //        {
    //            try
    //            {
    //                handler.DynamicInvoke(this, new AlarmEventArgs(location));
    //            }
    //            catch (TargetInvocationException e)
    //            {
    //                exceptionList.Add(e.InnerException);
    //            }
    //        }
    //        if (exceptionList.Count > 0)
    //            throw new AggregateException(exceptionList);
    //    }
    //}
    //class AlarmEventArgs : EventArgs
    //{
    //    public string Location { get; set; }
    //    public AlarmEventArgs(string location)
    //    {
    //        Location = location;
    //    }
    //}
    //class Prog
    //{
    //    // Method that must run when the alarm is raised
    //    private static void AlarmListener1(object sender, AlarmEventArgs e)
    //    {
    //        Console.WriteLine("Alarm listener 1 called from " + e.Location);
    //        throw new Exception("Bang");
    //    }
    //    // Method that must run when the alarm is raised
    //    static void AlarmListener2(object sender, AlarmEventArgs e)
    //    {
    //        Console.WriteLine("Alarm listener 2 called from " + e.Location);
    //        throw new Exception("Boom");
    //    }
    //    static void Main(string[] args)
    //    {
    //        // Create a new alarm
    //        Alarm alarm = new Alarm();
    //        // Connect the two listener methods
    //        alarm.OnAlarmRaised += AlarmListener1;  //Se suscribe al evento
    //        alarm.OnAlarmRaised += AlarmListener2;
    //        // raise the alarm
    //        try
    //        {
    //            alarm.RaiseAlarm("Kitchen");
    //        }
    //        catch (AggregateException agg) //No se puede usar directamente Exeption por que es una sola excepcion. AggregateException seria una lista
    //        {
    //            foreach (Exception ex in agg.InnerExceptions)
    //                Console.WriteLine(ex.Message);
    //        }
    //        Console.WriteLine("Alarm raised");

    //        Console.ReadKey();

    //    }
    //}

    #endregion

    #endregion

    #region creacion de delegados

    ///*

    //Hasta ahora hemos usado delegados predefinidos, que mantienen una coleccion de referencias a metodos, pero se podria crear un delegado que solo
    //mantenga un unico método.

    //delegate int IntOperation(int a, int b);

    //Con el ejemplo anterior, un programa podría crear valirables delegate de tipo IntOperation. En el codigo de abajo la variable op esta hecha
    //para referir primero a un método Add, y luego a un método Substract. Cada llamada a op ejecutará el método que ha sido creado para referirse.

    // */

    //class Prog
    //{
    //    delegate int IntOperation(int a, int b);
    //    static int Add(int a, int b)
    //    {
    //        Console.WriteLine("Add called");
    //        return a + b;
    //    }
    //    static int Subtract(int a, int b)
    //    {
    //        Console.WriteLine("Subtract called");
    //        return a - b;
    //    }
    //    static void Main(string[] args)
    //    {
    //        // Explicitly create the delegate
    //        var op = new IntOperation(Add);
    //        Console.WriteLine(op(2, 2));
    //        // Delegate is created automatically
    //        // from method
    //        op = Subtract;
    //        Console.WriteLine(op(2, 2));
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region delegate vs Delegate
    /*
    
    delegate en minuscula es una palabra reservada que sirve para crear un tipo de dato delegate:
        
        delegate int IntOperation(int a, int b);

    Delegate con mayúscula es una clase abstracta que define el comportamiento de las instancias delegate. Una vez que la palabra reservada
    delegate es utilizada para crear un tipo de dato delegate, los objetos de ese tipo de dato seran instancias de Delegate (mayúscula)

        IntOperation op;

    La variable op en este caso es una instancia de System.MultiCastDelegate type, que es una clase hija de la clase Delegate. Un programa
    podría utilizar la variable op mantener una coleccion de suscriptores o para referir un método único.

    */

    #endregion

    #region expresiones lambda

    /*
     
    Consideremos este delegado:
    
        delegate int IntOperation(int a, int b)

    El delegado IntOperation podria referirse a cualquier operacion entre dos integers, que a su vez devuelve un integer. Ahora veamos la
    siguiente expresion:

        IntOperation Add = (a,b) => (a + b);

    El operador => se llama operador lambda. Los items a y b a la izquierda del operador lambda son mapeados con los parametros definidos en el
    delegado. La expresión a la derecha del operador lambda asigna el comportamiento. Es decir que el método Add recibe dos paametros int, y devuelve
    un int resultado de la suma de ellos.

    Una expresion lambda podria recibir mas de dos parametros e incluso ejecutar muchas instrucciones, en ese caso deben encerrarse en llaves como abajo
    
    add = (a,b) =>
    {
     Console.WriteLine("Add called");
     return a + b;
    };


    */

    #endregion

    #region clousures

    /*

    El codigo de una expresión lambda puede acceder a variables en el código  cercano (supongo de ahi su nombre clousures). Estas
    variables deben estar vivas cuando el código se ejecuta, y por esto, el compilador extiende la vida de las variables cuando detecta que
    seran usadas en una expresion lamda.

    En el ejemplo de abajo la variable localInt debería morir despues de la ejecución de SetLocalInt, sin embargo el compilador detecta
    que la variable será utilizada por el delegado getLocalInt, y por eso la mantiene viva.

    */

    //class Prog
    //{
    //    delegate int GetValue();
    //    static GetValue getLocalInt;
    //    static void SetLocalInt()
    //    {
    //        // Local variable set to 99
    //        int localInt = 99;
    //        // Set delegate getLocalInt to a lambda expression that
    //        // returns the value of localInt
    //        getLocalInt = () => localInt;
    //    }
    //    static void Main(string[] args)
    //    {
    //        SetLocalInt();
    //        Console.WriteLine("Value of localInt {0}", getLocalInt());
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region tipos predefinidos (built in) para usar con expresiones lambda

    /*
    
    Existen varios tipos de datos prefedinidos para usar en expresiones lambda. El tipo Func provee un rango de delegados para metodos
    que aceptan y devuelven valores. Hay versiones de Func que llegan a aceptar hasta 16 parametros. En el ejemplo de abajo se utiliza uno que
    acepta dos parametros int y devuelve un int.

    Func<int,int,int> add = (a, b) => a + b;

    Func siempre debe devolver algun valor, si necesitamos un delegado que no devuelva nada, hay que usar Action. En el ejemplo de abajo se ve
    un Action que recibe un string, y no devuelve nada.

    static Action<string> logMessage = (message) => Console.WriteLine(message);

    El tipo delegado predefinido Predicate nos permite crear codigo que recibe un valor de un tipo particular, y retorna true o false.

    Predicate<int> dividesByThree = (i) => i % 3 == 0; 

    */

    #endregion

    #region métodos anonimos

    /*
     
    Hasta ahora hemos usado expresiones lamda adjuntas a delegados. El delegado provee el nombre bajo el cual el código en la expresión lambda
    puede ser accedido. Sin embargo, las expresiones lambda también pueen ser usadas directamente en un contexto en donde solo queremos expresar
    cierto comportamiento. 

    El ejemplo de abajo usa Task.Run para iniciar una nueva tarea. El código ejecutado por la tarea es expresado directamente como una expresión 
    lambda, que es pasada como argumento a Task.Run sin asignarsele un nombre en ningún momento.
     
    */

    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        Task.Run(() =>
    //        {
    //            for (int i = 0; i < 5; i++)
    //            {
    //                Console.WriteLine(i);
    //                Thread.Sleep(500);
    //            }
    //        });
    //        Console.WriteLine("Task running..");
    //        Console.ReadKey();
    //    }
    //}

    #endregion




}
