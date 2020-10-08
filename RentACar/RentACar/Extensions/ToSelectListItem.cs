using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Extensions
{
    public static class ToSelectListItem
    {
        public static SelectList ToSelectList(this IEnumerable items)
        {
            return new SelectList(items, "IdOsiguranja", "Tip");
        }
    }
}
