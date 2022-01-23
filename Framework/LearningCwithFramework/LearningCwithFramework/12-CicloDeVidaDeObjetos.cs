using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _12_CicloDeVidaDeObjetos
    {
    }

    #region Intro
    /*
     C#, a diferencia de otros lenguajes como c++, administran la memoria de forma automatica, por lo que no hay necesidad de andar destruyendo objetos.
     Sin embargo, los objetos pueden utilizar algunos recursos, que deben liberarse antes de que el recolector de basura se deshaga de ellos cuando
     corresponda. C# provee finalizadores que se van a ejecutar en el momento en que un objeto es quitado de memoria por el recolector de basura. Esto
     unido a lo que ya vimos con IDisposable, nos da las herramientas para liberar la memoria de forma adecuada.
    */
    #endregion

    #region Recolector de Basura

    /*
    Para entender y jugar un poco con el recolector de basura, el programa de abajo va creando objetos sobre la misma referencia p. Esto hace que 
    cada objeto nuevo sea inalcanzable ya que p, y el recolector de basura puede limpiarlo. Si ejecutamos el proyecto a traves de la pestaña analizar
    con el generador de perfiles de rendimiento y habilitamos el uso de memoria, se ve un lindo cuadrito que muesta que cada vez que sube el consumo de 
    memoria, vuelve a bajar. Esto es porque el recolector de basura esta eliminando los objetos.
    
        Cada programa tiene un espacio preestablecido de memoria donde se le permite trabajar, y cuando ese espacio se va quedando corto, el recolector
    sale al rescate. Recordemos que las referencias a un objeto se guardan en el Heap de la memeoria, a diferencia de los valores que se guaradn en 
    el stack. Para vaciar el Heap es que pasa el recolector.
    
        El recolector no solo limpia los objetos inalcanzables, sino que tambien "defragmenta" el heap de la memoria. A este proceso de "defragmentar" se
    lo llama "compactar" y deja en lo posible, un solo gran fragmento de memoria disponible.
    El proceso de recoleccion sería mas o menos asi: Primero se marcan (flag) los objetos inalcanzables,  se borran
    los marcados y luego se "compacta" la memoria intentando dejar un solo bloque. Los objetos que no fueron marcados, se mueven al comienzo del stack.
    Todos los Hilos (los managed) son pausados hasta que termine el trabajo del recolector, lo que puede hacer que el programa deje de responder durante
    algunos instantes.  

        Se puede llamar al recolector de basura manualmente, si sabemos que una buena cantidad de objetos serán inalcanzables en algun momento.
        El recolector marca el tiempo que un objeto a sobrevivido en el heap con generaciones. Un objeto generacion 1, ha sobrevivido a una limpieza.
    Un Objeto generacion 4, ha sobrevivido a 4, y asi...  Una limpieza de nivel 3, solo limpia la generacion 3 en adelante (siempre de los inalcanzables)

        Debido a que  los sistemas actuales tienen gran capacidad de memoria y procesamiento, se recomienda no preocuparse por el proceso
     de recoleccion de abusra, a menos que encontremos un problema. En cuyo caso, se puede disparar el recolector manualmente con 

        GC.Collect();
        
    */
    //class Person
    //{
    //    long[] personArray = new long[1000000];
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        for (long i = 0; i < 1000000000000; i++)
    //        {
    //            Person p = new Person();
    //            System.Threading.Thread.Sleep(1);

    //        }
    //    }
    //}


    #endregion

    #region Manejo de recursos no administrados

    /*
        Hay dos formas de liberar recursos. Finalizer o Disposable
    */

    #region Finalizer
    /*
    La finalizacion de un objeto es disparada por el recolector de basura. Un objeto puede tener un método finalizer que se invoca
    desde el recolector de basura antes de ser borrado de la memoria. El método finalizador no tiene tipo, y tiene el mismo nombre
    que la clase precedido por un (~) .  (Similar a un constructor, de hecho, seria un destructor, pero no necesita el public)
    
    Ejemplo en código 
    */
    //public class Person
    //{
    //    long[] personArray = new long[1000000];

    //    ~Person()
    //    {
    //        // This is where the person would be finalized
    //        Console.WriteLine("Finalizer called");
    //    }
    //}

    /*
    Posibles problemas con finalizador:   Cuando se ejecuta el recolector, primero se identifican todos los objetos con 
    finalizers, y se guardan en una Cola. Luego se lanza un hilo que ejecutara todos los finalizers de la cola. No hay
    garantias de cuando ese hilo se va a ejecutar, y si ademas la logica que contiene el finalizer es muy lenta, puede
    relentizar todo. Y mientras no se ejecute el finalizer, los objetos seguiran en memoria.
    Otra desventaja: No hay garantia de que el finalizer se ejecute. Si el sistema no necesita recursos de memoeria, el
    recolector no va a pasar, y por lo tanto, tampoco se va a correr el finalizador.
    */

    #endregion

    #region IDisposable

    /*
    Ver IDIsposable en la parte de Herencia
    */
    /*
     En algunos casos, es posible que queramos implementar IDisposable junto con un finalizer. Esto puede traer algunos problemas
     ya que tal vez se intenten liberar dos veces los mismos recursos. Para evitar esto hay que seguir un patron de diseño 
     llamado dispose pattern, en donde un método surpressFinalize sirve para identificar un objeto que no sera finalizado
     por el recolector de basura.
     El patron hace uso de un flag, que cuando es dispuesto, queda marcado como disposed, y no se ejecutara su finalize.
     Ejemplo de codigo:
     */

    //class ResourceHolder : IDisposable
    //{
    //    // Flag to indicate when the object has been
    //    // disposed
    //    bool disposed = false;
    //    public void Dispose()
    //    {
    //        // Call dispose and tell it that
    //        // it is being called from a Dispose call
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //    public virtual void Dispose(bool disposing)
    //    {
    //        // Give up if already disposed
    //        if (disposed)
    //            return;
    //        if (disposing)
    //        {
    //            // free any managed objects here
    //        }
    //        // Free any unmanaged objects here
    //    }
    //    ~ResourceHolder()
    //    {
    //        // Dispose only of unmanaged objects
    //        Dispose(false);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ResourceHolder r = new ResourceHolder();
    //        r.Dispose();
    //    }
    //}


    #endregion


    #endregion

    #region Manejo del recolector
    /*
     El recolector de basura se puede disparar con 
     GC.Collect()
     Pero tambien puede dispararse espeificandole que lo haga despues de esperar los finalizadores
     GC.WaitForPendingFinalizers();
     Como hemos visto, en algunos casos puede ser util especificar que cierto objeto (por ejemplo p) no debe correr su
     finalizer, en ese caso usariamos
     GC.SurpressFinalize(p);
     Y si luego tenemos que re-registrarlo en la ejecucion del finalizer
     GC.ReRegisterForFinalize(p);

     */
    
    #endregion

}
