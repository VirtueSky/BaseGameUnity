using System;
using UnityEngine;
using VirtueSky.Ads;

namespace TheBeginning.AppControl
{
    public struct AppControlAds
    {
        private static AdsManager _adsManager;

        public static void Init(AdsManager adsManager)
        {
            if (_adsManager != null)
            {
                UnityEngine.Object.Destroy(_adsManager);
            }

            AppControlAds._adsManager = adsManager;
        }

        public static AdUnitVariable AdUnitBanner => _adsManager.AdUnitBanner;
        public static AdUnitVariable AdUnitInter => _adsManager.AdUnitInter;
        public static AdUnitVariable AdUnitReward => _adsManager.AdUnitReward;

        public static void ShowInterstitial(Action completeCallback = null, Action displayCallback = null)
        {
            if (_adsManager == null)
            {
                Debug.LogError("Please Init AppControlAds before use");
                return;
            }

            _adsManager.ShowInterstitial(completeCallback, displayCallback);
        }

        public static void ShowReward(Action completeCallback = null, Action skipCallback = null,
            Action displayCallback = null,
            Action closeCallback = null)
        {
            if (_adsManager == null)
            {
                Debug.LogError("Please Init AppControlAds before use");
                return;
            }

            _adsManager.ShowRewardAds(completeCallback, skipCallback, displayCallback, closeCallback);
        }

        public static void ShowBanner()
        {
            if (_adsManager == null)
            {
                Debug.LogError("Please Init AppControlAds before use");
                return;
            }

            _adsManager.ShowBanner();
        }

        public static void HideBanner()
        {
            if (_adsManager == null)
            {
                Debug.LogError("Please Init AppControlAds before use");
                return;
            }

            _adsManager.HideBanner();
        }

        public static bool IsRewardReady()
        {
            if (_adsManager == null)
            {
                Debug.LogError("Please Init AppControlAds before use");
                return false;
            }

            return _adsManager.IsRewardReady();
        }
    }
}