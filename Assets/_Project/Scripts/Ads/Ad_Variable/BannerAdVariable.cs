using UnityEngine;
using VirtueSky.Ads;
using VirtueSky.Core;
using VirtueSky.Tracking;
using VirtueSky.Inspector;
using VirtueSky.Variables;

[CreateAssetMenu(menuName = "Ads Variable/Banner Variable", fileName = "banner_ad_variable")]
public class BannerAdVariable : AdVariable
{
    [SerializeField] private AdUnitVariable bannerVariable;
    [Space, SerializeField] private BooleanVariable isOffBannerVariable;

    [Space, HeaderLine("Firebase Remote Config"), SerializeField]
    private BooleanVariable remoteConfigOnOffBanner;

    public AdUnitVariable AdUnitBannerVariable => bannerVariable;

    public override void Init()
    {
    }

    bool Condition()
    {
        return bannerVariable.IsReady() && !isOffBannerVariable.Value && remoteConfigOnOffBanner.Value;
    }

    public void Show()
    {
        if (Condition())
        {
            bannerVariable.Show();
        }
    }

    public void Hide()
    {
        bannerVariable.HideBanner();
    }

    public AdUnitVariable ShowNoCondition()
    {
        return bannerVariable.Show();
    }

    public void Destroy()
    {
        bannerVariable.Destroy();
    }
}