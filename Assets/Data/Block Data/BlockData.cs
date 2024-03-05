using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Data", menuName = "Data/Block Data")]
public class BlockData : ScriptableObject
{
    public List<BlockSprite> listBlockSprites;
}

[Serializable]
public class BlockSprite
{
    public SpriteInfo spriteInfo;
    public BlockType blockType;
}

[Serializable]
public class SpriteInfo
{
    public List<Sprite> listSprite;
    public float maxHP;
}

public enum BlockType
{
    wood = 0,
    stone = 1,
    metal = 2,
}