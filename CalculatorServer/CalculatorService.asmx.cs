using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CalculatorServer
{
    [WebService]
    public class CalculatorService : System.Web.Services.WebService
    {

        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public int Sub(int a, int b)
        {
            return a - b;
        }

        [WebMethod]
        public int Mul(int a, int b)
        {
            return a * b;
        }

        [WebMethod]
        public double Div(int a, int b)
        {
            return b == 0 ? 0 : (double)a / (double)b;
        }
    }
}
