using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int countEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public int waveRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEneym());
    }

    

    IEnumerator SpawnEneym()
    {
        foreach (Wave wave in waves) {
            for(int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                countEnemyAlive ++;
                if(i != wave.count)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while (countEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
    }


}
