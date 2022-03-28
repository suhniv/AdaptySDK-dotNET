using System.Collections.Generic;
using System.Linq;
using Com.Adapty.Api;
using Com.Adapty.Api.Entity.Containers;
using Java.Interop;
using Java.Util;
using Kotlin;
using Kotlin.Jvm.Functions;
using Object = Java.Lang.Object;
using Product = Plugin.Adapty.Models.Product;

namespace Plugin.Adapty.Android.Callback
{
    public class GetProductsCallback : KotlinCallbackWrapper<Product[]?>, IAdaptyPaywallsCallback, IFunction4
    {
        public Object Invoke(Object p0, Object p1, Object p2, Object? p3)
        {
            OnResult(p0.JavaCast<ArrayList>()?.ToEnumerable<DataContainer>()?.ToList(),
                p1.JavaCast<ArrayList>()?.ToEnumerable<Com.Adapty.Api.Entity.Containers.Product>()?.ToList(),
                p3?.ToString());

            return Unit.Instance;
        }

        public void OnResult(IList<DataContainer>? containers, IList<Com.Adapty.Api.Entity.Containers.Product>? products, string? error)
        {
            if (products != null && products.Any())
            {
                OnResult(products.Select(p => p.ConvertProduct()).ToArray());
            }
            else
            {
                OnResult(null);
            }
        }
    }
}
