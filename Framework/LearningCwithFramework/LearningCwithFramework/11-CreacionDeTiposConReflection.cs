#define TERSE
//#define VERBOSE

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace LearningCwithFramework
{

    #region Intro

    /*
    Esta sección no se trata de crear aplicaciones que resuelvan algun problema, sino más bien trata sobre facilitar la administración y y generación
    de componentes de software. Veremos como agregar información descriptiva a clases a través del uso de objetos attribute, como generar programas
    que generan código como salida, y como usar el namespace System.Reflection para crear programas que pueden analizar el contenido de objetos de
    software.   
    */

    #endregion

    #region Creación y aplicación de Atributos
    /*
    C# nos permite agregar metada en forma de attributes adjuntos a las clases y a los miembros de clases. Un attribute es una instancia de alguna
    clase que extienda la clase Attribute (Seguro es abstracta)
    */
    #region Serializable Atttribute
    /*
    Este atributo en particular no contiene metada. El hecho de que una clase contenga adunto un atributo Serializable simplemente significa que
    una clase puede ser abierta y leida por un serializer. (Sin embargo XMLSerializer y JSONSerializer no necesitan que este el atributo adjunto 
    para funcionar)
    Un Serializer lee el contenido completo de una clase, y lo envio en un stream. Es posible que haya que considerarse la seguridad en esto y
    por esto c# requiere que una clase sea "opt in" en el proceso de serializacion. (Se vera esto muuucho mas adelante en "Serialize en deserialize
    data"

    En el ejemplo del codigo tenemos una clase Person, con el atributo serializable adjunto, y dentro de la clase tenemos un miembro screenPosition
    que tiene  adjunto el atributo nonserializable. Ya que este miembro nos da informacion acerca de como desplegar la persona en pantalla, no debe
    ser serializado.
    */

    //[Serializable]
    //public class Person
    //{
    //    public string Name;
    //    public int Age;
    //    [NonSerialized]
    //    // No need to save this
    //    private int screenPosition;
    //    public Person(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //        screenPosition = 0;
    //    }
    //}


    #endregion

    #region Compilacion condicional utilizando atributos

    /*
    Es posible utilizar el atributo "Conditional" para activar o desactivar el contenido de métodos.
    por ejemplo, los simbolos [TERSE] y [VERBOSE] se pueden utilizar para seleccionar el nivel de logging que una aplicación produce. En el código
    de abajo, si el simbolo [TERSE] esta definido, se utilizará el cuerpo del método TerseReport. El cuerpo del método reportHeader se utilizará 
    en ambos casos,
   
        A TENER EN CUENTA:  El atributo Conditional determina cual metodo se ejecutará cuando se haga la llamada. No determina cual metodo se
        pasará al compilador. Es decir, los dos métodos son pasados al compilador, pero se ejecuta el que corresponda.

    */

    // OJO: Para que esto funcione tiene que estar el define en la linea 1!  Anda para arriba y mira la linea 1 ya!
    //class Program
    //{
    //    [Conditional("VERBOSE"), Conditional("TERSE")]
    //    static void reportHeader()
    //    {
    //        Console.WriteLine("This is the header for the report");
    //    }
    //    [Conditional("VERBOSE")]
    //    static void verboseReport()
    //    {
    //        Console.WriteLine("This is output from the verbose report.");
    //    }
    //    [Conditional("TERSE")]
    //    static void terseReport()
    //    {
    //        Console.WriteLine("This is output from the terse report.");
    //    }
    //    static void Main(string[] args)
    //    {
    //        reportHeader();
    //        terseReport();
    //        verboseReport();
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Testeo de atributos

    /*
        Un programa puede chequear si una clase dada posee un determinado atributo. utilizando el método IsDefined, que un miembro estatico de la
        clase Attribute. IsDefined acepta dos parametros. EL primero es el tipo de la clase que se va a testear, y el segundo es el atributo que la
        clase deberia tener adjunto.
        El ejemplo de abajo demuestra un programa puede chequear que la clase Person contenga adjunto un atributo serializable. Hay que tener en cuenta
        que si biel atributo de llama Serializable, hay que agregarle el texto "Attribute" al final, para pasarlo como parametro.
    */
    //class Program
    //{
    //    [Serializable]
    //    public class Person
    //    {
    //        public string Name;
    //        public int Age;
    //        [NonSerialized]
    //        // No need to save this
    //        private int screenPosition;
    //        public Person(string name, int age)
    //        {
    //            Name = name;
    //            Age = age;
    //            screenPosition = 0;
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
    //            Console.WriteLine("Person can be serialized");
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Creación de atributos

    /*
        Es posible crear nuestros propios attribute, para usarlos de la misma forma de arriba como con el serializable, para marcar que esa clase
        es "algo". Los valores guardados en una instancia atributo, se setean en la metadata de la clase cuando el atributo se carga. Un programa
        podria cambiar ese valor, pero cuando se apague se perdera.

        En el código de abajo se ve crea una clase que hereda de Attribute, que nos sirve para marcar quien fue el programador de la clase.
        Tener en cuenta que en este caso para setear el programador, hay que llamar al constructor.
    */

    //class ProgrammerAttribute : Attribute   //<-- Por convencion se le pone siempre la palabra Attribute, a los attributos.
    //{
    //    private string programmerValue;  //Se podria poner publica, pero igualmente cuando el programa finalice se perdera.
    //    public ProgrammerAttribute(string programmer)
    //    {
    //        programmerValue = programmer;
    //    }
    //    public string Programmer
    //    {
    //        get
    //        {
    //            return programmerValue;
    //        }
    //    }
    //}

    //[ProgrammerAttribute(programmer: "Fred")]  // <-- Aca se esta llamando al constructor
    //class Person
    //{
    //    public string Name { get; set; }
    //}


    #endregion

    #region Control del uso de atributos
    /*
    El ProgrammerAttribute creado arriba puede ser adjuntado a cualquier elemento del programa, incluso a metodos y propiedades.
    A veces, necesitamos que un atributo solo sea aplicable a Clases, o a métodos, etc.  para ello hay que especificarlo al momento de su creación
    a través de otro Attribute llamado AttributeUsage. 
    */
    //[AttributeUsage(AttributeTargets.Class)]
    //class ProgrammerAttribute : Attribute
    //{
    //    //…
    //}
    ////O si se puede aplicar a mas de un elemento usamos | (or)
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    //class FieldOrProp : Attribute
    //{   
    ////…
    //}


    #endregion

    #region Lectura de atributos

    /*
    La clase Attribute provee un método GetCustomAttribute para obtener un Attributo e un tipo determinado. Recibe los mismos parametros que
    isDefined (referencia a la clase a testear, y referencia a la clase attribute que debe tener adjunta), y devuelve una referencia hacia el 
    atributo. Si el atributo no esta definido en esa clase, devuelve null.

    Ejemplo de uso:

    Attribute a = Attribute.GetCustomAttribute( typeof(Person), typeof(ProgrammerAttribute));
    ProgrammerAttribute p = (ProgrammerAttribute)a;   //<-- parece que solo se puede acceder a través de la Interfaz?
    Console.WriteLine("Programmer: {0}", p.Programmer);

    */

    #endregion


    #endregion

    #region Reflection
    /*
    Buscar y leer atributos es un ejemplo de reflection. También puede ser encontrado como Instrospection.
    Se puede usar reflection, por ejemplo, para marcar clases o metodos que necesitan ser testeados, y tambien para especificar como deben ser
    testeados. Tambien puede usarse para identificar automaticamente componentes al estilo "plug-in", de tal forma que una aplicación pueda ser
    creada como la suma de de varios elementos ya creados, y conectados entre ellos.
    Reflection debe considerarse como el punto final del proceso de creación de código como componentes, que implmenta interfaces, y se comunica
    por medio de eventos a los cuales se subscribe o publica.
    */

    #region Utilizando la informacion de tipo de un objeto

    /*
    
        Para comenzar a introducirnos en Reflecciones, consideremos el metodo GetType de un objeto. A través de reflections, el método gettype
        nos brinda informacion de todos los miembros de una clase.

    
    */
    //class Program
    //{
    //    class ProgrammerAttribute : Attribute   //<-- Por convencion se le pone siempre la palabra Attribute, a los attributos.
    //    {
    //        private string programmerValue;  //Se podria poner publica, pero igualmente cuando el programa finalice se perdera.
    //        public ProgrammerAttribute(string programmer)
    //        {
    //            programmerValue = programmer;
    //        }
    //        public string Programmer
    //        {
    //            get
    //            {
    //                return programmerValue;
    //            }
    //        }
    //    }

    //    [ProgrammerAttribute(programmer: "Fred")]  // <-- Aca se esta llamando al constructor
    //    class Person
    //    {
    //        public string Name { get; set; }
    //    }

    //    static void Main(string[] args)
    //    {
    //        System.Type type;
    //        Person p = new Person();
    //        type = p.GetType();
    //        foreach (MemberInfo member in type.GetMembers())
    //        {
    //            Console.WriteLine(member.ToString());
    //        }
    //        Console.ReadKey();

    //    }

    //}



    #endregion

    #region llamada a un metodo a través de refleccion
    /*
    Es posible utilizar la info recolectada desde type, para crear una llamada a un metodo.
    Este codigo es solo un ejemplo, y no tiene sentido por si mismo. Pero sirve para ilustrar la flexibilidad que nos brindan las relfections
    */
    //class Program
    //{
    //    class ProgrammerAttribute : Attribute   //<-- Por convencion se le pone siempre la palabra Attribute, a los attributos.
    //    {
    //        private string programmerValue;  //Se podria poner publica, pero igualmente cuando el programa finalice se perdera.
    //        public ProgrammerAttribute(string programmer)
    //        {
    //            programmerValue = programmer;
    //        }
    //        public string Programmer
    //        {
    //            get
    //            {
    //                return programmerValue;
    //            }
    //        }
    //    }

    //    [ProgrammerAttribute(programmer: "Fred")]  // <-- Aca se esta llamando al constructor
    //    class Person
    //    {
    //        public string Name { get; set; }
    //    }

    //    static void Main(string[] args)
    //    {
    //        System.Type type;
    //        Person p = new Person();
    //        type = p.GetType();
    //        MethodInfo setMethod = type.GetMethod("set_Name");
    //        setMethod.Invoke(p, new object[] { "Fred" });
    //        Console.WriteLine(p.Name);
    //        Console.ReadKey();

    //    }

    //}

    #endregion

    #region Buscando componentes en un Asembly

    /*
    Es posible buscar clases en un assembly o componentes que implementen una determinada interfaz. Esta caracteristica es la base del Managed
    Extensibility Framework o MEF. (Por lo que pude ver, es una forma de extender un programa, sin tener que tocar el codigo. Osea, seria algo
    asi como las extensiones del chrome, le agregas una extension, y empieza a hacer mas cosas, y no se toco el codigo original)

    En el codigo de ejemplo, se buscan todas las clases que implementen la interfaz IAccount.

    Tambien sería posible hacer una busqueda en un assembly que no este cargado, especificando el directorio donde debe buscar el dll, y luego algo
    como esto:

    Assembly bankTypes = Assembly.Load("BankTypes.dll");

    EJEMPLO ARITA --> typeof(ARITA.Web.MvcApplication).Assembly;

    */

    //public class Program
    //{
    //    public interface IAccount
    //    {
    //        void PayInFunds(decimal amount);
    //        bool WithdrawFunds(decimal amount);
    //        decimal GetBalance();
    //    }
    //    public class BankAccount : IAccount
    //    {
    //        private decimal _balance = 0;
    //        public BankAccount(decimal initialBalance)
    //        {
    //            _balance = initialBalance;
    //        }
    //        bool IAccount.WithdrawFunds(decimal amount)
    //        {
    //            if (_balance < amount)
    //            {
    //                return false;
    //            }
    //            _balance = _balance - amount;
    //            return true;
    //        }
    //        void IAccount.PayInFunds(decimal amount)
    //        {
    //            _balance = _balance + amount;
    //        }
    //        decimal IAccount.GetBalance()
    //        {
    //            return _balance;
    //        }
    //    }

    //    //Ejemplo de herencia
    //    public class BabyAccount : BankAccount, IAccount //<-- BabyAccount esta heredando de BankAccount, e implementando IAccount
    //    {
    //        public virtual void PrintAnything()
    //        {
    //            Console.WriteLine("Anything");
    //        }

    //        public BabyAccount(int initialBalance) : base(initialBalance)
    //        {
    //        }
    //    }

    //    static void Main(string[] args)
    //    {

    //        Assembly thisAssembly = Assembly.GetExecutingAssembly();
    //        List<Type> AccountTypes = new List<Type>();
    //        foreach (Type t in thisAssembly.GetTypes())
    //        {
    //            if (t.IsInterface)
    //                continue;
    //            if (typeof(IAccount).IsAssignableFrom(t))
    //            {
    //                AccountTypes.Add(t);
    //                Console.WriteLine(t.FullName);
    //            }
    //        }

    //        var AccountTypesWithLINQ = from type in thisAssembly.GetTypes()
    //                           where typeof(IAccount).IsAssignableFrom(type) && !type.IsInterface
    //                           select type;

    //        Console.WriteLine("Con LINQ");
    //        foreach (var item in AccountTypesWithLINQ)
    //        {
    //            Console.WriteLine(item.Name);

    //        }

    //        Console.WriteLine("Con LINQ y Lambda");
    //        var AccountTypesWithLINQLambda = thisAssembly.GetTypes().Where(x => !x.IsInterface && typeof(IAccount).IsAssignableFrom(x)).ToList();
    //        foreach (var item in AccountTypesWithLINQLambda)
    //        {
    //            Console.WriteLine(item.Name);
    //        }


    //        Console.ReadKey();
    //    }
    //}

    #endregion



    #endregion

    #region Generación de código en tiempo de ejecución

    /*
    Esto se utiliza para meta-programación. Es decir, programas que hacen programas. En esta sección se consideraran dos técnicas de generacion de
    código: Code Document Object Model (CodeDOM) y Lambda Expressions.

     */

    #region CodeDOM

    /*
    Un modelo de objetos Documento, es la representación de la estructura de un tipo de documento en particular. El objeto contiene collecciones de
    otros objetos, que representan el contenido del documento. Hay varios modelos de objetos documento como por ejemplo XML, HTML o JSON.
    En este caso CodeDOM se utiliza para representar la estructura de clases.

    Un objeto CodeDOM puede parsearse para convertirse en codigo fuente, o en un assembly. Las estructuras utilizadas en CodeDom representan la
    estructura lógica del código a implementar, y son independientes de la sintaxis del lenguaje de alto nivel que se utilice para crear el documento.
    Es decir que a partir de un objeto CodeDom podria crearse codigo fuente en c# o en vb. 

    El siguiente ejemplo muestra como se crea un objeto CodeDOM. CodeCompileUnit se crea primero que nada, luego el spacename, y despues se va
    generando el documento como el ejemplo. Obviamente hay elementos para cada linea que se desea escribir. Esto es apenas un pequeño ejemplo. 


    */

    //public class Program {

    //    static void Main(string[] args) {

    //        CodeCompileUnit compileUnit = new CodeCompileUnit();
    //        // Create a namespace to hold the types we are going to create
    //        CodeNamespace personnelNameSpace = new CodeNamespace("Personnel");
    //        // Import the system namespace
    //        personnelNameSpace.Imports.Add(new CodeNamespaceImport("System"));

    //        // Create a Person class
    //        CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
    //        personClass.IsClass = true;
    //        personClass.TypeAttributes = System.Reflection.TypeAttributes.Public;

    //        // Add the Person class to personnelNamespace
    //        personnelNameSpace.Types.Add(personClass);

    //        // Create a field to hold the name of a person
    //        CodeMemberField nameField = new CodeMemberField("String", "name");
    //        nameField.Attributes = MemberAttributes.Private;
    //        // Add the name field to the Person class
    //        personClass.Members.Add(nameField);
    //        // Add the namespace to the document
    //        compileUnit.Namespaces.Add(personnelNameSpace);

    //        /*
    //        Una vez el objeto CodeDom se ha creado se puede crear un CodeDomProvider para producir codigo desde el objeto CodeDom. Lo que hace es
    //        enviar el codigo a un string, y luego lo muestra en pantalla.
    //        */

    //        // Create a provider to parse the document
    //        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
    //        // Give the provider somewhere to send the parsed output
    //        StringWriter s = new StringWriter();
    //        // Set some options for the parse - we can use the defaults
    //        CodeGeneratorOptions options = new CodeGeneratorOptions();
    //        // Generate the C# source from the CodeDOM
    //        provider.GenerateCodeFromCompileUnit(compileUnit, s, options);
    //        // Close the output stream
    //        s.Close();

    //        // Print the C# output
    //        Console.WriteLine(s.ToString());
    //        Console.ReadKey();

    //    }
    //}


    #endregion

    #region Lambda Trees

    /*
    Como se vio arriba, la estructura de un objeto CodeDom, es como un tree.  Las expresiones lambda tambien trabajan en estas estructuras
    de arbol, y se pueden hacer cosas como estas:
    */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // build the expression tree:
    //        // Expression<Func<int,int>> square = num => num * num;
    //        // The parameter for the expression is an integer
    //        ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
    //        // The opertion to be performed is to square the parameter
    //        BinaryExpression squareOperation = Expression.Multiply(numParam, numParam);
    //        // This creates an expression tree that describes the square operation
    //        Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(squareOperation, new ParameterExpression[] { numParam });
    //        // Compile the tree to make an executable method and assign it to a delegate
    //        Func<int, int> doSquare = square.Compile();
    //        // Call the delegate
    //        Console.WriteLine("Square of 2: {0}", doSquare(2));
    //        Console.ReadKey();
    //    }
    //}

    /*
    Una vez creado a un expression tree, este no puede modificarse. Si se desea modificar, es necesario hacer una copia, y agregarla las extensiones
    necesarias a la copia. Puede verse un poco mas de esto en la Pag 196. Es complejo y por ahora no tiene mucho sentido detenerse aca.
    */

    #endregion

    #endregion

    #region Uso de los tipos provistos por System.Reflection

    #region Assembly

    /*
    Un Assembly es la salida que se produce cuando un programa .net se compila. El tipo Assembly representa el contenido de un assembly, que
    puede ser que se esta ejecutando, o uno cargado desde algun archivo.
    La clase Assembly provee una forma de que los programas puedan usar reflection en un assembly. Contiene métodos y propiedades para administrar
    veriones,  dependencias, y la definición de cualquier tipo que declare.
    En el codigo de ejemplo se usa el assembly actual, y se buscan los modulos y tipos definidos.
    */
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Assembly assembly = Assembly.GetExecutingAssembly();
    //        Console.WriteLine("Full name: {0}", assembly.FullName);
    //        AssemblyName name = assembly.GetName();
    //        Console.WriteLine("Major Version: {0}", name.Version.Major);
    //        Console.WriteLine("Minor Version: {0}", name.Version.Minor);
    //        Console.WriteLine("In global assembly cache: {0}", assembly.GlobalAssemblyCache);
    //        foreach (Module assemblyModule in assembly.Modules)
    //        {
    //            Console.WriteLine(" Module: {0}", assemblyModule.Name);
    //            foreach (Type moduleType in assemblyModule.GetTypes())
    //            {
    //                Console.WriteLine(" Type: {0}", moduleType.Name);
    //                foreach (MemberInfo member in moduleType.GetMembers())
    //                {
    //                    Console.WriteLine(" Member: {0}", member.Name);
    //                }
    //            }
    //        }
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region PropertyInfo
    /*
    Una propiedad en c# provee una forma rapida de crear get y set de una variable de determinado tipo. PropertyInfo nos da los detalles sobre esas
    propiedades, incluido la informacion de los metodos get y set si estan presentes.
    */

    //public class Person
    //{
    //    public String Name { get; set; }
    //    public String Age { get; }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Type type = typeof(Person);
    //        foreach (PropertyInfo p in type.GetProperties())
    //        {
    //            Console.WriteLine("Property name: {0}", p.Name);
    //            if (p.CanRead)
    //            {
    //                Console.WriteLine("Can read");
    //                Console.WriteLine("Set method: {0}", p.GetMethod);
    //            }
    //            if (p.CanWrite)
    //            {
    //                Console.WriteLine("Can write");
    //                Console.WriteLine("Set method: {0}", p.SetMethod);
    //            }
    //        }
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region MethodInfo
    /* Brinda la información acerca de los métodos*/

    //public class Calculator
    //{
    //    public int AddInt(int v1, int v2)
    //    {
    //        return v1 + v2;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Get the type information for the Calculator class");
    //        Type type = typeof(Calculator);
    //        Console.WriteLine("Get the method info for the AddInt method");
    //        MethodInfo AddIntMethodInfo = type.GetMethod("AddInt");
    //        Console.WriteLine("Get the IL instructions for the AddInt method");
    //        MethodBody AddIntMethodBody = AddIntMethodInfo.GetMethodBody();
    //        // Print the IL instructions.
    //        foreach (byte b in AddIntMethodBody.GetILAsByteArray())
    //        {
    //            Console.Write(" {0:X}", b);
    //        }
    //        Console.WriteLine();
    //        Console.WriteLine("Create Calculator instance");
    //        Calculator calc = new Calculator();
    //        Console.WriteLine("Create parameter array for the method");
    //        object[] inputs = new object[] { 1, 2 };
    //        Console.WriteLine("Call Invoke on the method info");
    //        Console.WriteLine("Cast the result to an integer");
    //        int result = (int)AddIntMethodInfo.Invoke(calc, inputs);
    //        Console.WriteLine("Result of: {0}", result);
    //        Console.WriteLine("Call InvokeMember on the type");
    //        result = (int)type.InvokeMember("AddInt", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, calc, inputs);
    //        Console.WriteLine("Result of: {0}", result);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #endregion

}
