using System;
using System.Reflection;
using GLib;

public static class Patch
{
	private static void ConnectDefaultHandlers (GType gtype, System.Type t)
	{
		foreach (MethodInfo minfo in t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly)) {
			MethodInfo baseinfo = minfo.GetBaseDefinition ();
			if (baseinfo == minfo)
				continue;

			foreach (object attr in baseinfo.GetCustomAttributes (typeof (DefaultSignalHandlerAttribute), false)) {
				DefaultSignalHandlerAttribute sigattr = attr as DefaultSignalHandlerAttribute;
				MethodInfo connector = sigattr.Type.GetMethod (sigattr.ConnectionMethod, BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { typeof (GType) }, new ParameterModifier [0]);
				object[] parms = new object [1];
				parms [0] = gtype;
				connector.Invoke (null, parms);
				break;
			}
		}
	}
}
