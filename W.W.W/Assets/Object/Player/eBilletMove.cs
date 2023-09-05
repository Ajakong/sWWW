using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class eBulletMove : MonoBehaviour
{
    Vector3 Move;
    Vector3 Pos;
    int timer;
    float RandPos;





    GameObject player;
    public string Enemy;
    public string targetObjectName;
    public string hideObjectName;





    public bool flipFlag;
    public bool moveFlag;





    void Start()
    {
        player = GameObject.Find(Enemy);
        flipFlag = player.GetComponent<enemyController>().TurnFlag;
        if (flipFlag)
        {
            Pos = new Vector3(player.transform.position.x - 0.3f, player.transform.position.y - 0.15f, player.transform.position.z);
            Move = new Vector3(-0.6f, 0, 0);
        }
        if (!flipFlag)
        {
            Pos = new Vector3(player.transform.position.x + 0.3f, player.transform.position.y - 0.15f, player.transform.position.z);
            Move = new Vector3(0.6f, 0, 0);
        }
        transform.position = Pos;





        timer = 0;
    }





    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 60) transform.localPosition += Move;





        if (timer > 85)
        {
            Destroy(this.gameObject);
        }
        timer++;
    }







    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {
        // ���������Ώۂ��G�v���C���[��������
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�



            RandPos = Random.Range(0, 1000.0f);
            targetObject.gameObject.transform.Translate(RandPos - 500, 0, 0);
        }





        //���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            Destroy(gameObject);                             // ���̔�����ł��Ƃ낢
        }
    }
}