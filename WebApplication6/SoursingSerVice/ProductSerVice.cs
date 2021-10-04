using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Data;
using static WebApplication6.SoursingSerVice.Event;

namespace WebApplication6.SoursingSerVice
{
    public class ProductSerVice
    {
        public string ProductId { get; set; }
        private readonly ApplicationDbContext _context;
        public ProductSerVice(ApplicationDbContext context,string productId)
        {
            TakeListProduct();
            ProductId = productId;
            _context = context;
        }
        
        public IDictionary<string,IList<IEvent>> GetDic= new Dictionary<string,IList<IEvent>>();
        public async Task AddEvent(IEvent request)
        {
            switch(request)
            {
                case Recived recive:
                    {
                        await Add(recive);
                        break;
                    }
                case Adjusted adjust:
                    {
                        await Add(adjust);
                        break;
                    }
                case Send send:
                    {
                        await Add(send);
                        break;

                    }
            }    
        }
        public async Task<IDictionary<string, IList<IEvent>>> TakeListProduct()
        {
            IDictionary<string, IList<IEvent>> listtake = new Dictionary<string, IList<IEvent>>();
            var listproduct = await _context.Products.ToListAsync();
            var listproductmanager = await _context.ManagerProducts.ToListAsync();
            foreach(var product in listproduct)
            {
                IList<IEvent> listEvents  = new List<IEvent>();
                foreach(var prductmaager in listproductmanager)
                {
                    if(prductmaager.ProductId == product.Id)
                    {
                        if(prductmaager.Status ==1)
                        {
                            var recive = new Recived(prductmaager.Id, prductmaager.Quantity, DateTime.Now);
                            listEvents.Add(recive);
                        }    
                        if(prductmaager.Status==2)
                        {
                            var send = new Recived(prductmaager.Id, prductmaager.Quantity, DateTime.Now);
                            listEvents.Add(send);
                        }
                        else
                        {
                            var send = new Adjusted(prductmaager.Id, prductmaager.Quantity,"", DateTime.Now);
                            listEvents.Add(send);
                        }
                       
                    }    
                }
                listtake.Add(ProductId, listEvents);
            }
            return listtake;

        }
        public async Task<Dictionary<string, IList<IEvent>>> TakeProduct()
        {
            Dictionary<string,IList<IEvent>> getall = new Dictionary<string,IList<IEvent>>();
            var product = await _context.Products.FindAsync(ProductId);
            var listproductmanager = await _context.ManagerProducts.ToListAsync();
            IList<IEvent> list = new List<IEvent>();
            foreach (var proc in listproductmanager)
            {
                if (proc.ProductId == product.Id)
                {
                    if (proc.Status == 1)
                    {
                        var recive = new Recived(proc.Id, proc.Quantity, DateTime.Now);
                        list.Add(recive);
                    }
                    if (proc.Status == 2)
                    {
                        var send = new Recived(proc.Id, proc.Quantity, DateTime.Now);
                        list.Add(send);
                    }
                    else
                    {
                        var send = new Adjusted(proc.Id, proc.Quantity, "", DateTime.Now);
                        list.Add(send);
                    }

                }
            }
            getall.Add(ProductId, list);
            return getall;
        }
        public IDictionary<string, IList<IEvent>> GetAll()
        {
            return GetDic;
        }
        public async Task Add(Recived recived)
        {
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity + recived.quantity;
            IList<IEvent> events = new List<IEvent>();
            events = GetDic[ProductId];
            events.Add(recived);
            GetDic.Add(ProductId, events);
        }
        public async Task Add(Send send)
        {
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity - send.quantity;
            IList<IEvent> events = new List<IEvent>();
            events = GetDic[ProductId];
            events.Add(send);
            GetDic.Add(ProductId, events);
        }    
        public async Task Add(Adjusted request)
        {
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity + request.quantity;
            IList<IEvent> events = new List<IEvent>();
            events = GetDic[ProductId];
            events.Add(request);
            GetDic.Add(ProductId, events);
        }
    }
}
