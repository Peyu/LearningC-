using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _21__Serializacion
    {
    }

    #region binary serialization / Serializacion Binaria
    /*
    PAG 392 -  asi como se serializa en json, se puede serializar en binario. 
    */
    #endregion

    #region Data Contract PAG 397
    /*
    Se encuentra en  System.Runtime.Serialization library y no viene dentro de un proyecto por default. Se diferencia del XML serializer
    en lo siguiente

        -   Los datos a ser serializados se seleccionnan utilizando un mecanismo "opt in" por lo que solo los items marcados con 
        el atributo [DataMenmber] seran serilizados.

        -   Es posible serilizar private class menmbers (pero seran publicas en el doc XML resultante)

        -   El XML serialzer proporciona opciones que le permiten al programador establecer el orden de los items en el archivo
        de datos. Esta opcion no esta presente con el data contract

        
    */


    #endregion


}
