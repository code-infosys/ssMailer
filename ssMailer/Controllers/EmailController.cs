using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace ssMailer.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string val)
        {
            SendEmail();
            return View();
        }

        public string Emails = @"rakesh_awasthi12@rediffmail.com,
siyatrehan701@gmail.com,
er_gurindersingh@yahoo.com,
devendra11885@gmail.com,
sweetgirl.kocher59@gmail.com,
siyatrehan701@gmail.com,
dxtmhjn@gmail.com,
rajeevsharma751@gmail.com,
sandhurashpal41@gmail.com, 
poojarajput16@gmail.com,
rahulpathania88@gmail.com,  
rakesh23bapna@gmail.com,
raj-mehta@hotmail.com,
ravi.lamba390@gmail.com,
kumar.life74@gmail.com, 
rvprofessionals@yahoo.com, 
poojarahput16@gmail.com, 
gandharav5951@gmail.com,
jkgill70008@gmail.com,
raj-mehta@hotmail.com,
er.abhishek00@gmail.com,
gandharav5951@gmail.com,
shrikantpatil805@gmail.com,
pjshines@gmail.com,
rajat88.puri@gmail.com, 
adeshmishra1790@gmail.com,
arunkapoor63@gmail.com,
arun.sharma22d@hotmail.com,
shishirboxey90@gmail.com,
 
pallavisharma288@gmail.com,
er.varunjaiswal@gmail.com,
mail2amansandhu@gmail.com,
amitmehta.26@gmail.com, 
bhupindersaini8@gmail.com,
rahulpathania88@gmail.com,
pannu_boy20@yahoo.co.in,
gsdhillon70008@gmail.com,
sudhanshu_prabhakar@yahoo.com, 
sudhanshuprabhakar15@gmail.com,
er.tanvi7513@gmail.com,
bhagatpriyanka28@gmail.com, 
vikkbehal@live.com,
gpsn85@gmail.com,
sudhanshu_prabhakar@yahoo.com, 
ankush.passion@gmail.com, 
niki.niks92@gmail.com,  
jainkush1401@gmail.com,
vinay.punj@yahoo.com,
kumarbipin.kumar46@gmail.com,
amansahni369@hotmail.com,
v.varun2004@gmail.com,
kishori.11pca012@baddiuniv.ac.in,
kkumar.ketu@gmail.com,
rohit53471@gmail.com,
dsdhanoa07@gmail.com,
krishmaverma9@gmail.com,
amrit_ap22@yahoo.com,
raviesh.kumar@yahoo.com,
hanishahir@gmail.com,
smartgaurav22@gmail.com,
pria.bjaj@gmail.com,
avtar_singh_bhamber@yahoo.co.in
anilkalsi8@gmail.com, 
aman.dhanjal13@live.com,
aman.dhanjal13@live.com,
duke.helsing@live.com,
mejatindersingh@gmail.com,
pankajkumar333@hotmai.com,
mukeshmehay@ymail.com,
sandeepsainipkt@gmail.com,
smartgaurav22@gmail.com,
mr.abhi490@rediffmail.com,
rituc786@gmail.com,
sonamverma0211@gmail.com,
sukhpreetsingh3008@gmail.com,
ritubala63@gmail.com,
rituc786@gmail.com,
ghaivikas143@gmail.com,
bansal.priyanka2014@gmail.com,
abhishekchadha2@gmail.com,
sandhurashpal41@gmail.com,
rohitw20@gmail.com,
puneetnoor17@gmail.com,
bains.manoj@yahoo.com,
hritika.narula@gmail.com,
vikasmanhas156@gmail.com,
ckplsunil@yahoo.co.in,
abhimanyu468@gmail.com,
gabanancy42@gmail.com,
sonamverma0211@gmail.com,
shaktiseth1997@gmail.com,
manjit.mattu4@gmail.com,
jaskaran.official91@gmail.com, ";

        public void SendEmail()
        {
            int chk = 0;
            string[] emailArr = Emails.Split(',');
            StringBuilder sb = new StringBuilder();
            try
            {

                string subject = "Skilledi Infotech - Part-Time Job Opening for .Net Developers";

                string body = string.Format(@"<div style='font-weight: 700'>
    
        Hello Asp.net Developer,<div>
            <br />
        </div>
          
        </div>
        <div>
             Greetings ,</div>
<p>
 We are looking for asp.net and mvc developers , who are Interested in working part-time(freelancing).<br>
 If you are interested in working part-time ,please contact on email or number given below.
</p>
        <div>
            <br />
        </div>
        <div>
<a href='http://www.skilledi.com'   target='_self'> Skilledi Infotech  </a>         <br>
<a href='http://www.studiosharp.net'   target='_self'> StudioSharp.Net Mvc Website Creator  </a>     
</div>
        <br/>
        <div>
            <b>Thanks &amp; Regards,</b></div>
        
         
        <div>
            <b>Skilledi Infotech&nbsp; </b></div>
    <div>  <b> Contact Email: skillediinfotech@gmail.com </b></div>
 <div>  <b> Contact No : +91 9878707793 </b></div>
    </div>");

                foreach (var item in emailArr)
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        message.To = item;

                        message.From = "S#@studiosharp.net";
                        message.Subject = subject;
                        message.BodyFormat = MailFormat.Html;
                        message.Body = body.Replace("$useremailid$", item);
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

                        sb.AppendLine(item+"<br>");
                        
                    }
                    catch (Exception)
                    {
                        
                    }
                    chk = 1;
                }


            }
            catch (Exception)
            {
            }
            if (chk == 1)
            {
                
            }

            ViewBag.email = sb.ToString();
        }


	}
}