using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Net.Wifi;
using System;
using Java.Lang;

namespace Informer
{
    class WifiDialog : DialogFragment
    {
        public static List<string> scanResults;
        public ListView mAvailWifiList;
        public TextView txtStatus, txtConName;
        private static WifiManager mWifiManager;
        private WifiBroadCastReceiver wifiBroadCastReceiver;
        IntentFilter intentFilter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_wifi, container, false);

            //views
            txtStatus = (TextView)view.FindViewById<TextView>(Resource.Id.txtState);
            txtConName = (TextView)view.FindViewById<TextView>(Resource.Id.txtConName);
            mAvailWifiList = (ListView)view.FindViewById<ListView>(Resource.Id.lvWifiList);

            mWifiManager = (WifiManager)Context.GetSystemService(Context.WifiService);

            if (mWifiManager.IsWifiEnabled)
            {
                txtStatus.Text = "Wifi State : Enabled";
                txtConName.Text = "Connection Name : " + mWifiManager.ConnectionInfo.SSID.ToString();
                
            }
            else
            {
                txtStatus.Text = "Wifi State : Disabled. Please enable to see available networks.";
                txtConName.Text = "Connection Name : None";
            }
                

            intentFilter = new IntentFilter(WifiManager.ScanResultsAvailableAction);
            wifiBroadCastReceiver = new WifiBroadCastReceiver(this);

            Context.RegisterReceiver(wifiBroadCastReceiver, intentFilter);
            mWifiManager.StartScan();


            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //sets the title bar invisible
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //sets the animation
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

        class WifiBroadCastReceiver : BroadcastReceiver
        {

            private WifiDialog wifiDialog;
            public WifiBroadCastReceiver(WifiDialog wifiDialog)
            {
                this.wifiDialog = wifiDialog;
            }
            public override void OnReceive(Context context, Intent intent)
            {
                scanResults = new List<string>();
                IList<ScanResult> scanwifinetworks = mWifiManager.ScanResults;
                foreach (ScanResult wifinetwork in scanwifinetworks)
                {
                    scanResults.Add(wifinetwork.Ssid);
                }
                //ArrayAdapter<string> adapter = new ArrayAdapter<string>(context, Android.Resource.Layout.SimpleListItem1, scanResults);
                MyListViewAdapter adapter = new MyListViewAdapter(context, scanResults);

                wifiDialog.mAvailWifiList.Adapter = adapter;
            }
        }
    }


}