using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Towers")]
public class Tower : ScriptableObject
{
    [SerializeField]
    private float firerate, damage, range, health;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private bool destructable;

    public float Firerate { get { return firerate; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float Range { get { return range; } set {; } }
    public float Health { get { return health; } set {; } }

    public GameObject Projectile { get { return projectile; } set {; } }

    public bool Destructable { get { return destructable; } set {; } }

    public string towerName;
}
