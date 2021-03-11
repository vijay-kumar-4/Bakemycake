using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Auth_Forms.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ImagePath { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}