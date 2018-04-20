using System;
using System.Collections.Generic;

namespace BookInfo.Models
{
    public class Author
    {
        private List<Book> books = new List<Book>();

        public int AuthorID { get; set; }   // PK
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<Book> Books { get { return books; } }

        public override bool Equals(object obj)
        {
                Author authorObj = obj as Author;
            if (authorObj == null)
                return false;
            else
                return Name == authorObj.Name && Birthday == authorObj.Birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = -1696464566;
            hashCode = hashCode * -1521134295 + AuthorID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}
