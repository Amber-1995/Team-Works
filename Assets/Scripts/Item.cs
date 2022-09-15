using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ExtraX
{
    public enum ItemType
    {
        Unknown = 0,

    }

    public abstract class Item
    {
        public ItemType ItemType { get { return itemType; } }

        public int MaxHold { get { return maxHold; } }

        protected ItemType itemType;

        protected int maxHold;

        public Item(ItemType itemType, int maxHold)
        {
            this.itemType = itemType;
            this.maxHold = maxHold;
        }

        public abstract void Use();
    }

   
}

