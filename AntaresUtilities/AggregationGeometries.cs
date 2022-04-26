using System;
using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> GetRecipeList()
        {
            _dm.Connect(_listOfServers.SelectedServerFQN, _listOfServers.SelectedServerDBName);
            var cmdString = $"SELECT [Id] FROM [{_listOfServers.SelectedServerDBName}].[dbo].[Recipe]";
            return _dm.SelectValuesFromDb(cmdString);
        }

        public List<RecipeGeometry> GetRecipeGeometriesList(string recipeID)
        {
            List<RecipeGeometry> results = new List<RecipeGeometry>();
            
            var cmdString = $"SELECT [LineId],[ItemType],[X],[Y],[Z] FROM [{_listOfServers.SelectedServerDBName}].[dbo].[ItemTypeGeometry] " +
                $"where RecipeId = '{recipeID}' and LineId <> -1";

            List<string[]> values = _dm.SelectTableFromDb (cmdString, 5);

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
            var cmdString = $"SELECT [RecipeDescription] FROM [{_listOfServers.SelectedServerDBName}].[dbo].[Recipe] " +
                $"Where Id='{ recipeName}'";
            return _dm.SelectValuesFromDb(cmdString)[0];
        }

        public void UpdateRecipeGeometryInDb(List<RecipeGeometry> list)
        {
            string cmdString;
            foreach (RecipeGeometry r in list)
            {
                cmdString = $"Update [{ _listOfServers.SelectedServerDBName}].[dbo].[ItemTypeGeometry] set x={r.X},y={r.Y},z={r.Z} " +
                    $"where RecipeId='{r.RecipeId}' and LineId={r.LineId} and ItemType={r.ItemType}";
                _dm.UpdateValueInDb(cmdString);
            }
        }
    }
}
