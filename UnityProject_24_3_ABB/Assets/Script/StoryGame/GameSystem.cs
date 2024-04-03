using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using STORYGAME;

namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSysteEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GameSystem gameSystem = (GameSystem)target;

            if(GUILayout.Button("Reset Story Modes"))
            {
                gameSystem.ResetStroyModles();
            }
        }
    }


#endif


    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;

        private void Awake()
        {
            instance = this;
        }

        public enum GAMESTATE
        {
            SROTYSHOW,
            WAITSELECT,
            STORYEND,
            BATTLEMODE,
            BATTLEDONE,
            SHOPMODE,
            ENDMODE,
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;
        public int currentStoryIndex = 1;

#if UNITY_EDITOR
        [ContextMenu("Reset Story Models")]

        public void ResetStroyModles()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
        }



#endif
    }

}