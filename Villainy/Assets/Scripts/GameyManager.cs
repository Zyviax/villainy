using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameyManager : MonoBehaviour
{
    public static int levelResources = 0;
    public static float levelMana = 0;

    public enum GameState
    {
        Tutorial,
        Queue,
        Play,
        End
    }

    public static GameState gameState;

    public static List<Transform> spawnedEnemies = new List<Transform>();
}
