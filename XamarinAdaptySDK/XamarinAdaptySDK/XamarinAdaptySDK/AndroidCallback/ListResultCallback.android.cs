using System;
using Android.Runtime;
using Com.Adapty.Utils;
using Java.Util;
using Kotlin.Collections;

namespace XamarinAdaptySDK.AndroidCallback
{
    public class ListResultCallback<TNativeItem, TResultItem> : KotlinListCallbackWrapper<TResultItem?>, IResultCallback
        where TNativeItem : class, IJavaObject
    {
        private readonly Func<TNativeItem, TResultItem> _projection;

        public ListResultCallback(Func<TNativeItem, TResultItem> projection)
        {
            _projection = projection;
        }

        public void OnResult(Java.Lang.Object result)
        {
            HandleListResult(result, _projection);
        }
    }
}