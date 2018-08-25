using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace 植物大战僵尸修改器_by照相_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            if (Helper.GetPidByProcessName(processName) == 0)
            {
                this.Text = "植物大战僵尸修改器-游戏未运行";
                this.BackColor = Color.Red;
                label4.Text = "游戏未运行";

            }
            else
            {
                this.Text = "植物大战僵尸修改器-游戏已运行";
                this.BackColor = Color.Blue;
                label4.Text = "游戏已运行";
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int address = ReadMemoryValue(baseAddress);             
            address = address + 0x768;                             
            address = ReadMemoryValue(address);
            address = address + 0x5560;
            try
            {
                WriteMemory(address, int.Parse(textBox1.Text));
            }
            catch {
                textBox1.Text = "";
                MessageBox.Show("您输入的数值非法，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        public int ReadMemoryValue(int baseAdd)
        {
            return Helper.ReadMemoryValue(baseAdd, processName);
        }
        
        public void WriteMemory(int baseAdd, int value)
        {
            Helper.WriteMemoryValue(baseAdd, processName, value);
        }
        private string processName = "PlantsVsZombies";
        private int baseAddress = 0x006A9EC0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Helper.GetPidByProcessName(processName) == 0)
            {
                this.Text = "植物大战僵尸修改器-游戏未运行";
                this.BackColor = Color.Red;
                label4.Text = "游戏未运行";

            }
            else
            {
                this.Text = "植物大战僵尸修改器-游戏已运行";
                this.BackColor = Color.Blue;
                label4.Text = "游戏已运行";
                int address = ReadMemoryValue(baseAddress);
                address = address + 0x768;
                address = ReadMemoryValue(address);
                address = address + 0x94;
                int address2 = ReadMemoryValue(baseAddress);
                address2 = address2 + 0x768;
                address2 = ReadMemoryValue(address2);
                address2 = address2 + 0xa0;
                label7.Text = "本局僵尸总数:" + ReadMemoryValue(address).ToString() + "个," + "当前僵尸数:" + ReadMemoryValue(address2).ToString()+"个";
                int address3 = ReadMemoryValue(baseAddress);
                address3 = address3 + 0x768;
                address3 = ReadMemoryValue(address3);
                address3 = address3 + 0x144;
                address3 = ReadMemoryValue(address3);
                address3 = address3 + 0x50;
                WriteMemory(address3, 0); 
               
                label8.Text = ReadMemoryValue(address3).ToString();
               

            }
            if (checkBox1.Checked)
            {
               
                int address = ReadMemoryValue(baseAddress);
                address = address + 0x768;
                address = ReadMemoryValue(address);
                address = address + 0x5560;
                WriteMemory(address, 9990); 
            }
            else {
               
            }
            if (checkBox2.Checked)
            {
               
                int address = ReadMemoryValue(baseAddress);
                address = address + 0x82C;
                address = ReadMemoryValue(address);
                address = address + 0x28;
                WriteMemory(address, 99999);
            }
            else
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int address = ReadMemoryValue(baseAddress);             //读取基址(该地址不会改变)
            address = address + 0x82C;                              //获取2级地址
            address = ReadMemoryValue(address);
            address = address + 0x28;                               //得到金钱地址
            try
            {
                WriteMemory(address, int.Parse(textBox2.Text) / 10);
            }
            catch {
                textBox2.Text = "";
                MessageBox.Show("您输入的数值非法，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int address = ReadMemoryValue(baseAddress);             
            address = address + 0x82C;                             
            address = ReadMemoryValue(address);
            address = address + 0x24;
            int a = 0;
            int b = 0;
            try{
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
            }catch{
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("您输入的数值非法，请重新输入" + "!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(a > 0 && a <= 6 && b > 0 && b <= 10)) {
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("您输入的数值非法，请重新输入" + "!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                WriteMemory(address, (int.Parse(textBox3.Text)-1) * 10 + int.Parse(textBox4.Text));
                MessageBox.Show("点击冒险模式即可直接跳到关卡" + textBox3.Text+"-"+textBox4.Text+"!", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch {
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("您输入的数值非法，请重新输入" + "!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                int address3 = ReadMemoryValue(baseAddress);
                address3 = address3 + 0x768;
                address3 = ReadMemoryValue(address3);
                address3 = address3 + 0xac;
                address3 = ReadMemoryValue(address3);
                address3 = address3 + 0x40;
                //label8.Text = ReadMemoryValue(address3).ToString();
                WriteMemory(address3, 9999999);
                
            }
            else
            {
                int address3 = ReadMemoryValue(baseAddress);
                address3 = address3 + 0x768;
                address3 = ReadMemoryValue(address3);
                address3 = address3 + 0xac;
                address3 = address3 + 0x44;
                WriteMemory(address3, 4);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                int address = ReadMemoryValue(baseAddress); //读取基址(该地址不会改变)
                address = address + 0x768; //获取2级地址
                address = ReadMemoryValue(address);
                address = address + 0x144;
                address = ReadMemoryValue(address);
                address = address + 0x070;
                label8.Text = ReadMemoryValue(address).ToString();
                WriteMemory(address, 0x01); //写入数据到地址
            }
            else {
                int address = ReadMemoryValue(baseAddress); //读取基址(该地址不会改变)
                address = address + 0x768; //获取2级地址
                address = ReadMemoryValue(address);
                address = address + 0x144;
                address = ReadMemoryValue(address);
                address = address + 0x070;
                WriteMemory(address, 0x1000); //写入数据到地址
            }
        }  
       
    }
}
