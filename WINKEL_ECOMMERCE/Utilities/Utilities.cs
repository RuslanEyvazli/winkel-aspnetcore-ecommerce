using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Utilities
{
    public static class Utilities
    {
        public static void RemoveFile(string fileName, IWebHostEnvironment _env)
        {
            string path = Path.Combine(_env.WebRootPath, "image", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static string GetAbsolutePath(IWebHostEnvironment _env, string image)
        {
            return Path.Combine(_env.WebRootPath, "iamge", image);
        }
    }
}
