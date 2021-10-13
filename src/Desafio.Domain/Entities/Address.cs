namespace Desafio.Domain.Entities
{
    public class Address : Entity
    {
        public string PublicPlace { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public void SetAddress(Address address)
        {
            PublicPlace = address.PublicPlace;
            Number = address.Number;
            Complement = address.Complement;
            ZipCode = address.ZipCode;
            District = address.District;
            City = address.City;
            State = address.State;
        }
    }
}
