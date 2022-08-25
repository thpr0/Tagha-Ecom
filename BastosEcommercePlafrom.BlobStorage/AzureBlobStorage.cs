using Azure.Storage.Blobs;
using BastosEcommercePlafrom.BlobStorage.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BastosEcommercePlafrom.BlobStorage
{
    public class AzureBlobStorage : IStorageManager
    {
        private readonly string _storageConnectionString;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobContainerClient;
        private readonly string containerName = "membresphotos";

        public AzureBlobStorage(string connectionString)
        {
            _storageConnectionString = connectionString;
            _blobServiceClient = new BlobServiceClient(_storageConnectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task<FileUploadResult> Upload(Stream file)
        {
            var fileUniqueId = Guid.NewGuid().ToString();
            BlobClient blob = _blobContainerClient.GetBlobClient(fileUniqueId);
            await blob.UploadAsync(file, true);

            return new FileUploadResult
                        {
                            Id = fileUniqueId,
                            Link = blob.Uri
                        };
        }

        public async Task<bool> Delete(string fileUniqueId)
        {
            BlobClient blob = _blobContainerClient.GetBlobClient(fileUniqueId);
            var result = await blob.DeleteAsync();

            return await Task.FromResult(!result.IsError);
        }
    }
}
