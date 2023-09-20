using Sirenix.OdinInspector;
using UnityEngine;
using VirtueSky.Core;
using VirtueSky.Misc;

public class Config : BaseMono
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private DailyRewardConfig dailyRewardConfig;
    [SerializeField] private CountryConfig countryConfig;
    [SerializeField] private ItemConfig itemConfig;

    public static GameConfig Game;
    public static DailyRewardConfig DailyRewardConfig;
    public static CountryConfig CountryConfig;
    public static ItemConfig ItemConfig;

    protected void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Game = gameConfig;
        DailyRewardConfig = dailyRewardConfig;
        CountryConfig = countryConfig;
        ItemConfig = itemConfig;
    }

    public override void Initialize()
    {
        base.Initialize();
        ItemConfig.Initialize();
    }

#if UNITY_EDITOR
    [Button]
    private void Load()
    {
        string path = "Assets/_Project/Config/";
        gameConfig = GetFile.GetConfigFromFolder<GameConfig>(path);
        dailyRewardConfig = GetFile.GetConfigFromFolder<DailyRewardConfig>(path);
        countryConfig = GetFile.GetConfigFromFolder<CountryConfig>(path);
        itemConfig = GetFile.GetConfigFromFolder<ItemConfig>(path);
    }
#endif
}