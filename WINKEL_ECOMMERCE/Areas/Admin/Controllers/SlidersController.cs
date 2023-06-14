using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Extensions;
using WINKEL_ECOMMERCE.Models;
using static WINKEL_ECOMMERCE.Utilities.Utilities;
using Microsoft.AspNetCore.Authorization;
namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin, Content Manager")]
    public class SlidersController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        
        public SlidersController(WINKEL_ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int? page = 1)
        {
            if ( page < 1 ) page = 1;
            ViewData["total_sliders_count"] = _context.Sliders.ToList().Count;
            int totalPages = (int)Math.Ceiling(Convert.ToDecimal(ViewData["total_sliders_count"]) / 3);
            if (page > totalPages) page = totalPages;
            IEnumerable<Slider> sliders = await _context.Sliders.Skip(((int)page -1)*3).Take(3).ToListAsync();
            ViewData["active_page"] = page;
            ViewData["active_nav"] = "sliders";
            return View(sliders); 
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["active_nav"] = "sliders";
            return View();
            //return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            //1. Check whether photo is not null
            //2. Check photo is a valid image
            //3. Create unique name for new photo via Guid.NewGuid();
            //4. Save new photo in images folder
            //5. Save photo name in SQL
            if(!ModelState.IsValid) 
            {
                return View(slider);
            }
            if (slider.Photo == null)
            {
                ModelState.AddModelError("Photo","Image should be selected");
                return View(slider);
            }
            if(!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Image is not valid.");
                return View(slider);
            }
            //string uniqueId = Guid.NewGuid().ToString();
            //string newFileName = uniqueId + slider.Photo.FileName;
            //// string path = Path.GetFullPath(@"C:\Users\rusey\source\C# Reunion\WINKEL_ECOMMERCE\WINKEL_ECOMMERCE\wwwroot\image\",newFileName) ;
            //string path = _env.WebRootPath + @"\image\" + newFileName ;

            //using (FileStream fs = new FileStream(path, FileMode.Create))
            //{
            //    await slider.Photo.CopyToAsync(fs);
            //}
            slider.Image = await slider.Photo.SaveFileAsync(_env);
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            ViewData["active_nav"] = "sliders";

            return View(slider);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            ViewData["active_nav"] = "sliders";

            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Slider slider)
        {
            if (!ModelState.IsValid) return View(slider);
            Slider slideFromDB = await _context.Sliders.FindAsync(id);
            if (slider.Photo != null)
            {
                if (!slider.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Image is not valid.");
                    return View(slider);
                }
                else
                {
                    // remove old image
                    if (slideFromDB.Image != null) RemoveFile(slideFromDB.Image, _env);

                    // add new image
                    slideFromDB.Image = await slider.Photo.SaveFileAsync(_env);
                }
            }
            slideFromDB.LeftVerticalText = slider.LeftVerticalText;
            slideFromDB.Header = slider.Header;
            slideFromDB.SupHeader = slider.SupHeader;
            slideFromDB.AltImage = slider.AltImage;
            slideFromDB.Description = slider.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id is null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider is null) return NotFound();
            ViewData["active_nav"] = "sliders";

            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeletePost(int? id)
        {   
            if(_context.Sliders.Count() == 1) return RedirectToAction(nameof(Index));
            if (id is null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider is null) return NotFound();
            if (slider.Image != null) RemoveFile(slider.Image, _env);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
