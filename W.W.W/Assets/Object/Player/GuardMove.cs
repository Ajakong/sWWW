using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    int timer;  

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 25 )
        {
            
        }

        //�^�C�}�̍X�V
        timer++;
    }

    //private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    //{
    //    // ���������Ώۂ��K�[�h��������
    //    Destroy(collision.gameObject);                             // ���̔�����ł��Ƃ낢
    //}
}
