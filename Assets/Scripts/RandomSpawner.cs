using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Donut_1;
    public GameObject Donut_2;
    public GameObject Donut_3;
    public GameObject Donut_4;
    private int Donuts_count = 1;
    public float Radius = 1.0f;
    public float TimeLeft = 60.0f;

    void Update()
    {
        if (TimeLeft >= 0)
        {
            switch (Donuts_count)
        {
            case 1:
                SpawnObjectAtRandom(Donut_1);
                break;
            case 2:
                SpawnObjectAtRandom(Donut_2);
                break;
            case 3:
                SpawnObjectAtRandom(Donut_3);
                break;
            case 4:
                {
                SpawnObjectAtRandom(Donut_4);
                Donuts_count = 0;
                }
                break;
        }
        TimeLeft -= Time.deltaTime;
            ++Donuts_count;
        } 
    }

    void SpawnObjectAtRandom(GameObject donut)
    {
        Vector3 randomPos = Random.insideUnitSphere * Radius;

        Instantiate(donut, this.transform.position + randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
