using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;

namespace Informer
{
    class BluetoothDialog : DialogFragment
    {
        public ListView mListOfAvailDevices, mListOfPairedDevices;
        public static List<string> scanPairedResults, scanAvailResults;
        public TextView txtBluStatus, txtBluConnectName, txtBlutoothAddres;
        BluetoothAdapter mBluetoothAdapter;
        //private BluetoothBroadCastReceiver mBluetoothBroadCastReceiver;
        IntentFilter intentFilter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_bluetooth, container, false);

            //views
            txtBluStatus = (TextView)view.FindViewById<TextView>(Resource.Id.txtBluState);
            txtBluConnectName = (TextView)view.FindViewById<TextView>(Resource.Id.txtBluConName);
            txtBlutoothAddres = (TextView)view.FindViewById<TextView>(Resource.Id.txtBluAddress);
            mListOfPairedDevices = (ListView)view.FindViewById<ListView>(Resource.Id.lvBluPairedList);


            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
                        
            //general info
            if (mBluetoothAdapter.IsEnabled)
            {
                txtBluStatus.Text = "Bluetooth State : Enabled";
                txtBluConnectName.Text = "Connection Name : " + mBluetoothAdapter.Name.ToString();
                txtBlutoothAddres.Text = "Address : " + mBluetoothAdapter.Address;
            }
            else
            {
                txtBluStatus.Text = "Bluetooth State : Disabled. Please enable to see available connections.";
                txtBluConnectName.Text = "Connection Name : None";
                txtBlutoothAddres.Text = "Address : Not Available";
            }

            //paired devices
            scanPairedResults = new List<string>();
            foreach (BluetoothDevice bondedDevice in mBluetoothAdapter.BondedDevices)
            {
                scanPairedResults.Add(bondedDevice.Name);
            }
            MyListViewAdapter mlva = new MyListViewAdapter(Context, scanPairedResults);
            mListOfPairedDevices.Adapter = mlva;

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
}