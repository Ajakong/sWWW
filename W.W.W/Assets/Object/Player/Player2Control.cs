using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player2Control : MonoBehaviour
{

    float RandPos;

    int weponFlag;
    public float Speed = 0;   // �v���C���[�ړ����x
    public float Jump = 0;   //�W�����v�̃p���[

    Rigidbody2D rbody;
    GameObject player;
    GameObject Kamehame;
    GameObject Sword;
    private Animator anim = null;

    [SerializeField] AudioSource Dash;
    [SerializeField] AudioSource jump;


    public bool KamehameFlag;
    public bool swordFlag;

    public string targetObjectName;

    float hori;


    public bool JumpFlag = false;
    public bool GroundFlag = true;
    public bool TurnFlag = false;

    int starttimer;

    void Start()
    {
        starttimer = 0;
        swordFlag = false;
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 5;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Kamehame = GameObject.Find("Player2");
    }



    async void Update()
    {
        //hori = Input.GetAxis("Horizontal2");  // L�X�e�B�b�N�����@�i��-1�`�E1�j
        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.UpArrow) && (GroundFlag))
        {
            await Task.Delay(10);
            JumpFlag = true;
        }
        if (!GroundFlag)
        {
            Jump = 0;
        }

        if (hori != 0)
        {
            Dash.volume = 1;
        }
        if ((hori == 0) || (transform.position.y > -1.9))
        {
            Dash.volume = 0;
        }

        if (transform.position.y < -1.9) jump.Play();
    }



    void FixedUpdate()
    {
        starttimer++;

        if (starttimer > 280)
        {
            if (starttimer == 281) Dash.Play();
            Debug.Log(GroundFlag);
            if (JumpFlag)
            {
                Jump += 3.0f;
                transform.Translate(0, Jump, 0);
                JumpFlag = false;
            }




            weponFlag = GetComponent<Panch2>().WeponSwitch;

            // �E���ŉE�ړ�
            if (Input.GetKey(KeyCode.RightArrow))
            {
                KamehameFlag = Kamehame.GetComponent<Panch2>().kameFlag;
                //swordFlag = Sword.GetComponent<Panch>().SwordFlag;
                Speed += 0.5f;
                TurnFlag = false;

                if (weponFlag == 0)
                {
                    Speed += 0.2f;
                }
                if (weponFlag == 1)
                {
                    Speed += 0.1f;
                }

                if (this.gameObject.transform.position.x > 450.0f)
                {
                    Speed = 0.0f;
                }

            }

            // �����ō��ړ�

            if (Input.GetKey(KeyCode.LeftArrow))
            {

                KamehameFlag = Kamehame.GetComponent<Panch2>().kameFlag;
                //swordFlag = Sword.GetComponent<Panch>().SwordFlag;

                Speed += -0.5f;
                TurnFlag = true;

                if (weponFlag == 0)
                {
                    Speed -= 0.2f;
                }
                if (weponFlag == 1)
                {
                    Speed -= 0.1f;
                }

                if (this.gameObject.transform.position.x < -450.0f)
                {
                    Speed = 0.0f;
                }



            }
            if (KamehameFlag == true)
            {
                Speed = 0;


            }
            //if (swordFlag == true)
            //{
            //    Speed = 0;


            //}

            if (this.gameObject.transform.position.y < -100)
            {
                Transform myTransform = this.transform;
                Vector3 pos = myTransform.position;
                pos.x = 0;
                pos.y = 0;
                pos.z = 0;
                myTransform.position = pos;

                RandPos = Random.Range(0, 1000.0f);
                this.gameObject.transform.Translate(RandPos - 500, 5, 0);
            }

            if (Speed != 0)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }

            transform.Translate(Speed, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = TurnFlag;
            Speed = 0;


        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        GroundFlag = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GroundFlag = false;
    }
}
