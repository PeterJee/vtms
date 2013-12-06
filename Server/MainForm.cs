using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
namespace VTMS
{
    public partial class MainForm : Form
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        System.Timers.Timer timer = new System.Timers.Timer(ONE_HOUR);

        string homePath = new System.IO.DirectoryInfo(".").FullName;
        string parentPath = new System.IO.DirectoryInfo(".").Parent.FullName;

        const int ONE_MINUTE = 1000 * 60;
        const int FIVE_MINUTES = 5 * ONE_MINUTE;
        const int TEN_MINUTES = 10 * ONE_MINUTE;
        const int THIRTY_MINUTES = 30 * ONE_MINUTE;
        const int ONE_HOUR = 60 * ONE_MINUTE;
        const int ONE_DAY = 24 * ONE_HOUR;

        public MainForm()
        {
            #region 初始化定时器
            InitializeComponent();
            //this.timeSetup.DataSource = new string[]{"每5分钟","每10分钟","每30分钟","每1小时"};
            //this.timeSetup.Text = "每1小时";

            timer.Elapsed += new System.Timers.ElapsedEventHandler(timeOut);
            timer.AutoReset = true;
            timer.Enabled = true;
            #endregion

            #region 初始化数据库配置
            if (!File.Exists(parentPath + "\\my.ini"))
            {
                SetPath(homePath);
                StreamReader sr = new StreamReader(parentPath + "\\temp.ini");

                FileStream fs = new FileStream(parentPath + "\\my.ini", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                string line = null;
                while((line = sr.ReadLine())!=null){
                    if(line.StartsWith("basedir")){
                        line = line + "\"" + parentPath + "\\\"";
                    }
                    else if (line.StartsWith("datadir"))
                    {
                        line = line + "\"" + parentPath + "\\" + "Data\\\"";
                    }
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
                sr.Close();

                if (File.Exists(parentPath + "\\setup.bat"))
                {
                    StartCmd(parentPath, "setup.bat");

                    File.Delete(parentPath + "\\setup.bat");
                }
                if (File.Exists(parentPath + "\\vtms.sql"))
                {
                    string command = "mysql -uroot -pjilichao < \"" + parentPath + "\\vtms.sql";
                    StartCmd(homePath, command);

                    File.Delete(parentPath + "\\vtms.sql");
                }
            }
            #endregion

            #region 默认备份目录为当前目录
            if (config.AppSettings.Settings["backupPath"] != null)
            {
                backupPath.Text = config.AppSettings.Settings["backupPath"].Value;
            }
            else
            {
                backupPath.Text = parentPath;
            }
            #endregion
        }
        /// <summary>
        /// 获取系统环境变量
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetSysEnvironmentByName(string name)
        {
            string result = string.Empty;
            try
            {
                result = OpenSysEnvironment().GetValue(name).ToString();//读取
            }
            catch (Exception)
            {

                return string.Empty;
            }
            return result;

        }
        /// <summary>
        /// 打开系统环境变量注册表
        /// </summary>
        /// <returns>RegistryKey</returns>
        private static RegistryKey OpenSysEnvironment()
        {
            RegistryKey regLocalMachine = Registry.LocalMachine;
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//打开HKEY_LOCAL_MACHINE下的SYSTEM 
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//打开ControlSet001 
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//打开Control 
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//打开Control 

            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);
            return regEnvironment;
        }
        /// <summary>
        /// 设置系统环境变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <param name="strValue">值</param>
        public static void SetSysEnvironment(string name, string strValue)
        {
            OpenSysEnvironment().SetValue(name, strValue);

        }
        public static void SetPath(string strHome)
        {
            string pathlist = GetSysEnvironmentByName("PATH");
            if (!pathlist.Contains(strHome))
            {
                if(!pathlist.EndsWith(";"))
                    pathlist += ";";
                pathlist += strHome;
                SetSysEnvironment("PATH", pathlist);
            }

        }
        #region 最小化图标
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
                this.notifyIcon.ShowBalloonTip(3500, "提示", "双击恢复窗口", ToolTipIcon.Info); 
                this.ShowInTaskbar = false; 
            }
        }
        /// <summary>
        /// 托盘中图标的双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
        }
        #endregion


        #region 调用终端命令
        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        /// <param name="workingDirectory">要启动的进程的目录</param>
        /// <param name="command">要执行的命令</param>
        public static bool StartCmd(String workingDirectory, String command)
        {
            bool result = false;
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c " + command;
                p.StartInfo.WorkingDirectory = workingDirectory;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();

                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行操作出错，错误信息为：" + ex.Message);
                result = false;
            }
            return result;
        }
        #endregion

        /// <summary>
        /// 点击关闭按钮时的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region 恢复数据库
        /// <summary>
        /// 选择恢复文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restorePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "备份文件|*.sql";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                this.restorePath.Text = fileDlg.FileName;
            }
        }
        /// <summary>
        /// 点击恢复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreBtn_Click(object sender, EventArgs e)
        {
            if (this.restorePath.Text.Length > 0)
            {
                string command = "mysql -uroot -pjilichao vtms < \"" + this.restorePath.Text +"\"";

                if (StartCmd(homePath, command))
                {
                    MessageBox.Show("恢复成功！");
                }
                else
                {
                    MessageBox.Show("恢复失败！");
                }
            }
        }
        #endregion

        #region 备份数据库
        /// <summary>
        /// 选择备份目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                this.backupPath.Text = folderDlg.SelectedPath;

                if (config.AppSettings.Settings["backupPath"] == null)
                {
                    config.AppSettings.Settings.Add("backupPath", backupPath.Text);
                }
                else
                {
                    config.AppSettings.Settings["backupPath"].Value = backupPath.Text;
                }
                config.Save();
            }
        }
        /// <summary>
        /// 备份按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backupBtn_Click(object sender, EventArgs e)
        {
            if (this.backupPath.Text.Length > 0)
            {
                string command = "mysqldump -uroot -pjilichao --default-character-set=utf8 --opt --extended-insert=false --quick --triggers -R --hex-blob vtms > \"" + this.backupPath.Text + "\"\\vtms.sql";

                if (StartCmd(homePath, command))
                {
                    MessageBox.Show("备份成功！");
                }
                else
                {
                    MessageBox.Show("备份失败！");
                }
            }
        }
        /// <summary>
        /// 设置备份频率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            //if (this.timeSetup.Text == "每5分钟")
            //{
            //    timer.Interval = FIVE_MINUTES;
            //}
            //else if (this.timeSetup.Text == "每10分钟")
            //{
            //    timer.Interval = TEN_MINUTES;
            //} if (this.timeSetup.Text == "每30分钟")
            //{
            //    timer.Interval = THIRTY_MINUTES;
            //} if (this.timeSetup.Text == "每1小时")
            //{
            //    timer.Interval = ONE_HOUR;
            //} 
        }
        /// <summary>
        /// 定时备份数据库
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void timeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.backupPath.Text.Length > 0)
            {
                string command = "mysqldump -uroot -pjilichao --default-character-set=utf8 --opt --extended-insert=false --quick --triggers -R --hex-blob vtms > \"" + this.backupPath.Text + "\"\\vtms.sql";

                StartCmd(homePath, command);
            }
        }
        #endregion
    }
}
