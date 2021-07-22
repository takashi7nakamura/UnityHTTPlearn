using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateCoins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateCoins()
    {
        for (; ; )
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.GetComponent<Coin>().SetPosition(Random.Range(-6.5f, 6.5f), 6.5f);
            coin.GetComponent<Coin>().SetVelocity(0.0f + Random.Range(-0.5f, 0.5f), -3.0f + Random.Range(-0.2f, 0.2f));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
