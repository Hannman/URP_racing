using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HGM_Commander))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        HGM_Commander myScript = (HGM_Commander)target;
        GUILayout.Space(15);
        GUILayout.Label("Вызов событий из HGM_Event:");
        GUILayout.Space(15);

        //Добавляем время
        if (GUILayout.Button("Добавить время"))
        {
            HGM_Event.addTime?.Invoke(myScript.amountOfTime);
        }

        
        if (GUILayout.Button("Смена цвета"))
        {
            HGM_Event.changeRingColor?.Invoke();
        }

        GUILayout.Space(15);
        GUILayout.Label("Состояние машины:");
        GUILayout.Space(15);

        if (GUILayout.Button("Можно контралировать"))
        {
            HGM_Event.onControlOn?.Invoke();
        }


        if (GUILayout.Button("Нельзя контралировать"))
        {
            HGM_Event.onControlOff?.Invoke();
        }

        GUILayout.Space(15);
        GUILayout.Label("Состояние игры:");
        GUILayout.Space(15);

        if (GUILayout.Button("Игра закончена по времени"))
        {
            GameStates.Win();
        }


        if (GUILayout.Button("Игра закончена пройгрышем"))
        {
            GameStates.GameOver();
        }
    }
}

