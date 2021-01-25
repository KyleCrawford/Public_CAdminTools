using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace CAdminTools
{
    public class CustomiseVisuals
    {
        private Color formBackColour;
        private string _formImagePath;
        private Color panelColour;
        private int panelOpacity;
        private Color buttonColour;
        private int buttonOpacity;

        struct fontSettings
        {
            public string fontName;
            public float fontSize;
            public bool fontBold;
            public bool fontItalics;
            public bool fontUnderline;
        }

        private string fontName;
        private int fontSize;

        private Form_MainForm _mainForm;

        public CustomiseVisuals(Form_MainForm mainForm)
        {
            _mainForm = mainForm;

        }

        private void DrawForm()
        {
            
        }

        public void LoadProfile()
        {
            Color currentPanelColour = Color.FromKnownColor(KnownColor.Control);
            int panelOpacity = 0;
            Color currentButtonColour = Color.FromKnownColor(KnownColor.Control);
            int buttonOpacity = 0;
            string fontName = "";
            float fontSize = 0f;
            Color textColour = Color.FromKnownColor(KnownColor.ControlText);
            bool bold = false;
            bool italic = false;
            bool underline = false;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");

            XmlNode xNode = xmlDoc.SelectSingleNode("//LocalSettings/Cusomisation/VisualsProfile");

            if (xmlDoc.SelectSingleNode("//VisualsProfile") == null)
            {
                return;
            }

            XmlNode formColour = xmlDoc.SelectSingleNode("//FormColour");
            _mainForm.BackColor = Color.FromArgb(int.Parse(formColour.InnerText));

            XmlNode formPicture = xmlDoc.SelectSingleNode("//FormPicture");
            if (formPicture.InnerText != "")
            {
                _mainForm.BackgroundImage = Image.FromFile(formPicture.InnerText);
            }



            //Get all the colours first, then loop through the controls
            XmlNode xpanelColour = xmlDoc.SelectSingleNode("//PanelColour");
            currentPanelColour = Color.FromArgb(int.Parse(xpanelColour.InnerText));
            panelOpacity = int.Parse(xpanelColour.Attributes["PanelOpacity"].Value);
            UpdatePanel(panelOpacity, currentPanelColour);

            XmlNode xbuttonColour = xmlDoc.SelectSingleNode("//ButtonColour");
            currentButtonColour = Color.FromArgb(int.Parse(xbuttonColour.InnerText));
            buttonOpacity = int.Parse(xbuttonColour.Attributes["ButtonOpacity"].Value);
            DrawBtnAndLbl(buttonOpacity, currentButtonColour);

            XmlNode xfontName = xmlDoc.SelectSingleNode("//FontName");
            fontName = xfontName.InnerText;
            fontSize = float.Parse(xfontName.Attributes["FontSize"].Value);

            XmlNode xfontColour = xmlDoc.SelectSingleNode("//TextColour");
            textColour = Color.FromArgb(int.Parse(xfontColour.InnerText));

            XmlNode fontModifier = xmlDoc.SelectSingleNode("//Bold");
            bold = bool.Parse(fontModifier.InnerText);

            fontModifier = xmlDoc.SelectSingleNode("//Italic");
            italic = bool.Parse(fontModifier.InnerText);

            fontModifier = xmlDoc.SelectSingleNode("//Underline");
            underline = bool.Parse(fontModifier.InnerText);

            UpdateFont(new Font(fontName, fontSize, (bold ? FontStyle.Bold : FontStyle.Regular) | (italic ? FontStyle.Italic : FontStyle.Regular) | (underline ? FontStyle.Underline : FontStyle.Regular)));
            UpdateFontColour(textColour);

        }

        public void SaveProfile()
        {
            //save the profile as xml in the user's localSettings.xml
            Color controlColour = Color.FromKnownColor(KnownColor.Control);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");


            if (xmlDoc.SelectSingleNode("//Customisation") == null)
            {

                CreateVisualsProfile(xmlDoc);

            }
            else
            {
                //modify values
                XmlNode formColour = xmlDoc.SelectSingleNode("//FormColour");
                formColour.InnerText = _mainForm.BackColor.ToArgb().ToString();

                XmlNode formPicture = xmlDoc.SelectSingleNode("//FormPicture");
                formPicture.InnerText = _formImagePath;

                XmlNode panelColour = xmlDoc.SelectSingleNode("//PanelColour");
                foreach (Control c in _mainForm.Controls)
                {
                    if (c is Panel)
                    {
                        controlColour = c.BackColor;
                        break;
                    }
                }
                panelColour.InnerText = controlColour.ToArgb().ToString();
                panelColour.Attributes["PanelOpacity"].Value = controlColour.A.ToString();

                XmlNode buttonColour = xmlDoc.SelectSingleNode("//ButtonColour");
                foreach (Control c in _mainForm.Controls)
                {
                    if (c is Button)
                    {
                        controlColour = c.BackColor;
                        break;
                    }
                }
                buttonColour.InnerText = controlColour.ToArgb().ToString();
                buttonColour.Attributes["ButtonOpacity"].Value = controlColour.A.ToString();

                XmlNode xfontName = xmlDoc.SelectSingleNode("//FontName");
                string fontName = "";
                float fontSize = 8;
                bool bold = false;
                bool italics = false;
                bool underline = false;
                Color fontColour = Color.FromKnownColor(KnownColor.ControlText);
                foreach (Control c in _mainForm.Controls)
                {
                    if (c is Button)
                    {
                        fontName = c.Font.Name;
                        fontSize = c.Font.Size;
                        bold = c.Font.Bold;
                        italics = c.Font.Italic;
                        underline = c.Font.Underline;
                        fontColour = c.ForeColor;
                        break;
                    }
                }
                xfontName.InnerText = fontName;
                xfontName.Attributes["FontSize"].Value = fontSize.ToString();

                XmlNode xColour = xmlDoc.SelectSingleNode("//TextColour");
                xColour.InnerText = fontColour.ToArgb().ToString();

                XmlNode fontModifier = xmlDoc.SelectSingleNode("//Bold");
                fontModifier.InnerText = bold.ToString();

                fontModifier = xmlDoc.SelectSingleNode("//Italic");
                fontModifier.InnerText = italics.ToString();

                fontModifier = xmlDoc.SelectSingleNode("//Underline");
                fontModifier.InnerText = underline.ToString();

                xmlDoc.Save(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");
            }

        }

        private void CreateVisualsProfile(XmlDocument xmlDoc)
        {
            Color controlColour = Color.FromKnownColor(KnownColor.Control);

            //no profile exists, gotta create xml from scratch
            XmlNode settingsRoot = xmlDoc.SelectSingleNode("//LocalSettings");

            XmlElement customisation = xmlDoc.CreateElement("Customisation");
            settingsRoot.AppendChild(customisation);

            XmlElement visualsProfile = xmlDoc.CreateElement("VisualsProfile");
            customisation.AppendChild(visualsProfile);

            XmlElement formColour = xmlDoc.CreateElement("FormColour");
            formColour.InnerText = _mainForm.BackColor.ToArgb().ToString();
            visualsProfile.AppendChild(formColour);

            XmlElement formPicture = xmlDoc.CreateElement("FormPicture");
            formPicture.InnerText = _formImagePath;
            visualsProfile.AppendChild(formPicture);

            XmlElement panelColour = xmlDoc.CreateElement("PanelColour");
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Panel)
                {
                    controlColour = c.BackColor;
                    break;
                }
            }
            panelColour.InnerText = controlColour.ToArgb().ToString();
            XmlAttribute panelOpacity = xmlDoc.CreateAttribute("PanelOpacity");
            panelOpacity.Value = controlColour.A.ToString();
            panelColour.Attributes.Append(panelOpacity);
            visualsProfile.AppendChild(panelColour);


            XmlElement buttonColour = xmlDoc.CreateElement("ButtonColour");
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Button)
                {
                    controlColour = c.BackColor;
                    break;
                }
            }
            buttonColour.InnerText = controlColour.ToArgb().ToString();
            XmlAttribute buttonOpacity = xmlDoc.CreateAttribute("ButtonOpacity");
            buttonOpacity.Value = controlColour.A.ToString();
            buttonColour.Attributes.Append(buttonOpacity);
            visualsProfile.AppendChild(buttonColour);

            XmlElement fontSetting = xmlDoc.CreateElement("FontSetting");
            string fontName = "";
            float fontSize = 8;
            bool bold = false;
            bool italics = false;
            bool underline = false;
            Color textColour = Color.FromKnownColor(KnownColor.Control);
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Button)
                {
                    fontName = c.Font.Name;
                    fontSize = c.Font.Size;
                    bold = c.Font.Bold;
                    italics = c.Font.Italic;
                    underline = c.Font.Underline;
                    textColour = c.ForeColor;
                    break;
                }

            }
            XmlElement xfontName = xmlDoc.CreateElement("FontName");
            xfontName.InnerText = fontName;
            fontSetting.AppendChild(xfontName);

            XmlAttribute xfontSize = xmlDoc.CreateAttribute("FontSize");
            xfontSize.Value = fontSize.ToString();
            xfontName.Attributes.Append(xfontSize);
            visualsProfile.AppendChild(fontSetting);

            XmlElement xtextColour = xmlDoc.CreateElement("TextColour");
            xtextColour.InnerText = textColour.ToArgb().ToString();
            fontSetting.AppendChild(xtextColour);

            XmlElement fontModifier = xmlDoc.CreateElement("Bold");
            fontModifier.InnerText = bold.ToString();
            fontSetting.AppendChild(fontModifier);

            fontModifier = xmlDoc.CreateElement("Italic");
            fontModifier.InnerText = italics.ToString();
            fontSetting.AppendChild(fontModifier);

            fontModifier = xmlDoc.CreateElement("Underline");
            fontModifier.InnerText = underline.ToString();
            fontSetting.AppendChild(fontModifier);

            xmlDoc.Save(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");
        }

        private void ChooseProfile()
        {
            //let the user choose a saved profile
            
            //how to load the different settings... just by name?

        }

        public void SetToDefault()
        {
            //set all the colours of the form to be default values.

            //background image
            _mainForm.BackgroundImage = null;

            //background Colour
            _mainForm.BackColor = Color.FromKnownColor(KnownColor.Control);

            foreach (Control c in _mainForm.Controls)
            {
                
                if (c is Panel)
                {
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                    //check for more controls
                    foreach (Control co in c.Controls)
                    {
                        co.BackColor = Color.FromKnownColor(KnownColor.Control);
                        if (co is Panel)
                        {
                            foreach (Control con in co.Controls)
                            {
                                con.BackColor = Color.FromKnownColor(KnownColor.Control);
                            }
                        }
                        else if (co is Button)
                        {
                            (co as Button).FlatStyle = FlatStyle.System;
                        }
                    }
                }
                else if (c is PictureBox)
                {
                    c.BackColor = Color.Transparent;
                }
                else if (c is Button)
                {
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                    (c as Button).FlatStyle = FlatStyle.System;
                }
                else if (c is Label)
                {
                    c.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
                else if (c is TextBox)
                {
                    continue;
                }
            }

            Font defaultFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            UpdateFont(defaultFont);
            UpdateFontColour(Color.FromKnownColor(KnownColor.ControlText));

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");
            //XmlNode xNode = xmlDoc.SelectSingleNode("//LocalSettings");
            //xNode.RemoveChild(xmlDoc.SelectSingleNode("//Customisation"));

            //xmlDoc.Save(_mainForm.LocalSettingsPath + @"\LocalSettings.xml");
        }


        /////
        public void DrawBtnAndLbl(int opacity, Color btnColour)
        {
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control co in c.Controls)
                    {
                        if (co is Button)
                        {
                            if (opacity < 255)
                            {
                                (co as Button).FlatStyle = FlatStyle.Flat;
                            }
                            else
                            {
                                (co as Button).FlatStyle = FlatStyle.System;
                            }
                            co.BackColor = Color.FromArgb(opacity, btnColour);
                        }
                        else if (co is Label)
                        {
                            co.BackColor = Color.FromArgb(opacity, btnColour);
                        }
                        else if (co is Panel)
                        {
                            foreach (RadioButton rBtn in co.Controls)
                            {
                                rBtn.BackColor = Color.FromArgb(opacity, btnColour);
                            }
                        }
                        else if (co is CheckBox)
                        {
                            co.BackColor = Color.FromArgb(opacity, btnColour);
                        }
                        
                    }
                }

                else if (c is Label)
                {
                    c.BackColor = Color.FromArgb(opacity, btnColour);
                }
                else if (c is Button)
                {
                    if (opacity < 255)
                    {
                        (c as Button).FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        (c as Button).FlatStyle = FlatStyle.System;
                    }
                    c.BackColor = Color.FromArgb(opacity, btnColour);
                }

            }
        }

        public void ChangeBackgroundImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @"\Admintools Backgrounds";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _mainForm.BackgroundImage = Image.FromFile(ofd.FileName);
                _formImagePath = ofd.FileName;

                if (!System.IO.Directory.Exists(_mainForm.LocalSettingsPath + @"\FormImages"))
                {
                    System.IO.Directory.CreateDirectory(_mainForm.LocalSettingsPath + @"\FormImages");
                }

                int imageCounter = 0;
                //while (System.IO.File.Exists(_mainForm.LocalSettingsPath + @"\FormImages\Background" + imageCounter + "*"))
               // while (System.IO.Directory.GetFiles(_mainForm.LocalSettingsPath + @"\FormImages\Background", _mainForm.LocalSettingsPath + @"\FormImages\Background" + imageCounter + ".*").Length > 0)
               // {
               //     imageCounter++;
               // }

                //System.IO.File.Copy(ofd.FileName, _mainForm.LocalSettingsPath + @"\FormImages\Background", );
            }


        }

        public void UpdatePanel(int Opacity, Color colour)
        {
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Panel)
                {
                    c.BackColor = Color.FromArgb(Opacity, colour);
                    foreach (Control co in c.Controls)
                    {
                        if (co is Panel)
                        {
                            co.BackColor = Color.FromArgb(0, colour);
                        }
                    }
                }
            }
        }

        public void UpdateFont(Font newFont)
        {
            foreach (Control c in _mainForm.Controls)
            {
                if (c is TextBox)
                {
                    continue;
                }
                c.Font = newFont;
                if (c is Panel)
                {
                    foreach (Control co in c.Controls)
                    {
                        if (co is TextBox)
                        {
                            continue;
                        }
                        else if (co is ComboBox)
                        {
                            continue;
                        }
                            co.Font = newFont;
                        if (co is Panel)
                        {
                            foreach (Control con in co.Controls)
                            {
                                con.Font = newFont;
                            }
                        }
                    }
                }
            }
        }

        public void UpdateFontColour(Color colour)
        {
            foreach (Control c in _mainForm.Controls)
            {
                if (c is Button)
                {
                    c.ForeColor = colour;
                }
                if (c is Panel)
                {
                    foreach (Control co in c.Controls)
                    {
                        if (!(co is TextBox))
                        co.ForeColor = colour;
                    }
                }
                if (c is TextBox || c is ComboBox)
                {
                    continue;
                }
                c.ForeColor = colour;
                
            }
        }
    }
}
