using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalLink : MonoBehaviour
{
    public void OpenWebsite(string url)
    {
        Application.OpenURL("https://scythedragonstudios.github.io/privacypolicy/");
    }
}
