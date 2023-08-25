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

        // 2 - Si le texte de recherche est égal ou supérieur à 2 caractères, il doit renvoyer tous les noms de ville commençant
        //          par le texte de recherche exact.
        //     Par exemple, pour le texte de recherche "Va", la fonction doit renvoyer Valence et Vancouver
        [TestMethod]
        public void WhenRechercheVille_Va_Then_ListVillesVa()
        {
            List<String> listVilles = _rechercheVille.Rechercher("Va");
            List<String> listToCompare = new() {"Valence","Vancouver"};
            CollectionAssert.IsSubsetOf(listToCompare, listVilles); 
        }

        //3 - La fonctionnalité de recherche doit être insensible à la casse
        [TestMethod]
        public void WhenRechercheVille_Va_Then_ListVillesVA()
        {
            List<String> listVilles = _rechercheVille.Rechercher("VA");
            List<String> listToCompare = new() { "Valence", "Vancouver" };
            CollectionAssert.IsSubsetOf(listToCompare, listVilles);
        }

    }
}
