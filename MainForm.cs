using AutoEBookBuilder.APIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoEBookBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            InitializeComponent();
        }
        public object testForm(string field)
        {
            switch (field)
            {
                case "rawFilesListBox":
                    return rawFilesListBox;
                case "eBookTextBox":
                    return eBookTextBox;
                case "buildButton_Click":
                    buildButton_Click(null, null);
                    return null;
                case "addRawFileButton_Click":
                    addRawFileButton_Click(null, null);
                    return null;
                case "newFilePathTextBox":
                    return newFilePathTextBox;
                case "lowerFileButton_Click":
                    lowerFileButton_Click(null, null);
                    return null;
                case "removeRawFileButton_Click":
                    removeRawFileButton_Click(null, null);
                    return null;
                default:
                    return null;
            }
        }

        private static Dictionary<string, Type> apiMap = new Dictionary<string, Type>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            reloadApiList();
            try
            {
                foreach (var file in DbLoader.getAll("fileList"))
                    rawFilesListBox.Items.Add(file);
            }
            catch (Exception) { }
        }

        private int totalFiles = 0;
        private void addRawFileButton_Click(object sender, EventArgs e)
        {
            var filePath = newFilePathTextBox.Text;
            if (File.Exists(filePath))
            {
                rawFilesListBox.Items.Add(filePath);
                totalFiles++;
                totalCounterLabel.Text = totalFiles.ToString();
            } 
            else
            {
                messageLabel.Text = String.Concat(filePath, " doesn't exist");
            }
        }

        private void removeRawFileButton_Click(object sender, EventArgs e)
        {
            var memory = rawFilesListBox.SelectedIndex;
            if (rawFilesListBox.SelectedIndex == -1)
                return;
            rawFilesListBox.Items.RemoveAt(rawFilesListBox.SelectedIndex);
            totalFiles--;
            if (rawFilesListBox.Items.Count > 0)
                rawFilesListBox.SelectedIndex = memory;
            totalCounterLabel.Text = totalFiles.ToString();
        }

        private void liftFileButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = rawFilesListBox.SelectedIndex;
            if (selectedIndex < 1)
                return;
            var movedFile = rawFilesListBox.Items[selectedIndex - 1];
            rawFilesListBox.Items[selectedIndex - 1] = rawFilesListBox.Items[selectedIndex];
            rawFilesListBox.Items[selectedIndex] = movedFile;
        }

        private void lowerFileButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = rawFilesListBox.SelectedIndex;
            if (selectedIndex == -1 || selectedIndex == rawFilesListBox.Items.Count - 1)
                return;
            var movedFile = rawFilesListBox.Items[selectedIndex];
            rawFilesListBox.Items[selectedIndex] = rawFilesListBox.Items[selectedIndex + 1];
            rawFilesListBox.Items[selectedIndex + 1] = movedFile;
        }
        private static string fileExplorerDialogFilter = "";
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveExplorerDialog.Filter = fileExplorerDialogFilter;
            saveExplorerDialog.FilterIndex = apiListComboBox.SelectedIndex < 0 ? 1 : apiListComboBox.SelectedIndex + 1;
            saveExplorerDialog.ShowDialog();
            var saveFileName = saveExplorerDialog.FileName;
            if (saveFileName.Equals("")) 
                return;
            var extentionIndex = saveFileName.LastIndexOf('.') + 1;
            var nameIndex = saveFileName.LastIndexOf('\\') + 1;
            var extention = saveFileName.Substring(extentionIndex).ToLower();
            try
            {
                File.WriteAllText(saveFileName, apiMap[extention]
                    .GetMethod("parseToType").Invoke(null, new object[] { 
                        eBookTextBox.Text, saveFileName.Substring(nameIndex, saveFileName.Length - nameIndex - extention.Length - 1) }).ToString());
            }
            catch (NullReferenceException) 
            {
                MessageBox.Show(
                    "Не удалось сохранить файл " + saveFileName + "\nAPI не содержит метода сериализации",
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить файл " + saveFileName + '\n' + ex.ToString(),
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            var bookStringBuilder = new StringBuilder();
            bool printBook = true;
            buildCounterLabel.Text = "0";
            var buildCounter = 0;

            foreach (string filePath in rawFilesListBox.Items)
            {
                bookStringBuilder.Append('\n');
                var extentionIndex = filePath.IndexOf('.') + 1;
                if (extentionIndex < 0)
                {
                    bookStringBuilder.Append("Файл ").Append(filePath).Append(" не имеет расширения");
                    printBook = false;
                    continue;
                }
                var fileType = filePath.Substring(extentionIndex, filePath.Length - extentionIndex);
                if (!apiMap.ContainsKey(fileType))
                {
                    bookStringBuilder.Append("Не существует API для расширения ").Append(fileType);
                    printBook = false;
                    continue;
                }
                var fileApiType = apiMap[fileType];
                try
                {
                    var a = fileApiType.GetMethod("get");
                    var fileText = fileApiType.GetMethod("get").Invoke(null, new object[] { filePath });
                    if (printBook)
                        bookStringBuilder.Append(fileText);
                    buildCounter++;
                    buildCounterLabel.Text = buildCounter.ToString();
                    DbLoader.write("fileList", filePath);
                }
                catch (Exception ex)
                {
                    bookStringBuilder.Append("Ошибка парсинга файла ").Append(filePath).Append('\n').Append(ex.ToString());
                    printBook = false;
                    Console.WriteLine(ex.ToString());
                }
            }
            if (!printBook)
                MessageBox.Show(
                        "Не удалось собрать книгу. Пожалуста, просмотрите список ошибок",
                        "Ошибка сборки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            eBookTextBox.Text = bookStringBuilder.Remove(0, 1).ToString();
        }

        private void explorerButton_Click(object sender, EventArgs e)
        {
            explorerDialog.Multiselect = true;
            explorerDialog.Filter = String.Concat("Все файлы (*.*)|*.*|", fileExplorerDialogFilter);
            explorerDialog.ShowDialog();
            rawFilesListBox.Items.AddRange(explorerDialog.FileNames);
            totalCounterLabel.Text = rawFilesListBox.Items.Count.ToString();
            explorerDialog.Reset();
        }

        private void addApiButton_Click(object sender, EventArgs e)
        {
            if (newFilePathTextBox.Text.EndsWith(".cs") && !apiList.Contains(newFilePathTextBox.Text))
                DbLoader.write("apis", newFilePathTextBox.Text);
            else
                MessageBox.Show(
                        "Это не корректный Api файл",
                        "Ошибка добавления API",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            reloadApiList();
        }

        List<string> apiList;
        private void reloadApiList()
        {
            try
            {
                apiList = DbLoader.getAll("apis");
                apiMap = ApiLoader.Load(apiList);
                var sb = new StringBuilder();
                foreach (var fileApiType in apiMap)
                {
                    var descriptionField = fileApiType.Value.GetField("description");
                    if (descriptionField == null)
                        sb.Append("Не удалось найти описание");
                    else
                        sb.Append(descriptionField.GetValue(null));
                    sb.Append(" (*.").Append(fileApiType.Key).Append(")|*.").Append(fileApiType.Key).Append('|');
                }
                apiListComboBox.Items.Clear();
                apiListComboBox.Items.AddRange(apiMap.Keys.ToArray<string>());
                if (sb.Length > 0)
                    sb.Length = sb.Length - 1;
                fileExplorerDialogFilter = sb.ToString();
            }
            catch (Exception){}
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            rawFilesListBox.Items.Clear();
            DbLoader.delete("fileList");
        }

        int count = 0;
        private void messageLabel_Click(object sender, EventArgs e)
        {
            var mod = count % 3;
            if (count == 0) {
                messageLabel.Text = "Пузырьком";
            }
            else if (count == 1)
            {
                messageLabel.Text = "Вставкой";
            }
            else if (count == 2)
            {
                messageLabel.Text = "Быстрая";
            }
            count++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mod = count % 3;
            List<string> itemsList = rawFilesListBox.Items.Cast<string>().ToList();
            rawFilesListBox.Items.Clear();
            if (count == 0)
            {
                foreach (var item in Sorter.BubbleSort(itemsList))
                {
                    rawFilesListBox.Items.Add(item);
                };
            }
            else if (count == 1)
            {
                foreach (var item in Sorter.InsertionSort(itemsList))
                {
                    rawFilesListBox.Items.Add(item);
                };
            }
            else if (count == 2)
            {
                foreach (var item in Sorter.QuickSort(itemsList))
                {
                    rawFilesListBox.Items.Add(item);
                };
            }
        }
    }
}
