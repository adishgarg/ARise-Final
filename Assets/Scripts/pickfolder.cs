using UnityEngine;
using System.IO;
public class PickFolder : MonoBehaviour
{
    public static string finalpath;

    public void LoadFile()
    {
        Debug.Log("LoadFile method called");

        string FileType = NativeFilePicker.ConvertExtensionToFileType("mp4"); 
        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) => {
            if (path == null)
            {
                Debug.Log("Error picking file");
            }
            else
            {
                finalpath = path;
                Debug.Log("Picked file: " + finalpath);
            }
        }, new string[] { FileType });
    }

}
