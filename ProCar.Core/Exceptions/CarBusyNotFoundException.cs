using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Exceptions
{
    public class CarBusyNotFoundException:Exception
    {
        public CarBusyNotFoundException() : base("All cars are available")
        {

        }
    }
}
