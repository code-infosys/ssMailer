using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ssMailer.Models;
using System.Web.Mail;
using System.Text;

namespace ssMailer.Controllers
{
    [Authorize]
    public class EmailerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Emailer/
        public ActionResult Index()
        {
            SendEmail();
            return View(db.Emailers.OrderByDescending(i=>i.Id).Take(2).ToList());
        }

        // GET: /Emailer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Emailer emailer = db.Emailers.Find(id);
            if (emailer == null)
            {
                return HttpNotFound();
            }
            return View(emailer);
        }

        // GET: /Emailer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Emailer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmailId,UserName,IsSent")] Emailer emailer)
        {
            if (ModelState.IsValid)
            {
                db.Emailers.Add(emailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailer);
        }

        // GET: /Emailer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emailer emailer = db.Emailers.Find(id);
            if (emailer == null)
            {
                return HttpNotFound();
            }
            return View(emailer);
        }

        // POST: /Emailer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmailId,UserName,IsSent")] Emailer emailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailer);
        }

        // GET: /Emailer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emailer emailer = db.Emailers.Find(id);
            if (emailer == null)
            {
                return HttpNotFound();
            }
            return View(emailer);
        }

        // POST: /Emailer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emailer emailer = db.Emailers.Find(id);
            db.Emailers.Remove(emailer);
            db.SaveChanges();
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


        public void SendEmail()
        {
              int chk = 0;
            var listUseres = db.Emailers.Where(i => i.IsSent == false).ToArray();
            StringBuilder sb = new StringBuilder();
            try
            {

                string subject = "Check this amazing MVC 5 online Web Application Creator - StudioSharp.net";

                string body = string.Format(@"<div style='font-weight: 700'>
    
        Hello,<div>
            <br />
        </div>
          
        </div>
        <div>
            Please check this amazing online website creator .</div>
        <div>
            <br />
        </div>
        <div>
            You can create website in just 5 steps :</div>
        <div>
            <br />
        </div>
        <div>
            1. Create Project &gt;&gt;&gt; 2. Create/Select Database &gt;&gt;&gt; 3. Select Theme &gt;&gt;&gt; 4. Select Function/Tables &gt;&gt;&gt; 5. Click Generate !</div>
        <div>
            <br />
        </div>
        <div>
<a href='http://www.studiosharp.net/create-your-first-website-free?RefferId=eff0b4f7-b7c9-46dc-9723-9f9eed796d0b&emailid=$useremailid$'   target='_self'>Referred by StudioSharp.net - Check this Website Builder  </a>            
</div>
        <div>
            <b>
            <br />
            </b>
        </div>
        <div>
            <b>Thanks &amp; Regards,</b></div>
        <div>
            <b>
            <br />
            </b>
        </div>
        <div>
            <b>
            <img class='CToWUd' height='160' src='http://studiosharp.net/Content/theme/logoss.png' width='133' /><br />
            <br />
            </b>
        </div>
        <div>
            <b><font size='4'>StudioSharp.net&nbsp;</font></b></div>
    
    </div>");
              
                foreach (var item in listUseres)
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        message.To = item.EmailId;

                        message.From = "S#@studiosharp.net";
                        message.Subject = subject;
                        message.BodyFormat = MailFormat.Html;
                        message.Body = body.Replace("$useremailid$", item.EmailId);
                        string Username = "S#@studiosharp.net";
                        string Password = "Akaal#123";
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //none, cdoBasic, NTLM
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", Username);
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password);
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", 2); // cdoNTLM, value 2. The current process security context is used to authenticate with the service.
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", false);
                        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout", 60);

                        string SmptServer = "smtpout.secureserver.net";
                        System.Web.Mail.SmtpMail.SmtpServer = SmptServer;
                        System.Web.Mail.SmtpMail.Send(message);

                        sb.AppendLine("update Emailer set IsSent=1 where Id=" + item.Id);

                    }
                    catch (Exception)
                    {
                        sb.AppendLine("update Emailer set IsSent=0 where Id=" + item.Id);
                    }
                    chk = 1;
                }


            }
            catch (Exception)
            {
            }
            if (chk == 1)
            {
                db.Database.ExecuteSqlCommand(sb.ToString());
            }
        }



    }
}
