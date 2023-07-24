using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApplication6.Models;

namespace DarkStore.Domain.Entity
{
    public class Basket
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }        

        public string FirstNameUser { get; set; }     

        public string SecondNameUser { get; set; }

        public string ProductName { get; set; }

   
        public string DescriptionUser { get; set; }      

        public string UserNumberPhone { get; set; }


        public string UserEmail { get; set; }

        public DateTime UserDate { get; set; }

        public bool State { get; set; }

        public static Basket BuildBasket(BasketModel newBasket)
        {
            Basket Basket = new Basket();
            Basket.ProductName = newBasket.ProductName;
            Basket.UserNumberPhone = newBasket.UserNumberPhone;
            Basket.SecondNameUser = newBasket.SecondNameUser;
            Basket.ProductId = newBasket.ProductId;
            Basket.DescriptionUser = newBasket.DescriptionUser;
            Basket.FirstNameUser = newBasket.FirstNameUser;
            Basket.State = false;
            Basket.UserDate = newBasket.UserDate;
            Basket.UserEmail = newBasket.UserEmail;           
            if(newBasket.UserId == 0 )
            {
                Basket.UserId = 1;
            }
            else
            {
                Basket.UserId = newBasket.UserId;
            }
            return Basket;
        }




    }
}
