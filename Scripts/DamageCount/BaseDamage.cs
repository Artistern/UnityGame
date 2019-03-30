using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseDamage : IDamage
{
    public int Calculate_Damage(float NormalAttackMin, float NormalAttackMax, float Crit_Rate, float CritDamage)
    {
        double temp = Random.Range(NormalAttackMin, NormalAttackMax);
        float x = Random.Range(1, 100);
        if (x<=Crit_Rate)
        {
            temp = temp * (CritDamage * 0.01);
            return (int) temp;
        }
        else
        {
            return (int) temp;
        }
    }
}
