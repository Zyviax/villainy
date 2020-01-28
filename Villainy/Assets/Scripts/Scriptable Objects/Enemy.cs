using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float health, speed, damage, towerDamage, healCooldown, healRadii, healAmount;
    [SerializeField]
    private int unitCost;
    [SerializeField]
    private bool attackTowers, isHealer;

    public float Health { get { return health; } set {; } }
    public float Speed { get { return speed; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float TowerDamage { get { return towerDamage; } set {; } }
    public float HealCooldown { get { return healCooldown; } set {; } }
    public float HealRadii { get { return healRadii; } set {; } }
    public float HealAmount { get { return healAmount; } set {; } }

    public int UnitCost { get { return unitCost; } set {; } }

    public bool AttackTowers { get { return attackTowers; } set {; } }
    public bool IsHealer { get { return isHealer; } set {; } }

    public string enemyName;
}
