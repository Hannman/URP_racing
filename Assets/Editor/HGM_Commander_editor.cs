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
        GUILayout.Label("����� ������� �� HGM_Event:");
        GUILayout.Space(15);

        //��������� �����
        if (GUILayout.Button("�������� �����"))
        {
            HGM_Event.addTime?.Invoke(myScript.amountOfTime);
        }

        
        if (GUILayout.Button("����� �����"))
        {
            HGM_Event.changeRingColor?.Invoke();
        }

        GUILayout.Space(15);
        GUILayout.Label("��������� ������:");
        GUILayout.Space(15);

        if (GUILayout.Button("����� ��������������"))
        {
            HGM_Event.onControlOn?.Invoke();
        }


        if (GUILayout.Button("������ ��������������"))
        {
            HGM_Event.onControlOff?.Invoke();
        }

        GUILayout.Space(15);
        GUILayout.Label("��������� ����:");
        GUILayout.Space(15);

        if (GUILayout.Button("���� ��������� �� �������"))
        {
            GameStates.Win();
        }


        if (GUILayout.Button("���� ��������� ����������"))
        {
            GameStates.GameOver();
        }
    }
}

