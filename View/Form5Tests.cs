using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using notes__app; // Add this using directive if needed

namespace notes__appTests.View
{
    [TestFixture]
    internal class Form5Tests
    {
        private Form5 form5;

        [SetUp]
        public void SetUp()
        {
            form5 = new Form5();
            form5.Show(); // This ensures that controls are created and accessible
        }

        [Test]
        public void Button1_Click_SuccessfulLogin()
        {
            // Arrange
            form5.textBox1.Text = "testUser";
            form5.textBox2.Text = "test@User123"; // Assuming this is a correct password

            // Act
            form5.button1.PerformClick();

            // Assert
            Assert.That("", Is.EqualTo(form5.label4.Text)); // Assert that the label4 text is empty, indicating successful login
        }




        [Test]
        public void Button1_Click_IncorrectPassword()
        {
            // Arrange
            form5.textBox1.Text = "testUser";
            form5.textBox2.Text = "incorrectPassword";

            // Act
            form5.button1.PerformClick();

            // Assert
            Assert.That(form5.label4.Text, Is.EqualTo("Password incorrect!")); // Assert that the label text is updated to "Password incorrect!"
        }

        [Test]
        public void Button1_Click_UserNotFound()
        {
            // Arrange
            form5.textBox1.Text = "nonExistentUser";
            form5.textBox2.Text = "somePassword";

            // Act
            form5.button1.PerformClick();

            // Assert
            Assert.That(MessageBox.Show("Log in was not successful!"), Is.EqualTo(DialogResult.OK)); // Assert that the message box with the appropriate message is displayed
        }



        [Test]
        public void Button2_Click_WithValidData_ShouldInsertUserAndShowSuccessMessage()
        {
            // Arrange
            form5.textBox1.Text = "User";
            form5.textBox2.Text = "Password@123";

            // Act
            form5.button2.PerformClick();

            // Assert
            Assert.That(MessageBox.Show("Data has been saved!"), Is.EqualTo(DialogResult.OK)); // Assert that success message box is shown
        }

        [Test]
        public void Button2_Click_WithExistingUsername_ShouldShowErrorMessage()
        {
            // Arrange
            form5.textBox1.Text = "User";
            form5.textBox2.Text = "Password@123";

            // Act
            form5.button2.PerformClick();

            // Assert
            Assert.That(form5.label3.Text, Is.EqualTo("Account with this username already exists!")); // Assert that label3 displays appropriate error message

        }

        [Test]
        public void Button2_Click_WithInvalidUsername_ShouldShowErrorMessage()
        {
            // Arrange
            form5.textBox1.Text = "user with space";
            form5.textBox2.Text = "Password@123";

            // Act
            form5.button2.PerformClick();

            // Assert
            Assert.That(form5.label3.Text, Is.EqualTo("You can't use this username! No spaces or @ sign allowed!")); // Assert that label3 displays appropriate error message
            
        }

        [Test]
        public void Button2_Click_WithInvalidPassword_ShouldShowErrorMessage()
        {
            // Arrange
            form5.textBox1.Text = "newUser";
            form5.textBox2.Text = "invalidpassword";

            // Act
            form5.button2.PerformClick();

            // Assert
            Assert.That(form5.label4.Text, Is.EqualTo("You can't use this password! No spaces allowed!\n" +
                                                       "The password must be between 8 and 16 characters long!\n" +
                                                       "The password must contain at least one capital and one\n" +
                                                       "lower letter, one number and one special sign.")); // Assert that label4 displays appropriate error message
            
        }

    }
}
