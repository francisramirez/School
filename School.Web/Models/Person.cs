using System;

namespace School.Web.Models
{
    public   class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Discriminator { get; set; }

    }
}
