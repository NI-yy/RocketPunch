using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;

    public GameObject GameDirector;
    public GameObject RangeManager;
    public int EnemyCount;
    public int nowLevel;

    private bool timeIsUpFlag = false;

    Vector3 range_lower;
    Vector3 range_upper;

    System.Action[] generateFuncs;

    private void Start()
    {
        EnemyCount = -1;
        GenerateFuncSet();
        generateFuncs[nowLevel]();
    }

    private void Update()
    {
        if(nowLevel != 0 && (!timeIsUpFlag))
        {
            if (EnemyCount == 0) //全ての的が壊されたら
            {
                GameDirector.GetComponent<GameDirector>().AllEnemyIsBreaked();
            }
        }
        
    }

    public void TimeIsUp()
    {
        timeIsUpFlag = true;
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("EnemyCube");

        foreach (GameObject enemy in Enemys)
        {
            Destroy(enemy);
        }
    }

    public void GenerateFuncSet()
    {
        generateFuncs = new System.Action[5];
        generateFuncs[0] = TitleGenerate;
        generateFuncs[1] = Level1Generate;
        generateFuncs[2] = Level2Generate;
        generateFuncs[3] = Level3Generate;
        generateFuncs[4] = Level4Generate;
    }

    void TitleGenerate()
    {
        range_lower = RangeManager.GetComponent<RangeManager>().range_lower;
        range_upper = RangeManager.GetComponent<RangeManager>().range_upper;
        Debug.Log(range_lower);
        Debug.Log(range_upper);
        EnemyCount = 20;

        int i;
        for (i = 0; i < EnemyCount; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x, range_upper.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
    }

    void Level1Generate()
    {
        EnemyCount = 1;
        // GameObjectを1個だけ生成
        GameObject enemyObject = Instantiate(createPrefab, new Vector3(0, 2.0f, 7.0f), createPrefab.transform.rotation);
        enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
    }

    void Level2Generate()
    {
        range_lower = RangeManager.GetComponent<RangeManager>().range_lower;
        range_upper = RangeManager.GetComponent<RangeManager>().range_upper;
        EnemyCount = 10;

        int i;
        for (i = 0; i < EnemyCount; i++)
        {
            /*
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x, range_upper.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            enemyObject.GetComponent<EnemyController>().generator = this;
            enemyObject.name += i;
            */

            float defaltPos = -(EnemyCount / 2) * 2.0f + 1;

            GameObject enemyObject = Instantiate(createPrefab, new Vector3(defaltPos + i * 2.0f, 2.0f, 7.0f), createPrefab.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;

        }
    }

    void Level3Generate()
    {
        EnemyCount = 10;
        //EnemyObjectを縦一列に並べて生成
        for(int i = 0; i < EnemyCount; i++)
        {
            GameObject enemyObject = Instantiate(createPrefab, new Vector3(0, 2.0f, 7.0f + 2.0f*i), createPrefab.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }

    }

    void Level4Generate()
    {
        range_lower = RangeManager.GetComponent<RangeManager>().range_lower;
        range_upper = RangeManager.GetComponent<RangeManager>().range_upper;
        Debug.Log(range_lower);
        Debug.Log(range_upper);
        EnemyCount = 5;

        int i;
        for (i = 0; i < EnemyCount; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x, range_upper.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObject = Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
    }
}
