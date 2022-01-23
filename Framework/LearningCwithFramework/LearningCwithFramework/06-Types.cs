using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{

    #region struct vs class

    /*
    
                Structs                                         |                           Clases

        -Las variables de un struct son pasadas por valor       |   -Las variables de un struct son pasadas por referencia
        -El constructor de un struct debe inicializar todos     |   -Sus miembros pueden no estar inicializados
        sus miembros, no se pueden inicializar en la estructura |
        -Su constructor siempre recibe parametros, a menos      |   -Su constructor puede no recibir parametros
        que tenga un cosntructor sin parametros que inicializa  |
        sus miembros con los valores por defecto.(cero para     |
        numeros y null para strings                             |
        -No es posible crear un struct extendiendo un padre     |   -Se puede crear una clase extendiendo su clase padre
        struct                                                  |
        -Las instancias de un struct generalmente se crean en   |
        el stack del programa, a menos que sean usados en       |
        clousures. Un array de instancias de structs se creara  |
        como un bloque de direcciones de memoria contiguas      |
        (ver esto en "memory allocation")
     
     
     */


    //Ejemplo de pasaje por valor y por referencia

    //class Prog
    //{
    //    struct StructStore
    //    {
    //        public int Data { get; set; }
    //    }
    //    class ClassStore
    //    {
    //        public int Data { get; set; }
    //    }
    //    static void Main(string[] args)
    //    {
    //        StructStore xs, ys;
    //        ys = new StructStore();
    //        ys.Data = 99;
    //        xs = ys;
    //        xs.Data = 100;
    //        Console.WriteLine("xStruct: {0}", xs.Data);
    //        Console.WriteLine("yStruct: {0}", ys.Data);
    //        ClassStore xc, yc;
    //        yc = new ClassStore();
    //        yc.Data = 99;
    //        xc = yc;
    //        xc.Data = 100;
    //        Console.WriteLine("xClass: {0}", xc.Data);
    //        Console.WriteLine("yClass: {0}", yc.Data);
    //        Console.ReadKey();
    //    }
    //}



    //Ejemplo de creacion de struct con constructor vacio que inicializa en defaults

    //struct Alien
    //{
    //    public int X;
    //    public int Y;
    //    public int Lives;
    //    public Alien(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //        Lives = 3;
    //    }
    //    public override string ToString()
    //    {
    //        return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
    //    }
    //}
    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        Alien a;
    //        a.X = 50;
    //        a.Y = 50;
    //        a.Lives = 3;
    //        Console.WriteLine("a {0}", a.ToString());
    //        Alien x = new Alien(100, 100);
    //        Console.WriteLine("x {0}", x.ToString());
    //        Alien[] swarm = new Alien[100];
    //        Console.WriteLine("swarm [0] {0}", swarm[0].ToString());
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region tipos inmutables

    /*
       Los tipos inmutables son aquellos que una vez creados no pueden editarse. Un ejemplo de ellos es DateTime. Uno puede pensar que al poner
       algo como miFecha = miFecha.AddDays(1);  esta editando miFecha, pero en realidad miFecha.AddDays() crea un nuevo objeto y se lo asigna
       a miFecha.   Si uno intentara hacer algo como miFecha.Month = 3;  no funciona, ya que Month no tiene el set, solo el get.

       Los tipos inmutables pueden ser utiles para trabajar con concurrencia (multihilos) ya que al no poder inmutarse, no podrian causar
       corrupcion de datos en condiciones de carrera.  Se hablará de esto mas adelante.

    */

    #endregion

    #region Enumerated Types

    ///*

    //Son utilizados en situaciones donde el programador quiere especificar un rango de valores que un determinado tipo puede tener.
    //Ejemplo con enum de tres estados:
    //*/

    //    ////Se pueden crear de esta forma, y por defecto tendran un valor int 0 ,1 y 2 o se puede especificar otra cosa como abajo
    ////enum AlienState
    ////{
    ////    Sleeping,
    ////    Attacking,
    ////    Destroyed
    ////};
    //enum AlienState : byte
    //{
    //    Sleeping = 1,
    //    Attacking = 2,
    //    Destroyed = 4
    //};
    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        AlienState x = AlienState.Attacking;
    //        Console.WriteLine(x);
    //        Console.ReadKey();
    //    }
    //}



    #endregion

    #region creando tipos de referencia

    /*
        La base en C# de un tipo de referencia es la Clase. No hay mucho que decir sobre la clase, pag 127 
    */

    #endregion

    #region Memory allocation

    /*
     
    La memoria utilizada para guardar las variables de tipo valor se encuentra en el stack (del micro supongo). Stack es una área de memoria donde los
    programas guardan y remueven bloques. Cualquier variable de tipo valor creada durante la ejecucion de un programa, va aparar a un stack frame local,
    y el frame completo es descartado cuando el bloque termina.

    La memoria utilizada para guardar variables de tipo referencia se encuentra en el heap. El heap es administrado por una aplicación completa.
    El heap es necesario, porque cono las referencias pueden ser pasadas como parámetros en llamadas a metodos, no puden ser descartadas cuando un
    método termina. Los objetos solo se remueven del heap cuando el recolector de basura que ya no hay referencias hacia ese objeto.

     */

    #endregion

    #region tipo Generic 

    /*
    
    Los tipo generic se usan frecuentemente en las colecciones de c#, con ellas podemos crear listas de cualquier tipo de dato o diccionarios
    de cualquier tipo de dato indexado a cualquier tipo de dato. Si no fuera por generic, seria necesario escrirbir una clase para cada tipo de dato
    Esto queda más claro en el ejemplo de abajo, donde se crea un stack de tipo <T>, para que pueda instanciarse con cualquier tipo de dato.

    */
    //class Prog
    //{
    //    class MyStack<T>
    //    {
    //        int stackTop = 0;
    //        T[] items = new T[100];
    //        public void Push(T item)
    //        {
    //            if (stackTop == items.Length)
    //                throw new Exception("Stack full");
    //            items[stackTop] = item;
    //            stackTop++;
    //        }
    //        public T Pop()
    //        {
    //            if (stackTop == 0)
    //                throw new Exception("Stack empty");
    //            stackTop--;
    //            return items[stackTop];
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        MyStack<string> nameStack = new MyStack<string>();
    //        nameStack.Push("Rob");
    //        nameStack.Push("Mary");
    //        Console.WriteLine(nameStack.Pop());
    //        Console.WriteLine(nameStack.Pop());
    //        Console.ReadKey();
    //    }
    //}


    #region contraints

    /*
    
    En el ejemplo anterior el stack podria ser de cualquier tipo de dato. Si quisieramos restringirlo para que solamente almacene referencias, se
    puede agregar unas restriccion (contraint) con los posibles tipos de datos que <T> puede representar.
    La restriccion se expresa de esta forma:
        class MyStack<T> where T:class

    valores posibles:
    T:class     -> El tipo T debe ser un tipo referencia
    T:struct    -> El tipo T debe ser un tipo valor
    T:new()     -> El tipo T en este caso debe tener un constructor publico, sin parametros. Si se usa una lista de constraints este va último.
    T:<base class>      -> El tipo T debe ser una clase base, o derivado de una.
    T:<interface name>  -> El tipo T debe ser o implementar la interface. Se pueden poner varias interfaces.
    T:unmanaged     ->El tipo T no puede ser una referencia ni contener ningun miembro que sea una referencia.



    */

    #endregion





    #endregion

    #region Constructores

    /*
    
    En el ejemplo de abajo la clase alien tiene dos constructores. Uno recibe tres parametros, y el otro solo dos.

     */

    //class Alien
    //{
    //    public int X;
    //    public int Y;
    //    public int Lives;
    //    public Alien(int x, int y, int lives)
    //    {
    //        if (x < 0 || y < 0)
    //            throw new ArgumentOutOfRangeException(“Invalid position”);
    //        X = x;
    //        Y = y;
    //        Lives = lives;
    //    }
    //    public Alien(int x, int y)
    //    {
    //        X = x;
    //        Y = y;
    //        Lives = 3;
    //    }
    //}


    /*
    
    Es posible hacer que un constructor llame a otro, a través de this. Como se muestra en el siguiente ejemplo:
    
    */

    //class Alien
    //{
    //    public int X;
    //    public int Y;
    //    public int Lives;
    //    public Alien(int x, int y, int lives)
    //    {
    //        if (x < 0 || y < 0)
    //            throw new ArgumentOutOfRangeException("Invalid position");
    //        X = x;
    //        Y = y;
    //        Lives = lives;
    //    }
    //    public Alien(int x, int y) : this(x, y, 3)   // <-- Aca se pasa los parametros que recibio, mas uno adicional, el otro constructor
    //    {
    //    }
    //    public override string ToString()
    //    {
    //        return string.Format("X: {0} Y: {1} Lives: {2}", X, Y, Lives);
    //    }
    //}


    #endregion

    #region constructores estáticos

    /*
    
    Una clase puede contener un constructor marcado como static. Este constructor se ejecutará solamente la primera vez que se cree una instancia
    de esta clase. Estos constructores son utiles para inicializar propiedades que también estén marcadas como static.
    
    */

    //class Alien
    //{
    //    // Alien code here
    //    static Alien()
    //    {
    //        Console.WriteLine("Static Alien constructor running");
    //    }
    //}


    #endregion

    #region Otros

    /*
    Algunas cosas que no vale la pena mensionar:
        static properties and methods Pag 133
        Method Pag 134
        Class Pag 135
        Parametros opcionales y parametros con nombre Pag 137
        Overload and overriden methods Pag 140

     
    */

    #endregion

    #region Extension Methods

    /*
    Una clase puede proveer métodos, para que otra clase los use (Esto se vera mas adelante en herencia). Sin embargo, los métodos de extension
    nos proveen con una forma de hacer que nuevos comportamientos (métodos) puedan ser añadidos a una clase, sin necesidad de extender la clase
    en sí misma.
    El primer parámetro que el método extendido recibe, especifica el tipo de dato (en este caso la clase) al cual el método extendido deberia
    añadirse, utilizando la palabra reservada this seguida del nombre del tipo de dato. Ver ejemplo abajo.
    Tener en cuenta que para que funcione el ejemplo hay que descomentar el namespace de mas abajo, que dice ExtensionMethod

    */

    //   using ExtensionMethods;
    //class Prog
    //   {
    //       static void Main(string[] args)
    //       {
    //           string text = @"A rocket explorer called Wright, 
    //           Once travelled much faster than light,
    //           He set out one day, In a relative way,
    //           And returned on the previous night";
    //           Console.WriteLine("El texto se dispersa en " + text.LineCount() + " renglones");
    //           Console.ReadKey();
    //       }
    //   }


    #endregion

    #region Propiedades indexadas

    /*

    Un programa puede acceder a un elemento en particular de un array, utilizando el indice que identifica al elemento: array[0] = 99;

    Una clase, puede utilizar este mismo mecanismo para acceder a una propiedad indexada. EN el ejemplo de abajo la clase IntArrayWrapper
    envuelve un array de enteros. La propiedad indexada acepta un valor entero que se utiliza para indexar el array que guarda el valor.

    De la misma forma, pero pasando un string como indice, podemos crear un diccionario. 
        
     */

    //class IntArrayWrapper
    //{
    //    // Create an array to store the values
    //    private int[] array = new int[100];
    //    // Declare an indexer property
    //    public int this[int i]
    //    {
    //        get { return array[i]; }
    //        set { array[i] = value; }
    //    }
    //}
    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        IntArrayWrapper x = new IntArrayWrapper();
    //        x[0] = 99;
    //        Console.WriteLine(x[0]);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

}

//namespace ExtensionMethods
//{
//    public static class MyExtensions
//    {
//        public static int LineCount(this String str)
//        {
//            return str.Split(new char[] { '\n' },
//            StringSplitOptions.RemoveEmptyEntries).Length;
//        }
//    }
//}
