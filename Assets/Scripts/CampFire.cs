using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<Damagable> things = new List<Damagable>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    private void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Damagable damagable))
        {
            things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Damagable damagable))
        {
            things.Remove(damagable);
        }
    }
}
