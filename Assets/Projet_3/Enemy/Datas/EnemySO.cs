using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "AnnieStudio/EnemyData", order = 1)]
public class EnemySO : ScriptableObject
{
    public string name = "PatrolEnemy";
    public int damage = 0;
}
