using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace School.Web.Models
{

    [Table("Person",Schema ="HR")]
    public   class Person
    {
        
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Discriminator { get; set; }

    }
}
