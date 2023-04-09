using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using librarian_admin.Models;
using X.PagedList;

namespace librarian_admin.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QuanLyGiaoTrinh2Context db = new QuanLyGiaoTrinh2Context();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DanhSachThuThu")]
        public IActionResult DanhSachThuThu(int page = 1)
        {
            int pageNumber = page;
            int pageSize = 12;
            var lstthuthu = db.ThuThus.AsNoTracking().OrderBy(x => x.TenThuThu);
            PagedList<ThuThu> lst = new PagedList<ThuThu>(lstthuthu, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemThuThu")]
        [HttpGet]
        public IActionResult ThemThuThu()
        {
            ViewBag.MaQue = new SelectList(db.Ques.ToList(), "MaQue", "TenQue");
            return View();
        }
        [Route("ThemThuThu")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemThuThu(ThuThu thuThu)
        {
            if(ModelState.IsValid)
            {
                db.ThuThus.Add(thuThu);
                db.SaveChanges();
                return RedirectToAction("DanhSachThuThu");
            }
            return View(thuThu);
        }
        [Route("SuaThuThu")]
        [HttpGet]
        public IActionResult SuaThuThu(string maThuThu)
        {
            var thuThu = db.ThuThus.Find(maThuThu);
            ViewBag.MaQue = new SelectList(db.Ques.ToList(), "MaQue", "TenQue");
            return View(thuThu);
        }
        [Route("SuaThuThu")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SuaThuThu(ThuThu thuThu)
        {
            if (ModelState.IsValid)
            {
                db.Update(thuThu);
                db.SaveChanges();
                return RedirectToAction("DanhSachThuThu");
            }
            return View(thuThu);
        }
        [Route("XoaThuThu")]
        [HttpGet]
        public IActionResult XoaThuThu(string matt)
        {
            TempData["Message"] = "";
            var lstChiTiet = db.ThuThus.Where(x => x.MaThuThu == matt);
            foreach (var item in lstChiTiet)
            {
                if (db.ThuThus.Where(x => x.MaThuThu == item.MaThuThu) != null)
                {
                    TempData["Message"] = "Lỗi Xóa!!";
                    return RedirectToAction("DanhSachThuThu");
                }
            }
            if (lstChiTiet != null) db.RemoveRange(lstChiTiet);
            db.Remove(db.ThuThus.Find(matt));
            db.SaveChanges();
            TempData["Message"] = "Xóa thành công";
            return RedirectToAction("DanhSachThuThu");
        }
    }
}