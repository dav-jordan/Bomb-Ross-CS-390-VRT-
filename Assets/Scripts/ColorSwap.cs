using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColorSwap : MonoBehaviour
{
    Color HexColor(uint hex) { return new Color((hex >> 16) & 255, (hex >> 8) & 255, hex & 255); }

    public const Color SAP_GREEN = HexColor(0x0a3410);
    public const Color ALIZARIN_CRIMSON = HexColor(0x4e1500);
    public const Color VAN_DYKE_BROWN = HexColor(0x221b15);
    public const Color DARK_SIENNA = HexColor(0x5f2e1f);
    public const Color MIDNIGHT_BLACK = HexColor(0x000000);
    public const Color PRUSSIAN_BLUE = HexColor(0x021e44);
    public const Color PHTHALO_BLUE = HexColor(0x0c0040);
    public const Color PHTHALO_GREEN = HexColor(0x102e3c);
    public const Color CADMIUM_YELLOW = HexColor(0xffec00);
    public const Color YELLOW_OCHRE = HexColor(0xc79b00);
    public const Color INDIAN_YELLOW = HexColor(0xffb800);
    public const Color BRIGHT_RED = HexColor(0xdb0000);
    public const Color TITANIUM_WHITE = HexColor(0xffffff);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
