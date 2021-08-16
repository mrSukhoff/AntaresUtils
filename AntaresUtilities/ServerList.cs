using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AntaresUtilities
{
    //Формат списка серверов
    public class ServerList
    {
        public List<string> ServerNameList 
        {
            get
            {
                return _serverNameList;
            }
        }


        public string SelectedServerName
        {
            get
            {
                return _selectedServer.Name;
            }
        }

        public string SelectedServerFQN
        {
            get
            { 
                return _selectedServer.FQN; 
            }
        }

        public string SelectedServerDBName
        {
            get
            {
                return _selectedServer.DBName;
            } 
        }

        
        private List<_server> _serverList;
        private List<string> _serverNameList;
        private _server _selectedServer;

        public ServerList()
        {
            string path = @"server.ini";
            if (File.Exists(path))
            {
                _serverList = new List<_server>();
                _serverNameList = new List<string>();
                
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                foreach (string l in lines)
                {
                    string[] word = l.Split(' ');
                    string name = word[0];
                    string fqn = word[1];
                    string dbname = word[2];
                    _server server = new _server
                    {
                        Name = name,
                        FQN = fqn,
                        DBName = dbname
                    };
                    _serverList.Add(server);
                    _serverNameList.Add(server.Name);
                }
            }
            else
            {
                _serverList = new List<_server> { new _server { Name = "Иркутск", FQN = "irk-sql-tst", DBName = "AntaresTracking_QA" } };
                _serverNameList = new List<string> { "Иркутск" };
            }
        }

        /// <summary>
        /// Устанавливает сервер с названием name как выбранный
        /// </summary>
        /// <param name="name">название сервера</param>
        public void SelectServer(string name) 
        {
            _server selectedServer = null;
            selectedServer = _serverList.First( s => s.Name == name);
            if (selectedServer is null) throw new ArgumentException("Сервер не найден");
            _selectedServer = selectedServer;
        }

        class _server 
        {
            public string Name { get; set; }
            public string FQN { get; set; }
            public string DBName { get; set; }
        }        
    }


}
