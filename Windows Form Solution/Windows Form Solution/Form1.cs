using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;


/*
 * Code by: Tam Nguyen
 * Additional notes: The instruction is literally impossible to accomplish if you follow the definition of API. Just not possible unless you rewrite everything from scratch,
 * including the libraries!
 */

namespace Windows_Form_Solution
{
    public partial class Form1 : Form
    {
        bool boldOn = false;
        ImageList images = new ImageList();
        List<Image> listImg {get; set;}
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listImg = new List<Image>();
            images.ImageSize = new System.Drawing.Size(86, 86);


            imgListView.LargeImageList = images;
        }

        // Placeholders
        private void BodyText_Enter(object sender, EventArgs e)
        {
            if (BodyText.Text == "Enter slide's body")
                BodyText.Text = "";
        }

        private void TitleInput_Enter(object sender, EventArgs e)
        {
            if (TitleInput.Text == "Enter Title")
                TitleInput.Text = "";
        }

        private void searchImgButton_Click(object sender, EventArgs e)
        {
            imgListView.Clear();
            images.Images.Clear();
            listImg.Clear();

            // Perform Regex to get our bolded words
            var match = Regex.Matches(BodyText.Rtf, @"\\b(.+?)\\b0");
            List<string> searchKeys = new List<string>();
            Console.WriteLine(BodyText.Rtf);
            searchKeys.Add(TitleInput.Text);

            foreach (var s in match)
            { 
                // Clean up the string to extract only the words
                string key = s.ToString().Trim().Replace("\\f0\\fs17","").Replace("\\b ", "").Replace("\\b0", "");
                // Add it to our dictionary for image search
                if (!searchKeys.Contains(key))
                    searchKeys.Add(key);
            }

            PerformImgSearch(searchKeys);
        }

        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                GeneratePPT();
            } catch (IOException)
            {
                DialogResult res = MessageBox.Show("Error generating powerpoint. Make sure you do not have Result.pptx currently open!");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ActiveControl is RichTextBox BodyText)
            {
                // Enable bold
                if (keyData == (Keys.Control | Keys.B))
                {
                    BodyText.SelectionFont = new Font(BodyText.SelectionFont, BodyText.SelectionFont.Style ^ FontStyle.Bold); // XOR will toggle
                    boldOn = !boldOn;
                    Console.WriteLine(boldOn);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AddImgToList(Image newImg)
        {
            // Add google image to memory
            listImg.Add(newImg);
            images.Images.Add(newImg);

            imgListView.Items.Add(new ListViewItem("", listImg.Count()));
        }

        private void PerformImgSearch(List<string> keys)
        {
            foreach (string key in keys)
            {
                string imgSearchURL = @"https://www.google.com/search?q={0}&tbm=isch&site=imghp";
                using (WebClient wc = new WebClient())
                {
                    //lets pretend we are IE8 on Vista.
                    wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)");
                    string result = wc.DownloadString(String.Format(imgSearchURL, new object[] { key }));


                    // Check to see if we have picture's links
                    if (result.Contains("https://encrypted-tbn0.gstatic.com/"))
                    {
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(result);

                        /*
                         * Since the img url is in a <img> which is inside <table> we want to see if the <img> has a source that contains "images?"
                         */

                        var imgList = from tables in doc.DocumentNode.Descendants("table")
                                      from img in tables.Descendants("img")
                                      where tables.Attributes["class"] != null
                                      && img.Attributes["src"] != null && img.Attributes["src"].Value.Contains("images?")
                                      select img;

                        // Preventing duplicates in the preview
                        List<String> imgSource = new List<String>();
                        int imgCount = 0;

                        foreach (var i in imgList)
                        { 
                            // if there are more than 3 key words, then limit 4 pictures per word
                            if (keys.Count > 3 && imgCount > 4)
                                break;
                            string src = i.Attributes["src"].Value;
                            if (!imgSource.Contains(src))
                            {
                                byte[] downloadedData = wc.DownloadData(i.Attributes["src"].Value);

                                if (downloadedData != null)
                                {
                                    //store the downloaded data in to a stream
                                    System.IO.MemoryStream ms = new System.IO.MemoryStream(downloadedData, 0, downloadedData.Length);

                                    //write to that stream the byte array
                                    ms.Write(downloadedData, 0, downloadedData.Length);

                                    //load an image from that stream.
                                    AddImgToList(Image.FromStream(ms));
                                }
                                imgSource.Add(src);
                            }
                            imgCount++;

                        }

                    }

                }
            }
        }
        private void GeneratePPT()
        {
            //Create a new PowerPoint presentation
            IPresentation powerpointDoc = Presentation.Create();

            ISlide slide = powerpointDoc.Slides.Add(SlideLayoutType.TitleOnly);


            IShape titleShape = slide.Shapes[0] as IShape;
            titleShape.TextBody.AddParagraph(TitleInput.Text).HorizontalAlignment = HorizontalAlignmentType.Center;

            //Add a text to the textbox.
            IShape descriptionShape = slide.AddTextBox(53.22, 141.73, 874.19, 77.70);
            descriptionShape.TextBody.Text = BodyText.Text;

            Console.WriteLine(imgListView.SelectedItems.Count);

            // Grab checked images

            int x = 170, y = 0, indx = 0;
            foreach (int i in imgListView.CheckedIndices)
            {
                slide.Shapes.AddPicture(ToStream(listImg[i+1]), x, y, 140, 140);
                x += 140;
                if (indx % 5 == 0)
                {
                    y += 140;
                    x = 170;
                }
                indx++;
            }

            //Save the PowerPoint presentation
            powerpointDoc.Save("Result.pptx");

            //Close the PowerPoint presentation
            powerpointDoc.Close();

            DialogResult res = MessageBox.Show("Result saved as Result.pptx which can be located in bin>debug");
        }

        public Stream ToStream(Image image)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;
            return stream;
        }
    }
}
