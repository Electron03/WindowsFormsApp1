using System;
using System.Windows.Forms;

// подключаем атрибут DllImport
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;

using static WindowsFormsApp1.enums;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options); // объявляем метод на C# 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetComputerName(StringBuilder lpBuffer, ref int lpnSize);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetUserName(StringBuilder buffer, ref uint size);
        [DllImport("kernel32")]
        public static extern int GetSystemDirectory(StringBuilder buf, int nMaxCount);
       
        private void UserName_Click(object sender, EventArgs e)
        {
            StringBuilder sr = new StringBuilder(255);
            UInt32 ir = (uint)sr.Capacity;
            GetUserName(sr, ref ir);
            MessageBox(this.Handle,sr.ToString(), "User Name", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sbBuf = new StringBuilder(128);
            Int32 intLen = (int)sbBuf.Capacity;
            GetComputerName(sbBuf, ref intLen);
            MessageBox(this.Handle, sbBuf.ToString(), "Mashina Name", 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sSystem = new StringBuilder(255);
            GetSystemDirectory(sSystem, sSystem.Capacity);
            MessageBox(this.Handle, sSystem.ToString(), "Mashina Name", 0);
        }
        [StructLayout(LayoutKind.Sequential)]
        public class OSVersionInfo
        {
            public uint dwOSVersionInfoSize;
            public uint dwMajorVersion;
            public uint dwMinorVersion;
            public uint dwBuildNumber;
            public uint dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public String szCSDVersion;
        }

        class Kernel
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetVersionEx([In, Out] OSVersionInfo info);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OSVersionInfo version = new OSVersionInfo();
            version.dwOSVersionInfoSize = (uint)Marshal.SizeOf(version);
            Kernel.GetVersionEx(version);
            MessageBox(this.Handle, version.dwBuildNumber.ToString(), "version", 0);
        }
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int metr = 16;
                    MessageBox(this.Handle, GetSystemMetrics(metr).ToString(), "Ширина и высота области приложения в полноэкранно", 0);
             
        }
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfoA")]
        static extern bool SystemParametersInfo(int uAction, ref int uParam, ref int lpvParam, int fuWinIni);
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void button6_Click(object sender, EventArgs e)
        {
            int uiParam = 0;
            int lpParam = 0;
            int param = 10; 
            bool sw = SystemParametersInfo(param, ref uiParam, ref lpParam, 0);

            if (sw)
            {
                MessageBox(this.Handle, lpParam.ToString(), "Интервал времени ожидания доступности", 0);
            }
            else {
                int error = Marshal.GetLastWin32Error();
                MessageBox(this.Handle, "Ошибка"+error.ToString(), "Интервал времени ожидания доступности", 0);
            }
        }
        [DllImport("user32.dll")]
        static extern uint GetSysColor(enums.SystemElementsToColor nIndex);
        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaColors);
        List<ItemColor> listSystemColors = new List<ItemColor>();
        List<ItemColor> saveSystemColors()
        {
            List<ItemColor> list = new List<ItemColor>();//список системных цветов
            foreach (SystemElementsToColor se in comboBox1.Items)
            {
                int color1 = Convert.ToInt32(GetSysColor(se));
                Color color = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
                list.Add(new ItemColor(se.ToString(), color));

            }
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillComboBoxes();//заполнение comboBox
            listSystemColors = saveSystemColors();//сохраним начальные системные цвета
        }
        void fillComboBoxes()
        {
            comboBox1.DataSource = Enum.GetValues(typeof(WindowsFormsApp1.enums.SystemElementsToColor));
            comboBox1.SelectedItem = null;
            comboBox1.Text = "Выберите элемент";
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    comboBox2.Items.Add(prop.Name);
                }
            }
            comboBox2.SelectedItem = null;
            comboBox2.Text = "Выберите цвет";
        }

      
        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                Color newColor = Color.FromName(comboBox2.SelectedItem.ToString());
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), comboBox1.SelectedItem.ToString());

                listSystemColors.ForEach(x =>
                {
                    if (x.ItemName == item.ToString())
                    {
                        
                        SetSysColors(1, new int[] { (int)item }, new int[] { System.Drawing.ColorTranslator.ToWin32(newColor) });
                        x.HasChanged = true;
                        MessageBox(this.Handle, newColor.ToString(), "COLOR_CAPTIONTEXT", 0);
                       
                    }
                });

            }
            else { System.Windows.Forms.MessageBox.Show("What?"); }
        }
        void GetSystemColor()
        {
            if (comboBox1.SelectedItem != null)
            {
                //элемент выбранный из списка
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), comboBox1.SelectedItem.ToString());
                //возвращает RGB цвет элемента item 
                int color1 = Convert.ToInt32(GetSysColor(item));
                //преобразование RGB в Color
                Color color = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
                //String s = Color.FromName(color);
                Color sd = Color.FromName(ColorTranslator.ToHtml(color));
                
                MessageBox(this.Handle,sd.ToString(), "COLOR_CAPTIONTEXT", 0);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            listSystemColors.ForEach(x =>
            {
                if (x.HasChanged)
                {
                    Color oldColor = x.IItemColor;
                    SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), x.ItemName);
                    SetSysColors(1, new int[] { (int)item }, new int[] { System.Drawing.ColorTranslator.ToWin32(oldColor) });
                    x.HasChanged = false;
                }
            });
          
        }
        private void button7_Click(object sender, EventArgs e)
        {
            GetSystemColor();
        }
        [DllImport("kernel32.dll")]
        static extern void GetTimeZoneInformation(ref TIME_ZONE_INFORMATION lpTimeZoneInformation);
        [DllImport("Kernel32")]
        public static extern int GetTickCount();
        private void button12_Click(object sender, EventArgs e)
        {
            int t = GetTickCount();
            MessageBox(this.Handle, t.ToString(), "GetTickCount ", 0);

        }

        struct SYSTEMTIME
        {
            internal Int16 wYear;
            internal Int16 wMonth;
            internal Int16 wDayOfWeek;
            internal Int16 wDay;
            internal Int16 wHour;
            internal Int16 wMinute;
            internal Int16 wSecond;
            internal Int16 wMilliseconds;
        }

        struct TIME_ZONE_INFORMATION
        {
            internal Int32 Bias;
            internal String StandardName;
            internal SYSTEMTIME StandardDate;
            internal Int32 StandardBias;
            internal String DaylightName;
            internal SYSTEMTIME DaylightDate;
            internal Int32 DaylightBias;
        }
        [DllImport("kernel32.dll")]
        static extern void GetLocalTime(ref SYSTEMTIME lpSystemTime);
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void button8_Click(object sender, EventArgs e)
        {
            SYSTEMTIME syst = new SYSTEMTIME();
            GetLocalTime(ref syst);
           
            switch (syst.wDayOfWeek)
            {
                case 1:
                    MessageBox(this.Handle, "Понедельник", "GetTickCount ", 0);
                    break;
                case 2:
                    MessageBox(this.Handle, "Вторник", "GetTickCount ", 0);
                    break;
                case 3:
                    MessageBox(this.Handle, "Среда", "GetTickCount ", 0);
                    break;
                case 4:
                    MessageBox(this.Handle, "Четверг", "GetTickCount ", 0);
                    break;
                case 5:
                    MessageBox(this.Handle, "Пятница", "GetTickCount ", 0);
                    break;
                case 6:
                    MessageBox(this.Handle, "Суббота", "GetTickCount ", 0);
                    break;
                case 7:
                    MessageBox(this.Handle, "Воскресение", "GetTickCount ", 0);
                    break;
            }
        }
       

        private void button9_Click(object sender, EventArgs e)
        {
            TIME_ZONE_INFORMATION time1 = new TIME_ZONE_INFORMATION();
            GetTimeZoneInformation(ref time1);
            MessageBox(this.Handle, time1.StandardName, "GetTickCount ", 0);
        }
        [DllImport("kernel32.dll")]
        public static extern uint GetUserDefaultLCID();

        private void button13_Click(object sender, EventArgs e)
        {
            uint lcid = GetUserDefaultLCID();
            MessageBox(this.Handle,lcid.ToString(), "GetTickCount ", 0);

        }

        
        [DllImport("user32.dll")]
        public static extern int GetKeyboardLayoutList(int nBuff, [Out] IntPtr[] lpList);
        private void button14_Click(object sender, EventArgs e)
        {
            int count = GetKeyboardLayoutList(0, null);
            String s=null;
            // Выделение памяти под массив указателей для хранения раскладок клавиатуры
            IntPtr[] layouts = new IntPtr[count];
            foreach (IntPtr layout in layouts)
            {
                int layoutInt = layout.ToInt32();
                s = s + layoutInt.ToString()+" ";
            }
            label1.Text = "Available Keyboard Layouts " + s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowCursor(bool bShow);
        private void button15_Click(object sender, EventArgs e)
        {
            ShowCursor(false);
            MessageBox(this.Handle, "Курсор скрыт", "ShowCursor ", 0);
            // Ждем 3 секунды
            System.Threading.Thread.Sleep(3000);

            // Отобразить курсор
            ShowCursor(true);
            MessageBox(this.Handle, "Курсор отображен", "ShowCursor ", 0);
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SetLocaleInfo(uint Locale, uint LCType, string lpLCData);
        const uint LOCALE_USER_DEFAULT = 0x0400;
        const uint LOCALE_SSHORTDATE = 0x1F;
        private void button16_Click(object sender, EventArgs e)
        {
            string newShortDateFormat = "MM/dd/yyyy";
            bool success = SetShortDateFormat(newShortDateFormat);
            if (success)
            {
                MessageBox(this.Handle, "Формат короткой даты успешно изменен", "SetLocaleInfo ", 0);
            }
            else
            {
                MessageBox(this.Handle, "Произошла ошибка при изменении формата короткой даты", " SetLocaleInfo ", 0);
            }
        }
        static bool SetShortDateFormat(string dateFormat)
        {
            return SetLocaleInfo(LOCALE_USER_DEFAULT, LOCALE_SSHORTDATE, dateFormat);
        }
    }

}
