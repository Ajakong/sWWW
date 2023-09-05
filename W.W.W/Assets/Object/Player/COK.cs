using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COK : MonoBehaviour
{
    float RandPos;
    Vector3 reset;
    playerLifeCount Script_A;
    player2LifeCount Script_B;

    public string targetObjectName;
    public string hideObjectName;

    // Update is called once per frame
    void Start()
    {
        reset = Vector3.zero;
        this.Script_A = FindObjectOfType<playerLifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int i = Script_A.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j
        this.Script_B = FindObjectOfType<player2LifeCount>(); //�X�N���v�g��T���ď�錾�����ϐ��ɑ���B
        int a = Script_B.countProperty; // �X�N���v�gA����ϐ��������Ă���B�iget�j
    }
    private void OnTriggerEnter2D(Collider2D collision)                 // �����蔻����@�m
    {
        // ���������Ώۂ��G�v���C���[��������
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject targetObject = GameObject.Find(targetObjectName);    // ���O��ݒ�
            RandPos = Random.Range(0, 1000.0f);
            targetObject.gameObject.transform.Translate(RandPos - 500, 0, 0);
            if (collision.gameObject.name == "Player")
                Script_A.countProperty -= 1;
            if (collision.gameObject.name == "Player2")
            {
                Script_B.countProperty -= 1;
            }
        }



        //���������Ώۂ��K�[�h��������
        if (collision.gameObject.name == hideObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);    // ���O��ݒ�
            this.transform.localPosition = reset;

            this.gameObject.SetActive(false);
        }
    }

}
