﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranspolarProject.Areas.Member.Models;

namespace TranspolarProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Role")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		[Route("Index")]
		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}

		[HttpGet]
		[Route("CreateRole")]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateRole")]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
		{
			AppRole role = new AppRole()
			{
				Name = createRoleViewModel.RoleName
			};
			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("Index","Role");
			}
			return View();
		}

		[Route("DeleteRole/{id}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}

		[Route("EditRole/{id}")]
		[HttpGet]
		public async Task<IActionResult> EditRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
			UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel
			{
				RoleID = id,
				RoleName = value.Name
			};
			return View(updateRoleViewModel);
		}

		[Route("EditRole/{id}")]
		[HttpPost]
		public async Task<IActionResult> EditRole(UpdateRoleViewModel updateRoleViewModel)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
			value.Name = updateRoleViewModel.RoleName;
			await _roleManager.UpdateAsync(value);
			return RedirectToAction("Index");
		}

		[Route("UserList")]
		public IActionResult UserList()
		{
			var values = _userManager.Users.ToList();
			return View(values);
		}

		[Route("AssignRole/{id}")]
		public async Task<IActionResult> AssignRole(int id)
		{
			var user = _userManager.Users.FirstOrDefault(x=>x.Id ==id);
			var roles = _roleManager.Roles.ToList();
			var userRoles = await _userManager.GetRolesAsync(user);
			List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
			foreach (var item in roles)
			{
				RoleAssignViewModel model = new RoleAssignViewModel();
				model.RoleID = item.Id;
				model.RoleName = item.Name;
				model.RoleExist = userRoles.Contains(item.Name);
				roleAssignViewModels.Add(model);
			}
			return View(roleAssignViewModels);
		}

	}
}