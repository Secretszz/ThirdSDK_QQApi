// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		IInitListener.cs
//
// Author Name:		Bridge
//
// Create Time:		2024/02/03 16:04:32
// *******************************************

namespace Bridge.QQApi
{
	using Common;

	internal interface IBridge
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="listener"></param>
		void InitSDK(ICommonListener listener);

		/// <summary>
		/// 一键拉起加QQ群
		/// </summary>
		/// <param name="qqGroupValue">加群参数</param>
		/// <param name="listener">加群回调</param>
		void JoinQQGroup(string qqGroupValue, ICommonListener listener);
	}
}