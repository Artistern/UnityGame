using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class MonsterMove:MonoBehaviour
{
    private CharacterController mCharacterController;
    private Vector3 Target = Vector3.zero;
    private float Speed = 3.0f;
    private float Girvate=10.0f;

    void Awake()
    {
        mCharacterController = this.GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        if (!mCharacterController.isGrounded)
        {
            Target.y -= Girvate * Time.deltaTime;
        }
        mCharacterController.Move(Target * Time.deltaTime);
       
    }
}

