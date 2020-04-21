using DDCA.HelloWorld.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDCA.HelloWorld.UnitTests
{
    [TestClass]
    public class HelloWorldNamesEntityTests
    {
        [TestMethod]
        public void NullParameter()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(null);

            Assert.IsNotNull(helloWorldEntity);
            Assert.IsNotNull(helloWorldEntity.ExistingNames);
            Assert.IsNotNull(helloWorldEntity.NewNames);
            Assert.IsNotNull(helloWorldEntity.AllNamesAphabetical);
            Assert.IsNotNull(helloWorldEntity.NewNamesAlphabetical);
        }

        [TestMethod]
        public void ExistingNames_ExistingNames()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(new string[] { "John", "Jack", "Jill" });

            Assert.IsTrue(helloWorldEntity.ExistingNames.Count() == 3);
            Assert.IsTrue(helloWorldEntity.ExistingNames.Contains("John"));
            Assert.IsTrue(helloWorldEntity.ExistingNames.Contains("Jack"));
            Assert.IsTrue(helloWorldEntity.ExistingNames.Contains("Jill"));
        }

        [TestMethod]
        public void ExistingNames_AllNamesAlphabetical()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(new string[] { "John", "Jack", "Jill" });

            var allNamesAlphabetical = helloWorldEntity.AllNamesAphabetical.ToList();

            Assert.IsTrue(allNamesAlphabetical[0] == "Jack");
            Assert.IsTrue(allNamesAlphabetical[1] == "Jill");
            Assert.IsTrue(allNamesAlphabetical[2] == "John");
        }


        [TestMethod]
        public void NewNamesAdded_NewNames()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(null);
            helloWorldEntity.AddName("John");
            helloWorldEntity.AddName("Jack");
            helloWorldEntity.AddName("Jill");

            Assert.IsTrue(helloWorldEntity.ExistingNames.Count() == 0);
            Assert.IsTrue(helloWorldEntity.NewNames.Count() == 3);
            Assert.IsTrue(helloWorldEntity.NewNames.Contains("John"));
            Assert.IsTrue(helloWorldEntity.NewNames.Contains("Jack"));
            Assert.IsTrue(helloWorldEntity.NewNames.Contains("Jill"));
        }

        [TestMethod]
        public void NewNamesAdded_NewNamesAlphabetical()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(null);
            helloWorldEntity.AddName("John");
            helloWorldEntity.AddName("Jack");
            helloWorldEntity.AddName("Jill");

            var newNamesAlphabetical = helloWorldEntity.NewNamesAlphabetical.ToList();

            Assert.IsTrue(helloWorldEntity.ExistingNames.Count() == 0);
            Assert.IsTrue(newNamesAlphabetical.Count() == 3);
            Assert.IsTrue(newNamesAlphabetical[0] == "Jack");
            Assert.IsTrue(newNamesAlphabetical[1] == "Jill");
            Assert.IsTrue(newNamesAlphabetical[2] == "John");
        }

        [TestMethod]
        public void NewNamesAdded_AllNamesAlphabetical()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(null);
            helloWorldEntity.AddName("John");
            helloWorldEntity.AddName("Jack");
            helloWorldEntity.AddName("Jill");

            var allNamesAlphabetical = helloWorldEntity.AllNamesAphabetical.ToList();

            Assert.IsTrue(helloWorldEntity.ExistingNames.Count() == 0);
            Assert.IsTrue(allNamesAlphabetical.Count() == 3);
            Assert.IsTrue(allNamesAlphabetical[0] == "Jack");
            Assert.IsTrue(allNamesAlphabetical[1] == "Jill");
            Assert.IsTrue(allNamesAlphabetical[2] == "John");
        }

        [TestMethod]
        public void NewNamesAdded_ExistingNames_AllNamesAlphabetical()
        {
            var helloWorldEntity = new HelloWorldNamesEntity(new string[] { "Allis", "Barbara" });
            helloWorldEntity.AddName("Adam");
            helloWorldEntity.AddName("Bob");

            var allNamesAlphabetical = helloWorldEntity.AllNamesAphabetical.ToList();

            Assert.IsTrue(helloWorldEntity.ExistingNames.Count() == 2);
            Assert.IsTrue(allNamesAlphabetical.Count() == 4);
            Assert.IsTrue(allNamesAlphabetical[0] == "Adam");
            Assert.IsTrue(allNamesAlphabetical[1] == "Allis");
            Assert.IsTrue(allNamesAlphabetical[2] == "Barbara");
            Assert.IsTrue(allNamesAlphabetical[3] == "Bob");
        }



    }
}
