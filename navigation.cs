using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.OleDb;

namespace MotorAuto
{
    class navigation
    {

        private static int index = 0;

        public static void navNext(DataGridView dgv) // Следующая запись
        {
            index = dgv.CurrentRow.Index;
            try
            {
                if (index >= 0)
                {
                    dgv.Rows[index].Selected = true;
                    dgv.CurrentCell = dgv.Rows[index + 1].Cells[0];
                    //l.Text = index.ToString() + " | " + (dgv.RowCount - 1).ToString() + " | " + dgv.CurrentRow.Index.ToString();
                }
                else if (index == dgv.RowCount - 1)
                {
                    MessageBox.Show("Последняя строка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n\n" + ex, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        public static void navPrevious(DataGridView dgv) // Предыдущая запись
        {
            index = dgv.CurrentRow.Index;
            try
            {
                if (index <= dgv.RowCount - 1)
                {
                    dgv.Rows[index].Selected = true;
                    dgv.CurrentCell = dgv.Rows[index - 1].Cells[0];
                    //l.Text = index.ToString() + " | " + (dgv.RowCount - 1).ToString() + " | " + dgv.CurrentRow.Index.ToString();
                }
                else if (index == 0)
                {
                    MessageBox.Show("Первая строка", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n\n" + ex, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public static void navDelete() // Удаление записи
        {

        }

        public static void navSave() // Сохранение записи
        {

        }

        public static void navAdd() // Добавление записи
        {

        }

    }
}
