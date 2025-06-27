using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CrudVeiculos.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default);
    }
}
