using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="Bangla is My Mother Toungue")]
        Bangla=1,
        Hindi=2,
        English=3,
        Tamil=4,
        Dutch=5,
        Urdhu=6
    }
}
