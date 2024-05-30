using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip,
    Consum,
    Resorce,
    Buff
}

public enum ConsumType
{
    Health
}

public enum BuffType
{
    AddSpeed,
}

[System.Serializable]
public class ItemDataConsum
{
    public ConsumType type;
    public float value;
}

[System.Serializable]
public class ItemDataBuff
{
    public BuffType type;
    public float value;
    public float duration;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Staking")]
    public bool canStack;
    public int maxStackSize;

    [Header("Consum")]
    public ItemDataConsum[] consum;

    [Header("Buff")]
    public ItemDataBuff[] buff;
}
