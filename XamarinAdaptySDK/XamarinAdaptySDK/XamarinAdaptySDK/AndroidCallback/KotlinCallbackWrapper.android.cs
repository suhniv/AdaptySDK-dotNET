using System;
using System.Threading.Tasks;

namespace XamarinAdaptySDK.AndroidCallback
{
    public abstract class KotlinCallbackWrapper<T> : Java.Lang.Object
    {
        private readonly TaskCompletionSource<T> _tcs = new();

        public readonly Task<T> Task;

        protected KotlinCallbackWrapper() => Task = _tcs.Task;
        protected void OnResult(T result) => _tcs.TrySetResult(result);
        protected void OnException(Exception ex) => _tcs.TrySetException(ex);
    }
}