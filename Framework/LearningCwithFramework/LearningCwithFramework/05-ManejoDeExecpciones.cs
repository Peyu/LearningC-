using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _05_ManejoDeExecpciones
    {
    }

    /*
    
    Manejo de excepciones comienza en pag 98 del libro Exam Ref 70-483 Programming... 
    Es bastante básico solo pongo lo más destacable.
    
    */


    /*
    
    Re-levantar una excepcion:

    En ocaciones, al manejar una excepcion, es necesario también "pasar la execpcion hacia arriba" a un manejo de excepción superior. Para
    hacerlo, simplemente usamos throw como en el ejemplo de abajo.

    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw ex; // this will not preserve the original stack trace
    }

    Sin embargo, esto se considera una mala practica, ya que  porque la excepcion re-levantada no va a contener el stacktrace del error original,
    ya que sera sobrescrito por el tracktrace del throw.

    Otra forma de pasar una excepcion hacia arriba, es pasarla como una excepción interna (inner excepction). La clase excepción contiene una propiedad
    innerException que puede ser seteada cuando se construye la excepcion. El constructor para la nueva excepcion se pasa como referencia a la exepción
    original.

    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw new Exception("Something bad happened", ex);
    }

    Un manejador de excepcion puede usar la propiedad innerexception como parte de su lógica de manejo.
     */

    #region Excepcion Interna (inner Exception)
    //class Prog
    //{
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            try
    //            {
    //                Console.Write("Enter an integer: ");
    //                string numberText = Console.ReadLine();
    //                int result;
    //                result = int.Parse(numberText);
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception("Calculator failure", ex);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            Console.WriteLine(ex.InnerException.Message);
    //            Console.WriteLine(ex.InnerException.StackTrace);
    //        }
    //        Console.ReadKey();
    //    }
    //}
    #endregion

    #region Excepciones agregadas (aggregate exception)

    /*
     Pag 108
    Algunos tipos de excepciones contienen listas de excepciones internas (inner exception), que son llamadas aggregate exceptions. Estas
    excepciones ocurren cuando mas de una cosa puede fallar cuando una operacion es ejecutada, o cuando el resultadode una serie de eacciones
    necesitan ser traidas juntas.
     
    El ejemplo de abajo muestra una situación en donde las excepciones agregadas son utilizdas para entregar resultados desde un método que es
    llamdo para leer texto de una pagina web. La excepcion agregada es atajada y se muestra el mensaje de cada error.
     
    */

    //class Prog
    //{
    //    async static Task<string> FetchWebPage(string uri)
    //    {
    //        var httpClient = new HttpClient();
    //        var response = await httpClient.GetAsync(uri);
    //        return await response.Content.ReadAsStringAsync();
    //    }
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            Task<string> getpage = FetchWebPage("invalid uri");
    //            getpage.Wait();
    //            Console.WriteLine(getpage.Result);
    //        }
    //        catch (AggregateException ag)
    //        {
    //            foreach (Exception e in ag.InnerExceptions)
    //            {
    //                Console.WriteLine(e.Message);
    //            }
    //        }
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    /* Creacion de excepciones custom Pag 105 */

    #region Clausulas condicionales en bloques Catch

    /*

    ya hemos visto que una excepcion puede pasarse hacia arriba, para que otro manejador de excepciones la tome. Otra forma de lograr esto, es poner
    un condicional en nuestro manejo de expeciones para que en cierto caso, la excepcion no se maneje. Esto va a hacer que automaticamente va a pasar 
    al bloque de arriba, sin tener que "reconstruir" la excepcion con una excepcion interna.
    La clausula condicional se construye con "when"


    */

    //class Prog
    //{
    //    class CalcException : Exception
    //    {
    //        public enum CalcErrorCodes
    //        {
    //            InvalidNumberText,
    //            DivideByZero
    //        }
    //        public CalcErrorCodes Error { get; set; }
    //        public CalcException(string message, CalcErrorCodes error) : base(message)
    //        {
    //            Error = error;
    //        }
    //    }
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            throw new CalcException("Calc failed", CalcException.CalcErrorCodes.DivideByZero);
    //        }
    //        catch (CalcException ce) when (ce.Error == CalcException.CalcErrorCodes.DivideByZero) //Si se cambia el tipo de excepcion, la deja pasar
    //        {
    //            Console.WriteLine("Divide by zero error");
    //        }
    //    }
    //}


    #endregion



}