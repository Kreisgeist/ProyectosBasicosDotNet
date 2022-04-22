using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicisExercise.Models;
using System.Dynamic;

namespace PublicisExercise.Controllers
{
    public class CataloguesController : Controller
    {
        private readonly appEnewsContext _db;
        public CataloguesController(appEnewsContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Pages()
        {
            List<Page> pages = await (from p in _db.Pages
                                      select p).ToListAsync();

            List<Category> categories = await (from p in _db.Categories
                                               select p).ToListAsync();

            List<string> catMedios = pages.Select(x => x.Medio).Distinct().ToList();
            List<string> catCategorias = categories.Where(y => pages.Select(x => x.IdCategory).Distinct().Contains(y.Id)).Select(y => y.Name).ToList();
            
            dynamic model = new ExpandoObject();
            model.Pages = pages;
            model.Categories = categories;
            model.CAT_Medios = catMedios;
            model.CAT_Categories = catCategorias;
            return View(model);
        }
        public async Task<JsonResult> InsertRegister(string medio, DateTime fecha, int categoria, int spots)
        {
            try
            {
                Page newPage = new Page()
                {
                    Medio = medio,
                    Fecha = fecha,
                    IdCategory = categoria,
                    Spots = spots,
                    SrcLink = "",
                    Processing = true
                };

                _db.Entry(newPage).State = EntityState.Added;
                _db.SaveChanges();

                string? categoryName = await (from c in _db.Categories
                                             where c.Id == newPage.IdCategory
                                             select c.Name).FirstOrDefaultAsync();

                List<string> pageResponse = new List<string>() { newPage.Medio, newPage.Fecha.ToString("dd/MM/yyyy"), categoryName == null ? "ERROR": categoryName, newPage.Spots.ToString() };

                return Json(pageResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult DeleteRegister(int id)
        {
            try
            {
                Page deletedPage = (from p in _db.Pages
                                    where p.Id == id
                                    select p).First();

                if (deletedPage != null)
                {
                    _db.Entry(deletedPage).State = EntityState.Deleted;
                    _db.SaveChanges();

                    return Json(1);
                }
                else
                {
                    return Json(2);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> LoadRegisterData(int id)
        {
            try
            {
                Page loadedPage = await (from p in _db.Pages
                                         where p.Id == id
                                         select p).FirstAsync();

                if (loadedPage != null)
                {
                    return Json(loadedPage);
                }
                else
                {
                    return Json(2);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> UpdateRegister(int id, string medio, DateTime fecha, int categoria, int spots)
        {
            try
            {
                Page updatedPage = await (from p in _db.Pages
                                          where p.Id == id
                                          select p).FirstAsync();

                updatedPage.Medio = medio;
                updatedPage.Fecha = fecha;
                updatedPage.IdCategory = categoria;
                updatedPage.Spots = spots;
                _db.Entry(updatedPage).State = EntityState.Modified;
                _db.SaveChanges();

                string? categoryName = await (from c in _db.Categories
                                              where c.Id == updatedPage.IdCategory
                                              select c.Name).FirstOrDefaultAsync();

                List<string> pageResponse = new List<string>() { updatedPage.Medio, updatedPage.Fecha.ToString("dd/MM/yyyy"), categoryName == null ? "ERROR" : categoryName, updatedPage.Spots.ToString() };

                return Json(pageResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
