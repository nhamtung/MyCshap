using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vn.Ntq.RoboFW.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Commons;

namespace Vn.Ntq.RoboFW.Commands.Tests
{
    [TestClass()]
    public class MultiMapBufferTests
    {
        [TestMethod()]
        public void AddAndRemoveTest()
        {
            MultiMapBuffer<RoboMessage> mmb = new MultiMapBuffer<RoboMessage>();
            ResponseFactory cf = new ResponseFactory();
            mmb.Add(cf.Create(new byte[] { 1, 1, 3}));
            mmb.Add(cf.Create(new byte[] { 2, 2, 3 }));
            mmb.Add(cf.Create(new byte[] { 3, 3, 3 }));
            mmb.Add(cf.Create(new byte[] { 1, 4, 3 }));
            mmb.Add(cf.Create(new byte[] { 3, 5, 3 }));
            mmb.Add(cf.Create(new byte[] { 2, 6, 3 }));

            var a = mmb.Remove(cf.Create(new byte[] { 1 }));
            Assert.AreEqual((byte)1, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 1 }));
            Assert.AreEqual((byte)4, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 3 }));
            Assert.AreEqual((byte)3, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 2 }));
            Assert.AreEqual((byte)2, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 2 }));
            Assert.AreEqual((byte)6, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 3 }));
            Assert.AreEqual((byte)5, a.GetData()[1]);
            a = mmb.Remove(cf.Create(new byte[] { 3 }));
            Assert.IsNull(a);
        }

       
    }
}