using FTech.Domain.Entities.Categories;
using FTech.Domain.Entities;

namespace FTech.Domain.Entities.Cars
{
    public class Car : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
