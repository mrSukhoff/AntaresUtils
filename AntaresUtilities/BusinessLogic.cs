using System.Collections.Generic;

namespace AntaresUtilities
{
    public partial class BusinessLogic
    {
        public List<string> ServerNames { get; private set; }

        private readonly DataMiner _dm;
        private readonly ServerList _listOfServers;
        private List<RecipeGeometry> _currentGMIDRecipesGeometry;
        private string _currentGMID;

        public BusinessLogic()
        {
            _listOfServers = new ServerList();
            ServerNames = _listOfServers.ServerNameList;
            _dm = new DataMiner();
        }

        public void SelectServer(string serverName)
        {
            _listOfServers.SelectServer(serverName);
        }

        public KIZ KizFactory(string gtin, string serial)
        {
            return new KIZ(gtin, serial, _listOfServers);
        }
    }
}
