using System;
using Microsoft.Office.Interop.Word;
using word =  Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace docxtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string test = "Test Value Properties";

                //Create an instance for word app  
                word.Application winword = new word.Application();

                //Set animation status for word application  
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                winword.Visible = false;

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                //Create a new document  
                word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document  
                foreach (word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.  
                    word.Range headerRange = section.Headers[word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Header text goes here";
                }

                //Add the footers into the document  
                foreach (word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.  
                    word.Range footerRange = wordSection.Footers[word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                }

                //adding text to document  
                document.Content.SetRange(0, 0);
                document.Content.Font.Size = 10;
                document.Content.Text = 
                    $"Candidate Name : {test} \n " +
                    $"Address : {test} \n" +
                    $"Post Code : {test} \n" +
                    $"Contact Number : {test} \n" +
                    $"Job Role : {test} \n" +
                    $"Date Of Birth : {test} \n" +
                    $"Enhance DBS : {test} \n" +
                    $"Work Permit : {test} \n" +
                    $"Eligible to work in the UK : {test} \n" +
                    $"Confirmation of ID : {test} \n" +
                    $"References Received : {test} \n" +
                    Environment.NewLine;

                //headerRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                //Add paragraph with Heading 1 style  
                word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Heading 2";
                para1.Range.set_Style(ref styleHeading1);
                para1.Range.Text = $"Candidate has agreed to work under New Horizon Healthcare Services policy and procedures.";
                para1.Range.InsertParagraphAfter();

                //Add paragraph with Heading 2 style  
                word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "Education and Training";
                para2.Range.InsertParagraphAfter();

                //Add paragraph 3
                word.Paragraph para3 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading3 = "Heading 2";
                para3.Range.set_Style(ref styleHeading3);
                para3.Range.Text = $"Statutory and Mandatory Training";
                para3.Range.InsertParagraphAfter();

                //Create a 5X5 table and insert some dummy record  
                Table firstTable = document.Tables.Add(para1.Range, 15, 3, ref missing, ref missing);

                firstTable.Borders.Enable = 1;
                foreach (Row row in firstTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here  
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Center alignment for the Header cells  
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row  
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }

                //Save the document  
                object filename = "RoughMockUp";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                Console.WriteLine("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

