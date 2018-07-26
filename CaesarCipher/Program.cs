using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            int control = -1;
            do
            {
                Console.WriteLine("Co chcesz zrobić \n1) Szyfrowanie\n2) Deszyfrowanie\n0) Wyjście");
                control = Int32.Parse(Console.ReadLine());
                if (control == 1)
                {
                    initEncription();
                }
                if (control == 2)
                {
                    initDecription();
                }
                if (control != 1 && control != 2 && control != 0)
                {
                    Console.WriteLine("Niepoprawne dane, wprowadź inną liczbę");
                }
            } while (control != 0);
        }

        static void initEncription()
        {
            Console.Write("Podaj tekst do kodowania: ");
            string publicCode = Console.ReadLine().ToUpper();
            Console.Write("Podaj przesuniecie: ");
            int shift = int.Parse(Console.ReadLine()) % 26;
            string encriptedCode = CesarCipher(publicCode, shift);
            Console.WriteLine($"Tekst po zakodowaniu: {encriptedCode}");
        }

        static void initDecription()
        {
            Console.Write("Podaj tekst do odkodowania: ");
            string encriptedCode = Console.ReadLine().ToUpper();
            Console.Write("Podaj przesuniecie: ");
            int shift = int.Parse(Console.ReadLine()) % 26;
            string decriptedCode = CesarCipherDecription(encriptedCode, shift);
            Console.WriteLine($"Tekst po odkodowaniu: {decriptedCode}");
        }

        static string CesarCipher(string publicCode, int shift)
        {
            char[] publicCodeCharTab = new char[publicCode.Length];
            publicCodeCharTab= publicCode.ToCharArray();
            char[] encriptedCodeCharTab = new char[publicCodeCharTab.Length];
            for (int i = 0; i < publicCodeCharTab.Length; i++)
            {
                if (publicCodeCharTab[i]+shift>90)
                {
                    encriptedCodeCharTab[i] = (char)((int)publicCodeCharTab[i] + shift - 26);
                }
                else
                {
                    encriptedCodeCharTab[i] = (char)((int)publicCodeCharTab[i] + shift);
                }
            }

            string encriptedCodeString = new string(encriptedCodeCharTab);
            return encriptedCodeString;
        }

        static string CesarCipherDecription(string encriptedCode, int shift)
        {
            char[] encriptedCodeCharTab = new char[encriptedCode.Length];
            encriptedCodeCharTab = encriptedCode.ToCharArray();
            char[] decriptedCodeCharTab = new char[encriptedCodeCharTab.Length];
            for (int i = 0; i < encriptedCodeCharTab.Length; i++)
            {
                if ((int)encriptedCodeCharTab[i] - shift < 65)
                {
                    decriptedCodeCharTab[i] = (char)((int)encriptedCodeCharTab[i] - shift + 26);
                }
                else
                {
                    decriptedCodeCharTab[i] = (char)((int)encriptedCodeCharTab[i] - shift);
                }
            }

            string decriptedCodeString = new string(decriptedCodeCharTab);
            return decriptedCodeString;

        }

    }
}
