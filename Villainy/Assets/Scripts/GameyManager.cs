using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameyManager : MonoBehaviour
{
    public static int levelResources = 0;
    public static float levelMana = 0;

    public enum GameState
    {
        Menu,
        Tutorial,
        Queue,
        Play,
        End
    }

    public static GameState gameState;

    public static List<Transform> spawnedEnemies = new List<Transform>();

    public static int levelsCompleted = 0;
}
