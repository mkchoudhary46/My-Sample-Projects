using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_AngularJs_ASPNET_MVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
    }
}
