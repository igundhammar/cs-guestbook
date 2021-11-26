using System;
using System.Net.Mime;
using System.Threading.Channels;
using Moment3.Classes;

namespace Moment3
{
    class Program
    {
        public static void Main()
        {
            // Create instance of Entries class and run ReadFile
            var entries = new Entries();
            var result = entries.ReadFile();
            // Loop until option X is pressed by user
            while (true)
            {
                // Write menu to user console
                Console.WriteLine("IDAS GÄSTBOK");
                Console.WriteLine("[1] - Skriv i gästboken");
                Console.WriteLine("[2] - Radera ur gästboken");
                Console.WriteLine("[3] - Se alla inlägg");
                Console.WriteLine("[X] - Avsluta");
                // Read input from user
                var input = Console.ReadLine();
                // Switch to decide what to do from input
                switch (input)
                {


                    // Case 1, clear console, get inputs from user with name and entry text. Check if they're empty and if not, continue to add entry to list with all entries and write to text file.
                    case "1":
                        Console.Clear();
                        Console.WriteLine("För att avsluta, tryck x när som helst.");
                        Console.WriteLine("Vad heter du? ");
                        var author = Console.ReadLine();
                        if (author == "")
                        {
                            Console.WriteLine("Ditt namn får inte vara tomt.");
                            Console.WriteLine("Vad heter du? ");
                            author = Console.ReadLine();
                        }

                        if (author == "x" || author == "X")
                        {
                            return;
                        }

                        Console.WriteLine("Skriv ditt inlägg: ");
                        var entryText = Console.ReadLine();
                        if (entryText == "")
                        {
                            Console.WriteLine("Ditt inlägg kan inte vara tomt.");
                            Console.WriteLine("Skriv ditt inlägg: ");
                            entryText = Console.ReadLine();
                        }

                        if (entryText == "x" || entryText == "X")
                        {
                            return;
                        }

                        var entry = new Entry(author, entryText);
                        entries.AddEntry(entry);
                        entries.WriteToFile();
                        break;


                    // Case 2, get guestbook (list) from entries and get input from user with what ID to delete from guestbook. Check if input is empty or not in range of the list. If not, delete entry from list and write new list to text file.
                    case "2":
                        var guestbook = entries.GetGuestbook();
                        Console.WriteLine("Vilket inlägg vill du radera? (ID)");
                        string deleteInput = Console.ReadLine();
                        if (deleteInput == "")
                        {
                            Console.WriteLine("Ange ett ID ur gästboken för att radera.");
                            Console.WriteLine("Vilket inlägg vill du radera? (ID)");
                            deleteInput = Console.ReadLine();
                        }
                        var intInput = Int32.Parse(deleteInput);
                        if (intInput < 0 || intInput > guestbook.Count)
                        {
                            Console.WriteLine($"Hittade inget inlägg med ID {deleteInput}");
                            Console.WriteLine("Vilket inlägg vill du radera? (ID)");
                            deleteInput = Console.ReadLine();
                        }
                        else
                        {
                            entries.DeleteEntry(deleteInput);
                            entries.WriteToFile();
                            Console.WriteLine("Inlägget raderat!");

                        }
                        break;


                    // Case 3, check if guestbook is empty and write errormessage. If not, loop through the guestbook and print out to the console all entries of the guestbook.
                    case "3":
                        Console.Clear();
                        if (!result)
                        {
                            Console.WriteLine("Gästboken är tom. Skriv ett inlägg!");
                            Console.WriteLine();
                        }
                        else
                        {
                            var list = entries.GetGuestbook();
                            var i = 0;
                            foreach (var e in list)
                            {
                                Console.WriteLine($"ID: {i}");
                                Console.WriteLine($"Författare: {e.Author}");
                                Console.WriteLine($"Meddelande: {e.EntryText}");
                                Console.WriteLine();
                                i++;
                            }
                        }

                        break;


                    // Case x, if the user enters X at any time the program will shut down.
                    case "x":
                        Environment.Exit(0);
                        break;


                    // Case default, if the user enters anything else than any of the cases above, write error message.
                    default:
                        Console.Clear();
                        Console.WriteLine("Ange ett giltigt nummer, eller [X] för att avsluta.\n");
                        break;
                }
            }
        }
    }
}