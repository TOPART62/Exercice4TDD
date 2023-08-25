using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4TDD
{
    // La fonction prend une chaîne (texte de recherche) en entrée et renvoie les villes trouvées qui correspondent au texte de recherche.
    // Exemple de villes : Paris, Budapest, Skopje, Rotterdam, Valence, Vancouver, Amsterdam, Vienne, Sydney, New York, Londres, Bangkok, Hong Kong, Dubaï, Rome, Istanbul
    public class RechercheVille
    {
        private readonly List<String> villes = new()
        { 
            "Paris", 
            "Budapest", 
            "Skopje", 
            "Rotterdam", 
            "Valence", 
            "Vancouver", 
            "Amsterdam", 
            "Vienne", 
            "Sydney", 
            "New York", 
            "Londres", 
            "Bangkok", 
            "Hong Kong", 
            "Dubaï", 
            "Rome", 
            "Istanbul", 
            "Bruxelles", 
            "Lille",
            "Douai"
        };

        // Lecture de la liste
        public List<String> LireListVilles()
        { 
            return villes;  
        }
        // Recherche villes
        public List<String> Rechercher(String mot)
        {
            List<String> listTmp = new();
            if (mot == null)
                throw new NotFoundException();

            if (mot == "*")
                return villes;

            if (mot.Length < 2)
                throw new NotFoundException(); 
            
            foreach (String s in villes) 
                if (s.ToUpper().Contains(mot.ToUpper())) listTmp.Add(s);    
            return listTmp;    
        }
    }
}
