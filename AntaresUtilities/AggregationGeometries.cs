using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetRecipeList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            return _dm.GetRecipeList();
        }

        public List<RecipeGeometry> GetRecipeGeometriesList(string recipeID)
        {
            return _dm.GetRecipeGeometry(recipeID);
        }

        public string GetRecipeDescription(string recipeName)
        {
            return _dm.GetRecipeDescription(recipeName);
        }

        public void UpdateRecipeGeometryInDb(List<RecipeGeometry> list)
        {
            foreach (RecipeGeometry r in list)
            {
                _dm.UpdateGeometryInDb(r);
            }
        }


    }
}
