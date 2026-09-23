using Microsoft.AspNetCore.Mvc;
using nvylesson07.Models.DataModels;

namespace nvylesson07.Controllers
{
    public class nvyMemberController : Controller
    {
        // Mock Data
        protected List<nvyMember> _members = new List<nvyMember>
        {
            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "nguyenvanyen",
                nvyPassword = "123456",
                nvyFullName = "Nguyen Van Yen",
                nvyEmail = "nguyenvanyen@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "nguyenan",
                nvyPassword = "123456",
                nvyFullName = "Nguyen Van An",
                nvyEmail = "nguyenan@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "tranbinh",
                nvyPassword = "123456",
                nvyFullName = "Tran Van Binh",
                nvyEmail = "tranbinh@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "lehoa",
                nvyPassword = "123456",
                nvyFullName = "Le Thi Hoa",
                nvyEmail = "lehoa@gmail.com"
            },

            new nvyMember
            {
                nvyMemberId = Guid.NewGuid().ToString(),
                nvyUserName = "phamnam",
                nvyPassword = "123456",
                nvyFullName = "Pham Van Nam",
                nvyEmail = "phamnam@gmail.com"
            }
        }; 
        

        public IActionResult Index()
{
    return View();
}

// Đưa dữ liệu dạng List ra View
public IActionResult GetMembers()
{
    ViewBag.Members = _members;
    return View();
}

// Strong Typing - Thông tin thành viên
public IActionResult GetMember()
{
    var member = new nvyMember
    {
        nvyMemberId = Guid.NewGuid().ToString(),
        nvyUserName = "nguyenvanyen",
        nvyPassword = "123456",
        nvyFullName = "Nguyễn Văn Yên",
        nvyEmail = "nguyenvanyen@gmail.com"
    };

    return View(member);
}