using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Informer
{
    class BatteryDialog : DialogFragment
    {
        public TextView txtBatteryStatus, txtBatteryPlug, txtBatteryLevel, txtBatteryTemp, txtBatteryTech, txtBatteryHealth, txtBatteryVoltage;
        IntentFilter intentFilter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_battery, container, false);

            //Views
            txtBatteryStatus = (TextView)view.FindViewById<TextView>(Resource.Id.txtStatus);
            txtBatteryPlug = (TextView)view.FindViewById<TextView>(Resource.Id.txtPlug);
            txtBatteryLevel = (TextView)view.FindViewById<TextView>(Resource.Id.txtLevel);
            txtBatteryTemp = (TextView)view.FindViewById<TextView>(Resource.Id.txtTemp);
            txtBatteryTech = (TextView)view.FindViewById<TextView>(Resource.Id.txtTech);
            txtBatteryHealth = (TextView)view.FindViewById<TextView>(Resource.Id.txtHealth);
            txtBatteryVoltage = (TextView)view.FindViewById<TextView>(Resource.Id.txtVoltage);

            //intent filter
            intentFilter = new IntentFilter(Intent.ActionBatteryChanged);
            MyBroadCastReceiver myBroadCastReceiver = new MyBroadCastReceiver(this);

            Context.RegisterReceiver(myBroadCastReceiver, intentFilter);           

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //sets the title bar to invisible
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //sets the animation
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

    }

    internal class MyBroadCastReceiver:BroadcastReceiver
    {
        private BatteryDialog batteryDialog;

        public MyBroadCastReceiver(BatteryDialog batteryDialog)
        {
            this.batteryDialog = batteryDialog;
        }

        public override void OnReceive(Context context, Intent intent)
        {
                        
            //status
            int status = intent.GetIntExtra(BatteryManager.ExtraStatus, -1);
            if (status == (int)Android.OS.BatteryStatus.Charging)
                batteryDialog.txtBatteryStatus.Text = "Battery Status : Charging";
            else if (status == (int)Android.OS.BatteryStatus.Full)
                batteryDialog.txtBatteryStatus.Text = "Battery Status : Full";
            else if (status == (int)Android.OS.BatteryStatus.Discharging)
                batteryDialog.txtBatteryStatus.Text = "Battery Status : Discharging";
            else if (status == (int)Android.OS.BatteryStatus.NotCharging)
                batteryDialog.txtBatteryStatus.Text = "Battery Status : Not Charging";
            else if (status == (int)Android.OS.BatteryStatus.Unknown)
                batteryDialog.txtBatteryStatus.Text = "Battery Status : Unknown";

            //plug
            int chargePlug = intent.GetIntExtra(BatteryManager.ExtraPlugged, -1);
            if (status == (int)Android.OS.BatteryPlugged.Ac)
                batteryDialog.txtBatteryPlug.Text = "Power Source : AC";
            else if (status == (int)Android.OS.BatteryPlugged.Usb)
                batteryDialog.txtBatteryPlug.Text = "Power Source : USB";
            else if (status == (int)Android.OS.BatteryPlugged.Wireless)
                batteryDialog.txtBatteryPlug.Text = "Power Source : Wireless";

            //level
            int level = intent.GetIntExtra(BatteryManager.ExtraLevel, -1);
            int scale = intent.GetIntExtra(BatteryManager.ExtraScale, -1);
            float batteryPct = (level / (float)scale) * 100;
            batteryDialog.txtBatteryLevel.Text = "Battery Level : " + batteryPct.ToString();

            //voltage
            int voltage = intent.GetIntExtra(BatteryManager.ExtraVoltage, -1);
            batteryDialog.txtBatteryVoltage.Text = "Battery Voltage : " + voltage.ToString() + "mV";

            //temperature
            int temp = intent.GetIntExtra(BatteryManager.ExtraTemperature, -1);
            batteryDialog.txtBatteryTemp.Text = "Battery Temperature : "+ temp.ToString() + "*C";

            //technology
            String tech = intent.GetStringExtra(BatteryManager.ExtraTechnology);
            batteryDialog.txtBatteryTech.Text = "Battery Technology : "+ tech;

            //health
            int health = intent.GetIntExtra(BatteryManager.ExtraHealth, -1);
            switch (health)
            {
                case (int)Android.OS.BatteryHealth.Cold:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : COLD";
                    break;
                case (int)Android.OS.BatteryHealth.Dead:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : DEAD";
                    break;
                case (int)Android.OS.BatteryHealth.Good:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : GOOD";
                    break;
                case (int)Android.OS.BatteryHealth.Overheat:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : OVERHEAT";
                    break;
                case (int)Android.OS.BatteryHealth.OverVoltage:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : OVERVOLTAGE";
                    break;
                case (int)Android.OS.BatteryHealth.Unknown:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : UNKNOWN";
                    break;
                case (int)Android.OS.BatteryHealth.UnspecifiedFailure:
                    batteryDialog.txtBatteryHealth.Text = "Battery Health : FAILURE";
                    break;
                default:
                    break;
            }
            
        }
    }
}