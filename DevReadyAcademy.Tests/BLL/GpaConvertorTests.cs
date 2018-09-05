using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevReadyAcademy.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReadyAcademy.BLL.Tests
{
    [TestClass()]
    public class GpaConvertorTests
    {
        [TestMethod()]
        public void ConvertNumberToLetterTest()
        {
            var Gpa = 83;
            var expected = "B";
            var actual = DevReadyAcademy.BLL.GpaConvertor.ConvertNumberToLetter(Gpa);
            Assert.AreEqual(expected, actual);
        }
    }
}