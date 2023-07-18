namespace TranspolarProject.Areas.Member.Models
{
	public class RoleAssignViewModel
	{
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; } // bu rol bu kullanıcıda var mı ?
    }
}
