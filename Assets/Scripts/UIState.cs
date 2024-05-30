using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIState : MonoBehaviour
{
    public State health;
    public State stamina;

    private void Start()
    {
        CharacterManager.Instance.Player.state.uiState = this;
    }
}
