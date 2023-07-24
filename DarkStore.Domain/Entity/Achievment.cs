using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace DarkStore.Domain.Entity
{
    public class Achievment
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string srcImg { get; set; }

        public DateTime DateTime { get; set; }

        public int typeId { get; set; }

        public int progress { get; set; }

        public string UserEmail { get; set; }
        public static List<Achievment> AchievemetBuild(RegisterModel newuser)
        {
            Achievment achievement1 = new Achievment() {
                Name = "Первая регистрация!",
                Description = "Зарегистрироваться на сайте",
                srcImg = "/Images/WebPages/PersonCab/Достижение3.png",
                typeId = 1,
                DateTime = DateTime.Now,
                progress = 100,
                UserEmail = newuser.Email
            };
            Achievment achievement2 = new Achievment() {
                Name = "Уже десять дней на сайте",
                Description = "Создать аккаунт и подождать 10 дней)",
                srcImg = "/Images/WebPages/PersonCab/Достижение3.png",
                typeId = 1,
                DateTime = DateTime.Now,
                progress = 0,
                UserEmail = newuser.Email
            };
            Achievment achievement3 = new Achievment() {
                Name = "Довольный пользователь",
                Description = "Оставить 10 положительных комментариев)",
                srcImg = "/Images/WebPages/PersonCab/Достижение3.png",
                typeId = 2,
                DateTime = DateTime.Now,
                progress = 0,
                UserEmail = newuser.Email
            };
            Achievment achievement4 = new Achievment() {
                Name = "Обеспеченый пользователь",
                Description = "Оставить 10 заявок)",
                srcImg = "/Images/WebPages/PersonCab/Достижение3.png",
                typeId = 3,
                DateTime = DateTime.Now,
                progress = 0,
                UserEmail = newuser.Email
            };
            return new List<Achievment>() { achievement1, achievement2, achievement3, achievement4 };
        }
        
    }

}
    
