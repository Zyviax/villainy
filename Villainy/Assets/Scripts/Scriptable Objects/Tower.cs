using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Towers")]
public class Tower : ScriptableObject
{
    [SerializeField]
    private float firerate, damage, range;
    [SerializeField]
    private GameObject projectile;

    public float Firerate { get { return firerate; } set {; } }
    public float Damage { get { return damage; } set {; } }
    public float Range { get { return range; } set {; } }

    public GameObject Projectile { get { return projectile; } set {; } }

    public string towerName;
}
