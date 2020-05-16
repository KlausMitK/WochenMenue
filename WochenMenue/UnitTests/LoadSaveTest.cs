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
            //TODO: Ein File aus dem Test-Ordner laden
            LoadSaveFile loadSaveFile = new LoadSaveFile();
            Woche woche = loadSaveFile.Load("XXXXX___FILE____NAME");

            Assert.AreEqual(woche.Montag.Gericht, "Eierpampe");

            Assert.AreEqual(woche.Dienstag.Zutaten[0].Name, "Eier");

            Assert.AreEqual(woche.Dienstag.Zutaten[0].Menge, 2);


            //TODO: Für mehrere Tage püfen, ob Gerichte und Zutaten stimmen.
        }

        [Test]
        public void SaveTest()
        {
            //TODO: Einen Tag mit einem Gericht und Zutaten anlegen

            //TODO:Den Tag in eine Woche einhängen

            //TODO: Diese Woche speichern

            //TODO: Dann die Woche laden

            //TODO: Prüfen, dass nur ein Tag in der Woche ist

            //TODO: Prüfen, dass das Gericht für den Tag stimmt

            //TODO: Prüfen, dass die Zutaten für den Tag stimmen
        }


    }
}
