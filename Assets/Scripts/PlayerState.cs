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
    public UIState uiState;

    State health { get { return uiState.health; } }

    public State buff;

    public event Action onTakedamage;
    public event Action onTakeBuff;

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
