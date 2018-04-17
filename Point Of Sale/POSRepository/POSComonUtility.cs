using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSRepository
{
    public static class POSComonUtility
    {
        public static List<POSGridItemInfo> SearchItem(string itemName, Form form)
        {
            List<POSGridItemInfo> gridItems = new List<POSGridItemInfo>();

            if (!string.IsNullOrEmpty(itemName))
            {
                List<POSItemInfo> items = POSDbUtility.GetAllPOSItems();
                POSItemInfo item = items.Find(posItem => posItem.Barcode == itemName);

                if (item == null)
                {
                    items = items.FindAll(posItem => posItem.Name.Contains(itemName));

                    if (items == null || items.Count == 0)
                    {
                        List<POSRefundInfo> refunds = POSDbUtility.GetAllPOSRefundInfo();

                        POSRefundInfo refundInfo = refunds.Find(refund => refund.Barcode == itemName);

                        if (refundInfo != null)
                        {
                            if (refundInfo.Refunded)
                            {
                                MessageBox.Show(form, "This refund slip is already refunded.");
                            }
                            else
                            {
                                gridItems.Add(new POSGridItemInfo(refundInfo));
                            }

                        }
                    }
                    else
                    {
                        gridItems.AddRange((from posItem in items
                                            where posItem != null
                                            select new POSGridItemInfo(posItem)).ToList());
                    }
                }
                else
                {
                    gridItems.Add(new POSGridItemInfo(item));
                }


            }

            return gridItems;
        }

        public static string GetInnerExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            Exception innerException = ex.InnerException;

            while (innerException != null)
            {
                message += "\n" + innerException.Message;
                innerException = innerException.InnerException;
            }

            return message;
        }

        public static bool ValidateInputs(List<TextBox> lstTextBoxes)
        {
            bool validated = false;

            if (lstTextBoxes != null)
            {
                List<string> lstInvalidTextboxes = (from text in lstTextBoxes
                                                    where text != null && string.IsNullOrEmpty(text.Text)
                                                    select text.Name).ToList();

                validated = lstInvalidTextboxes.Count == 0;

                foreach (TextBox textbox in lstTextBoxes)
                {
                    if (textbox.ReadOnly)
                    {
                        continue;
                    }
                    if (lstInvalidTextboxes.Contains(textbox.Name))
                    {
                        textbox.BackColor = Color.Yellow;
                    }
                    else
                    {
                        textbox.BackColor = Color.White;
                    }

                }
            }

            return validated;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] array = null;

            if (imageIn != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    array = ms.ToArray();
                }
            }

            return array;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;

            if (byteArrayIn != null)
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    returnImage = Image.FromStream(ms);
                }
            }

            return returnImage;
        }

        public static bool IsDigitsOnly(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public static void AllowNumericOnly(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        public static void DrawShopInfo(Graphics graphic, string shopName, string shopAddress, string contactInfo, ref int pixY, Brush nameBrush = null, Brush addressBrush = null, Brush contactBrush = null, string nameFontFamily = null, string addressFontFamily = null, string contactFontFamily = null, bool fillBackGround = true, int pixX = 0, int width = 280, int fontSize = 9, int fontHeight = 26)
        {
            POSComonUtility.Draw16FontSizeText(graphic, shopName, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, width, 1, fillBackGround, true, true, true, ref pixY, pixX, brush: nameBrush, fontFamily:nameFontFamily, fontHeight: fontHeight);

            if (fontSize == 9)
            {
                POSComonUtility.Draw9FontSizeText(graphic, shopAddress, FontStyle.Regular, StringAlignment.Center, StringAlignment.Center, width, 1, false, false, true, true, ref pixY, pixX, brush: addressBrush, fontFamily: addressFontFamily);
            }
            else if(fontSize == 12)
            {
                POSComonUtility.Draw12FontSizeText(graphic, shopAddress, FontStyle.Regular, StringAlignment.Center, StringAlignment.Center, width, 1, false, false, true, true, ref pixY, pixX, brush: addressBrush, fontFamily: addressFontFamily);
            }

            if (fontSize == 9)
            {
                POSComonUtility.Draw9FontSizeText(graphic, contactInfo, FontStyle.Bold | FontStyle.Underline, StringAlignment.Center, StringAlignment.Center, width, 0, false, false, false, false, ref pixY, pixX, brush: contactBrush, fontFamily: contactFontFamily);
            }
            else if (fontSize == 12)
            {
                POSComonUtility.Draw12FontSizeText(graphic, contactInfo, FontStyle.Regular | FontStyle.Underline, StringAlignment.Center, StringAlignment.Center, width, 0, false, false, false, false, ref pixY, pixX, brush: contactBrush, fontFamily: contactFontFamily);
            }
            

        }

        public static void DrawSalesManInfo(Graphics graphic, string salesManName, ref int pixY, int pixX, int width = 200)
        {
            POSComonUtility.Draw12FontSizeText(graphic, "Sales Man:", FontStyle.Regular | FontStyle.Underline, StringAlignment.Near, StringAlignment.Center, width, 4, false, false, true, true, ref pixY, pixX, brush: Brushes.DarkBlue);

            POSComonUtility.Draw16FontSizeText(graphic, salesManName, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, width, 1, false, false, true, true, ref pixY, pixX, brush: Brushes.DarkBlue);
        }

        public static void DrawSalesReceiptInfo(Graphics graphic, string heading, string receiptNumber, DateTime receiptDate, string cashierName, ref int pixY)
        {
            POSComonUtility.Draw12FontSizeText(graphic, heading, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, 280, 4, true, true, true, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, "Receipt#: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 94, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, receiptNumber, FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 186, 0, false, false, true, false, ref pixY, 94);

            int bigestHeight = 0;

            int height1 = POSComonUtility.Draw9FontSizeText(graphic, "Date: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, true, ref pixY);
            bigestHeight = height1;

            int height2 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.Date.ToShortDateString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 70);

            if (bigestHeight < height2)
            {
                bigestHeight = height2;
            }

            int height3 = POSComonUtility.Draw9FontSizeText(graphic, "Time: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, false, ref pixY, 140);

            if (bigestHeight < height3)
            {
                bigestHeight = height3;
            }

            int height4 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.ToShortTimeString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 210);

            if (bigestHeight < height4)
            {
                bigestHeight = height4;
            }
            pixY += bigestHeight;

            height1 = POSComonUtility.Draw9FontSizeText(graphic, "Day: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, true, ref pixY);
            bigestHeight = height1;

            height2 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.DayOfWeek.ToString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 70);

            if (bigestHeight < height2)
            {
                bigestHeight = height2;
            }

            height3 = POSComonUtility.Draw9FontSizeText(graphic, "Cashier: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, false, ref pixY, 140);

            if (bigestHeight < height3)
            {
                bigestHeight = height3;
            }

            height4 = POSComonUtility.Draw9FontSizeText(graphic, cashierName, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 210);

            if (bigestHeight < height4)
            {
                bigestHeight = height4;
            }
            pixY += bigestHeight;

        }

        public static void DrawRefundReceiptInfo(Graphics graphic, string heading, string refundSlipNumber, string billNumber, DateTime receiptDate, string cashierName, bool amountRefunded, ref int pixY)
        {
            POSComonUtility.Draw16FontSizeText(graphic, heading, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, 280, 4, false, true, true, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, "Refund Slip#: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 94, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, refundSlipNumber, FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 186, 0, false, false, true, false, ref pixY, 94);

            POSComonUtility.Draw9FontSizeText(graphic, "Bill#: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 94, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, billNumber, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 186, 0, false, false, true, false, ref pixY, 94);

            int bigestHeight = 0;

            int height1 = POSComonUtility.Draw9FontSizeText(graphic, "Date: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, true, ref pixY);
            bigestHeight = height1;

            int height2 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.Date.ToShortDateString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 70);

            if (bigestHeight < height2)
            {
                bigestHeight = height2;
            }

            int height3 = POSComonUtility.Draw9FontSizeText(graphic, "Time: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, false, ref pixY, 140);

            if (bigestHeight < height3)
            {
                bigestHeight = height3;
            }

            int height4 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.ToShortTimeString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 210);

            if (bigestHeight < height4)
            {
                bigestHeight = height4;
            }
            pixY += bigestHeight;

            height1 = POSComonUtility.Draw9FontSizeText(graphic, "Day: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, true, ref pixY);
            bigestHeight = height1;

            height2 = POSComonUtility.Draw9FontSizeText(graphic, receiptDate.DayOfWeek.ToString(), FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 70);

            if (bigestHeight < height2)
            {
                bigestHeight = height2;
            }

            height3 = POSComonUtility.Draw9FontSizeText(graphic, "Cashier: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, false, ref pixY, 140);

            if (bigestHeight < height3)
            {
                bigestHeight = height3;
            }

            height4 = POSComonUtility.Draw9FontSizeText(graphic, cashierName, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 210);

            if (bigestHeight < height4)
            {
                bigestHeight = height4;
            }

            pixY += bigestHeight;

            height1 = POSComonUtility.Draw9FontSizeText(graphic, "Amount Refunded: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, true, ref pixY);
            bigestHeight = height1;

            height2 = POSComonUtility.Draw9FontSizeText(graphic, amountRefunded ? "Yes" : "No", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 0, false, false, false, false, ref pixY, 70);

            if (bigestHeight < height2)
            {
                bigestHeight = height2;
            }
            pixY += bigestHeight;

        }

        public static void DrawItemsHeaders(Graphics graphic, ref int pixY)
        {
            POSComonUtility.Draw9FontSizeText(graphic, "Qty", FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 28, 2, true, true, false, true, ref pixY, borderPen: Pens.White, addFillHeight: true);

            POSComonUtility.Draw9FontSizeText(graphic, "Product Name", FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 143, 1, true, true, false, false, ref pixY, 29, borderPen: Pens.White, addFillHeight: true);

            POSComonUtility.Draw9FontSizeText(graphic, "Price", FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 35, 1, true, true, false, false, ref pixY, 173, borderPen: Pens.White, addFillHeight: true);

            POSComonUtility.Draw9FontSizeText(graphic, "Dis", FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 28, 1, true, true, false, false, ref pixY, 209, borderPen: Pens.White, addFillHeight: true);

            POSComonUtility.Draw9FontSizeText(graphic, "Total", FontStyle.Bold, StringAlignment.Near, StringAlignment.Center, 42, 1, true, true, true, false, ref pixY, 238, borderPen: Pens.White, addFillHeight: true);
        }

        public static void DrawCategoryRow(Graphics graphic, string categoryName, ref int pixY)
        {
            POSComonUtility.Draw9FontSizeText(graphic, categoryName, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, 280, 2, true, true, true, true, ref pixY);
        }

        public static void DrawPOSItemInfo(Graphics graphic, string quantity, string productName, string productCode, string price, string discount, string total, ref int pixY)
        {
            int bigestHeight = 0;

            int height1 = POSComonUtility.Draw9FontSizeText(graphic, quantity, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 28, 2, false, false, false, true, ref pixY);
            bigestHeight = height1;

            int pixYtemp = pixY;

            int height2 = POSComonUtility.Draw9FontSizeText(graphic, productName, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 143, 1, false, false, true, false, ref pixY, 29);

            int height3 = POSComonUtility.Draw9FontSizeText(graphic, productCode, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 143, 1, false, false, false, false, ref pixY, 29);

            if (bigestHeight < (height2 + height3))
            {
                bigestHeight = (height2 + height3);
            }

            pixY = pixYtemp;

            int height4 = POSComonUtility.Draw9FontSizeText(graphic, price, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 35, 1, false, false, false, false, ref pixY, 173);

            if (bigestHeight < height4)
            {
                bigestHeight = height4;
            }

            int height5 = POSComonUtility.Draw9FontSizeText(graphic, discount, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 28, 1, false, false, false, false, ref pixY, 209);

            if (bigestHeight < height5)
            {
                bigestHeight = height5;
            }

            int height6 = POSComonUtility.Draw9FontSizeText(graphic, total, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 42, 1, false, false, false, false, ref pixY, 238);

            if (bigestHeight < height6)
            {
                bigestHeight = height6;
            }

            pixY += bigestHeight;

        }

        public static void DrawBillInfo(Graphics graphic, string itemsCount, string totalQuantity, string totalGross, string totalDiscount, string total, string amountReceived, string amountReturned, ref int pixY)
        {
            graphic.DrawLine(Pens.Black, 0, pixY, 280, pixY);

            POSComonUtility.Draw9FontSizeText(graphic, itemsCount, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, false, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, totalQuantity, FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw9FontSizeText(graphic, "Total Gross: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, totalGross, FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw9FontSizeText(graphic, "Total Discount: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, totalDiscount, FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw9FontSizeText(graphic, "Total: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, total, FontStyle.Bold, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw16FontSizeText(graphic, total, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, 280, 2, false, true, true, true, ref pixY, addFillHeight: true);

            POSComonUtility.Draw9FontSizeText(graphic, "Received:", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, amountReceived, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 70);

            POSComonUtility.Draw9FontSizeText(graphic, "Returned:", FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 70, 0, false, false, false, false, ref pixY, 140);

            POSComonUtility.Draw9FontSizeText(graphic, amountReturned, FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 70, 0, false, false, true, false, ref pixY, 210);

        }

        public static void DrawRefundBillInfo(Graphics graphic, string itemsCount, string totalQuantity, string total,  ref int pixY)
        {
            graphic.DrawLine(Pens.Black, 0, pixY, 280, pixY);

            POSComonUtility.Draw9FontSizeText(graphic, itemsCount, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, false, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, totalQuantity, FontStyle.Regular, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw9FontSizeText(graphic, "Total Refund: ", FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 140, 1, false, false, false, true, ref pixY);

            POSComonUtility.Draw9FontSizeText(graphic, total, FontStyle.Bold, StringAlignment.Far, StringAlignment.Center, 140, 0, false, false, true, false, ref pixY, 140);

            POSComonUtility.Draw16FontSizeText(graphic, total, FontStyle.Bold, StringAlignment.Center, StringAlignment.Center, 280, 2, false, true, true, true, ref pixY, addFillHeight: true);
        }

        public static void DrawBarcode(Graphics graphic, string billCode, ref int pixY, int width = 280, int pixX = 0, int barcodeHeight = 60, int barcodeWidth = 280, bool drawLine = true, int barcodeXShift = 0)
        {
            if (drawLine)
            {
                graphic.DrawLine(Pens.Black, pixX, pixY, width + pixX, pixY);
                pixY += 10;
            }

            pixY += 10;

            Barcode barcode = new Barcode();
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.Height = barcodeHeight;
            barcode.Width = barcodeWidth;

            Image img = barcode.Encode(TYPE.CODE128, billCode);

            graphic.DrawImage(img, new RectangleF(pixX + barcodeXShift, pixY, barcodeWidth, barcodeHeight));

            pixY += barcodeHeight;

            POSComonUtility.Draw9FontSizeText(graphic, billCode, FontStyle.Regular, StringAlignment.Center, StringAlignment.Center, width, 0, false, false, true, false, ref pixY, pixX);
        }

        public static void DrawBillEndingInfo(Graphics graphic, SystemSettings systemSettings, bool isRefund, ref int pixY)
        {
            bool addTopGap = true;

            if (systemSettings != null && !string.IsNullOrEmpty(systemSettings.BillTermsAndConditions))
            {
                List<string> termsAndCoditions = isRefund ? systemSettings.RefundTermsAndConditions.Split('^').ToList() : systemSettings.BillTermsAndConditions.Split('^').ToList();

                foreach (string terms in termsAndCoditions)
                {
                    if (addTopGap)
                    {
                        POSComonUtility.Draw9FontSizeText(graphic, terms, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 280, 3, false, false, true, true, ref pixY);
                        addTopGap = false;
                    }
                    else
                    {
                        POSComonUtility.Draw9FontSizeText(graphic, terms, FontStyle.Regular, StringAlignment.Near, StringAlignment.Center, 280, 0, false, false, true, false, ref pixY);
                    }
                }
            }

            //string condition1 = "1. Kindly bring cash invoice after sales and services.";
            //string condition2 = "2. In terms of exchange and refund items should be in saleable condition with orignal packing.";
            //string condition3 = "3. Store timing: 11AM to 11PM, Sunday Open and on Friday store will open at 3PM";
            string thanksNote = systemSettings.ThanksNote;

            if (!string.IsNullOrEmpty(thanksNote))
            {
                POSComonUtility.Draw16FontSizeText(graphic, thanksNote, FontStyle.Regular, StringAlignment.Center, StringAlignment.Center, 280, 0, false, false, true, addTopGap, ref pixY);
            }

            string aboutDev = "Designed and developed by Hassan Ahmed Baig h.baig34@gmail.com";
            
            graphic.DrawLine(Pens.Black, 0, pixY, 280, pixY);

            POSComonUtility.Draw9FontSizeText(graphic, aboutDev, FontStyle.Regular, StringAlignment.Center, StringAlignment.Center, 280, 1, false, false, true, true, ref pixY);
        }

        private static int Draw12FontSizeText(Graphics graphic, string text, FontStyle style, StringAlignment alignment, StringAlignment lineAlignment, int totalWidth, int topGapLines, bool fillBackground, bool drawBorder, bool changeLine, bool addTopGap, ref int pixY, int pixX = 0, Pen borderPen = null, bool addFillHeight = false, Brush brush = null, string fontFamily = null)
        {
            return DrawText(graphic, text, 12, style, alignment, lineAlignment, totalWidth, topGapLines, 11, 20, 5, fillBackground, drawBorder, changeLine, addTopGap, ref pixY, pixX, borderPen, addFillHeight, brush, fontFamily);
        }

        private static int Draw9FontSizeText(Graphics graphic, string text, FontStyle style, StringAlignment alignment, StringAlignment lineAlignment, int totalWidth, int topGapLines, bool fillBackground, bool drawBorder, bool changeLine, bool addTopGap, ref int pixY, int pixX = 0, Pen borderPen = null, bool addFillHeight = false, Brush brush = null, string fontFamily = null)
        {
            return DrawText(graphic, text, 9, style, alignment, lineAlignment, totalWidth, topGapLines, 7, 16, 3, fillBackground, drawBorder, changeLine, addTopGap, ref pixY, pixX, borderPen, addFillHeight, brush, fontFamily);            
        }

        private static int Draw16FontSizeText(Graphics graphic, string text, FontStyle style, StringAlignment alignment, StringAlignment lineAlignment, int totalWidth, int topGapLines, bool fillBackground, bool drawBorder, bool changeLine, bool addTopGap, ref int pixY, int pixX = 0, Pen borderPen = null, bool addFillHeight = false, Brush brush = null, string fontFamily = null, int fontHeight = 26)
        {
            return DrawText(graphic, text, 16, style, alignment, lineAlignment, totalWidth, topGapLines, 15, fontHeight, 10, fillBackground, drawBorder, changeLine, addTopGap, ref pixY, pixX, borderPen, addFillHeight, brush, fontFamily);            
        }

        private static int DrawText(Graphics graphic,string text, int fontSize, FontStyle style, StringAlignment alignment, StringAlignment lineAlignment, int totalWidth, int topGapLines, int pixCountPerChar, int fontHeight, int fillHeight, bool fillBackground, bool drawBorder, bool changeLine, bool addTopGap, ref int pixY, int pixX, Pen borderPen, bool addFillHeight = false, Brush brush = null, string fontFamily = null)
        {
            Font font = new Font(fontFamily == null ? "Segoe UI" : fontFamily, fontSize, style);

            if (addTopGap)
            {
                pixY += 10 * topGapLines;
            }


            StringFormat format = new StringFormat();
            format.Alignment = alignment;
            format.LineAlignment = lineAlignment;           

            int lines = GetNumberOfLines(text, totalWidth, pixCountPerChar);
            int height = 0;

            Brush textBrush = brush == null ? (fillBackground ? Brushes.White : Brushes.Black) : brush;

            if (addFillHeight)
            {
                height = (lines * fontHeight) + fillHeight;
            }
            else
            {
                height = (lines * fontHeight);
            }

            if (drawBorder || fillBackground)
            {
                if (borderPen == null)
                {
                    borderPen = Pens.Black;
                }

                graphic.DrawRectangle(borderPen, new Rectangle(pixX, pixY, totalWidth, height));
            }

            if (fillBackground)
            {
                graphic.FillRectangle(Brushes.Black, new Rectangle(pixX, pixY, totalWidth, height));
            }

            graphic.DrawString(text, font, textBrush, new RectangleF(pixX, pixY, totalWidth, height), format);

            if (changeLine)
            {
                pixY += height;
            }

            return height;
        }

        private static int GetNumberOfLines(string text, int totalWidth, int pixCountPerChar)
        {
            int lines = 1;

            string[] arrSplit = text.Split(' ');
            int currentLineWidth = 0;
            int i = 0;
            int totalLength = arrSplit.Length;

            foreach (string word in arrSplit)
            {
                int lettersCount = word.Length;

                if (i != 0)
                {
                    lettersCount++;
                }

                int wordWidth = lettersCount * pixCountPerChar;

                if (wordWidth < totalWidth)
                {
                    if ((wordWidth + currentLineWidth) < totalWidth)
                    {
                        currentLineWidth += wordWidth;
                    }
                    else
                    {
                        lines++;
                        currentLineWidth = wordWidth;
                    }
                }

                i++;
            }
            return lines;
        }

        public static string PopulateRoles(bool isAdmin,
                                            bool viewItems,
                                            bool updateItems,
                                            bool viewVendors,
                                            bool updateVendors,
                                            bool printBarcode,
                                            bool createBill,
                                            bool refundBill,
                                            bool searchItems)
        {
            string roles = string.Empty;

            if (isAdmin)
            {
                roles += "Admin,";
            }

            if (viewItems)
            {
                roles += "ViewItems,";
            }

            if (updateItems)
            {
                roles += "UpdateItems,";
            }

            if (viewVendors)
            {
                roles += "ViewVendors,";
            }

            if (updateVendors)
            {
                roles += "UpdateVendors,";
            }

            if (printBarcode)
            {
                roles += "PrintBarcode,";
            }

            if (createBill)
            {
                roles += "CreateBill,";
            }

            if (refundBill)
            {
                roles += "RefundBill,";
            }

            if (searchItems)
            {
                roles += "SearchItem";
            }

            return roles;
        }
    }

    public enum POSStatusCodes
    {
        Success,
        Failed,
        Aborted
    }
}
