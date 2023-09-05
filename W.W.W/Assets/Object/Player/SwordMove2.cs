using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwordMove2 : MonoBehaviour
{
    // ���U��
    int timer;
    float RandPos;
    Vector3 axis;       // ��]��
    Vector3 point;
    Vector3 resetPos;
    Vector3 resetRot;
    Vector3 resetSca;



    public string targetObjectName;
    public string hideObjectName;
    public bool flipFlag;
    public float SpinLot;
    public float PrePoint;
    public float lotZ;



    void Start()
    {
        PrePoint = 0.5f;
        lotZ = 60.0f;
        SpinLot = 12.0f;
        resetPos = new Vector3(0, -PrePoint, 0);
        resetRot = new Vector3(0, 0, 60.0f);



        axis = new Vector3(0, 0, 1);



        timer = 0;
    }



    private void Update()
    {
        // �p���`�������]
        flipFlag = GetComponentInParent<Player2Control>().TurnFlag;
        point = new Vector3(transform.parent.position.x + PrePoint, transform.parent.position.y, 0);
    }



    void FixedUpdate()
    {
        if (timer == 1)
        {
            if (flipFlag)
            {
                SpinLot = -12.0f;
                PrePoint = -0.5f;
                lotZ = -60.0f;
                this.transform.localRotation = Quaternion.Euler(0, 0, lotZ);
                this.transform.localPosition = resetPos;
            }
            if (!flipFlag)
            {
                SpinLot = 12.0f;
                PrePoint = 0.5f;
                lotZ = 60.0f;
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
            GameObject targetObject = GameObject.Find(targetObjectName);
            RandPos = Random.Range(0, 1000.0f);
            targetObject.gameObject.transform.Translate(RandPos-500, 10, 0);
        }



        // ���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            this.transform.localRotation = Quaternion.Euler(0, 0, 60.0f);
            this.transform.localPosition = resetPos;
            timer = 0;
            this.gameObject.SetActive(false);                             // ���̔�����ł��Ƃ낢
        }
    }
}