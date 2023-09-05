using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordmove3 : MonoBehaviour
{
    // ���U��
    int timer;
    float RandPos;
    Vector3 axis;       // ��]��
    Vector3 point;
    Vector3 resetPos;
    Vector3 resetRot;
    Vector3 resetSca;
    playerLifeCount Script_A;
    player2LifeCount Script_B;

    public string targetObjectName;
    public string hideObjectName;
    public bool flipFlag;
    public float SpinLot;
    public float PrePoint;
    public float lotZ;



    void Start()
    {
        PrePoint = 0.5f;
        lotZ = 280.0f;
        SpinLot = 14.0f;
        resetPos = new Vector3(0, -PrePoint, 0);
        resetRot = new Vector3(0, 0, 60.0f);

        axis = new Vector3(0, 0, 2);

        timer = 0;

        this.Script_A = FindObjectOfType<playerLifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int i = Script_A.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j
        this.Script_B = FindObjectOfType<player2LifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int a = Script_B.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j

    }



    private void Update()
    {
        point = new Vector3(transform.parent.position.x + PrePoint, transform.parent.position.y, 0);
    }



    void FixedUpdate()
    {
        if (timer == 1)
        {
            // �p���`�������]
            flipFlag = GetComponentInParent<Player2Control>().TurnFlag;
            if (flipFlag)
            {
                SpinLot = -12.0f;
                PrePoint = -1.5f;
                lotZ = -140.0f;
                this.transform.localRotation = Quaternion.Euler(0, 0, lotZ);
                this.transform.localPosition = resetPos;
            }
            if (!flipFlag)
            {
                SpinLot = 12.0f;
                PrePoint = 1.5f;
                lotZ = 140.0f;
                this.transform.localRotation = Quaternion.Euler(0, 0, lotZ);
                this.transform.localPosition = resetPos;
            }
        }



        if (timer < 16)
        {

            transform.RotateAround(point, axis, SpinLot);
        }
        else
        {
            transform.localPosition = resetPos;
            timer = 0;
            this.gameObject.SetActive(false);
        }
        timer++;
    }



    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {
        // ���������Ώۂ��G�v���C���[��������
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject hideObject = GameObject.Find(targetObjectName);    // ���O��ݒ�
            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�

            RandPos = Random.Range(70, 950.0f);
            Debug.Log(RandPos);
            targetObject.gameObject.transform.Translate(RandPos - 500.0f, 10, 0);

            Script_A.countProperty -= 10;
            if (collision.gameObject.name == "Player2")
            {
                Script_B.countProperty -= 1;
            }
        }



        // ���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            this.transform.localRotation = Quaternion.Euler(0, 0, 140.0f);
            this.transform.localPosition = resetPos;
            timer = 0;
            this.gameObject.SetActive(false);                             // ���̔�����ł��Ƃ낢
        }
    }
}
