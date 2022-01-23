using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _16_AdministracionDeAssemblys
    {
    }

    #region Assemblys
    /*
    Un assembly es un componente individual de una aplicación. Puede ser un programa ejecutable (.exe) o una librería (.dll).
    
    EL programador crea el código fuente junto y adjunta los recursos necesarios, y estos son combinados por el compilador visual studio
    para producir un assembly.  Los archivos del assembly contienen programas expresados en MSIL (Microsoft Intermediate Language), junto con
    los recursos.  Cuando la aplicación es ejecutada por .net runtime, el compilador JIT (Just in Time) convierte los archivos IL en código 
    máquina.

    Hay dos cosas importantes que recordar:
        1- El IL resultante es independiente del lenguaje en que fue escrito (C# , F# o Vb).
        2- El Il resultante es independeinte del hardware que se utilizará para correr el programa. Hay un paso adicional en la compilación
        en donde se convierte el MSIL del assembly en el código máquina que entiende el hardware en donde se esta corriendo. Esto ocurre en 
        la compilación JIT (Just in time).

    Es posible hacer un proyecto con dos soluciones. (Como BSRec). En estos casos uno de los proyectos es dependiente del otro. Lo que significa
    que cambios en en l proyecto independiente, puede generar cambios en em comportamiento del dependiente. VS no permite dependencias circulares
    , por lo que un proyecto A puede dpender de B, pero ese proyecto B, no puede depender de A.

    */
    #endregion

    #region Versiones de Assemblys

    /*
    EN versiones anteriores de Windows, era posible que distintos programas fueran dependientes de las mismas librerias. En ese momento era una
    buena idea ya que se ahorraba memoeria, pero causaba inconvenientes ya que un programa podria actualizar una libreria, haciendo que otro
    programa que usaba la versión anterior pudiese fallar. Esto era conocido como "DLL HELL". Uno de los objetivos de .NET fue solucionar estos
    inconvenientes. 

    Es posible investigar como funcionan los archivos de un assembly utiisando ildasm, del que ya se hablo un poco con boxing y unboxing
    . ildasmpuede ser utilizado para el código y el contenido de un assembly. También se puede ver el Manifest, que contiene una lista de
    todos los assemblyes que son utilizados por el assembly en cuestion.
    Cuando la aplicación se ejecuta, .Net runtime environment se asegura de que la versión de la libreria que se carga coincida con la que
    es requerida. De lo contrario no compila. 
    Es posible setear la versión en las propiedades de un proyecto, seleccionando  "Aseembly Information". Esto abre una ventana de dialogo
    que puede verse en la PAG 284. 
    Esta información se guarda en un archivo llamado AssemblyInfo.cs
    */


    #endregion

    #region Firma de Assemblys con nombres fuertes (strong names)

    /*
    PAG 285
    Los Assemblis se firman digitalmente de la misma forma que se vio arriba con provate y public keys. Hay varias ventajas en firmar
    los assemblys de esta forma:
        -El chequeo de versión solo se realiza si los assemblies estan firmados
        -Un Assembly de nombre fuerte solo puede ser utilizado en aplicaciones que también esten firmadas con nombres fuertes.
        -Un assembly de nombre fuerte puede ser cargado en un global assemby cache (GAC) que permite proveer mejoras de performance compartidas
        entre aplicaciones (wtf)
        -Un assembly de nombre fuerte tiene un nombre único que es generado utilizando la clave privada al momento de la creación del assembly.
        Esto permite que distintas versiones del assembly coexistan en un sistema. Y ya que el manifest contiene los nombres fuertes de las
        dependencias, nunca se dara otro "dll hell".

    La herramienta de linea de comando "sn" puede ser utilizada para crear claves privadas y publicas. También es posible generarlas de la pestaña
    "sign" de las propiedades de un proyecto assembly. Mas ingo en PAG 286
    */

    #endregion

    #region nombres que califican y claves publicas, firmado retardado (delay signing) , y limitacion de nombres fuertes
    /*VER PAG 287*/
    #endregion

    #region GAC Global Assembly Cache
    /*
    Si se necesita compartir un assembly entre varias aplicaciones creadas por uno mismo, se puede colocar el assembly en el GAC. Para ello
    hay que colocar el assembly en la carpeta windows/assembly.   Cuando el runtime busca un assembly automaticamente lo busca primero en el
    GAC.  Se puede ver la secuencia de busqueda de un assembly aqui  https://docs.microsoft.com/en-gb/windows/desktop/SbsCs/assembly-searching-sequence
    */
    #endregion

    #region assembly binding redirection
    
    /*
    Utilizando assemblies con nombres fuertes en el GAC, es posible tener distintas versiones de un mismo assembly. Esto es conocido como 
    side-by-side hosting. 
    Esto puede causar un inconveniente:  Si tengo un bug en un assembly y lo arreglo y genero una nueva version del assembly, todas las aplicaciones
    van a seguir apuntando a la version anterior de assembly, y habra que corregirlas una por una. Esto se puede solucionar a tres niveles, dandole
    una politica de direccionamiento. Ver mas en PAG 289

    */
    
    #endregion




}
