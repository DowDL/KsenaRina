using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
   
    public List<GameObject> Donuts = new List<GameObject>();

    private int Donuts_count = 1;
    public float Length = 1.0f;
    public float Width = 1.0f;
    public float Height = 1.0f;
    public float TimeLeft = 60.0f;
    public float Delay = 1f;
    public float Timer;

   
    void Update()
    {
        if (Timer <= 0)
        {
            SpawnObjectAtRandom(Donuts[Random.Range(0, Donuts.Count)]);
            Timer = Delay;
        }
        Timer -= Time.deltaTime;

        return;
       
    }

    void SpawnObjectAtRandom(GameObject donut)
    {

        Vector3 randomPos = new Vector3(
                   (Random.value - 0.5f) * Length,
                   (Random.value - 0.5f) * Height,
                   (Random.value - 0.5f) * Width
                   );

        Instantiate(donut, this.transform.position + randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 size = new Vector3(Length, Height, Width);

        Gizmos.DrawWireCube(this.transform.position, size);
    }
}
