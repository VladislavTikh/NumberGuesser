using DataAcces.Models;
using DataAccess.IRepository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Base class of repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        #region Private Members
        private string ApplicationDirectory = Environment.CurrentDirectory;
        private string FolderName;
        #endregion
        #region Constructor
        public BaseRepository(string folderName)
        {
            FolderName = folderName;
            var path = Path.Combine(ApplicationDirectory, folderName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        #endregion
        public string CreateFullPath(long id)
        {
            var appPath = Environment.CurrentDirectory;
            var fileName = $"{id}.json";
            return Path.Combine(appPath, FolderName, fileName);
        }
        #region Operations with objects of repo
        public void Save(T model)
        {
            JsonSerializer<T>.Serialize(model, CreateFullPath(model.ID));
        }

        public T Get(long id)
        {
            var path = CreateFullPath(id);
            if (!File.Exists(path))
            {
                return null;
            }
            return JsonSerializer<T>.Deserialize(path);
        }
        #endregion
    }
}
