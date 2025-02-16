using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public List<EnemyWave> enemies = new List<EnemyWave>();
    public List<Enemy> spawnedEnemies = new List<Enemy>();
    public List<string> ListOfWords = new List<string>();
    public string filePath = "Assets/Assets/text/fonts";
    public StructreController structreController;
    private int CurrentWave = 0;
    private Coroutine currentWaveCoroutine;

    private void OnEnable()
    {
        structreController.OnrepairStarted += StartRound;
    }
    private void OnDisable()
    {
        structreController.OnrepairStarted -= StartRound;

    }
    private void StartRound()
    {
        LoadTextFile();
        currentWaveCoroutine = StartCoroutine(PlayRound());
    }
    void LoadTextFile()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            ListOfWords.AddRange(lines);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

   
    public void SpawnEneamy()
    {
        if (enemies[CurrentWave].enemycount > 0 && spawnedEnemies.Count < enemies[CurrentWave].maxEnemies)
        {
          GameObject enemy =  Instantiate(enemies[CurrentWave].enemys[Random.Range(0, 2)],transform.position, Quaternion.identity);
          enemy.GetComponent<Enemy>().Iniatalize(ListOfWords[Random.Range(0, ListOfWords.Count)], structreController);
          spawnedEnemies.Add(enemy.GetComponent<Enemy>());
          enemy.GetComponent<Enemy>().OnDeath += OnOnDeath;
          
        }
        
    }

    private void OnOnDeath(Enemy enemy)
    {
        if(!spawnedEnemies.Contains(enemy))
            return;

        spawnedEnemies.Remove(enemy);
            
        enemy.GetComponent<Enemy>().OnDeath -= OnOnDeath;

        enemies[CurrentWave].enemycount--;
    }

    public IEnumerator PlayRound()
    {

        while (enemies[CurrentWave].enemycount > 0  )
        {

            SpawnEneamy();
            yield return new WaitForSeconds(Random.Range(1f, 3.5f));
        }
        
        
        yield return new WaitForSeconds(1f);
        CurrentWave++;
        currentWaveCoroutine = StartCoroutine(PlayRound());
    }
}

[System.Serializable]
public class EnemyWave
{
    public string name; 
    public int enemycount;
    public int maxEnemies;
    public GameObject[] enemys;
}