package com.bridge.qqapi;

import android.app.Activity;

import com.tencent.tauth.Tencent;

/**
 * QQ桥接
 */
public class QQApiManager {
    public static QQApiManager getInstance(){
        return Holder.INSTANCE;
    }
    private Tencent mTencent;

    public void init(Activity activity, String appId){
        mTencent = Tencent.createInstance(appId, activity);
    }

    private static class Holder{
        private final static QQApiManager INSTANCE = new QQApiManager();
    }
}
