using TMPro;
using UnityEngine;

public class BoxWidget : MonoBehaviour
{
    [Header("Quadrant Texts")]
    public TMP_Text redText;
    public TMP_Text yellowText;
    public TMP_Text blueText;
    public TMP_Text greenText;

    public void SetMark(NoteColor color, bool on, string mark = "1")
    {
        switch (color)
        {
            case NoteColor.Red: redText.text = on ? mark : ""; break;
            case NoteColor.Yellow: yellowText.text = on ? mark : ""; break;
            case NoteColor.Blue: blueText.text = on ? mark : ""; break;
            case NoteColor.Green: greenText.text = on ? mark : ""; break;

        }
    }

    public void ClearAll()
    {
        redText.text = yellowText.text = blueText.text = greenText.text = "";
    }
}
