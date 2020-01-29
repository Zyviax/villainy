using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float health, speed, damage, healCooldown, healRadii, healAmount, speedAmount;
    [SerializeField]
    private int unitCost;
    [SerializeField]
    private bool isHealer, isSpeeder;

    public float Health { get { return health; } set {; } }
    public float Speed { get { return speed; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float HealCooldown { get { return healCooldown; } set {; } }
    public float HealRadii { get { return healRadii; } set {; } }
    public float HealAmount { get { return healAmount; } set {; } }
    public float SpeedAmount { get { return speedAmount; } set{; } }

    public int UnitCost { get { return unitCost; } set {; } }

    public bool IsHealer { get { return isHealer; } set {; } }
    public bool IsSpeeder { get { return isSpeeder; } set {; } }

    public string enemyName;
}
