using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace LearningCwithFramework
{
    class Programa
    {


        #region USO DE TASK - PARALLEL
        ///// <summary>
        /////EJEMPLO USO DE TASK.  Parallel devuelve el flujo al finalizar todas las tareas 
        ///// </summary>
        //static void Task1()
        //{
        //    Console.WriteLine("Task 1 starting");
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Task 1 ending");
        //}
        //static void Task2()
        //{
        //    Console.WriteLine("Task 2 starting");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Task 2 ending");
        //}
        //
        //static void Main(string[] args)
        //{
        //    Parallel.Invoke(() => Task1(), () => Task2());//
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}
        #endregion

        #region USO DE PARALLEL - FOREACH
        ///// <summary>
        ///// Recibe un item, comienza, espera, termina
        ///// </summary>
        ///// <param name="item"></param>
        //static void WorkOnItem(object item)
        //{
        //    Console.WriteLine("Started working on: " + item);
        //    Thread.Sleep(100);
        //    Console.WriteLine("Finished working on: " + item);
        //}
        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 500);
        //    Parallel.ForEach(items, item =>
        //    {
        //        WorkOnItem(item);
        //    });
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}
        #endregion

        #region USO DE PARALLEL -FOR

        //static void WorkOnItem(object item)
        //{
        //    Console.WriteLine("Started working on: " + item);
        //    Thread.Sleep(100);
        //    Console.WriteLine("Finished working on: " + item);
        //}
        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 500).ToArray();
        //    Parallel.For(0, items.Length, i =>
        //    {
        //        WorkOnItem(items[i]);
        //    });
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}

        #endregion

        #region MANEJO DE PARALLEL FOR
        //static void WorkOnItem(object item)
        //{
        //    Console.WriteLine("Started working on: " + item);
        //    Thread.Sleep(100);
        //    Console.WriteLine("Finished working on: " + item);
        //}
        //static void Main(string[] args)
        //{
        //    var items = Enumerable.Range(0, 500).ToArray();
        //    ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState
        //   loopState) =>
        //    {
        //        if (i == 10)
        //            //loopState.Stop();  //Corta la ejecucion incluyendo las que hayan comenzado
        //            loopState.Break();  //Corta la ejecucion, pero las operaciones que hayan comenzado terminaran
        //        WorkOnItem(items[i]);
        //    });
        //    Console.WriteLine("Completed: " + result.IsCompleted);
        //    Console.WriteLine("Items: " + result.LowestBreakIteration);
        //    Console.WriteLine("Finished processing. Press a key to end.");
        //    Console.ReadKey();
        //}
        #endregion

        #region PARALLEL LINQ
        //class Person
        //{
        //    public string Name { get; set; }
        //    public string City { get; set; }
        //}  
        //static void Main(string[] args)
        //{
        //    Person[] people = new Person[] {
        //    new Person { Name = "Alan", City = "Hull" },
        //    new Person { Name = "Beryl", City = "Seattle" },
        //    new Person { Name = "Charles", City = "London" },
        //    new Person { Name = "David", City = "Seattle" },
        //    new Person { Name = "Eddy", City = "Paris" },
        //    new Person { Name = "Fred", City = "Berlin" },
        //    new Person { Name = "Gordon", City = "Hull" },
        //    new Person { Name = "Henry", City = "Seattle" },
        //    new Person { Name = "Isaac", City = "Seattle" },
        //    new Person { Name = "James", City = "London" }};

        //var result = from person in people.AsParallel() // <-- No implica que se vaya a correr en paralelo. EL sistema lo determina
        //             where person.City == "Seattle"
        //             select person;


        //De esta forma se fuerza el paralelismo, estableciendo como maximo 4 hilos.
        //var result = 
        //    from person in people.AsParallel().WithDegreeOfParallelism(4).WithExecutionMode(ParallelExecutionMode.ForceParallelism)
        //    where person.City == "Seattle"
        //    select person;

        //De esta forma se preserva el orden, pero no significa que se ejecute en orden. Es mas lento
        //var result = from person in
        //    people.AsParallel().AsOrdered()
        //    where person.City == "Seattle"
        //    select person;

        //    //AsSequencial si se ejecuta en orden.
        //    var result = (from person in people.AsParallel()
        //                  where person.City == "Seattle"
        //                  orderby (person.Name)
        //                  select new
        //                  {
        //                      Name = person.Name
        //                  }).AsSequential().Take(4); //Este take siempre debe ser posterior al orderby,o puede generar diferencia de orden.



        //    foreach (var person in result)
        //        Console.WriteLine(person.Name);

        //   //result.ForAll(person => Console.WriteLine(person.Name));   //<-- Esto es un foreach pero en paralelo, aunque aca no funciona.

        //    Console.WriteLine("Finished processing. Press a key to end.");
        //        Console.ReadKey();
        //    }
        //}

        #endregion


    }
}




