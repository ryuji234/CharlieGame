using UnityEngine;

public class Ringspawn : MonoBehaviour
{
    public GameObject Ringspawner;
    public GameObject RingPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 1f;


    private float spawnRate;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);


    }

    // Update is called once per frame
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            var Ring = BigRingPool.GetObject(); // ¼öÁ¤
            if (Camera.main.transform.localPosition.x < 140)
            {

                Ring.transform.position = transform.position;
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
            else
            {
                BigRingPool.ReturnObject(Ring);
            }


        }

    }
}
