using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Dtos
{
    public class installmentDto
    {
    public Category Category { get; set; }
    public double ProductPrice { get; set; }
    public Installement Installements { get; set; }

    }
}