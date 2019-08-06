using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MotorAuto
{
    class print
    {
        // Вставка текста в ячейки книги
        // string[] columns:
        // 0 - мин. дата по таблице                                (Книга покупок)
        // 1 - макс. дата по таблице                               (Книга покупок)
        // 2 - ГлавБух                                             (Книга покупок)
        // 3 - Покупатель                                          (Книга покупок)
        // 4 - ИНН и КПП в формате "ИНН / КПП"                     (Книга покупок)
        // 5 - Продавец                                            (Книга продаж)
        // 6 - ИНН и КПП в формате "ИНН / КПП"                     (Книга продаж)
        // 7 - Данные компании формата "Имя, ИНН, КПП, Адрес"      (Прайс-лист)
        // 8 - Реквизиты компании формата "Имя банка, р/c, к/c"    (Счет - накладная)
        // 9 - ФИО менеджера                                       (Счет - накладная)
        // 10 - Номер операции                                     (Счет - накладная)
        // 11 - Данные компании формата "Имя, Адрес"               (ТОРГ-12)
        // 12 - Кол-во записей                                     (ТОРГ-12)
        // 13 - Данные контрагента формата "Имя, Адрес, Реквизиты" (ТОРГ-12)
        // 14 - Автосалон                                          (ТОРГ-12)
        // 15 - ФИО менеджера                                      (ТОРГ-12)
        // 16 - Выбранная дата с                                   (Отчет по продажам)
        // 17 - Выбранная дата по                                  (Отчет по продажам)
        // 18 - Данные продавца формата "Имя, ИНН, КПП, Адрес"     (Счет - накладная)
        // 19 - Реквизиты продавца формата "Имя банка, р/c, к/c"   (Счет - накладная)
        // 20 - Данные контрагента формата "Имя, ИНН, КПП, Адрес"  (Счет - накладная)
        // 21 - Реквизиты контрагента формата "Имя банка, р/с, к/с"(Счет - накладная)
        // 22 - ФИО кассира                                        (Товарный чек)
        // 23 - Имя компании                                       (ТОРГ-13)
        // 24 - Из автосалона                                      (ТОРГ-13)
        // 25 - В автосалон                                        (ТОРГ-13)
        // 26 - isPurchase

        // Быстро экспортирует данные, но не сохраняет форматирование при сдвиге, так что нужно:
        // 1) Сохранять форматирование автоматически или сделать ручное форматирование, + (Сделал ручное форматирование)
        // 2) Сделать подсчет суммы в конце таблицы у каждого отдельного файла, + (Метод готов, осталось заполнить)
        // 3) Сделать возможность печати всех документов из одного метода, + (Почти готово, осталось форматирование)
        // 4) Заполнить одну таблицу множеством данных (10 тыс. - 50 тыс. строк) для показа на защите диплома. ---
        // 5) Полное форматирование, ---
        // 6) Закрытие Excel чтобы он не оставался в памяти. ---
        //
        // Файлы в которых проходит суммирование:
        // 1) Книга покупок.xlsx +
        // 2) Книга продаж.xlsx
        // 3) Отчет по продажам.xlsx
        // 4) Счет - накладная.xlsx
        // 5) Товарный чек.xlsx
        // 6) ТОРГ-12 (Товарная накладная).xlsx
        // 7) ТОРГ-13 (Перемещение).xlsx
        public static void ExportToExcel(Form form, DataGridView dgv, int fRow, int fColumn, string nameFile, bool getSum, string[] columns)
        {
            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = baseDirectory + "doc//" + nameFile;

            int firstColumn = fColumn; // Первый столбец
            int firstRow = fRow; // Первая строка
            int lastRow = firstRow + dgv.RowCount; // Последняя строка
            int lastColumn = firstColumn + dgv.ColumnCount; // Последний столбец

            Excel.Application xl = new Excel.Application(); // Создаем экземпляр Excel'а

            try
            {
                Excel.Workbook wb = (Excel.Workbook)xl.Workbooks.Open(path, false, false); // Открываем файл Excel
                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet; // Указываем ссылку на активный лист файла Excel

                form.Cursor = Cursors.WaitCursor;

                // Заполняем массив данными
                object[,] rc = new object[dgv.RowCount, dgv.ColumnCount];
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        rc[i, j] = dgv.Rows[i].Cells[j].Value;
                    }
                }

                // Вставка текста в ячейки шаблона
                pasteTextToExcel(ws, nameFile, columns, true);

                // Добавляем пустые строки со сдвигом вниз
                Excel.Range insertColumn = ws.Range[ws.Cells[firstRow, firstColumn], ws.Cells[lastRow - 2, lastColumn - 1]];
                insertColumn.Insert(Excel.XlDirection.xlDown);

                // Вставляем текст из массива в Excel
                Excel.Range pasteText = ws.Range[ws.Cells[firstRow, firstColumn], ws.Cells[lastRow - 1, lastColumn - 1]];
                pasteText.Font.Bold = false;
                pasteText.Font.Name = "Arial";
                pasteText.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, rc);

                GetSum(ws, firstRow, lastRow, getSum, nameFile); // Форматирование документа

                // Удаляем последнюю пустую строку со сдвигом вверх
                Excel.Range deleteColumn = ws.Range[ws.Cells[lastRow - 1, firstColumn], ws.Cells[lastRow - 1, lastColumn]];
                deleteColumn.Delete(Excel.XlDirection.xlUp);

                form.Cursor = Cursors.Default;

                xl.Visible = true; // Делаем книгу Excel видимой
                xl.UserControl = true; // Делаем книгу Excel активной
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex, "Ошибка");
            }
        }

        // Печатает таблицу без вставки текста
        public static void ExportToExcelNew(Form form, DataGridView dgv, int fRow, int fColumn, string nameTable)
        {
            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = baseDirectory + "doc//Прайс-лист.xlsx";

            int firstColumn = fColumn; // Первый столбец
            int firstRow = fRow; // Первая строка
            int lastRow = firstRow + dgv.RowCount; // Последняя строка
            int lastColumn = firstColumn + dgv.ColumnCount; // Последний столбец

            Excel.Application xl = new Excel.Application(); // Создаем экземпляр Excel'а

            try
            {
                Excel.Workbook wb = (Excel.Workbook)xl.Workbooks.Open(path, false, false); // Открываем файл Excel
                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet; // Указываем ссылку на активный лист файла Excel

                form.Cursor = Cursors.WaitCursor;

                // Очистка старого форматирования
                Excel.Range rngDEL = (Excel.Range)ws.Range[ws.Cells[1, 1], ws.Cells[7, dgv.ColumnCount + 4]];
                rngDEL.Clear();

                // Заполняем массив заголовками
                object[] headers = new object[dgv.ColumnCount];
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    headers[i] = dgv.Columns[i].HeaderText;
                }

                // Заполняем массив данными
                object[,] rc = new object[dgv.RowCount, dgv.ColumnCount];
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        rc[i, j] = dgv.Rows[i].Cells[j].Value;
                    }
                }

                // Вставка текста в ячейки шаблона
                ws.Cells[1, 1] = DateTime.Now.ToShortDateString();
                ws.Cells[3, 1] = nameTable;

                // Форматирование
                Excel.Range rngName = ws.Range[ws.Cells[3, 1], ws.Cells[3, 1]];
                rngName.Font.Size = 16;
                rngName.Font.Bold = true;

                // Добавляем пустые строки со сдвигом вниз
                Excel.Range insertColumn = ws.Range[ws.Cells[firstRow, firstColumn], ws.Cells[lastRow - 2, lastColumn - 1]];
                insertColumn.Insert(Excel.XlDirection.xlDown);

                // Вставка рамок
                Excel.Range pasteBorders = ws.Range[ws.Cells[firstRow - 1, firstColumn], ws.Cells[lastRow - 1, lastColumn]];

                pasteBorders.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                pasteBorders.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                pasteBorders.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
                pasteBorders.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
                pasteBorders.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;

                // Вставляем заголовки из массива в Excel
                Excel.Range pasteCaptions = ws.Range[ws.Cells[firstRow - 1, firstColumn], ws.Cells[firstRow - 1, lastColumn]];
                pasteCaptions.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, headers);
                pasteCaptions.Font.Bold = true;

                // Вставляем текст из массива в Excel
                Excel.Range pasteText = ws.Range[ws.Cells[firstRow, firstColumn], ws.Cells[lastRow - 1, lastColumn - 1]];
                pasteText.Font.Bold = false;
                pasteText.Font.Name = "Arial";
                pasteText.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, rc);

                // Удаляем последнюю пустую строку со сдвигом вверх
                Excel.Range deleteRow = ws.Range[ws.Cells[lastRow - 1, firstColumn], ws.Cells[lastRow - 1, lastColumn]];
                deleteRow.Delete(Excel.XlDirection.xlUp);

                // Удаляем последний столбец
                Excel.Range deleteColumn = ws.Range[ws.Cells[firstRow - 1, lastColumn], ws.Cells[lastRow, lastColumn]];
                deleteColumn.Clear();

                // Автоподбор ширины столбцов
                Excel.Range rngAF = ws.Range[ws.Cells[firstRow - 1, 1], ws.Cells[lastRow, lastColumn]];
                rngAF.Columns.AutoFit();
                rngAF.Rows.AutoFit();

                form.Cursor = Cursors.Default;

                xl.Visible = true; // Делаем книгу Excel видимой
                xl.UserControl = true; // Делаем книгу Excel активной
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex, "Ошибка");
            }
        }

        #region Вставка текста
        private static void pasteTextToExcel(Excel.Worksheet ws, string nameFile, string[] columns, bool isPurchase)
        {
            switch (nameFile)
            {
                case "Книга покупок.xlsx": // Форматирование для книги "Книга покупок"

                    ws.Cells[6, 3] = columns[23];
                    ws.Cells[7, 7] = columns[4];
                    ws.Cells[8, 3] = columns[0];
                    ws.Cells[8, 5] = columns[1];
                    ws.Cells[19, 5] = columns[2];

                    break;
                case "Книга продаж.xlsx": // Форматирование для книги "Книга продаж"

                    ws.Cells[6, 2] = columns[23];
                    ws.Cells[7, 7] = columns[4];
                    ws.Cells[8, 3] = columns[0];
                    ws.Cells[8, 5] = columns[1];
                    ws.Cells[19, 5] = columns[2];

                    break;
                case "Отчет по продажам.xlsx": // Форматирование для книги "Отчет по продажам"

                    ws.Cells[1, 1] = DateTime.Now.ToShortDateString();
                    ws.Cells[4, 1] = $"Отчет по продажам по торговым точка с {columns[16]} по {columns[17]}";

                    break;
                case "Отчет по менеджерам.xlsx": // Форматирование для книги "Отчет по менеджерам"

                    ws.Cells[1, 1] = DateTime.Now.ToShortDateString();
                    ws.Cells[3, 1] = $"Отчет по работе менеджеров с {columns[16]} по {columns[17]}";

                    break;
                case "Счет - Накладная.xlsx": // Форматирование для книги "Счет - накладная"

                    ws.Cells[1, 1] = columns[7] + ", " + columns[8];
                    ws.Cells[17, 1] = "Главный бухгалтер________________" + columns[2];

                    if (columns[26] == "True") // Закупка
                    {
                        ws.Cells[4, 1] = $"Приходная накладная № {columns[10]} от {DateTime.Now.ToShortDateString()}";
                        ws.Cells[19, 3] = "Принял________________" + columns[9];
                        ws.Cells[7, 1] = string.Empty;
                        ws.Cells[6, 2] = columns[18] + ", " + columns[19];
                    }
                    else // Продажа
                    {
                        ws.Cells[4, 1] = $"Счет № {columns[10]} от {DateTime.Now.ToShortDateString()}";
                        ws.Cells[19, 1] = "Отпустил________________" + columns[22];
                        ws.Cells[6, 1] = string.Empty;
                        ws.Cells[7, 2] = columns[20] + ", " + columns[21];
                    }

                    break;
                case "Товарный чек.xlsx": // Форматирование для книги "Товарный чек"

                    ws.Cells[1, 1] = columns[7];
                    ws.Cells[4, 1] = "Товарный чек № " + columns[10] + " от " + DateTime.Now.ToShortDateString();
                    ws.Cells[14, 1] = "Кассир________________" + columns[22];

                    break;
                case "ТОРГ-12 (Товарная накладная).xlsx": // Форматирование для книги "ТОРГ-12"

                    ws.Cells[8, 1] = columns[11] + ", Реквизиты: " + columns[8];
                    ws.Cells[10, 1] = columns[14];
                    ws.Cells[13, 8] = columns[20] + ", Реквизиты: " + columns[21];
                    ws.Cells[16, 8] = columns[11] + ", Реквизиты: " + columns[8];
                    ws.Cells[19, 8] = columns[20] + ", Реквизиты: " + columns[21];
                    ws.Cells[28, 37] = DateTime.Now.ToShortDateString();
                    ws.Cells[28, 32] = columns[10];
                    ws.Cells[38, 6] = columns[12];
                    ws.Cells[50, 23] = columns[15];
                    ws.Cells[52, 23] = columns[2];

                    break;
                case "ТОРГ-13 (Перемещение).xlsx": // Форматирование для книги "ТОРГ-13"

                    ws.Cells[11, 7] = DateTime.Now.ToShortDateString();
                    ws.Cells[6, 1] = columns[23];
                    ws.Cells[16, 1] = columns[24];
                    ws.Cells[16, 2] = columns[25];

                    break;
                case "Прайс-лист.xlsx": // Форматирование для книги "Прайс-лист

                    ws.Cells[1, 1] = columns[7];

                    break;
                case "Остаток товара на складе.xlsx": // Форматирование для книги "Остаток товара на складе"

                    ws.Cells[1, 1] = DateTime.Now.ToShortDateString();

                    break;
            }
        }
        #endregion

        // Форматирование + формулы
        #region Форматирование
        private static void GetSum(Excel.Worksheet ws, int firstRow, int lastRow, bool getSum, string nameFile)
        {
            switch (nameFile)
            {
                case "Книга покупок.xlsx": // Форматирование для книги "Книга покупок"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 1, firstRow, lastRow);
                    }
                    
                    // Указание диапазонов для редактирования
                    Excel.Range rngCol1 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol2 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 5]]; // Столбцы 2-7
                    Excel.Range rngCol3 = (Excel.Range)ws.Range[ws.Cells[firstRow, 6], ws.Cells[lastRow, 6]]; // Столбец 8
                    Excel.Range rngCol4 = (Excel.Range)ws.Range[ws.Cells[firstRow, 8], ws.Cells[lastRow, 10]]; // Столбцы 9-11

                    // Форматирование выравнивания
                    rngCol1.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol2.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol3.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol4.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol4.NumberFormat = "#,##0.00";

                    break;
                case "Книга продаж.xlsx": // Форматирование для книги "Книга продаж"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 2, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol5 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 2]]; // Столбцы 1-2
                    Excel.Range rngCol5_1 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol6 = (Excel.Range)ws.Range[ws.Cells[firstRow, 3], ws.Cells[lastRow, 5]]; // Столбцы 3-5
                    Excel.Range rngCol8 = (Excel.Range)ws.Range[ws.Cells[firstRow, 7], ws.Cells[lastRow, 9]]; // Столбцы 6-8

                    // Форматирование выравнивания
                    rngCol5.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol5_1.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol6.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol8.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol8.NumberFormat = "#,##0.00";

                    break;
                case "Отчет по продажам.xlsx": // Форматирование для книги "Отчет по продажам"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 3, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol9 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 3]]; // Столбцы 2-3
                    Excel.Range rngCol10 = (Excel.Range)ws.Range[ws.Cells[firstRow, 6], ws.Cells[lastRow, 6]]; // Столбец 6
                    Excel.Range rngCol10_1 = (Excel.Range)ws.Range[ws.Cells[firstRow, 7], ws.Cells[lastRow, 9]]; // Столбцы 7-9

                    // Форматирование выравнивания
                    rngCol9.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol10.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol10_1.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol10_1.NumberFormat = "#,##0.00";

                    break;
                case "Отчет по менеджерам.xlsx": // Форматирование для книги "Отчет по менеджерам"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 4, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol11 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 2]]; // Столбцы 1-2
                    Excel.Range rngCol12 = (Excel.Range)ws.Range[ws.Cells[firstRow, 3], ws.Cells[lastRow, 5]]; // Столбцы 3-5

                    // Форматирование выравнивания
                    rngCol11.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol12.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol12.NumberFormat = "#,##0.00";

                    break;
                case "Счет - Накладная.xlsx": // Форматирование для книги "Счет - накладная"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 5, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol13 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol14 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 2]]; // Столбец 2
                    Excel.Range rngCol15 = (Excel.Range)ws.Range[ws.Cells[firstRow, 3], ws.Cells[lastRow, 4]]; // Столбцы 10-11
                    Excel.Range rngCol16 = (Excel.Range)ws.Range[ws.Cells[firstRow, 5], ws.Cells[lastRow, 6]]; // Столбцы 12-13

                    // Форматирование выравнивания
                    rngCol13.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol14.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol15.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol16.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol16.NumberFormat = "#,##0.00";

                    break;
                case "Товарный чек.xlsx": // Форматирование для книги "Товарный чек"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 6, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol17 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol18 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 2]]; // Столбец 2
                    Excel.Range rngCol19 = (Excel.Range)ws.Range[ws.Cells[firstRow, 3], ws.Cells[lastRow, 4]]; // Столбцы 3-4
                    Excel.Range rngCol20 = (Excel.Range)ws.Range[ws.Cells[firstRow, 5], ws.Cells[lastRow, 6]]; // Столбцы 12-13

                    // Форматирование выравнивания
                    rngCol17.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol18.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol19.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol20.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol20.NumberFormat = "#,##0.00";

                    break;
                case "ТОРГ-12 (Товарная накладная).xlsx": // Форматирование для книги "ТОРГ-12"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 7, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol21 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol22 = (Excel.Range)ws.Range[ws.Cells[firstRow, 4], ws.Cells[lastRow, 4]]; // Столбец 4
                    Excel.Range rngCol23 = (Excel.Range)ws.Range[ws.Cells[firstRow, 18], ws.Cells[lastRow, 24]]; // Столбцы 18-24
                    Excel.Range rngCol24 = (Excel.Range)ws.Range[ws.Cells[firstRow, 27], ws.Cells[lastRow, 54]]; // Столбцы 27-54

                    // Форматирование выравнивания
                    rngCol21.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol22.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol23.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol24.HorizontalAlignment = Excel.Constants.xlRight;

                    // Установка формата
                    rngCol24.NumberFormat = "#,##0.00";

                    break;
                case "ТОРГ-13 (Перемещение).xlsx": // Форматирование для книги "ТОРГ-13"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 8, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol25 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol26 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 3]]; // Столбцы 2-3
                    Excel.Range rngCol29 = (Excel.Range)ws.Range[ws.Cells[firstRow, 4], ws.Cells[lastRow, 6]]; // Столбцы 4-6

                    // Форматирование выравнивания
                    rngCol25.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol25.VerticalAlignment = Excel.Constants.xlTop;
                    rngCol26.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol29.HorizontalAlignment = Excel.Constants.xlRight;

                    // Высота ячеек
                    rngCol25.RowHeight = 12;

                    // Установка формата
                    rngCol29.NumberFormat = "#,##0.00";

                    break;
                case "Прайс-лист.xlsx": // Форматирование для книги "Прайс-лист"

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol30 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol31 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 2]]; // Столбец 2
                    Excel.Range rngCol32 = (Excel.Range)ws.Range[ws.Cells[firstRow, 3], ws.Cells[lastRow, 3]]; // Столбец 3
                    Excel.Range rngCol33 = (Excel.Range)ws.Range[ws.Cells[firstRow, 4], ws.Cells[lastRow, 4]]; // Столбец 4

                    // Форматирование выравнивания
                    rngCol30.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol30.Font.Size = 10;

                    rngCol31.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol31.Font.Size = 10;

                    rngCol32.HorizontalAlignment = Excel.Constants.xlCenter;
                    rngCol32.Font.Size = 10;

                    rngCol33.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol33.Font.Size = 10;

                    // Установка формата
                    rngCol33.NumberFormat = "#,##0.00";

                    break;
                case "Остаток товара на складе.xlsx": // Форматирование для книги "Остаток товара на складе"

                    if (getSum == true)
                    {
                        sumTableExcel(ws, 9, firstRow, lastRow);
                    }

                    // Указание диапазонов для редактирования
                    Excel.Range rngCol34 = (Excel.Range)ws.Range[ws.Cells[firstRow, 1], ws.Cells[lastRow, 1]]; // Столбец 1
                    Excel.Range rngCol35 = (Excel.Range)ws.Range[ws.Cells[firstRow, 2], ws.Cells[lastRow, 3]]; // Столбцы 2-3
                    Excel.Range rngCol36 = (Excel.Range)ws.Range[ws.Cells[firstRow, 4], ws.Cells[lastRow, 8]]; // Столбцы 4-8

                    // Форматирование выравнивания
                    rngCol34.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol34.Font.Size = 11;
                    rngCol34.Font.Name = "Calibri";

                    rngCol35.HorizontalAlignment = Excel.Constants.xlLeft;
                    rngCol35.Font.Size = 11;
                    rngCol35.Font.Name = "Calibri";

                    rngCol36.HorizontalAlignment = Excel.Constants.xlRight;
                    rngCol36.Font.Size = 11;
                    rngCol36.Font.Name = "Calibri";

                    // Установка формата
                    rngCol36.NumberFormat = "#,##0.00";

                    break;
            }
        }
        #endregion

        // Вставка формул
        #region Формулы
        private static void sumTableExcel(Excel.Worksheet ws, int numberFile, int firstRow, int lastRow)
        {
            switch (numberFile)
            {
                case 1:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol1Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 8], ws.Cells[lastRow, 8]]; // Формула для подсчета суммы столбца "Покупки включая НДС"
                    Excel.Range rngCol2Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 9], ws.Cells[lastRow, 9]]; // Формула для подсчета суммы стобца "Покупки без НДС"
                    Excel.Range rngCol3Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 10], ws.Cells[lastRow, 10]]; // Формула для подсчета суммы столбца "Сумма НДС"

                    // Указываем диапазон для формул
                    rngCol1Sum.Formula = $"=SUM(r{firstRow}c{8}:r{lastRow - 1}c{8})";
                    rngCol2Sum.Formula = $"=SUM(r{firstRow}c{9}:r{lastRow - 1}c{9})";
                    rngCol3Sum.Formula = $"=SUM(r{firstRow}c{10}:r{lastRow - 1}c{10})";

                    break;
                case 2:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol4Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 7], ws.Cells[lastRow, 7]]; // Формула для подсчета суммы столбца "Покупки включая НДС"
                    Excel.Range rngCol5Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 8], ws.Cells[lastRow, 8]]; // Формула для подсчета суммы стобца "Покупки без НДС"
                    Excel.Range rngCol6Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 9], ws.Cells[lastRow, 9]]; // Формула для подсчета суммы столбца "Сумма НДС"

                    // Указываем диапазон для формул
                    rngCol4Sum.Formula = $"=SUM(r{firstRow}c{7}:r{lastRow - 1}c{7})";
                    rngCol5Sum.Formula = $"=SUM(r{firstRow}c{8}:r{lastRow - 1}c{8})";
                    rngCol6Sum.Formula = $"=SUM(r{firstRow}c{9}:r{lastRow - 1}c{9})";

                    break;
                case 3:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol7Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 3], ws.Cells[lastRow, 3]]; // Формула для подсчета суммы столбца "Выручка, руб."
                    Excel.Range rngCol8Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 4], ws.Cells[lastRow, 4]]; // Формула для подсчета суммы стобца "Валовая прибыль, руб."

                    // Указываем диапазон для формул
                    rngCol7Sum.Formula = $"=SUM(r{firstRow}c{3}:r{lastRow - 1}c{3})";
                    rngCol8Sum.Formula = $"=SUM(r{firstRow}c{4}:r{lastRow - 1}c{4})";

                    break;
                case 4:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol9Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 3], ws.Cells[lastRow, 3]]; // Формула для подсчета суммы столбца "Выручка, руб."
                    Excel.Range rngCol10Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 4], ws.Cells[lastRow, 4]]; // Формула для подсчета суммы стобца "Премиальная часть, руб."

                    // Указываем диапазон для формул
                    rngCol9Sum.Formula = $"=SUM(r{firstRow}c{4}:r{lastRow - 1}c{4})";
                    rngCol10Sum.Formula = $"=SUM(r{firstRow}c{5}:r{lastRow - 1}c{5})";

                    break;
                case 5:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol11Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 6], ws.Cells[lastRow, 6]]; // Формула для подсчета суммы столбца "Сумма без НДС, руб."
                    Excel.Range rngCol12Sum = (Excel.Range)ws.Range[ws.Cells[lastRow + 1, 6], ws.Cells[lastRow + 1, 6]]; // Формула для подсчета произведения стобца "Сумма без НДС, руб." строки "НДС 18%"
                    Excel.Range rngCol13Sum = (Excel.Range)ws.Range[ws.Cells[lastRow + 2, 6], ws.Cells[lastRow + 2, 6]]; // Формула для подсчета суммы столца "Сумма без НДС, руб." строки "НДС 18%" + "ИТОГО"

                    // Указываем диапазон для формул
                    rngCol11Sum.Formula = $"=SUM(r{firstRow}c{6}:r{lastRow - 1}c{6})";
                    rngCol12Sum.Formula = $"=r{lastRow}c{6}*0.20";
                    rngCol13Sum.Formula = $"=r{lastRow + 1}c{6}+r{lastRow}c{6}";

                    break;
                case 6:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol14Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 6], ws.Cells[lastRow, 6]]; // Формула для подсчета суммы столбца "Сумма, руб."

                    // Указываем диапазон для формул
                    rngCol14Sum.Formula = $"=SUM(r{firstRow}c{6}:r{lastRow - 1}c{6})";

                    break;
                case 7:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol15Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 33], ws.Cells[lastRow, 33]]; // Формула для подсчета суммы столбца "Мест, штук"
                    Excel.Range rngCol16Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 38], ws.Cells[lastRow, 38]]; // Формула для подсчета суммы стобца "Количество"
                    Excel.Range rngCol17Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 44], ws.Cells[lastRow, 44]]; // Формула для подсчета суммы столца "Сумма без учета НДС, руб. коп."
                    Excel.Range rngCol18Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 50], ws.Cells[lastRow, 50]]; // Формула для подсчета суммы столбца "НДС - сумма, руб. коп."
                    Excel.Range rngCol19Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 54], ws.Cells[lastRow, 54]]; // Формула для подсчета суммы столбца "Сумма с учетом НДС, руб. коп."

                    // Указываем диапазон для формул
                    rngCol15Sum.Formula = $"=SUM(r{firstRow}c{33}:r{lastRow - 1}c{33})";
                    rngCol16Sum.Formula = $"=SUM(r{firstRow}c{38}:r{lastRow - 1}c{38})";
                    rngCol17Sum.Formula = $"=SUM(r{firstRow}c{44}:r{lastRow - 1}c{44})";
                    rngCol18Sum.Formula = $"=SUM(r{firstRow}c{50}:r{lastRow - 1}c{50})";
                    rngCol19Sum.Formula = $"=SUM(r{firstRow}c{54}:r{lastRow - 1}c{54})";

                    break;
                case 8:
                    // Диапазоны для вставки формул
                    Excel.Range rngCol20Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 6], ws.Cells[lastRow, 6]]; // Формула для подсчета суммы столбца "Сумма, руб. коп."
                    Excel.Range rngCol20_1Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 5], ws.Cells[lastRow, 5]]; // Формула для подсчета суммы столбца "Штук"
                    Excel.Range rngCol20_2Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 4], ws.Cells[lastRow, 4]]; // Формула для подсчета суммы столбца "Цена"

                    // Указываем диапазон для формул
                    rngCol20Sum.Formula = $"=SUM(r{firstRow}c{6}:r{lastRow - 2}c{6})";
                    rngCol20_1Sum.Formula = $"=SUM(r{firstRow}c{5}:r{lastRow - 2}c{5})";
                    rngCol20_2Sum.Formula = $"=SUM(r{firstRow}c{4}:r{lastRow - 1}c{4})";

                    break;
                case 9:

                    // Диапазоны для вставки формул
                    Excel.Range rngCol21Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 7], ws.Cells[lastRow, 7]]; // Формула для подсчета суммы столбца "Мест, штук"
                    Excel.Range rngCol22Sum = (Excel.Range)ws.Range[ws.Cells[lastRow, 8], ws.Cells[lastRow, 8]]; // Формула для подсчета суммы стобца "Количество"

                    // Указываем диапазон для формул
                    rngCol21Sum.Formula = $"=SUM(r{firstRow}c{7}:r{lastRow - 1}c{7})";
                    rngCol22Sum.Formula = $"=SUM(r{firstRow}c{8}:r{lastRow - 1}c{8})";

                    break;
            }
        }
        #endregion
    }
}
