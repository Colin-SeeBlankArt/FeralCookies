using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MG.MDV;
using UnityEditor;
using UnityEngine;

public class DocumentationWindow : EditorWindow
{
    private GUISkin m_darkSkin;
    private readonly List<string> m_documentationFiles = new List<string>();
    private MarkdownViewer m_documentationObject;
    private GUISkin m_lightSkin;

    private Vector2 m_scrollPosition = Vector2.zero;

    [MenuItem("Rhythm Mountain/Windows/Documentation")]
    private static void OpenDocumentationWindow()
    {
        GetWindow<DocumentationWindow>().Show();
    }

    [InitializeOnLoadMethod]
    private static void AutoOpenWindow()
    {
        EditorApplication.delayCall += OpenDocumentationWindow;
    }

    protected void OnDisable()
    {
        m_documentationObject = null;

        EditorApplication.update -= UpdateRequests;
        Selection.selectionChanged += SelectionChanged;
    }

    private void OnEnable()
    {
        var darkSkinPath = AssetDatabase.GUIDToAssetPath("8611e9e5923b6084997203d4997b4976");
        m_darkSkin = AssetDatabase.LoadAssetAtPath<GUISkin>(darkSkinPath);
        var lightSkinPath = AssetDatabase.GUIDToAssetPath("81f272e4a921a5448a30c0e40b4ea003");
        m_lightSkin = AssetDatabase.LoadAssetAtPath<GUISkin>(lightSkinPath);

        var mdFiles = Directory.GetFiles("Assets/Documentation", "*.md");
        if (mdFiles?.Length > 0)
        {
            m_documentationFiles.AddRange(mdFiles);
        }

        var markdownFiles = Directory.GetFiles("Assets/Documentation", "*.markdown");
        if (markdownFiles?.Length > 0)
        {
            m_documentationFiles.AddRange(markdownFiles);
        }

        var firstPage = m_documentationFiles.FirstOrDefault(f => f.EndsWith("readme.md", StringComparison.InvariantCultureIgnoreCase));
        if (firstPage != null)
        {
            SelectPage(firstPage);
        }

        EditorApplication.update += UpdateRequests;
        Selection.selectionChanged += SelectionChanged;
    }

    private void OnGUI()
    {
        if (m_documentationObject == null)
        {
            return;
        }

        EditorGUILayout.LabelField("Rhythm Mountain Documentation", EditorStyles.whiteLargeLabel, GUILayout.Height(50f));
        
        
        var remainingWidth = (float)position.width;
        var quarterWidth = remainingWidth * 0.25f;
        var yStart = 20f;
        var remainingHeight = position.height - yStart;
        GUILayout.BeginArea(new Rect(0f, yStart, quarterWidth, remainingHeight));
        {
            for (var i = 0; i < m_documentationFiles.Count; i++)
            {
                var filename = Path.GetFileName(m_documentationFiles[i]);
                if (EditorGUILayout.LinkButton(filename))
                {
                    SelectPage(m_documentationFiles[i]);
                }
            }
        }
        GUILayout.EndArea();
        remainingWidth -= quarterWidth;

        GUILayout.BeginArea(new Rect(quarterWidth, yStart, remainingWidth, remainingHeight));
        {
            m_scrollPosition = GUILayout.BeginScrollView(m_scrollPosition);
            {
                m_documentationObject.Draw();
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndArea();
    }

    private void SelectionChanged()
    {
        var newSelection = Selection.activeObject as TextAsset;
        var path = AssetDatabase.GetAssetPath(newSelection);

        var ext = Path.GetExtension(path).ToLower();
        if (ext != ".md" && ext != ".markdown")
        {
            return;
        }

        SelectPage(path);
    }

    private void SelectPage(string markdownPath)
    {
        var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(markdownPath);
        var content = asset.text;
        var path = AssetDatabase.GetAssetPath(asset);

        var skin = Preferences.DarkSkin ? m_darkSkin : m_lightSkin;
        m_documentationObject = new MarkdownViewer(skin, path, content);
    }

    private void UpdateRequests()
    {
        if (m_documentationObject != null && m_documentationObject.Update())
        {
            Repaint();
        }
    }
}