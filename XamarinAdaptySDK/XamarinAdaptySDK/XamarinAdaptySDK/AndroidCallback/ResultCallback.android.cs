using System;
using Android.Runtime;
using Com.Adapty.Utils;
using Object = Java.Lang.Object;

namespace XamarinAdaptySDK.AndroidCallback
{
    public class ResultCallback<TNativeResult, TResult> : KotlinCallbackWrapper<TResult?>, IResultCallback
        where TNativeResult : class, IJavaObject
    {
        private readonly Func<TNativeResult, TResult> _projection;

        public ResultCallback(Func<TNativeResult, TResult> projection)
        {
            _projection = projection;
        }

        public void OnResult(Object? result)
        {
            HandleResult(result, _projection);
        }
    }
}