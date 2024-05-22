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
        public int Id { get; set; }
        public Category Category { get; set; }
        public string DeliverySize { get; set; }
        public string DriveType { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
    }
}
