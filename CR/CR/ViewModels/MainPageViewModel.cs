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


                    IFolder folder = FileSystem.Current.LocalStorage;
                    String folderName ="player" ;
                    var checkExistence = await folder.CheckExistsAsync("player");

                    if(checkExistence != ExistenceCheckResult.FolderExists)
                    {
                        folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);

                        String filename = "player_" + p.tag + ".txt";
                        IFile file3;
                        var t = await folder.CheckExistsAsync(filename);
                        if (t == ExistenceCheckResult.FileExists)
                        {
                            //file3 = await file3.OpenAsync(filename, CreationCollisionOption.ReplaceExisting);
                        }
                        IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                        await file.WriteAllTextAsync(json_player);
                        var y = await file.ReadAllTextAsync();
                    }
                    else
                    {
                        folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

                        String filename = "player_" + p.tag + ".txt";
                        IFile file3;
                        var t = await folder.CheckExistsAsync(filename);
                        if (t == ExistenceCheckResult.FileExists)
                        {
                            //file3 = await file3.OpenAsync(filename, CreationCollisionOption.ReplaceExisting);
                        }
                        IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                        await file.WriteAllTextAsync(json_player);
                        var y = await file.ReadAllTextAsync();
                    }

                    

                    
                    








                    IFolder folder2 = FileSystem.Current.LocalStorage;
                    String folderName2 = "player";
                    var checkExistence2 = await folder2.CheckExistsAsync("player");

                    if (checkExistence2 != ExistenceCheckResult.FolderExists)
                    {
                        folder2 = await folder2.CreateFolderAsync(folderName2, CreationCollisionOption.ReplaceExisting);
                    }
                    else
                    {
                        folder2 = await folder2.CreateFolderAsync(folderName2, CreationCollisionOption.OpenIfExists);

                        String filename2 = "player_" + p.tag + ".txt";

                        
                        IFile file2 = await folder2.CreateFileAsync(filename2, CreationCollisionOption.OpenIfExists);

                        var x = await file2.ReadAllTextAsync();
                        string ciao = x;
                    }
                    

                    
















                    //await Xamarin.Forms.DependencyService.Get<ISave>().Save("prova.json", "application/json", ms);


                    //var x = await Xamarin.Forms.DependencyService.Get<IRead>().Read("prova.json");
                }

                Player_txt = player.ToString();
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