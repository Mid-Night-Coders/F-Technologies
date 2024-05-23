using FTech.Domain.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Domain.Entities.Categories
{
    public class Category : Auditable
    {
        public string Model { get; set; }
        public ICollection<Car> Cars { get; set; } 
    }
}
