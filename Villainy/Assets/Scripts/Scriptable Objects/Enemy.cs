using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private float health, speed;

    public float Health { get { return health; } set {; } }
    public float Speed { get { return speed; } set {; } }

    public string enemyName;
}
