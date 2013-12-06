using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Collections;
namespace VTMS.Common
{
    public class Utilities
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static byte[] ConvertImage2Bytes(Image image)
        {
            if (image == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            imagedata = ms.GetBuffer();
            return imagedata;

        }

        public static Image ConvertBytes2Image(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            return img;
        }

        public static bool IsNullOrEmpty(string str)
        {
            if (str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Md5Encrypt(string password)
        {
            
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            string result = BitConverter.ToString(bytes).Replace("-", "");
            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    result += bytes[i].ToString("X");
            //}
            return result;
        }

        public static string Base64Dencrypt(string password)
        {
            byte[] output = Convert.FromBase64String(password);
            return Encoding.Default.GetString(output);
        }

        public static string Base64Encrypt(string password)
        {
            byte[] bytes = Encoding.Default.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveConfig(string key, string value)
        {
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
        }

        public static string GetConfigValue(string key)
        {
            if (config.AppSettings.Settings[key] != null)
                return config.AppSettings.Settings[key].Value;
            else
                return null;
        }
        public static void RemoveConfigValue(string key)
        {
            config.AppSettings.Settings.Remove(key);
        }

        public static void Save()
        {
            config.Save(ConfigurationSaveMode.Modified);
        }
        public static string GeneratePassword()
        {
            string pwdchars = "abcdefgh0123456789ijklmnopqrs0123456789tuvwxyz0123456789_ABCDEFG0123456789HIJKLMNOPQ0123456789RSTUVWXYZ";
            int pwdlen = 12;

            
            string tmpstr = "";
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        public static void sendEmail(string mailTo, string newPassword)
        {
            //mail message

            MailMessage mymail = new MailMessage();

            mymail.From = new MailAddress("pomelover@gmail.com"); //发送邮件的地址

            mymail.To.Add(new MailAddress(mailTo));  //接收邮件的地址

            mymail.Subject = "新密码已生成";

            mymail.SubjectEncoding = Encoding.UTF8;

            mymail.Body = @"亲爱的用户：你好！
    您的密码已经设置为：" + newPassword + "，请您及时修改！";
            ;

            mymail.BodyEncoding = Encoding.UTF8;

            mymail.IsBodyHtml = false;

            //smtp client

            SmtpClient sender = new SmtpClient();

            sender.Host = "smtp.gmail.com";

            sender.Port = 587;

            sender.Credentials = new NetworkCredential("pomelover@gmail.com", "jilichao1001"); //邮箱名及密码

            sender.DeliveryMethod = SmtpDeliveryMethod.Network;

            sender.EnableSsl = true;   //无加密功能的邮箱一般设为false


            try
            {
                sender.Send(mymail);

                //console.writeline("success");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        /// <summary>
        /// 查找特定控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public static List<Control> findControl(Control control, Type t)
        {
            List<Control> list = new List<Control>();
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == t)
                {
                    list.Add(c);
                }
                else if (c.Controls.Count > 0)
                {
                    List<Control> l = findControl(c, t);
                    foreach (Control cc in l)
                    {
                        list.Add(cc);
                    }
                }
            }
            return list;
        }

        public static Hashtable GetAllCtrlStates(Control CrlContainer)//获得并存储窗体中各控件的初始位置
        {
            Hashtable statesOfAllCtrl = new Hashtable();
            foreach (Control iCrl in CrlContainer.Controls)
            {
                statesOfAllCtrl.Add(iCrl, new SizeAndPosition(iCrl.Width, iCrl.Height, iCrl.Location.X, iCrl.Location.Y));
                if (iCrl.Controls.Count > 0)
                {
                    Hashtable children =  GetAllCtrlStates(iCrl);
                    foreach (DictionaryEntry child in children)
                    {
                        statesOfAllCtrl.Add(child.Key, child.Value);
                    }
                }
            }
            return statesOfAllCtrl;
        }

        public static void ChangeForm(Control form, Hashtable ctrls, int startWidth, int startHeight)
        {
            //如果窗体的大小在改变过程中小于窗体尺寸的初始值，则窗体中的各个控件自动重置为初始尺寸，且窗体自动添加滚动条
            if (form.Size.Width <= startWidth || form.Size.Height <= startHeight)
            {

                foreach (DictionaryEntry item in ctrls)
                {
                    Control ctrl = (Control)item.Key;
                    SizeAndPosition temp = (SizeAndPosition)item.Value;

                    ctrl.Width = temp.width;

                    ctrl.Height = temp.height;

                    ctrl.Bounds = new Rectangle(new Point(temp.locationX, temp.locationY),
                        ctrl.Size);
                }
            }
            else
            //否则，重新设定窗体中所有控件的大小（窗体内所有控件的大小随窗体大小的变化而变化）
            {
                double FormSizeChangedX = (double)form.Size.Width / startWidth;
                double FormSizeChangedY = (double)form.Size.Height / startHeight;

                foreach (DictionaryEntry item in ctrls)
                {
                    Control ctrl = (Control)item.Key;
                    SizeAndPosition temp = (SizeAndPosition)item.Value;

                    ctrl.Width = (int)(temp.width * FormSizeChangedX);

                    ctrl.Height = (int)(temp.height * FormSizeChangedY);

                    ctrl.Bounds = new Rectangle(new Point((int)(temp.locationX * FormSizeChangedX), (int)(temp.locationY * FormSizeChangedY)),
                        ctrl.Size);
                }
            }
        }
    }
}
