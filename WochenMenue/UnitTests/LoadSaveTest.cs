using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using NUnit.Framework;
using Utils;

namespace UnitTests
{
    class LoadSaveTest
    {
        [SetUp]
        public void setup()
        {
            SetUpIniAndLogging.SetUp();
        }

        [Test]
        public void LoadTest()
        {
            LoadSaveFile loadSaveFile = new LoadSaveFile();
            Woche woche = loadSaveFile.Load(PropValues.Instance().TestDirectory + "\\Volle RezeplisteTest.xml");

            Assert.AreEqual(woche.Montag.Gericht, "Kuchen, Spätzle");
            Assert.AreEqual(woche.Dienstag.Zutaten[0].Name, "Butter");
            Assert.AreEqual(woche.Dienstag.Zutaten[0].Menge, 10);
            Assert.AreEqual(woche.Mittwoch.Zutaten[2].Einheit, "gr");
            Assert.AreEqual(woche.Donnerstag.Zutaten.Count, 3);
            Assert.AreEqual(woche.Freitag.Zutaten[1].Menge, 20);
            Assert.AreEqual(woche.Samstag.Zutaten[2].Name, "Mehl");
            Assert.AreEqual(woche.Sonntag.Zutaten[0].Einheit, "Stück");
            Assert.AreEqual(woche.Dienstag.Gericht, "Pfannenkuchen");
            Assert.AreEqual(woche.Mittwoch.Gericht, "Pizza");
            Assert.AreEqual(woche.Donnerstag.Gericht, "Halumi Pfanne");
            Assert.AreEqual(woche.Freitag.Gericht, "Pudding");
            Assert.AreEqual(woche.Samstag.Gericht, "Schnitzel");
            Assert.AreEqual(woche.Sonntag.Gericht, "Taccos");
        }

        [Test]
        public void SaveTest()
        {
            Tag montag = new Tag();
            montag.Gericht = "Schnitzel";
            Zutat Fleisch = new Zutat();
            Fleisch.Name = "Fleisch";
            Fleisch.Menge = 500;
            Fleisch.Einheit = "gr";
            montag.Zutaten.Add(Fleisch);

            Woche woche = new Woche();
            woche.Montag = montag;

            LoadSaveFile laodSaveFile = new LoadSaveFile();
            laodSaveFile.Save(woche, PropValues.Instance().TestDirectory + "\\SaveTest.xml");

            Woche newWoche = laodSaveFile.Load(PropValues.Instance().TestDirectory + "\\SaveTest.xml");

            Assert.AreEqual(newWoche.Montag.Gericht, "Schnitzel");
            Assert.AreEqual(newWoche.Montag.Zutaten.Count, 1);

            Assert.AreEqual(newWoche.Montag.Zutaten[0].Name, "Fleisch");
            Assert.AreEqual(newWoche.Montag.Zutaten[0].Menge, 500);
            Assert.AreEqual(newWoche.Montag.Zutaten[0].Einheit, "gr");

            TesteTag(newWoche.Dienstag);
            TesteTag(newWoche.Mittwoch);
            TesteTag(newWoche.Donnerstag);
            TesteTag(newWoche.Freitag);
            TesteTag(newWoche.Samstag);
            TesteTag(newWoche.Sonntag);
        }

        private void TesteTag(Tag tag)
        {
            Assert.AreEqual(tag.Zutaten.Count, 0);
            Assert.AreEqual(tag.Gericht, "");
        }

    }
}
