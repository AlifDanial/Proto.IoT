using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using SimpleFileBrowser;


public class MP3Import : MonoBehaviour
{

    public IntPtr handle_mpg;
    public IntPtr errPtr;
    public IntPtr rate;
    public IntPtr channels;
    public IntPtr encoding;
    public IntPtr id3v1;
    public IntPtr id3v2;
    public IntPtr done;

    public string mPath;
    public int x;
    public int intRate;
    public int intChannels;
    public int intEncoding;
    public int FrameSize;
    public int lengthSamples;
    public AudioClip myClip;
    public AudioSource audioSource;
    public Image prefab;


    #region Consts: Standard values used in almost all conversions.
    private const float const_1_div_128_ = 1.0f / 128.0f;  // 8 bit multiplier
    private const float const_1_div_32768_ = 1.0f / 32768.0f; // 16 bit multiplier
    private const double const_1_div_2147483648_ = 1.0 / 2147483648.0; // 32 bit
    #endregion

    public void StartImport()
    {

        // Set filters (optional)
        // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
        // if all the dialogs will be using the same filters
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Audio Files", ".mp3"));

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
            mPath = FileBrowser.Result;
            Debug.Log(mPath);

            if (mPath.Length != 0)
            {
                Image o = Instantiate(prefab, transform);
                Debug.Log(mPath);

                //audioSource = (AudioSource)gameObject.GetComponent(typeof(AudioSource));
                //if (audioSource == null) audioSource = (AudioSource)gameObject.AddComponent<AudioSource>();


                MPGImport.mpg123_init();
                handle_mpg = MPGImport.mpg123_new(null, errPtr);
                x = MPGImport.mpg123_open(handle_mpg, mPath);
                MPGImport.mpg123_getformat(handle_mpg, out rate, out channels, out encoding);
                intRate = rate.ToInt32();
                intChannels = channels.ToInt32();
                intEncoding = encoding.ToInt32();

                MPGImport.mpg123_id3(handle_mpg, out id3v1, out id3v2);
                MPGImport.mpg123_format_none(handle_mpg);
                MPGImport.mpg123_format(handle_mpg, intRate, intChannels, 208);

                FrameSize = MPGImport.mpg123_outblock(handle_mpg);
                byte[] Buffer = new byte[FrameSize];
                lengthSamples = MPGImport.mpg123_length(handle_mpg);

                myClip = AudioClip.Create(mPath, lengthSamples, intChannels, intRate, false, false);

                int importIndex = 0;

                while (0 == MPGImport.mpg123_read(handle_mpg, Buffer, FrameSize, out done))
                {

                    float[] fArray;
                    fArray = ByteToFloat(Buffer);

                    myClip.SetData(fArray, (importIndex * fArray.Length) / 2);

                    importIndex++;
                }

                MPGImport.mpg123_close(handle_mpg);

                audioSource.clip = myClip;
                audioSource.loop = true;

                //audioSource.Play();

            }

        }        
    }

    public float[] IntToFloat(Int16[] from)
    {
        float[] to = new float[from.Length];

        for (int i = 0; i < from.Length; i++)
            to[i] = (float)(from[i] * const_1_div_32768_);

        return to;
    }

    public Int16[] ByteToInt16(byte[] buffer)
    {
        Int16[] result = new Int16[1];
        int size = buffer.Length;
        if ((size % 2) != 0)
        {
            /* Error here */
            Console.WriteLine("error");
            return result;
        }
        else
        {
            result = new Int16[size / 2];
            IntPtr ptr_src = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, 0, ptr_src, size);
            Marshal.Copy(ptr_src, result, 0, result.Length);
            Marshal.FreeHGlobal(ptr_src);
            return result;
        }
    }

    public float[] ByteToFloat(byte[] bArray)
    {
        Int16[] iArray;

        iArray = ByteToInt16(bArray);

        return IntToFloat(iArray);
    }


}