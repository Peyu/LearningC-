using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LearningCwithFramework
{
    class LearningTasks
    {
        #region TASK simple
        ////The code in Listing 1-11 creates a task, starts it running, and then waits for the task to complete.
        //public static void DoWork()
        //{
        //    Console.WriteLine("Work starting");
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Work finished");
        //}
        ////static void Main(string[] args)
        ////{
        ////    Task newTask = new Task(() => DoWork());
        ////    newTask.Start();
        ////    newTask.Wait();
        ////    Console.ReadKey();
        ////}

        ////variante de Main ejecutando y creandose en un mismo metodo run
        //static void Main(string[] args)
        //{
        //    Task newTask = Task.Run(() => DoWork());
        //    newTask.Wait();
        //    Console.ReadKey();
        //}

        #endregion

        #region Task con retorno de valor

        //public static int CalculateResult()
        //{
        //    Console.WriteLine("Work starting");
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Work finished");
        //    return 99;
        //}
        //static void Main(string[] args)
        //{
        //    Task<int> task = Task.Run(() =>
        //    {
        //        return CalculateResult();
        //    });
        //    Console.WriteLine(task.Result);
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}


        #endregion

        #region TASK con waitall

        //public static void DoWork(int i)
        //{
        //    Console.WriteLine("Task {0} starting", i);
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Task {0} finished", i);
        //}
        //static void Main(string[] args)
        //{
        //    //se crea un array de 10 Tasks
        //    Task[] Tasks = new Task[10];

        //    //se mandan a ejecutar todas las tasks del array
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int taskNum = i; // make a local copy of the loop counter so that the
        //                         // correct task number is passed into the lambda expression
        //        Tasks[i] = Task.Run(() => DoWork(taskNum));
        //    }

        //    Task.WaitAll(Tasks);
        //    //Task.WaitAll espera a que se ejecute todo el array de tareas, y recien entonces continua con el flujo.
        //    //Probablemente se pueda conseguir lo mismo con un parallel for (?)
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();

        //    //Una variante de esto es terminar con Task.WaitAny en donde el flujo se detiene hasta que un determinado numero de
        //    //tasks terminan, y luego el flujo prosigue.  OJO, las tareas que aun no han terminado, siguen corriendo hasta terminar


        //}

        #endregion

        #region Continuation task / ContinueWith Method
        //public static void HelloTask()
        //{
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Hello");
        //}
        //public static void WorldTask()
        //{
        //    Thread.Sleep(1000);
        //    Console.WriteLine("World");
        //}
        //public static void ExceptionTask()
        //{
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Exception found");
        //}
        //static void Main(string[] args)
        //{
        //    Task task = Task.Run(() => HelloTask());
        //    //task.ContinueWith((prevTask) => WorldTask()); //este "prevTask" puede ser cualquier cosa, es una referencia hacia
        //                                                  //la primer tarea, que la segunda necesita recibir, podria ser t, tarea, loquevenga

        //    //ver nota abajo
        //    task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);
        //    task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);

        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}


        ////El método ContinueWith tiene una sobrecarga, que acepta un type TaskContinuationOptions, donde se especifica
        ////a que tarea llamar si salta una excepcion en la tarea previa
        ////task.ContinueWith((prevTask) => ExceptionTask(), TaskContinuationOptions.OnlyOnFaulted);
        ////o a que tarea llamar si sale todo bien.
        ////task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);


        #endregion

        #region Child Tasks
        ///*EL codigo corriendo dentro de una task, puede crear otras tasks.  Estas task hijas, pueden ser "attached" o "detached" a
        //sus padres.  En las attached, el padre no terminara su ejecución, hasta que no se hayan completado sus hijos.
        // */

        ///*
        //Las tareas hijas se crean utilizando la sobrecarga del método Task.Factory.StartNew que acepta tres parametros, 
        //el primero es funcion lambda con el comportamiento, el segundo es un objeto con el estado (en este ejemplo se le pasa un int)
        //y el tercero es un valor TaskCreationOption donde se especifica que la tarea creada es una tarea HIJA attached
        //OJO, por defecto las tareas hijas son detached!! Por eso las tareas creadas con Task.Run, son detached.
        //*/

        //public static void DoChild(object state)
        //{
        //    Console.WriteLine("Child {0} starting", state);
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Child {0} finished", state);
        //}
        //static void Main(string[] args)
        //{
        //    var parent = Task.Factory.StartNew(() => {
        //        Console.WriteLine("Parent starts");
        //        for (int i = 0; i < 10; i++)
        //        {
        //            int taskNo = i;
        //            Task.Factory.StartNew(
        //            (x) => DoChild(x), // lambda expression
        //            taskNo, // state object
        //            TaskCreationOptions.AttachedToParent);   //Especifica tareas hijas attached
        //            //TaskCreationOptions.DenyChildAttach);  //Especifica tareas hijas detached
        //        }
        //    });
        //    parent.Wait(); // will wait for all the attached children to complete
        //    Console.WriteLine("Parent finished. Press a key to end.");
        //    Console.ReadKey();
        //}


        #endregion


    }
}
