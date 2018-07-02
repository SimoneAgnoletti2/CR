using CR.Class;
using CR.Interface;
using CR.Test;
using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CR.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string player_txt;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Player_txt
        {
            get
            {
                return player_txt;
            }

            set
            {
                player_txt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Player_txt)));
            }
        }

        public Command GoToTestProgressBar { get; }
        public Command RequestPlayer{ get; }
        public Command RequestPlayerBattles { get; }
        public Command RequestPlayerChests { get; }

        public MainPageViewModel()
        {
            GoToTestProgressBar = new Command(() =>
            {
                Application.Current.MainPage = new NavigationPage(new CR.Page.ProgressBar());
            });

            RequestPlayer = new Command(async () =>
            {
                Connect connection = new Connect();
                List<Player> player = await connection.GetComparePlayers(new List<string>());

                foreach(Player p in player)
                {
                    var json_player = JsonConvert.SerializeObject(p);

                    Save save = new Save();
                    var presente = await save.CheckFile("player", "player_" + p.tag + ".txt", json_player);
                    var contenuto_attuale = await save.ReadFile("player", "player_" + p.tag + ".txt", json_player);
                    var risultato_scrittura =await save.WriteFile("player", "player_" + p.tag + ".txt", json_player);
                    Player_txt = json_player.ToString();
                }

            });
            RequestPlayerBattles = new Command( () =>
            {
                
            });
            RequestPlayerChests = new Command( () =>
            {

            });
        }


        
    }
}