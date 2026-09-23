using Microsoft.AspNetCore.Mvc;
using nvylesson08model.Models;

namespace nvylesson08model.Controllers
{
    public class nvyMemberController : Controller
    {
        // Mock data - nvyMember
        private static List<nvyMember> _members = new List<nvyMember>()
        {
            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "nguyenvanyen",
                nvyPassword = "123456",
                nvyFullName = "Nguyen Van Yen",
                nvyEmail = "yendzvl2006@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "nguyenvana",
                nvyPassword = "123456",
                nvyFullName = "Nguyen Van A",
                nvyEmail = "nguyenvana@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "tranthib",
                nvyPassword = "123456",
                nvyFullName = "Tran Thi B",
                nvyEmail = "tranthib@gmail.com"
            }
        };
        
        // Get: Danh sách thành viên 
        public IActionResult Index()
        {
            return View(_members);
        }
    }
}
