﻿using System.ComponentModel.DataAnnotations;

namespace TranspolarProject.Areas.Customer.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
		public string Password { get; set; }
	}
}
