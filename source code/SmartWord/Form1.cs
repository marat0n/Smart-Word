using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartWord.Properties;
using static System.Array;

namespace SmartWord
{
    public partial class FormMain : Form
    {
                FormInfo        FI                = new FormInfo(); // FI - Form Info
               List<TextBox>    smartWords       = new List<TextBox>();
              List<RichTextBox> smartWordsValue = new List<RichTextBox>();
             List<Panel>        panels         = new List<Panel>();
            List<Panel>         yellowPanels  = new List<Panel>();
           List<Panel>          YPs          = new List<Panel>();     // YPs - yellow panels
          List<Button>          buttons     = new List<Button>();
         List<string>           Values     = new List<string>();
        List<List<string>>      saveElems = new List<List<string>>(); // elems - elements

        string searchText;

        int actualIndexForSW = 1; // SW - Smart Words // thanks captain
        int randNum          = 0;
        Random random        = new Random();

        public FormMain()
        {
            InitializeComponent();
        }

        void Form1_Load(object sender, EventArgs e)
        {
            QuantityOfSymbols QOSforWords = new QuantityOfSymbols(false); // QOS - Quantity Of Symbols
            QuantityOfSymbols QOSforValues = new QuantityOfSymbols(false);

            string words = Convert.ToString(Settings.Default["words"]);
            string values = Convert.ToString(Settings.Default["values"]);
            string numberForCounts = "";

            int indexForValues = 0;

            for (int i = 0; i < values.Length; i++) {  // elV - elements of values
                if (QOSforValues.numberRecorded) {
                    Values.Add(values.Substring(i, QOSforValues.count));
                    i += QOSforValues.count - 1;
                    QOSforValues.fillingOut(0, false);
                } else {
                    if (values[i] != ' ') { numberForCounts += values[i]; }
                    else { 
                        QOSforValues.numberRecorded = true;
                        QOSforValues.count = Convert.ToInt32(numberForCounts);
                        numberForCounts = "";
                    }
                }
            }

            for (int i = 0; i < words.Length; i++) {
                if (QOSforWords.numberRecorded) {
                    createNewWord(words.Substring(i, QOSforWords.count), Values[indexForValues]);
                    i += QOSforWords.count - 1;
                    QOSforWords.fillingOut(0, false);
                    indexForValues++;
                } else {
                    if (words[i] != ' ') { 
                        numberForCounts += words[i]; 
                    }
                    else {
                        QOSforWords.numberRecorded = true;
                        QOSforWords.count = Convert.ToInt32(numberForCounts);
                        numberForCounts = "";
                    }
                }
            }
        }

        void createNewWord(string textForTB, string textForRTB)
        {
                      Button button_delete        = new Button();
                       TextBox tb                = new TextBox();
                        RichTextBox rtb         = new RichTextBox();
                         Panel newPanel        = new Panel();
                          Panel yellowPanel   = new Panel();

                          button_delete.Width = 46;
                         button_delete.Height  = 40;
                        tb.Width                = 150;
                       tb.Height                 = 22;
                      rtb.Width                   = 320;
                     rtb.Height                    = 40;
                    newPanel.Width                  = Width - 49;
                   newPanel.Height                   = 50;
                  yellowPanel.Width                   = 0;
                 yellowPanel.Height                    = 50;
                tb.Text                                 = textForTB;
               rtb.Text                                  = textForRTB;
              button_delete.Text                          = "Delete";
             yellowPanel.BackColor                         = Color.FromArgb(255, 217, 25);
            rtb.Font                                        = new Font(rtb.Font.FontFamily, 10f);

            if (randNum == 1) randNum = random.Next(2, 4);
            else if (randNum == 2) { randNum = random.Next(1, 3); if (randNum == 2) randNum = 3; }
            else if (randNum == 3) randNum = random.Next(1, 3);
            else randNum = random.Next(1, 4);

            if (randNum == 1) newPanel.BackColor = Color.DarkGray;
            else if (randNum == 2) newPanel.BackColor = Color.Gray;
            else if (randNum == 3) newPanel.BackColor = Color.LightGray;

            if (actualIndexForSW == 1) {
                tb.Location            = new Point(20, 90 * actualIndexForSW);
                rtb.Location           = new Point(10 + tb.Width + tb.Location.X, 90 * actualIndexForSW - 10);
                button_delete.Location = new Point(rtb.Location.X + rtb.Width + 5, 90 * actualIndexForSW - 10);
                newPanel.Location      = new Point(15, 90 * actualIndexForSW - 15);
                yellowPanel.Location   = new Point(15, 90 * actualIndexForSW - 15);
            } else {
                tb.Location            = new Point(20, 55 * actualIndexForSW + 35);
                newPanel.Location      = new Point(15, 55 * actualIndexForSW + 20);
                yellowPanel.Location   = new Point(15, 55 * actualIndexForSW + 20);
                rtb.Location           = new Point(10 + tb.Width + tb.Location.X, 55 * actualIndexForSW + 25);
                button_delete.Location = new Point(rtb.Location.X + rtb.Width + 5, 55 * actualIndexForSW + 25);
            }

            smartWords.Add(tb);
            smartWordsValue.Add(rtb);
            panels.Add(newPanel);
            yellowPanels.Add(yellowPanel);
            buttons.Add(button_delete);

            button_delete.Name = Convert.ToString(actualIndexForSW);
            button_delete.Click += Button_delete_Click;

            this.Controls.Add(button_delete);
            this.Controls.Add(tb);
            this.Controls.Add(rtb);
            this.Controls.Add(yellowPanel);
            this.Controls.Add(newPanel);

            actualIndexForSW++;

            if (55 * actualIndexForSW > this.Height - 30) {
                AutoScroll = true;
            }
        }

        string letterTranslation(string arg)
        {
            string result = "";

            foreach (char el in arg)
            {
                switch (el)
                {
                    case 'q': result += "й"; break;
                    case 'w': result += "ц"; break;
                    case 'e': result += "у"; break;
                    case 'r': result += "к"; break;
                    case 't': result += "е"; break;
                    case 'y': result += "н"; break;
                    case 'u': result += "г"; break;
                    case 'i': result += "ш"; break;
                    case 'o': result += "щ"; break;
                    case 'p': result += "з"; break;
                    case '[': result += "х"; break;
                    case ']': result += "ъ"; break;
                    case '{': result += "х"; break;
                    case '}': result += "ъ"; break;
                    case 'a': result += "ф"; break;
                    case 's': result += "ы"; break;
                    case 'd': result += "в"; break;
                    case 'f': result += "а"; break;
                    case 'g': result += "п"; break;
                    case 'h': result += "р"; break;
                    case 'j': result += "о"; break;
                    case 'k': result += "л"; break;
                    case 'l': result += "д"; break;
                    case ';': result += "ж"; break;
                    case (char)39: result += "э"; break;
                    case ':': result += "ж"; break;
                    case '"': result += "э"; break;
                    case 'z': result += "я"; break;
                    case 'x': result += "ч"; break;
                    case 'c': result += "с"; break;
                    case 'v': result += "м"; break;
                    case 'b': result += "и"; break;
                    case 'n': result += "т"; break;
                    case 'm': result += "ь"; break;
                    case '.': result += "ю"; break;
                    case '>': result += "ю"; break;
                    case ',': result += "б"; break;
                    case '<': result += "б"; break;
                    case 'й': result += "q"; break;
                    case 'ц': result += "w"; break;
                    case 'у': result += "e"; break;
                    case 'к': result += "r"; break;
                    case 'е': result += "t"; break;
                    case 'н': result += "y"; break;
                    case 'г': result += "u"; break;
                    case 'ш': result += "i"; break;
                    case 'щ': result += "o"; break;
                    case 'з': result += "p"; break;
                    case 'х': result += "["; break;
                    case 'ъ': result += "]"; break;
                    case 'Ф': result += "a"; break;
                    case 'ы': result += "s"; break;
                    case 'в': result += "d"; break;
                    case 'а': result += "f"; break;
                    case 'п': result += "g"; break;
                    case 'р': result += "h"; break;
                    case 'о': result += "j"; break;
                    case 'л': result += "k"; break;
                    case 'д': result += "l"; break;
                    case 'ж': result += ";"; break;
                    case 'э': result += "'"; break;
                    case 'я': result += "z"; break;
                    case 'ч': result += "x"; break;
                    case 'с': result += "c"; break;
                    case 'м': result += "v"; break;
                    case 'и': result += "b"; break;
                    case 'т': result += "n"; break;
                    case 'ь': result += "m"; break;
                    case 'б': result += ","; break;
                    case 'ю': result += "."; break;
                    default: result += el; break;
                }
            }

            return result;
        }

        string MakeWordsSmaller(string arg) {
            string result = "";

            foreach (char el in arg) {
                switch (el) {
                    case 'Q': result += "q"; break;
                    case 'W': result += "w"; break;
                    case 'E': result += "e"; break;
                    case 'R': result += "r"; break;
                    case 'T': result += "t"; break;
                    case 'Y': result += "y"; break;
                    case 'U': result += "u"; break;
                    case 'I': result += "i"; break;
                    case 'O': result += "o"; break;
                    case 'P': result += "p"; break;
                    case 'A': result += "a"; break;
                    case 'S': result += "s"; break;
                    case 'D': result += "d"; break;
                    case 'F': result += "f"; break;
                    case 'G': result += "g"; break;
                    case 'H': result += "h"; break;
                    case 'J': result += "j"; break;
                    case 'K': result += "k"; break;
                    case 'L': result += "l"; break;
                    case 'Z': result += "z"; break;
                    case 'X': result += "x"; break;
                    case 'C': result += "c"; break;
                    case 'V': result += "v"; break;
                    case 'B': result += "b"; break;
                    case 'N': result += "n"; break;
                    case 'M': result += "m"; break;
                    case 'Й': result += "й"; break;
                    case 'Ц': result += "ц"; break;
                    case 'У': result += "у"; break;
                    case 'К': result += "к"; break;
                    case 'Е': result += "е"; break;
                    case 'Н': result += "н"; break;
                    case 'Г': result += "г"; break;
                    case 'Ш': result += "ш"; break;
                    case 'Щ': result += "щ"; break;
                    case 'З': result += "з"; break;
                    case 'Х': result += "х"; break;
                    case 'Ъ': result += "ъ"; break;
                    case 'Ф': result += "ф"; break;
                    case 'Ы': result += "ы"; break;
                    case 'В': result += "в"; break;
                    case 'А': result += "а"; break;
                    case 'П': result += "п"; break;
                    case 'Р': result += "р"; break;
                    case 'О': result += "о"; break;
                    case 'Л': result += "л"; break;
                    case 'Д': result += "д"; break;
                    case 'Ж': result += "ж"; break;
                    case 'Э': result += "э"; break;
                    case 'Я': result += "я"; break;
                    case 'Ч': result += "ч"; break;
                    case 'С': result += "с"; break;
                    case 'М': result += "м"; break;
                    case 'И': result += "и"; break;
                    case 'Т': result += "т"; break;
                    case 'Ь': result += "ь"; break;
                    case 'Б': result += "б"; break;
                    case 'Ю': result += "ю"; break;
                    default : result += el; break;
                }
            }

            return result;
        }

        void ButtonAdd_Click(object sender, EventArgs e)
        {
            createNewWord(null, null);
        }

        void Button_save_Click(object sender, EventArgs e)
        {
            int indexForSE = -1; // SE - save elems // elems - elements

            Settings.Default["words"] = "";
            Settings.Default["values"] = "";

            for (int i = 0; i < smartWords.Count; i++) {
                if (smartWords[i].Text.Trim() != "" || smartWordsValue[i].Text.Trim() != "") {
                    indexForSE++;
                    saveElems.Add(new List<string>());
                    saveElems[indexForSE].Add(smartWords[i].Text);
                    saveElems[indexForSE].Add(smartWordsValue[i].Text);
                }
            }

            for (int i = 0; i < saveElems.Count; i++) {
                Settings.Default["words"] += saveElems[i][0].Length + " " + saveElems[i][0];
                Settings.Default["values"] += saveElems[i][1].Length + " " + saveElems[i][1];
            }

            saveElems.Clear();
            Settings.Default.Save();
        }

        void Button_Search_Click(object sender, EventArgs e)
        {
            search.Text = "";
            foreach (Panel panel in YPs) { panel.Width = 0; }
            YPs = new List<Panel>();
        }

        void timer_for_search_Tick(object sender, EventArgs e)
        {
            if (search.Text != "") {
                searchText = MakeWordsSmaller(search.Text);
                for (int i = 0; i < smartWords.Count; i++) {
                    if (MakeWordsSmaller(smartWordsValue[i].Text).Contains(searchText)) {
                        YPs.Add(yellowPanels[i]);
                        yellowPanels[i].Width = panels[i].Width;
                    } else if (letterTranslation(MakeWordsSmaller(smartWordsValue[i].Text)).Contains(searchText)) {
                        YPs.Add(yellowPanels[i]);
                        yellowPanels[i].Width = panels[i].Width;
                    } else if (MakeWordsSmaller(smartWords[i].Text).Contains(searchText)) {
                        YPs.Add(yellowPanels[i]);
                        yellowPanels[i].Width = panels[i].Width;
                    } else if (letterTranslation(MakeWordsSmaller(smartWords[i].Text)).Contains(searchText)) {
                        YPs.Add(yellowPanels[i]);
                        yellowPanels[i].Width = panels[i].Width;
                    } else {
                        YPs.Remove(yellowPanels[i]);
                        yellowPanels[i].Width = 0;
                    }
                }
            } else {
                foreach (Panel panel in YPs) { panel.Width = 0; }
                YPs = new List<Panel>();
            }
        }

        void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (search.Text != "" || search.Text != " ") {
                timer_for_search.Enabled = true;
            } else {
                timer_for_search.Enabled = false;
                foreach (Panel panel in YPs) {
                    panel.Width = 0;
                }
                YPs = new List<Panel>();
            }
        }

        void Button_delete_Click(object sender, EventArgs e) {
            int btnID = Convert.ToInt32((sender as Button).Name);
            if (btnID == actualIndexForSW) {
                smartWords[btnID-1].Dispose();
                smartWordsValue[btnID-1].Dispose();
                panels[btnID-1].Dispose();
                yellowPanels[btnID-1].Dispose();
                buttons[btnID-1].Dispose();

                smartWords.RemoveAt(btnID-1);
                smartWordsValue.RemoveAt(btnID-1);
                panels.RemoveAt(btnID-1);
                yellowPanels.RemoveAt(btnID-1);
                buttons.RemoveAt(btnID-1);
            } else {
                smartWords[btnID-1].Dispose();
                smartWordsValue[btnID-1].Dispose();
                panels[btnID-1].Dispose();
                yellowPanels[btnID-1].Dispose();
                buttons[btnID-1].Dispose();

                smartWords.RemoveAt(btnID-1);
                smartWordsValue.RemoveAt(btnID-1);
                panels.RemoveAt(btnID-1);
                yellowPanels.RemoveAt(btnID-1);
                buttons.RemoveAt(btnID-1);

                for (int i = btnID-1; i < panels.Count; i++) {
                    smartWords[i].Location = new Point(smartWords[i].Location.X, smartWords[i].Location.Y - 55);
                    smartWordsValue[i].Location = new Point(smartWordsValue[i].Location.X, smartWordsValue[i].Location.Y - 55);
                    panels[i].Location = new Point(panels[i].Location.X, panels[i].Location.Y - 55);
                    yellowPanels[i].Location = new Point(yellowPanels[i].Location.X, yellowPanels[i].Location.Y - 55);
                    buttons[i].Location = new Point(buttons[i].Location.X, buttons[i].Location.Y - 55);
                    buttons[i].Name = Convert.ToString(Convert.ToInt32(buttons[i].Name) - 1);
                }
            }

            actualIndexForSW--;
        }

        private void info_Click(object sender, EventArgs e)
        {
            FI.Show();
        }

        private void info_MouseEnter(object sender, EventArgs e)
        {
            info.ForeColor = Color.White;
        }

        private void info_MouseLeave(object sender, EventArgs e)
        {
            info.ForeColor = Color.Black;
        }
    }

    class QuantityOfSymbols
    {
        public QuantityOfSymbols(bool NR) { numberRecorded = NR; } // NR - number recorded

        public int count = 0;
        public bool numberRecorded;
    }

    static class ExtensionForQOS
    {
        public static void fillingOut(this QuantityOfSymbols QOS, int num, bool NR) {
            QOS.count = num;
            QOS.numberRecorded = NR;
        }
    }
}
