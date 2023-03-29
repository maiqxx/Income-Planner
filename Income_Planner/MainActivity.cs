using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AlertDialog = Android.App.AlertDialog;

namespace Income_Planner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnCalculate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            btnCalculate.Click += BtnCalculate_Click;
            
        }

        private void BtnCalculate_Click(object sender, System.EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmation");
            alert.SetMessage("Do you want to calculate?");

            alert.SetPositiveButton(
                "OK", (x,y) =>
            {
                var perHour = FindViewById<EditText>(Resource.Id.editTextPHP);
                double phperhour = double.Parse(perHour.Text);
                var work = FindViewById<EditText>(Resource.Id.editTextWorkHourPerDay);
                double workperday = double.Parse(work.Text);
                var save = FindViewById<EditText>(Resource.Id.editTextTaxRate);
                double saving = double.Parse(save.Text);
                var tax = FindViewById<EditText>(Resource.Id.editTextSavings);
                double taxrate = double.Parse(tax.Text);

                double annualworksummary = workperday * 5 * 50;
                double annualincome = phperhour * workperday * 5 * 50;
                double taxpayable = (taxrate / 100) * annualincome;
                double annualsavings = (saving / 100) * annualincome;
                double spendableincome = annualincome - saving - taxpayable;

                Calculation.workSum = annualworksummary.ToString();
                Calculation.grossIncome = annualincome.ToString();
                Calculation.taxPay = taxpayable.ToString();
                Calculation.savings = annualsavings.ToString();
                Calculation.SpendableIncome = spendableincome.ToString();

                Intent i = new Intent(this, typeof(Results_));  
                StartActivity(i);
            });

            alert.SetNegativeButton("Cancel", delegate
            {
                var perHour = FindViewById<EditText>(Resource.Id.editTextPHP);
                perHour.Text = "";
                var work = FindViewById<EditText>(Resource.Id.editTextWorkHourPerDay);
                work.Text = "";
                var save = FindViewById<EditText>(Resource.Id.editTextTaxRate);
                save.Text = "";
                var tax = FindViewById<EditText>(Resource.Id.editTextSavings);
                tax.Text = "";

                Toast.MakeText(this, "You have cancelled the action!", ToastLength.Long).Show();
            });

            Dialog diag = alert.Create();
            diag.Show();
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}