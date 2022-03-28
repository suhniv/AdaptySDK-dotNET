using Com.Adapty.Errors;
using Java.Interop;
using Java.Lang;
using XamarinAdaptySDK.Exceptions;

namespace XamarinAdaptySDK
{
    public static class UtilsAndroid
    {
        /// <summary>
        /// Converts AdaptyError to AdaptySdkException
        /// </summary>
        public static AdaptySdkException? ToException(this Object? error)
        {
            if (error?.JavaCast<AdaptyError>() is { } adaptyError)
            {
                return new AdaptySdkException(adaptyError.Message ?? "");
            }

            return null;
        }
    }
}