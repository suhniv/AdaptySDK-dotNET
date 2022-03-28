using System.Linq;
using Com.Adapty.Models;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Kotlin;
using Kotlin.Jvm.Functions;
using XamarinAdaptySDK.Models;

namespace XamarinAdaptySDK.AndroidCallback
{
    public class GetPaywallsCallback : KotlinCallbackWrapper<Paywall[]?>, IFunction3
    {
        public Object Invoke(Object p0, Object p1, Object p2)
        {
            if (p2.ToException() is { } exception)
            {
                OnException(exception);
            }
            else
            {
                if (p0.JavaCast<ArrayList>().ToEnumerable<PaywallModel>()?.ToList() is { } paywalls && paywalls.Any())
                {
                    var paywallsProducts = paywalls
                        .Select(p => p.Products)
                        .SelectMany(p => p)
                        .ToArray();

                    if (paywallsProducts.Any() && paywallsProducts.All(p => p.SkuDetails != null))
                    {
                        var crossPaywalls = paywalls.Select(p => p.ToPaywall());

                        OnResult(crossPaywalls.ToArray());
                    }
                }
                else if (p1.JavaCast<ArrayList>().ToEnumerable<ProductModel>()?.ToList() is { } products &&
                         products.Any())
                {
                    //Here must be All but there is a bug in Adapty
                    //if (products.All(p => p.SkProduct != null))
                    if (products.Any(p => p.SkuDetails != null))
                    {
                        OnResult(new[]
                        {
                            new Paywall
                            {
                                Products = products.Select(p => p.ToProduct()).ToArray()
                            }
                        });
                    }
                }
                else
                {
                    OnResult(null);
                }
            }

            return Unit.Instance;
        }
    }
}