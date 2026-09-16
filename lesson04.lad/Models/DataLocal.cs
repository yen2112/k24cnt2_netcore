using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson04.lad.Models
{
    public class DataLocal
    {
        public static List<People> _peoples = new List<People>()
        {
            new People(){ Id = 1, Name = "Devmaster", Email = "devmaster.edu.vn@gmail.com", Phone = "0978611889", Address = "25 Vũ Ngọc Phan", Avatar = "images/avatar/01.jpg", Birthday = Convert.ToDateTime("2012/09/22"), Bio = "Viện Công Nghệ Devmaster", Gender = 1 },
            new People(){ Id = 2, Name = "Trịnh Văn Chung", Email = "chunghd@gmail.com", Phone = "0978611889", Address = "25 Vũ Ngọc Phan", Avatar = "images/avatar/01.jpg", Birthday = Convert.ToDateTime("1979/05/25"), Bio = "Devmaster Academy", Gender = 1 },
            new People(){ Id = 3, Name = "Gia Lâm", Email = "huypq@gmail.com", Phone = "0912113213", Address = "Gia Lâm, Hà Nội", Avatar = "images/avatar/02.jpg", Birthday = Convert.ToDateTime("1999/02/12"), Bio = "Viện công nghệ Devmaster", Gender = 1 },
            new People(){ Id = 4, Name = "Tiểu Long Nữ", Email = "lengoc@gmail.com", Phone = "0988001002", Address = "Bắc Ninh", Avatar = "images/avatar/03.jpg", Birthday = Convert.ToDateTime("2000/02/02"), Bio = "Nhân vật trong phim kiếm hiệp", Gender = 0 },
            new People(){ Id = 5, Name = "Doãn Chí Bình", Email = "binhdc@gmail.com", Phone = "0988001003", Address = "Chùa Bái Đính", Avatar = "images/avatar/04.jpg", Birthday = Convert.ToDateTime("1997/12/12"), Bio = "Nhân vật trong phim kiếm hiệp", Gender = 1 }
        };

        public static List<People> GetPeoples()
        {
            return _peoples;
        }

        public static People? GetPeopleById(int id)
        {
            var people = _peoples.FirstOrDefault(x => x.Id == id);
            return people;
        }
    }
}
