using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private CharaController player;
    private PlayerHealth playerHealth;
    private List<Enemy> enemies;
    private List<Plant> plants;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharaController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemies = FindObjectsOfType<Enemy>().ToList();
        plants = FindObjectsOfType<Plant>().ToList();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu")
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1;
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void MainMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private SaveData createSaveData()
    {
        SaveData save = new SaveData();

        save.health = playerHealth.health;
        save.plant = player.plant;
        save.playerPositionX = player.transform.position.x;
        save.playerPositionY = player.transform.position.y;
        foreach(var e in enemies)
        {
            Debug.Log("jinlaile");
            save.enemyPositionX.Add(e.transform.position.x);
            save.enemyPositionY.Add(e.transform.position.y);
            save.enemyMaxHp.Add(e.maxHp);
            save.enemyHp.Add(e.hp);
            save.enemyDamage.Add(e.damage);
            save.enemyIsDead.Add(e.isDead);
        }
        foreach(var p in plants)
        {
            save.plantIsCollected.Add(p.isCollected);
        }

        return save;
    }
    public void SaveGame()
    {
        SaveBySerialization();
        Resume();
    }
    public void LoadGame()
    {
        LoadByDeserialization();
        Resume();
    }
    private void SaveBySerialization()
    {
        SaveData save = createSaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/Data.text");
        bf.Serialize(fileStream, save);
        fileStream.Close();
        
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
