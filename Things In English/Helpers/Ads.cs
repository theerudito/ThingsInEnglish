using MarcTron.Plugin;

namespace ThingsInEnglish.Helpers
{
    public static class Ads
    {
        public static void ShowIntertiscal()
        {
            var idIntersticial = "ca-app-pub-7633493507240683/7190362096";

            CrossMTAdmob.Current.LoadInterstitial(idIntersticial);

            CrossMTAdmob.Current.ShowInterstitial();
        }

        public static bool IsIntertiscalLoaded()
        {
            return CrossMTAdmob.Current.IsInterstitialLoaded();
        }

        public static void ShowRewardedVideo()
        {
            var idVideo = "ca-app-pub-7633493507240683/3984262527";

            CrossMTAdmob.Current.LoadRewardedVideo(idVideo);

            CrossMTAdmob.Current.ShowRewardedVideo();
        }

        public static bool IsVideoLoaded()
        {
            return CrossMTAdmob.Current.IsRewardedVideoLoaded();
        }
    }
}
