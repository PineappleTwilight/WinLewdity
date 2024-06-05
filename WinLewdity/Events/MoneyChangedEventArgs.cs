using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHtmlViewer.Events
{
    public class MoneyChangedEventArgs : EventArgs
    {
        public int newMoneyValue;
        public int oldMoneyValue;
    }
}