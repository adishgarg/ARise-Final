using System.Collections;
using UnityEngine;
using System.IO;
public class FilePickerSystem : MonoBehaviour
{
    public static string finalpath;

    public static IEnumerator PickFileCoroutine()
    {
        bool filePicked = false;

        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) => {
            if (path == null)
            {
                Debug.Log("Error picking file");
            }
            else
            {
                string directoryPath = Path.GetDirectoryName(path);
                finalpath = GetPathUpToDirectory(directoryPath, "content");
                Debug.Log("Picked folder: " + finalpath);
                filePicked = true;
            }
        });

        yield return new WaitUntil(() => filePicked);
    }

    private static string GetPathUpToDirectory(string fullPath, string targetDirectory)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);

        while (directoryInfo != null && !directoryInfo.Name.Equals(targetDirectory, System.StringComparison.OrdinalIgnoreCase))
        {
            directoryInfo = directoryInfo.Parent;
        }

        return directoryInfo?.FullName;
    }
}