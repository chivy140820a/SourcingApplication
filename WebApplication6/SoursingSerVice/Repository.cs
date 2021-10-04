using System.Threading.Tasks;
using WebApplication6.Data;
using System.Collections.Generic;

namespace WebApplication6.SoursingSerVice
{
    public class Repository
    {
        
        private readonly ApplicationDbContext _context;
        public string ProductId { get; set; }
        public Repository(ApplicationDbContext context,string productId)
        {
            ProductId = productId;
            _context = context;
        }   
        public async Task GetAll()
        {
            var productService = new ProductSerVice();
            return await productService.GetAll();
            
        }    
    }
}
