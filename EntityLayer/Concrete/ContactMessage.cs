using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ContactMessage
	{
        [Key]
        public int MessageID { get; set; }
        public string ContactName { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactContent { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
