package com.bridge.qqapi;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import com.bridge.R;
import com.bridge.common.listener.IBridgeListener;
import com.bridge.qqapi.callback.LoginCallback;
import com.bridge.qqapi.callback.ShareCallback;
import com.tencent.connect.common.Constants;
import com.tencent.connect.share.QQShare;
import com.tencent.tauth.Tencent;

/**
 * QQ桥接
 */
public class QQApiManager {
    public static QQApiManager getInstance(){
        return Holder.INSTANCE;
    }
    private Tencent mTencent;
    private LoginCallback loginCallback;
    private ShareCallback shareCallback;

    public void init(Activity activity, String appId){
        mTencent = Tencent.createInstance(appId, activity, activity.getString(R.string.qq_authorities));
    }

    public void login(Activity activity, String scope, IBridgeListener loginListener){
        loginCallback = new LoginCallback(loginListener);
        mTencent.login(activity, scope, loginCallback);
    }

    public void share(Activity activity, String targetUrl, String title, String imageUrl, IBridgeListener shareListener){
        final Bundle params = new Bundle();
        params.putInt(QQShare.SHARE_TO_QQ_KEY_TYPE, QQShare.SHARE_TO_QQ_TYPE_IMAGE);
        params.putString(QQShare.SHARE_TO_QQ_TARGET_URL, targetUrl);
        params.putString(QQShare.SHARE_TO_QQ_TITLE, title);
        params.putString(QQShare.SHARE_TO_QQ_IMAGE_LOCAL_URL, imageUrl);
        params.putInt(QQShare.SHARE_TO_QQ_EXT_INT, QQShare.SHARE_TO_QQ_FLAG_QZONE_ITEM_HIDE);
        shareCallback = new ShareCallback(shareListener);
        mTencent.shareToQQ(activity, params, shareCallback);
    }

    public void onActivityResult(int requestCode, int resultCode, Intent data){
        switch (resultCode){
            case Constants.REQUEST_LOGIN:
            case Constants.REQUEST_APPBAR:
                Tencent.onActivityResultData(requestCode, resultCode, data, loginCallback);
            break;
            case Constants.REQUEST_QQ_SHARE:
                Tencent.onActivityResultData(requestCode, resultCode, data, shareCallback);
            break;
            default:
                break;
        }
    }

    private static class Holder{
        private final static QQApiManager INSTANCE = new QQApiManager();
    }
}
