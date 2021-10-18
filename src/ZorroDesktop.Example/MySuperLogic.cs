using System;
using System.Windows.Forms;

namespace ZorroDesktop.Example
{
    class MySuperLogic
    {
        public void Msg()
        {
            MessageBox.Show("Hello");
        }

        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
