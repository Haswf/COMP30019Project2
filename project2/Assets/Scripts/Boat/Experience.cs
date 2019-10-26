using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private int level = Player.PlayerLevel;
    private int Exp = Player.PlayerExp;
    private int skillPoints = Player.PlayerSkillPoints;
    private int maxExp;
    
    // Start is called before the first frame update
    void Start()
    {
        maxExp = 500 + level * 100 -100;
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

        if (GetComponent<HealthManager>().getHealth() <= 0)
        {
            Player.PlayerExp = Exp;
            Player.PlayerLevel = level;
            Player.PlayerSkillPoints = skillPoints;
            Player.NowMaxExp = maxExp;
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
