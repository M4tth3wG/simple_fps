using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameConfiguration", fileName ="GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    [Header("Player")]
    public int lives;
    public Vector3 playerPosition;
    public float gunRange;
    public float playerSpeed;
    public float playerRotationSpeed;
    public float minPlayerRotationSpeed;
    public float maxPlayerRotationSpeed;
    public float playerMinVert;
    public float playerMaxVert;

    [Header("Enemy")]
    public float enemyFollowRange;
    public float enemyAttackRate;

    [Header("Volume")]
    public float volume;
}
