using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _08_Encapsulamiento
    {
    }

    #region Modificadores de acceso 

    /*
    Public:  Cualquiera tiene acceso.
    
    Private: Solo se puede acceder desde el mismo typo. Por convencion las propiedades privadas comienzan con guion bajo _miPropiedad
    
    Sealed: un metodo marcado con sealed, no puede ser overriden. Se utiliza para evitar que un programador malicioso, cambie el codigo en su
    beneficio. Ver pag 173

    Ejemplo de get y set especificados en codigo
    */
    //class Customer
    //{
    //    private string _nameValue;
    //    public string Name
    //    {
    //        get
    //        {
    //            return _nameValue;
    //        }
    //        set
    //        {
    //            if (value == "")
    //                throw new Exception("Invalid customer name");
    //            _nameValue = value;
    //        }
    //    }
    //}

    /*
    
    Generalmente nos encontramos con codigo sin que se especifique ni el get y set, pero su comportamiento ha sido auto-implementado. De ahi su nombre
    de propiedades auto implementadas, como el siguiente ejemplo:
        public int Age {get; set;}
     
    */


    /*
    
    Protected: Hace que el miembro de la clase sea utilizable solo desde la misma clase, o desde alguna otra clase que herede de esta.
    
    Internal: Hace que el miembro de la clase sea utilizable por cualquiera dentro del mismo assembly. Puede ser tanto un programa ejecutable
    (.exe) o una libreria (.dll) 
    
    Readonly:  Obviamente hace que se de solo lectura.

    */

    /*
   Los modificadores de acceso private, public, protected e internal, tambien pueden usarse en clases que estan anidadas en otra clase. 
   */

    #endregion

    #region Aplicar encapsulamineto utilizando implementacion de interfaces explicitas 

    /*
    Es posible utilizar implementaciones de interfaces explicitas para hacer que los métodos implementados por una interfaz sean visibles unicamente
    cuando el objeto es accedido a través de una referencia a la interfaz.

    Esto se entiende mejor si consideramos un ejemplo donde tiene sentido su uso. Supongamos que hacemos una interfaz IPrintable, que permite
    a una impresora imprimir el objeto. Esto haria que cualquier objeto que implemente la interfaz, sea imprimible. Pero esto solo tiene utilidad
    cuando es utilizado por algo que intente imprimir un objeto. No tiene sentido en ningun otro contexto. 
    
    Es posible lograr esto utilizando implementaciones explicitas en los métodos de impresión.

    En en codigo de abajo se ve que los métodos GetPrintableText y GetTitle (que son declarados en la interfaz) son implementaciones 
    explicitas, ya que contienen IPrintable en la firma. Ver Pag 161 para ver los efectos sobre intellisense

    class Report : IPrintable
    {
        string IPrintable. GetPrintableText(int pageWidth, int pageHeight)
        {
        return "Report text to be printed";
        }
        string IPrintable.GetTitle()
        {
        return "Report title to be printed";
        }
    }

    luego para poder llamar a estos métodos, se debe crear un objeto, e implmentar la interfaz.

    Report myReport = nre Report();
    IPrintable printItem = myReport;
    printItem.GetPrintableText(x,y)

    Se aconseja usar implementaciones explicitas siempre que se pueda, ya que esto evita que se utilicen métodos en contextos donde no corresponde.

    */

    #endregion

    #region Resolviendo firmas duplicadas en métodos utilizando implementacion explicita
    
    /*
    Una clase puede implmentar mas de una interfaz, y puede darse el caso que un método tenga el mismo nombre en una interfaz que en otra. Esto
    puede resolverse tambien con implementacion eplicita como se veio arriba. Ver Pag 162 para ver ejemplo en codigo, pero es lo mismo de arriba.
    */

    #endregion
}
