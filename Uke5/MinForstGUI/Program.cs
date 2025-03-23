namespace MinForstGUI;
using System;
using System.Windows.Forms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        Form myForm = new()
        {
            Text = "Min Første GUI",
            Width = 400 ,
            Height = 300
        };
        TextBox myTextBox = new()
        {
            Left = 50,
            Top = 50,
            Width = 200
        };
        Button showButton = new()
        {
            Text =" Klikk meg !",
            Left = 150,
            Top = 100,
            Width =  100 
        };

        showButton.Click+= (sender,e)=> {
            string userInput = myTextBox.Text ;
            if (!String.IsNullOrEmpty(userInput))
            {
                MessageBox.Show($"Du skrev :{userInput}");
            }else {
                MessageBox.Show("Tekstboksen er tom!");
            }
        };
        myForm.Controls.Add(myTextBox);
        myForm.Controls.Add(showButton);
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();
        Application.Run(myForm);
    }    
}