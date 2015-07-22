namespace Frites.Core.Tests.Models
{
    public class Item
    {
        public virtual int Id { get; protected set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}