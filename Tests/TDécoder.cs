using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    [TestCategory("FG")] // Mettre vos initiales ici
    public class TDécoder
    {
        [TestMethod]
        [Timeout(500)]
        [DataRow("", "")]
        [DataRow("z", "z*")]
        [DataRow("yoda", "ay*do***")]
        [DataRow("yoda", "ady*o***")]
        [DataRow("12345", "1*2*3*4*5*")]
        [DataRow("54321", "12345*****")]
        [DataRow("12345", "1*2*3*4*5*")]

        [DataRow("hokus-pokus", "suskoh***u**-*p*ko****")]
        [DataRow("hokus-pokus", "koh***u*sos*-*p**uk***")]
        [DataRow("hokus-pokus", "sopuoh**k**-s****k*u**")]

        [DataRow("c#-ou-python-?", "-h-uo-#c******yp**t**no***?*")]
        [DataRow("c#-ou-python-?", "nohty-#c***po*-u********?-**")]

        public void T01_Décodage(string décodage, string message)
        {
            Assert.AreEqual(décodage, Décoder.Program.Décoder(message));
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow("stack underflow", "123**4***5")]
        [DataRow("stack underflow", "12*34*56*7*****89*")]
        [DataRow("stack underflow", "*")]
        [DataRow("stack underflow", "123****")]
        [DataRow("123**4**[*]5", "123**4***5")]
        [DataRow("12*34*56*7****[*]89*", "12*34*56*7*****89*")]
        [DataRow("[*]", "*")]
        [DataRow("123***[*]*45", "123*****45")]
        public void T02_Underflow(string messageErreur, string message)
        {
            var ex = Assert.ThrowsException<FormatException>(
                () => Décoder.Program.Décoder(message));
            StringAssert.Contains(ex.Message, messageErreur);
        }

        [TestMethod]
        [Timeout(500)]
        [DataRow("étoiles manquantes", "ady*o**")]
        [DataRow("étoiles manquantes", "a")]
        [DataRow("étoiles manquantes", "ady*o*")]
        [DataRow("étoiles manquantes", "ady*o")]
        [DataRow("étoiles manquantes", "12345*")]
        [DataRow("étoiles manquantes", "12345**678*")]
        [DataRow("'*'", "ady*o**")]
        [DataRow("'*'", "a")]
        [DataRow("'**'", "ady*o*")]
        [DataRow("'***'", "ady*o")]
        [DataRow("'****'", "12345*")]
        [DataRow("'*****'", "12345**678*")]
        public void T03_ÉtoilesManquantes(string messageErreur, string message)
        {
            var ex = Assert.ThrowsException<FormatException>(
                () => Décoder.Program.Décoder(message));
            StringAssert.Contains(ex.Message, messageErreur);
        }

    }

}
