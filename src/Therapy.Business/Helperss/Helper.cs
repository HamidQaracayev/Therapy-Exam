using Microsoft.AspNetCore.Http;

namespace Therapy.Business.Helperss;

public class Helper
{
    public static string GetFile(string rootpath,string foldername,IFormFile image)
    {
        string filename = image.FileName.Length > 64 ? image.FileName.Substring(image.FileName.Length - 64 , 64) : image.FileName;
        filename = Guid.NewGuid().ToString() + filename;
        string mainPath = Path.Combine(rootpath, foldername,filename);

        using (FileStream stream = new FileStream(mainPath, FileMode.Create))
        {
            image.CopyTo(stream);
        }
        return filename;
    }
}
