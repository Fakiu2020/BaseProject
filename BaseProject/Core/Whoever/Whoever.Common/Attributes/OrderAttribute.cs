using System;

namespace Whoever.Common.Attributes
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class OrderAttribute : Attribute
    {
        public int Order { get; set; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}
