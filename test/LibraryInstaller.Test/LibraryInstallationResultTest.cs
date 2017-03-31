﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibraryInstaller.Test
{
    [TestClass]
    public class LibraryInstallationResultTest
    {
        [TestMethod]
        public void Constructor()
        {
            Mocks.LibraryInstallationState state = GetState();

            var ctor1 = new LibraryInstallationResult(state);
            Assert.AreEqual(state, ctor1.InstallationState);
            Assert.AreEqual(0, ctor1.Errors.Count);
            Assert.IsTrue(ctor1.Success);
            Assert.IsFalse(ctor1.Cancelled);

            var ctor2 = new LibraryInstallationResult(state, PredefinedErrors.ManifestMalformed());
            Assert.AreEqual(state, ctor2.InstallationState);
            Assert.AreEqual(1, ctor2.Errors.Count);
            Assert.IsFalse(ctor2.Success);
            Assert.IsFalse(ctor2.Cancelled);
        }

        [TestMethod]
        public void FromSuccess()
        {
            Mocks.LibraryInstallationState state = GetState();
            var result = LibraryInstallationResult.FromSuccess(state);

            Assert.AreEqual(state, result.InstallationState);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.IsTrue(result.Success);
            Assert.IsFalse(result.Cancelled);
        }

        [TestMethod]
        public void FromCancelled()
        {
            Mocks.LibraryInstallationState state = GetState();
            var result = LibraryInstallationResult.FromCancelled(state);

            Assert.AreEqual(state, result.InstallationState);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Cancelled);
        }

        private static Mocks.LibraryInstallationState GetState()
        {
            return new Mocks.LibraryInstallationState
            {
                ProviderId = "_prov_",
                LibraryId = "_lib_",
                Path = "_path_",
                Files = new List<string>() { "a", "b" },
            };
        }

    }
}