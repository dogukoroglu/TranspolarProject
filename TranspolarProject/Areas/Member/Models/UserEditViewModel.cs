﻿namespace TranspolarProject.Areas.Member.Models
{
	public class UserEditViewModel
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
    }
}
