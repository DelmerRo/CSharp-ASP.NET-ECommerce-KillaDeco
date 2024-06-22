
namespace WebKillaDeco.Helpers
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string folderName = "category-image")
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", folderName);
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    return $"~/images/{folderName}/{uniqueFileName}"; // Guardar la ruta relativa
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error saving the image file.", ex);
                }
            }
            else
            {
                throw new ArgumentException("Image file is required.", nameof(imageFile));
            }
        }

        public async Task<List<string>> SaveImagesAsync(List<IFormFile> imageFiles, string folderName = "category-image")
        {
            var imageUrls = new List<string>();

            if (imageFiles != null && imageFiles.Count > 0)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", folderName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    foreach (var imageFile in imageFiles)
                    {
                        if (imageFile != null && imageFile.Length > 0)
                        {
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await imageFile.CopyToAsync(fileStream);
                            }

                            imageUrls.Add($"~/images/{folderName}/{uniqueFileName}"); // Guardar la ruta relativa
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error saving the image files.", ex);
                }
            }
            else
            {
                throw new ArgumentException("Image files are required.", nameof(imageFiles));
            }

            return imageUrls;
        }

    }
}
