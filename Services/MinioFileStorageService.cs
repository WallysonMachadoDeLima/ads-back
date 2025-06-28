using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Minio;

namespace CrudVeiculos.Services
{
    public class MinioFileStorageService : IFileStorageService
    {
        private readonly MinioClient _minio;
        private readonly MinioSettings _settings;

        public MinioFileStorageService(
            MinioClient minioClient,
            IOptions<MinioSettings> opts)
        {
            _minio = minioClient;
            _settings = opts.Value;
        }

        public async Task<string> UploadFileAsync(
            IFormFile file,
            CancellationToken cancellationToken = default)
        {
            var bucket = _settings.BucketName;
            // Gera nome único para evitar colisão
            var objectName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // Certifica-se de que o bucket existe
            bool found = await _minio.BucketExistsAsync(
                new BucketExistsArgs()
                    .WithBucket(bucket),
                cancellationToken);

            if (!found)
            {
                await _minio.MakeBucketAsync(
                    new MakeBucketArgs()
                        .WithBucket(bucket),
                    cancellationToken);
            }

            // Faz o upload diretamente do Stream do IFormFile
            await using var stream = file.OpenReadStream();
            await _minio.PutObjectAsync(
                new PutObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(file.Length)
                    .WithContentType(file.ContentType),
                cancellationToken);

            // Retorna a URL pública (ajuste se você tiver custom domain)
            var scheme = _settings.UseSSL ? "https" : "http";
            return $"{scheme}://{_settings.Endpoint}/{bucket}/{objectName}";
        }
    }
}
