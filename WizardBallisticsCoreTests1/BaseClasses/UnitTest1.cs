﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardBallistics.Core;

namespace WizardBallisticsCoreTests1.BaseClasses {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            WBVec a = new WBVec(1, 2, 3, 4, 5);
            var b = a.Clone();
            b[1] = 999;
            Assert.AreNotEqual(a[1], b[1]);
        }
    }
}
