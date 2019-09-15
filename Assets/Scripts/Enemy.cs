using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 10;
    private Transform[] transforms;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        transforms = WayPoints.positions;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (index > (transforms.Length - 1)) return;
        transform.Translate((transforms[index].position - transform.position).normalized * Time.deltaTime * speed);
        if(Vector3.Distance(transform.position,transforms[index].position) < 0.2f )
        {
            index++;
        }
        if(index > transforms.Length - 1)
        {
            ReachDestination();
        }
    }
    void ReachDestination()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        WaveSpawner.countEnemyAlive--;
    }
}
