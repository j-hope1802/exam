namespace Domain.Dtos;
public class CustomerDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
}
public class AddCustomer : CustomerDto
{

}