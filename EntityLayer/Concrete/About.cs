﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About
	{
        [Key]
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubTitle { get; set; }
        public string SubDescription { get; set; }
        public string SubIcon { get; set; }
    }
}