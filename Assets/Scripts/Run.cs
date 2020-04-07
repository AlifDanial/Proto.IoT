using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class Run : MonoBehaviour
{
    public IntPtr handle_mpg;
    public IntPtr errPtr;
    public IntPtr rate;
    public IntPtr channels;
    public IntPtr encoding;
    public IntPtr id3v1;
    public IntPtr id3v2;
    public IntPtr done;
    
    public int x;
    public int intRate;
    public int intChannels;
    public int intEncoding;
    public int FrameSize;
    public int lengthSamples;
    public AudioClip myClip;
    public AudioSource audioSource;
    public GameObject Sensor;
    public Image o;
    public VideoPlayer v;
    public RawImage ri;
    public Text texto;
    public Text audiostext;
    public Image audiosI;

    public Image rfid;
    public Text rfidt;
    public Image motion;
    public Text motiont;
    public Image touch;
    public Text toucht;

    public Image audio;
    public Text audiot;
    public Image image;
    public Text imaget;
    public Image text;
    public Text textt;
    public Image video;
    public Text videot;

    #region Consts: Standard values used in almost all conversions.
    private const float const_1_div_128_ = 1.0f / 128.0f;  // 8 bit multiplier
    private const float const_1_div_32768_ = 1.0f / 32768.0f; // 16 bit multiplier
    private const double const_1_div_2147483648_ = 1.0 / 2147483648.0; // 32 bit
    #endregion

    ProjectData projectData = new ProjectData();
    string path;
    bool stop = true;
    bool registered = false;
    string temp = "";

    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.File.Exists(path))
        {
            string contents = System.IO.File.ReadAllText(path);
            JSONwrapper wrapper = JsonUtility.FromJson<JSONwrapper>(contents);
            projectData = wrapper.triggers;
        }        


    }

    // Update is called once per frame
    void Update()
    {
        triggerScan(Sensor.GetComponent<ConnectToServer>().SensorData);           
    }

    public void setPath(string s){
        path = s;

        if (System.IO.File.Exists(path))
        {
            string contents = System.IO.File.ReadAllText(path);
            JSONwrapper wrapper = JsonUtility.FromJson<JSONwrapper>(contents);
            projectData = wrapper.triggers;
        }
        
        Sensor.GetComponent<ConnectToServer>().SensorData = "EMPTY";
        stop = false;        
        ri.gameObject.SetActive(false);
        audiosI.gameObject.SetActive(false);
        audiostext.enabled = false;
    }

    public void readData()
    {
        try
        {
            if (System.IO.File.Exists(path))
            {
                string contents = System.IO.File.ReadAllText(path);
                JSONwrapper wrapper = JsonUtility.FromJson<JSONwrapper>(contents);
                projectData = wrapper.triggers;

                foreach (TriggerData s in projectData.triggers)
                {
                    int t = s.trigger;
                    Debug.Log("Trigger = " + t);

                    string i = s.input;
                    Debug.Log("input = " + i);

                    string o = s.output;
                    Debug.Log("output = " + o);
                }

                Debug.Log("Finished Reading");
               
                
            }
            else
            {
                Debug.Log("Unable to read the save data, file does not exist");
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void stopScan()
    {
        stop = true;
        Sensor.GetComponent<ConnectToServer>().SensorData = "EMPTY";
        audiosI.gameObject.SetActive(false);
        ri.gameObject.SetActive(false);
        audiostext.enabled = false;
    }

    public void show(Image a, Text b)
    {
        a.gameObject.SetActive(true);
        b.gameObject.SetActive(true);
    }

    public void hide(Image a, Image b, Image c, Text d, Text e, Text f)
    {
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(false);
        d.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
        f.gameObject.SetActive(false);
    }

    public void hideIn(Image a, Image b, Text d, Text e)
    {
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        d.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
    }

    public void triggerScan(string s)
    {        
        if (temp != s)
        {
            temp = s;
            registered = false;

            Debug.Log("TEMP = " + temp);

            if(temp == "Motion")
            {
                show(motion, motiont);
                hideIn(rfid, touch, rfidt,toucht);
                Debug.Log("TEMP = " + temp);
            }

            else if (temp.Contains("Touch"))
            {
                show(touch, toucht);
                hideIn(rfid, motion, rfidt, motiont);
                Debug.Log("TEMP = " + temp);
            }

            else if (temp.Contains("Card"))
            {
                show(rfid, rfidt);
                hideIn(motion, touch, motiont, toucht);
                Debug.Log("TEMP = " + temp);
            }
        }
        
        if (System.IO.File.Exists(path) && stop == false)
        {           
            foreach (TriggerData t in projectData.triggers)
            {
                if (temp == t.input && registered == false)
                {
                    Debug.Log("scanned trigger..");
                    Debug.Log("String Scanning = " + s);
                    Debug.Log("Output = " + t.output);
                    Debug.Log("OutputType = " + t.outputType);

                    
                    o.enabled = false;
                    audioSource.enabled = false;                    
                    texto.enabled = false;
                    
                    registered = true;

                    if(t.outputType == "Audio")
                    {
                        string filename = Path.GetFileName(t.output);
                        audioSource.enabled = true;
                        audiosI.gameObject.SetActive(true);
                        audiostext.enabled = true;
                        audiostext.text = filename;

                        show(audio, audiot);
                        hide(image, text, video, imaget, textt, videot);
                        
                        if(t.output == "Bell" || t.output == "Fire Alarm" || t.output == "Police Siren" || t.output == "Service Bell" || t.output == "SOS Morse Code")
                        {
                            string resource = "Audio/";
                            string audio = t.output;
                            string audioPath = String.Concat(resource, audio);
                            var audioClip = Resources.Load<AudioClip>(audioPath);
                            audioSource.clip = audioClip;
                            audioSource.Play();                            
                        }
                        else
                        {
                            MP3(t.output);
                        }

                        ri.gameObject.SetActive(false);
                        o.enabled = false;                        
                        texto.enabled = false;                       
                    }

                    if (t.outputType == "Image")
                    {
                        o.enabled = true;
                        
                        show(image, imaget);
                        hide(audio, text, video, audiot, textt, videot);

                        if (t.output == "Aid" || t.output == "Break Down" || t.output == "Fire" || t.output == "Flood" || t.output == "Home" || t.output == "Locked" || t.output == "Secure" || t.output == "Tire" || t.output == "Weather")
                        {
                            string resource = "Image/";
                            string image = t.output;
                            string imagePath = String.Concat(resource, image);
                            var sprite = Resources.Load<Sprite>(imagePath);
                            Sprite Isprite = Sprite.Create(sprite.texture, new Rect(0, 0, sprite.texture.width, sprite.texture.height), new Vector2(0.5f, 0.5f));
                            o.GetComponent<Image>().sprite = Isprite;
                        }
                        else
                        {
                            IMAGE(t.output);
                        }

                        audiosI.gameObject.SetActive(false);
                        ri.gameObject.SetActive(false);
                        audioSource.enabled = false;                        
                        texto.enabled = false;                        
                        audiostext.enabled = false;
                    }

                    if (t.outputType == "Video")
                    {
                        ri.gameObject.SetActive(true);                        
                        show(video, videot);
                        hide(image, text, audio, imaget, textt, audiot);

                        if (t.output == "atoms" || t.output == "candle" || t.output == "earth" || t.output == "particle")
                        {
                            RenderTexture rendertexture;
                            rendertexture = new RenderTexture(1920, 1080, 24);
                            ri = v.gameObject.GetComponent<RawImage>();
                            ri.texture = rendertexture;

                            string resource = "Video/";
                            string video = t.output;
                            string videoPath = String.Concat(resource, video);
                            var vc = Resources.Load<VideoClip>(videoPath);

                            v.clip = vc;
                            v.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
                            v.targetTexture = rendertexture;
                            v.Play();
                        }
                        else
                        {
                            VIDEO(t.output);
                        }

                        audiosI.gameObject.SetActive(false);
                        audioSource.enabled = false;
                        o.enabled = false;
                        texto.enabled = false;
                       
                        audiostext.enabled = false;
                    }

                    if (t.outputType == "Text")
                    {
                        
                        texto.enabled = true;

                        show(text, textt);
                        hide(image, audio, video, imaget, audiot, videot);

                        texto.text = t.output;

                        audiosI.gameObject.SetActive(false);
                        ri.gameObject.SetActive(false);
                        audioSource.enabled = false;
                        o.enabled = false;                       
                        
                        audiostext.enabled = false;
                    }
                }
            }
        }
    }
        
    public void VIDEO(string path)
    {
        RenderTexture rendertexture;
        rendertexture = new RenderTexture(1920, 1080, 24);

        
        ri = v.gameObject.GetComponent<RawImage>();
        ri.texture = rendertexture;

        WWW www = new WWW("file:///" + path);
        v.url = path;

        v.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture;
        v.targetTexture = rendertexture;
        v.Play();
    }

    public void IMAGE(string path)
    {
        Sprite Isprite;

        WWW www = new WWW("file:///" + path);
        Isprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
        o.GetComponent<Image>().sprite = Isprite;
    }

    public void MP3(string mPath)
    {       
        if (mPath.Length != 0)
        {           

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
            audioSource.Play();

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
