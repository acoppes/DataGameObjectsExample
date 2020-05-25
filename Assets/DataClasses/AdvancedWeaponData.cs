using UnityEngine;

public class AdvancedWeaponData : MonoBehaviour, WeaponData
{
    public float cooldown;
    public int damage;
    public int level = 1;
    
    public float Cooldown => cooldown;

    public int Damage => damage * level;
}