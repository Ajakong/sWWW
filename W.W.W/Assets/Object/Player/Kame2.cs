using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kame2 : MonoBehaviour
{
    Vector3 Move;
    Vector3 localScale;

    int timer;

    float RandNum;
    float RandPos;
    public bool flipFlag;
    public bool kameFlag;
    public string targetObjectName;
    public string hideObjectName;

    void Start()
    {

        localScale = transform.localScale; // ���[�J���ϐ��Ɋi�[
        kameFlag = false;

        Move = new Vector3(0.5f, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flipFlag = GetComponentInParent<Player2Control>().TurnFlag;
        if (timer <= 50)
        {
            kameFlag = true;
            localScale += Move; // ���[�J���ϐ��Ɋi�[�����l���㏑��
            transform.localScale = localScale; // ���[�J���ϐ�����
            if (flipFlag)
            {
                localScale -= Move * 2;
                transform.localScale = localScale;
            }
        }
        else
        {
            kameFlag = false;
            localScale.x = 0;
            transform.localScale = localScale;
            this.gameObject.SetActive(false);
            timer = 0;
        }






        timer++;
    }
    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {
        // ���������Ώۂ��G�v���C���[��������
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�
            RandNum = Random.Range(0.0f, 800.0f);
            Debug.Log(RandNum);
            targetObject.gameObject.transform.Translate(RandNum - 400.0f, 10, 0);
            RandNum = 0;


        }



        //���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            localScale.x = 0;
            transform.localScale = localScale;
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }

}
