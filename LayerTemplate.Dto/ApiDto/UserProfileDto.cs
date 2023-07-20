using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.Dto.ApiDto
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}
