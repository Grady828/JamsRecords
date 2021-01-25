using System;
using JamsRecords.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JamsRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new JamsRecordsContext();
            Console.WriteLine();
            Console.WriteLine("Welcome To Jams Records");
            var userHasNotChosenToQuit = false;
            while (userHasNotChosenToQuit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose from the following");
                Console.WriteLine("(B)ands (A)lbums (S)ongs (V)iew signed/unsigned Bands or (Q)uit");
                var choice = Console.ReadLine().ToLower().Trim();
                if (choice == "q")
                {
                    break;
                }
                if (choice == "b")
                {
                    Console.WriteLine("Would you like to (s)ign (r)elease or (v)iew all bands? ");
                    var userChoice = Console.ReadLine().ToLower().Trim();
                    if (userChoice == "s")
                    {
                        Console.WriteLine("What is the new Bands name? ");
                        var newBandName = Console.ReadLine();
                        Console.WriteLine("What country is the band from? ");
                        var newCountryOfOrigin = Console.ReadLine();
                        Console.WriteLine("How many members are in the band? ");
                        var newNumberOfMembers = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the bands website? ");
                        var newWebsite = Console.ReadLine();
                        Console.WriteLine("What style or genre is the new band");
                        var newStyle = Console.ReadLine();
                        Console.WriteLine("Is the band signed with us? True or False please.");
                        var newIsSigned = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Who is the bands main contact? ");
                        var newContactName = Console.ReadLine();
                        Console.WriteLine("What is the new bands 4 digit extension? ");
                        var newContactNumber = int.Parse(Console.ReadLine());

                        var newBand = new Bands

                        {
                            Name = newBandName,
                            CountryOfOrigin = newCountryOfOrigin,
                            NumberOfMembers = newNumberOfMembers,
                            Website = newWebsite,
                            Style = newStyle,
                            IsSigned = newIsSigned,
                            ContactName = newContactName,
                            ContactPhone = newContactNumber,
                        };
                        context.Bands.Add(newBand);
                        context.SaveChanges();


                    }
                    if (choice == "a")
                    {

                    }
                    if (userChoice == "r")
                    {
                        Console.WriteLine("What band would you like to release? ");
                        var releasedBand = Console.ReadLine();
                        var existingBand = context.Bands.FirstOrDefault(band => band.Name == releasedBand);
                        if (existingBand != null)
                        {
                            context.Bands.Remove(existingBand);
                            context.SaveChanges();
                        }
                    }
                    if (userChoice == "v")
                        foreach (var Band in context.Bands)
                        {
                            Console.WriteLine($"We are currently working with {Band.Name}.");
                        }

                }
                if (choice == "a")
                {
                    Console.WriteLine("Would you like to (a)dd an album, (v)iew all albums by release date, or (e)nter a band name to view its discography? ");
                    var userChoice = Console.ReadLine().ToLower().Trim();


                    if (userChoice == "a")
                    {
                        Console.WriteLine("What is the Title of the new album? ");
                        var newTitle = Console.ReadLine();
                        Console.WriteLine("Is this album Explicit? True or False please. ");
                        var newIsExplicit = bool.Parse(Console.ReadLine());
                        Console.WriteLine("When was the album released? yyyy-mm-dd");
                        var newReleaseDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the that bands name");
                        var newAlbumsBand = context.Bands.FirstOrDefault(band => band.Name == Console.ReadLine());


                        var newAlbum = new Albums
                        {
                            Title = newTitle,
                            IsExplicit = newIsExplicit,
                            ReleaseDate = newReleaseDate,
                            BandId = newAlbumsBand.Id,
                        };
                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                    }
                    if (userChoice == "v")
                    {
                        var albumsInOrder = context.Albums.OrderBy(albumsReleaseDate => albumsReleaseDate.ReleaseDate);

                        Console.WriteLine("Here is your list");

                        foreach (var album in albumsInOrder)

                        {
                            Console.WriteLine($"{album.Title} { album.ReleaseDate}");

                        }
                    }
                    if (userChoice == "e")
                    {
                        Console.WriteLine("Write the name of the band to see its discography");
                        var chosenBand = Console.ReadLine();
                        var chosenBandsAlbums = context.Albums.
                             Include(album => album.Band).
                             Where(album => album.Band.Name == chosenBand);
                        foreach (var album in chosenBandsAlbums)
                        {
                            Console.WriteLine($"The selected bands albums are {album.Title}");
                        }


                    }
                }
                if (choice == "s")
                {
                    Console.WriteLine("What is the Track number of the new song? ");
                    var newTrackNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the songs name?. ");
                    var newTitle = Console.ReadLine();
                    Console.WriteLine("How long is the song? ");
                    var newDuration = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the name of Album");
                    var newSongsAlbum = context.Albums.FirstOrDefault(album => album.Title == Console.ReadLine());

                    var newSong = new Songs
                    {
                        TrackNumber = newTrackNumber,
                        Title = newTitle,
                        Duration = newDuration,
                        AlbumId = newSongsAlbum.Id,
                    };
                    context.Songs.Add(newSong);
                    context.SaveChanges();
                }
                if (choice == "v")
                {
                    Console.WriteLine("View Bands that are (s)igned or (u)nsigned? ");
                    var userChoice = Console.ReadLine();
                    if (userChoice == "s")
                    {
                        var Bands = context.Bands;
                        var bandsThatAreSigned = Bands.Where(Bands => Bands.IsSigned == true);
                        foreach (var Band in bandsThatAreSigned)

                        {
                            Console.WriteLine($"{Band.Name} ");
                        }

                    }
                    if (userChoice == "u")
                    {
                        var Bands = context.Bands;
                        var bandsThatAreNotSigned = Bands.Where(Bands => Bands.IsSigned == false);
                        foreach (var Band in bandsThatAreNotSigned)
                        {
                            Console.WriteLine($"{Band.Name} ");
                        }


                    }
                }



            }
        }
    }
}
