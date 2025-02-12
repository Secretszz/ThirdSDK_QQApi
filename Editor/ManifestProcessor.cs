// *******************************************
// Company Name:	深圳市晴天互娱科技有限公司
//
// File Name:		ManifestProcessor.cs
//
// Author Name:		Bridge
//
// Create Time:		2023/12/04 19:13:02
// *******************************************

#if UNITY_ANDROID
namespace Bridge.QQApi
{
    using System.Xml.Linq;
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    using UnityEditor.Callbacks;
    using Common;

    internal static class ManifestProcessor
    {
        [PostProcessBuild(10001)]
        public static void OnPostprocessBuild(BuildTarget target, string projectPath)
        {
            CopyNativeCode(projectPath);
        }

        private static void CopyNativeCode(string projectPath)
        {
            var sourcePath = ThirdSDKPackageManager.GetUnityPackagePath(PackageType.QQ);
            if (string.IsNullOrEmpty(sourcePath))
            {
                // 这个不是通过ump下载的包，查找工程内部文件夹
                sourcePath = "Assets/ThirdSDK/QQApi";
            }

            sourcePath += "/Plugins/Android/qqapi";
            Debug.Log("remotePackagePath===" + sourcePath);
            string targetPath = Path.Combine(projectPath, Common.ManifestProcessor.NATIVE_CODE_DIR, "qqapi");
            Debug.Log("targetPath===" + targetPath);
            FileTool.DirectoryCopy(sourcePath, targetPath);
            RefreshManifest();
            ThirdSDKSettings settings = ThirdSDKSettings.Instance;
            string packageName = PlayerSettings.applicationIdentifier;
            SetStringsConfig(settings.QQAppId, packageName);
        }
        
        private static void SetStringsConfig(string app_id, string packageName)
        {
            Common.ManifestProcessor.StringsElements.Add(new XElement("string", new XAttribute("name", "qq_app_id"), app_id));
            Common.ManifestProcessor.StringsElements.Add(new XElement("string", new XAttribute("name", "qq_login_protocol_scheme"), $"tencent{app_id}"));
            Common.ManifestProcessor.StringsElements.Add(new XElement("string", new XAttribute("name", "qq_authorities"), $"{packageName}.fileprovider"));
        }

        private static void RefreshManifest()
        {
            Common.ManifestProcessor.ApplicationElements.Add(new XElement("activity",
                new XAttribute(Common.ManifestProcessor.ns + "name", "com.tencent.tauth.AuthActivity"),
                new XAttribute(Common.ManifestProcessor.ns + "noHistory", "true"),
                new XAttribute(Common.ManifestProcessor.ns + "launchMode", "singleTask"),
                new XElement("intent-filter",
                    new XElement("action", new XAttribute(Common.ManifestProcessor.ns + "name", Common.ManifestProcessor.ACTION_VIEW)),
                    new XElement("category", new XAttribute(Common.ManifestProcessor.ns + "name", Common.ManifestProcessor.DEFAULT_CATEGORY)),
                    new XElement("category", new XAttribute(Common.ManifestProcessor.ns + "name", Common.ManifestProcessor.BROWSABLE_CATEGORY)),
                    new XElement("data", new XAttribute(Common.ManifestProcessor.ns + "scheme", "@string/qq_login_protocol_scheme")))));

            Common.ManifestProcessor.ApplicationElements.Add(new XElement("activity",
                new XAttribute(Common.ManifestProcessor.ns + "name", "com.tencent.connect.common.AssistActivity"),
                new XAttribute(Common.ManifestProcessor.ns + "configChanges", "orientation|keyboardHidden|screenSize"),
                new XAttribute(Common.ManifestProcessor.ns + "screenOrientation", "behind"),
                new XAttribute(Common.ManifestProcessor.ns + "theme", "@android:style/Theme.Translucent.NoTitleBar")));
        }
    }
}
#endif
