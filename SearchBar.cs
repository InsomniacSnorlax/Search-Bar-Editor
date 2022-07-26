using System;
using UnityEditor;
using UnityEngine;

public class SearchBar : EditorWindow
{
    /// <summary>
    /// Opens up Window
    /// </summary>
    [MenuItem("Snorlax's Tools/Search Bar")]
    public  static void OpenWindow()
    {
        GetWindow<SearchBar>();
    }
    // Targeted array or list that will be filtered out
    string[] listOfStrings = { "Apples", "Peaches", "Grapes", "Watermelon"};
    // String for the searh bar, must initalise or the editor might misbehave
    string SearchString = "";
    #region Main Methods
    /// <summary>
    /// A reusable search bar method for editors
    /// </summary>
    /// <param name="SearchString">input string will be altered due to ref hence making it reusable</param>
    public void SearchBarMethod(ref string SearchString)
    {
        EditorGUILayout.BeginHorizontal();
        {
            SearchString = GUILayout.TextField(SearchString, GUI.skin.FindStyle("ToolbarSeachTextField"));

            if (GUILayout.Button("", GUI.skin.FindStyle("ToolbarSeachCancelButton")))
            {
                SearchString = "";
            }
        }
        EditorGUILayout.EndHorizontal();
    }
    /// <summary>
    /// Returns true if toCheck string is included in the source string while ignoring case
    /// </summary>
    /// <param name="source">The string to be compared to</param>
    /// <param name="toCheck">The search string</param>
    /// <param name="comp">StringComparison can be changed if need be</param>
    /// <returns></returns>
    private bool StringContains(string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
    {
        return source?.IndexOf(toCheck, comp) >= 0;
    }
    #endregion
    /// <summary>
    /// Used for OnGUI 
    /// </summary>
    public void ExampleMethod()
    {
        // Search bar
        SearchBarMethod(ref SearchString);

        // Displaying list
        foreach (string target in listOfStrings)
        {
            // If the target string doesn't include the search string it will continue with the list and skip displaying the label
            if (!StringContains(target, SearchString) && !String.IsNullOrEmpty(SearchString))
            {
                continue;
            }

            GUILayout.Label(target);
        }
    }

    private void OnGUI()
    {
        ExampleMethod();
    }
}
