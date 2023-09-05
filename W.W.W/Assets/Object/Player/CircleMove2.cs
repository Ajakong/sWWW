using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CircleMove2 : MonoBehaviour
{
    Vector3 Move;
    Vector3 reset;
    playerLifeCount Script_B;
    int timer;
    float RandPos;



    public string targetObjectName;
    public string hideObjectName;
    public bool flipFlag;



    // Start is called before the first frame update
    void Start()
    {
        reset = Vector3.zero;
        this.transform.localPosition = reset;
        Move = new Vector3(0.1f, 0, 0);
        this.Script_B = FindObjectOfType<playerLifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int a = Script_B.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j


        timer = 0;
    }



    private void Update()
    {
        // �p���`�������]
        flipFlag = GetComponentInParent<Player2Control>().TurnFlag;
    }



    //1/50���Ƃɂ�����ʂ�B
    private void FixedUpdate()
    {
        if (timer == 1)
        {
            if (flipFlag) Move.x = -0.1f;
            if (!flipFlag) Move.x = 0.1f;
        }
        // ����n��
        if (timer < 10)
        {
            transform.localPosition += Move;   // 10�t���[���ŉ��肫��
        }
        else if (timer < 20)//����������ߎn�߂�



        {
            transform.localPosition -= Move;   // 10�t���[���Ŗ߂�����
        }
        else
        {
            transform.localPosition = reset;
            timer = 0;
            this.gameObject.SetActive(false);
        }



        //�^�C�}�̍X�V
        timer++;
    }



    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {
        // ���������Ώۂ��G�v���C���[��������
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�
            RandPos = Random.Range(0, 1000.0f);
            targetObject.gameObject.transform.Translate(RandPos - 500, 10, 0);
            Script_B.countProperty -= 10;
        }



        //���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            this.transform.localPosition = reset;
            timer = 0;
            this.gameObject.SetActive(false);
        }
    }
}