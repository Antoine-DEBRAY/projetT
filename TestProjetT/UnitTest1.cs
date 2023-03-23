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
            List<Service> services = new List<Service>{
                new Service{Id = 1, Intitule = "Service 2"},
                new Service{Id = 2, Intitule = "Service 3"},
                new Service{Id = 3, Intitule = "Service 1"},
                new Service{Id = 4, Intitule = "Comptabilité"},
            };
            Mock.Get(bddpersonnels).Setup(s => s.getAllServices()).Returns(services);

            // act
            List<Service> maSuperListe = bddpersonnels.getAllServices();

            // assert
            maSuperListe.Should().HaveCount(4);
            maSuperListe[0].Id.Should().Be(1);
            maSuperListe[0].Intitule.Should().Be("Service 2");
            maSuperListe[1].Id.Should().Be(2);
            maSuperListe[1].Intitule.Should().Be("Service 3");
            maSuperListe[2].Id.Should().Be(3);
            maSuperListe[2].Intitule.Should().Be("Service 1");
            maSuperListe[3].Id.Should().Be(4);
            maSuperListe[3].Intitule.Should().Be("Comptabilité");
        }

        [TestMethod]
        public void TestDeGetAllFonctions_RetourneUneListeDeToutesLesFonctions()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            List<Fonction> fonctions = new List<Fonction>{
                new Fonction{Id = 1, Intitule = "Fonction 2"},
                new Fonction{Id = 2, Intitule = "Fonction 3"},
                new Fonction{Id = 3, Intitule = "Fonction 1"},
                new Fonction{Id = 4, Intitule = "Directeur"},
            };
            Mock.Get(bddpersonnels).Setup(s => s.getAllFonctions()).Returns(fonctions);

            // act
            List<Fonction> maSuperListe = bddpersonnels.getAllFonctions();

            // assert
            maSuperListe.Should().HaveCount(4);
            maSuperListe[0].Id.Should().Be(1);
            maSuperListe[0].Intitule.Should().Be("Fonction 2");
            maSuperListe[1].Id.Should().Be(2);
            maSuperListe[1].Intitule.Should().Be("Fonction 3");
            maSuperListe[2].Id.Should().Be(3);
            maSuperListe[2].Intitule.Should().Be("Fonction 1");
            maSuperListe[3].Id.Should().Be(4);
            maSuperListe[3].Intitule.Should().Be("Directeur");
        }

        [TestMethod]
        public void TestDeGetAllPersonnels_RetourneUneListeDeToutLesPersonnels()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            List<Personnel> personnels = new List<Personnel>{
                new Personnel{Id = 1, Nom = "AARON", Prenom = "Abella", Telephone = "0654789625"},
                new Personnel{Id = 2, Nom = "ABDELALI", Prenom = "Abraham", Telephone = "0547896214"},
                new Personnel{Id = 3, Nom = "ABDOULAYE", Prenom = "Acélie", Telephone = "0654789651"},
                new Personnel{Id = 4, Nom = "ABEL", Prenom = "Achille", Telephone = "0654789321"},
            };
            Mock.Get(bddpersonnels).Setup(s => s.getAllPersonnels()).Returns(personnels);

            // act
            List<Personnel> maSuperListe = bddpersonnels.getAllPersonnels();

            // assert
            maSuperListe.Should().HaveCount(4);
            maSuperListe[0].Id.Should().Be(1);
            maSuperListe[0].Nom.Should().Be("AARON");
            maSuperListe[0].Prenom.Should().Be("Abella");
            maSuperListe[0].Telephone.Should().NotBe(null);
            maSuperListe[1].Id.Should().Be(2);
            maSuperListe[1].Nom.Should().Be("ABDELALI");
            maSuperListe[1].Prenom.Should().Be("Abraham");
            maSuperListe[1].Telephone.Should().NotBe(null);
            maSuperListe[2].Id.Should().Be(3);
            maSuperListe[2].Nom.Should().Be("ABDOULAYE");
            maSuperListe[2].Prenom.Should().Be("Acélie");
            maSuperListe[2].Telephone.Should().NotBe(null);
            maSuperListe[3].Id.Should().Be(4);
            maSuperListe[3].Nom.Should().Be("ABEL");
            maSuperListe[3].Prenom.Should().Be("Achille");
            maSuperListe[3].Telephone.Should().NotBe(null);
        }

        [TestMethod]
        public void TestDeGetAllServices_RetourneZeroServices()
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

        [TestMethod]
        public void TestDeGetAllFonctions_RetourneZeroFonctions()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            var oui = Mock.Of<List<Fonction>>();
            Mock.Get(bddpersonnels).Setup(s => s.getAllFonctions()).Returns(oui);

            // act
            List<Fonction> maSuperListe = bddpersonnels.getAllFonctions();

            // assert
            maSuperListe.Should().HaveCount(0);
        }

        [TestMethod]
        public void TestDeGetAllPersonnels_RetourneZeroPersonnels()
        {
            // arrange
            CBDDPersonnels bddpersonnels = Mock.Of<CBDDPersonnels>();
            var oui = Mock.Of<List<Personnel>>();
            Mock.Get(bddpersonnels).Setup(s => s.getAllPersonnels()).Returns(oui);

            // act
            List<Personnel> maSuperListe = bddpersonnels.getAllPersonnels();

            // assert
            maSuperListe.Should().HaveCount(0);
        }

        [TestMethod]
        public void TestDeTrierLesServices_RetourneUneListeDeTousLesServicesTries()
        {
            // arrange
            CBDDPersonnels bddpersonnels = new CBDDPersonnels();
            List<Service> services = new List<Service>
            {
                new Service{Id = 1, Intitule = "Service 2"},
                new Service{Id = 2, Intitule = "Service 3"},
                new Service{Id = 3, Intitule = "Service 1"},
                new Service{Id = 4, Intitule = "Comptabilité"},
            };

            // act
            bddpersonnels.TrierLesServices(services);

            // assert
            services.Count.Should().Be(4);
            services[0].Id.Should().Be(4);
            services[0].Intitule.ToString().Should().Be("Comptabilité");
            services[1].Intitule.ToString().Should().Be("Service 1");
            services[1].Id.Should().Be(3);
            services[2].Intitule.ToString().Should().Be("Service 2");
            services[2].Id.Should().Be(1);
            services[3].Intitule.ToString().Should().Be("Service 3");
            services[3].Id.Should().Be(2);
        }

        [TestMethod]
        public void TestDeTrierLesFonctions_RetourneUneListeDeToutesLesFonctionsTries()
        {
            // arrange
            CBDDPersonnels bddpersonnels = new CBDDPersonnels();
            List<Fonction> fonctions = new List<Fonction>{
                new Fonction{Id = 1, Intitule = "Fonction 2"},
                new Fonction{Id = 2, Intitule = "Fonction 3"},
                new Fonction{Id = 3, Intitule = "Fonction 1"},
                new Fonction{Id = 4, Intitule = "Directeur"},
            };

            // act
            bddpersonnels.TrierLesFonctions(fonctions);

            // assert
            fonctions.Should().HaveCount(4);
            fonctions[0].Id.Should().Be(4);
            fonctions[0].Intitule.Should().Be("Directeur");
            fonctions[1].Id.Should().Be(3);
            fonctions[1].Intitule.Should().Be("Fonction 1");
            fonctions[2].Id.Should().Be(1);
            fonctions[2].Intitule.Should().Be("Fonction 2");
            fonctions[3].Id.Should().Be(2);
            fonctions[3].Intitule.Should().Be("Fonction 3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Il n'y a aucun service à trier")]
        public void TestDeTrierLesServices_RetourneUneErreurCarAucunServices()
        {
            // arrange
            CBDDPersonnels bDDPersonnels = new CBDDPersonnels();
            List<Service> liste = new List<Service>();

            // act
            bDDPersonnels.TrierLesServices(liste);

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Il n'y a aucune fonction à trier")]
        public void TestDeTrierLesFonctions_RetourneUneErreurCarAucuneFonctions()
        {
            // arrange
            CBDDPersonnels bDDPersonnels = new CBDDPersonnels();
            List<Fonction> liste = new List<Fonction>();

            // act
            bDDPersonnels.TrierLesFonctions(liste);

            // assert
        }
    }
}
