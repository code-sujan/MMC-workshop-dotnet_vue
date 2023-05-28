namespace test.Helpers;

public static class FileHelper
{
    public static async Task<string> RecordFile(IFormFile file)
    {
        var path = "Content";
        EnsureDirectoryIsCreated(path);
        var extension = Path.GetExtension(file.FileName);
        var encryptedFileName = Guid.NewGuid() + extension;
        var filePath = Path.Combine(path, encryptedFileName);
        await using var stream = new FileStream(filePath, FileMode.Create); 
        await file.CopyToAsync(stream);
        return encryptedFileName;
    }
    
    public static void RemovePhysicalFile(string fileName)
    {
        var removableFormat = Path.Combine("Content", fileName);
        File.Delete(removableFormat);
    }

    private static void EnsureDirectoryIsCreated(string rootDirectory)
    {
        if (!Directory.Exists(rootDirectory)) Directory.CreateDirectory(rootDirectory);
    }
}