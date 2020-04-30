using System;
using System.Collections.Generic;

namespace consolemenu
{
    class Menu
    {
        /*

        ¡Bienvenido a la nevería!

        1) Tipo de cono
        2) Sabor de nieve
        3) Sencillo o doble
        4) Con o sin chocolate
        5) Toppings

        6) Pagar

        9) Salir

        Selecciona una opción:
        > 1
        [enter]

        */

        private const int MAIN_MENU_EXIT_OPTION = 9;
        private const int GO_BACK_OPTION = 9;

        List<int> mainMenuOptions = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 9});
        List<int> selectConeOptions = new List<int>(new int[] {1, 2, 9});
        List<int> selectFlaborOptions = new List<int>(new int[] {1, 2, 3, 9});

        private string tipoCono = "Regular";
        private string tipoSabor = "Vainilla";


        private void DisplayWelcomeMessage() {
            System.Console.WriteLine("¡Bienvenido a la nevería!");
            System.Console.WriteLine();
        }

        private void DisplayMainMenuOptions() {
            System.Console.WriteLine("1) Tipo de cono");
            System.Console.WriteLine("2) Sabor de nieve");
            System.Console.WriteLine("3) Sencillo o doble");
            System.Console.WriteLine("4) Con o sin chocolate");
            System.Console.WriteLine("5) Toppings");
            System.Console.WriteLine();
            System.Console.WriteLine("6) Pagar");
            System.Console.WriteLine();
            System.Console.WriteLine("9) Salir");
        }

        private void DisplayByeMessage() {
            System.Console.WriteLine("¡Gracias por su preferencia! ¡Hasta luego!");
        }

        private int RequestOption(List<int> validOptions) {
            int userInputAsInt = 0;
            bool isUserInputValid = false;

            //Mientras no haya una respuesta válida...
            //aqui se interpreta un valur adquirido, en este caso dado por el usuario
            while(!isUserInputValid) {
                System.Console.WriteLine("Selecciona una opción:");
                string userInput = System.Console.ReadLine();


                try {
                    userInputAsInt = Convert.ToInt32(userInput);
                    isUserInputValid = validOptions.Contains(userInputAsInt);
                } catch (System.Exception) {
                    isUserInputValid = false;
                }


                if (!isUserInputValid)
                {
                    System.Console.WriteLine("La opción seleccionada no es válida.");
                }
            }

            return userInputAsInt;
        }

        /*
        Selecciona un tipo de cono

        1) Regular
        2) Waffle

        9) Volver

        Selecciona una opción:
        > 1
        [enter]

        */

        private void DisplaySelectConeMessage() {/*es la funcion de dar un mensaje*/
            System.Console.WriteLine("Selecciona un tipo de cono");
            System.Console.WriteLine();
        }

        private void DisplaySelectConeOptions() {/*es la funsion de dar un mensaje*/
            System.Console.WriteLine("1) Regular");
            System.Console.WriteLine("2) Waffle");
            System.Console.WriteLine();
            System.Console.WriteLine("9) Volver");
        }

        private void SelectConeType() {
            int selectedOption = 0;

            while (selectedOption != GO_BACK_OPTION) {
                DisplaySelectConeMessage();
                DisplaySelectConeOptions();
                System.Console.WriteLine($"Tipo de Cono seleccionado: {tipoCono}");

                selectedOption = RequestOption(selectConeOptions);

                switch (selectedOption)
                {
                    case 1: //Regular
                        tipoCono = "Regular";
                        break;
                    case 2: //Waffle
                        tipoCono = "Waffle";
                        break;
                } //el break se sale de este switch
            }
        }

        private void DisplaySelectFlaborMessage() {/*es la funcion de dar un mensaje*/
            System.Console.WriteLine("Selecciona un sabor");
            System.Console.WriteLine();
        }

        private void DisplaySelectFlaborOptions() {/*es la funsion de dar un mensaje*/
            System.Console.WriteLine("1) Chocolate");
            System.Console.WriteLine("2) Vainilla");
            System.Console.WriteLine("2) Fresa");
            System.Console.WriteLine();
            System.Console.WriteLine("9) Volver");
        }

        private void SelectFlaborType() {
            int selectedOption = 0;

            while (selectedOption != GO_BACK_OPTION) {
                DisplaySelectFlaborMessage();
                DisplaySelectFlaborOptions();
                System.Console.WriteLine($"Tipo de Cono seleccionado: {tipoSabor}");

                selectedOption = RequestOption(selectFlaborOptions);

                switch (selectedOption)
                {
                    case 1: 
                        tipoSabor = "Chocolate";
                        break;
                    case 2: 
                        tipoCono = "Vainilla";
                        break;
                    case 3: 
                        tipoSabor = "Fresa";
                        break;
                } //el break se sale de este switch
            }
        }

        private void Pay() {
            //\n es salto de línea
            System.Console.WriteLine("Tu pedido es el siguiente:\n");
            System.Console.WriteLine($"tipoCono => {tipoCono}");
            System.Console.WriteLine($"tipoSabor => {tipoSabor}");

            System.Console.WriteLine("\n!Gracias por tu compra!");
        }

        public void Display() {
            int selectedOption = 0;

            DisplayWelcomeMessage();

            while (selectedOption != MAIN_MENU_EXIT_OPTION) {
                DisplayMainMenuOptions();

                selectedOption = RequestOption(mainMenuOptions);

                /*aqui se empiesa a ejecutar la interaccion*/
                switch (selectedOption) 
                {
                    case 1: //Tipo de cono
                        SelectConeType();
                        break;
                        case 2: //Tipo de cono
                        SelectFlaborType();
                        break;
                    case 6: //Pagar
                        Pay();
                        selectedOption = MAIN_MENU_EXIT_OPTION;
                        break;
                    // default:
                }
            }

            

            DisplayByeMessage();

        }
       
    }
}
