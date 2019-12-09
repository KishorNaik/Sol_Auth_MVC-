using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Web_Api.Model
{
    public static class AppSetting
    {
        public static String Secret { get; set; } = "this is my custom Secret key for authnetication";
    }
}
