namespace Plugin.Adapty
{
    public partial class CrossAdapty
    {
        public static ICrossAdapty Instance { get; }
#if IOS || ANDROID
            = new CrossAdapty();
#endif
    }
}
