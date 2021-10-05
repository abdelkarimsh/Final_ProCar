using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCar.Core.Exceptions
{
    public class CarInServiceNotFoundException:Exception
    {
        public CarInServiceNotFoundException() : base("All cars are Basy")
        {

        }
    }
}
