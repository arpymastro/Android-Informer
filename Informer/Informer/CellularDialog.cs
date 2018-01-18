
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Telephony;

namespace Informer
{
    class CellularDialog : DialogFragment
    {
        public TextView txtPhonType, txtNetType, txtIsRoaming, txtSimSerNum, txtVoiceNum, txtNetCountry, txtOpName;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_cellular, container, false);

            //views
            txtPhonType = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellType);
            txtNetType = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellNetType);
            txtIsRoaming = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellRoam);
            txtSimSerNum = (TextView)view.FindViewById<TextView>(Resource.Id.txtSimSerNum);
            txtVoiceNum = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellVoiceNum);
            txtNetCountry = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellNetCountry);
            txtOpName = (TextView)view.FindViewById<TextView>(Resource.Id.txtCellOpName);
            
            //populating views with TelephoneManager details
            TelephonyManager telephonyManager = (TelephonyManager)Context.GetSystemService(Context.TelephonyService);

            switch (telephonyManager.PhoneType)
            {
                case PhoneType.Cdma:
                    txtNetType.Text = "Phone Type : CDMA";
                    break;
                case PhoneType.Gsm:
                    txtNetType.Text = "Phone Type : GSM";
                    break;
                case PhoneType.None:
                    txtNetType.Text = "Phone Type : NONE";
                    break;
                case PhoneType.Sip:
                    txtNetType.Text = "Phone Type : SIP";
                    break;
                default:
                    txtNetType.Text = "Phone Type : NOT FOUND";
                    break;
            }

            switch (telephonyManager.NetworkType)
            {
                case NetworkType.OneXrtt:
                    txtPhonType.Text = "Phone Type : OneXrtt";
                    break;
                case NetworkType.Cdma:
                    txtPhonType.Text = "Phone Type : Cdma";
                    break;
                case NetworkType.Edge:
                    txtPhonType.Text = "Phone Type : Edge";
                    break;
                case NetworkType.Ehrpd:
                    txtPhonType.Text = "Phone Type : Ehrpd";
                    break;
                case NetworkType.Evdo0:
                    txtPhonType.Text = "Phone Type : Evdo0";
                    break;
                case NetworkType.EvdoA:
                    txtPhonType.Text = "Phone Type : EvdoA";
                    break;
                case NetworkType.EvdoB:
                    txtPhonType.Text = "Phone Type : EvdoB";
                    break;
                case NetworkType.Gprs:
                    txtPhonType.Text = "Phone Type : Gprs";
                    break;
                case NetworkType.Lte:
                    txtPhonType.Text = "Phone Type : Lte";
                    break;
                case NetworkType.Umts:
                    txtPhonType.Text = "Phone Type : Umts";
                    break;
                case NetworkType.Unknown:
                    txtPhonType.Text = "Phone Type : Uknown";
                    break;
                default:
                    break;
            }

            txtIsRoaming.Text = "In Roaming? : " + telephonyManager.IsNetworkRoaming.ToString();
            txtSimSerNum.Text = "Sim Serial Number : " + telephonyManager.SimSerialNumber;

            if (telephonyManager.VoiceMailNumber != null)
                txtVoiceNum.Text = "Voice Mail Number : " + telephonyManager.VoiceMailNumber;
            else
                txtVoiceNum.Text = "Voice Mail Number : NOT SET";

            txtNetCountry.Text = "Network Country : " + telephonyManager.NetworkCountryIso;
            txtOpName.Text = "Operator Name : " + telephonyManager.SimOperatorName;

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
    }
}