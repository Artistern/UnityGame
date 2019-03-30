using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;


public class FirstCalcMethod : BaseCalc
{
    /// <summary>
    /// 伤害计算的公式
    /// temp=rand(max,min)
    /// 判定是否产生暴击
    /// </summary>
    /// <returns></returns>
    public int DamageCalc(float max, float min, float Crit, float rate)
    {
        double temp = Random.Range(min, max);
        float x = Random.Range(1, 100);
        if (x<=rate)
        {
            temp=temp*(Crit*0.01);
        }
        return (int) temp;
    }
}
