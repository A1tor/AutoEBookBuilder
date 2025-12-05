using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEBookBuilder.UnitTests
{
    [TestFixture]
    internal class FormTester
    {
        private static MainForm form;

        [Test]
        public void FormClearFileListTestMethod()
        {
            if (form == null)
                form = new MainForm();
            var list = (ListBox) form.testForm("rawFilesListBox");
            list.Items.Clear();
            Assert.That(list.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void FormAddInvalidFileToListTestMethod()
        {
            if (form == null)
                form = new MainForm();
            FormClearFileListTestMethod();
            var texbox = (TextBox) form.testForm("newFilePathTextBox");
            texbox.Text = "test";
            for (int i = 0; i < 3; i++)
                form.testForm("addRawFileButton_Click");
            try
            {
                form.testForm("buildButton_Click");
                throw new Exception();
            }
            catch (ArgumentOutOfRangeException){}
            
            var result = (RichTextBox) form.testForm("eBookTextBox");
            Assert.That(result.Text, Is.EqualTo(""));
        }

        [Test]
        public void FormMoveFileTestMethod()
        {
            if (form == null)
                form = new MainForm();
            FormClearFileListTestMethod();
            var list = (ListBox) form.testForm("rawFilesListBox");
            for (int i = 0; i < 3; i++)
                list.Items.Add(i.ToString());
            list.SelectedIndex = 1;
            Assert.That(list.Items[list.SelectedIndex].ToString(), Is.EqualTo("1"));
            form.testForm("lowerFileButton_Click");
            Assert.That(list.Items[list.SelectedIndex].ToString(), Is.EqualTo("2"));
        }

        [Test]
        public void FormMoveInvalidFileTestMethod()
        {
            if (form == null)
                form = new MainForm();
            FormMoveFileTestMethod();
            var list = (ListBox) form.testForm("rawFilesListBox");
            list.SelectedIndex = 2;
            Assert.That(list.Items[list.SelectedIndex].ToString(), Is.EqualTo("1"));
            form.testForm("lowerFileButton_Click");
            Assert.That(list.Items[list.SelectedIndex].ToString(), Is.EqualTo("1"));
        }
        [Test]
        public void FormIndexSlidingOnDeleteFileListTestMethod()
        {
            if (form == null)
                form = new MainForm();
            FormMoveFileTestMethod();
            var list = (ListBox) form.testForm("rawFilesListBox");
            list.SelectedIndex = 0;
            Assert.That(list.Items.Count, Is.EqualTo(3));
            for (int i = 0; i < 3; i++)
                form.testForm("removeRawFileButton_Click");
            Assert.That(list.Items.Count, Is.EqualTo(0));
        }
    }
}
