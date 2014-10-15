using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProgram
{
    public static class OperationsOnAllControls
    {

        private static string log = String.Empty;

        private static void WriteLog(Control c)
        {
            log = log + c.GetType().ToString() + "\n";
        }

        public static void CleanForm(Control myForm)
        {
            traverseControlsAndSetEmpty(myForm);
            MessageBox.Show(log);
        }

        private static void traverseControlsAndSetEmpty(Control control)
        {

            foreach (var c in control.Controls)
            {

                WriteLog((Control)c);

                // reset TEXTBOX
                if (c is TextBox)
                {
                    if (((TextBox)c).Text != "")
                    {
                        // debug
                        //MessageBox.Show(((TextBox)c).Text);
                        // debug

                        ((TextBox)c).Text = String.Empty;
                    }
                }

                // reset CHECKBOX
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked == true)
                    {
                        // debug
                        //MessageBox.Show(((TextBox)c).Name + " FALSE");
                        // debug

                        ((CheckBox)c).Checked = false;
                    }
                }

                traverseControlsAndSetEmpty((Control)c);
            }

        }
    
    }

}
