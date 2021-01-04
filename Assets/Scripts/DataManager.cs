using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    private int value;

    EasyFileSave myFile;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProceses();
        }
        else
        {
            Destroy(gameObject);  
        }
        DontDestroyOnLoad(gameObject);
    }
    

 
    void Update()
    {
        
    }
    
    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = " SHOT BULLET : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = " ENEMY KILLED : " + enemyKilled.ToString();

        }
    }
    void StartProceses()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalenemyKilled", totalEnemyKilled);

        myFile.Save();
    }
    public void LoadData()
    {
        if (myFile.Load()
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }
}
