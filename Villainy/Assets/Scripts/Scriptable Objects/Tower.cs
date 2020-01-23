using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Towers")]
public class Tower : ScriptableObject
{
    [SerializeField]
    private float fireCooldown, damage, range, health, aoeRadius;
    [SerializeField]
    private int targeting;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private bool destructable, aoe;

    public float FireCooldown { get { return fireCooldown; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float Range { get { return range; } set {; } }
    public float Health { get { return health; } set {; } }
    public float AoERadius { get { return aoeRadius; } set {; } }

    public int Targeting { get { return targeting; } set {; } }

    public GameObject Projectile { get { return projectile; } set {; } }

    public bool Destructable { get { return destructable; } set {; } }
    public bool AoE { get { return aoe; } set {; } }

    public string towerName;
}
