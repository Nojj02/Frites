using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Frites.Core.Tests.Models;
using NHibernate;
using TechTalk.SpecFlow;

namespace Frites.Core.Tests.Features
{
    [Binding]
    public sealed class ParameterMappingSteps
    {
        [When(@"I save Item (.*) with description (.*)")]
        public void SaveItemWithDescription(string itemCode, string itemDescription)
        {
            var session = Injector.Get<ISession>();

            var item =
                new Item
                {
                    Code = itemCode,
                    Description = itemDescription
                };

            using (var transaction = session.BeginTransaction())
            {
                session.Save(item);

                transaction.Commit();
            }
        }

        [Then(@"I should have Item (.*) with description (.*)")]
        public void VerifyItem(string itemCode, string itemDescription)
        {
            var session = Injector.Get<ISession>();

            var item = 
                session.QueryOver<Item>()
                    .Where(x => x.Code == itemCode)
                    .SingleOrDefault();

            item.Code.Should().Be(itemCode);
            item.Description.Should().Be(itemDescription);
        }
    }
}
