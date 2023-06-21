using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Com.Adapty.Utils;
using Java.Interop;
using Java.Lang;
using Exception = System.Exception;
using IJavaObject = Android.Runtime.IJavaObject;

namespace XamarinAdaptySDK.AndroidCallback
{
    public abstract class KotlinListCallbackWrapper<T> : KotlinCallbackWrapper<List<T>>
    {
        protected void HandleListResult<TNativeItem>(Java.Lang.Object result, Func<TNativeItem, T> projection) where TNativeItem : class, IJavaObject
        {
            try
            {
                if (result.JavaCast<AdaptyResult.Success>().Value.JavaCast<IIterable>() is { } nativeIterable )
                {
                    var list = new List<T>();
                    var iterator = nativeIterable.Iterator();

                    while (iterator.HasNext)
                    {
                        list.Add(projection(iterator.Next().JavaCast<TNativeItem>()));
                    }
                    
                    SetResult(list);
                }
            }
            catch (Exception e)
            {
                SetException(e);
                // if (result?.JavaCast<AdaptyResult.Error>()?.GetError() is { } adaptyError)
                // {
                //     SetException(adaptyError);
                // }
                // else
                // {
                //     SetException(e);
                // }
            }
        }
    }
    
    public abstract class KotlinCallbackWrapper<T> : Java.Lang.Object
    {
        private readonly TaskCompletionSource<T> _tcs = new();

        public readonly Task<T> Task;

        protected KotlinCallbackWrapper() => Task = _tcs.Task;
        protected void SetResult(T result) => _tcs.TrySetResult(result);
        protected void SetException(Exception ex) => _tcs.TrySetException(ex);

        protected void HandleResult<TNativeResult>(Java.Lang.Object result, Func<TNativeResult, T> projection) where TNativeResult : class, IJavaObject
        {
            try
            {
                if (result.JavaCast<AdaptyResult.Success>().Value.JavaCast<TNativeResult>() is { } nativeResult )
                {
                    SetResult(projection(nativeResult));
                }
            }
            catch (Exception e)
            {
                if (result?.JavaCast<AdaptyResult.Error>()?.GetError() is { } adaptyError)
                {
                    SetException(adaptyError);
                }
                else
                {
                    SetException(e);
                }
            }
        }

        public TaskAwaiter<T> GetAwaiter() => Task.GetAwaiter();
    }
}