using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DarkStore.Domain.ENUM
{
    public enum StatusOrder : byte
    {
        [Display(Name = "В обработке")]

        Processing = 1,

        [Display(Name = "Принят")]

        Approved,

        [Display(Name = "Собирается")]

        Assembled,

        [Display(Name = "Принят в доставку")]

        Delivery,

        [Display(Name = "Доставлен")]

        Delivered
    }
}
