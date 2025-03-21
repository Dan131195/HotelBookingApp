using HotelBookingApp.Models;
using HotelBookingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class CameraController : Controller
{
    private readonly CameraService _cameraService;

    public CameraController(CameraService cameraService)
    {
        _cameraService = cameraService;
    }

    public async Task<IActionResult> Index()
    {
        var camere = await _cameraService.GetAllAsync();
        return View(camere);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Camera camera)
    {
        if (ModelState.IsValid)
        {
            await _cameraService.CreateAsync(camera);
            return RedirectToAction(nameof(Index));
        }
        return View(camera);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var camera = await _cameraService.GetByIdAsync(id);
        return View(camera);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Camera camera)
    {
        if (ModelState.IsValid)
        {
            await _cameraService.UpdateAsync(camera);
            return RedirectToAction(nameof(Index));
        }
        return View(camera);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var camera = await _cameraService.GetByIdAsync(id);
        return View(camera);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _cameraService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
