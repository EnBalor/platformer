using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface Interactable
{
    public string GetInteractPrompt();
    public void OnInterract();
}

public class OnFieldObject : MonoBehaviour, Interactable
{
    public ItemData data;
    private PlayerState playerState;

    private void Start()
    {
        playerState = CharacterManager.Instance.Player.state;
    }

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInterract()
    {
        if(data.type == ItemType.Buff)
        {
            for(int i = 0; i < data.buff.Length; i++)
            {
                switch(data.buff[i].type)
                {
                    case BuffType.AddSpeed:
                        playerState.TakeBuff(data.buff[i].value, data.buff[i].duration);
                        break;
                }
            }
        }
    }
}
