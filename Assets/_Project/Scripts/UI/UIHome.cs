using UnityEngine;
using VirtueSky.Events;

public class UIHome : MonoBehaviour
{
    [SerializeField] private PopupVariable popupVariable;

    public void OnClickSetting()
    {
        popupVariable?.Value.Show<PopupSetting>();
    }

    public void OnClickDebug()
    {
        popupVariable?.Value.Show<PopupDebug>();
    }

    public void OnClickDailyReward()
    {
        popupVariable?.Value.Show<PopupDailyReward>();
    }

    public void OnClickShop()
    {
        popupVariable?.Value.Show<PopupShop>();
    }

    public void OnClickTest()
    {
        popupVariable?.Value.Show<PopupTest>();
    }
}