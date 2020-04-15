using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor;
using SimpleFileBrowser;

public class videoInstant : MonoBehaviour
{
    public RawImage prefab;
    public RawImage prefab1;
    public VideoPlayer player;  
    public VideoPlayer player1;  
    RenderTexture rendertexture;
    public string path;
    RawImage o;

    public void Start()
    {
        Initialize();
    }

    public void Import()
    {
        

        // Set filters (optional)
        // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
        // if all the dialogs will be using the same filters
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Videos", ".mp4", ".mov"));

        // Set default filter that is selected when the dialog is shown (optional)
        // Returns true if the default filter is set successfully
        // In this case, set Images filter as the default filter
        FileBrowser.SetDefaultFilter(".jpg");

        // Set excluded file extensions (optional) (by default, .lnk and .tmp extensions are excluded)
        // Note that when you use this function, .lnk and .tmp extensions will no longer be
        // excluded unless you explicitly add them as parameters to the function
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

        // Add a new quick link to the browser (optional) (returns true if quick link is added successfully)
        // It is sufficient to add a quick link just once
        // Name: Users
        // Path: C:\Users
        // Icon: default (folder icon)
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        // Show a save file dialog 
        // onSuccess event: not registered (which means this dialog is pretty useless)
        // onCancel event: not registered
        // Save file/folder: file, Initial path: "C:\", Title: "Save As", submit button text: "Save"
        // FileBrowser.ShowSaveDialog( null, null, false, "C:\\", "Save As", "Save" );

        // Show a select folder dialog 
        // onSuccess event: print the selected folder's path
        // onCancel event: print "Canceled"
        // Load file/folder: folder, Initial path: default (Documents), Title: "Select Folder", submit button text: "Select"
        // FileBrowser.ShowLoadDialog( (path) => { Debug.Log( "Selected: " + path ); }, 
        //                                () => { Debug.Log( "Canceled" ); }, 
        //                                true, null, "Select Folder", "Select" );

        // Coroutine example
        StartCoroutine(ShowLoadDialogCoroutine());

       
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Initial path: default (Documents), Title: "Load File", submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(false, null, "Load File", "Load");

        // Dialog is closed
        // Print whether a file is chosen (FileBrowser.Success)
        // and the path to the selected file (FileBrowser.Result) (null, if FileBrowser.Success is false)
        Debug.Log(FileBrowser.Success + " " + FileBrowser.Result);

        if (FileBrowser.Success)
        {
            // If a file was chosen, read its bytes via FileBrowserHelpers
            // Contrary to File.ReadAllBytes, this function works on Android 10+, as well
            path = FileBrowser.Result;
            Debug.Log(path);

            if (path.Length != 0)
            {
                rendertexture = new RenderTexture(1920, 1080, 24);

                o = Instantiate(prefab, transform);
                o = player.gameObject.GetComponent<RawImage>();
                o.texture = rendertexture;

                WWW www = new WWW("file:///" + path);
                player.url = path;

                player.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
                player.targetTexture = rendertexture;
                player.Play();
            }

        }
    }

    public void Initialize()
    {
        RawImage o3;
        RenderTexture rendertexture1 = new RenderTexture(1920, 1080, 24);

        o3 = Instantiate(prefab1, transform);
        o3 = player.gameObject.GetComponent<RawImage>();
        o3.texture = rendertexture1;

        var vc = Resources.Load<VideoClip>("Video/candle");
        player1.clip = vc;        

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture1;
        player1.Play();

        RawImage o1;
        RenderTexture rendertexture2 = new RenderTexture(1920, 1080, 24);

        o1 = Instantiate(prefab1, transform);
        o1 = player.gameObject.GetComponent<RawImage>();
        o1.texture = rendertexture2;

        var vc1 = Resources.Load<VideoClip>("Video/earth");
        player1.clip = vc1;        

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture2;
        player1.Play();

        RawImage o2;
        RenderTexture rendertexture3 = new RenderTexture(1920, 1080, 24);

        o2 = Instantiate(prefab1, transform);
        o2 = player.gameObject.GetComponent<RawImage>();
        o2.texture = rendertexture3;

        var vc2 = Resources.Load<VideoClip>("Video/particle");
        player1.clip = vc2;

        player1.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        player1.targetTexture = rendertexture3;
        player1.Play();
        
    }

}
