using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _07_ConsumoDeTipos
    {

    }

    #region Boxing and unboxing

    /*
    
    Hemos visto en types que algunas variables como int, float, structs, etc se pasan por valor, mientras que las clases por referencia. Sin embargo
    a veces puede ser util, pasar un int por referencia por ejemplo. para eso, el runtime utiiza boxing y unboxing.
    En el ejemplo de abajo, se guarad el valor 99 en un objeto, y luego se castea a un integer.
    */

    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        // the value 99 is boxed into an object
    //        object o = 99;
    //        // the boxed object is unboxed back into an int
    //        int oVal = (int)o;
    //        Console.WriteLine(oVal);
    //        Console.ReadKey();
    //    }
    //}

    /*
    
    Mas alla de este ejemplo, internamente, el clr esta realizando las tareas de boxing y unboxing del valor de forma automática. Internamente,
    cada tipo predefinido (buit-in) matchea con un "tipo interface" al que se castea en el proceso de boxing. Por ejemplo el tipo interface,
    para un int es el Int32. y para un long Int64
    Todas estas operaciones se producen internamente y no hay que darles mucha bola, sin embargo es importante entender que se estan realizando,
    y que un programa en donde hay mucho casteo, puede disminuir considerablemente su velocidad.
    */


    #endregion

    #region Cast types

    /*
        Hay dos tipos de cast.  Narrowing y widening.
        Narrowing es cuando una variable pierde parte de su valor Ej
        
        float x = 9.9f;
        int i = x;
    
        y widening es lo opuesto.

        Esto es importante para entender Convert types

    
    */

    #endregion

    #region Convert Types

    /*
    Pag 147
    El runtime de .net provee métodos de conversión predefinidos que utilizadmos todo el tiempo. Pero que pasa cuando queremos programar
    nuestra propia forma de convertir de un tipo a otro? Podemos lograrlo marcando nuestros metodos como implicit y explicit operators.

    Un operador implicito se utiliza para cast de tipo widening, mientras que el explicito para narrowindg, ya que como se perdera valor
    durante la operacion, debe ser explicito.
    
    */


    //class Miles
    //{
    //    public double Distance { get; }
    //    // Conversion operator for implicit converstion to Kilometers
    //    public static implicit operator Kilometers(Miles t)
    //    {
    //        Console.WriteLine("Implicit conversion from miles to kilometers");
    //        return new Kilometers(t.Distance * 1.6);
    //    }
    //    public static explicit operator int(Miles t)
    //    {
    //        Console.WriteLine("Explicit conversion from miles to int");
    //        return (int)(t.Distance + 0.5);
    //    }
    //    public Miles(double miles)
    //    {
    //        Distance = miles;
    //    }
    //}
    //class Kilometers
    //{
    //    public double Distance { get; }
    //    public Kilometers(double kilometers)
    //    {
    //        Distance = kilometers;
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Miles m = new Miles(100);
    //        Kilometers k = m; // implicity convert miles to km
    //        Console.WriteLine("Kilometers: {0}", k.Distance);
    //        int intMiles = (int)m; // explicitly convert miles to int
    //        Console.WriteLine("Int miles: {0}", intMiles);
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Manejando tipos Dinamyc
    /*
    
    C# es fuertemente tipado. Esto requiere que al momento de compilacion, el compilador asegure que las operaciones entre tipos pueden ser realziadas.
    Sin embargo, esto trae algunos problemas cuando hay instrucciones de interoperacion con otros programas que no tienen su origen en c# como por
    ejemplo Common Object Model (COM), o Document Object Model (DOM), o cuando se trabaja con objetos generados con c# reflection, o cuando se inter-
    actua con lenguajes dinámicos como javascript.
    En estas situaciones se necesita una forma de forzar al compilador a interactuar con objetos, en donde la informacion acerca del tipo generada
    por c# no esta disponible. La palabra reservada dinamyc es utilizada para identificar items donde el compilador debe suspender  los chequeos de tipo.
    Esto puede ocacionar que hayan errores que no se detecten al momento de la compilacion, pero que igual van a fallar en su momento.

    En el ejemplo de abajo se puede apreciar como el compilador no levanta un error en complilacion, aun cuando no existe una definicion para 
    el metodo Banana. Esto se debe a que d, ha sido declarado como dinamyc y no esta efectuando los chequeos.

    */

    //class MessageDisplay
    //{
    //    public void DisplayMessage(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MessageDisplay m = new MessageDisplay();
    //        m.DisplayMessage("Hello world");
    //        Console.ReadKey();
    //        dynamic d = new MessageDisplay();
    //        d.Banana("hello world");
    //    }
    //}


    /*
    
    Además, en una variable declarada como dinamyc, su tipo es inferido según el contexto de una forma similar a la que usa Python o javascript.
    En el siguiente ejemplo se ve como una variable dinamyc es usada primero como integer, y luego como string.
     
    */

    //class Program {

    //    static void Main(string[] args) {
    //        dynamic d = 99;
    //        d = d + 1;
    //        Console.WriteLine(d);
    //        d = "Hello";
    //        d = d + " Rob";
    //        Console.WriteLine(d);
    //    }
    //}



    #endregion

    #region ExpandoObject

    /*
    La clase ExpandoObject le permite a lo programas agregar propiedad dinamicamente a un objeto. Tambien se pueden crear expandoObject anidados
    si se les agrega otro ExpandoObject como propiedad. ExpandoObject son muy utiles cuando se trabaja con Jsons o XML
    */
    //class Program {

    //    static void Main(string[] args)
    //    {
    //        dynamic person = new ExpandoObject();
    //        person.Name = "Rob Miles";
    //        person.Age = 21;
    //        Console.WriteLine("Name: {0} Age: {1}", person.Name, person.Age);

    //    }
    //}
    #endregion

    #region Interoperability with unmanaged code that accesses COM APIs
    /*
     Esto esta explicado en la Pag 150. Es importante pero no tiene caso transcribirlo, es mejor leerlo entero, no es largo.
     */

    #endregion

}
