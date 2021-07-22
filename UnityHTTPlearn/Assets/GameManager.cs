using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obstacleManager;
    public GameObject coinManager;

    public GameObject player;

    public GameObject clickStartText;

    public enum GAME_STATE
    {
        GAME_TITLE,  // タイトル画面
        GAME_GAME,   // ゲーム画面
        GAME_RESULT, // リザルト画面
    }

    private GAME_STATE state;

    // Start is called before the first frame update
    void Start()
    {
        InitTitleState();
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case GAME_STATE.GAME_TITLE:
                // マウスボタンが押されたら
                if (Input.GetMouseButtonDown(0))
                {
                    // ゲーム開始状態へ
                    InitGameState();
                }
                break;
            case GAME_STATE.GAME_GAME:
                if (player.activeSelf == false)
                {
                    InitResultState();
                }
                break;
            case GAME_STATE.GAME_RESULT:
                if (Input.GetMouseButtonDown(0))
                {
                    // ゲームステートへ
                    InitGameState();
                }
                break;
            default:
                break;
        }

    }

    // タイトル状態に入った時の初期化処理
    private void InitTitleState()
    {
        state = GAME_STATE.GAME_TITLE;

        InitGameObjects();
        // Click to Start表示をONにする
        clickStartText.SetActive(true);

        // Playerの表示はOFFにする
        player.SetActive(false);
        
    }

    // ゲーム状態に入った時の初期化処理
    private void InitGameState()
    {
        // Click to Start 表示をOFFにする
        clickStartText.SetActive(false);

        state = GAME_STATE.GAME_GAME;

        // Playerの位置は初期位置(0,0)に設定する
        player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // Player位置の表示を開始する
        player.SetActive(true);

        InitGameObjects();
    }

    // リザルト状態に入った時の初期化処理
    private void InitResultState()
    {
        state = GAME_STATE.GAME_RESULT;
    }

    private void InitGameObjects()
    {
        obstacleManager.GetComponent<ObstracleManager>().DestroyAll();
        coinManager.GetComponent<CoinManager>().DestroyAll();

    }

}
