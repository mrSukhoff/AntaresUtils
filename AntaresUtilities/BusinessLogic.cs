using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntaresUtilities
{
    public class BusinessLogic
    {
        
        private DataMiner dm;
        public ServerList ListOfServers;

        public BusinessLogic()
        {
            ListOfServers = new ServerList();
            dm = new DataMiner();
        }

        //Получаем список рецептов с выбраного сервера
        public List<string> GetRecipeList()
        {
            dm.Connect(ListOfServers.SelectedServerFQN, ListOfServers.SelectedServerDBName);

            List<string> result = new List<string>();
            foreach (string recipe in dm.GetRecipeList())
            {
                result.Add(recipe);
            }
            return result;
        }

        //Получаем с сервера геометрию выбраного рецепта
        public List<RecipeGeometry> GetSelectedRecipeGeometrysList(string recipeID)
        {
            return dm.GetRecipeGeometry(recipeID);
        }

        public string GetRecipeDescription(string recipeName)
        {
            return dm.GetRecipeName(recipeName);
        }

        public string GetMaterialDescription(string recipeName)
        {
            return dm.GetMaterialName(recipeName);
        }

        public void SaveRecipeGeometryToDb(List<RecipeGeometry> list)
        {
            dm.SetRecipeGeometry(list);
        }

        public List<string> GetMaterialsList()
        {
            dm.Connect(ListOfServers.SelectedServerFQN, ListOfServers.SelectedServerDBName);
            return dm.GetGMIDList();
        }

        public List<RecipeGeometry> GetRecipesListByGMID(string gMID)
        {
            return dm.GetRecipesListByGMID(gMID);
        }
    
        public void SaveMaterialGeometrysToDb(List<RecipeGeometry> list)
        {
            dm.SetRecipesGeometry(list);
        }
        
        public Package GetCrypto(Package package)
        {
            dm.Connect(ListOfServers.SelectedServerFQN, ListOfServers.SelectedServerDBName);
            return dm.GetCrypto(package);
        }
    }
}
