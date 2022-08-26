using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ssMailer.Controllers
{
    public class UploadSSController : Controller
    {
        //
        // GET: /UploadSS/
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult Uploadstar(string name, string chunk, string chunks,  HttpPostedFileWrapper file)
        {
            string filePath = Server.MapPath("~/Uploads/") + name;

            SaveFileFromUrl(filePath, file);
            return Json("Done",JsonRequestBehavior.AllowGet);

        }

        public void SaveFileFromUrl(string file_name, HttpPostedFileWrapper file)
        {
            byte[] content;

            Stream stream = file.InputStream;

            using (BinaryReader br = new BinaryReader(stream))
            {
                content = br.ReadBytes(file.ContentLength);
                br.Close();
            }


            FileStream fs = new FileStream(file_name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(content);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }

        }



        public ActionResult custom()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MultiUploader()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MultiUploader(HttpPostedFileWrapper upl)
        {
            string filePath = Server.MapPath("~/Uploads/") + upl.FileName;

            SaveFileFromUrl(filePath, upl);
            return View();

        }













        public ActionResult testfb()
        {
            return View();
        }
    }
}