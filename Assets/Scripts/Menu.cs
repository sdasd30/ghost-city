using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;

    GameObject player;

    string saveDirectory;

    bool paused = false;

    void Start()
    {
        saveDirectory = Application.persistentDataPath + "/Saves/";

        pauseMenu.SetActive(false);

        player = GameObject.Find("Player");

        if (Directory.Exists(saveDirectory))
        {
            string[] files = Directory.GetFiles(saveDirectory);

            if (files.Length > 0)
            {
                FileStream file = File.OpenRead(files[files.Length - 1]);

                BinaryFormatter bf = new BinaryFormatter();

                GameSave save = (GameSave)bf.Deserialize(file);

                player.GetComponent<HasHealthBar>().maxHealth = save.player.maxHealth;
                player.GetComponent<HasHealthBar>().currentHealth = save.player.health;
                player.GetComponent<HasHealthBar>().UpdateHealthBar();

                file.Close();
            }
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);

            paused = !paused;

            Time.timeScale = paused ? 0 : 1;
        }
    }

    public void Quit()
    {
        GameObject[] inventoryItems = player.GetComponent<Inventory>().inventory.ToArray();

        InteractableItemSave[] inventory = new InteractableItemSave[inventoryItems.Length];

        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = new InteractableItemSave();
        }

        PlayerSave playerSave = new PlayerSave();

        playerSave.inventory = inventory;
        playerSave.health = player.GetComponent<HasHealthBar>().currentHealth;
        playerSave.maxHealth = player.GetComponent<HasHealthBar>().maxHealth;

        GameSave save = new GameSave();

        save.player = playerSave;

        string path = saveDirectory + "save-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".txt";

        FileStream file;

        Directory.CreateDirectory(saveDirectory);

        if (File.Exists(path))
        {
            file = File.OpenWrite(path);
        }

        else
        {
            file = File.Create(path);
        }

        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(file, save);

        file.Close();
    }
}

[Serializable]
public class GameSave
{
    public PlayerSave player;
}

[Serializable]
public class PlayerSave
{
    public InteractableItemSave[] inventory;
    public int health;
    public int maxHealth;
}

[Serializable]
public class InteractableItemSave
{
    
}
