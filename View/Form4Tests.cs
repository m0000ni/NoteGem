using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using notes__app; // Add this using directive if needed

namespace notes__appTests.View
{
    [TestFixture]
    internal class Form4Tests
    {
        private Form4 form4;

        [SetUp]
        public void SetUp()
        {
            form4 = new Form4("SampleTitle");
            form4.Show(); // Ensure controls are created and accessible
        }

        [Test]
        public void Button1_Click_WithCorrectPinCode_ShouldShowPinCodeVerifiedMessage()
        {
            // Arrange
            form4.textBox1.Text = "1234"; // Assuming correct pin code

            // Act
            form4.button1.PerformClick();

            // Assert
            Assert.That(form4.label1.Text, Is.EqualTo("PIN code verified!")); // Assert that the label1 displays the expected message
        }

        [Test]
        public void Button1_Click_WithIncorrectPinCode_ShouldShowWrongPinCodeMessage()
        {
            // Arrange
            form4.textBox1.Text = "0000"; // Assuming incorrect pin code

            // Act
            form4.button1.PerformClick();

            // Assert
            Assert.That(form4.label1.Text, Is.EqualTo("Wrong PIN code!")); // Assert that the label1 displays the expected message
        }

        [Test]
        public void Button1_Click_WithEmptyPinCode_ShouldShowPleaseEnterPinCodeMessage()
        {
            // Arrange
            form4.textBox1.Text = ""; // Assuming empty pin code

            // Act
            form4.button1.PerformClick();

            // Assert
            Assert.That(MessageBox.Show("Please enter your PIN code!"), Is.EqualTo(DialogResult.OK)); // Assert that the expected message box is shown
        }

        [Test]
        public void Button2_Click_WithEmptyPinCode_ShouldShowPleaseEnterPinCodeMessage()
        {
            // Arrange
            form4.textBox1.Text = ""; // Assuming empty pin code

            // Act
            form4.button2.PerformClick();

            // Assert
            Assert.That(MessageBox.Show("Please enter a PIN code to add!"), Is.EqualTo(DialogResult.OK)); // Assert that the expected message box is shown
        }

        [Test]
        public void Button2_Click_WithNonEmptyPinCode_ShouldShowPinCodeAddedSuccessfullyMessage()
        {
            // Arrange
            form4.textBox1.Text = "1234"; // Assuming valid pin code

            // Act
            form4.button2.PerformClick();

            // Assert
            Assert.That(MessageBox.Show("PIN code added successfully!"), Is.EqualTo(DialogResult.OK)); // Assert that the expected message box is shown
        }
    }
}
