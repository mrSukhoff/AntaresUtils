using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntaresUtilities
{
    class BusinessLogic
    {
        
        AntaresUtils au = new AntaresUtils();
        ServerList _listOfServer;

        public BusinessLogic(ServerList s)
        {
            _listOfServer = s;
        }

        //Получаем список рецептов с выбраного сервера
        public List<string> GetRecipeList()
        {
            au.Connect(_listOfServer.SelectedServerFQN, _listOfServer.SelectedServerDBName);

            List<string> result = new List<string>();
            foreach (string recipe in au.GetRecipeList())
            {
                result.Add(recipe);
            }
            return result;
        }

        //Получаем с сервера геометрию выбраного рецепта
        public List<RecipeGeometry> GetSelectedRecipeGeometrysList(string recipeID)
        {
            return au.GetRecipeGeometry(recipeID);
        }
    }
}
