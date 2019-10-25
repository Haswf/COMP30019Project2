using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private int level = 1;
    private int Exp;
    private int skillPoints = 0;
    private int maxExp = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        Exp = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        //level up
        if (getExp() > getMaxExp())
        {
            setExp(getExp()-getMaxExp());
            setMaxExp(getMaxExp()+100);
            setLevel(getlevel()+1);
            setSkillPoints(getSkillPoints()+1);
        }
    }

    public void setMaxExp(int newMax)
    {
        maxExp = newMax;
    }

    public int getMaxExp()
    {
        return maxExp;
    }
    public void increaseExp(int exp)
    {
        Exp += exp;
    }

    public void setExp(int remain)
    {
        Exp = remain;
    }
    

    public int getExp()
    {
        return Exp;
    }

    public int getlevel()
    {
        return level;
    }

    public void setLevel(int nextLevel)
    {
        level = nextLevel;
    }

    public int getSkillPoints()
    {
        return skillPoints;
    }

    public void setSkillPoints(int newPoints)
    {
        skillPoints = newPoints;
    }
}
