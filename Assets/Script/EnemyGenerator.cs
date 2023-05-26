using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject NormalEnemy;
    public GameObject MovingNormalEnemy;
    public GameObject NormalEnemySpiral;
    public GameObject NormalEnemyDurable;
    public GameObject BlueEnemy;
    public GameObject MovingBlueEnemy;
    public GameObject YellowEnemy;
    public GameObject MovingYellowEnemy;
    public GameObject RedEnemy;
    public GameObject MovingRedEnemy;

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
            enemy.gameObject.GetComponent<MeshRenderer>().enabled = false;
            enemy.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    public void GenerateFuncSet()
    {
        generateFuncs = new System.Action[11];
        generateFuncs[0] = TitleGenerate;
        generateFuncs[1] = Level1Generate;
        generateFuncs[2] = Level2Generate;
        generateFuncs[3] = Level3Generate;
        generateFuncs[4] = Level4Generate;
        generateFuncs[5] = Level5Generate;
        generateFuncs[6] = Level6Generate;
        generateFuncs[7] = Level7Generate;
        generateFuncs[8] = Level8Generate;
        generateFuncs[9] = Level9Generate;
        generateFuncs[10] = Level10Generate;
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
            GameObject enemyObject = Instantiate(NormalEnemy, new Vector3(x, y, z), NormalEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
    }

    void Level1Generate()
    {
        EnemyCount = 1;
        // GameObjectを1個だけ生成
        GameObject enemyObject = Instantiate(NormalEnemy, new Vector3(0, 2.0f, 7.0f), NormalEnemy.transform.rotation);
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

            GameObject enemyObject = Instantiate(NormalEnemy, new Vector3(defaltPos + i * 2.0f, 2.0f, 7.0f), NormalEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;

        }
    }

    void Level3Generate()
    {
        EnemyCount = 10;
        //EnemyObjectを縦一列に並べて生成
        for(int i = 0; i < EnemyCount; i++)
        {
            GameObject enemyObject = Instantiate(NormalEnemy, new Vector3(0, 2.0f, 7.0f + 2.0f*i), NormalEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }

    }

    void Level4Generate()
    {
        EnemyCount = 3;

        GameObject enemyObjectBlue = Instantiate(BlueEnemy, new Vector3(-4.0f, 2.0f, 7.0f), BlueEnemy.transform.rotation);
        enemyObjectBlue.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;

        GameObject enemyObjectYellow = Instantiate(YellowEnemy, new Vector3(0, 2.0f, 7.0f), YellowEnemy.transform.rotation);
        enemyObjectYellow.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;

        GameObject enemyObjectRed = Instantiate(RedEnemy, new Vector3(4.0f, 2.0f, 7.0f), RedEnemy.transform.rotation);
        enemyObjectRed.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
    }

    void Level5Generate()
    {
        EnemyCount = 1;
        // GameObjectを1個だけ生成
        GameObject enemyObject = Instantiate(NormalEnemyDurable, new Vector3(0, 2.0f, 7.0f), NormalEnemyDurable.transform.rotation);
        enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
    }

    void Level6Generate()
    {
        EnemyCount = 1;
        // GameObjectを1個だけ生成
        GameObject enemyObject = Instantiate(NormalEnemy, new Vector3(0, 18.8f, 35.8f), NormalEnemy.transform.rotation);
        enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
    }

    void Level7Generate()
    {
        range_lower = RangeManager.GetComponent<RangeManager>().range_lower;
        range_upper = RangeManager.GetComponent<RangeManager>().range_upper;
        EnemyCount = 9;

        int i;
        for (i = 0; i < 3; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x + 3, range_upper.x - 3);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObject = Instantiate(MovingBlueEnemy, new Vector3(x, y, z), MovingBlueEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
        for (i = 0; i < 3; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x + 3, range_upper.x - 3);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObjectyellow = Instantiate(MovingYellowEnemy, new Vector3(x, y, z), MovingYellowEnemy.transform.rotation);
            enemyObjectyellow.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
        for (i = 0; i < 3; i++)
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(range_lower.x + 3, range_upper.x - 3);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y = Random.Range(range_lower.y, range_upper.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z = Random.Range(range_lower.z, range_upper.z);

            // GameObjectを上記で決まったランダムな場所に生成
            GameObject enemyObjectred = Instantiate(MovingRedEnemy, new Vector3(x, y, z), MovingRedEnemy.transform.rotation);
            enemyObjectred.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
    }

    void Level8Generate()
    {
        EnemyCount = 10;
        int i;

        for(i = 0; i < EnemyCount; i++)
        {
            GameObject enemyObject = Instantiate(NormalEnemySpiral, new Vector3(0, 0, 0), NormalEnemySpiral.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        }
        
    }

    void Level9Generate()
    {
        EnemyCount = 9;
        float x;
        float y;
        int i;

        for(i = 0; i < 3; i++)
        {
            x = Random.Range(-18.0f, 18.0f);
            y = Random.Range(2.0f, 13.0f);
            GameObject enemyObject = Instantiate(BlueEnemy, new Vector3(x, y, 37.0f), BlueEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
            enemyObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1.0f * (1 + 0.5f * i));
        }
        for (i = 0; i < 3; i++)
        {
            x = Random.Range(-18.0f, 18.0f);
            y = Random.Range(2.0f, 13.0f);
            GameObject enemyObject = Instantiate(YellowEnemy, new Vector3(x, y, 37.0f), YellowEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
            enemyObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1.0f * (1 + 0.5f * i));
        }
        for (i = 0; i < 3; i++)
        {
            x = Random.Range(-18.0f, 18.0f);
            y = Random.Range(2.0f, 13.0f);
            GameObject enemyObject = Instantiate(RedEnemy, new Vector3(x, y, 37.0f), RedEnemy.transform.rotation);
            enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
            enemyObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1.0f * (1 + 0.5f * i));
        }


    }

    void Level10Generate()
    {
        EnemyCount = 1;
        // GameObjectを1個だけ生成
        GameObject enemyObject = Instantiate(NormalEnemyDurable, new Vector3(0, 2.0f, 7.0f), NormalEnemyDurable.transform.rotation);
        enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().generator = this;
        enemyObject.transform.GetChild(0).gameObject.GetComponent<EnemyController>().life = 100.0f;
    }
}
