package md565596b2d7463dc953a14dc72bf433bff;


public class BluetoothDialog_BluetoothBroadCastReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Informer.BluetoothDialog+BluetoothBroadCastReceiver, Informer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BluetoothDialog_BluetoothBroadCastReceiver.class, __md_methods);
	}


	public BluetoothDialog_BluetoothBroadCastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BluetoothDialog_BluetoothBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("Informer.BluetoothDialog+BluetoothBroadCastReceiver, Informer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public BluetoothDialog_BluetoothBroadCastReceiver (md565596b2d7463dc953a14dc72bf433bff.BluetoothDialog p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == BluetoothDialog_BluetoothBroadCastReceiver.class)
			mono.android.TypeManager.Activate ("Informer.BluetoothDialog+BluetoothBroadCastReceiver, Informer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Informer.BluetoothDialog, Informer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
