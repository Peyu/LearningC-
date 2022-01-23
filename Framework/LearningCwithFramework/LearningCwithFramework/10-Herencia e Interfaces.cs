using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _10_Herencia
    {


        #region Ejemplo de Interfaces, herencia,  operadores Is As y base
        ///*
        //Pag 163 Info general sobre Inerfaces.

        //    Algunas cosas a tner en cuenta:
        //        - Solo se puede overridear metodos que sean virtual o abstract
        //        - No se puede overridear un método de interfaz implmentado de forma explicita.
        //        - Tener cuidado con propiedades private, ya que si una clase hija necesita usarla no va a poder, a menos que se cambie a protected.

        //*/
        ////Ejemplo de interfaz con implementacino explicita
        //public interface IAccount
        //{
        //    void PayInFunds(decimal amount);
        //    bool WithdrawFunds(decimal amount);
        //    decimal GetBalance();
        //}
        //public class BankAccount : IAccount
        //{
        //    private decimal _balance = 0;
        //    bool IAccount.WithdrawFunds(decimal amount)
        //    {
        //        if (_balance < amount)
        //        {
        //            return false;
        //        }
        //        _balance = _balance - amount;
        //        return true;
        //    }
        //    void IAccount.PayInFunds(decimal amount)
        //    {
        //        _balance = _balance + amount;
        //    }
        //    decimal IAccount.GetBalance()
        //    {
        //        return _balance;
        //    }
        //}

        ////Ejemplo de herencia
        //public class BabyAccount : BankAccount, IAccount //<-- BabyAccount esta heredando de BankAccount, e implementando IAccount
        //{
        //    public virtual void PrintAnything() {
        //        Console.WriteLine("Anything");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var cuenta = new BankAccount();
        //    //cuenta.GetBalance(); //<-- esto no funciona porque no se esta llamando a través de la interfaz

        //    //sin este paso, no se puede acceder a los metodos, porque son explicitos.
        //    IAccount ATravesDeInterface = cuenta;

        //    ATravesDeInterface.GetBalance();

        //    var CuentaBaby = new BabyAccount();
        //    IAccount CuentaBabyInterfaceada = CuentaBaby;
        //    CuentaBabyInterfaceada.PayInFunds(50);
        //    CuentaBaby.PrintAnything();
        //    if (CuentaBaby is IAccount)
        //        Console.WriteLine("La cuenta Baby implementa la interfaz IAccount");

        //    //otra forma de interfacear una clase. Esta es mas segura, ya que si no es posible interfacear la clase, va devolver null
        //    var OtraCuenta = new BankAccount();
        //    IAccount otraI = OtraCuenta as IAccount; //<-- Esto devuelve null de no ser posible. 
        //    otraI.WithdrawFunds(50);

        //    ////Puebo override, se debe descomentar la region oveerides
        //    //var BoyAccount = new BoyAccount();
        //    //var BoyI = BoyAccount as BoyAccount;
        //    //BoyI.PrintAnything();

        //    Console.ReadKey();
        //}
        #endregion

        #region overrides

        //public class BoyAccount : BabyAccount, IAccount
        //{
        //    public override void PrintAnything() {
        //        //Ejecuto el metodo original, sin overridear, desde base
        //        base.PrintAnything();
        //        Console.WriteLine("Boy Accounts prints Anything.");
        //    }
        //}

        #endregion

        #region Reemplazo de metodos en clase padre, a traves de una clase hijo

        /*
        Esto es interesante mas a modo de cuirosidad, que porque sea util. Ya que no se aconseja usarlo. No es posible reemplazar un metodo sealed
        Ver en Pag 172
        */

        #endregion

        #region Constructores y herencia de clases 
        /*
            Al agregar un constructor a la clase base, todas las clases hijas se rompen... (A menos que le agreguemos un constructor vacio, claro)
            Lo que pasa es que al intentar crear la babyaccount, necesita pasarle un dato al constructor. Para solucionar esto, el constructor de
            la clase babyaccount, deberia llamar al constructor de la clase bankaccount.
        */
        //public interface IAccount
        //{
        //    void PayInFunds(decimal amount);
        //    bool WithdrawFunds(decimal amount);
        //    decimal GetBalance();
        //}
        //public class BankAccount : IAccount
        //{
        //    private decimal _balance = 0;
        //    public BankAccount(decimal initialBalance)
        //    {
        //        _balance = initialBalance;
        //    }
        //    bool IAccount.WithdrawFunds(decimal amount)
        //    {
        //        if (_balance < amount)
        //        {
        //            return false;
        //        }
        //        _balance = _balance - amount;
        //        return true;
        //    }
        //    void IAccount.PayInFunds(decimal amount)
        //    {
        //        _balance = _balance + amount;
        //    }
        //    decimal IAccount.GetBalance()
        //    {
        //        return _balance;
        //    }
        //}

        ////Ejemplo de herencia
        //public class BabyAccount : BankAccount, IAccount //<-- BabyAccount esta heredando de BankAccount, e implementando IAccount
        //{
        //    public virtual void PrintAnything()
        //    {
        //        Console.WriteLine("Anything");
        //    }
        //    ////como esto esta comentado, no funca...
        //    //public BabyAccount(int initialBalance) : base(initialBalance)
        //    //{
        //    //}
        //}

        //static void Main(string[] args)
        //{
        //    var cuenta = new BankAccount(100);
        //    //cuenta.GetBalance(); //<-- esto no funciona porque no se esta llamando a través de la interfaz

        //    //sin este paso, no se puede acceder a los metodos, porque son explicitos.
        //    IAccount ATravesDeInterface = cuenta;

        //    ATravesDeInterface.GetBalance();

        //    var CuentaBaby = new BabyAccount(50);
        //    IAccount CuentaBabyInterfaceada = CuentaBaby;
        //    CuentaBabyInterfaceada.PayInFunds(50);
        //    CuentaBaby.PrintAnything();
        //    if (CuentaBaby is IAccount)
        //        Console.WriteLine("La cuenta Baby implementa la interfaz IAccount");

        //    //otra forma de interfacear una clase. Esta es mas segura, ya que si no es posible interfacear la clase, va devolver null
        //    var OtraCuenta = new BankAccount(0);
        //    IAccount otraI = OtraCuenta as IAccount; //<-- Esto devuelve null de no ser posible. 
        //    otraI.WithdrawFunds(50);


        //    Console.ReadKey();
        //}

        #endregion

        #region Clases y metodos abstractos
        /*
            Si lo que queremos lograr con la interfaz, es asegurarnos de que cualquier clase que implemente la interfaz, cumpla con la implementacion
            de ciertas propiedades o metodos, lo que necesitamos es marcarla en la interfaz como abstract. En este caso solo tendremos la firma y no
            habra logica, ya que debe implmentarse en las clases que la implemente. Sin embargo, tambien podemos marcarla como virtual, en este caso
            proveemos de un metodo default, que se utilizara si no hay ningun metodo que la overridee. Sin embargo esta forma no garantiza que el metodo
            sea implementado en todos las clases derivadas, y puede generar algun inconveniente.

            A tener en cuenta:  Si en una clase, una propiedad o método es marcado como abstracto, entonces hay que marcar la clase entera como 
            abstracta.

            Ejemplo de un sring abstracto

            public abstract class BankAccount  // <-- La clase se marco como abstracta porque tiene un string abstracto
            {
             public abstract string WarningLetterString();    //<--  esto es un metodo que no recibe parametros y devuelve un string
            }
        */


        #endregion

        #region IComparable
        /*
        La interfaz IComparable es utilizada por .NET para determinar el orden de los objetos cuando se ordenan. Esta interfaz contiene un solo metodo
        "CompareTo" que compara un objeto contra otro, y devuelve un integer.  Si el integer < 0 entonces el objeto va antes del objeto contra el que
        comparo.  si el integer es 0 se deberian poner los dos objetos al mismo nivel, y si el integer > 0 el objeto vas despues del objeto contra el 
        que se comparo.
        
        El método CompareTo se abastece con una referencia de objeto, que debe ser convertida en una referencia IAccount, para que pueda ser comparado
        contra un BankAccount. El método CompareTo es simplificado utilizando el método CompareTo de decimal.

        */

        //public interface IAccount
        //{
        //    void PayInFunds(decimal amount);
        //    bool WithdrawFunds(decimal amount);
        //    decimal GetBalance();
        //}
        //public class BankAccount : IAccount, IComparable
        //{
        //    private decimal _balance = 0;
        //    public BankAccount(decimal initialBalance)
        //    {
        //        _balance = initialBalance;
        //    }
        //    public int CompareTo(object obj)
        //    {
        //        // if we are being compared with a null object we are definitely after it
        //        if (obj == null) return 1;
        //        // Convert the object reference into an account reference
        //        IAccount account = obj as IAccount;
        //        // as generates null if the conversion fails
        //        if (account == null)
        //            throw new ArgumentException("Object is not an account");
        //        // use the balance value as the basis of the comparison
        //        return this._balance.CompareTo(account.GetBalance());
        //    }

        //    bool IAccount.WithdrawFunds(decimal amount)
        //    {
        //        if (_balance < amount)
        //        {
        //            return false;
        //        }
        //        _balance = _balance - amount;
        //        return true;
        //    }
        //    void IAccount.PayInFunds(decimal amount)
        //    {
        //        _balance = _balance + amount;
        //    }
        //    decimal IAccount.GetBalance()
        //    {
        //        return _balance;
        //    }
        //}

        ////Ejemplo de herencia
        //public class BabyAccount : BankAccount, IAccount //<-- BabyAccount esta heredando de BankAccount, e implementando IAccount
        //{
        //    public virtual void PrintAnything()
        //    {
        //        Console.WriteLine("Anything");
        //    }
        //    //como esto esta comentado, no funca...
        //    public BabyAccount(int initialBalance) : base(initialBalance)
        //    {
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var Cuenta = new BankAccount(100);
        //    //cuenta.GetBalance(); //<-- esto no funciona porque no se esta llamando a través de la interfaz

        //    //sin este paso, no se puede acceder a los metodos, porque son explicitos.
        //    IAccount ATravesDeInterface = Cuenta;

        //    ATravesDeInterface.GetBalance();

        //    var CuentaBaby = new BabyAccount(50);
        //    IAccount CuentaBabyInterfaceada = CuentaBaby;
        //    CuentaBabyInterfaceada.PayInFunds(30);
        //    CuentaBaby.PrintAnything();
        //    if (CuentaBaby is IAccount)
        //        Console.WriteLine("La cuenta Baby implementa la interfaz IAccount");

        //    //otra forma de interfacear una clase. Esta es mas segura, ya que si no es posible interfacear la clase, va devolver null
        //    var OtraCuenta = new BankAccount(0);
        //    IAccount otraI = OtraCuenta as IAccount; //<-- Esto devuelve null de no ser posible. 
        //    otraI.WithdrawFunds(50);

        //    Console.WriteLine("Comparo dos cuentas");
        //    if (Cuenta.CompareTo(CuentaBaby) > 0) {
        //        Console.WriteLine("Cuenta tiene mas fondos que CuentaBaby");
        //    }

        //    Console.WriteLine("Se crean 20 cuentas, se agregan a una lista, y luego se ordenan");
        //    // Create 20 accounts with random balances
        //    List<IAccount> accounts = new List<IAccount>();
        //    Random rand = new Random(1);
        //    for (int i = 0; i < 20; i++)
        //    {
        //        IAccount account = new BankAccount(rand.Next(0, 10000));
        //        accounts.Add(account);
        //    }
        //    // Sort the accounts
        //    accounts.Sort();

        //    // Display the sorted accounts
        //    foreach (IAccount account in accounts)
        //    {
        //        Console.WriteLine(account.GetBalance());
        //    }

        //    Console.ReadKey();
        //}

        #endregion

        #region Typed IComparable

        /*
        EN el ejemplo anterior, la interfaz IComparable utiliza el método CompareTo que acepta como parametro cualquier tipo de objeto. Esto hace
        que el programa pueda tirar una excepcion si se le pasa un objeto que no sea el correcto, y a su vez, existe la necesidad de manejar esa
        excepcion. 
        Otra forma de implementar la interfaz IComparable, es hacer que el metodo CompareTo reciba como parametro un tipo definido. De esa forma
        si se le pasa un objeto de otra clase, va a saltar al momento de la compilación, y a su vez, ya no es necesario manejar la excepcion.
        
        A TENER EN CUENTA!  Para poder hacer compilar esto, se tuvo que cambiar IAccount, para que tambien implemente IComparable<IAccount>.
        Es decir que ahora todos los objetos IAccount deben tener un metodo CompareTo
            
        */

        //public interface IAccount: IComparable<IAccount>
        //{
        //    void PayInFunds(decimal amount);
        //    bool WithdrawFunds(decimal amount);
        //    decimal GetBalance();
        //}
        //public class BankAccount : IAccount, IComparable<IAccount>
        //{
        //    private decimal _balance = 0;
        //    public BankAccount(decimal initialBalance)
        //    {
        //        _balance = initialBalance;
        //    }
        //    public int CompareTo(IAccount account)
        //    {
        //        // if we are being compared with a null object we are definitely after it
        //        if (account == null) return 1;
        //        // use the balance value as the basis of the comparison
        //        return this._balance.CompareTo(account.GetBalance());
        //    }

        //    bool IAccount.WithdrawFunds(decimal amount)
        //    {
        //        if (_balance < amount)
        //        {
        //            return false;
        //        }
        //        _balance = _balance - amount;
        //        return true;
        //    }
        //    void IAccount.PayInFunds(decimal amount)
        //    {
        //        _balance = _balance + amount;
        //    }
        //    decimal IAccount.GetBalance()
        //    {
        //        return _balance;
        //    }


        //}

        ////Ejemplo de herencia
        //public class BabyAccount : BankAccount, IAccount //<-- BabyAccount esta heredando de BankAccount, e implementando IAccount
        //{
        //    public virtual void PrintAnything()
        //    {
        //        Console.WriteLine("Anything");
        //    }
        //    //como esto esta comentado, no funca...
        //    public BabyAccount(int initialBalance) : base(initialBalance)
        //    {
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var Cuenta = new BankAccount(100);
        //    //cuenta.GetBalance(); //<-- esto no funciona porque no se esta llamando a través de la interfaz

        //    //sin este paso, no se puede acceder a los metodos, porque son explicitos.
        //    IAccount ATravesDeInterface = Cuenta;

        //    ATravesDeInterface.GetBalance();

        //    var CuentaBaby = new BabyAccount(50);
        //    IAccount CuentaBabyInterfaceada = CuentaBaby;
        //    CuentaBabyInterfaceada.PayInFunds(30);
        //    CuentaBaby.PrintAnything();
        //    if (CuentaBaby is IAccount)
        //        Console.WriteLine("La cuenta Baby implementa la interfaz IAccount");

        //    //otra forma de interfacear una clase. Esta es mas segura, ya que si no es posible interfacear la clase, va devolver null
        //    var OtraCuenta = new BankAccount(0);
        //    IAccount otraI = OtraCuenta as IAccount; //<-- Esto devuelve null de no ser posible. 
        //    otraI.WithdrawFunds(50);

        //    Console.WriteLine("Comparo dos cuentas");
        //    if (Cuenta.CompareTo(CuentaBaby) > 0)
        //    {
        //        Console.WriteLine("Cuenta tiene mas fondos que CuentaBaby");
        //    }

        //    Console.WriteLine("Se crean 20 cuentas, se agregan a una lista, y luego se ordenan");
        //    // Create 20 accounts with random balances
        //    List<IAccount> accounts = new List<IAccount>();
        //    Random rand = new Random(1);
        //    for (int i = 0; i < 20; i++)
        //    {
        //        IAccount account = new BankAccount(rand.Next(0, 10000));
        //        accounts.Add(account);
        //    }
        //    // Sort the accounts
        //    accounts.Sort();

        //    // Display the sorted accounts
        //    foreach (IAccount account in accounts)
        //    {
        //        Console.WriteLine(account.GetBalance());
        //    }

        //    Console.ReadKey();
        //}


        #endregion

        #region IEnumerable
        /*Pag 178*/

        /*
         Esta interfaz permite a quien la implemente pasar un enumerador a quien lo solicite. EL objeto enumerator puede ser utilizado para enumerar
         o iterar. Por ejemplo, el tipo string soporta IEnumerator, y esto permite obtener un enumerador, que expone el método MoveNext(), que
         retorna un valor true si queda algun otro elemento en la enumeración. El enumerador tambien expone una propiedad llamada Current,
         que es una referencia al objeto actual por el que se esta iterando.
        
         Ejemplo en codigo:
         */

        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        // Get an enumerator that can iterate through a string
        //        var stringEnumerator = "Hello world".GetEnumerator();
        //        while (stringEnumerator.MoveNext())
        //        {
        //            Console.Write(stringEnumerator.Current);
        //            Console.ReadKey();
        //        }

        //    }
        //}

        /*
        
        Es posible consumir todos los IEnumerabes de esta forma, pero c# nos hace la vida más fácil con foreach.
        
        */


        #endregion

        #region Creación de un IEnumerable
        /*
        Todas las colecciones y los resultados de querys LinQ, son IEnumerables.
        Para crear un IEnumerable hay que implmenetar un método GetEnumerator. Y para implementar IEnumerator hay que implementar una propiedad
        current de tipo T, sin embargo los IEnumerator implementan a su vez la interfaz IDisposable, por lo que tambien hayq que implmentar sus metodos
        y propiedades (ver mas abajo que esta la explicacion de los IDisposables)
        */

        //class EnumeratorThing : IEnumerator<int>, IEnumerable
        //{
        //    int count;
        //    int limit;

        //    public int Current
        //    {
        //        get
        //        {
        //            return count;
        //        }
        //    }
        //    object IEnumerator.Current 
        //    {
        //        get
        //        {
        //            return count;
        //        }
        //    }
        //    public void Dispose()
        //    {
        //    }
        //    public bool MoveNext()
        //    {
        //        if (++count == limit)
        //            return false;
        //        else
        //            return true;
        //    }
        //    public void Reset()
        //    {
        //        count = 0;
        //    }
        //    public IEnumerator GetEnumerator() //Implementacino explicita
        //    {
        //        return this;
        //    }
        //    public EnumeratorThing(int limit)
        //    {
        //        count = 0;
        //        this.limit = limit;
        //    }
        //}
        //static void Main(string[] args) {

        //    EnumeratorThing e = new EnumeratorThing(10);
        //    foreach (var item in e)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();

        //    var Enumerator = e.GetEnumerator();
        //    Enumerator.Reset();
        //    while (Enumerator.MoveNext()) {
        //        Console.WriteLine(Enumerator.Current);
        //    }
        //    Console.ReadKey();


        //}


        #endregion

        #region Uso de Yield
        /*
        Para hacer mas sencilla la creación de enumerators, c# provee la palabra reservada yield.
        yield se utiliza seguido de return y seguido de la variable que se va a devolver en la iteración actual (current). Em compilador de c# genera
        todos los comportamientos de Current() y MoveNext() que hacen que la iteración funcione, y además guarda el estado del método iterador,
        para que el iterador pueda reasumir el comando (statement) que le sigue al yield cuando la siguiente iteracion es requerida.

        ok, explicación un poco mas crilla:
        Cuando se ejecuta GetEnumerator por primera vez, devuelve 1. El yield frena el for, y le da el flujo de control a quien llamo al getEnumerator
        (que de seguro es algun tipo de loop). cuando el loop pasa a la siguiente vuelta, el for continua desde donde quedo la ultima vez, por lo tanto
        ahora devuelve el 2... y asi...
        */

        //class EnumeratorThing : IEnumerable<int>
        //{
        //    public IEnumerator<int> GetEnumerator()
        //    {
        //        for (int i = 1; i < 10; i++)
        //            yield return i;
        //    }
        //    IEnumerator IEnumerable.GetEnumerator()
        //    {
        //        return GetEnumerator();
        //    }
        //    private int limit;
        //    public EnumeratorThing(int limit)
        //    {
        //        this.limit = limit;
        //    }
        //}
        //static void Main(string[] args)
        //{

        //    EnumeratorThing e = new EnumeratorThing(10);
        //    foreach (var item in e)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();

        //    var Enumerator = e.GetEnumerator();
        //    //notar que aca no hace falta el reset, c# se encarga de volver a poner el contador al inicio... very cool, indeed...
        //    while (Enumerator.MoveNext())
        //    {
        //        Console.WriteLine(Enumerator.Current);
        //    }
        //    Console.ReadKey();


        //}

        #endregion

        #region IDisposable

        /*
        Si bien el compilador de c# se encarga del manejo de memoria y el recolector de basura, es posible proveer a un objeto con un metodo Dispose,
        que, implementando la interfaz IDisposable, marque a un objeto como disposed.  Esto es util ya que no es posible saber cuando el recolector 
        de basura va a borrar el objeto de la memoria, sin embargo, si se intenta acceder a un objeto que ha sido disposed, el compilador lanzará
        una excepcion de tipo ObjectDisposedException, aun cuando aun exista en memoria.
        El metodo dispose, deberia ser capaz de "limpiar" lo que ya no es necesario antes de quedar "dispuesto", por ejemplo: cerrar las conecciones
        a BD que hayan quedado abiertas.
        */
        /*
        Hay que tener en cuenta que las acciones necesarias para "Disponer" de un objeto, dependen completamente de las caracteristicas del programa.
        Además, el método Dispose no se ejecutará automaticamente cuando el objeto sea borrado de memoria. Hay dos maneras de asegurarnos de 
        que Dispose sea ejecutado correctamente. 1 - Llamarlo desde código.  2 - utilizando "using" de c# (ver ejemplo abajo)
        
        Si se necesita usar mas de un objeto IDisposable, se pueden anidar los using.

        Deducción:  Lo que hace using es mantener vivo un objeto Idisposable, y despues llamar su dispose... 
            
        */

        //EJEMPLO EN CÓDIGO

        //class CrucialConnection : IDisposable
        //{
        //    public void Dispose()
        //    {
        //        //aqui el codigo deberia liberar recursos
        //        Console.WriteLine("Dispose called");
        //    }
        //}
        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        using (CrucialConnection c = new CrucialConnection()) //<-- esto dispara el dispose al final. Si dispara una excepcion tambien!!
        //        {
        //            // do something with the crucial connection
        //        }
        //        Console.ReadKey();
        //    }
        //}

        #endregion

        #region IUnknown 

        /*
        Anteriormente vimos que los objetos dinamic son tipados devilmente, y que se usan en interoperaciones con objetos COM o DOM. IUnknow es la forma
        que tiene c# de trabajar con estos objetos, por ahora no hace falta saber mas que esto.
        */

        #endregion


    }
}
