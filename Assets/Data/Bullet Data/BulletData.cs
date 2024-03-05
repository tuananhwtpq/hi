using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletData", menuName = "Data/Bullet Data")]
public class BulletData : ScriptableObject
{
    public List<BulletInfo> BulletInfos;
}
[Serializable]
public class BulletInfo
    {
        public float damage;
        public Sprite sprite;
    }