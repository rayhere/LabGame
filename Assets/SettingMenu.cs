using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Audio;
using TMPro;
// Dropdown is a UI element
// to refenrence an audio mixer
// TMP namespace because we use TMPro.TMP_Dropdown resolutionDropdown;

// SettingMenu
// https://www.youtube.com/watch?v=YOaYQrN1oYQ

// Resolution Dropdown
// (refresh rate)
// https://www.youtube.com/watch?v=HnvPNoU9Wjw
public class SettingMenu : MonoBehaviour
{
    // To add action to event for VolumeSlider
    // Go to the VolumeSlider, inside Slider > On Value Changed > (click + sign)
    // Then drag the object (Canvas) that this script is sitting on, 
    // Then set the function, SettingMenu > SetVolume
    // Don't forget Set Min Value to -80, Max Value to 0. For VolumeSilder
    // Assign Silder to Window > Audio Mixer
    // in Audio Mixer (window), click + sign, will create a mixer in the project (catalog)
    // Rename the mixer (object in Project) to MainMixer
    // To expose volume parameter, select the master group (Inspector of Audio Mixer), 
    // right click the volume (under Attenuation), and select Expose "Volume (of Master)" to script
    // in the Audio Mixer (window), on the top right, there have Exposed Parmeters (1),
    // click on Exposed Parmeters(1), there have one parameter named, MyExposedParam
    // right click on it and rename it to, volume
    // To change our volume on the mixer, to do that 

    // need a reference to audio mixer
    // create variable AudioMixer, named, audioMixer
    // After created, drag the MainMixer (inside project (catalog)), 
    // to the slot inside the Settings Menu (script) that is the script (this) sitting on (Canvas) 
    //public AudioMixer audioMixer;

    // create a variable that will reference UI element


    // will create an empty spot for a resolutionDropdown
    // public Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown resolutionDropdown;

    // create a list of all the resolutions
    Resolution[] resolutions;

    // create variable for RefreshRate;
    private float currentRefreshRate;

    void Start ()
    {
        // Screen.resolutions that contain all resolutions supported
        // Store all possible resolutions (variable) to a Resolution[] list, named, resolutions
        resolutions = Screen.resolutions;

        // clear out the default options that inside the dropdown
        // call the function, ClearOptions();
        // 1. clear out all the options in our resolution dropdown 
        resolutionDropdown.ClearOptions();

        // set currentRefreshRate
        currentRefreshRate = Screen.currentResolution.refreshRate;

        // To turn array of resolutions (Resolution[] resolution = Screen.resolutions;
        // into a list of string, List<string> options, dynamic size
        // 2. create a list of strings which is going to be our options
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        // 3. we then loop through each element in our resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // 4. for each of them we create a formatted string that displays our resolution
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + currentRefreshRate + " Hz";
            // Add each option into List<string> options
            // options is List<String>, to call its variable, use method
            // 4.5 and we add it (option) to our options list 
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // to Add options that inside the dropdown
        // call the function/ method, AddOptions();
        // AddOptions takes in a list of strings
        // Add List<string> options into resolutionsDropdown
        // 5. when we're done looping through, 
        // 5.1 we'll add our options list to our resolution drop down if we save 
        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // this is a function
    // to use it, drap our canvas (object) which contain this script,
    // go under settings menu to find ResolutionDropdown, 
    // and choose set resolution as the function
    public void SetResolution (int resolutionIndex)
    {
        // to get the width and the height
        // simply use a resolution index to find the correct element in our resolutions array 
        // Resolution[] resolutions;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float  volume)
    {
        // "volume", is the Exposed Parmeter of the Audio Mixer, renamed as "volume"
        // set the float value, named, volume
        //audioMixer.SetFloat("volume", volume);
        // Debug.Log(volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("QualitySettings change to : " + qualityIndex);
    }

    // this is a function
    // to use it, drag the script (this) sitting on (Canvas), 
    // and drag the Canvas (object into the Toggle (Fullscreen Toggle) function object
    // where Toggle > On Value Changed (Boolean), click add and drag the Canvas (object) in
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
