using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class InstanceWitchControl : MonoBehaviour
{
    private WitchControl mWitchControl;

    void Awake()
    {
        mWitchControl = new WitchControl();
        mWitchControl.SetMonsterState(new WitchStand(mWitchControl), this.gameObject,
            this.gameObject.GetComponent<CharacterController>());
    }

    void Start()
    {
      
    }

    void Update()
    {
        mWitchControl.SetMonsterUpdate();
    }

}
