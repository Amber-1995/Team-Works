using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtraX
{
    [CreateAssetMenu(menuName = "ExtraX/ActionSetting")]
    public class ActionSetting : ScriptableObject
    {
        public List<string> actions;
    }
}