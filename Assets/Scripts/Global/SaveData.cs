using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveData
{
    private int _level = 1;
    public int level
    {
        get { return _level; }
        set { _level = value; Export(); }
    }

    public SaveData()
    {
        Import();
    }

    public bool Export()
    {
        return false;
    }

    public bool Import()
    {
        return false;
    }

    public bool ClearLevel(int levelId)
    {
        int nextLevel = levelId + 1;
        if (nextLevel <= _level || nextLevel > Global.maxLevel)
            return true;
        _level = nextLevel;
        return Export();
    }
}
