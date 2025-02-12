// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		AndroidBridgeImpl.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/02/03 16:16:05
// *******************************************

#if UNITY_ANDROID
namespace Bridge.QQApi
{
	using Common;
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	internal class AndroidBridgeImpl : IBridge
	{
		private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
		private const string ManagerClassName = "com.bridge.qqapi.QQApiManager";

		private static AndroidJavaObject sdk;
		private static AndroidJavaObject currentActivity;
		
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		void IBridge.InitSDK(IBridgeListener listener)
		{
			AndroidJavaClass unityPlayer = new AndroidJavaClass(UnityPlayerClassName);
			currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass bridge = new AndroidJavaClass(ManagerClassName);
			sdk = bridge.CallStatic<AndroidJavaObject>("getInstance");
			listener?.OnSuccess("");
		}
	}
}
#endif