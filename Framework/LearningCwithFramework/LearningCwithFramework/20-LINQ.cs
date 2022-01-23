using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCwithFramework
{
    class _20_LINQ
    {
    }

    #region Consultas, manipulacion de datos y objetos con LINQ PAG 375

    class Program {

        static void Main(string[] args) {
            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

            List<Artist> artists = new List<Artist>();
            List<MusicTrack> musicTracks = new List<MusicTrack>();

            Random rand = new Random(1);
            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    musicTracks.Add(newTrack);
                }
            }
            //foreach (MusicTrack track in musicTracks)
            //{
            //    Console.WriteLine("Artist:{0} Title:{1} Length:{2}",
            //    track.Artist.Name, track.Title, track.Length);
            //}
            //Console.ReadKey();

            /////////////////////////////////////////////////////////
            //Hasta aca es todo para crear datos con los que jugar///
            /////////////////////////////////////////////////////////


            //Las querys se escriben muy parecidas a sql pero con el select al final, como se ejecuta realmente en sql.
            //IEnumerable<MusicTrack> selectedTracks = from track in musicTracks
            //                                         where track.Artist.Name == "Rob Miles"
            //                                         select track;

            //foreach (MusicTrack track in selectedTracks)
            //{
            //    Console.WriteLine("Artist:{0} Title:{1}", track.Artist.Name, track.Title);
            //}



            //Console.ReadKey();

            #region Proyeccion / projection
            ////Proyeccion / Projection

            //var selectedTracks = from track in musicTracks
            //                     where track.Artist.Name == "Rob Miles"
            //                     select new TrackDetails
            //                     {
            //                         ArtistName = track.Artist.Name,
            //                         Title = track.Title
            //                     };

            //foreach (TrackDetails track in selectedTracks)
            //{
            //    Console.WriteLine("Artist:{0} Title:{1}", track.ArtistName, track.Title);
            //}

            //Console.ReadKey();
            #endregion

            #region tipos anonimos
            //Tipos anonimos / Anonymous types

            //var selectedTracks = from track in musicTracks
            //                     where track.Artist.Name == "Rob Miles"
            //                     select new // projection type name missing from here
            //                     {
            //                         ArtistName = track.Artist.Name,
            //                         track.Title
            //                     };

            //foreach (var item in selectedTracks)
            //{
            //    Console.WriteLine("Artist:{0} Title:{1}", item.ArtistName, item.Title);
            //}
            //Console.ReadKey();

            #endregion

            #region Linq Join 
            //esto no funciona porque no existe la tabla en bd con el ID
            //var artistTracks = from artist in artists
            //                   where artist.Name == "Rob Miles"
            //                   join track in musicTracks on artist.ID equals track.ArtistID
            //                   select new
            //                   {
            //                       ArtistName = artist.Name,
            //                       track.Title
            //                   };

            //foreach (var track in artistTracks)
            //{
            //    Console.WriteLine("Artist:{0} Title:{1}", track.Artist.Name, track.Title);
            //}
            //Console.ReadKey();

            #endregion

            #region Linq Group
            //PAG 381  - Tambien necesita ID, no funciona sin BD. Nada nuevo, es un group de SQL
            #endregion

            #region Linq Take and skip
            //PAG 383 - Es interesante, sirve para hacer paginadores.
            #endregion

            #region Linq agregate commands
            //PAG 384 Son los Count() , avg(), sum() que se usan con los agrupadores en sql
            #endregion

            #region LINQ to XML
            //PAG 388 - No entiendi nada.
            #endregion

        }



    }
    class Artist
    {
        public string Name { get; set; }
    }
    class MusicTrack
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }
    class TrackDetails
    {
        public string ArtistName;
        public string Title;
    }


    #endregion


}
