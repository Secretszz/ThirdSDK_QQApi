package com.bridge.qqapi;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;

/**
 * QQ桥接
 */
public class QQApiManager {
    public static QQApiManager getInstance(){
        return Holder.INSTANCE;
    }

    private static class Holder{
        private final static QQApiManager INSTANCE = new QQApiManager();
    }
}
