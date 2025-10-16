namespace PeripheralsAPI_Assignment_6.Models
{
    public class Peripheral
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public int QuantityInStock { get; set; }

        public decimal Price { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
