using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LearningCwithFramework
{
    class _19_DataAccess
    {
    }

    #region I/O Operations
    //Pag 340
    #region leer y escribir archivos y streams
    /*
    .net Framework proporciona una clas Stream que sirve como padre de un rango de clases que se utilizan para leer y escribir datos.
    Hay 3 formas en las que un programa puede interactuar con un Stream
        - Escribir una secuencia de Bytes
        - Leer una secuencia de Bytes
        - Posicionar el "file Pointer" del Stream

    El file Pointer es la posición del Strem en donde la siguiente operación de lectura o escritura se ejjecutará. 

    Árbol de clases

        System.IO.Stream  (Abstract)
            |
            |-- System.IO.BufferedStream
            |-- System.IO.FileStream
            |-- System.IO.MemoryStream
            |-- System.IO.PipeStream
            |-- System.IO.NetworkStream
    
        Todas estas clases comparten lo que heredan del padre, como por ejemplo el método write, con el cual se podra escribir en cualquier
        tipo de Stream. Sin embargo la creación de cada strem depende de que tipo se trate.

     */

    #region FileStream

    /*
     UN objeto Filestrem proporciona una instancia de un Stream conectado a un archivo. El Strem se conecta con el sistema de archivos de la
     pc, y es este el que se conecta con el dispositivo de almacenamiento.

     */

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Writing to a file
    //        FileStream outputStream = new FileStream("OutputText.txt", FileMode.
    //        OpenOrCreate, FileAccess.Write);
    //        string outputMessageString = "Hello world";
    //        byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
    //        outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
    //        outputStream.Close();
    //        FileStream inputStream = new FileStream("OutputText.txt", FileMode.Open,
    //        FileAccess.Read);
    //        long fileLength = inputStream.Length;
    //        byte[] readBytes = new byte[fileLength];
    //        inputStream.Read(readBytes, 0, (int)fileLength);
    //        string readString = Encoding.UTF8.GetString(readBytes);
    //        inputStream.Close();
    //        Console.WriteLine("Read message: {0}", readString);
    //        Console.ReadKey();
    //    }
    //}

    #region FileMode y FileAccess
    /*
        FileModes:
            -FileMode.Append: Solo sirve para escribir al final de un archivo. Si no existe el archivo se crea. 
            -FileMode.Create: Crea un archivo para escribir en el. Si el archivo ya existe lo sobreescribe.
            -FileMode.CreateNew: Igual que el anterior pero si el archivo ya existe tira una excepción.
            -FileMode.Open: Sirve para leer o escribir. si el archivo no existe lanza una excepción.
            -FileMode.OpenOrCreate
            -FileMode.Truncate: Abre un archivo para escribir. Cualquier contenido anterior se borra.

        FileAcces:
            FileAcces.Read
            FileAcces.ReadWrite
            FileAcces.Write
     
     */
    #endregion

    #region Convertir texto en datos binarios con Unicode
    /*
    un Strem solo puede transferir bytes desde y hacia un dispositivo de almacenamiento. Por eso es necesario convertir lo que se desea enviar
    primero a unicode, y luego insertarlo en el strem, o hacer el proceso inverso para leerlo. Por defecto se usa el UTF8, pero hay otros tipos
    de encodeo.
    El metodo GetBytes toma un string y devuelve los bytes que lo representan en el encoding especificado.
    */

    #endregion

    #region IDispose & FileStream
    /*
    La clase Stream implementa IDisposable. Lo que significa que podemos utilizar "using" para asegurarnos de que los archivos son cerrados.
    
    using (FileStream outputStream = new FileStream(“OutputText.txt”, FileMode.OpenOrCreate,
    FileAccess.Write))
    {
     string outputMessageString = “Hello world”;
     byte[] outputMessageBytes = Encoding.UTF8.GetBytes(outputMessageString);
     outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
    } 
     
    */



    #endregion

    #region Trabajando con archivos de Texto
    /*
     El sistema de archivos no hace niguna diferencia entre archivos de texto y archivos binarios.Si bien ya hemos visto como convertir un string
     en bytes con determinado encoding, existe una forma más sencilla de trabajar con archivos de texto. Las clases TextWriter y TextReader son
     clases abstractas que definen ciertos métodos para trabajar con texto.
     La clase StreamWriter extiende TextWriter para proporcionarnos una clase que podamos utilizar para escribir en archivos texto. 
    */
    //class Program {
    //    static void Main(string[] args) {
    //        using (StreamWriter writeStream = new StreamWriter("OutputText.txt"))
    //        {
    //            writeStream.Write("Hello world");
    //        }
    //        using (StreamReader readStream = new StreamReader("OutputText.txt"))
    //        {
    //            string readSTring = readStream.ReadToEnd();
    //            Console.WriteLine("Text read: {0}", readSTring);
    //        }
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region Encadenamiento de streams
    /*
    La clase Stream tiene un metodo que recibe a otro Strem como parametro, permitiendo la encadenacion de Strems. El espacio de nombres
    IO.Compression puede cargar y guardar cadenas de stream.  (supongo que al encadenarlos los comprime??) VER PAG 345

    */

    //class Program {
    //    static void Main(string[] args) {
    //        using (FileStream writeFile = new FileStream("CompText.zip", FileMode.OpenOrCreate, FileAccess.Write))
    //        {
    //            using (GZipStream writeFileZip = new GZipStream(writeFile,
    //            CompressionMode.Compress))
    //            {
    //                using (StreamWriter writeFileText = new StreamWriter(writeFileZip))
    //                {
    //                    writeFileText.Write("Hello world");
    //                }
    //            }
    //        }
    //        using (FileStream readFile = new FileStream("CompText.zip", FileMode.Open,
    //         FileAccess.Read))
    //        {
    //            using (GZipStream readFileZip = new GZipStream(readFile,
    //            CompressionMode.Decompress))
    //            {
    //                using (StreamReader readFileText = new StreamReader(readFileZip))
    //                {
    //                    string message = readFileText.ReadToEnd();
    //                    Console.WriteLine("Read text: {0}", message);
    //                }
    //            }
    //        }
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region Utilización de la clase File
    /*
    La clase File (abstracta )es un helper para trabajar con archivos con mayor facilidad. Contiene una serie de métodos que nos permiten 
    añadir texto a un archivo, copiar un archivo, crearlo, borrarlo, moverlo, abrirlo, leerlo y administrar sus seguridad. 
    */

    //class Program {
    //    static void Main(string[] args) {
    //        File.WriteAllText(path: "c:\\temp\\TextFile.txt", contents: "This text goes in the file");
    //        File.AppendAllText(path: "c:\\temp\\TextFile.txt", contents: " - This goes on the end");
    //        if (File.Exists("c:\\temp\\TextFile.txt"))
    //            Console.WriteLine("Text File exists");
    //        string contents = File.ReadAllText(path: "c:\\temp\\TextFile.txt");
    //        Console.WriteLine("File contents: {0}", contents);
    //        if(File.Exists("c:\\temp\\CopyTextFile.txt"))
    //            File.Delete("c:\\temp\\CopyTextFile.txt");
    //        File.Copy(sourceFileName: "c:\\temp\\TextFile.txt", destFileName: "c:\\temp\\CopyTextFile.txt");
    //        using (TextReader reader = File.OpenText(path: "c:\\temp\\CopyTextFile.txt"))
    //        {
    //            string text = reader.ReadToEnd();
    //            Console.WriteLine("Copied text: {0}", text);
    //        }
    //        //Practica de lo de mas arriba:
    //        using (StreamWriter writeStream = new StreamWriter("c:\\temp\\CopyTextFile.txt"))
    //        {
    //            //writeStrem pisa el archivo. Parece que no tiene nada parecido al Append de mas arriba. AUnque se podria leer, guardar en 
    //            //EnvironmentVariableTarget y volver a escribir, es mas facil con FIle
    //            writeStream.WriteLine("Added with StremWriter, this delete the previous content");
    //            writeStream.WriteLine("Add another Line");

    //        }
    //        using (StreamReader readStream = new StreamReader("c:\\temp\\CopyTextFile.txt"))
    //        {
    //            string readSTring = readStream.ReadToEnd();
    //            Console.WriteLine("Text read with readStream: {0}", readSTring);
    //        }


    //        Console.ReadKey();


    //    }
    //}

    #endregion

    #region Manejo de excepciones de Strem
    /*
    PAG 346. Basicamente tener cuidado con Strem, hay muchas razones por las que podria lanzar excepciones. Usar siempre los stream con try cartch 
    */

    #endregion

    #region File Storage
    /*
     * La clase DriveInfo nos proporciona información sobre las distintas particiones de un dispositivo de almacenamiento.
    */
    //class Program {
    //    static void Main(string[] args) {
    //        DriveInfo[] drives = DriveInfo.GetDrives();
    //        foreach (DriveInfo drive in drives)
    //        {
    //            Console.Write("Name:{0} ", drive.Name);
    //            if (drive.IsReady)
    //            {
    //                Console.Write(" Type:{0}", drive.DriveType);
    //                Console.Write(" Format:{0}", drive.DriveFormat);
    //                Console.Write(" Free space:{0}", drive.TotalFreeSpace);
    //            }
    //            else
    //            {
    //                Console.Write(" Drive not ready");
    //            }
    //            Console.WriteLine();

    //        }
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region FileInfo

    /* PAG 348
     * FileInfo nos proporciona informacion sobre uno o mas archivos. Nos permite principalmente leer y modificar sus atributos de lectura, 
     * escritura, path, directorio, si esta comprimido, si es oculto, si es un archivo de sistema, o si es temporal. Ejemplo:
    */

    //class Program {
    //    static void Main(string[] args)
    //    {
    //        string filePath = "TextFile.txt";
    //        File.WriteAllText(path: filePath, contents: "This text goes in the file");
    //        FileInfo info = new FileInfo(filePath);
    //        Console.WriteLine("Name: {0}", info.Name);
    //        Console.WriteLine("Full Path: {0}", info.FullName);
    //        Console.WriteLine("Last Access: {0}", info.LastAccessTime);
    //        Console.WriteLine("Length: {0}", info.Length);
    //        Console.WriteLine("Attributes: {0}", info.Attributes);
    //        Console.WriteLine("Make the file read only");
    //        info.Attributes |= FileAttributes.ReadOnly;
    //        Console.WriteLine("Attributes: {0}", info.Attributes);
    //        Console.WriteLine("Remove the read only attribute");
    //        info.Attributes &= ~FileAttributes.ReadOnly;
    //        Console.WriteLine("Attributes: {0}", info.Attributes);
    //        Console.ReadKey();
    //    }
    //}



    #endregion

    #region Directory y DirectoryInfo
    /*
     * Directory y DirectoryInfo, son similares a File y FileInfo, pero para directorios.
    */

    //class Program {
    //    static void Main(string[] args) {
    //        Directory.CreateDirectory("TestDir");
    //        if (Directory.Exists("TestDir"))
    //            Console.WriteLine("Directory created successfully");
    //        Directory.Delete("TestDir");
    //        Console.WriteLine("Directory deleted successfully");
    //        Console.ReadKey();
    //    }
    //}

    #endregion

    #region Path
    /*
     * La clase Path nos proporciona varios m[etodos para trabajar con paths.
     * La @ hace que el string sea "verbatim", que significa que no debe considerar \ como un caracter de escape. De lo no usar @, tendriamos que
     * poner \\ en el path, para "escapear" el caracter \
     * 
     * Tener en cuenta que en las rutas relativas, se utiliza . para referirise al directorio actual .. para el enterior y \ como separador
     * 
    */
    //class Program {
    //    static void Main(string[] args) {
    //        string fullName = @"c:\users\rob\Documents\test.txt";
    //        string dirName = Path.GetDirectoryName(fullName);
    //        string fileName = Path.GetFileName(fullName);
    //        string fileExtension = Path.GetExtension(fullName);
    //        string lisName = Path.ChangeExtension(fullName, ".lis");
    //        string newTest = Path.Combine(dirName, "newtest.txt");
    //        Console.WriteLine("Full name: {0}", fullName);
    //        Console.WriteLine("File directory: {0}", dirName);
    //        Console.WriteLine("File name: {0}", fileName);
    //        Console.WriteLine("File extension: {0}", fileExtension);
    //        Console.WriteLine("File with lis extension: {0}", lisName);
    //        Console.WriteLine("New test: {0}", newTest);
    //        Console.ReadKey();
    //    }
    //}


    #endregion

    #region Busqueda de archivos
    /* Para buscar archivos es posible usar el metodo GetFiles o GetDirectories
    */
    //class Program {

    //        static void FindFiles(DirectoryInfo dir, string searchPattern)
    //        {
    //            foreach (DirectoryInfo directory in dir.GetDirectories())
    //            {
    //                FindFiles(directory, searchPattern);
    //            }
    //            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
    //            foreach (FileInfo fileInfo in matchingFiles)
    //            {
    //                Console.WriteLine(fileInfo.FullName);
    //            }
    //        }
    //        static void Main(string[] args)
    //        {
    //            DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
    //            string searchString = "*.cs";
    //            FindFiles(startDir, searchString);
    //            Console.ReadKey();
    //        }
    //}



    #endregion



    #endregion

    #region System.Net
    /*
     * Ver intro en 352, basicamente habla de lo que es http.
    */

    #region WebRequest
    /*
     * Esta es la forma con mayor flexibiidad, y por consiguiente la mas compleja. Se puede usar de forma asincrona pero el programador debe
     * encargarse.
     * 
     * La clase abstracta WebRequest especifica los comportamientos que deben cumplir sus herederos.
     * Create : 
        * Expone un metodo statico llamado Create, que recibe una URI que especifica el recurso a ser utilizado. La clase WebRequest examina la
        * URI y devuelve un WebRequest acorde. La salida puede ser un objeto HttpWebRequest, FtpWebRequest, o FileWebRequest. 
     
     *HttpWebResponse:
        * GetResponse:
            *El metodo GetResponse de una HttpWebRequest devuelve una instancia de WebResponse que describe la respuesta del server. No es la
            * pagina misma, sino una respuesta que describe la respuesta del servidor.
        *GetResponseStream: este método si es el que recibe la página en si misma. 
     *
     */

    //class Program {
    //    static void Main(string[] args) {
    //        WebRequest webRequest = WebRequest.Create("https://www.microsoft.com");
    //        WebResponse webResponse = webRequest.GetResponse(); // <-- Response
    //        using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))  //<-- ResponseStream
    //        {
    //            string siteText = responseReader.ReadToEnd();
    //            Console.WriteLine(siteText);
    //            Console.ReadKey();
    //        }

    //    }
    //}


    #endregion

    #region WebClient 
    /*
     * La clase WebClient proporciona una forma mas sencilla de leer las respuestas de un servidor. Se puede usar de forma síncrona o asíncrona.
     
     */
    //Ejemplo sincrónico.
    //class Program {
    //    static void Main(string[] args)
    //    {
    //        WebClient client = new WebClient();
    //        string siteText = client.DownloadString("http://www.microsoft.com");
    //        Console.WriteLine(siteText);
    //        Console.ReadKey();
    //    }
    //}

    //Ejemplo asincrónico
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        bool working = true;
    //        var siteText = Program.readWebpage("http://www.microsoft.com");
    //        while (working)
    //        {
    //            if (siteText.IsCompleted) {
    //                Console.WriteLine(siteText.Result);
    //                Console.ReadKey();
    //                working = false;
    //            }
    //        }

    //    }

    //    public static async Task<string> readWebpage(string uri)
    //    {
    //        WebClient client = new WebClient();
    //        return await client.DownloadStringTaskAsync(uri);
    //    }
    //}

    #endregion

    #region HttpClient
    /*
     * El HttpClient es importante porque es la forma en que una Windows Universal Application puede descargar un website. A diferencia de
     * WebRequesty WebClient, HttpCliente solo proporciona métodos asíncronos. Puede utilizarse de una forma muy similar a WebClient 
     
     */
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        bool working = true;
    //        var siteText = Program.readWebpage("http://www.microsoft.com");
    //        while (working)
    //        {
    //            if (siteText.IsCompleted)
    //            {
    //                Console.WriteLine(siteText.Result);
    //                Console.ReadKey();
    //                working = false;
    //            }
    //        }

    //    }

    //    public static async Task<string> readWebpage(string uri)
    //    {
    //        HttpClient client = new HttpClient();
    //        return await client.GetStringAsync(uri);
    //    }
    //}




    #endregion

    #region WebClient Vs HttpClient
    /*
    
    Articulo interesante: https://www.infoworld.com/article/3198673/when-to-use-webclient-vs-httpclient-vs-httpwebrequest.html
    (HttpClient it is the preferred way to consume HTTP requests unless you have a specific reason not to use it.)

    Sacadodo de: https://stackoverflow.com/questions/20530152/deciding-between-httpclient-and-webclient
    +--------------------------------------------+--------------------------------------------+
    |               WebClient                    |               HttpClient                   |
    +--------------------------------------------+--------------------------------------------+
    | Available in older versions of .NET        | .NET 4.5 only.  Created to support the     |
    |                                            | growing need of the Web API REST calls     |
    +--------------------------------------------+--------------------------------------------+
    | WinRT applications cannot use WebClient    | HTTPClient can be used with WinRT          |
    +--------------------------------------------+--------------------------------------------+
    | Provides progress reporting for downloads  | No progress reporting for downloads        |
    +--------------------------------------------+--------------------------------------------+
    | Does not reuse resolved DNS,               | Can reuse resolved DNS, cookie             |
    | configured cookies                         | configuration and other authentication     |
    +--------------------------------------------+--------------------------------------------+
    | You need to new up a WebClient to          | Single HttpClient can make concurrent      |
    | make concurrent requests.                  | requests                                   |
    +--------------------------------------------+--------------------------------------------+
    | Thin layer over WebRequest and             | Thin layer of HttpWebRequest and           |
    | WebResponse                                | HttpWebResponse                            |
    +--------------------------------------------+--------------------------------------------+
    | Mocking and testing WebClient is difficult | Mocking and testing HttpClient is easy     |
    +--------------------------------------------+--------------------------------------------+
    | Supports FTP                               | No support for FTP                         |
    +--------------------------------------------+--------------------------------------------+
    | Both Synchronous and Asynchronous methods  | All IO bound methods in                    |
    | are available for IO bound requests        | HTTPClient are asynchronous                |
    +--------------------------------------------+--------------------------------------------+
    If you’re using .NET 4.5, please do use the async good­ness with Http­Client that Microsoft pro­vides to the devel­op­ers. Http­Client is very sym­met­ri­cal to the server side brethren of the HTTP those are HttpRe­quest and HttpResponse.
    
    Update: 5 Rea­sons to use new Http­Client API:
    
    Strongly typed headers.
    Shared Caches, cook­ies and credentials
    Access to cook­ies and shared cookies
    Con­trol over caching and shared cache.
    Inject your code mod­ule into the ASP.NET pipeline. Cleaner and mod­u­lar code.
     
    */

    #endregion

    #region Manejo de Excepciones PAG 354
    /*
   Cargar informacion desde internet es propenso a errores. Siempre las conecciones a la red deben estar envueltas en try catchs. 

    */

    #endregion

    #region Implementar operacion I/O asíncronas PAG 355
    /*
     * Las operaciones sobre archivos proporcionadas por la clase File, no tienen ninguna versión asíncrona. Por lo tanto para lograr el 
     * asincronicmo debemos recurrir a la clase FileStream, algo como esto:
     * 
     async Task WriteBytesAsync(string filename, byte [] items)
     {
        using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate,FileAccess.Write))
        {
            await outStream.WriteAsync(items, 0, items.Length);
        }
     }
    */



    #endregion

    #region Manejo e excepciones en métodos asíncronos. PAG 356
    /*
     Recordemos que como vimos en la seccion de task, estos deben devolver un result, o un task. Los unicos que deberían devolver un void son
     los handlers. UNa mal código puede provocar que las excepciones no se lanzen. Aca un ejemplo de buena utilización. Notar donde van los try catchs

    private async void StartTaskButton_Click(object sender, RoutedEventArgs e)
    {
         byte[] data = new byte[100];
        try
        {
            // note that the filename contains an invalid character await
            WriteBytesAsyncTask("demo:.dat", data);
        }
        catch (Exception writeException)
        {
            MessageBox.Show(writeException.Message, "File write failed");
        }
    }
    .
     */
    #endregion

    #endregion

    #region
    /*
    */
    #endregion


    #endregion

    #endregion

    #region Consumo de datos PAG 357

    #region Recuperación de datos de una BD 358
    /*
     Nada nuevo. 
    */
    #endregion

    #region Lectura de datos con SQL PAG 358
    /*
    Los programas utilizan las bases de datos en una forma similar a la que utilizan un Stream. Primero se crea un objeto que reresenta la
    coneccion con la BD, y envían mensajes a través de ese objeto. El mecanismo de conección esta organizado también, de la misma forma en que
    están organizadas las operacion I/O de la clase Stream. La clase DbConnection (que representa la conección con la Bd) es abstracta, y describe
    los comportamientos de la conección. La clase SqlConnection es hija de DbConnection y representa una conección SQL.
    Para crear una conección a una Bd SQL es necesario crear un objeto SqlConnection, su constructor necesita recibir un "connectino string"
    que identifique la DB a ser consultada. 
    
    Ejemplo (No correr, no hay db creada)
    */
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string connectionString = "Server=(localdb)\\mssqllocaldb;" +
    //        "Database=MusicTracksContext-e0f0cd0d-38fe-44a4-add2-359310ff8b5d;" +
    //        "Trusted_Connection=True;MultipleActiveResultSets=true";
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack",
    //            connection);
    //            SqlDataReader reader = command.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                string artist = reader["Artist"].ToString();
    //                string title = reader["Title"].ToString();
    //                Console.WriteLine("Artist: {0} Title: {1}", artist, title);
    //            }
    //        }
    //        Console.ReadKey();
    //    }
    //}



    #endregion

    #region administracion de connection strings PAG 360
    /*
     Los connection strings se alamacenan en el archivo appsettings.json (al parecer guardar la info en Web.config es el viejo approach).

     Dentro de este archivo se pueden guardar tambien configuraciones para development y produccion:
     appsettings.development.json y appsettings.production.json

     Ejemplo de appsettings.json:
     {
        "Logging": {
            "IncludeScopes": false,
            "LogLevel": {
            "Default": "Warning"
            }
        },
        "ConnectionStrings": {
            "MusicTracksContext": "Server=(localdb)\\mssqllocaldb;Database=MusicTracksContexte0f0cd0d-38fe-44a4-add2-359310ff8b5d;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
     }

    Hay que diferenciar dos tipos de variabls de entorno
    - Variables de entorno de aplicaciciones ASP, determinar el seto de logging, tracing, debbuging, y la connection string.
    -Variavles de entorno: son administradas por windows. La variable de entorno ASPNETCORE_ENVIRONMENT puede ser seteada con valores
    para que la aplicacion ASP determine que entorno debe seleccionar cuando se ejecute. Se puede setear estas variables desde visual studio
    con pestaña Debug --> Properties.  (aunque yo persnoamlmente no lo veo como se uestra en la imagen) o desde windows.

    */
    #endregion

    #region operaciones SQL 362
    /*
        nada nuevo 
    */
    /*
        UPDATE:  PAG 363
        
            Nota sobre sql Injection PAG 363
        
                Forma correcta para evitar injections:
                    Console.Write("Enter the title of the track to update: ");
                    string searchTitle = Console.ReadLine();
                    Console.Write("Enter the new artist name: ");
                    string newArtist = Console.ReadLine();
                    string SqlCommandText =
                     "UPDATE MusicTrack SET Artist='" + newArtist + "' WHERE Title='" + searchTitle + "'";


        
     */
    #endregion

    #region Operaciones SQL asíncronas PAG 364
    /*
        Los comandos SQL tienen versiones asincronas que se puede utilizar con async/await
        Ejemplo de su uso: (no correr)
    */

    //async Task<string> dumpDatabase(SqlConnection connection)
    //{
    //    SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);
    //    SqlDataReader reader = await command.ExecuteReaderAsync();
    //    StringBuilder databaseList = new StringBuilder();
    //    while (await reader.ReadAsync())
    //    {
    //        string id = reader["ID"].ToString();
    //        string artist = reader["Artist"].ToString();
    //        string title = reader["Title"].ToString();
    //        string row = string.Format("ID: {0} Artist: {1} Title: {2}", id, artist, title);
    //        databaseList.AppendLine(row);
    //    }
    //    return databaseList.ToString();
    //}


    #endregion

    #region uso de SQL en aplicaciones ASP PAG 365
    /*
    Solo habla un poco de razor. (cuando usamos el @ en las paginas .cshtml) nada nuevo. 
    */

    #endregion

    #region consumo de Json 366
    /*
    Desde https://json2csharp.com/ se puede ingresar un json, y devuelve la clase en C# capaz de recibirlo... muy util para ahorrar tiempo.
    Por lo demas nada nuevo... 

    */
    #endregion

    #region consumo de XML PAG 368
    /*
    Ejemplo de lectura de un XMl con un reader.  
    */

    //class Program {
    //    static void Main(string[] Args) {
    //        string XMLDocument = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
    //            "<MusicTrack xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
    //            "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"> " +
    //            "<Artist>Rob Miles</Artist> " +
    //            "<Title>My Way</Title> " +
    //            "<Length>150</Length>" +
    //            "</MusicTrack>";

    //        using (StringReader stringReader = new StringReader(XMLDocument))
    //        {
    //            XmlTextReader reader = new XmlTextReader(stringReader);
    //            while (reader.Read())
    //            {
    //                string description = string.Format("Type:{0} Name:{1} Value:{2}", reader.NodeType.ToString(), reader.Name, reader.Value);                    
    //                Console.WriteLine(description);      
    //            }
    //            Console.ReadKey();
    //        }

    //    }

    //}

    #region Documentos XML
    /*
    una fomra mas sencilla de leer documentos XMl, es crear un objeto XMLDocument desde el cual podemos extraer la info.  
    */
    //class Program
    //{

    //    static void Main(string[] args) {

    //        string XMLDocument = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
    //                   "<MusicTrack xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
    //                   "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"> " +
    //                   "<Artist>Rob Miles</Artist> " +
    //                   "<Title>My Way</Title> " +
    //                   "<Length>150</Length>" +
    //                   "</MusicTrack>";

    //        XmlDocument doc = new XmlDocument();
    //        doc.LoadXml(XMLDocument);
    //        System.Xml.XmlElement rootElement = doc.DocumentElement;
    //        // make sure it is the right element
    //        if (rootElement.Name != "MusicTrack")
    //        {
    //            Console.WriteLine("Not a music track");
    //        }
    //        else
    //        {
    //            string artist = rootElement["Artist"].FirstChild.Value;
    //            Console.WriteLine("", artist);
    //            string title = rootElement["Title"].FirstChild.Value;
    //            Console.WriteLine("Artist:{0} Title:{1}", artist, title);
    //        }
    //        Console.ReadKey();
    //    }

    //}



    #endregion

    #endregion

    #region recuperacin de datos utilizando WCF 370
    /*Crea un sistema server-client, no voy a indagar demasiado en esto, es medio al pedo.   */
    #endregion


    #endregion


}
