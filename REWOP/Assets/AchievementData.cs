using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementData : MonoBehaviour {
    public List<AchievementMeta> Achievements;
    public AchievementView AchievementView;

    public void UpdateCounters(int index, int delta)
    {
        Achievements[index].CurQuantity += delta;
        AchievementView.UpdateAchievements();
            CheckStat();
    }

    public void CheckStat()
    {
        foreach (var Achievement in Achievements)
            if (Achievement.CurQuantity >= Achievement.ReqQuantity && !Achievement.granted)
                GrantAchievement(Achievement.AchID);
    }

    public void GrantAchievement(int ID)
    {
        Achievements[SearchIDindex(ID)].granted = true;
        AchievementView.UpdateAchievements();
    }

    #region "private functions"
    public int SearchIDindex(int ID)
    {
        for (int i = 0; i < Achievements.Count-1; i++)
            if (Achievements[i].AchID == ID)
                return i;
  

        return -1;
    }
    #endregion
}



[System.Serializable()]
public class AchievementMeta
{
    public int AchID;
    public string Name;
    [TextArea(1,3)]
    public string Description;
    public int ReqQuantity;
    public int CurQuantity;
    public bool granted = false;
    public Sprite icon;
    public string tag;
}

