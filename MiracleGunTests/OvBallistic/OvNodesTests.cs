﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiracleGun.OvBallistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleGun.OvBallistic.Tests
{
    [TestClass()]
    public class OvNodesTests
    {
        [TestMethod()]
        public void GetIntTest()
        {
            var n = new OvNodes();
            int i = n.GetInt();
            Assert.Fail();
        }
    }
}