using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.SRC.ProceduleDungeon.Utilities;
using UnityEngine;
using UnityEngine.TestTools.Utils;


namespace Assembly_CSharp_TestSpace.___Tests___.ProceduleDungeon.Tests.Utilities
{
    internal class GenericTests
    {
        private Generic Generic { get; set; } = null;

        [SetUp]
        private void SetUp() 
        {
            Generic = new Generic();
        }
        [TearDown]
        private void TearDown()
        {
            Generic = null;
        }

        [TestCase(1)]
        [Test]
         public Task Test_NeighborsPositions(float scale)
        {
            var result = Generic.NeighborsPosition(scale);
            
        }
    }
}
