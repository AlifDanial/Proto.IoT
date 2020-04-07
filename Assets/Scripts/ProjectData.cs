using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ProjectData
{
    public List<TriggerData> triggers = new List<TriggerData>();
    public List<SaveData> saves = new List<SaveData>();
}
