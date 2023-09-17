using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using VirtueSky.Core;
using Random = UnityEngine.Random;


public class VisualEffectsManager : BaseMono
{
    public List<VisualEffectData> visualEffectDatas;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        pools.Initialize();
    }

    public VisualEffectData GetVisualEffectDataByType(VisualEffectType visualEffectType)
    {
        return visualEffectDatas.Find(item => item.visualEffectType == visualEffectType);
    }

    public void SpawnEffect()
    {
        // VisualEffectData visualEffectData = GetVisualEffectDataByType(data.visualEffectType);
        // if (visualEffectData != null)
        // {
        //     GameObject randomEffect = visualEffectData.GetRandomEffect();
        //     GameObject effect = Instantiate(randomEffect, data.parent, false);
        //     effect.transform.position = data.position;
        //     effect.transform.localScale = data.localScale;
        //     if (data.isDestroyedOnEnd) Destroy(effect, data.timeDestroy);
        // }
    }

    private bool IsItemExistedByVisualEffectType(VisualEffectType visualEffectType)
    {
        foreach (VisualEffectData item in visualEffectDatas)
        {
            if (item.visualEffectType == visualEffectType)
            {
                return true;
            }
        }

        return false;
    }

    [Button]
    public void UpdateVisualEffects()
    {
        for (int i = 0; i < Enum.GetNames(typeof(VisualEffectType)).Length; i++)
        {
            VisualEffectData visualEffectData = new VisualEffectData();
            visualEffectData.visualEffectType = (VisualEffectType)i;
            if (IsItemExistedByVisualEffectType(visualEffectData.visualEffectType)) continue;
            visualEffectDatas.Add(visualEffectData);
        }

        visualEffectDatas = visualEffectDatas.GroupBy(elem => elem.visualEffectType).Select(group => group.First())
            .ToList();
    }
}

[Serializable]
public class VisualEffectData
{
    public List<GameObject> effectList;
    public VisualEffectType visualEffectType;

    public GameObject GetRandomEffect()
    {
        return effectList[Random.Range(0, effectList.Count)];
    }
}

public enum VisualEffectType
{
    Default,
}