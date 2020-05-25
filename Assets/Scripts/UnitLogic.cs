using System.Collections.Generic;
using UnityEngine;

public class UnitLogic : MonoBehaviour
{
    public int player;

    public GameObject dataGameObject;

    private static readonly List<UnitLogic> unitsInWorld = new List<UnitLogic>();
    
    private int currentHealth;
    
    private HealthData health;
    private WeaponData[] weapons;

    private float[] weaponsCooldown;
    
    private void Start()
    {
        health = dataGameObject.GetComponentInChildren<HealthData>();
        weapons = dataGameObject.GetComponentsInChildren<WeaponData>();

        if (health != null)
            currentHealth = health.health;
        
        weaponsCooldown = new float[weapons.Length];
    }

    private void OnEnable()
    {
        unitsInWorld.Add(this);
    }

    private void OnDisable()
    {
        unitsInWorld.Remove(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        for (var i = 0; i < weaponsCooldown.Length; i++)
        {
            weaponsCooldown[i] += Time.deltaTime;
        }

        foreach (var target in unitsInWorld)
        {
            if (target == this)
                continue;

            if (target.player == player)
                continue;

            for (var i = 0; i < weapons.Length; i++)
            {
                var weapon = weapons[i];
                if (weaponsCooldown[i] >= weapon.Cooldown)
                {
                    target.currentHealth -= weapon.Damage;
                    weaponsCooldown[i] = 0;
                }
            }
        }
    }
}
