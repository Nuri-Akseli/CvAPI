using CvAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Infrastructure.Services.Storage
{
    public class StorageService:IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName => _storage.GetType().Name;

        public void Delete(string pathOrContainerName, string fileName)
        {
             _storage.Delete(pathOrContainerName, fileName);
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            return _storage.GetFiles(pathOrContainerName);
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            return _storage.HasFile(pathOrContainerName, fileName);
        }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            return _storage.UploadAsync(pathOrContainerName, files);
        }

        public Task<(string fileName, string path)> UploadSingleAsync(string path, IFormFile file)
        {
            return _storage.UploadSingleAsync(path, file);
        }
    }
}
