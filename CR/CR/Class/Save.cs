using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR.Class.game;

namespace CR.Class.game
{
    public class Write
    {
        public async Task<string> WriteFile(string foldername, string filename, string json)
        {
            try
            {
                IFolder folder = FileSystem.Current.LocalStorage;
                var checkExistence = await folder.CheckExistsAsync(foldername);
                if (checkExistence != ExistenceCheckResult.FolderExists)
                {
                    folder = await folder.CreateFolderAsync(foldername, CreationCollisionOption.ReplaceExisting);
                    IFile file3;
                    var t = await folder.CheckExistsAsync(filename);
                    if (t == ExistenceCheckResult.FileExists)
                    {
                        //file3 = await file3.OpenAsync(filename, CreationCollisionOption.ReplaceExisting);
                    }
                    IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                    await file.WriteAllTextAsync(json);
                    var y = await file.ReadAllTextAsync();
                    return "OK";
                }
                else
                {
                    folder = await folder.CreateFolderAsync(foldername, CreationCollisionOption.OpenIfExists);

                    IFile file3;
                    var t = await folder.CheckExistsAsync(filename);
                    if (t == ExistenceCheckResult.FileExists)
                    {
                    }
                    IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                    await file.WriteAllTextAsync(json);
                    var y = await file.ReadAllTextAsync();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }

    public class Read
    {
        public async Task<string> ReadFile(string foldername, string filename, string json)
        {
            try
            {
                IFolder folder = FileSystem.Current.LocalStorage;
                var checkExistence = await folder.CheckExistsAsync(foldername);
                if (checkExistence != ExistenceCheckResult.FolderExists)
                {
                    return "KO";
                }
                else
                {
                    folder = await folder.CreateFolderAsync(foldername, CreationCollisionOption.OpenIfExists);

                    IFile file3;
                    var t = await folder.CheckExistsAsync(filename);
                    if (t == ExistenceCheckResult.FileExists)
                    {
                        IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
                        
                        var y = await file.ReadAllTextAsync();
                        return y;
                    }
                    else
                    {
                        return "KO";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }

    public class Check
    {
        public async Task<string> ReadFile(string foldername, string filename, string json)
        {
            try
            {
                IFolder folder = FileSystem.Current.LocalStorage;
                var checkExistence = await folder.CheckExistsAsync(foldername);
                if (checkExistence != ExistenceCheckResult.FolderExists)
                {
                    return "KO";
                }
                else
                {
                    folder = await folder.CreateFolderAsync(foldername, CreationCollisionOption.OpenIfExists);

                    IFile file3;
                    var t = await folder.CheckExistsAsync(filename);
                    if (t == ExistenceCheckResult.FileExists)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "KO";
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
