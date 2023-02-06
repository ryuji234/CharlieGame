using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySpawn : MonoBehaviour
{
    public GameObject Monkeyspawner;
    public GameObject MonkeyPrefab;
    public GameObject BlueMonkeyPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 1f;

    private int Count;
    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        Count = 0;

    }

    // Update is called once per frame
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            var Ring = MonkeyPool.GetObject(); // ¼öÁ¤
            if (Camera.main.transform.localPosition.x < 140)
            {

                Ring.transform.position = transform.position;
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                if(Count <3)
                {
                    Count++;
                }
                else
                {
                    Invoke("BlueMonkeyCall",1.5f);
                    Count= 0;
                }
            }
            else
            {
                MonkeyPool.ReturnObject(Ring);
            }


        }

    }
    private void BlueMonkeyCall()
    {
        var Ring = BlueMonkeyPool.GetObject();
        if (Camera.main.transform.localPosition.x < 140)
        {

            Ring.transform.position = transform.position;
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            
        }
        else
        {
            BlueMonkeyPool.ReturnObject(Ring);
        }
        CancelInvoke();
    }
}
