using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ProgressScript : MonoBehaviour
{


    static public int progress = -1;
    //GameObject[] lvlButtons;

    private Save sv = new Save();
    private string path;
    public SnapScrolling snapScrolling;

    // Use this for initialization
    void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            LoadFile();
            if (SnapScrolling.flagLvlsPosition == 0)
            {
                snapScrolling.SetButtonPosition(progress + 1);
            }

            for (int i = 0; i <= progress + 1; i++)
            {
                if (SnapScrolling.lvlButtons[i] != null)
                {
                    SnapScrolling.lvlButtons[i].GetComponent<Button>().enabled = true;
                    SnapScrolling.lvlButtons[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
            }
        }

    }

    public void LoadFile()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            progress = sv.Progress;
        }
    }

    public void SaveFile()  //https://www.youtube.com/watch?v=oZ1gmpnQBFg
    { 
#if UNITY_ANDROID && !UNITY_EDITOR
    path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        sv.Progress = progress;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

    [System.Serializable]
    public class Save
    {
        public int Progress;
    }
}
