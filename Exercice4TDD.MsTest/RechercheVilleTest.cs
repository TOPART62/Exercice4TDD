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
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("a"));
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
        public void WhenRechercheVille_VA_Then_ListVillesVA()
        {
            List<String> listVilles = _rechercheVille.Rechercher("VA");
            List<String> listToCompare = new() { "Valence", "Vancouver" };
            CollectionAssert.IsSubsetOf(listToCompare, listVilles);
        }

        //4 - La fonctionnalité de recherche devrait également fonctionner lorsque le texte de recherche n'est qu'une partie
        //      d'un nom de ville Par exemple "ape" devrait renvoyer la ville "Budapest"
        [TestMethod]
        public void WhenRechercheVille_Ape_Then_ListVillesApe()
        {
            List<String> listVilles = _rechercheVille.Rechercher("ape");
            List<String> listToCompare = new() { "Budapest" };
            CollectionAssert.IsSubsetOf(listToCompare, listVilles);
        }

        //5 - Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville
        [TestMethod]
        public void WhenRechercheVille_asterisk_Then_ListVilles()
        {
            List<String> listVilles = _rechercheVille.Rechercher("*");
            List<String> listToCompare = _rechercheVille.LireListVilles();
            Assert.AreSame(listToCompare, listVilles);
        }

    }
}

