﻿
using _3.TaskQuiz;

//2.  Her defe proqrami basladan zaman variantlarda olan cavablar random deyismelidir. Meselen:
//	Proqrami 1-ci defe isedusen zaman sualin cavabi 
//	a) Baki
//	b) Gence
//	c) Naxcivan
//	Proqrami 2-ci defe isedusen zaman sualin cavabi
//	a) Gence
//	b) Naxcivan
//	c) Baki
//	Proqram bu qaydada her defe cavablari qarisdirmalidir.
//3.  Butun suallar ilk defeden acilmir bir suala cavab verennen sonra o biri sual acilir.
//4.  Istifadeci suala cavab vermek ucun sadece varianti secmelidir(Sualin cavabini konsolda yazmamalidir).
//5.  Duzgun cavab verilende hemen sual yasil rengde olsun, sehv cavabda qirmizi rengde.
//6.  Her duzgun suala gore user 10 xal qazanir her verdiyi cavaba gore 10 xal cixilir. Xal eger menfi olursa o zaman 0 xal 
//gostersin yeni menfi xal olmasin. Proqramin sonunda yazilsin ki, imtahan bitmisdir siz filan qeder xal toplamisiniz. 
//7.  Proqrami yazmaq ucun siz sadece funksiya, ve arraydan istifade elemelisiniz.
// List ve ozunuzden class yaradib istifade elemek olmaz.
//Note: 
//	Random reqem istifade elemek ucun:
//	Random rand = new Random();
//int number = rand.Next(0, 99); // hansi araliqda random reqem vermesinizi istiyirsinize 0 99 u istediyiniz araliqla deyisin.

namespace _3.TaskQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Quiz = {"1. Azerbaycanin Paytaxi Hansi Sheherdir ?",
                             "2. ROM nedir ?",
                             "3. C# Nedir ?",
                             "4. UK - un Paytixti Haradir ?",
                             "5. Ram Nedir ?",
                             "6. (Periferiya) Cixish Qurgular Hansilardir ?",
                             "7. Internet Nedir ?",
                             "8. DSL Nedir ?",
                             "9. Obyekt Yonumlu Programlashdirma nedir ?",
                             "10. Dunyanin En Boyuk Golu Hansidir ?",
                            };
            string[][] answers = [
                            ["Baku", "Ganja", "Naxcivan"],//1
                            ["Daimi Yaddash Sahesi", "Muveqqeti Yaddash Sahesi", "Shebeke"],//2
                            ["Object-oriented Programming Language", "CPU", "GPU"],//3
                            ["New York", "Baku", "London"],//4
                            ["Hec Biri", "Emeli Yaddash", "GPU"],//5
                            ["Kamera", "Mikrofon", "Monitor"],//6
                            ["Programing Language", "Sebeke", "İnformasiya"],//7
                            ["Massiv", "Emeli Yaddash", "Digital Subscriber Line"],//8
                            ["Server", "Modem", "Object-oriented Programming"],//9
                            ["Victoria", "Baikal", "Caspian"],//10
];

            string[] trueAnswers = ["Baku", "Daimi Yaddash Sahesi", "Object-oriented Programming Language", "London", "Emeli Yaddash", "Monitor", "Sebeke", "Digital Subscriber Line", "Object-oriented Programming", "Caspian"];


            int score = 0;
            Random random = new();
            for (int i = 0; i < Quiz.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Score: {score}");
                Console.WriteLine(Quiz[i]);
                random.Shuffle(answers[i]);
                Console.WriteLine($"A) {answers[i][0]}");
                Console.WriteLine($"B) {answers[i][1]}");
                Console.WriteLine($"C) {answers[i][2]}");

            answering:
                var key = Console.ReadKey().Key;

                int index = key switch
                {
                    ConsoleKey.A => 0,
                    ConsoleKey.B => 1,
                    ConsoleKey.C => 2,
                    _ => -1
                };
                if (index == -1) goto answering;
                
                    if (trueAnswers[i] == answers[i][index])
                    {
                        score += 10;
                   
                    char correctOption = (char)('A' + index);
                    Console.Clear();
                    for (char option = 'A'; option <= 'C'; option++)
                    {
                        if (option == correctOption)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine($"{option}) {answers[i][option - 'A']}");
                        Console.ResetColor();
                    }

                    System.Threading.Thread.Sleep(2500);
                }

                else
                {
                    score = score == 0 ? 0 : score - 10;
                    char truechoice = (char)('A' + index);
                    Console.Clear();
                    for (char choice = 'A'; choice <= 'C'; choice++)
                    {
                        if (choice == truechoice)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine($"{choice}) {answers[i][choice - 'A']}");
                        Console.ResetColor();
                    }
                    System.Threading.Thread.Sleep(2500);
                }
            }
            Console.Clear();
            Console.WriteLine($"\nTotal score: {score}");
        }
    }
}