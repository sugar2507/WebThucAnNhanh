using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanThucAnNhanh.Models;
using System.IO;
using System.Data.Entity;
using System.Net;

namespace WebBanThucAnNhanh.Areas.QuanLy.Controllers
{
    public class HoaDonController : Controller
    {

        QLThucAnNhanhEntities database = new QLThucAnNhanhEntities();
        // GET: QuanLy/HoaDon
        public ActionResult Index(int id = 0)
        { 
            
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            var links = from l in database.HOADONs
                        select l;
            if (id != 0)
            {
                links = links.Where(x => x.MAHOADON == id);
            }
            return View(links);
            //if (sdt != 0)
            //{
            //    links = links.Where(x => x.DATHANG.DIACHIGH.SDT == sdt);

            //}
            //return View(links);
            //return View(database.HOADONs.ToList());
        }

        // GET: QuanLy/HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hoadon = database.HOADONs.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: QuanLy/DonHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }
    }
}
