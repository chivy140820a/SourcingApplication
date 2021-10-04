using System.Collections.Generic;

namespace WebApplication6.Entity
{
    public class ProductStatus
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public List<ManagerProduct> ManagerProducts { get; set; }
    }
}
