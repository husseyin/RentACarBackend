using Core.Utilities.Results.OperationResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            if (formFile.Length > 0)
            {
                using (var fileStream = new FileStream(sourcePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }

            var result = newPath(formFile);
            File.Move(sourcePath, result);

            return result;
        }

        public static IResult Delete(string sourcePath)
        {
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public static string Update(IFormFile formFile, string sourcePath)
        {
            var result = newPath(formFile);
            if (formFile.Length > 0)
            {
                using (var fileStream = new FileStream(result, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }

            File.Delete(sourcePath);

            return result;
        }

        private static string newPath(IFormFile formFile)
        {
            var newPath = $@"\wwwroot\Images\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{new FileInfo(formFile.FileName).Extension}";
            return newPath;
        }
    }
}