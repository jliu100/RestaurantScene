using UnityEngine;

public class BinSwitch : MonoBehaviour
{
    public int selectedBin = 1;
    public Transform vrCamera;

    // Start is called before the first frame update
    void Start()
    {
        SelectBin();
    }

    // Update is called once per frame
    void Update()
    {
        int previousBin = selectedBin;
       

        if (vrCamera.eulerAngles.x < 41.0f && vrCamera.eulerAngles.x > 40.0f)
        {
            if (selectedBin >= transform.childCount - 1)
                selectedBin = 1;
            else
                selectedBin++;
        }
        if (vrCamera.eulerAngles.x < 350.0f && vrCamera.eulerAngles.x >345.0f)
        {
            if (selectedBin <= 1)
                selectedBin = transform.childCount -1;
            else
                selectedBin--;
        }

        if (previousBin != selectedBin)
            SelectBin();
    }
    void SelectBin()
    {
        int i = 0;
        foreach(Transform bin in transform)
        {

            if (i == selectedBin)
                bin.gameObject.SetActive(true);
            else if (i== 0)
            {
                bin.gameObject.SetActive(true);
            }
            else
                bin.gameObject.SetActive(false);
            i++;
        }
    }
}
