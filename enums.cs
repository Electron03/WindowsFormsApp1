using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class enums
    {
        public enum SystemMetrics
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F
            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001
            SM_CONVERTIBLESLATEMODE = 0x2003,
            SM_SYSTEMDOCKED = 0x2004,
        }
        public enum SystemElementsToColor
        {
          
            COLOR_3DLIGHT = 22,//Light color for three-dimensional display elements(for edges facing the light source.)
            COLOR_GRADIENTINACTIVECAPTION = 28,//Right side color in the color gradient of an inactive window's title bar. COLOR_INACTIVECAPTION specifies the left side color.
            COLOR_MENU = 4,//Menu background. The associated foreground color is COLOR_MENUTEXT
        }
        /*    public enum ColorFromRGB { 
                maroon=	"#800000,
    dark red	#8B0000
    brown	#A52A2A
    firebrick	#B22222
    crimson	#DC143C
    red	#FF0000
    tomato	#FF6347
    coral	#FF7F50
    indian red	#CD5C5C
    light coral	#F08080
    dark salmon	#E9967A
    salmon	#FA8072
    light salmon	#FFA07A
    orange red	#FF4500
    dark orange	#FF8C00
    orange	#FFA500
    gold	#FFD700
    dark golden rod	#B8860B
    golden rod	#DAA520
    pale golden rod	#EEE8AA
    dark khaki	#BDB76B
    khaki	#F0E68C
    olive	#808000
    yellow	#FFFF00
    yellow green	#9ACD32
    dark olive green	#556B2F
    olive drab	#6B8E23
    lawn green	#7CFC00
    chart reuse	#7FFF00
    green yellow	#ADFF2F
    dark green	#006400
    green	#008000
    forest green	#228B22
    lime	#00FF00
    lime green	#32CD32
    light green	#90EE90
    pale green	#98FB98
    dark sea green	#8FBC8F
    medium spring green	#00FA9A
    spring green	#00FF7F
    sea green	#2E8B57
    medium aqua marine	#66CDAA
    medium sea green	#3CB371
    light sea green	#20B2AA
    dark slate gray	#2F4F4F
    teal	#008080
    dark cyan	#008B8B
    aqua	#00FFFF
    cyan	#00FFFF
    light cyan	#E0FFFF
    dark turquoise	#00CED1
    turquoise	#40E0D0
    medium turquoise	#48D1CC
    pale turquoise	#AFEEEE
    aqua marine	#7FFFD4
    powder blue	#B0E0E6
    cadet blue	#5F9EA0
    steel blue	#4682B4
    corn flower blue	#6495ED
    deep sky blue	#00BFFF
    dodger blue	#1E90FF
    light blue	#ADD8E6
    sky blue	#87CEEB
    light sky blue	#87CEFA
    midnight blue	#191970
    navy	#000080
    dark blue	#00008B
    medium blue	#0000CD
    blue	#0000FF
    royal blue	#4169E1
    blue violet	#8A2BE2
    indigo	#4B0082
    dark slate blue	#483D8B
    slate blue	#6A5ACD
    medium slate blue	#7B68EE
    medium purple	#9370DB
    dark magenta	#8B008B
    dark violet	#9400D3
    dark orchid	#9932CC
    medium orchid	#BA55D3
    purple	#800080
    thistle	#D8BFD8
    plum	#DDA0DD
    violet	#EE82EE
    magenta / fuchsia	#FF00FF
    orchid	#DA70D6
    medium violet red	#C71585
    pale violet red	#DB7093
    deep pink	#FF1493
    hot pink	#FF69B4
    light pink	#FFB6C1
    pink	#FFC0CB
    antique white	#FAEBD7
    beige	#F5F5DC
    bisque	#FFE4C4
    blanched almond	#FFEBCD
    wheat	#F5DEB3
    corn silk	#FFF8DC
    lemon chiffon	#FFFACD
    light golden rod yellow	#FAFAD2
    light yellow	#FFFFE0
    saddle brown	#8B4513
    sienna	#A0522D
    chocolate	#D2691E
    peru	#CD853F
    sandy brown	#F4A460
    burly wood	#DEB887
    tan	#D2B48C
    rosy brown	#BC8F8F
    moccasin	#FFE4B5
    navajo white	#FFDEAD
    peach puff	#FFDAB9
    misty rose	#FFE4E1
    lavender blush	#FFF0F5
    linen	#FAF0E6
    old lace	#FDF5E6
    papaya whip	#FFEFD5
    sea shell	#FFF5EE
    mint cream	#F5FFFA
    slate gray	#708090
    light slate gray	#778899
    light steel blue	#B0C4DE
    lavender	#E6E6FA
    floral white	#FFFAF0
    alice blue	#F0F8FF
    ghost white	#F8F8FF
    honeydew	#F0FFF0
    ivory	#FFFFF0
    azure	#F0FFFF
    snow	#FFFAFA
    black	#000000
    dim gray / dim grey	#696969
    gray / grey	#808080
    dark gray / dark grey	#A9A9A9
    silver	#C0C0C0
    light gray / light grey	#D3D3D3
    gainsboro	#DCDCDC
    white smoke	#F5F5F5
    white	#FFFFFF
    */
    }
}
