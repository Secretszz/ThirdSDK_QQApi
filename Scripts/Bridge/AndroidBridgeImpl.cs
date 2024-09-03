// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		AndroidBridgeImpl.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/02/03 16:16:05
// *******************************************

using Bridge.Common;

#if UNITY_ANDROID
namespace Bridge.QQApi
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	internal class AndroidBridgeImpl : IBridge
	{
		private const string UnityPlayerClassName = "com.unity3d.player.UnityPlayer";
		private const string ManagerClassName = "com.bridge.qqapi.QQApiManager";

		private static AndroidJavaClass bridge;
		private static AndroidJavaObject currentActivity;
		
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		void IBridge.InitSDK(ICommonListener listener)
		{
			AndroidJavaClass unityPlayer = new AndroidJavaClass(UnityPlayerClassName);
			currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			bridge = new AndroidJavaClass(ManagerClassName);
			listener?.OnResult(0, "");
		}

		/// <summary>
		/// 一键拉起加QQ群
		/// </summary>
		/// <param name="qqGroupValue">加群参数</param>
		/// <param name="listener">加群回调</param>
		void IBridge.JoinQQGroup(string qqGroupValue, ICommonListener listener)
		{
			if (bridge.CallStatic<bool>("joinQQGroup", currentActivity, qqGroupValue))
			{
				listener?.OnResult(0, "");
			}
			else
			{
				listener?.OnResult(-1, "打开QQ失败，请检查设备内是否安装了QQ");
			}
		}
	}
}
#endif