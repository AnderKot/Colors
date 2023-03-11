using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Colors
{
    public partial class Form1 : Form
    {
        public Form1()
		{
			InitializeComponent();
		}

        private void m_colorPicker_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(3, true);
            CurrPointer.Mode = 3;
            CurrColor.SelectedColorChangedInvike();
            checkedListBox1.ItemCheck += CheckedListClick;
        }

        private void CheckedListClick(object sender, ItemCheckEventArgs e)
        {

            if (checkedListBox1.CheckedItems.Count > 0)
            {
                if (e.CurrentValue == CheckState.Checked)
                {
                    e.NewValue = CheckState.Checked;
                    CurrPointer.Mode = e.Index;
                    CurrColor.SelectedColorChangedInvike();
                }
                else
                {
                    CurrPointer.Mode = e.Index;
                    Int32 checkedItemIndex = checkedListBox1.CheckedIndices[0];
                    checkedListBox1.ItemCheck -= CheckedListClick;
                    checkedListBox1.SetItemChecked(checkedItemIndex, false);
                    checkedListBox1.ItemCheck += CheckedListClick;
                    CurrColor.SelectedColorChangedInvike();
                }
                return;
            }


        }
    }
}
