// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		iOSBridgeImpl.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/02/03 17:34:49
// *******************************************

#if UNITY_IOS
namespace Bridge.QQApi
{
	using Common;
	using System.Runtime.InteropServices;

	/// <summary>
	/// 
	/// </summary>
	internal class iOSBridgeImpl : IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		void IBridge.InitSDK(IBridgeListener listener)
		{
			listener?.OnSuccess("");
		}
	}
}
#endif