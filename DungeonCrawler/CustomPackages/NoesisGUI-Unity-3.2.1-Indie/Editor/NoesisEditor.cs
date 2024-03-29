using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class NoesisEditor
{
    static NoesisEditor()
    {
        EditorApplication.update += () =>
        {
            if (NoesisUnity.Initialized)
            {
                Noesis.GUI.UpdateInspector();
            }
        };

        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;

#if UNITY_2019_1_OR_NEWER
        SceneView.duringSceneGui += OnSceneGUI;
#else
        SceneView.onSceneGUIDelegate += OnSceneGUI; 
#endif
    }

    /// <summary>
    /// When a XAML is dragged into the Scene view, we add it to the main camera
    /// </summary>
    private static void OnSceneGUI(SceneView sceneView)
    {
        if (Camera.main != null)
        {
            OnDraggedObject(Camera.main.gameObject);
        }
    }

    /// <summary>
    /// When a XAML is dragged into the hierarchy view, we add it to the target object
    /// </summary>
    private static void HierarchyWindowItemOnGUI(int instancedID, Rect selectionRect)
    {
        if (!selectionRect.Contains(Event.current.mousePosition))
        {
            return;
        }

        OnDraggedObject(EditorUtility.InstanceIDToObject(instancedID) as GameObject);
    }

    private static void OnDraggedObject(GameObject obj)
    {
        Event ev = Event.current;

        if (ev.type != EventType.DragUpdated && ev.type != EventType.DragPerform && ev.type != EventType.DragExited)
        {
            return;
        }

        NoesisXaml xaml = DraggedXaml();
        if (xaml == null)
        {
            return;
        }

        if (!CanAttachXaml(obj))
        {
            ev.Use();
            return;
        }

        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

        if (ev.type == EventType.DragPerform)
        {
            AddViewToObject(xaml, obj);
            ev.Use();
        }
    }

    private static NoesisXaml DraggedXaml()
    {
        if (DragAndDrop.objectReferences != null)
        {
            foreach (var obj in DragAndDrop.objectReferences)
            {
                if (obj is NoesisXaml)
                {
                    return (NoesisXaml)obj;
                }
            }
        }

        return null;
    }

    private static bool CanAttachXaml(GameObject obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.TryGetComponent(out Camera _))
        {
            return true;
        }

#if ENABLE_UGUI_PACKAGE
        if (obj.TryGetComponent(out UnityEngine.UI.RawImage _))
        {
            return true;
        }
#endif

        if (obj.TryGetComponent(out UnityEngine.Renderer _))
        {
            return true;
        }

        return false;
    }

    private static void AddViewToObject(NoesisXaml xaml, GameObject obj)
    {
        if (obj.TryGetComponent(out NoesisView view))
        {
            Undo.RecordObject(view, "Changed XAML");
            view.Xaml = xaml;
        }
        else
        {
            Undo.AddComponent<NoesisView>(obj);
            obj.GetComponent<NoesisView>().Xaml = xaml;
        }
    }
}