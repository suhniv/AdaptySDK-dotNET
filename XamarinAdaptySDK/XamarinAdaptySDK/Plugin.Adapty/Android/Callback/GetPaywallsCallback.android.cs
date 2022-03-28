using System.Collections.Generic;
using System.Linq;
using Com.Adapty.Api;
using Com.Adapty.Api.Entity.Containers;
using Java.Interop;
using Java.Util;
using Kotlin;
using Kotlin.Jvm.Functions;
using Object = Java.Lang.Object;
using Paywall = Plugin.Adapty.Models.Paywall;

namespace Plugin.Adapty.Android.Callback
{
    public class GetPaywallsCallback : KotlinCallbackWrapper<Paywall[]?>, IAdaptyPaywallsCallback, IFunction4
    {
        public Object Invoke(Object p0, Object p1, Object p2, Object? p3)
        {
            OnResult(p0.JavaCast<ArrayList>()?.ToEnumerable<DataContainer>()?.ToList(),
                p1.JavaCast<ArrayList>()?.ToEnumerable<Product>()?.ToList(),
                p3?.ToString());

            return Unit.Instance;
        }

        public void OnResult(IList<DataContainer>? containers, IList<Product>? products, string? error)
        {
            if (containers != null && containers.Any())
            {
                OnResult(containers.Select(x => new Paywall
                {
                    Products = x.Attributes.Products.Select(p => p.ConvertProduct()).ToArray()
                }).ToArray());
            }
            else if (products != null && products.Any())
            {
                OnResult(new[]{new Paywall
                {
                    Products = products.Select(p=>p.ConvertProduct()).ToArray()
                }});
            }
            else
            {
                OnResult(null);
            }
        }
    }
}
