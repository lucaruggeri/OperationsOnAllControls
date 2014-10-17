using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProgram
{
    class Statistics
    {
        public static List<string> names = new List<string>();
        public static List<string> values = new List<string>();

        public Statistics(List<string> list)
        { 
            // sorting
            list.Sort();

            // grouping
            var result = list
                        .GroupBy(s => s)
                        .Select(group => new { ControlTypeName = group.Key, Number = group.Count() });

            // view
            string view = String.Empty;
            foreach (var obj in result)
            {
                view = view + "CONTROL TYPE: " + obj.ControlTypeName + "\n";
                view = view + " OCCURRENCES: " + obj.Number.ToString() + "\n";
                view = view + "\n\n";
            }

            MessageBox.Show(view);
        }
    }

    public static class OperationsOnAllControls
    {

        private static List<string> log = new List<string>();

        private static void WriteLog(Control c)
        {
            log.Add(c.GetType().ToString());
        }

        private static void ReadLog()
        {
        }

        private static void ReadStatistics()
        {
        }

        public static void CleanForm(Control myForm, bool generateSummary)
        {
            log.Clear();

            traverseControlsAndSetEmpty(myForm);
 
            if (generateSummary == true)
            {
                Statistics myStats = new Statistics(log);             
            }

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
