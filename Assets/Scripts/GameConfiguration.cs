using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameConfiguration", fileName ="GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    // Player
    public int lives;
    public Vector3 playerPosition;
    public float gunRange;
    public float playerSpeed;
    public float playerRotationSpeed;
    public float playerMinVert;
    public float playerMaxVert;

    // Enemy
    public float enemyFollowRange;
    public float enemyAttackRate;
}
