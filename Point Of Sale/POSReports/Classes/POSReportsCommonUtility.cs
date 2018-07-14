using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSReports
{
    public static class POSReportsCommonUtility
    {
        public static void GenerateReportAsExcel(IWin32Window owner, POSReportConfig reportConfig, string fileName)
        {
            Cursor currentCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (reportConfig != null && reportConfig.Columns != null && reportConfig.Data != null)
                {
                    using (ExcelPackage ex = new ExcelPackage())
                    {
                        ExcelWorksheet work = ex.Workbook.Worksheets.Add(reportConfig.SheetName);

                        work.View.ShowGridLines = false;
                        work.Cells.Style.Font.Name = reportConfig.FontName;

                        for (int i = 0; i < reportConfig.Columns.Count; i++)
                        {
                            work.Column(i + 2).Width = reportConfig.Columns[i].Width;
                        }

                        //work.Column(1).Width = 20;
                        //work.Column(2).Width = 40;
                        //work.Column(3).Width = 22;
                        //work.Column(4).Width = 40;
                        //work.Column(5).Width = 40;
                        //work.Column(6).Width = 25.29;
                        //work.Column(7).Width = 40;
                        //work.Column(8).Width = 40;
                        //work.Column(9).Width = 25.29;

                        //Heading
                        work.Cells["D3:E4"].Merge = true;
                        work.Cells["D3:E4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        work.Cells["D3:E4"].Style.Fill.BackgroundColor.SetColor(reportConfig.HeadingBackColor);
                        work.Cells["D3:E4"].Style.Font.Size = reportConfig.HeadingFontSize;
                        work.Cells["D3:E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        work.Cells["D3:E4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        work.Cells["D3:E4"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                        work.Cells["D3:E4"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                        work.Cells["D3:E4"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                        work.Cells["D3:E4"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                        work.Cells["D3:E4"].Style.Border.Top.Color.SetColor(reportConfig.BorderColor);
                        work.Cells["D3:E4"].Style.Border.Bottom.Color.SetColor(reportConfig.BorderColor);
                        work.Cells["D3:E4"].Style.Border.Left.Color.SetColor(reportConfig.BorderColor);
                        work.Cells["D3:E4"].Style.Border.Right.Color.SetColor(reportConfig.BorderColor);
                        work.Cells["D3:E4"].Value = reportConfig.Heading;

                        // img variable actually is your image path
                        //System.Drawing.Image myImage = System.Drawing.Image.FromFile("Images/logo.png");

                        //var pic = work.Drawings.AddPicture("Logo", myImage);

                        //pic.SetPosition(5, 1300);

                        int row = 6;

                        for (int i = 0; i < reportConfig.MetaInfo.Count; i++)
                        {
                            POSReportMetaInfo metaInfo = reportConfig.MetaInfo[i];

                            if (metaInfo.LabelColSpan < 0)
                            {
                                metaInfo.LabelColSpan = 0;
                            }

                            if (metaInfo.ValueColSpan < 0)
                            {
                                metaInfo.ValueColSpan = 1;
                            }

                            work.Cells[row, 2].Style.Font.Bold = true;
                            work.Cells[row, 2].Style.Font.Color.SetColor(reportConfig.FontColor);
                            work.Cells[row, 2, row, 2 + metaInfo.ValueColSpan + metaInfo.LabelColSpan].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            work.Cells[row, 2, row, 2 + metaInfo.ValueColSpan + metaInfo.LabelColSpan].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                            if (metaInfo.LabelColSpan > 0)
                            {
                                work.Cells[row, 2, row, 2 + metaInfo.LabelColSpan].Merge = true;
                            }

                            work.Cells[row, 2, row, 2 + metaInfo.LabelColSpan].Value = metaInfo.Label;

                            if (metaInfo.ValueColSpan > 0)
                            {
                                work.Cells[row, 2 + metaInfo.ValueColSpan + metaInfo.LabelColSpan].Merge = true;
                            }

                            work.Cells[row, 2 + metaInfo.ValueColSpan + metaInfo.LabelColSpan].Value = metaInfo.Value;
                            work.Row(row).Height = metaInfo.RowHeight;

                            row++;
                        }

                        //work.Cells[row, 1].Style.Font.Bold = true;
                        //work.Cells[row, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //work.Cells[row, 1, row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //work.Cells[row, 1].Value = "Report From: ";
                        //work.Cells[row, 2].Value = this.dtpFromDate.Value.ToShortDateString();
                        //work.Row(row).Height = 20;

                        //row++;
                        //work.Cells[row, 1].Style.Font.Bold = true;
                        //work.Cells[row, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //work.Cells[row, 1, row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //work.Cells[row, 1].Value = "Report To:";
                        //work.Cells[row, 2].Value = this.dtpToDate.Value.ToShortDateString();
                        //work.Row(row).Height = 20;

                        //row++;
                        //work.Cells[row, 1].Style.Font.Bold = true;
                        //work.Cells[row, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //work.Cells[row, 1, row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //work.Cells[row, 1].Value = "Late Time Range:";
                        //work.Cells[row, 2].Value = this.dtpLateTimeStart.Value.ToShortTimeString() + " - " + this.dtpLateTimeEnd.Value.ToShortTimeString();
                        //work.Row(row).Height = 20;

                        //row++;
                        //work.Cells[row, 1].Style.Font.Bold = true;
                        //work.Cells[row, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //work.Cells[row, 1, row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //work.Cells[row, 1].Value = "Report Time: ";
                        //work.Cells[row, 2].Value = DateTime.Now.ToString();
                        //work.Row(row).Height = 20;

                        row++;
                        row++;

                        //foreach (KeyValuePair<string, List<CardHolderReportInfo>> category in data)
                        //{
                        //    if (category.Value == null)
                        //    {
                        //        continue;
                        //    }

                        //    //Section
                        //    work.Cells[row, 1].Style.Font.Bold = true;
                        //    work.Cells[row, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //    work.Cells[row, 1, row, 2].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //    work.Cells[row, 1, row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        //    work.Cells[row, 1].Value = "Category:";
                        //    work.Cells[row, 2].Value = category.Key;
                        //    work.Row(row).Height = 20;

                        //    //Data
                        //    row++;
                        int columnsCount = reportConfig.Columns.Count;

                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Top.Color.SetColor(reportConfig.HeaderBorderColor);
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Bottom.Color.SetColor(reportConfig.HeaderBorderColor);
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Left.Color.SetColor(reportConfig.HeaderBorderColor);
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Right.Color.SetColor(reportConfig.HeaderBorderColor);

                        work.Cells[row, 2, row, 1 + columnsCount].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        work.Cells[row, 2, row, 1 + columnsCount].Style.Fill.BackgroundColor.SetColor(reportConfig.HeaderColor);
                        work.Cells[row, 2, row, 1 + columnsCount].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        work.Cells[row, 2, row, 1 + columnsCount].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        for (int i = 0; i < columnsCount; i++)
                        {
                            POSReportColumn column = reportConfig.Columns[i];

                            work.Cells[row, i + 2].Value = column.Name;
                        }

                        work.Row(row).Height = reportConfig.HeaderRowHeight;

                        //work.Cells[row, 1, row, 9].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        //work.Cells[row, 1, row, 9].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        //work.Cells[row, 1, row, 9].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        //work.Cells[row, 1, row, 9].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                        //work.Cells[row, 1, row, 9].Style.Border.Top.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 9].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 9].Style.Border.Left.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));
                        //work.Cells[row, 1, row, 9].Style.Border.Right.Color.SetColor(System.Drawing.Color.FromArgb(247, 150, 70));

                        //work.Cells[row, 1, row, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        //work.Cells[row, 1, row, 9].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(253, 233, 217));
                        //work.Cells[row, 1, row, 9].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        //work.Cells[row, 1, row, 9].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        //work.Cells[row, 1].Value = "Blocked Status Number";
                        //    work.Cells[row, 2].Value = "First Name";
                        //    work.Cells[row, 3].Value = "CNIC Number";
                        //    work.Cells[row, 4].Value = "Blocked By";
                        //    work.Cells[row, 5].Value = "Blocked Reason";
                        //    work.Cells[row, 6].Value = "Blocked Time";
                        //    work.Cells[row, 7].Value = "UnBlocked By";
                        //    work.Cells[row, 8].Value = "UnBlocked Reason";
                        //    work.Cells[row, 9].Value = "UnBlocked Time";
                        //    work.Row(row).Height = 20;

                        for (int i = 0; i < reportConfig.Data.Count; i++)
                        {
                            POSReportData data = reportConfig.Data[i];
                            row++;
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Top.Color.SetColor(reportConfig.BorderColor);
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Bottom.Color.SetColor(reportConfig.BorderColor);
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Left.Color.SetColor(reportConfig.BorderColor);
                            work.Cells[row, 2, row, 1 + columnsCount].Style.Border.Right.Color.SetColor(reportConfig.BorderColor);

                            if (i % 2 == 0)
                            {
                                work.Cells[row, 2, row, 1 + columnsCount].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                work.Cells[row, 2, row, 1 + columnsCount].Style.Fill.BackgroundColor.SetColor(reportConfig.AltColor);
                            }

                            work.Cells[row, 2, row, 1 + columnsCount].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            //work.Cells[row, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            //work.Cells[row, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                            for (int j = 0; j < columnsCount; j++)
                            {
                                work.Cells[row, j + 2].Value = data.Values[j];
                            }

                            //work.Cells[row, 1].Value = chl.BlockedStatus;
                            //work.Cells[row, 2].Value = chl.FirstName;
                            //work.Cells[row, 3].Value = chl.CNICNumber;
                            //work.Cells[row, 4].Value = chl.BlockedBy.ToString();
                            //work.Cells[row, 4].Value = chl.BlockedReason.ToString();
                            //work.Cells[row, 4].Value = chl.BlockedTime.ToString();
                            //work.Cells[row, 4].Value = chl.UnBlockedBy.ToString();
                            //work.Cells[row, 4].Value = chl.UnBlockedReason.ToString();
                            //work.Cells[row, 5].Value = chl.UnBlockedTime.ToString();

                            work.Row(row).Height = reportConfig.DataRowHeight;
                        }

                        row++;
                        row++;


                        //}

                        ex.SaveAs(new System.IO.FileInfo(fileName));

                        System.Diagnostics.Process.Start(fileName);
                    }
                }
                Cursor.Current = currentCursor;
            }
            catch (Exception exp)
            {
                Cursor.Current = currentCursor;
                if (exp.InnerException != null && exp.InnerException.InnerException != null)
                {
                    if (exp.InnerException.InnerException.HResult == -2147024864)
                    {
                        MessageBox.Show(owner, "\"" + fileName + "\" is already is use.\n\nPlease close it and generate report again.");
                    }
                    if (exp.InnerException.InnerException.HResult == -2147024891)
                    {
                        MessageBox.Show(owner, "You did not have rights to save file on selected location.\n\nPlease run as administrator.");
                    }
                }
                else
                {
                    MessageBox.Show(owner, exp.Message);
                }

            }

        }

        public static void SetReportConfigStyling(POSReportConfig reportConfig)
        {
            reportConfig.DataRowHeight = 20;
            reportConfig.AltColor = System.Drawing.Color.LightGray;
            reportConfig.BorderColor = System.Drawing.Color.FromArgb(247, 150, 70);
            reportConfig.FontColor = System.Drawing.Color.FromArgb(247, 150, 70);
            reportConfig.FontName = "Segoe UI Light";
            reportConfig.HeaderBorderColor = System.Drawing.Color.FromArgb(247, 150, 70);
            reportConfig.HeaderColor = System.Drawing.Color.FromArgb(253, 233, 217);
            reportConfig.HeaderRowHeight = 20;
            reportConfig.HeadingBackColor = System.Drawing.Color.FromArgb(252, 213, 180);
            reportConfig.HeadingFontSize = 22;
        }
    }
}
