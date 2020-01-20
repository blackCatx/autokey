using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HotKeySample
{
    public partial class Form_Display : Form
    {
        public Form_Display()
        {
            InitializeComponent();
        }

        private string[] sarrayMods = null;             //组合键
        private Keys key=new Keys();                    //热键

        private const int nHotKeyStartID = 0xabdd;           //热键标识
        private const int nHotKeyStopID  = 0xabde;           //热键标识
        private const int nHotKeySpeedID = 0xabdf;           //热键标识

        int nTimes = 0;

        private void textBox_Key_KeyDown(object sender, KeyEventArgs e)
        {
            string sOutput = "";
            if (e.Modifiers.ToString().Length > 0 && e.Modifiers.ToString() != "None")
            {
                sOutput = e.Modifiers.ToString().Replace("Control", "Ctrl");
                sarrayMods = Regex.Split(sOutput, ",");
                sOutput = sOutput.Replace(",", " + ") + " + ";
            }
            if (e.KeyValue != 17 && e.KeyValue != 18 && e.KeyValue != 97)
            {
                sOutput = sOutput + e.KeyCode.ToString();
                key = e.KeyCode;
            }

            this.textBox_Key.Text = sOutput;
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            //             int nModKey = 0;
            //             if (sarrayMods.Length > 0)
            //             {
            //                 for (int i = 0; i < sarrayMods.Length; i++)
            //                 {
            //                     switch (sarrayMods[i])
            //                     {
            //                         case "Alt":
            //                             nModKey = nModKey |(int) HotKey.MOD.MOD_ALT;
            //                             break;
            //                         case "Ctrl":
            //                             nModKey = nModKey | (int)HotKey.MOD.MOD_CTRL;
            //                             break;
            //                         case "Shift":
            //                             nModKey = nModKey | (int)HotKey.MOD.MOD_SHIFT;
            //                             break;
            //                     }
            //                 }
            //             }
            // 
            //             if (HotKey.RegHotKey(this.Handle, nHotKeyStartID, nModKey, key))
            //                 MessageBox.Show("热键设置成功！");
            //             else
            //                 MessageBox.Show("热键设置失败！");

            ShootLoop.startRunSpeedAutoKey();
        }

        /// <summary>
        /// 重写WndProc响应热键方法
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case nHotKeyStartID:
                    Method();       //热键调用的方法
                    break;
                case nHotKeyStopID:
                    MethodStop();       //热键调用的方法
                    break;
                case nHotKeySpeedID:
                    MethodSpeed();
                    break;
            }

            base.WndProc(ref m);
        }

        private void MethodSpeed()
        {
            nTimes++;
            Random random = new Random();
            int nRoll = random.Next(1, 100);
            string sText = "第 " + nTimes.ToString() + " 次按下热键，本次得到点数:[ " + nRoll.ToString() + " ]";
            this.label_text.Text = sText;

            ShootLoop.startRunSpeedAutoKey();


        }


        /// <summary>
        /// 热键调用的方法
        /// </summary>
        private void Method()
        {
            nTimes++;
            Random random = new Random();
            int nRoll = random.Next(1, 100);
            string sText = "第 " + nTimes.ToString() + " 次按下热键，本次得到点数:[ " + nRoll.ToString() + " ]";
            this.label_text.Text = sText;

            ShootLoop.startRunAutoKey();


        }

        private void MethodStop()
        {
            nTimes++;
            Random random = new Random();
            int nRoll = random.Next(1, 100);
            string sText = "第 " + nTimes.ToString() + " 次按下热键，本次得到点数:[ " + nRoll.ToString() + " ]";
            this.label_text.Text = sText;


            ShootLoop.stopRunAutoKey();


        }

        private void textBox_Key_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string sOutput = "";
            if (e.Modifiers.ToString().Length > 0 && e.Modifiers.ToString() != "None")
            {
                sOutput = e.Modifiers.ToString().Replace("Control", "Ctrl");
                sarrayMods = Regex.Split(sOutput, ",");
                sOutput = sOutput.Replace(",", " + ") + " + ";
            }
            if (e.KeyValue != 17 && e.KeyValue != 18 && e.KeyValue != 97)
            {
                sOutput = sOutput + e.KeyCode.ToString();
                key = e.KeyCode;
            }

            this.textBox_Key.Text = sOutput;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nModKey = 0;
            if (sarrayMods.Length > 0)
            {
                for (int i = 0; i < sarrayMods.Length; i++)
                {
                    switch (sarrayMods[i])
                    {
                        case "Alt":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_ALT;
                            break;
                        case "Ctrl":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_CTRL;
                            break;
                        case "Shift":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_SHIFT;
                            break;
                    }
                }
            }

            if (HotKey.RegHotKey(this.Handle, nHotKeyStopID, nModKey, key))
                MessageBox.Show("热键设置成功！");
            else
                MessageBox.Show("热键设置失败！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nModKey = 0;
            if (sarrayMods.Length > 0)
            {
                for (int i = 0; i < sarrayMods.Length; i++)
                {
                    switch (sarrayMods[i])
                    {
                        case "Alt":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_ALT;
                            break;
                        case "Ctrl":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_CTRL;
                            break;
                        case "Shift":
                            nModKey = nModKey | (int)HotKey.MOD.MOD_SHIFT;
                            break;
                    }
                }
            }

            if (HotKey.RegHotKey(this.Handle, nHotKeySpeedID, nModKey, key))
                MessageBox.Show("热键设置成功！");
            else
                MessageBox.Show("热键设置失败！");
        }

        private void Form_Display_Load(object sender, EventArgs e)
        {

            HotKey.RegHotKey(this.Handle, nHotKeyStartID, (int)HotKey.MOD.MOD_CTRL, Keys.A);
            HotKey.RegHotKey(this.Handle, nHotKeyStopID, (int)HotKey.MOD.MOD_CTRL, Keys.S);
            HotKey.RegHotKey(this.Handle, nHotKeySpeedID, (int)HotKey.MOD.MOD_CTRL, Keys.D);
        }
    }
}
