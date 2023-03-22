using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BddpersonnelContext;
using biblioBDDpersonnels;
using System.Collections.Generic;
using Moq;
using FluentAssertions;
using appliWPFBDDpersonnels;

namespace TestProjetT
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestDeGetAllServices_RetourneUneListeDeTousLesServices()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            Service test = new Service();
            test.Id = 1;
            test.Intitule = "Nouveau Service";
            Service test2 = new Service();
            test2.Id = 2;
            test2.Intitule = "Deuxième service";
            var liste = Mock.Of<List<Service>>();
            liste.Add(test);
            liste.Add(test2);
            Mock.Get(bddpersonnels).Setup(s => s.getAllServices()).Returns(liste);

            // act
            List<Service> maSuperListe = bddpersonnels.getAllServices();

            // assert
            maSuperListe.Should().HaveCount(2);
            maSuperListe[0].Id.Should().Be(1);
            maSuperListe[0].Intitule.Should().Be("Nouveau Service");
            maSuperListe[1].Id.Should().Be(2);
            maSuperListe[1].Intitule.Should().Be("Deuxième service");
        }

        [TestMethod]
        public void TestDeLaRecupertionDesServices_RetourneUneErreurCarAucunService()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            var oui = Mock.Of<List<Service>>();
            Mock.Get(bddpersonnels).Setup(s => s.getAllServices()).Returns(oui);

            // act
            List<Service> maSuperListe = bddpersonnels.getAllServices();

            // assert
            maSuperListe.Should().HaveCount(0);
        }
    }
}
