using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDamage
{
    /// <summary>
    /// 计算伤害的方法
    /// </summary>
    /// <returns></returns>
    int Calculate_Damage(float NormalAttackMin,float NormalAttackMax,float Crit_Rate,float CritDamage);
}
