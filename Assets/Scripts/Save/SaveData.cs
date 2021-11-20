using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    public int plant;
    public int health;
    public float playerPositionX;
    public float playerPositionY;

    public List<float> enemyPositionX=new List<float>();
    public List<float> enemyPositionY = new List<float>();
    public List<float> enemyMaxHp = new List<float>();
    public List<float> enemyHp=new List<float>();
    public List<int> enemyDamage = new List<int>();
    public List<bool> enemyIsDead = new List<bool>();

    public List<bool> plantIsCollected=new List<bool>();
}
