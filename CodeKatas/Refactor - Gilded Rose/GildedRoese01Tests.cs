using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodeKatas
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod, Ignore]
        public void Test()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", items[0].Name);
        }
    }
}
