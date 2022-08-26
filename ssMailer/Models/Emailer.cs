using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ssMailer.Models
{
    public class Emailer
    {
        public int Id { get; set; }
        public string EmailId { get; set; }

        public string UserName { get; set; }
        public bool IsSent { get; set; }

    }
    
    public class MapEmailer : EntityTypeConfiguration<Emailer>
    {
        public MapEmailer()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.EmailId).HasMaxLength(100);
            Property(o => o.UserName).HasMaxLength(50);

            ToTable("Emailer");


        }
    }
}