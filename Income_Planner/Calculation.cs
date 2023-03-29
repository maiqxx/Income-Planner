using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Income_Planner
{
    class Calculation
    {
        public static string PhpPerHour { get; set; }
        public static string WorkHHourPerDay { get; set; }
        public static string TaxRate { get; set; }
        public static string SavingsRate { get; set; }
        public static string SpendableIncome { get; set; }

        public static string workSum { get; set; }
        public static string grossIncome { get; set; }
        public static string taxPay { get; set; }
        public static string savings { get; set; }
        public static string spendIncome { get; set; }
        //public static string spendIncome { get; set; }

    }
}