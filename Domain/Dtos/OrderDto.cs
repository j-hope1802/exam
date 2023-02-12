using Domain.Entities;

namespace Domain.Dtos;
public class OrderDto
{
    public int Id{get;set;}

    public int CustomerId{get;set;}
    
    public int ProductId{get;set;}
  
    public Category Category { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
     public string CustomerPhoneNumber{get;set;}
    public double Amount{get;set;}
    public Installement Installements { get; set; }



}
public class AddOrder : OrderDto
{

}