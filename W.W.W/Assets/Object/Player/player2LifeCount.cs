using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player2LifeCount : MonoBehaviour
{
    public int lifeCount;
    public bool active;
    int timer;
    public GameObject Life;
    public GameObject fin;

    public GameObject Player1Win;
    public GameObject Player1Win2;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        lifeCount = 50;
        active = false;
        Life.SetActive(false);
        fin.SetActive(false);
        Player1Win.SetActive(false);
        Player1Win2.SetActive(false);
    }
    public int countProperty // �����Ńv���p�e�B���g���Bpublic�����܂��B
    {
        get { return lifeCount; }  // ���ꂪgettr�B���̃X�N���v�g����Ăяo�������Areturn�̂��Ƃɏ������ϐ���Ԃ��B
        set { lifeCount = value; } // ���ꂪsettr�Bvalue�ɂ͑��̃X�N���v�g�ő�����ꂽ�l���i�[����܂��B�i�����܂ŋC�ɂ��Ȃ��đ��v�B�j
    }
    // Update is called once per frame
    void Update()
    {
        
        GetComponent<Text>().text = ("�~") + lifeCount.ToString("0");
        if(lifeCount<=0)
        {
            active = true;
            Life.SetActive(true);
            fin.SetActive(true);
            Time.timeScale = 0.8f;
        }
        if (timer >= 100)
        {
            Life.SetActive(false);
            fin.SetActive(false);
            Player1Win.SetActive(true);
            Player1Win2.SetActive(true);
        }
        if(timer>=200)
        {
            SceneManager.LoadScene("titleScene" +
               "");
        }

    }
    private void FixedUpdate()
    {
        if (lifeCount <= 0)
        {
            timer++;
        }
    }
}
