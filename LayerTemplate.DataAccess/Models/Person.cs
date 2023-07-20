using System;
using System.Collections.Generic;

namespace LayerTemplate.DataAccess.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
    }
}
