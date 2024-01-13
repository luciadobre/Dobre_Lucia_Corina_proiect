namespace Dobre_Lucia_Corina_proiect.Models
{
    public class Distributor
    {
        public int ID { get; set; }
        public string DistributorName { get; set; }
        public string Address { get; set; }
        public ICollection<Product>? Product { get; set; }
    }
}
