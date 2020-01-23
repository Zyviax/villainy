using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float health, speed, damage, towerDamage, attackCooldown;
    [SerializeField]
    private int unitCost;
    [SerializeField]
    private bool attackTowers;

    public float Health { get { return health; } set {; } }
    public float Speed { get { return speed; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float TowerDamage { get { return towerDamage; } set {; } }
    public float AttackCooldown { get { return attackCooldown; } set {; } }

    public int UnitCost { get { return unitCost; } set {; } }

    public bool AttackTowers { get { return attackTowers; } set {; } }

    public string enemyName;
}
