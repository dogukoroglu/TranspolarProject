﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Staff
	{
		[Key]
		public int StaffID { get; set; }
        public string Name{ get; set; }
        public string Position{ get; set; }
        public string ImageUrl{ get; set; }
        public string SocialMedia1{ get; set; }
        public string SocialMedia2{ get; set; }
        public string SocialMedia3{ get; set; }
        public bool Status{ get; set; }
    }
}
