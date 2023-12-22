using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Data;
using shop.Forms;
namespace shop.Classes
{
    static class Cheque
    {
        private static Word.Application application;
        private static Word.Document document;
        private static Word.Paragraph newParagraph;
        private static Word.Table paymentsTable;
        private static Word.Range cellRange;
        public static void CreateNewCheque()
        {
            application = new Word.Application();
            document = application.Documents.Add();
            document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            document.PageSetup.TopMargin = application.InchesToPoints(1);
            document.PageSetup.BottomMargin = application.InchesToPoints(0.60f);
            document.PageSetup.LeftMargin = application.InchesToPoints(0.80f);
            document.PageSetup.RightMargin = application.InchesToPoints(0.59f);
            document.ActiveWindow.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            document.ActiveWindow.Selection.ParagraphFormat.SpaceAfter = 0.0F;
        }
        public static void AddNewParagraphsCenter(string textParagraph, int fontSize, int fontBold)
        {
            RangeParagraph(textParagraph, fontSize, fontBold);
            newParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            newParagraph.Range.InsertParagraphAfter();
            newParagraph.CloseUp();
        }
        public static void AddNewParagraphsLeft(string textParagraph, int fontSize, int fontBold)
        {
            RangeParagraph(textParagraph, fontSize, fontBold);
            newParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            newParagraph.Range.InsertParagraphAfter();
            newParagraph.CloseUp();
        }
        public static void AddTable()
        {
            newParagraph = document.Paragraphs.Add();
            Word.Range tableRange = newParagraph.Range;
            paymentsTable = document.Tables.Add(tableRange, 1, 7);
            newParagraph.Range.Font.Size = 14;
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            newParagraph.SpaceAfter = 0;
            newParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            paymentsTable.Columns[1].Width = 300;
            paymentsTable.Columns[2].Width = 60;
            paymentsTable.Columns[3].Width = 80;
            paymentsTable.Columns[4].Width = 80;
            paymentsTable.Columns[5].Width = 80;
            paymentsTable.Columns[6].Width = 80;
            paymentsTable.Columns[7].Width = 100;
            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Название";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Кол-во";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Стоимость";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Скидка (%)";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Скидка (руб.)";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Дата получения";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Всего";
            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }
        public static void RangeCellsTable()
        {
            int y = 2;
            int itog = 0;
            foreach (DataRow row in Basket.GetBasket.Rows)
            {
                paymentsTable.Rows.Add();
                paymentsTable.Rows[y].Range.Bold = 0;
                cellRange = paymentsTable.Cell(y, 1).Range;
                cellRange.Text = row[1].ToString();
                cellRange = paymentsTable.Cell(y, 2).Range;
                cellRange.Text = row[2].ToString();
                cellRange = paymentsTable.Cell(y, 3).Range;
                cellRange.Text = row[5].ToString();
                cellRange = paymentsTable.Cell(y, 4).Range;
                cellRange.Text = row[7].ToString();
                cellRange = paymentsTable.Cell(y, 5).Range;
                cellRange.Text = row[8].ToString();
                cellRange = paymentsTable.Cell(y, 6).Range;
                cellRange.Text = DateTime.Now.AddDays(BasketShow.dayDelivery).ToString("yyyy-MM-dd");
                cellRange = paymentsTable.Cell(y, 7).Range;
                cellRange.Text = row[3].ToString();
                itog += Convert.ToInt32(row[3].ToString());
                y++;
                if (y == Basket.GetBasket.Rows.Count + 2)
                {
                    paymentsTable.Rows.Add();
                    paymentsTable.Rows[y].Range.Bold = 1;
                    cellRange = paymentsTable.Cell(y, 6).Range;
                    cellRange.Text = "Итого:";
                    cellRange = paymentsTable.Cell(y, 7).Range;
                    cellRange.Text = itog.ToString();
                }
            }
            newParagraph.SpaceAfter = 10;
        }
        private static void RangeParagraph(string textParagraph, int fontSize, int fontBold)
        {
            newParagraph = document.Content.Paragraphs.Add();
            newParagraph.Range.Text = textParagraph;
            newParagraph.Range.Font.Size = Convert.ToInt32(fontSize);
            newParagraph.Range.Font.Bold = fontBold;
            newParagraph.SpaceAfter = 10;
        }
        public static void SaveCheque()
        {
            try
            {
                document.SaveAs(Directory.GetCurrentDirectory() + "\\cheques\\Чек №" + BasketShow.numberOrder + " от " + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".docx");
            }
            catch
            {
                MessageBox.Show("При сохранении возникли ошибки", "Внимание", MessageBoxButtons.OK);
                return;
            }
        }
        public static void Vis()
        {
            application.Visible = true;
        }
    }
}
