using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Damagable
{
    void TakeDamage(int damage);
}
public class PlayerState : MonoBehaviour, Damagable
{
    public float staminaRate;

    public UIState uiState;

    State health { get { return uiState.health; } }
    State stamina { get { return uiState.stamina; } }

    public State buff;

    public event Action onTakedamage;
    public event Action onLoseStamina;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("»ç¸Á");
    }

    public void TakeDamage(int damage)
    {
        health.Substract(damage);
        onTakedamage?.Invoke();
    }

    public void LoseStamina()
    {
        if(CharacterManager.Instance.Player.controller.isDash == true)
        {
            stamina.Substract(staminaRate);
            onLoseStamina?.Invoke();
        }
    }

    public void TakeBuff(float speed, float duration)
    {
        StartCoroutine(SpeedBuffCoroutine(speed, duration));
    }

    private IEnumerator SpeedBuffCoroutine(float speed, float duration)
    {
        CharacterManager.Instance.Player.controller.moveSpeed += speed;
        yield return new WaitForSeconds(duration);
        CharacterManager.Instance.Player.controller.moveSpeed -= speed;
    }
}
