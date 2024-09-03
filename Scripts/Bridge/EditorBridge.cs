// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		EditorBridge.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/02/03 19:26:41
// *******************************************

#if UNITY_EDITOR
namespace Bridge.QQApi
{
	using Common;

	/// <summary>
	/// 
	/// </summary>
	internal class EditorBridge : IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		void IBridge.InitSDK(ICommonListener listener)
		{
			listener?.OnResult(0, "");
		}

		/// <summary>
		/// 一键拉起加QQ群
		/// </summary>
		/// <param name="qqGroupValue">加群参数</param>
		/// <param name="listener">加群回调</param>
		void IBridge.JoinQQGroup(string qqGroupValue, ICommonListener listener)
		{
			listener?.OnResult(0, "");
		}
	}
}
#endif