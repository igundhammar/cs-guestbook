using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Moment3.Classes;

namespace Moment3.Classes
{
    public class Entry
    {
        public readonly string Author;
        public readonly string EntryText;


        // Constructor to set the strings of inputs to properties of the class.
        public Entry(string author, string entry)
        {
            if (author == null && entry == null) return;
            this.Author = author;
            this.EntryText = entry;
        }
    }
}