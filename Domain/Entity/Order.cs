namespace Domain.Entities;
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerPhoneNumber{get;set;}
        public Customer Customer { get; set; }
    public Category Category { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public double Amount { get; set; }
    public Installement Installements { get; set; }

}
public enum Category
{
    Smartphone = 0,
    Computer = 1,
    Television = 2
}
public enum Installement
{
    Three = 3,
    Six = 6,
    Nine = 9,
    Twelve = 12,
    Eighteen = 18,
    TwentyFour = 24
}
