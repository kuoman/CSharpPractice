using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PersonalPractice.Gilded_Rose.RefactorTry2
{
    [TestClass]
    public class GildedRoeseRefactorTry2Tests
    {
        [TestMethod, Ignore]
        public void Test()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseRefactorTry2 app = new GildedRoseRefactorTry2(items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", items[0].Name);
        }
    }
}
