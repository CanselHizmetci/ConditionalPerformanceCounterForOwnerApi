using System;
namespace Owner.API.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
    }
}

