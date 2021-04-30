using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseOP.Services
{
    public static class InputHandlerService
    {
        public static void SymbolWithSpace(object sender, KeyPressEventArgs e)
        {
            string symbol = e.KeyChar.ToString();
            char symbolChar = e.KeyChar;

            if (!Regex.Match(symbol, @"[а-яА-Я]|[a-zA-Z]").Success && symbolChar != 8 && symbolChar != 32)
                e.Handled = true;
        }
        public static void DigitOnly(object sender, KeyPressEventArgs e)
        {
            char digit = e.KeyChar;

            if (!Char.IsDigit(digit) && digit != 8)
                e.Handled = true;
        }

        public static void DateTimeOnly(object sender, KeyPressEventArgs e)
        {
            char digit = e.KeyChar;

            if (!Char.IsDigit(digit) && digit != 8 && !(digit == '.'))
                e.Handled = true;
        }
    }
}
