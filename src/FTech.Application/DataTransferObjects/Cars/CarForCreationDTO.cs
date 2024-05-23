using FTech.Domain.Entities.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Application.DataTransferObjects.Cars
{
    public class CarForCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public IFormFile Image { get; set; }
        public long CategoryId { get; set; }
    }
}
