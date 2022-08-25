using System.IO;
using System.Threading.Tasks;

namespace BastosEcommercePlafrom.BlobStorage.Interfaces
{
    public interface IStorageManager
    {
        Task<FileUploadResult> Upload(Stream file);
        Task<bool> Delete(string fileUniqueId); 
    }
}
