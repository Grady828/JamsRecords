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
                Console.WriteLine("(B)ands (A)lbums (S)ongs (V)iew or (Q)uit");
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
                    Console.WriteLine("Would you like to (a)dd an album, (v)iew all albums by release date, or (e)nter a band name to view all albums? ");
                    var userChoice = Console.ReadLine().ToUpper().Trim();
                    if (userChoice == "a")
                    {
                        Console.WriteLine("What is the Title of the new album? ");
                        var newTitle = Console.ReadLine();
                        Console.WriteLine("Is this album Explicit? True or False please. ");
                        var newIsExplicit = bool.Parse(Console.ReadLine());
                        Console.WriteLine("When was the album released? yyyymmdd ");
                        var newReleaseDate = Console.ReadLine();
                        Console.WriteLine("Please enter the that bands BandId");
                        var newBandId = int.Parse(Console.ReadLine());

                        var newAlbum = new Albums
                        {
                            Title = newTitle,
                            IsExplicit = newIsExplicit,
                            ReleaseDate = newReleaseDate,
                            BandId = newBandId,
                        };
                    }
                }

            }
        }
    }
}
