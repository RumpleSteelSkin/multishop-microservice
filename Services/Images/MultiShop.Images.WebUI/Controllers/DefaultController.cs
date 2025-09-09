using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.WebUI.DAL.Entities;
using MultiShop.Images.WebUI.Services;

namespace MultiShop.Images.WebUI.Controllers;
public class DefaultController(ICloudStorageService cloudStorageService) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(ImageDrive imageDrive)
    {
        if (imageDrive.Photo == null) return RedirectToAction("Index", "Default");
        imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
        imageDrive.SavedUrl =
            await cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
        return RedirectToAction("Index", "Default");
    }

    private string? GenerateFileNameToSave(string incomingFileName)
    {
        var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
        var extension = Path.GetExtension(incomingFileName);
        return $"{fileName}-{DateTime.Now.ToUniversalTime():yyyyMMddHHmmss}{extension}";
    }
    

}