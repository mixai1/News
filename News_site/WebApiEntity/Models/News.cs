using System;
using System.Collections.Generic;

namespace WebApiEntity.Models
{
    public class News : IEquatable<News>
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }
        public double IndexOfPositive { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Comments> Comments { get; set; }

        public bool Equals(News other)
        {
            if (other is null)
                return false;

            return this.Header == other.Header && this.Body == other.Body;
        }

        public override bool Equals(object obj) => Equals(obj as News);
        public override int GetHashCode() => (Header, Body).GetHashCode();
    }
}
