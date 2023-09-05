using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exProCont : MonoBehaviour
{
    Vector3 localScale;
    Vector3 Move;
    GameObject bomb;
    Vector3 BombPos;
    player2LifeCount Script_A;
    playerLifeCount Script_B;

    int timer;
    float RandPos;
    

    public string targetObjectName;
    public string hideObjectName;
    public string Bomb;


    void Start()
    {
        bomb = GameObject.Find(Bomb);
        BombPos=new Vector3(bomb.transform.position.x, bomb.transform.position.y,bomb.transform.position.z);
        //BombPos = GetComponentInParent<Transform>().position;
        
        timer = 0;
        transform.position = BombPos;
        Move = new Vector3(0.1f, 0.1f, 0);

        this.Script_A = FindObjectOfType<player2LifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int i = Script_A.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j
        this.Script_B = FindObjectOfType<playerLifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int a = Script_B.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j



    }

    void Update()
    {



        if (timer == 1)
        {
            localScale = new Vector3(4, 4, 0);
        }
        else if (timer <= 40)
        {
            localScale += Move;
        }
        
        else if (timer > 40)
        {
            Destroy(gameObject);
        }


    }

    void FixedUpdate()
    {

        
        timer++;
    }

    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {

        if (collision.gameObject.name == targetObjectName)
        {

            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�
            RandPos = Random.Range(0, 1000.0f);
            targetObject.gameObject.transform.Translate(RandPos - 500, 11, 0);
            if (collision.gameObject.name == "Player2")
            {
                Script_A.countProperty -= 10;
            }
            if (collision.gameObject.name == "Player")
            {
                Script_B.countProperty -= 10;
            }// �G���ł��Ƃ낢
        }

    }
}
