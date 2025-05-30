using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Stateless;
namespace BugTests
{

    [TestClass]
    public class BugTests
    {
        [TestMethod]
        public void OpenState_Assign_ChangesToAssigned()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void OpenState_Close_ThrowsException()
        {
            var bug = new Bug(Bug.State.Open);
            Assert.ThrowsException<InvalidOperationException>(() => bug.Close());
        }

        [TestMethod]
        public void AssignedState_Close_ChangesToClosed()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState());
        }

        [TestMethod]
        public void AssignedState_Defer_ChangesToDefered()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Defer();
            Assert.AreEqual(Bug.State.Defered, bug.getState());
        }

        [TestMethod]
        public void AssignedState_Reject_ChangesToRejected()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Reject();
            Assert.AreEqual(Bug.State.Rejected, bug.getState());
        }

        [TestMethod]
        public void AssignedState_InProc_ChangesToInProcess()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.InProc();
            Assert.AreEqual(Bug.State.InProcess, bug.getState());
        }

        [TestMethod]
        public void AssignedState_Block_ChangesToBlocked()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Block();
            Assert.AreEqual(Bug.State.Blocked, bug.getState());
        }

        [TestMethod]
        public void AssignedState_Assign_RemainsAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void ClosedState_Assign_ChangesToAssigned()
        {
            var bug = new Bug(Bug.State.Closed);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void DeferedState_Assign_ChangesToAssigned()
        {
            var bug = new Bug(Bug.State.Defered);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void DeferedState_Reject_ChangesToRejected()
        {
            var bug = new Bug(Bug.State.Defered);
            bug.Reject();
            Assert.AreEqual(Bug.State.Rejected, bug.getState());
        }

        [TestMethod]
        public void InProcessState_Close_ChangesToClosed()
        {
            var bug = new Bug(Bug.State.InProcess);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState());
        }

        [TestMethod]
        public void InProcessState_Defer_ChangesToDefered()
        {
            var bug = new Bug(Bug.State.InProcess);
            bug.Defer();
            Assert.AreEqual(Bug.State.Defered, bug.getState());
        }

        [TestMethod]
        public void BlockedState_Defer_ChangesToDefered()
        {
            var bug = new Bug(Bug.State.Blocked);
            bug.Defer();
            Assert.AreEqual(Bug.State.Defered, bug.getState());
        }

        [TestMethod]
        public void RejectedState_Assign_ChangesToAssigned()
        {
            var bug = new Bug(Bug.State.Rejected);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void BlockedState_Close_ThrowsException()
        {
            var bug = new Bug(Bug.State.Blocked);
            Assert.ThrowsException<InvalidOperationException>(() => bug.Close());
        }

        [TestMethod]
        public void InProcessState_Assign_ThrowsException()
        {
            var bug = new Bug(Bug.State.InProcess);
            Assert.ThrowsException<InvalidOperationException>(() => bug.Assign());
        }

        [TestMethod]
        public void RejectedState_Close_ThrowsException()
        {
            var bug = new Bug(Bug.State.Rejected);
            Assert.ThrowsException<InvalidOperationException>(() => bug.Close());
        }

        [TestMethod]
        public void DeferedState_Close_ThrowsException()
        {
            var bug = new Bug(Bug.State.Defered);
            Assert.ThrowsException<InvalidOperationException>(() => bug.Close());
        }

        [TestMethod]
        public void MainWorkflow_EndsInAssigned()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Close();
            bug.Assign();
            bug.Reject();
            bug.Assign();
            bug.InProc();
            bug.Block();
            bug.Defer();
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }
    }
}