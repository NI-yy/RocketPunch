using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownManager : MonoBehaviour
{
    public GameObject gameDirector;
    public GameObject enemyGenerator;
    public GameObject MessageCanvas;
    public TMPro.TMP_Text messageText;

    public bool is_final;

    string levelText;
    float countdown = 3.0f;
    int count;
    int build_index;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {

        if (is_final)
        {
            levelText = "Final";
        }
        else
        {
            levelText = SceneManager.GetActiveScene().buildIndex.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (countdown >= 0)
            {
                countdown -= Time.deltaTime;
                count = (int)countdown + 1;
                messageText.text = "Level " + levelText + "\n" + count.ToString();
            }
            else
            {
                MessageCanvas.SetActive(false);
                gameDirector.SetActive(true);
                enemyGenerator.SetActive(true);
                flag = false;
            }
        }
        
    }
}
