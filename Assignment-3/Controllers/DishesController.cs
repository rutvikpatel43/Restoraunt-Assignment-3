using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_3.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.Helpers;

namespace Assignment_3.Controllers
{
    public class DishesController : Controller
    {
        private DishesModel db = new DishesModel();

        // GET: Dishes
        public async Task<ActionResult> Index()
        {
            return View(await db.Dish.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dish.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,ImageUrl,ThumbnailUrl,Description,DishName,price")] Dishes dishes, HttpPostedFileBase image)
        {
            string newFileName,imagePath,ThumbnailimagePath;
            newFileName = "";
            imagePath = "~/Content/OrignalImages";
            ThumbnailimagePath = "~/Content/ThumbImages";
            WebImage photo;
            if (ModelState.IsValid)
            {
                if(!Directory.Exists(imagePath)&&!Directory.Exists(ThumbnailimagePath))
                {
                    Directory.CreateDirectory(Server.MapPath(imagePath));
                    Directory.CreateDirectory(Server.MapPath(ThumbnailimagePath));
                }
                
                    photo = WebImage.GetImageFromRequest();
                    newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);
                    //imagePath = "~/Content/OrignalImages/" + newFileName;
                    photo.Save(Path.Combine(Server.MapPath(imagePath),newFileName));
                    dishes.ImageUrl = newFileName;
                    newFileName = Guid.NewGuid().ToString() + "_" +
                    Path.GetFileName(photo.FileName);
                    photo.Resize(80, 80, false, false);
                    photo.Save(Path.Combine(Server.MapPath(ThumbnailimagePath), newFileName));
                    dishes.ThumbnailUrl = newFileName;
                
                db.Dish.Add(dishes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dishes);
        }
                   /*
                    //Save image to file
                    var filename = image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                    var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);

                    //Read image back from file and create thumbnail from it
                    var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
                    using (var srcImage = Image.FromFile(imageFile))
                    using (var newImage = new Bitmap(100, 100))
                    using (var graphics = Graphics.FromImage(newImage))
                    using (var stream = new MemoryStream())
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                        newImage.Save(stream, ImageFormat.Png);
                        var thumbNew = File(stream.ToArray(), "image/png");
                        artwork.ArtworkThumbnail = thumbNew.FileContents;
                    }
                }

                //Save model object to database
                db.ArtWorks.Add(artwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artwork);
        }*/
        // GET: Dishes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dish.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,ImageUrl,ThumbnailUrl,Description,DishName,price")] Dishes dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dishes);
        }

        // GET: Dishes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dishes dishes = await db.Dish.FindAsync(id);
            if (dishes == null)
            {
                return HttpNotFound();
            }
            return View(dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dishes dishes = await db.Dish.FindAsync(id);
            db.Dish.Remove(dishes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
