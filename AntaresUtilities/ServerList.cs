using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AntaresUtilities
{
    //Формат списка серверов
    internal class ServerList
    {
        public List<string> ServerNameList => _serverNameList;

        public string SelectedServerName => _selectedServer.Name;

        public string SelectedServerFQN => _selectedServer.FQN;

        public string SelectedServerDBName => _selectedServer.DBName;

        private readonly List<Server> _serverList;
        private readonly List<string> _serverNameList;
        private Server _selectedServer;

        public ServerList()
        {
            string path = @"server.ini";
            _serverList = new List<Server>();
            _serverNameList = new List<string>();

            if (File.Exists(path))
            {
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] word = line.Split(' ');
                        string name = word[0];
                        string fqn = word[1];
                        string dbname = word[2];
                        Server server = new Server
                        {
                            Name = name,
                            FQN = fqn,
                            DBName = dbname
                        };
                        _serverList.Add(server);
                        _serverNameList.Add(server.Name);
                    }
                }
            }
            else
            {
                _serverList.Add(new Server { Name = "Иркутск_ТСТ", FQN = "irk-sql-tst", DBName = "AntaresTracking_QA" });
                _serverNameList.Add("Иркутск_ТСТ");
            }
        }

        /// <summary>
        /// Устанавливает сервер с названием name как выбранный
        /// </summary>
        /// <param name="name">название сервера</param>
        public void SelectServer(string name)
        {
            Server selectedServer = null;
            selectedServer = _serverList.First(s => s.Name == name);
            if (selectedServer is null) throw new ArgumentException("Сервер не найден");
            _selectedServer = selectedServer;
        }

        internal class Server
        {
            public string Name { get; set; }
            public string FQN { get; set; }
            public string DBName { get; set; }
        }
    }


}
