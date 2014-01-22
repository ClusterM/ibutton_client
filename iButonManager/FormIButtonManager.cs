using Cluster.iButtonManager.Properties;
using Cluster.iButtonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Внимание! Ниже много говнокода :)

namespace Cluster.iButtonManager
{
    public partial class FormIButtonManager : Form
    {
        public FormIButtonManager()
        {
            InitializeComponent();
        }

        private string KeyType(byte type)
        {
            switch (type)
            {
                case 0xFF: return "Cyfral";
                case 0xFE: return "Metacom";
                default: return string.Format("{0:X2}", type);
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = new iButtonConnection(Settings.Default.Port);
                var keys = connection.ReadKeys();
                dataGridViewKey.Rows.Clear();
                dataGridViewKey.RowCount = keys.Length;
                for (int i = 0; i < keys.Length; i++)
                {
                    dataGridViewKey.Rows[i].Tag = keys[i];
                    dataGridViewKey.Rows[i].Cells["colTypeK"].Value = KeyType(keys[i].Type);
                    dataGridViewKey.Rows[i].Cells["colKeyK"].Value = keys[i].Key;
                    dataGridViewKey.Rows[i].Cells["colCRCK"].Value = (keys[i].Type != 0xFF ? string.Format("{0:X2}", keys[i].CRC) : "--");
                    bool found = false;
                    foreach (DataGridViewRow keyInDB in dataGridViewDatabase.Rows)
                    {
                        if (((iButtonKey)keyInDB.Tag).ToString() == keys[i].ToString())
                        {
                            found = true;
                            dataGridViewKey.Rows[i].Cells["colDescriptionK"].Value = keyInDB.Cells["colDescription"].Value;
                        }
                    }
                    if (!found)
                    {
                        var newRow = dataGridViewDatabase.Rows.Add();
                        dataGridViewDatabase.Rows[newRow].Tag = keys[i];
                        dataGridViewDatabase.Rows[newRow].Cells["colType"].Value = KeyType(keys[i].Type);
                        dataGridViewDatabase.Rows[newRow].Cells["colKey"].Value = keys[i].Key;
                        dataGridViewDatabase.Rows[newRow].Cells["colCRC"].Value = (keys[i].Type != 0xFF ? string.Format("{0:X2}", keys[i].CRC) : "--");
                        dataGridViewKey.Rows[i].Cells["colDescriptionK"].Value =
                            dataGridViewDatabase.Rows[newRow].Cells["colDescription"].Value = "Добавлен " + DateTime.Now.ToString();
                    }
                }
                for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                    dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
                for (int i = 0; i < dataGridViewKey.RowCount; i++)
                    dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
                SaveDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Уверен?", "Записать?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                != System.Windows.Forms.DialogResult.Yes) return;
            try
            {
                var connection = new iButtonConnection(Settings.Default.Port);
                connection.Erase();
                for (int i = 0; i < dataGridViewKey.RowCount; i++)
                    connection.Write(((iButtonKey)dataGridViewKey.Rows[i].Tag));
                MessageBox.Show(this, "Готово!", "Запись ключей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteFromKey_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
            {
                if (dataGridViewKey.Rows[i].Selected &&
                    MessageBox.Show(this, "Уверен?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewKey.Rows.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
                dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
        }
                
        private void dataGridViewDatabase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
            {
                if (dataGridViewDatabase.Rows[e.RowIndex].Tag.ToString() == dataGridViewKey.Rows[i].Tag.ToString())
                {
                    dataGridViewKey.Rows[i].Cells["colDescriptionK"].Value = dataGridViewDatabase.Rows[e.RowIndex].Cells["colDescription"].Value;
                }
            }
        }

        private void dataGridViewKey_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var newDescription = dataGridViewKey.Rows[e.RowIndex].Cells["colDescriptionK"].Value;
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
            {
                if (dataGridViewDatabase.Rows[i].Tag.ToString() == dataGridViewKey.Rows[e.RowIndex].Tag.ToString())
                {
                    dataGridViewDatabase.Rows[i].Cells["colDescription"].Value = newDescription;
                }
            }
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
            {
                if (dataGridViewKey.Rows[i].Tag.ToString() == dataGridViewKey.Rows[e.RowIndex].Tag.ToString())
                {
                    dataGridViewKey.Rows[i].Cells["colDescriptionK"].Value = newDescription;
                }
            }
        }

        private void dataGridViewDatabase_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
        }

        private void dataGridViewKey_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
                dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
        }

        void AddToDeviceSelectedRow()
        {
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
            {
                if (dataGridViewDatabase.Rows[i].Selected)
                {
                    var newRow = dataGridViewKey.Rows.Add();
                    dataGridViewKey.Rows[newRow].Tag = dataGridViewDatabase.Rows[i].Tag;
                    dataGridViewKey.Rows[newRow].Cells["colTypeK"].Value = dataGridViewDatabase.Rows[i].Cells["colType"].Value;
                    dataGridViewKey.Rows[newRow].Cells["colKeyK"].Value = dataGridViewDatabase.Rows[i].Cells["colKey"].Value;
                    dataGridViewKey.Rows[newRow].Cells["colCRCK"].Value = dataGridViewDatabase.Rows[i].Cells["colCRC"].Value;
                    dataGridViewKey.Rows[newRow].Cells["colDescriptionK"].Value = dataGridViewDatabase.Rows[i].Cells["colDescription"].Value;
                }
            }
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
                dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
        }

        private void buttonAddToDevice_Click(object sender, EventArgs e)
        {
            AddToDeviceSelectedRow();
        }

        private void dataGridViewDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDatabase.Columns[e.ColumnIndex].Name != "colDescription")
                AddToDeviceSelectedRow();
        }

        private void buttonUpKey_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridViewKey.RowCount; i++)
            {
                if (dataGridViewKey.Rows[i].Selected)
                {
                    var row1 = dataGridViewKey.Rows[i - 1];
                    var row2 = dataGridViewKey.Rows[i];
                    dataGridViewKey.Rows.RemoveAt(i - 1);
                    dataGridViewKey.Rows.RemoveAt(i - 1);
                    dataGridViewKey.Rows.Insert(i - 1, row2);
                    dataGridViewKey.Rows.Insert(i, row1);
                    dataGridViewKey.Rows[i - 1].Selected = true;
                    break;
                }
            }
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
                dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
        }

        private void buttonDownKey_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewKey.RowCount - 1; i++)
            {
                if (dataGridViewKey.Rows[i].Selected)
                {
                    var row1 = dataGridViewKey.Rows[i];
                    var row2 = dataGridViewKey.Rows[i + 1];
                    dataGridViewKey.Rows.RemoveAt(i);
                    dataGridViewKey.Rows.RemoveAt(i);
                    dataGridViewKey.Rows.Insert(i, row1);
                    dataGridViewKey.Rows.Insert(i, row2);
                    dataGridViewKey.Rows[i + 1].Selected = true;
                    break;
                }
            }
            for (int i = 0; i < dataGridViewKey.RowCount; i++)
                dataGridViewKey.Rows[i].Cells["colNumK"].Value = i + 1;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridViewDatabase.RowCount; i++)
            {
                if (dataGridViewDatabase.Rows[i].Selected)
                {
                    var row1 = dataGridViewDatabase.Rows[i - 1];
                    var row2 = dataGridViewDatabase.Rows[i];
                    dataGridViewDatabase.Rows.RemoveAt(i - 1);
                    dataGridViewDatabase.Rows.RemoveAt(i - 1);
                    dataGridViewDatabase.Rows.Insert(i - 1, row2);
                    dataGridViewDatabase.Rows.Insert(i, row1);
                    dataGridViewDatabase.Rows[i - 1].Selected = true;
                    break;
                }
            }
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDatabase.RowCount - 1; i++)
            {
                if (dataGridViewDatabase.Rows[i].Selected)
                {
                    var row1 = dataGridViewDatabase.Rows[i];
                    var row2 = dataGridViewDatabase.Rows[i + 1];
                    dataGridViewDatabase.Rows.RemoveAt(i);
                    dataGridViewDatabase.Rows.RemoveAt(i);
                    dataGridViewDatabase.Rows.Insert(i, row1);
                    dataGridViewDatabase.Rows.Insert(i, row2);
                    dataGridViewDatabase.Rows[i + 1].Selected = true;
                    break;
                }
            }
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
            {
                if (dataGridViewDatabase.Rows[i].Selected &&
                    MessageBox.Show(this, "Уверен?", "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewDatabase.Rows.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
        }

        private void SaveDatabase()
        {
            var database = new List<string>();
            for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
            {
                database.Add(dataGridViewDatabase.Rows[i].Tag.ToString() + ";" + dataGridViewDatabase.Rows[i].Cells["colDescription"].Value);
            }
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "keys.dat"), database);
        }

        private void FormIButtonManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDatabase();
        }

        private void FormIButtonManager_Load(object sender, EventArgs e)
        {
            try
            {
                var database = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "keys.dat"));
                dataGridViewDatabase.RowCount = database.Length;
                for (int i = 0; i < database.Length; i++)
                {
                    var line = database[i];
                    int d = line.IndexOf(";");
                    var key = new iButtonKey(line.Substring(0, d));
                    var description = line.Substring(d + 1);
                    dataGridViewDatabase.Rows[i].Tag = key;
                    dataGridViewDatabase.Rows[i].Cells["colType"].Value = KeyType(key.Type);
                    dataGridViewDatabase.Rows[i].Cells["colKey"].Value = key.Key;
                    dataGridViewDatabase.Rows[i].Cells["colCRC"].Value = (key.Type != 0xFF ? string.Format("{0:X2}", key.CRC) : "--");
                    dataGridViewDatabase.Rows[i].Cells["colDescription"].Value = description;
                }
                for (int i = 0; i < dataGridViewDatabase.RowCount; i++)
                    dataGridViewDatabase.Rows[i].Cells["colNum"].Value = i + 1;
            }
            catch { }
        }

        private void определитьПортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                if (new iButtonConnection(port).Test())
                {
                    Settings.Default.Port = port;
                    Settings.Default.Save();
                    MessageBox.Show(this, "Порт определён: " + port, "Определение порта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show(this, "Не определён", "Определение порта", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void перезагрузитьУстройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connection = new iButtonConnection(Settings.Default.Port);
            try
            {
                connection.Reboot();
                MessageBox.Show(this, "Готово", "Перезагрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
