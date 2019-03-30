using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BossDamage:DamageAndATK
{
    public float Blood = 2000;
    void Update()
    {
        if (Hurt != 0)
        {
            Blood = Blood - Hurt;
            Hurt = 0;
            //Debug.Log("受到了伤害："+Hurt);
        }
        else if (Blood <= 0)
        {
            isDead = true;
            //Debug.Log("死亡");
        }
        else
        {
            isDead = false;
        }
    }
}
