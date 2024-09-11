// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		QQApi.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/09/03 18:37:07
// *******************************************

namespace Bridge.QQApi
{
	using Common;

	/// <summary>
	/// 
	/// </summary>
	public static class QQApi
	{
		private static IBridge _bridge;

		/// <summary>
		/// SDK桥接文件
		/// </summary>
		private static IBridge bridgeImpl
		{
			get
			{
				if (_bridge == null)
				{
#if UNITY_IOS && !UNITY_EDITOR
					_bridge = new iOSBridgeImpl();
#elif UNITY_ANDROID && !UNITY_EDITOR
					_bridge = new AndroidBridgeImpl();
#else
					_bridge = new EditorBridge();
#endif
				}

				return _bridge;
			}
		}
		
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		public static void InitSDK(IBridgeListener listener)
		{
			bridgeImpl.InitSDK(listener);
		}

		/// <summary>
		/// 一键拉起加QQ群
		/// QQ群Key生成网页：https://qun.qq.com/join.html
		/// </summary>
		/// <param name="qqGroupValue">加群参数</param>
		/// <param name="listener">加群回调</param>
		public static void JoinQQGroup(string qqGroupValue, IBridgeListener listener)
		{
			bridgeImpl.JoinQQGroup(qqGroupValue, listener);
		}
	}
}