using System;
using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetRecipeList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            string cmdString = "SELECT [Id] FROM [" + _listOfServers.SelectedServerDBName + "].[dbo].[Recipe]";
            return _dm.SelectValuesFromDb(cmdString);
        }

        public List<RecipeGeometry> GetRecipeGeometriesList(string recipeID)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();

            var cmdString = string.Format("SELECT [LineId],[ItemType],[X],[Y],[Z] FROM [{0}].[dbo].[ItemTypeGeometry] " +
                "where RecipeId = '{1}' and LineId <> -1", _listOfServers.SelectedServerDBName, recipeID);
            var values = _dm.SelectTableFromDb (cmdString, 5);

            foreach (var row in values)
            {
                RecipeGeometry r = new RecipeGeometry();
                int.TryParse(row[0], out r.LineId);
                int.TryParse(row[1], out r.ItemType);
                int.TryParse(row[2], out r.X);
                int.TryParse(row[3], out r.Y);
                int.TryParse(row[4], out r.Z);
                if (r.ItemType == 300 || r.ItemType == 400) results.Add(r);
            }
            return results;
        }

        public string GetRecipeDescription(string recipeName)
        {
            string cmdString = String.Format("SELECT [RecipeDescription] FROM [{0}].[dbo].[Recipe] " +
                "Where Id='{1}'", _listOfServers.SelectedServerDBName, recipeName);
            return _dm.SelectValuesFromDb(cmdString)[0];
        }

        public void UpdateRecipeGeometryInDb(List<RecipeGeometry> list)
        {
            string cmdString;
            foreach (RecipeGeometry r in list)
            {
                cmdString = string.Format("Update [{0}].[dbo].[ItemTypeGeometry] set x={1},y={2},z={3} " +
                    "where RecipeId='{4}' and LineId={5} and ItemType={6}", _listOfServers.SelectedServerDBName, 
                    r.X, r.Y, r.Z, r.RecipeId, r.LineId, r.ItemType);
                _dm.UpdateValueInDb(cmdString);
            }
        }
    }
}
