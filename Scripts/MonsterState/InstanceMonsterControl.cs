using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class InstanceMonsterControl:MonoBehaviour
{
    private MonsterControl mMonsterControl=new MonsterControl();

    void Start()
    {
        
       mMonsterControl.SetMonsterState(new Stand(mMonsterControl), this.gameObject,this.gameObject.GetComponent<CharacterController>());
    }

    void LateUpdate()
    {
        mMonsterControl.SetMonsterUpdate();
    }
}

