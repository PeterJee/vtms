using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar.Controls;
namespace VTMS.ControlLib
{
    public partial class TextBoxExt : TextBoxX
    {
        private RegexType controlType;
        private bool notNull = true;
        private string errorMessage;
        public ErrorProvider errorProvider = new ErrorProvider();

        public enum RegexType
        {
            Default,
            Number,
            Zip,
            Email,
            Phone,
            Float,
            MixChar,
            Date,
            YearMonth
        }
        [DefaultValue(RegexType.Default)]
        [Description("文本框类型")]
        public RegexType ControlType
        {
            get { return controlType; }
            set
            {
                controlType = value;
            }
        }
        [DefaultValue(true)]
        [Description("是否可以为空")]
        public bool NotNull
        {
            get { return notNull; }
            set
            {
                notNull = value;
            }
        }
        private void TextBoxExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (controlType)
            {
                case RegexType.Number:
                case RegexType.Zip:
                case RegexType.YearMonth:
                case RegexType.Date:
                    if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case RegexType.Phone:
                    if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-')
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case RegexType.Float:
                    if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || (this.Text.Contains('.') && e.KeyChar == '.'))
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
                case RegexType.MixChar:
                    if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-')
                        e.Handled = false;
                    else
                        e.Handled = true;
                    break;
            }
        }
        private void ControlToValidate_Validating(object sender, CancelEventArgs e)
        {
            if (!this.ReadOnly && !Invalid())
            {
                showErrorMessage(this.ControlType);
                errorProvider.SetError(this, errorMessage);
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void showErrorMessage(RegexType value)
        {
            switch (value)
            {
                case RegexType.Number:
                    errorMessage = "只能输入数字！";
                    break;
                case RegexType.Zip:
                    errorMessage = "输入的邮政编码不合法";
                    break;
                case RegexType.Email:
                    errorMessage = "输入的邮件地址不合法";
                    break;
                case RegexType.Phone:
                    errorMessage = "输入的电话号码不合法";
                    break;
                case RegexType.Float:
                    errorMessage = "输入的金额不合法";
                    break;
                case RegexType.MixChar:
                    errorMessage = "只能输入半角英文或者数字";
                    break;
                case RegexType.Date:
                    errorMessage = "输入的日期格式不正确，应该为yyyyMMdd,例如20010101";
                    break;
                case RegexType.YearMonth:
                    errorMessage = "输入的日期格式不正确，应该为yyyyMM,例如200101";
                    break;
            }
        }
        public bool Invalid()
        {
            if (NotNull&& string.IsNullOrEmpty(this.Text.Trim()))
            {
                errorMessage = "不能为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(this.Text.Trim()))
            {
                return true;
            }
            bool b = false;
            switch (this.ControlType)
            {
                case RegexType.Default:
                    b = true;
                    break;
                case RegexType.Number:
                    b = Validation(this.Text, @"^\+?[1-9][0-9]*$");
                    break;
                case RegexType.Zip:
                    b = Validation(this.Text, @"^[1-9]\d{5}$");
                    break;
                case RegexType.Email:
                    b = Validation(this.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    break;
                case RegexType.Phone:
                    b = Validation(this.Text, @"^((\d{11})|(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|)$");
                    break;
                case RegexType.Float:
                    b = Validation(this.Text, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*|[1-9]\d*|0$");
                    break;
                case RegexType.MixChar:
                    b = Validation(this.Text, @"^(([A-Za-z0-9]+)[-]?([A-Za-z0-9]+)?)$");
                    break;
                case RegexType.Date:
                    b = Validation(this.Text, @"^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2\2(?:29))$");
                    break;
                case RegexType.YearMonth:
                    b = Validation(this.Text, @"^[0-9]{4}(0[1-9]|1[0-2])$");
                    break;
            }
            return b;
        }
        private bool Validation(string validValue, string regularExpression)
        {
            Regex regex;
            try
            {
                regex = new Regex(regularExpression);
            }
            catch
            {
                return false;
            }
            if (regex.IsMatch(validValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public TextBoxExt()
        {
            InitializeComponent();

            this.KeyPress += new KeyPressEventHandler(TextBoxExt_KeyPress);
            this.Validating += new CancelEventHandler(ControlToValidate_Validating);
        }
    }
}
