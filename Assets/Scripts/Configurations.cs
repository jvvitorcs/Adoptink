using UnityEngine;
using System.Collections;

class Configurations : MonoBehaviour
{
    public GameObject configs;
    
    public void ActiveConfigs()
        {
            if (configs.activeSelf)
            {
                configs.SetActive(false);
            }
            else
            {
                configs.SetActive(true);
            }
        }
    }

