namespace SmartCore.Entities
{
    public class XlsReader
    {
        

        #region public XlsReader()
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public XlsReader()
        {

        }

        #endregion

        #region public string way {get;set;}

        public string way {get;set;}

        #endregion

        #region public XlsReader(string path)

        /// <summary>
        /// Путь к файлу
        /// </summary>
        /// <param name="path"></param>
        public XlsReader(string path)
        {
            way = path;
        }

        #endregion

        #region public string ReadCell(Int32 x,Int32 y)

        /// <summary>
        /// Возвращает содержимое одной ячейки
        /// </summary>
        /// <param name="x">Строка</param>
        /// <param name="y">Столбец</param>
        /// <returns></returns>
        //public string ReadCell(Int32 x, Int32 y)
        //{
        //    var excelapp = new Application { Visible = false };
        //    Workbooks excelappworkbooks = excelapp.Workbooks;
        //    Workbook excelappworkbook = excelapp.Workbooks.Open(way, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    Sheets sheets = excelappworkbook.Worksheets;
        //    Worksheet worksheet = (Worksheet)sheets.get_Item(1);
        //    String value = ((Range) worksheet.Cells[x, y]).Value2.ToString();
        //    excelapp.Workbooks.Close();
        //  return value;
        //}

        #endregion

        #region public List<ListViewItem> GetRangeCell(String x,String y)

       /// <summary>
        /// Возвращает массив строк ,выбранных из диапазона ячеек
       /// </summary>
       /// <param name="xChar">Принимает идентификатор колонки ,например "А"</param>
       /// <param name="xNumber">Принимает идентификатор строки например "3"</param>
        /// <param name="yChar">Принимает идентификатор колонки ,например "C"</param>
        /// <param name="yNumber">Принимает идентификатор строки например "8"</param>
       /// <returns></returns>
        //public List<ListViewItem> GetRangeCell(Char xChar, Int32 xNumber, Char yChar, Int32 yNumber)
        //{

            
        //    List<ListViewItem> _list=new List<ListViewItem>();
        //    var excelapp = new Application { Visible = false };
        //    Workbooks excelappworkbooks = excelapp.Workbooks;
        //    Workbook excelappworkbook = excelapp.Workbooks.Open(way, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    Sheets sheets = excelappworkbook.Worksheets;
        //    Worksheet worksheet = (Worksheet)sheets.get_Item(1);

        //    Range excelcells = worksheet.get_Range(xChar.ToString()+xNumber.ToString(), yChar.ToString()+yNumber.ToString());
        //    var list = (Object[,])excelcells.Value2;
        //    var item = new ListViewItem();
        //    for (int j = 1; j <= yNumber-xNumber; j++)
        //    {
        //        for (int i = 1; i <= (((Int32)yChar) - ((Int32)xChar)); i++)
        //        {

                        
        //                if (list[j, i] != null)
        //                {
        //                    item.SubItems.Add(list[j, i].ToString());
        //                }
        //                else
        //                {
        //                    item.SubItems.Add("null");
        //                }
        //                if (i == (((Int32)yChar) - ((Int32)xChar)))
        //                {
                            
        //                    _list.Add(item);
        //                    item = new ListViewItem();
        //                }
        //        }
               
        //    }
        //    return _list;
        //}

        #endregion

        #region public void WriteCell(Int32 x, Int32 y,String text)

        /// <summary>
        /// принимает координаты х,у и содержимое которое нужно записать в координаты
        /// </summary>
        /// <param name="x">Строка</param>
        /// <param name="y">Столбец</param>
        /// <param name="text">Содержимое</param>
        //public void WriteCell(Int32 x, Int32 y,String text)
        //{
        //    var excelapp = new Application { Visible = false };
        //    Workbooks excelappworkbooks = excelapp.Workbooks;
        //    Workbook excelappworkbook = excelapp.Workbooks.Open(way, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, XlPlatform.xlWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    Sheets sheets = excelappworkbook.Worksheets;
        //    Worksheet worksheet = (Worksheet)sheets.get_Item(1);
        //    worksheet.Cells.set_Item(x,y,(text as Object));
        //    worksheet.SaveAs(way, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    excelapp.Workbooks.Close();
        //}

        #endregion
    }
}
