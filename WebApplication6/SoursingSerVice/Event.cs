using System;

namespace WebApplication6.SoursingSerVice
{
    public class Event
    {
        public interface IEvent { };
        public record Recived(int productId ,int quantity,DateTime dateCreated): IEvent;
        public record Send(int productId, int quantity, DateTime dateCreated):IEvent;
        public record Adjusted(int productId, int quantity,string reason, DateTime dateCreated): IEvent;
    }
}
