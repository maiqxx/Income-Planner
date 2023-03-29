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
using AndroidX.AppCompat.App;
using AlertDialog = Android.App.AlertDialog;

namespace Income_Planner
{
    [Activity(Label = "Results_")]
    public class Results_ : Activity
    {
        Button button1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Rezults);

            var php = FindViewById<TextView>(Resource.Id.txtWorkSum);
            php.Text = Calculation.workSum;
            
            var work = FindViewById<TextView>(Resource.Id.txtGrossIncome);
            work.Text = Calculation.grossIncome;

            var save = FindViewById<TextView>(Resource.Id.txtTaxPay);
            save.Text = Calculation.savings;

            var tax = FindViewById<TextView>(Resource.Id.txtSavings);
            tax.Text = Calculation.taxPay;

            var inc = FindViewById<TextView>(Resource.Id.txtSpendableIncome);
            inc.Text = Calculation.SpendableIncome;

            button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click1;
        }

        private void Button1_Click1(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmation");
            alert.SetMessage("Are you sure you want to go back?");

            alert.SetPositiveButton(
                "Yes", (x, y) =>
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    StartActivity(i);
                });

            alert.SetNegativeButton("Cancel", delegate
            {
                Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
            });

            Dialog diag = alert.Create();
            diag.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}