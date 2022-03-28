namespace XamarinAdaptySDK
{
    public partial class Adapty
    {
        public static ICrossAdapty Instance { get; }
#if IOS || ANDROID
            = new Adapty();
#endif
    }
}
