using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Question2
	{
		[Key]
		public int Question2ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Area1 { get; set; }
        public string Area2 { get; set; }
        public string Area3 { get; set; }
        public string Area4 { get; set; }
        public string Area5 { get; set; }
    }
}
