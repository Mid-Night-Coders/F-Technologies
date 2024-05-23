using FTech.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Application.DataTransferObjects.Cars
{
    public class CarForResultDTO
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public long Id { get; set; }
        public Category Category { get; set; }
    }
}
