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

		/// <summary>
		/// 一键拉起加QQ群
		/// </summary>
		/// <param name="qqGroupValue">加群参数</param>
		/// <param name="listener">加群回调</param>
		void IBridge.JoinQQGroup(string qqGroupValue, IBridgeListener listener)
		{
			string[] keys = qqGroupValue.Split(',');
			if (c_join_qq_group(keys[0], keys[1]))
			{
				listener?.OnSuccess("");
			}
			else
			{
				listener?.OnError(-1, "打开QQ失败，请检查设备内是否安装了QQ");
			}
		}

		[DllImport("__Internal")]
		private static extern bool c_join_qq_group(string groupUin, string key);
	}
}
#endif