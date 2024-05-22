using FTech.Domain.Entities.Categories;
using FTech.Domain.Entities;

namespace FTech.Domain.Entities.Cars
{
    public class Car : Auditable
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string DeliverySize { get; set; }
        public string DriveType { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
    }
}
