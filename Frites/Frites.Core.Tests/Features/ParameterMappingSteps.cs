using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Frites.Core.Tests.Models;
using TechTalk.SpecFlow;

namespace Frites.Core.Tests.Features
{
    [Binding]
    public sealed class ParameterMappingSteps
    {
        private Item item;

        [When(@"I save Item (.*) with description (.*)")]
        public void SaveItemWithDescription(string itemCode, string itemDescription)
        {
            item =
            //var item =
                new Item
                {
                    Code = itemCode,
                    Description = itemDescription
                };

            //_session.Save(item);
        }

        [Then(@"I should have Item (.*) with description (.*)")]
        public void VerifyItem(string itemCode, string itemDescription)
        {
            //Item item = _session.Where(x => x.Code == itemCode).SingleOrDefault();

            item.Code.Should().Be(itemCode);
            item.Description.Should().Be(itemDescription);
        }
    }
}
