
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SAAMControl.Model
{
    public class RichTextBoxHelper : DependencyObject
    {
        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
        }
        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }
        public static readonly DependencyProperty DocumentXamlProperty =
          DependencyProperty.RegisterAttached(
            "DocumentXaml",
            typeof(string),
            typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = (obj, e) =>
                {
                    var richTextBox = (RichTextBox)obj;

                    // Parse the XAML to a document (or use XamlReader.Parse())
                    var xaml = GetDocumentXaml(richTextBox);
                    Paragraph para = new Paragraph();
                    para.Margin = new Thickness(0); // remove indent between paragraphs
                    para.Inlines.Add(xaml);

                    // Set the document
                    richTextBox.Document.Blocks.Add(para);
                    richTextBox.Document.Blocks.Remove(richTextBox.Document.Blocks.FirstBlock);
                    richTextBox.Document.Blocks.Add(para);
                    

                    List<string> linksOnContent = GetLinks(xaml);
                    if (linksOnContent.Count > 0)
                    {
                        foreach (var link in linksOnContent)
                        {
                            string value = link.Replace("<a>", string.Empty).Replace("</a>", string.Empty);
                            TextRange hyperlinkTextRange = FindWordFromPosition(richTextBox.Document.ContentStart, link);
                            List<Hyperlink> results = new List<Hyperlink>();
                            hyperlinkTextRange.Text = value;
                            Hyperlink hyperlink = new Hyperlink(hyperlinkTextRange.Start, hyperlinkTextRange.End);
                            hyperlink.RequestNavigate += (sender, args) => Process.Start(value);
                            hyperlink.IsEnabled = true;
                            //string newlink = link;
                            //if (!link.Contains("http"))
                            //{
                            //    newlink = "http://" + link;
                            //}

                            //hyperlink.NavigateUri = new Uri(link);
                        }
                    }
                }
            });

        public static TextRange FindWordFromPosition(TextPointer position, string word)
        {
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);

                    // Find the starting index of any substring that matches "word".
                    int indexInRun = textRun.IndexOf(word);
                    if (indexInRun >= 0)
                    {
                        TextPointer start = position.GetPositionAtOffset(indexInRun);
                        TextPointer end = start.GetPositionAtOffset(word.Length);
                        return new TextRange(start, end);
                    }
                }

                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }

            // position will be null if "word" is not found.
            return null;
        }

        public static List<string> GetLinks(string message)
        {
            List<string> list = new List<string>();
            Regex urlRx = new Regex(@"<a(?![^>]+href).*?>(.*?)</a>", RegexOptions.IgnoreCase);

            MatchCollection matches = urlRx.Matches(message);
            foreach (Match match in matches)
            {
                list.Add(match.Value);
            }

            return list;
        }
    }
}


