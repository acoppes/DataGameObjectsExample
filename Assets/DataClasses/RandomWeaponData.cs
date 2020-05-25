using UnityEngine;

public class RandomWeaponData : MonoBehaviour, WeaponData
{
    public float cooldown;

    public int minDamage;
    public int maxDamage;
    
    public float Cooldown => cooldown;

    public int Damage => Random.Range(minDamage, maxDamage);
}