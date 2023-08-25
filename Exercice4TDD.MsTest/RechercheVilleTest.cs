using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4TDD.MsTest
{
    [TestClass]
    public class RechercheVilleTest
    {
        private RechercheVille? _rechercheVille;

        [TestInitialize] // s'exécutera AVANT CHAQUE TEST
        public void SetUp()
        {
            _rechercheVille = new RechercheVille();
        }
        [TestCleanup]  // s'exécutera APRES CHAQUE TEST
        public void Down()
        {
            _rechercheVille = null;
        }

        // 1 - Si le texte de la recherche contient moins de 2 caractères, Une exception est levée de type NotFoundException.
        [TestMethod]
        public void WhenRechercheVille_LessThan2Digits_Then_NotFoundException()
        {
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("a")) ;
        }
    }
}
