namespace Domain.Dtos;
using Domain.Entities;
public class ProductDto{
    public int Id { get; set; }
    public Category Category { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public Installement Installements { get; set; }
  
}
public class AddProduct :ProductDto
{

}