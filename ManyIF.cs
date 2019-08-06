using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MotorAuto
{
    class ManyIF // Если при составлении SQL-запроса нужно множество IF, то лучше использовать данный класс
    {
        // Конвертирование даты в ту что понимает MS Access
        public static string convDate(DateTimePicker dtp)
        {
            string date = "#" + dtp.Value.Month + "/" + dtp.Value.Day + "/" + dtp.Value.Year + "#";

            return date;
        }

        // Добавляет в запрос "AND" перед каждой командой
        public static string isStr(string str)
        {
            char[] symbols = str.ToCharArray();
            foreach (char a in symbols)
            {
                if (char.IsWhiteSpace(a))
                {
                    str += "AND ";

                    break;
                }
            }
            return str.ToString();
        }

        // Очищает запрос от "AND" перед "WHERE"
        public static string clearAND(string str, string from, string to, int countSymbols)
        {
            try
            {
                int start = str.IndexOf(from);
                int end = str.IndexOf(to);

                if (start < 0 || end < 0)
                {
                    return str;
                }

                string textBefore = str.Substring(0, start + countSymbols);
                string textAfter = str.Substring(end);
                str = textBefore + " " + textAfter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return str;
        }

        // Составляет SQL-запрос для формы fBookPurchaseAndSales
        public static string where(bool start, bool end, bool cashier, bool manager, bool partner, bool POS, bool sales, bool buy,
                                   DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cbxCashier, ComboBox cbxManager,
                                   ComboBox cbxPartner, ComboBox cbxPOS, RadioButton rbSales, RadioButton rbBuy)
        {
            string whereStr = "HAVING ";

            if (start == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.Дата >= " + convDate(dtpStart) + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (end == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.Дата <= " + convDate(dtpEnd) + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (cashier == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.КассирID = " + cbxCashier.SelectedValue + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (manager == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.МенеджерID = " + cbxManager.SelectedValue + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (partner == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.КонтрагентID = " + cbxPartner.SelectedValue + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (POS == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.ТочкаID = " + cbxPOS.SelectedValue + " ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (sales == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.Закупка = false ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (buy == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Операция.Закупка = true ";

                whereStr = clearAND(whereStr, "NG", "О", 2);
            }
            if (start == false && end == false && cashier == false && manager == false && partner == false &&
                POS == false && sales == false && buy == false)
            {
                whereStr = string.Empty;
            }

            return whereStr;
        }

        // Составляет SQL-запрос для формы fMoveToOtherPointOfSale
        public static string whereForMTOPOS(bool start, bool end, bool fromPOS, bool toPOS, DateTimePicker dtpStart, DateTimePicker dtpEnd,
                                            ComboBox cbxFromPOS, ComboBox cbxToPOS)
        {
            string whereStr = "WHERE ";

            if (start == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Перемещение.Дата >= " + convDate(dtpStart) + " ";

                whereStr = clearAND(whereStr, "RE", "П", 2);
            }
            if (end == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Перемещение.Дата <= " + convDate(dtpEnd) + " ";

                whereStr = clearAND(whereStr, "RE", "П", 2);
            }
            if (fromPOS == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Перемещение.ТочкаID1 = " + cbxFromPOS.SelectedValue + " ";

                whereStr = clearAND(whereStr, "RE", "П", 2);
            }
            if (toPOS == true)
            {
                whereStr = isStr(whereStr);

                whereStr += "Перемещение.ТочкаID2 = " + cbxToPOS.SelectedValue + " ";

                whereStr = clearAND(whereStr, "RE", "П", 2);
            }
            if (start == false && end == false && fromPOS == false && toPOS == false)
            {
                whereStr = string.Empty;
            }
            return whereStr;
        }
    }
}
