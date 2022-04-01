using System;

namespace Vet.Domain
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string Race { get; set; }
    }
}
