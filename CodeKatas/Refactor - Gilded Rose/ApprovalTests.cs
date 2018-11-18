using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKatas
{
    [TestClass]
    public class ApprovalTest
    {
        [TestMethod]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            //Program.Main(new string[] { });
            //String output = fakeoutput.ToString();
            //Approvals.Verify(output);
        }
    }
}
