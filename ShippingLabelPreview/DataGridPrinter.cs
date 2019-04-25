using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Collections;

namespace WindowsFormsApp1
{

    public class DataGridPrinter
    {

        private PrintDocument ThePrintDocument;
        private DataTable TheTable;
        private DataGrid TheDataGrid;

        public int RowCount = 0;  // current count of rows;
        private const int kVerticalCellLeeway = 10;
        public int PageNumber = 1;
        public ArrayList Lines = new ArrayList();

        int PageWidth;
        int PageHeight;
        int TopMargin;
        int LeftMargin;
        int BottomMargin;



        public DataGridPrinter(DataGrid aGrid, PrintDocument aPrintDocument, DataTable aTable)
        {
            //
            // TODO: Add constructor logic here
            //
            TheDataGrid = aGrid;
            ThePrintDocument = aPrintDocument;
            TheTable = aTable;

            PageWidth = ThePrintDocument.DefaultPageSettings.PaperSize.Width;
            PageHeight = ThePrintDocument.DefaultPageSettings.PaperSize.Height;
            TopMargin = ThePrintDocument.DefaultPageSettings.Margins.Top;
            LeftMargin = ThePrintDocument.DefaultPageSettings.Margins.Left;
            BottomMargin = ThePrintDocument.DefaultPageSettings.Margins.Bottom;

        }

        public void DrawHeader(Graphics g)
        {
            SolidBrush ForeBrush = new SolidBrush(TheDataGrid.HeaderForeColor);
            SolidBrush BackBrush = new SolidBrush(TheDataGrid.HeaderBackColor);
            Pen TheLinePen = new Pen(TheDataGrid.GridLineColor, 1);
            StringFormat cellformat = new StringFormat();
            cellformat.Trimming = StringTrimming.EllipsisCharacter;
            cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;



            int columnwidth = PageWidth / TheTable.Columns.Count;

            int initialRowCount = RowCount;

            // draw the table header
            float startxposition = TheDataGrid.Location.X;
            RectangleF nextcellbounds = new RectangleF(0, 0, 0, 0);

            RectangleF HeaderBounds = new RectangleF(0, 0, 0, 0);

            HeaderBounds.X = TheDataGrid.Location.X;
            HeaderBounds.Y = TheDataGrid.Location.Y + TopMargin + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
            HeaderBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
            HeaderBounds.Width = PageWidth;

            g.FillRectangle(BackBrush, HeaderBounds);

            for (int k = 0; k < TheTable.Columns.Count; k++)
            {
                string nextcolumn = TheTable.Columns[k].ToString();
                RectangleF cellbounds = new RectangleF(startxposition, TheDataGrid.Location.Y + TopMargin + 2 + (RowCount - initialRowCount) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                    columnwidth,
                    TheDataGrid.HeaderFont.SizeInPoints + kVerticalCellLeeway);
                nextcellbounds = cellbounds;

                if (startxposition + columnwidth <= PageWidth)
                {
                    g.DrawString(nextcolumn, TheDataGrid.HeaderFont, ForeBrush, cellbounds, cellformat);
                }

                startxposition = startxposition + columnwidth;

            }

            if (TheDataGrid.GridLineStyle != DataGridLineStyle.None)
                g.DrawLine(TheLinePen, TheDataGrid.Location.X, nextcellbounds.Bottom, PageWidth, nextcellbounds.Bottom);
        }

        public bool DrawRows(Graphics g)
        {
            int lastRowBottom = TopMargin;

            try
            {
                SolidBrush ForeBrush = new SolidBrush(TheDataGrid.ForeColor);
                SolidBrush BackBrush = new SolidBrush(TheDataGrid.BackColor);
                SolidBrush AlternatingBackBrush = new SolidBrush(TheDataGrid.AlternatingBackColor);
                Pen TheLinePen = new Pen(TheDataGrid.GridLineColor, 1);
                StringFormat cellformat = new StringFormat();
                cellformat.Trimming = StringTrimming.EllipsisCharacter;
                cellformat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;
                int columnwidth = PageWidth / TheTable.Columns.Count;

                int initialRowCount = RowCount;

                RectangleF RowBounds = new RectangleF(0, 0, 0, 0);

                // draw vertical lines




                // draw the rows of the table
                for (int i = initialRowCount; i < TheTable.Rows.Count; i++)
                {
                    DataRow dr = TheTable.Rows[i];
                    int startxposition = TheDataGrid.Location.X;

                    RowBounds.X = TheDataGrid.Location.X;
                    RowBounds.Y = TheDataGrid.Location.Y + TopMargin + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);
                    RowBounds.Height = TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway;
                    RowBounds.Width = PageWidth;
                    Lines.Add(RowBounds.Bottom);

                    if (i % 2 == 0)
                    {
                        g.FillRectangle(BackBrush, RowBounds);
                    }
                    else
                    {
                        g.FillRectangle(AlternatingBackBrush, RowBounds);
                    }


                    for (int j = 0; j < TheTable.Columns.Count; j++)
                    {
                        RectangleF cellbounds = new RectangleF(startxposition,
                            TheDataGrid.Location.Y + TopMargin + 2 + ((RowCount - initialRowCount) + 1) * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway),
                            columnwidth,
                            TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway);


                        if (startxposition + columnwidth <= PageWidth)
                        {
                            g.DrawString(dr[j].ToString(), TheDataGrid.Font, ForeBrush, cellbounds, cellformat);
                            lastRowBottom = (int)cellbounds.Bottom;
                        }

                        startxposition = startxposition + columnwidth;
                    }

                    RowCount++;

                    if (RowCount * (TheDataGrid.Font.SizeInPoints + kVerticalCellLeeway) > (PageHeight * PageNumber) - (BottomMargin + TopMargin))
                    {
                        DrawHorizontalLines(g, Lines);
                        DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                        return true;
                    }


                }

                DrawHorizontalLines(g, Lines);
                DrawVerticalGridLines(g, TheLinePen, columnwidth, lastRowBottom);
                RowCount = 0;
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

        void DrawHorizontalLines(Graphics g, ArrayList lines)
        {
            Pen TheLinePen = new Pen(TheDataGrid.GridLineColor, 1);

            if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
                return;

            for (int i = 0; i < lines.Count; i++)
            {
                g.DrawLine(TheLinePen, TheDataGrid.Location.X, (float)lines[i], PageWidth, (float)lines[i]);
            }
        }

        void DrawVerticalGridLines(Graphics g, Pen TheLinePen, int columnwidth, int bottom)
        {
            if (TheDataGrid.GridLineStyle == DataGridLineStyle.None)
                return;

            for (int k = 0; k < TheTable.Columns.Count; k++)
            {
                g.DrawLine(TheLinePen, (TheDataGrid.Location.X) + k * columnwidth,
                    TheDataGrid.Location.Y + TopMargin,
                    (TheDataGrid.Location.X) + k * columnwidth,
                    bottom);
            }
        }


        public bool DrawDataGrid(Graphics g)
        {

            try
            {
                DrawHeader(g);
                bool bContinue = DrawRows(g);
                return bContinue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }

        }

    }

}
