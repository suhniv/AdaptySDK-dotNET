using Com.Adapty.Api;
using Com.Adapty.Api.Responses;
using Kotlin;
using Kotlin.Jvm.Functions;
using Object = Java.Lang.Object;

namespace Plugin.Adapty.Android.Callback
{
    public class RestorePurchasesCallback : KotlinCallbackWrapper<bool>, IAdaptyRestoreCallback, IFunction2
    {
        public Object Invoke(Object? p0, Object? p1)
        {
            OnResult(p0 as RestoreReceiptResponse, p1?.ToString());

            return Unit.Instance;
        }

        public void OnResult(RestoreReceiptResponse? response, string? error)
        {
            OnResult(string.IsNullOrEmpty(error));
        }
    }
}
