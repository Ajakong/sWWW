using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneJene : MonoBehaviour
{
    int[] randpos = new int[4];
    int no = 0;
    bool[] isGetNum = new bool[4] { false, false, false, false};

    public void Start()
    {

        DropWepon playerscript; //�ĂԃX�N���v�g�ɂ����Ȃ���

        while (no < 4)
        {
            randpos[no] = Random.Range(0, 4);
            if (!isGetNum[randpos[no]])
            {
                isGetNum[randpos[no]] = true;
                no++;
            }
        }

        GameObject obj = GameObject.Find("Enemy0"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<DropWepon>(); //�t���Ă���X�N���v�g���擾
        playerscript.WeponNum = randpos[0];

        obj = GameObject.Find("Enemy1"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<DropWepon>(); //�t���Ă���X�N���v�g���擾
        playerscript.WeponNum = randpos[1];

        obj = GameObject.Find("Enemy2"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<DropWepon>(); //�t���Ă���X�N���v�g���擾
        playerscript.WeponNum = randpos[2];

        obj = GameObject.Find("Enemy3"); //Player���Ă����I�u�W�F�N�g��T��
        playerscript = obj.GetComponent<DropWepon>(); //�t���Ă���X�N���v�g���擾
        playerscript.WeponNum = randpos[3];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
