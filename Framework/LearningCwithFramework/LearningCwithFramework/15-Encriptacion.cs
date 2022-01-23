using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _15_Encriptacion
    {
    }

    #region teoria de public y private keys
    /*
    Pag 263
    Criptografía: El "Arte" de leer mensajes que nadie execpto el destinatario del mensaje puede leer. Implica generar una version encriptada del
    mensaje que puede enviarse de forma segura por la red. El receptor va a desencriptar el mensaje
    
    Criptoanálisis: El "Arte" de romper un codigo secreto. Involucra leer el mensaje encriptado en busca de patrones que reflejen el lenguaje
    y convensiones de quien envio el mensaje. Una vez se tienen esos patrones se puede intentar romper el codigo para extraer su contenido.
    
     Encriptacion simetrica:  Ejemplo, dos personas tienen dos libros, como en "La clave esta en rebeca". En este caso el libro es la "key"
     El unico inconveneiente es asegurar se que ambos extremos tengan la misma key, antes de iniciar el envio.

    Encriptacion asimétrica: El mensaje decodificado puede extraerse de dos keys distintas. De ahi la asimetría. El problema aqui es que la
    desencriptacion en estos casos es bastante mas pesada para la computadora y requiere que las keys sean mas largas y complejas. Esto se
    puede solucionar utilizando una combinacion de keys simetricas y asimetricas.

    Asimétrico y simétrico combinados?:  Se utiliza una de las dos keys asimétricas como public_key. Se le da esta clave a cualquiera con quien se desea
    iniciar una "conversacion" privada. La segunda se utiliza como private_key. Cualquiera con la public_key puede leer mensajes encriptados con
    tu private_key, y puede tambien generar mensajes encriptados que solo se pueden leer con la private_key.  La cosa aca, es que con la public_key
    no se pueden leer mensajes encriptados con la public_key... solo mensajes encriptados con la private_key.


    EJEMPLO:   Alice y Bob quieren hablar en privado, y Eve quiere escuchar la conversacion.

    1: Alice y Bob Generan cada uno un par de claves asimétricas, una privada y otro pública. Comparten sus claves públicas por internet.

    2: Eve guarda una copia de las claves públicas.

    3: Alice y Bob generan ahora una clave simétrica. Alice utiliza la clave pública de Bob para encriptar su clave simétrica, y se la envia a Bob.
    
    4: Eve obtiene una copia de la clave simétrica encriptada. Pero como con la clave publica no se puede leer un mensaje encriptado con clave publica
    pues no puede leer un sorongo...

    5: Bob ahora tiene la clave simetrica de Alice, y puede leer mensajes encriptados sin el esfuerzo de las claves asimetricas.
     
     */
    #endregion

    #region Uso de clave asimetrica para firmar un documento

    /*
     * Pag264
     Siguiendo un poco el ejemplo anterior:

    1: Bob crea un documento, lo uncripta con si private key, y ademas genera un checksum que tambien encripta.

    2: Alice recibe el documento encriptado y el checksum encriptado. Si el checksum es correcto puede estar segura de que el documento proviene
    de Bob, y que no ha sido alterado.
     */

    #endregion

    #region Encriptación simétrica Aes

    /*Advanced Encriptation Standard*/

    /*
     Aes reemplaza el anterior DES (Data encryptation estandard). Es un sistema de encriptación simétrica.
     Otros estandares como DES o RC2 tambien son soportados por .net, pero estan depreciados. Solo se utilizan con legacy systems.
     TripleDES, se utiliza encriptando DES con 3 keys, se utiliza en la idustria de pagos electrónicos. 

        En el código se ve un ejemplo de como utilizar esto.

        El vector de inicializacion se utiliza para agregarle seguridad a una key. Lo que hace es especificar un punto de inicio al azar en el 
        stream. Si cada stream comenzara en el inicio hay una posibilidad de que el uso continua de esta key, pueda proveer un conjunto de
        datos lo suficientemente grande como para que un tercero pueda terminar rompiendo la encriptación. El receptor del mensaje necesita
        tanto la key, como el vector de inicializacion para leer el mensaje.
     */

    //class Program
    //{
    //    static void DumpBytes(string title, byte[] bytes)
    //    {
    //        Console.Write(title);
    //        foreach (byte b in bytes)
    //        {
    //            Console.Write("{0:X} ", b);
    //        }
    //        Console.WriteLine();
    //    }
    //    static void Main(string[] args)
    //    {
    //        string plainText = "This is my super secret data";
    //        // byte array to hold the encrypted message
    //        byte[] cipherText;
    //        // byte array to hold the key that was used for encryption
    //        byte[] key;
    //        // byte array to hold the initialization vector that was used for encryption
    //        byte[] initializationVector;
    //        // Create an Aes instance
    //        // This creates a random key and initialization vector
    //        using (Aes aes = Aes.Create())
    //        {
    //            // copy the key and the initialization vector
    //            key = aes.Key;
    //            initializationVector = aes.IV;
    //            // create an encryptor to encrypt some data
    //            // should be wrapped in using for production code
    //            ICryptoTransform encryptor = aes.CreateEncryptor();
    //            // Create a new memory stream to receive the 
    //            // encrypted data.
    //            using (MemoryStream encryptMemoryStream = new MemoryStream())
    //            {
    //                // create a CryptoStream, tell it the stream to write to
    //                // and the encryptor to use. Also set the mode
    //                using (CryptoStream encryptCryptoStream =
    //                new CryptoStream(encryptMemoryStream,
    //                encryptor, CryptoStreamMode.Write))
    //                {
    //                    // make a stream writer from the cryptostream
    //                    using (StreamWriter swEncrypt =
    //                    new StreamWriter(encryptCryptoStream))
    //                    {
    //                        //Write the secret message to the stream.
    //                        swEncrypt.Write(plainText);
    //                    }
    //                    // get the encrypted message from the stream
    //                    cipherText = encryptMemoryStream.ToArray();
    //                }
    //            }
    //        }
    //        // Dump out our data
    //        Console.WriteLine("String to encrypt: {0}", plainText);
    //        DumpBytes("Key: ", key);
    //        DumpBytes("Initialization Vector: ", initializationVector);
    //        DumpBytes("Encrypted: ", cipherText);   
    //        Console.ReadKey();


    //        /*Esta otra parte desencripta el mensaje de arriba.*/
    //        string decryptedText;
    //        using (Aes aes = Aes.Create())
    //        {
    //            // Configure the aes instances with the key and
    //            // initialization vector to use for the decryption
    //            aes.Key = key;
    //            aes.IV = initializationVector;
    //            // Create a decryptor from aes
    //            // should be wrapped in using for production code
    //            ICryptoTransform decryptor = aes.CreateDecryptor();
    //            using (MemoryStream decryptStream = new MemoryStream(cipherText))
    //            {
    //                using (CryptoStream decryptCryptoStream =
    //                new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Read))
    //                {
    //                    using (StreamReader srDecrypt = new StreamReader(decryptCryptoStream))
    //                    {
    //                        // Read the decrypted bytes from the decrypting stream
    //                        // and place them in a string.
    //                        decryptedText = srDecrypt.ReadToEnd();
    //                        Console.WriteLine("Mensaje desencriptado: " + decryptedText);
    //                    }
    //                }
    //            }
    //        }
    //        Console.ReadKey();

    //    }
    //}


    #endregion

    #region Utilizacion de encriptación asimétrica RSA  para crear claves públicas y privadas

    /* RSA - Rivest/Shamir/Adleman  PAG 268 */

    //class Program
    //{
    //    static void DumpBytes(string title, byte[] bytes)
    //    {
    //        Console.Write(title);
    //        foreach (byte b in bytes)
    //        {
    //            Console.Write("{0:X} ", b);
    //        }
    //        Console.WriteLine();
    //    }
    //    static void Main(string[] args)
    //    {
    //        string plainText = "This is my super secret data";
    //        Console.WriteLine("Plain text: {0}", plainText);

    //        // RSA works on byte arrays, not strings of text
    //        // This will convert our input string into bytes and back
    //        ASCIIEncoding converter = new ASCIIEncoding();
    //        // Convert the plain text into a byte array
    //        byte[] plainBytes = converter.GetBytes(plainText);
    //        DumpBytes("Plain bytes: ", plainBytes);
    //        byte[] encryptedBytes;
    //        byte[] decryptedBytes;
    //        // Create a new RSA to encrypt the data
    //        // should be wrapped in using for production code
    //        RSACryptoServiceProvider rsaEncrypt = new RSACryptoServiceProvider();
    //        // get the keys out of the encryptor
    //        string publicKey = rsaEncrypt.ToXmlString(includePrivateParameters: false);
    //        Console.WriteLine("Public key: {0}", publicKey);
    //        string privateKey = rsaEncrypt.ToXmlString(includePrivateParameters: true);
    //        Console.WriteLine("Private key: {0}", privateKey);
    //        // Now tell the encyryptor to use the public key to encrypt the data
    //        rsaEncrypt.FromXmlString(privateKey);
    //        // Use the encryptor to encrypt the data. The fOAEP parameter
    //        // specifies how the output is "padded" with extra bytes
    //        // For maximum compatibility with receiving systems, set this as
    //        // false
    //        encryptedBytes = rsaEncrypt.Encrypt(plainBytes, fOAEP: false);
    //        DumpBytes("Encrypted bytes: ", encryptedBytes);
    //        // Now do the decode - use the private key for this
    //        // We have sent someone our public key and they
    //        // have used this to encrypt data that they are sending to us
    //        // Create a new RSA to decrypt the data
    //        // should be wrapped in using for production code
    //        RSACryptoServiceProvider rsaDecrypt = new RSACryptoServiceProvider();
    //        // Configure the decryptor from the XML in the private key
    //        rsaDecrypt.FromXmlString(privateKey);
    //        decryptedBytes = rsaDecrypt.Decrypt(encryptedBytes, fOAEP: false);
    //        DumpBytes("Decrypted bytes: ", decryptedBytes);
    //        Console.WriteLine("Decrypted string: {0}", converter.GetString(decryptedBytes));
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Almacen de claves a nivel de Usuario
    /*
    El uso de claves publicas y privadas nos genera una nueva necesidad: Donde guardar de forma segura nuestras claves privadas?
    
    Existe un almacen de claves para cada usuario de una computadora. Cuando se crea una instancia de RSACryptoServiceProvider , esta instancia
    utiliza un lugar especifico dentro de este almacen.
    */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string containerName = "MyKeyStore";
    //        CspParameters csp = new CspParameters();
    //        csp.KeyContainerName = containerName;
    //        // Create a new RSA to encrypt the data
    //        RSACryptoServiceProvider rsaStore = new RSACryptoServiceProvider(csp);
    //        Console.WriteLine("Stored keys: {0}",
    //        rsaStore.ToXmlString(includePrivateParameters: true));
    //        RSACryptoServiceProvider rsaLoad = new RSACryptoServiceProvider(csp);
    //        Console.WriteLine("Loaded keys: {0}",
    //        rsaLoad.ToXmlString(includePrivateParameters: true));
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Almacen de claves a nivel de Maquina

    /*
    Pag 271
    
    Si las claves van a ser compartidas por varios usuarios, deberia guararse a nivel de maquina. Windows implementa un alamcen de claves
    en una carpeta que contiene un archivo para cada llave. Generalmente se encuentra en  C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys

    */

    //class Program{

    //    static void Main(string[] args) {
    //        CspParameters cspParams = new CspParameters();
    //        cspParams.KeyContainerName = "Machine Level Key";
    //        // Specify that the key is to be stored in the machine level key store
    //        cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
    //        // Create a crypto service provider
    //        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);
    //        Console.WriteLine(rsa.ToXmlString(includePrivateParameters: false));
    //        Console.ReadKey();
    //        // Make sure that it is persisting keys
    //        rsa.PersistKeyInCsp = true;
    //        // Clear the provider to make sure it saves the key
    //        rsa.Clear();
    //    }
    //}

    #endregion

    #region Firmas digitales y cerificados

    /*
     En el proceso de arriba (encriptación con claves publicas y privadas) existe un riesgo.  Que pasa si alguien se hace pasar por Bob y le manda
     a Alice una clave publica falsa para comenzar una conversación? Para solucionar esto necesitamos acreditar la identidad. Y para esto se necesita
     una autoridad certificante.  Estas entidades generan certificados digitales para firmar mensajes.  Bob se inscribe con una autoridad certificante.
     Alice le pude a la autoridad la porcion publica de la llave de Bob, y ahi volvemos a los pasos de arriba.
     Este proceso se lleva a cabo cada vez que nuestra computadora se comunica con una pagina (me imagino que a través de DNS)
     
     */

    #endregion

    #region Firma de documentos utilizando certificados

    /*  PAG 272 Mueestra un ejemplo. */

    #endregion

    #region Implementación de system.security
    /*
    Si uno quiere implementar su propio sistema de encriptacion, puede conseguirse haciendo heredar nuestra clase de SymmetricAlgorithm. Sin embargo,
    esto esta altamente desaconsejado... Nunca vamos a conseguir algo tan bueno como lo que ya esta hecho.
    
    */


    #endregion

    #region Integridad by hashing

    /*
    Este es un ejemplo muy sencillo de hashing. Como se puede ver es bastante pobre, ya que como no se considera la posicion de cada
    caracter, los tres string devuelven el mismo hash, a pesar de ser distintos. De nuevo: NO SE RECOMIENDA HACER NUESTRO PROPIO HASH
    Leer mas abajo...
    */
    //class Program
    //{
    //    static int calculateChecksum(string source)
    //    {
    //        int total = 0;
    //        foreach (char ch in source)
    //            total = total + (int)ch;
    //        return total;
    //    }
    //    static void showChecksum(string source)
    //    {
    //        Console.WriteLine("Checksum for {0} is {1}",
    //        source, calculateChecksum(source));
    //    }
    //    static void Main(string[] args)
    //    {
    //        showChecksum("Hello world");
    //        showChecksum("world Hello");
    //        showChecksum("Hemmm world");
    //        Console.ReadKey();
    //    }
    //}

    /*
    El tipo Objeto, provee un metodo GetHash() que devuelve un valor que se basa en la localización en memoria de dicho objeto. Como todos
    los objetos derivan de la clase objeto, todo tiene un Gethash().

    El tipo string tiene su propia implementación de GetHash() que usa el contenido del string para generar el hash. 
    Igualmente este hash provee una solucion rápida para uso cotidiano, pero si se necesita para criptología, es necesario usar hash más
    seguros (mas largos, este nunca va a superar los 4 bytes, independientemente del tamaño del texto, lo que significa que el mismo hash,
    va a ser valido para mas de un texto).
    */

    //class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        string text1 = "Hello world";
    //        string text2 = "world Hello";
    //        string text3 = "Hemmm world";

    //        Console.WriteLine("Hash for {0} is: {1:X}", text1, text1.GetHashCode());
    //        Console.WriteLine("Hash for {0} is: {1:X}", text2, text2.GetHashCode());
    //        Console.WriteLine("Hash for {0} is: {1:X}", text3, text3.GetHashCode());
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region MD5 Hashing

    /*
     * Pag 276
    Se ha comprobado que dos documentos pueden tener el mismo hash MD5. Lo cual lo hace NO aconsejable para criptología. Sin embargo, es
    valido para chequear que no haya corrupción de datos. Produce un hash de bytes    
    */

    #endregion

    #region SHA 1
    /*
     PAG 277

    Secure Hash Algorith, produce un hash de 20 bytes. Si bien es mejor que MD5 se ha demostrado que es vulnerable a ataques por fuerza bruta

    
    */
    #endregion

    #region SHA 2
    /*
    Es familiar del SHA1, y es realmente un conjunto de 6 Hashs, que producen 224, 256, 384 o 512 bytes hashs. 
    EL código de abajo produce un hash de 256 bytes.

    Este hash es vulnerable a "lenght extension attacks" donde una persona maliciosa puede agregar información al final del documento
    existente, sin alterar el hash. SHA 3 ofrece protección contra este ataque, pero no se encuentra presente dentro de Security.Criptography
    */

    //class Program
    //{
    //    static byte[] calculateHash(string source)
    //    {
    //        // This will convert our input string into bytes and back
    //        ASCIIEncoding converter = new ASCIIEncoding();
    //        byte[] sourceBytes = converter.GetBytes(source);
    //        HashAlgorithm hasher = SHA256.Create();
    //        byte[] hash = hasher.ComputeHash(sourceBytes);
    //        return hash;
    //    }
    //    static void showHash(string source)
    //    {
    //        Console.Write("Hash for {0} is: ", source);
    //        byte[] hash = calculateHash(source);
    //        foreach (byte b in hash)
    //            Console.Write("{0:X} ", b);
    //        Console.WriteLine();
    //    }
    //    static void Main(string[] args)
    //    {
    //        showHash("Hello world");
    //        showHash("world Hello");
    //        showHash("Hemmm world");
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Enciptación de streams
    
    /* Ver en PAG 278 - Volver a ver esto despues de llegar a Skill 4-1   */

    #endregion



}
