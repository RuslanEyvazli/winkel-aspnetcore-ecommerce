using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Extensions
{
    public static class IFormFileExtension
    {
        public static async Task<string> SaveFileAsync(this IFormFile file, IWebHostEnvironment _env)
        {
            string uniqueId = Guid.NewGuid().ToString();
            string newFileName = uniqueId + file.FileName;
            // string path = Path.GetFullPath(@"C:\Users\rusey\source\C# Reunion\WINKEL_ECOMMERCE\WINKEL_ECOMMERCE\wwwroot\image\",newFileName) ;
            string path = _env.WebRootPath + @"\image\" + newFileName;

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return newFileName;

        }
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains(@"image/");
          
        }
    }
}
