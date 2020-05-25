using UnityEngine;

public class BasicWeaponData : MonoBehaviour, WeaponData
{
    public float cooldown;
    public int damage;
    public float Cooldown => cooldown;
    public int Damage => damage;
}