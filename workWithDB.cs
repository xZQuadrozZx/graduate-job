using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
//using System.Data.Odbc;

namespace MotorAuto
{
    class workWithDB
    {

        private static string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB/Shop.mdb"; // Строка подключения

        static int rowsDGV, columnsDGV;
        public static string[,] dgvToArray(DataGridView dgv) // Перевод DataGridView в массив
        {
            rowsDGV = dgv.RowCount;
            columnsDGV = dgv.ColumnCount;

            string[,] str = new string[rowsDGV, columnsDGV];

            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    str[i, j] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            } 

            return str;
        }

        public static bool isEqual(string[,] str1, string[,] str2) // Сравнение двух массивов
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            for (int i = 0; i < rowsDGV; i++)
            {
                for (int j = 0; j < columnsDGV; j++)
                {
                    if (str1[i, j] != str2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void auth(string login, string password) // Авторизация
        {
            bool success = false;
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                const string cmd = "SELECT ФИО FROM Работник WHERE Логин = @login AND Пароль = @password";
                OleDbCommand check = new OleDbCommand(cmd, conn);
                check.Parameters.AddWithValue("@login", login);
                check.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    success = dataReader.Read();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы ввели неверные данные!", "Ошибка");
            }
            finally
            {
                conn.Close();
            }

            if (success == true)
            {
                fStartMenu form_StartMenu = new fStartMenu();
                form_StartMenu.Show();
                fAuth form_Auth = new fAuth();
                form_Auth.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void getUserName(string login, string password) // Выводит в переменную userName - имя пользователя
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                const string cmd = "SELECT ФИО FROM Работник WHERE Логин = @login AND Пароль = @password";
                OleDbCommand check = new OleDbCommand(cmd, conn);
                check.Parameters.AddWithValue("@login", login);
                check.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        fStartMenu.userName = dataReader[0].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        static string lastID;

        public static string getLastID(string cmdText) // Выводит последний элемент в таблице БД
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                OleDbCommand check = new OleDbCommand(cmdText, conn);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lastID = dataReader[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return lastID;
        }

        public static void getRole(string roleUserID) // Выводит в переменную roleUser - должность пользователя
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                const string cmd = "SELECT Должность FROM Должность WHERE ID = @roleUserID";
                OleDbCommand check = new OleDbCommand(cmd, conn);
                check.Parameters.AddWithValue("@roleUserID", roleUserID);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        fStartMenu.roleUser = dataReader[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        static string roleUser;

        public static string getRoleID(string login, string password) // Возвращает ID должности пользователя
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                const string cmd = "SELECT ДолжностьID FROM Работник WHERE Логин = @login AND Пароль = @password";
                OleDbCommand check = new OleDbCommand(cmd, conn);
                check.Parameters.AddWithValue("@login", login);
                check.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        roleUser = dataReader[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return roleUser;
        }

        //**************//
        private static OleDbDataAdapter dataAdapter;
        private static DataSet ds;
        //**************//

        public static void fillDGV(string cmdText, DataGridView dgv) // Заполняет таблицу по SQL-запросу
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                dataAdapter = new OleDbDataAdapter(cmdText, conn);
                ds = new DataSet();
                dataAdapter.Fill(ds);
                dgv.DataSource = ds.Tables[0].DefaultView;
                conn.Dispose();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillDGVComboBox(DataGridView dgv, string cmdText, DataGridViewComboBoxColumn dgvColumn, string sqlCol, string caption, string disMember, string ValMember) // Заполняет столбец таблицы по SQL-запросу
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                dgvColumn.DataPropertyName = sqlCol;
                dgvColumn.Name = caption;
                dgvColumn.DataSource = ds.Tables[0].DefaultView;
                dgvColumn.DisplayMember = disMember;
                dgvColumn.ValueMember = ValMember;
                dgvColumn.FlatStyle = FlatStyle.Flat;

                dgv.Columns.Add(dgvColumn);

                conn.Dispose();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillDGVTextBox(DataGridView dgv, string cmdText, DataGridViewColumn dgvColumn, string sqlCol, string caption) // Заполняет столбец таблицы по SQL-запросу
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdText, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                dgvColumn.DataPropertyName = sqlCol;
                dgvColumn.Name = caption;

                dgv.Columns.Add(dgvColumn);

                conn.Dispose();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillDGVColumn(DataGridView dgv, string cmdText, DataGridViewColumn dgvColumn, string sqlCol, string nameColumn) // Заполняет столбец таблицы по SQL-запросу
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                dataAdapter = new OleDbDataAdapter(cmdText, conn);
                ds = new DataSet();
                dataAdapter.Fill(ds);

                dgvColumn.DataPropertyName = sqlCol;
                dgvColumn.Name = nameColumn;
                dgv.Columns.Add(dgvColumn);

                conn.Dispose();
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void saveDB() // Сохранение изменений в БД
        {
            try
            {
                dataAdapter.Update(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillChart(Chart chart, string cmdText, string title, string displayMember, string valueMember) // Заполняет элемент Chart по SQL-запросу
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                chart.Titles[0].Text = title;
                chart.Titles[0].Font = new Font("Century Gothic", 16);

                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                cmd.Connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                chart.Series[0].Points.DataBindXY(reader, displayMember, reader, valueMember);

                reader.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                // Выдает ошибку при запуске окна со статистикой, хз почему
                //MessageBox.Show(ex.Message + "\nПолный текст:\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillCombobox(ComboBox cb, string dispMember, string valMember, string cmdText) // Заполняет выбранный combobox с помощью SQL запроса
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                dataAdapter = new OleDbDataAdapter(cmdText, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                cb.DataSource = dt;
                cb.DisplayMember = dispMember; // Что выводится
                cb.ValueMember = valMember; // Что используется

                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillTextbox(TextBox tb, string cmdText, string nameRow) // Заполняет выбранный textbox с помощью SQL запроса
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(cmdText, conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                reader.Read();
                tb.Text = reader[nameRow].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillPictureBox(PictureBox pb, string ID) // Вывод изображения из БД в PictureBox (Требуется исправление)
        {
            string pathToImg = System.AppDomain.CurrentDomain.BaseDirectory + "img\\auto"; // Фото из БД
            string pathToDefaultImg = System.AppDomain.CurrentDomain.BaseDirectory + "img"; // Фото стандартное

            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                const string cmd = "SELECT Фото FROM Товар WHERE ID = @photoID";
                OleDbCommand check = new OleDbCommand(cmd, conn);
                check.Parameters.AddWithValue("@photoID", ID);
                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader[0].ToString() == string.Empty)
                        {
                            Bitmap path = new Bitmap(pathToDefaultImg + "\\" + "no-photo.jpg");
                            pb.Image = path;
                        }
                        else
                        {
                            Bitmap path = new Bitmap(pathToImg + "\\" + dataReader[0].ToString());
                            pb.Image = path;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void actionDB(string cmdText) // Вносит изменения в БД
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            
            try
            {
                conn.Open();
                OleDbCommand comm = new OleDbCommand(cmdText, conn);
                comm.ExecuteNonQuery();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fillDTPMinDate(DateTimePicker dtp) // Получить минимальную дату
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MIN(Дата) FROM Операция", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                reader.Read();
                dtp.Text = reader[0].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
