using Com.Adapty.Errors;
using Com.Adapty.Utils;
using Java.Interop;

namespace XamarinAdaptySDK.AndroidCallback
{
    public class VoidCallback : KotlinCallbackWrapper<bool>, IErrorCallback
    {
        public void OnError(AdaptyError? result)
        {
            if (result != null && result.JavaCast<AdaptyError>() is { } adaptyError)
            {
                SetException(adaptyError.InnerException);
            }
        }
    }
}