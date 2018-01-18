using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Informer
{
    [Activity(Label = "Informer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnBattery;
        private Button mBtnWifi, mBtnBlue, mBtnCell;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            

            //calling event when battery info button is clicked
            mBtnBattery = FindViewById<Button>(Resource.Id.btnBattery);
            mBtnBattery.Click += (object sender, EventArgs args) =>
            {
                //pull up the dialog
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                BatteryDialog bd = new BatteryDialog();
                bd.Show(trans, "Battery Dialog Fragment");
            };

            //calling event when wifi info button is clicked
            mBtnWifi = FindViewById<Button>(Resource.Id.btnWifi);
            mBtnWifi.Click += (object sender, EventArgs args) =>
            {
                //pull up the dialog
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                WifiDialog wd = new WifiDialog();
                wd.Show(trans, "Wifi Dialog Fragment");
            };

            //calling event when bluetooth info button is clicked
            mBtnBlue = FindViewById<Button>(Resource.Id.btnBluetooth);
            mBtnBlue.Click += (object sender, EventArgs args) =>
            {
                //pull up the dialog
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                BluetoothDialog bd = new BluetoothDialog();
                bd.Show(trans, "Bluetooth Dialog Fragment");
            };

            //calling event when cell info button is clicked
            mBtnCell = FindViewById<Button>(Resource.Id.btnCell);
            mBtnCell.Click += (object sender, EventArgs args) =>
            {
                //pull up the dialog
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                CellularDialog cd = new CellularDialog();
                cd.Show(trans, "Cellular Dialog Fragment");
            };

        }
    }
}

