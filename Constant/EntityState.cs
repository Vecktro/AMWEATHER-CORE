using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMWEATHER_CORE.Constant
{
    public static class EntityState
    {
        public static Microsoft.EntityFrameworkCore.EntityState Modified() {
            return Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public static Microsoft.EntityFrameworkCore.EntityState Delete()
        {
            return Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
