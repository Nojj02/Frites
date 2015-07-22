using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Frites.Core.Tests.Models;

namespace Frites.Core.Tests.Mappings
{
    public class ItemMapping : ClassMap<Item>
    {
        public ItemMapping()
        {
            Table("Items");

            Id(x => x.Id)
                .Column("ItemId");
            Map(x => x.Code)
                .Not.Nullable()
                .Length(255);
            Map(x => x.Description)
                .Not.Nullable()
                .Length(1000);
        }
    }
}
