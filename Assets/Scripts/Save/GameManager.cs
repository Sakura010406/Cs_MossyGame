using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isLoad;

    private CharaController player;
    private PlayerHealth playerHealth;
    private List<Enemy> enemies;
    private List<Plant> plants;

    // Start is called before the first frame update
    private void Awake()
    {
        
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<CharaController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemies = FindObjectsOfType<Enemy>().ToList();
        plants = FindObjectsOfType<Plant>().ToList();
        Debug.Log(isLoad);
        Debug.Log(plants.Count);
        
        if (isLoad)
        {
            Debug.Log("sudato");
            LoadByDeserialization();
        }
    }
    private void LoadByDeserialization()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.text"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/Data.text", FileMode.Open);
            SaveData save = bf.Deserialize(fileStream) as SaveData;
            fileStream.Close();
            playerHealth.health = save.health;
            player.plant = save.plant;
            player.transform.position = new Vector2(save.playerPositionX, save.playerPositionY);
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].transform.position = new Vector2(save.enemyPositionX[i], save.enemyPositionY[i]);
                enemies[i].maxHp = save.enemyMaxHp[i];
                enemies[i].hp = save.enemyHp[i];
                enemies[i].damage = save.enemyDamage[i];
                enemies[i].isDead = save.enemyIsDead[i];
                enemies[i].Reload(enemies[i].isDead);
            }
            for (int i = 0; i < plants.Count; i++)
            {
                plants[i].isCollected = save.plantIsCollected[i];
                plants[i].Reload(plants[i].isCollected);
            }
        }
        else
            Debug.LogError("NO SAVE EXISTS!");
    }
}
