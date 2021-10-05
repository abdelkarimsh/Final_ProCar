using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Conestants
{
    public class Results
    {
        public static object AddSuccessResult()
        {
            return new { status = 1, msg = "s:تمت اضافة العنصر بنجا", close = 1 };
        }

        public static object EditSuccessResult()
        {
            return new { status = 1, msg = "s:تمت التعديل على العنصر بنجا", close = 1 };
        }
        public static object UpdateStatusSuccessResult()
        {
            return new { status = 1, msg = "s: تم تحديث الحالة  بنجاح ", close = 1 };
        }

        public static object DeleteSuccessResult()
        {
            return new { status = 1, msg = "s: تم حذف العنصر بنجاح", close = 1 };
        }




    }
}
