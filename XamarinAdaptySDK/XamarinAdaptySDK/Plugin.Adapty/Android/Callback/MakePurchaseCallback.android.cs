using Android.BillingClient.Api;
using Com.Adapty.Api;
using Kotlin.Jvm.Functions;
using Kotlin;
using Plugin.Adapty.Models;
using Object = Java.Lang.Object;
using Com.Adapty.Api.Responses;

namespace Plugin.Adapty.Android.Callback
{
    public class MakePurchaseCallback : KotlinCallbackWrapper<PurchaserInfo?>, IAdaptyPurchaseCallback, IFunction3
    {
        public Object Invoke(Object? p0, Object? p1, Object? p2)
        {
            OnResult(null, null, null);
            //OnResult(p0?.JavaCast<Purchase>()!, p1?.JavaCast<ValidateReceiptResponse>()!, p2?.ToString()!);

            return Unit.Instance;
        }

        public void OnResult(Purchase? purchase, ValidateReceiptResponse? response, string? error)
        {
            OnResult(new PurchaserInfo());
        }
    }
}
