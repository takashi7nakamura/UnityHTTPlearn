using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // すべてのObstacleを消すメソッド
    public void DestroyAll()
    {
        GameObject[] taggedObjects;

        // シーン上にある全てのタグが"Obstacle"のオブジェクトを探す
        taggedObjects = GameObject.FindGameObjectsWithTag("Obstacle");

        // 見つかったすべての GameObject に対して
        for (int i = 0; i < taggedObjects.Length ; i++)
        {
            // GameObjectを Destroy する 
            Destroy(taggedObjects[i]);
        }
    }

    // コルーチンで一定時間ごとに障害物を生成する
    IEnumerator GenerateObstacles()
    {
        for (; ; )
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.GetComponent<Obstacle>().SetPosition(Random.Range(-6.5f, 6.5f), 6.5f);
            obstacle.GetComponent<Obstacle>().SetVelocity(0.0f+Random.Range(-1.5f,1.5f), -2.0f+Random.Range(-0.2f,0.2f));
            yield return new WaitForSeconds(0.3f);
        }
    }
}
