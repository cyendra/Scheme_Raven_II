using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace Raven.Scheme.Editor
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void codeRichBox_TextChanged(object sender, EventArgs e)
        {
            int nSelectStart = codeRichBox.SelectionStart;
            int nSelectLength = codeRichBox.SelectionLength;
            for (int count = 0; count < BlueText.Length; count++)
            {
                Regex reg = new Regex(BlueText[count]);
                MatchCollection matches = reg.Matches(codeRichBox.Text);
                foreach (Match mat in matches)
                {
                    codeRichBox.Select(mat.Index, BlueText[count].Length);
                    codeRichBox.SelectionColor = Color.Blue;
                }
            }
            codeRichBox.Select(nSelectStart, nSelectLength);
        }

        private string[] BlueText = new string[] { "【", "】" };


    }
}
