using System.Threading.Tasks;

namespace Plugin.Adapty.Android.Callback
{
    public abstract class KotlinCallbackWrapper<T> : Java.Lang.Object
    {
        private readonly TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();

        public readonly Task<T> CallbackTask;

        protected KotlinCallbackWrapper() => CallbackTask = _tcs.Task;
        protected void OnResult(T result) => _tcs.TrySetResult(result);
    }
}
