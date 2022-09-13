using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraX
{
    [CreateAssetMenu(menuName = "ExtraX/ScrollWheelActionSetting")]
    public class ScrollWheelActionSetting : ScriptableObject
    {
        public List<string> actions;
    }
}