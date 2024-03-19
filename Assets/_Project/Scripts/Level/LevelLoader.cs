using UnityEngine;
using UnityEngine.AddressableAssets;
using VirtueSky.Core;
using VirtueSky.Inspector;
using VirtueSky.Threading.Tasks;
using VirtueSky.Variables;

[EditorIcon("icon_controller")]
public class LevelLoader : BaseMono
{
    [ReadOnly] [SerializeField] private Level currentLevel;
    [ReadOnly] [SerializeField] private Level previousLevel;
    [SerializeField] private IntegerVariable currentIndexLevel;
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private EventLoadLevel eventLoadLevel;
    [SerializeField] private EventGetCurrentLevel eventGetCurrentLevel;
    [SerializeField] private EventGetPreviousLevel eventGetPreviousLevel;

    public Level CurrentLevel() => currentLevel;
    public Level PreviousLevel() => previousLevel;

    public override void OnEnable()
    {
        base.OnEnable();
        eventLoadLevel.AddListener(LoadLevel);
        eventGetCurrentLevel.AddListener(CurrentLevel);
        eventGetPreviousLevel.AddListener(PreviousLevel);
    }

    private void Start()
    {
        var instance = LoadLevel();
    }

    public async UniTask<Level> LoadLevel()
    {
        int index = HandleIndexLevel(currentIndexLevel.Value);
        var result = await Addressables.LoadAssetAsync<GameObject>($"{gameConfig.keyLoadLevel} {index}");
        if (currentLevel != null)
        {
            previousLevel = currentLevel;
        }
        else
        {
            int indexPrev = HandleIndexLevel(currentIndexLevel.Value - 1);
            var resultPre = await Addressables.LoadAssetAsync<GameObject>($"{gameConfig.keyLoadLevel} {indexPrev}");
            previousLevel = resultPre.GetComponent<Level>();
        }

        currentLevel = result.GetComponent<Level>();
        return currentLevel;
    }

    int HandleIndexLevel(int indexLevel)
    {
        if (indexLevel > gameConfig.maxLevel)
        {
            return (indexLevel - gameConfig.startLoopLevel) %
                   (gameConfig.maxLevel - gameConfig.startLoopLevel + 1) +
                   gameConfig.startLoopLevel;
        }

        if (indexLevel > 0 && indexLevel < gameConfig.maxLevel)
        {
            if (gameConfig.levelNextType == LevelNextType.NormalNext)
            {
                return (indexLevel - 1) % gameConfig.maxLevel + 1;
            }

            if (gameConfig.levelNextType == LevelNextType.RandomNext)
            {
                return UnityEngine.Random.Range(gameConfig.startLoopLevel, gameConfig.maxLevel);
            }
        }

        if (indexLevel == 0)
        {
            return gameConfig.maxLevel;
        }

        return 1;
    }

    public void ActiveCurrentLevel(bool active)
    {
        currentLevel.gameObject.SetActive(active);
    }
}