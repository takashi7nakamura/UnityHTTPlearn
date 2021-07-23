using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 画面外に消えたらオブジェクトを破棄する
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        // Debug.Log("Obstacle Destroyed");
    }

    // オブジェクトの位置を設定するメソッド
    public void SetPosition(float x, float y)
    {
        Vector3 pos = new Vector3(x, y, 0);
        transform.position = pos;
    }

    // オブジェクトの速度設定するメソッド
    public void SetVelocity(float vx, float vy)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
}
