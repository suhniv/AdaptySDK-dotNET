using Java.Lang;
using Kotlin;
using Kotlin.Jvm.Functions;

namespace XamarinAdaptySDK.AndroidCallback
{
    public class VoidCallback : KotlinCallbackWrapper<bool>, IFunction1
    {
        public Object Invoke(Object p0)
        {
            if (p0.ToException() is { } exception)
            {
                OnException(exception);
            }
            else
            {
                OnResult(true);
            }

            return Unit.Instance;
        }
    }
}