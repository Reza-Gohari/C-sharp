namespace GjettEtTall;
using System ;
using System.Windows.Forms;


static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()

    {
        // Aktivere GUI _stiler
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Form gameForm = new Form
        {
            Text = "Gjett et tall",
            Width = 400 ,
            Height = 300
        };
        //Generer et tilfeldig tall mellom 1 og 100
        Random random = new Random();
        int targetNumber = random.Next(1,100);


        // Legg til en tekstboks for å skrive gjentninger 

        TextBox guessBox = new TextBox
        {
            Left = 50,
            Top = 50 ,
            Width = 100

        };
        // Legg til ne knapp for å sjekke gjetningen
        /*Button checkButton = new Button
        {
            Text = "Sjekk ",
            Left = 160,
            Top = 50 ,
            Width = 100
        };*/
        // Legg til en etikett for tilbakemelding
        Label feedbackLable = new Label
        {
            Text = "Gjett et tall mellom 1 til 100 !",
            Left = 50,
            Top = 100,
            Width = 300
        };
        // Legg til metode for å kjekke gjetningen
        void CheckGuess() 
        {
            if(int.TryParse(guessBox.Text,out int userGuess))
            {
                if (userGuess < targetNumber)
                {
                    feedbackLable.Text = "For lavt ! Prøv igjen.";
                }
                else if (userGuess > targetNumber)
                {
                    feedbackLable.Text = "For høyd ! Prøv igjen .";
                }
                else feedbackLable.Text = "Gratulere ! Du gjette riktig !";
            }
            else 
            {
                feedbackLable.Text = " Venligst skriv en et gyildig tall.";
            }
            guessBox.Text = string.Empty;
        }
        // Legg til keyPresss-hendelse for tekstboksen 
        guessBox.KeyPress += (sender,e) =>
        {
            if(e.KeyChar == (char)Keys.Enter) // Sjekker om Enter er trykket
            {
                e.Handled = true ; // Hindrer "pling"-lyd
                CheckGuess();
            }
        };


        // Legg til komponentene på skjermen 
        gameForm.Controls.Add(guessBox);
        //gameForm.Controls.Add(checkButton);
        gameForm.Controls.Add(feedbackLable);


        // Start GUI-vinduet
        Application.Run(gameForm);
    }    
}