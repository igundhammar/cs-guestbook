using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Moment3.Classes
{
    public class Entries
    {
        private readonly List<Entry> _guestbook;

        // Constructor of the Entries class, initialize a new empty List.
        public Entries()
        {
            this._guestbook = new List<Entry>();
        }


        // Read file "Entry.txt" and set the lines of the text file to variables. Call function AddEntry with parameters of the variables.
        public bool ReadFile()
        {
            if (!File.Exists("Entry.txt"))
            {
                return false;
            }
            else
            {
                try
                {
                    using StreamReader read = new StreamReader("Entry.txt");
                    while (!read.EndOfStream)
                    {
                        var author = read.ReadLine();
                        var entryText = read.ReadLine();
                        var entry = new Entry(author, entryText);
                        this.AddEntry(entry);
                    }
                }
                catch (Exception)
                {
                    return true;
                }
            }

            return true;
        }


        // Add the entry from ReadFile to the List of all entries.
        public void AddEntry(Entry entry)
        {
            this._guestbook.Add(entry);
        }


        // Get the whole List (guestbook).
        public List<Entry> GetGuestbook()
        {
            return this._guestbook;
        }


        // Get input from user and remove from list.
        public void DeleteEntry(string deleteInput)
        {
            var intInput = Int32.Parse(deleteInput);
            var list = this.GetGuestbook();
            list.RemoveAt(intInput);
        }


        // Write to file, get guestbook as list and write all entries in the list to text file.
        public void WriteToFile()
        {
            var list = this.GetGuestbook();
            var file = new StreamWriter("Entry.txt");
            foreach (var e in list)
            {
                file.WriteLine($"{e.Author}");
                file.WriteLine($"{e.EntryText}");
            }
            file.Close();
        }
    }
}