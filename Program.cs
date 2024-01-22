﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace BusinessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int newCount = 0, mobileCount = 0, laptopCount = 0, swCount = 0, earbudCount = 0, mobileSCount = 0, mobileOCount = 0, mobileICount = 0, mobileMCount = 0, mobileTCount = 0, laptopICount = 0, laptopDCount = 0, laptopHCount = 0, laptopIpCount = 0, swMCount = 0, swKCount = 0, swZCount = 0, swACount = 0, earbudXCount = 0, earbudACount = 0, earbudAsCount = 0, shCount = 0, feedbackCount = 0;

            string[] SamsungM = new string[100];
            string[] OppoM = new string[100];
            string[] InfinixM = new string[100];
            string[] miXiaomiM = new string[100];
            string[] TecnoM = new string[100];
            string[] InfinixL = new string[100];
            string[] Dell = new string[100];
            string[] HP = new string[100];
            string[] iphoneL = new string[100];
            string[] mibro = new string[100];
            string[] kieslect = new string[100];
            string[] ZERO = new string[100];
            string[] Assortedsw = new string[100];
            string[] XiaomiE = new string[100];
            string[] Audionic = new string[100];
            string[] AssortedE = new string[100];
            string[] shDevices = new string[100];
            string[] feedbacks = new string[100];

            double[] SamsungMPrices = new double[100];
            double[] oppoMPrices = new double[100];
            double[] infinixMPrices = new double[100];
            double[] miXiaomiMPrices = new double[100];
            double[] TecnoMPrices = new double[100];
            double[] InfinixLPrices = new double[100];
            double[] dellPrices = new double[100];
            double[] HPPrices = new double[100];
            double[] iphoneLPrices = new double[100];
            double[] mibroPrices = new double[100];
            double[] kieslectPrices = new double[100];
            double[] zeroPrices = new double[100];
            double[] AssortedswPrices = new double[100];
            double[] XiaomiEPrices = new double[100];
            double[] AudionicPrices = new double[100];
            double[] AssortedEPrices = new double[100];
            double[] shDevicesPrices = new double[100];

            string[] mobileCompanies = new string[5] { "SAMSUNG", "OPPO", "INFINIX", "MI XIAOMI", "TECNO" };
            string[] LaptopCompanies = new string[4] { "INFINIX", "DELL", "HP", "IPHONE" };
            string[] swCompanies = new string[4] { "MIBRO", "KIESLECT", "ZERO", "ASSORTED" };
            string[] EarbudsCompanies = new string[3] { "MI XIAOMI", "AUDIONIC", "ASSORTED" };

            string[] newName = new string[100];
            string[] newPassword = new string[100];
            string[] role = new string[100];
            string[] accountNo = new string[100];
            double budget = 0, tempBudget = budget;
            loadDevicedata(SamsungM, SamsungMPrices,ref mobileSCount, "Samsung.txt");
            loadDevicedata(OppoM, oppoMPrices, ref mobileOCount, "Oppo.txt");
            loadDevicedata(InfinixM, infinixMPrices, ref mobileICount, "InfinixM.txt");
            loadDevicedata(miXiaomiM, miXiaomiMPrices, ref mobileMCount, "MiM.txt");
            loadDevicedata(TecnoM, TecnoMPrices, ref mobileTCount, "Tecno.txt");
            loadDevicedata(InfinixL, InfinixLPrices, ref laptopICount, "InfinixL.txt");
            loadDevicedata(Dell, dellPrices, ref laptopDCount, "Dell.txt");
            loadDevicedata(HP, HPPrices, ref laptopHCount, "Hp.txt");
            loadDevicedata(iphoneL, iphoneLPrices, ref laptopIpCount, "Iphone.txt");
            loadDevicedata(mibro, mibroPrices, ref swMCount, "Mibro.txt");
            loadDevicedata(kieslect, kieslectPrices, ref swKCount, "Kieslect.txt");
            loadDevicedata(ZERO, zeroPrices, ref swZCount, "Zero.txt");
            loadDevicedata(Assortedsw, AssortedswPrices, ref swACount, "AssortedS.txt");
            loadDevicedata(XiaomiE, XiaomiEPrices, ref earbudXCount, "MiE.txt");
            loadDevicedata(Audionic, AudionicPrices, ref earbudACount, "Audionic.txt");
            loadDevicedata(AssortedE, AssortedEPrices, ref earbudAsCount, "AssortedE.txt");
            loadDevicedata(shDevices, shDevicesPrices, ref shCount, "Shdevices.txt");
            loadFeedback(feedbacks,ref feedbackCount);
            ReadUserInfo(newName, newPassword, role, accountNo,ref newCount);
            while (true)
            {
                printHeader();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                int opt;
                string input;
                loginPage();
                Console.WriteLine("Enter the option...");
                input = Console.ReadLine();
                if (checkOptionValidation(input))
                {
                    opt = int.Parse(input);
                    if (opt == 1)
                    {
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t SIGN IN PAGE ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");

                        string Name, Password;

                        while (true)
                        {
                            while (true)
                            {
                                Console.Write("Enter Username: ");
                                Name = Console.ReadLine();
                                if (string.IsNullOrEmpty(Name))
                                {
                                    Console.WriteLine("UserName cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Write("Enter Password: ");
                                Password = Console.ReadLine();
                                if (string.IsNullOrEmpty(Password))
                                {
                                    Console.WriteLine("Password cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            string userRole = SignIn(Name, Password, newName, newPassword, role);
                            int accountCount = AccountCount(Name, Password, newName, newPassword, role);
                            string upperUserRole = UpperLetters(userRole);

                            if (upperUserRole == "ADMIN")
                            {
                                printHeader();
                                Console.WriteLine("Signing in as an ADMIN.");
                                Thread.Sleep(1500);
                                adminMenu(newName, role, newCount, mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, ref mobileCount, LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, ref mobileSCount, ref mobileOCount, ref mobileICount, ref mobileMCount, ref mobileTCount, ref laptopICount, ref laptopDCount, ref laptopHCount, ref laptopIpCount, ref swMCount, ref swKCount, ref swZCount, ref swACount, ref earbudXCount, ref earbudACount, ref earbudAsCount, shDevices, shDevicesPrices, ref shCount, ref budget, ref tempBudget, feedbacks, ref feedbackCount);
                                break;
                            }
                            else if (upperUserRole == "CUSTOMER")
                            {
                                printHeader();
                                Console.WriteLine("Signing in as a Customer.");
                                Thread.Sleep(1500);
                                customerMenu(mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, ref mobileSCount, ref mobileOCount, ref mobileICount, ref mobileMCount, ref mobileTCount, ref laptopICount, ref laptopDCount, ref laptopHCount, ref laptopIpCount, ref swMCount, ref swKCount, ref swZCount, ref swACount, ref earbudXCount, ref earbudACount, ref earbudAsCount, shDevices, shDevicesPrices, shCount, budget, ref tempBudget, accountNo, accountCount, feedbacks, ref feedbackCount);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(userRole);
                            }
                        }
                    }
                    else if (opt == 2)
                    {
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t SIGN UP PAGE");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Instructions for Sign Up => \n Username must be at least 6 characters long and must not contain any special character and contain at least 3 letters \n Password must be at least 8 characters long\n");

                        while (true)
                        {
                            Console.Write("Enter Username: ");
                            newName[newCount] = Console.ReadLine();
                            if (CheckUserName(newName[newCount], newName, newCount))
                            {
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write("Enter Password: ");
                            newPassword[newCount] = Console.ReadLine();
                            if (newPassword[newCount].Length < 8)
                            {
                                Console.WriteLine("Invalid input. Password does not contain 8 characters.");
                                continue;
                            }
                            break;
                        }

                        string upperRole;
                        while (true)
                        {
                            Console.Write("Enter your role (Admin/Customer): ");
                            role[newCount] = Console.ReadLine();
                            upperRole = UpperLetters(role[newCount]);
                            if (upperRole != "ADMIN" && upperRole != "CUSTOMER")
                            {
                                Console.WriteLine("\nInvalid Role. Please select a valid role.");
                                continue;
                            }
                            break;
                        }

                        if (upperRole == "CUSTOMER")
                        {
                            while (true)
                            {
                                Console.Write("Enter your Account Number (Must be 13 digits): ");
                                accountNo[newCount] = Console.ReadLine();
                                if (accountNo[newCount].Length == 13 && checkOptionValidation(accountNo[newCount]))
                                {
                                    StoreUserInfo(newName, newPassword, role, accountNo, newCount);
                                    Console.WriteLine("\nYou have successfully registered your credentials.");
                                    newCount++;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Account Number / Account Number must be 13 digits.");
                                }
                            }
                        }
                        else if (upperRole == "ADMIN")
                        {
                            StoreUserInfo(newName, newPassword, role, accountNo, newCount);
                            Console.WriteLine("\nYou have successfully registered your credentials.");
                            newCount++;
                        }
                    }
                    else if (opt == 3)
                    {
                        Console.Clear();
                        printHeader();

                        Console.WriteLine("Thanks for coming here.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option Selection.");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                    }

                    Console.WriteLine("\n\n\nPress any Key to go to Login Page...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please write valid input.");
                    Thread.Sleep(750);
                    Console.Clear();
                }
            }
        }

        static void printHeader()
        {
            Console.WriteLine("___________________________________________________________________________________________________________________________");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                              ____  _   _ _____ ___ _  ___   _   _____ _____ ____ _   _                                  |");
            Console.WriteLine("|                             | ___|| | | | ____|_ _| |/ | | | | |_   _| ____| ___| | | |                                 |");
            Console.WriteLine("|                             |___ || |_| |  _|  | || ' /| |_| |   | | |  _| | |  | |_| |                                 |");
            Console.WriteLine("|                              ___)||  _  | |___ | || . \\|  _  |   | | | |__ | |__|  _  |                                 |");
            Console.WriteLine("|                             |____||_| |_|_____|___|_|\\_|_| |_|   |_| |_____|____|_| |_|                                 |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");

        }
        static void loginPage()
        {
            Console.WriteLine("\t \t \t \t \t \tLOGIN PAGE ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" 1. Sign In with your credentials.");
            Console.WriteLine(" 2. Sign Up your credentials");
            Console.WriteLine(" 3. Exit");
        }
        static void StoreFeedback(string[] feedbacks, int feedbackCount)
        {
            string path = "Feedback.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(feedbacks[feedbackCount]);
            file.Close();
        }

        static void loadFeedback(string[] feedbacks, ref int feedbackCount)
        {
            string path = "Feedback.txt";
            string record;
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                while ((record = reader.ReadLine()) != null)
                {
                    feedbacks[feedbackCount] = record;
                    feedbackCount++;
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void loadDevicedata(string[] company, double[] companyPrices, ref int count, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader file = new StreamReader(fileName);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    company[count] = ParseData(record, 1);
                    companyPrices[count] = double.Parse(ParseData(record, 2));
                    count++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void UpdateDeviceData(string[] company, double[] companyPrices, ref int count, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamWriter file = new StreamWriter(fileName, false);
                for (int i = 0; i < count; i++)
                {
                    file.Write(company[i]+","+companyPrices[i]);
                    if (i < count - 1)
                    {
                        file.WriteLine();
                    }
                }
                file.Close();

            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void ReadUserInfo(string[] newName, string[] newPassword, string[] role, string[] accountNo, ref int newCount)
        {
            string record;
            StreamReader file = new StreamReader("Users.txt");
            while ((record = file.ReadLine()) != null)
            {
                newName[newCount] = ParseData(record, 1);
                newPassword[newCount] = ParseData(record, 2);
                role[newCount] = ParseData(record, 3);
                accountNo[newCount] = ParseData(record, 4);
                newCount++;
            }
            file.Close();
        }
        static void StoreUserInfo(string[] newName, string[] newPassword, string[] role, string[] accountNo, int newCount)
        {
            char c = (char)138;
            StreamWriter file = new StreamWriter("Users.txt", true);
            file.WriteLine($"{newName[newCount]},{newPassword[newCount]},{role[newCount]},{accountNo[newCount]}");
            file.Close();
        }
        static void addDeviceData(string addModel, double addModelPrice, string[] company, double[] companyPrices, ref int count, string fileName)
        {
            company[count] = addModel;
            companyPrices[count] = addModelPrice;
            StreamWriter file = new StreamWriter(fileName, true);
            file.WriteLine();
            file.Write($"{company[count]},{companyPrices[count]}");
            count++;
            file.Close();
        }

        static string ParseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static string ParseDataForLogin(string record, int field)
        {
            char c = (char)138;
            int cCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == c)
                {
                    cCount++;
                }
                else if (cCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static string UpperLetters(string word)
        {
            string letters = "";

            for (int i = 0; i < word.Length; i++)
            {
                letters += char.ToUpper(word[i]);
            }

            return letters;
        }
        static bool CheckUserName(string word, string[] newName, int newCount)
        {
            if (ExistedUsername(newName, newCount))
            {
                Console.WriteLine("Username already taken. Please choose another.");
                return false;
            }

            if (word.Length > 5)
            {
                int letterCount = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    {
                        letterCount++;
                    }
                    else if (!(c >= '0' && c <= '9'))
                    {
                        Console.WriteLine("Invalid character in username. Use only letters and numbers.");
                        return false;
                    }
                }

                if (letterCount >= 3)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username. Username must contain at least 3 letters.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid username. Username must be at least 6 characters long.");
                return false;
            }
        }
        static string SignIn(string name, string password, string[] newName, string[] newPassword, string[] role)
        {
            for (int j = 0; j < 100; j++)
            {
                if (name == newName[j] && password != newPassword[j])
                {
                    return "You have entered the wrong password.";
                }
            }

            for (int j = 0; j < 100; j++)
            {
                if (name != newName[j] && password == newPassword[j])
                {
                    return "You have entered the wrong username.";
                }
            }

            for (int j = 0; j < 100; j++)
            {
                if (name == newName[j] && password == newPassword[j])
                {
                    Console.Clear();
                    return role[j];
                }
            }

            return "You are not registered yet.";
        }
        static int AccountCount(string name, string password, string[] newName, string[] newPassword, string[] role)
        {
            for (int j = 0; j < 100; j++)
            {
                if (name == newName[j] && password == newPassword[j])
                {
                    Console.Clear();
                    return j;
                }
            }
            return -1;
        }
        static bool ExistedUsername(string[] newName, int newCount)
        {
            for (int i = newCount - 1; i >= 0; i--)
            {
                if (newName[newCount] == newName[i])
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckMobileCompany(string company)
        {
            if (company == "SAMSUNG" || company == "OPPO" || company == "INFINIX" || company == "MI XIAOMI" || company == "TECNO")
            {
                return true;
            }
            return false;
        }

        static bool CheckLaptopCompany(string company)
        {
            if (company == "INFINIX" || company == "DELL" || company == "HP" || company == "IPHONE")
            {
                return true;
            }
            return false;
        }

        static bool CheckSWCompany(string company)
        {
            if (company == "MIBRO" || company == "KIESLECT" || company == "ZERO" || company == "ASSORTED")
            {
                return true;
            }
            return false;
        }

        static bool CheckEarbudCompany(string company)
        {
            if (company == "MI XIAOMI" || company == "AUDIONIC" || company == "ASSORTED")
            {
                return true;
            }
            return false;
        }

        static bool checkModel(string[] models, string modelName, int count)
        {
            for (int j = 0; j < count; j++)
            {
                if (models[j] == modelName)
                {
                    return true;
                }
            }
            return false;
        }

        static void printMobiles(string[] mobileCompanies, string[] SamsungM, double[] SamsungMPrices, string[] OppoM, double[] oppoMPrices, string[] InfinixM, double[] infinixMPrices, string[] miXiaomiM, double[] miXiaomiMPrices, string[] TecnoM, double[] TecnoMPrices, int mobileCount, int mobileSCount, int mobileOCount, int mobileICount, int mobileMCount, int mobileTCount)
        {
            int mX = 81, mY = 19;
            Console.WriteLine("\t \t \t \t \t \t \t \t Samsung\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileSCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{SamsungM[i]}");
                Console.SetCursorPosition(mX, mY);
                Console.WriteLine(SamsungMPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Oppo\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileOCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{OppoM[i]}");
                Console.SetCursorPosition(mX, mY + 7);
                Console.WriteLine(oppoMPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileICount; i++)
            {
                Console.WriteLine($"\t \t \t \t{InfinixM[i]}");
                Console.SetCursorPosition(mX, mY + 14);
                Console.WriteLine(infinixMPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t MI Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileMCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{miXiaomiM[i]}");
                Console.SetCursorPosition(mX, mY + 21);
                Console.WriteLine(miXiaomiMPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Tecno\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileTCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{TecnoM[i]}");
                Console.SetCursorPosition(mX, mY + 28);
                Console.WriteLine(TecnoMPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printLaptops(string[] LaptopCompanies, string[] InfinixL, double[] InfinixLPrices, string[] Dell, double[] dellPrices, string[] HP, double[] HPPrices, string[] iphoneL, double[] iphoneLPrices, int laptopCount, int laptopICount, int laptopDCount, int laptopHCount, int laptopIpCount)
        {
            int mX = 90, mY = 19;
            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopICount; i++)
            {
                Console.WriteLine($"\t \t \t \t{InfinixL[i]}");
                Console.SetCursorPosition(mX, mY);
                Console.WriteLine(InfinixLPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Dell\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopDCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{Dell[i]}");
                Console.SetCursorPosition(mX, mY + 7);
                Console.WriteLine(dellPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t HP\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopHCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{HP[i]}");
                Console.SetCursorPosition(mX + 5, mY + 14);
                Console.WriteLine(HPPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t iPhone\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopIpCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{iphoneL[i]}");
                Console.SetCursorPosition(mX, mY + 21);
                Console.WriteLine(iphoneLPrices[i]);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printSmartWatches(string[] swCompanies, string[] mibro, double[] mibroPrices, string[] kieslect, double[] kieslectPrices, string[] ZERO, double[] zeroPrices, string[] Assortedsw, double[] AssortedswPrices, int swCount, int swMCount, int swKCount, int swZCount, int swACount)
        {
            int lX = 90, lY = 19;
            Console.WriteLine("\t \t \t \t \t \t \t \t Mibro\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swMCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{mibro[i]}");
                Console.SetCursorPosition(lX, lY);
                Console.WriteLine(mibroPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Kieslect\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swKCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{kieslect[i]}");
                Console.SetCursorPosition(lX + 8, lY + 7);
                Console.WriteLine(kieslectPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Zero\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swZCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{ZERO[i]}");
                Console.SetCursorPosition(lX, lY + 14);
                Console.WriteLine(zeroPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swACount; i++)
            {
                Console.WriteLine($"\t \t \t \t{Assortedsw[i]}");
                Console.SetCursorPosition(lX, lY + 21);
                Console.WriteLine(AssortedswPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printEarbuds(string[] EarbudsCompanies, string[] XiaomiE, double[] XiaomiEPrices, string[] Audionic, double[] AudionicPrices, string[] AssortedE, double[] AssortedEPrices, int earbudCount, int earbudXCount, int earbudACount, int earbudAsCount)
        {
            int lX = 82, lY = 19;
            Console.WriteLine("\t \t \t \t \t \t \t \t Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudXCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{XiaomiE[i]}");
                Console.SetCursorPosition(lX, lY);
                Console.WriteLine(XiaomiEPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Audionic\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudACount; i++)
            {
                Console.WriteLine($"\t \t \t \t{Audionic[i]}");
                Console.SetCursorPosition(lX, lY + 7);
                Console.WriteLine(AudionicPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudAsCount; i++)
            {
                Console.WriteLine($"\t \t \t \t{AssortedE[i]}");
                Console.SetCursorPosition(lX, lY + 14);
                Console.WriteLine(AssortedEPrices[i]);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static bool editModelPrice(string[] models, double[] prices, int count, string modelName, double newPrice)
        {
            for (int j = 0; j < count; j++)
            {
                if (models[j] == modelName)
                {
                    prices[j] = newPrice;
                    return true;
                }
            }
            return false;
        }
        static bool deleteModel(ref string[] models, ref double[] prices, ref int count, ref string modelName)
        {
            for (int j = 0; j < count; j++)
            {
                if (models[j] == modelName)
                {
                    for (int k = j; k < count - 1; k++)
                    {
                        models[k] = models[k + 1];
                        prices[k] = prices[k + 1];
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }

        static string editSHDevicePrice(string editshDevice, double editshDevicePrice, string[] shDevices, double[] shDevicesPrices, int shCount)
        {
            for (int i = 0; i < shCount; i++)
            {
                if (editshDevice == shDevices[i])
                {
                    shDevicesPrices[i] = editshDevicePrice;
                    UpdateDeviceData(shDevices, shDevicesPrices, ref shCount, "Shdevices.txt");

                    return "Device Price Update successfully.";
                }
            }

            return "Device not found.";
        }
        static string deleteSHDevice(string deleteshDevice, string[] shDevices, double[] shDevicesPrices, int shCount)
        {
            for (int i = 0; i < shCount; i++)
            {
                if (deleteshDevice == shDevices[i])
                {
                    for (int j = i; j < shCount - 1; j++)
                    {
                        shDevices[j] = shDevices[j + 1];
                        shDevicesPrices[j] = shDevicesPrices[j + 1];
                    }
                    shCount--;
                    UpdateDeviceData(shDevices, shDevicesPrices, ref shCount, "Shdevices.txt");

                    return $"{deleteshDevice} deleted successfully";
                }
            }
            return "Wrong Device Name";
        }

        static bool checkOptionValidation(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static void csph()
        {
            Console.Clear();
            printHeader();
        }
        static void adminMenu(string[] newName, string[] role, int newCount, string[] mobileCompanies, string[] SamsungM, double[] SamsungMPrices, string[] OppoM, double[] oppoMPrices, string[] InfinixM, double[] infinixMPrices, string[] miXiaomiM, double[] miXiaomiMPrices, string[] TecnoM, double[] TecnoMPrices, ref int mobileCount, string[] LaptopCompanies, string[] InfinixL, double[] InfinixLPrices, string[] Dell, double[] dellPrices, string[] HP, double[] HPPrices, string[] iphoneL, double[] iphoneLPrices, int laptopCount, string[] swCompanies, string[] mibro, double[] mibroPrices, string[] kieslect, double[] kieslectPrices, string[] ZERO, double[] zeroPrices, string[] Assortedsw, double[] AssortedswPrices, int swCount, string[] EarbudsCompanies, string[] XiaomiE, double[] XiaomiEPrices, string[] Audionic, double[] AudionicPrices, string[] AssortedE, double[] AssortedEPrices, int earbudCount, ref int mobileSCount, ref int mobileOCount, ref int mobileICount, ref int mobileMCount, ref int mobileTCount, ref int laptopICount, ref int laptopDCount, ref int laptopHCount, ref int laptopIpCount, ref int swMCount, ref int swKCount, ref int swZCount, ref int swACount, ref int earbudXCount, ref int earbudACount, ref int earbudAsCount, string[] shDevices, double[] shDevicesPrices, ref int shCount, ref double budget, ref double tempBudget, string[] feedbacks, ref int feedbackCount)
        {
            int choice = -1;
            while (choice != 0)
            {
                int selectOption = -1, x = 35, y = 18;
                string addMobile, addLaptop, addSW, addEarbud, addMobileModel, addLaptopModel, addSWModel, addEarbudModel, deleteMobile, deleteMobileModel, deleteLaptop, deleteLaptopModel, deleteSw, deleteSwModel, deleteEarbud, deleteEarbudModel, editshDevice, deleteshDevice;
                double addMobilePrices, addLaptopPrice, addSWPrice, addEarbudPrice, editshDevicePrice;
                bool foundMobile = false, foundLaptop = false, foundSW = false, foundEarbud = false;

                csph();
                Console.WriteLine("\t \t \t \t \t \t ADMIN MENU ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Enter 1 to check registered users and admins.");
                Console.WriteLine("Enter 2 to watch devices.");
                Console.WriteLine("Enter 3 to add Device Model.");
                Console.WriteLine("Enter 4 to edit Device Price.");
                Console.WriteLine("Enter 5 to delete Device.");
                Console.WriteLine("Enter 6 to handle second hand devices.");
                Console.WriteLine("Enter 7 to view your sales");
                Console.WriteLine("Enter 8 to see Feedbacks");
                Console.WriteLine("Enter 9 to change Theme ");
                Console.WriteLine("Enter 0 to escape the matrix");

                Console.WriteLine("Enter your choice... ");
                string input;
                input = Console.ReadLine();
                if (checkOptionValidation(input))
                {
                    choice = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(750);
                    continue;
                }
                csph();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t Registered Admins and Customers are: ");
                        Console.WriteLine("\t Username \t \t Status ");
                        Console.WriteLine("--------------------------------------------------------------");

                        for (int i = 0; i < newCount; i++)
                        {
                            Console.Write("\t" + newName[i]);
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(role[i]);
                            y++;
                        }

                        Console.WriteLine("\nPress any key to go back to Menu....");
                        Console.Read();
                        break;

                    case 2:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to watch Mobiles List");
                            Console.WriteLine("Enter 2 to watch Laptops List");
                            Console.WriteLine("Enter 3 to watch Smart Watches List");
                            Console.WriteLine("Enter 4 to watch Wireless Earbuds List");
                            Console.WriteLine("Enter 0 to go back to admin menu\n");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(800);
                                csph();
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Mobiles with their prices.\n");
                                printMobiles(mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Laptops with their prices.\n");
                                printLaptops(LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Smart Watches with their prices.\n");
                                printSmartWatches(swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Earbuds with their prices.\n");
                                printEarbuds(EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Thread.Sleep(800);
                                csph();
                                Console.WriteLine("\n /!\\ Write valid option please.\n\n\n");
                            }
                        } while (selectOption != 0);

                        break;

                    case 3:
                        do
                        {
                            csph();
                            Console.WriteLine("\n\nEnter 1 to add new Mobile Model");
                            Console.WriteLine("Enter 2 to add new Laptops Model");
                            Console.WriteLine("Enter 3 to add new Smart Watches Model");
                            Console.WriteLine("Enter 4 to add new Wireless Earbuds Model");
                            Console.WriteLine("Enter 0 to go back to admin menu\n");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(800);
                                csph();
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(addMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addMobileModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addMobileModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addMobilePrices = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addMobile)
                                {
                                    case "SAMSUNG":
                                        addDeviceData(addMobileModel, addMobilePrices, SamsungM, SamsungMPrices, ref mobileSCount, "Samsung.txt");
                                        Console.WriteLine("Mobile model added successfully to Samsung.");
                                        break;
                                    case "OPPO":
                                        addDeviceData(addMobileModel, addMobilePrices, OppoM, oppoMPrices, ref mobileOCount, "Oppo.txt");
                                        Console.WriteLine("Mobile model added successfully to Oppo.");
                                        break;
                                    case "INFINIX":
                                        addDeviceData(addMobileModel, addMobilePrices, InfinixM, infinixMPrices, ref mobileICount, "InfinixM.txt");
                                        Console.WriteLine("Mobile model added successfully to Infinix.");
                                        break;
                                    case "MI XIAOMI":
                                        addDeviceData(addMobileModel, addMobilePrices, miXiaomiM, miXiaomiMPrices, ref mobileMCount, "MiM.txt");
                                        Console.WriteLine("Mobile model added successfully to MI Xiaomi.");
                                        break;
                                    case "TECNO":
                                        addDeviceData(addMobileModel, addMobilePrices, TecnoM, TecnoMPrices, ref mobileTCount, "Tecno.txt");
                                        Console.WriteLine("Mobile model added successfully to Tecno.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(addLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addLaptopModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addLaptopModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addLaptopPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addLaptop)
                                {
                                    case "INFINIX":
                                        addDeviceData(addLaptopModel, addLaptopPrice, InfinixL, InfinixLPrices, ref laptopICount, "InfinixL.txt");
                                        Console.WriteLine("Laptop model added successfully to Infinix.");
                                        break;
                                    case "DELL":
                                        addDeviceData(addLaptopModel, addLaptopPrice, Dell, dellPrices, ref laptopDCount, "Dell.txt");
                                        Console.WriteLine("Laptop model added successfully to Dell.");
                                        break;
                                    case "HP":
                                        addDeviceData(addLaptopModel, addLaptopPrice, HP, HPPrices, ref laptopHCount, "Hp.txt");
                                        Console.WriteLine("Laptop model added successfully to HP.");
                                        break;
                                    case "IPHONE":
                                        addDeviceData(addLaptopModel, addLaptopPrice, iphoneL, iphoneLPrices, ref laptopIpCount, "Iphone.txt");
                                        Console.WriteLine("Laptop model added successfully to iPhone.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addSW = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(addSW))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addSWModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addSWModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addSWPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addSW)
                                {
                                    case "MIBRO":
                                        addDeviceData(addSWModel, addSWPrice, mibro, mibroPrices, ref swMCount, "Mibro.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Mibro.");
                                        break;
                                    case "KIESLECT":
                                        addDeviceData(addSWModel, addSWPrice, kieslect, kieslectPrices, ref swKCount, "Kieslect.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Kieslect.");
                                        break;
                                    case "ZERO":
                                        addDeviceData(addSWModel, addSWPrice, ZERO, zeroPrices, ref swZCount, "Zero.txt");
                                        Console.WriteLine("Smart Watch model added successfully to ZERO.");
                                        break;
                                    case "ASSORTED":
                                        addDeviceData(addSWModel, addSWPrice, Assortedsw, AssortedswPrices, ref swACount, "AssortedS.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Assorted.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(addEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addEarbudModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addEarbudModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addEarbudPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addEarbud)
                                {
                                    case "XIAOMI":
                                        addDeviceData(addEarbudModel, addEarbudPrice, XiaomiE, XiaomiEPrices, ref earbudXCount, "MiE.txt");
                                        Console.WriteLine("Earbud model added successfully to Xiaomi.");
                                        break;
                                    case "AUDIONIC":
                                        addDeviceData(addEarbudModel, addEarbudPrice, Audionic, AudionicPrices, ref earbudACount, "Audionic.txt");
                                        Console.WriteLine("Earbud model added successfully to Audionic.");
                                        break;
                                    case "ASSORTED":
                                        addDeviceData(addEarbudModel, addEarbudPrice, AssortedE, AssortedEPrices, ref earbudAsCount, "AssortedE.txt");
                                        Console.WriteLine("Earbud model added successfully to Assorted.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Write valid option.");
                            }
                        } while (selectOption != 0);
                        break;

                    case 4:

                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to edit Mobile Price");
                            Console.WriteLine("Enter 2 to edit Laptop Price");
                            Console.WriteLine("Enter 3 to edit Smart Watch Price");
                            Console.WriteLine("Enter 4 to edit Earbuds Price");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Choose the option: ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(750);
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                printMobiles(mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                                Console.ReadLine(); // Ignore newline
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the mobile price: ");
                                    addMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(addMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addMobileModel = Console.ReadLine().ToUpper();
                                    if (addMobile == "SAMSUNG" && checkModel(SamsungM, addMobileModel, mobileSCount))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "OPPO" && checkModel(OppoM, addMobileModel, mobileOCount))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "INFINIX" && checkModel(InfinixM, addMobileModel, mobileICount))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "MI XIAOMI" && checkModel(miXiaomiM, addMobileModel, mobileMCount))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "TECNO" && checkModel(TecnoM, addMobileModel, mobileTCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addMobilePrices = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addMobile == "SAMSUNG")
                                {
                                    foundMobile = editModelPrice(SamsungM, SamsungMPrices, mobileSCount, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(SamsungM, SamsungMPrices, ref mobileSCount, "Samsung.txt");
                                }
                                else if (addMobile == "OPPO")
                                {
                                    foundMobile = editModelPrice(OppoM, oppoMPrices, mobileOCount, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(OppoM, oppoMPrices, ref mobileOCount, "Oppo.txt");
                                }
                                else if (addMobile == "INFINIX")
                                {
                                    foundMobile = editModelPrice(InfinixM, infinixMPrices, mobileICount, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(InfinixM, infinixMPrices, ref mobileICount, "InfinixM.txt");
                                }
                                else if (addMobile == "MI XIAOMI")
                                {
                                    foundMobile = editModelPrice(miXiaomiM, miXiaomiMPrices, mobileMCount, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(miXiaomiM, miXiaomiMPrices, ref mobileMCount, "MiM.txt");
                                }
                                else if (addMobile == "TECNO")
                                {
                                    foundMobile = editModelPrice(TecnoM, TecnoMPrices, mobileTCount, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(TecnoM, TecnoMPrices, ref mobileTCount, "Tecno.txt");
                                }

                                if (foundMobile)
                                {
                                    Console.WriteLine("Mobile price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                printLaptops(LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the Laptop price: ");
                                    addLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(addLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addLaptopModel = Console.ReadLine().ToUpper();
                                    if (addLaptop == "INFINIX" && checkModel(InfinixL, addLaptopModel, laptopICount))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "DELL" && checkModel(Dell, addLaptopModel, laptopDCount))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "HP" && checkModel(HP, addLaptopModel, laptopHCount))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "IPHONE" && checkModel(iphoneL, addLaptopModel, laptopIpCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addLaptopPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addLaptop == "INFINIX")
                                {
                                    foundLaptop = editModelPrice(InfinixL, InfinixLPrices, laptopICount, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(InfinixL, InfinixLPrices, ref laptopICount, "InfinixL.txt");
                                }
                                else if (addLaptop == "DELL")
                                {
                                    foundLaptop = editModelPrice(Dell, dellPrices, laptopDCount, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(Dell, dellPrices, ref laptopDCount, "Dell.txt");
                                }
                                else if (addLaptop == "HP")
                                {
                                    foundLaptop = editModelPrice(HP, HPPrices, laptopHCount, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(HP, HPPrices, ref laptopHCount, "Hp.txt");
                                }
                                else if (addLaptop == "IPHONE")
                                {
                                    foundLaptop = editModelPrice(iphoneL, iphoneLPrices, laptopIpCount, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(iphoneL, iphoneLPrices, ref laptopIpCount, "Iphone.txt");
                                }

                                if (foundLaptop)
                                {
                                    Console.WriteLine("Laptop price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                printSmartWatches(swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);
                                Console.ReadLine(); // Ignore newline
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the smart watch price: ");
                                    addSW = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(addSW))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addSWModel = Console.ReadLine().ToUpper();
                                    if (addSW == "MIBRO" && checkModel(mibro, addSWModel, swMCount))
                                    {
                                        break;
                                    }
                                    else if (addSW == "KIESLECT" && checkModel(kieslect, addSWModel, swKCount))
                                    {
                                        break;
                                    }
                                    else if (addSW == "ZERO" && checkModel(ZERO, addSWModel, swZCount))
                                    {
                                        break;
                                    }
                                    else if (addSW == "ASSORTED" && checkModel(Assortedsw, addSWModel, swACount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addSWPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addSW == "MIBRO")
                                {
                                    foundSW = editModelPrice(mibro, mibroPrices, swMCount, addSWModel, addSWPrice);
                                    UpdateDeviceData(mibro, mibroPrices, ref swMCount, "Mibro.txt");
                                }
                                else if (addSW == "KIESLECT")
                                {
                                    foundSW = editModelPrice(kieslect, kieslectPrices, swKCount, addSWModel, addSWPrice);
                                    UpdateDeviceData(kieslect, kieslectPrices, ref swKCount, "Kieslect.txt");
                                }
                                else if (addSW == "ZERO")
                                {
                                    foundSW = editModelPrice(ZERO, zeroPrices, swZCount, addSWModel, addSWPrice);
                                    UpdateDeviceData(ZERO, zeroPrices, ref swZCount, "Zero.txt");
                                }
                                else if (addSW == "ASSORTED")
                                {
                                    foundSW = editModelPrice(Assortedsw, AssortedswPrices, swACount, addSWModel, addSWPrice);
                                    UpdateDeviceData(Assortedsw, AssortedswPrices, ref swACount, "AssortedS.txt");
                                }

                                if (foundSW)
                                {
                                    Console.WriteLine("Smartwatch price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                printEarbuds(EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the Earbud price: ");
                                    addEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(addEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addEarbudModel = Console.ReadLine().ToUpper();
                                    if (addEarbud == "MI XIAOMI" && checkModel(XiaomiE, addEarbudModel, earbudXCount))
                                    {
                                        break;
                                    }
                                    else if (addEarbud == "AUDIONIC" && checkModel(Audionic, addEarbudModel, earbudACount))
                                    {
                                        break;
                                    }
                                    else if (addEarbud == "ASSORTED" && checkModel(AssortedE, addEarbudModel, earbudAsCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addEarbudPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                if (addEarbud == "XIAOMI")
                                {
                                    foundEarbud = editModelPrice(XiaomiE, XiaomiEPrices, earbudXCount, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(XiaomiE, XiaomiEPrices, ref earbudXCount, "MiE.txt");
                                }
                                else if (addEarbud == "AUDIONIC")
                                {
                                    foundEarbud = editModelPrice(Audionic, AudionicPrices, earbudACount, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(Audionic, AudionicPrices, ref earbudACount, "Audionic.txt");
                                }
                                else if (addEarbud == "ASSORTED")
                                {
                                    foundEarbud = editModelPrice(AssortedE, AssortedEPrices, earbudAsCount, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(AssortedE, AssortedEPrices, ref earbudAsCount, "AssortedE.txt");
                                }
                                if (foundEarbud)
                                {
                                    Console.WriteLine("Earbuds price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Invalid Option");
                            }
                        } while (selectOption != 0);
                        break;

                    case 5:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to Delete Mobile");
                            Console.WriteLine("Enter 2 to Delete Laptops");
                            Console.WriteLine("Enter 3 to Delete Smart Watches");
                            Console.WriteLine("Enter 4 to Delete Wireless Earbuds");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(750);
                                continue;
                            }
                            if (selectOption == 1)
                            {
                                csph();
                                printMobiles(mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                                Console.ReadLine(); // Ignore newline
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Mobile model: ");
                                    deleteMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(deleteMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name which you want to delete: ");
                                    deleteMobileModel = Console.ReadLine().ToUpper();
                                    if (deleteMobile == "SAMSUNG" && checkModel(SamsungM, deleteMobileModel, mobileSCount))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "OPPO" && checkModel(OppoM, deleteMobileModel, mobileOCount))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "INFINIX" && checkModel(InfinixM, deleteMobileModel, mobileICount))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "MI XIAOMI" && checkModel(miXiaomiM, deleteMobileModel, mobileMCount))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "TECNO" && checkModel(TecnoM, deleteMobileModel, mobileTCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteMobile == "SAMSUNG")
                                {
                                    foundMobile = deleteModel(ref SamsungM, ref SamsungMPrices, ref mobileSCount, ref deleteMobileModel);
                                    UpdateDeviceData(SamsungM, SamsungMPrices, ref mobileSCount, "Samsung.txt");
                                }
                                else if (deleteMobile == "OPPO")
                                {
                                    foundMobile = deleteModel(ref OppoM, ref oppoMPrices, ref mobileOCount, ref deleteMobileModel);
                                    UpdateDeviceData(OppoM, oppoMPrices, ref mobileOCount, "Oppo.txt");
                                }
                                else if (deleteMobile == "INFINIX")
                                {
                                    foundMobile = deleteModel(ref InfinixM, ref infinixMPrices, ref mobileICount, ref deleteMobileModel);
                                    UpdateDeviceData(InfinixM, infinixMPrices, ref mobileICount, "InfinixM.txt");
                                }
                                else if (deleteMobile == "MI XIAOMI")
                                {
                                    foundMobile = deleteModel(ref miXiaomiM, ref miXiaomiMPrices, ref mobileMCount, ref deleteMobileModel);
                                    UpdateDeviceData(miXiaomiM, miXiaomiMPrices, ref mobileMCount, "MiM.txt");
                                }
                                else if (deleteMobile == "TECNO")
                                {
                                    foundMobile = deleteModel(ref TecnoM, ref TecnoMPrices, ref mobileTCount, ref deleteMobileModel);
                                    UpdateDeviceData(TecnoM, TecnoMPrices, ref mobileTCount, "Tecno.txt");
                                }

                                if (foundMobile)
                                {
                                    Console.WriteLine("Mobile model deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                printLaptops(LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Laptop model: ");
                                    deleteLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(deleteLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name you want to delete: ");
                                    deleteLaptopModel = Console.ReadLine().ToUpper();
                                    if (deleteLaptop == "INFINIX" && checkModel(InfinixL, deleteLaptopModel, laptopICount))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "DELL" && checkModel(Dell, deleteLaptopModel, laptopDCount))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "HP" && checkModel(HP, deleteLaptopModel, laptopHCount))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "IPHONE" && checkModel(iphoneL, deleteLaptopModel, laptopIpCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteLaptop == "INFINIX")
                                {
                                    foundLaptop = deleteModel(ref InfinixL, ref InfinixLPrices, ref laptopICount, ref deleteLaptopModel);
                                    UpdateDeviceData(InfinixL, InfinixLPrices, ref laptopICount, "InfinixL.txt");
                                }
                                else if (deleteLaptop == "DELL")
                                {
                                    foundLaptop = deleteModel(ref Dell, ref dellPrices, ref laptopDCount, ref deleteLaptopModel);
                                    UpdateDeviceData(Dell, dellPrices, ref laptopDCount, "Dell.txt");
                                }
                                else if (deleteLaptop == "HP")
                                {
                                    foundLaptop = deleteModel(ref HP, ref HPPrices, ref laptopHCount, ref deleteLaptopModel);
                                    UpdateDeviceData(HP, HPPrices, ref laptopHCount, "Hp.txt");
                                }
                                else if (deleteLaptop == "IPHONE")
                                {
                                    foundLaptop = deleteModel(ref iphoneL, ref iphoneLPrices, ref laptopICount, ref deleteLaptopModel);
                                    UpdateDeviceData(iphoneL, iphoneLPrices, ref laptopIpCount, "Iphone.txt");
                                }

                                if (foundLaptop)
                                {
                                    Console.WriteLine("Laptop model deleted successfully.");
                                }

                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                printSmartWatches(swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Smart Watch model: ");
                                    deleteSw = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(deleteSw))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name you want to delete: ");
                                    deleteSwModel = Console.ReadLine().ToUpper();
                                    if (deleteSw == "MIBRO" && checkModel(mibro, deleteSwModel, swMCount))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "KIESLECT" && checkModel(kieslect, deleteSwModel, swKCount))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "ZERO" && checkModel(ZERO, deleteSwModel, swZCount))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "ASSORTED" && checkModel(Assortedsw, deleteSwModel, swACount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteSw == "MIBRO")
                                {
                                    foundSW = deleteModel(ref mibro, ref mibroPrices, ref swMCount, ref deleteSwModel);
                                    UpdateDeviceData(mibro, mibroPrices, ref swMCount, "Mibro.txt");
                                }
                                else if (deleteSw == "KIESLECT")
                                {
                                    foundSW = deleteModel(ref kieslect, ref kieslectPrices, ref swKCount, ref deleteSwModel);
                                    UpdateDeviceData(kieslect, kieslectPrices, ref swKCount, "Kieslect.txt");
                                }
                                else if (deleteSw == "ZERO")
                                {
                                    foundSW = deleteModel(ref ZERO, ref zeroPrices, ref swZCount, ref deleteSwModel);
                                    UpdateDeviceData(ZERO, zeroPrices, ref swZCount, "Zero.txt");
                                }
                                else if (deleteSw == "ASSORTED")
                                {
                                    foundSW = deleteModel(ref Assortedsw, ref AssortedswPrices, ref swACount, ref deleteSwModel);
                                    UpdateDeviceData(Assortedsw, AssortedswPrices, ref swACount, "AssortedS.txt");
                                }
                                if (foundSW)
                                {
                                    Console.WriteLine("Smart Watch deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                printEarbuds(EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete an Earbud model: ");
                                    deleteEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(deleteEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    deleteEarbudModel = Console.ReadLine().ToUpper();
                                    if (deleteEarbud == "MI XIAOMI" && checkModel(XiaomiE, deleteEarbudModel, earbudXCount))
                                    {
                                        break;
                                    }
                                    else if (deleteEarbud == "AUDIONIC" && checkModel(Audionic, deleteEarbudModel, earbudACount))
                                    {
                                        break;
                                    }
                                    else if (deleteEarbud == "ASSORTED" && checkModel(AssortedE, deleteEarbudModel, earbudAsCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteEarbud == "Xiaomi")
                                {
                                    foundEarbud = deleteModel(ref XiaomiE, ref XiaomiEPrices, ref earbudXCount, ref deleteEarbudModel);
                                    UpdateDeviceData(XiaomiE, XiaomiEPrices, ref earbudXCount, "MiE.txt");
                                }
                                else if (deleteEarbud == "Audionic")
                                {
                                    foundEarbud = deleteModel(ref Audionic, ref AudionicPrices, ref earbudACount, ref deleteEarbudModel);
                                    UpdateDeviceData(Audionic, AudionicPrices, ref earbudACount, "Audionic.txt");
                                }
                                else if (deleteEarbud == "Assorted")
                                {
                                    foundEarbud = deleteModel(ref AssortedE, ref AssortedEPrices, ref earbudAsCount, ref deleteEarbudModel);
                                    UpdateDeviceData(AssortedE, AssortedEPrices, ref earbudAsCount, "AssortedE.txt");
                                }
                                if (foundEarbud)
                                {
                                    Console.WriteLine("Earbuds deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Invalid Option");
                            }
                        } while (selectOption != 0);
                        break;

                    case 6:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to watch Second Hand Devices ");
                            Console.WriteLine("Enter 2 to add Second Hand Devices ");
                            Console.WriteLine("Enter 3 to edit Second Hand Device Price");
                            Console.WriteLine("Enter 4 to delete Second Hand Device");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Choose an option...");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Write valid Input");
                                Thread.Sleep(750);
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                displaySHDevices(shDevices, shDevicesPrices, shCount);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.Write("Enter the name of device (with model and company) to add: ");
                                Console.ReadLine(); // Ignore newline
                                shDevices[shCount] = Console.ReadLine().ToUpper();
                                while (true)
                                {
                                    Console.Write("Enter the price for this device: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        shDevicesPrices[shCount] = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                Console.WriteLine($"\n{shDevices[shCount]} of price {shDevicesPrices[shCount]} has been added.");
                                shCount++;
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                Console.ReadLine(); // Ignore newline
                                while (true)
                                {
                                    Console.Write("Enter the name of device (with model and company) of which you want to change price: ");
                                    editshDevice = Console.ReadLine().ToUpper();
                                    if (checkModel(shDevices, editshDevice, shCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write($"Enter the new price for {editshDevice}: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        editshDevicePrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                Console.WriteLine(editSHDevicePrice(editshDevice, editshDevicePrice, shDevices, shDevicesPrices, shCount));
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                while (true)
                                {
                                    Console.Write("Enter the name of device (with model and company) to delete: ");
                                    deleteshDevice = Console.ReadLine().ToUpper();
                                    if (checkModel(shDevices, deleteshDevice, shCount))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                Console.WriteLine(deleteSHDevice(deleteshDevice, shDevices, shDevicesPrices, shCount));
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Enter valid option.");
                            }
                        } while (selectOption != 0);
                        break;
                    case 7:
                        Console.WriteLine("Your Sales: " + tempBudget);
                        Console.WriteLine("\nPress any key to go back to Menu.... ");
                        Console.ReadKey();
                        break;
                    case 8:
                        if (feedbackCount == 0)
                        {
                            Console.SetCursorPosition(35, 12);
                            Console.WriteLine("No Feedbacks Till Now.");
                        }
                        else
                        {
                            Console.WriteLine("                                       FEEDBACKS              ");
                            Console.WriteLine("=======================================================================================================");
                            Console.WriteLine();

                            for (int i = 0; i < feedbackCount; i++)
                            {
                                Console.WriteLine(feedbacks[i]);
                            }
                        }
                        Console.WriteLine("\nPress any key to go back to Menu.... ");
                        Console.ReadKey();
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Thread.Sleep(800);
                        break;
                }
            }
        }

        static void printMobileswithinbudget(double budget, string[] mobileCompanies, string[] SamsungM, double[] SamsungMPrices, string[] OppoM, double[] oppoMPrices, string[] InfinixM, double[] infinixMPrices, string[] miXiaomiM, double[] miXiaomiMPrices, string[] TecnoM, double[] TecnoMPrices, int mobileCount, int mobileSCount, int mobileOCount, int mobileICount, int mobileMCount, int mobileTCount)
        {
            int mX = 81, mY = 19;

            Console.WriteLine("\t \t \t \t \t \t \t \t Samsung\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileSCount; i++)
            {
                if (SamsungMPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + SamsungM[i]);
                    Console.SetCursorPosition(mX, mY);
                    Console.WriteLine(SamsungMPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Oppo\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileOCount; i++)
            {
                if (oppoMPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + OppoM[i]);
                    Console.SetCursorPosition(mX, mY + 7);
                    Console.WriteLine(oppoMPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileICount; i++)
            {
                if (infinixMPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + InfinixM[i]);
                    Console.SetCursorPosition(mX, mY + 14);
                    Console.WriteLine(infinixMPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t MI Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileMCount; i++)
            {
                if (miXiaomiMPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + miXiaomiM[i]);
                    Console.SetCursorPosition(mX, mY + 21);
                    Console.WriteLine(miXiaomiMPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Tecno\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mobileTCount; i++)
            {
                if (TecnoMPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + TecnoM[i]);
                    Console.SetCursorPosition(mX, mY + 28);
                    Console.WriteLine(TecnoMPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }

        static void printLaptopswithinbudget(double budget, string[] LaptopCompanies, string[] InfinixL, double[] InfinixLPrices, string[] Dell, double[] dellPrices, string[] HP, double[] HPPrices, string[] iphoneL, double[] iphoneLPrices, int laptopCount, int laptopICount, int laptopDCount, int laptopHCount, int laptopIpCount)
        {
            int mX = 90, mY = 19;

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopICount; i++)
            {
                if (InfinixLPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + InfinixL[i]);
                    Console.SetCursorPosition(mX, mY);
                    Console.WriteLine(InfinixLPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t  Dell\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopDCount; i++)
            {
                if (dellPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + Dell[i]);
                    Console.SetCursorPosition(mX, mY + 7);
                    Console.WriteLine(dellPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t HP\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopHCount; i++)
            {
                if (HPPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + HP[i]);
                    Console.SetCursorPosition(mX + 5, mY + 14);
                    Console.WriteLine(HPPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t iPhone\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < laptopIpCount; i++)
            {
                if (iphoneLPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + iphoneL[i]);
                    Console.SetCursorPosition(mX, mY + 21);
                    Console.WriteLine(iphoneLPrices[i]);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printSmartWatcheswithinbudget(double budget, string[] swCompanies, string[] mibro, double[] mibroPrices, string[] kieslect, double[] kieslectPrices, string[] ZERO, double[] zeroPrices, string[] Assortedsw, double[] AssortedswPrices, int swCount, int swMCount, int swKCount, int swZCount, int swACount)
        {
            int lX = 90, lY = 19;

            Console.WriteLine("\t \t \t \t \t \t \t \t Mibro\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swMCount; i++)
            {
                if (mibroPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + mibro[i]);
                    Console.SetCursorPosition(lX, lY);
                    Console.WriteLine(mibroPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Kieslect\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swKCount; i++)
            {
                if (kieslectPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + kieslect[i]);
                    Console.SetCursorPosition(lX + 8, lY + 7);
                    Console.WriteLine(kieslectPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Zero\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swZCount; i++)
            {
                if (zeroPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + ZERO[i]);
                    Console.SetCursorPosition(lX, lY + 14);
                    Console.WriteLine(zeroPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < swACount; i++)
            {
                if (AssortedswPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + Assortedsw[i]);
                    Console.SetCursorPosition(lX, lY + 21);
                    Console.WriteLine(AssortedswPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printEarbudswithinbudget(double budget, string[] EarbudsCompanies, string[] XiaomiE, double[] XiaomiEPrices, string[] Audionic, double[] AudionicPrices, string[] AssortedE, double[] AssortedEPrices, int earbudCount, int earbudXCount, int earbudACount, int earbudAsCount)
        {
            int lX = 82, lY = 19;

            Console.WriteLine("\t \t \t \t \t \t \t \t Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudXCount; i++)
            {
                if (XiaomiEPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + XiaomiE[i]);
                    Console.SetCursorPosition(lX, lY);
                    Console.WriteLine(XiaomiEPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Audionic\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudACount; i++)
            {
                if (AudionicPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + Audionic[i]);
                    Console.SetCursorPosition(lX, lY + 7);
                    Console.WriteLine(AudionicPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < earbudAsCount; i++)
            {
                if (AssortedEPrices[i] <= budget)
                {
                    Console.Write("\t \t \t \t" + AssortedE[i]);
                    Console.SetCursorPosition(lX, lY + 14);
                    Console.WriteLine(AssortedEPrices[i]);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void displaySHDevices(string[] shDevices, double[] shDevicesPrices, int shCount)
        {
            int x = 56, y = 15;
            Console.WriteLine("\t \t \t SECOND HAND DEVICES \n");
            Console.WriteLine("---------------------------------------------------------------------------");

            for (int i = 0; i < shCount; i++)
            {
                Console.Write(shDevices[i]);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(shDevicesPrices[i]);
                y++;
            }
        }
        static bool ModelExisted(string buyDevice, string buyModel, string[] SamsungM, string[] OppoM, string[] InfinixM, string[] miXiaomiM, string[] TecnoM, string[] InfinixL, string[] Dell, string[] HP, string[] iphoneL, string[] mibro, string[] kieslect, string[] ZERO, string[] Assortedsw, string[] XiaomiE, string[] Audionic, string[] AssortedE)
        {
            if (buyDevice == "MOBILE")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == SamsungM[i] || buyModel == OppoM[i] || buyModel == InfinixM[i] || buyModel == miXiaomiM[i] || buyModel == TecnoM[i])
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "LAPTOP")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == InfinixL[i] || buyModel == Dell[i] || buyModel == HP[i] || buyModel == iphoneL[i])
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "SMART WATCH")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == mibro[i] || buyModel == kieslect[i] || buyModel == ZERO[i] || buyModel == Assortedsw[i])
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "EARBUDS")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == XiaomiE[i] || buyModel == Audionic[i] || buyModel == AssortedE[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static double getDevicePrice(string buyModel, string[] models, double[] prices, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (models[i] == buyModel)
                {
                    return prices[i];
                }
            }
            return 0.0;
        }

        static double getSHDevicePrice(string buySHDevice, string[] shDevices, double[] shDevicesPrices, int shCount)
        {
            for (int i = 0; i < shCount; i++)
            {
                if (buySHDevice == shDevices[i])
                {
                    return shDevicesPrices[i];
                }
            }
            return 0;
        }
        static bool CheckAccount(string aNo, string[] accountNo, int accountCount)
        {
            for (int i = 0; i < aNo.Length; i++)
            {
                if (aNo[i] != accountNo[accountCount][i])
                {
                    return false;
                }
            }
            return true;
        }
        static void customerMenu(string[] mobileCompanies, string[] SamsungM, double[] SamsungMPrices, string[] OppoM, double[] oppoMPrices,
        string[] InfinixM, double[] infinixMPrices, string[] miXiaomiM, double[] miXiaomiMPrices, string[] TecnoM, double[] TecnoMPrices,
        int mobileCount, string[] LaptopCompanies, string[] InfinixL, double[] InfinixLPrices, string[] Dell, double[] dellPrices,
        string[] HP, double[] HPPrices, string[] iphoneL, double[] iphoneLPrices, int laptopCount, string[] swCompanies, string[] mibro,
        double[] mibroPrices, string[] kieslect, double[] kieslectPrices, string[] ZERO, double[] zeroPrices, string[] Assortedsw,
        double[] AssortedswPrices, int swCount, string[] EarbudsCompanies, string[] XiaomiE, double[] XiaomiEPrices, string[] Audionic,
        double[] AudionicPrices, string[] AssortedE, double[] AssortedEPrices, int earbudCount, ref int mobileSCount, ref int mobileOCount,
        ref int mobileICount, ref int mobileMCount, ref int mobileTCount, ref int laptopICount, ref int laptopDCount, ref int laptopHCount,
        ref int laptopIpCount, ref int swMCount, ref int swKCount, ref int swZCount, ref int swACount, ref int earbudXCount, ref int earbudACount,
        ref int earbudAsCount, string[] shDevices, double[] shDevicesPrices, int shCount, double budget, ref double tempBudget,
        string[] accountNo, int accountCount, string[] feedbacks, ref int feedbackCount)
        {
            int choice = 1;
            string buyDevice, showDevice, buyModel, feedback, buySHDevice, aNo;
            double shPrice;
            while (choice != 0)
            {
                Console.Clear();
                printHeader();
                Console.WriteLine("\t \t \t \t \t \t CUSTOMER MENU \n");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Enter 1 to Watch the Device you want (Mobile / Laptop / Smart Watch/ Earbuds)");
                Console.WriteLine("Enter 2 to Add money in your account");
                Console.WriteLine("Enter 3 to Watch the Device (Mobile / Laptop / Smart Watch/ Earbuds) within your budget");
                Console.WriteLine("Enter 4 to Watch Second Hand Devices");
                Console.WriteLine("Enter 5 to Select the Device you Wanna Buy ");
                Console.WriteLine("Enter 6 to Select the Second Hand Device you Want to Buy ");
                Console.WriteLine("Enter 7 to see your bill and remaining amount.");
                Console.WriteLine("Enter 8 to give your feedback");
                Console.WriteLine("Enter 0 to escape the matrix\n");

                Console.Write("Enter your choice... ");
                string input = Console.ReadLine();

                if (checkOptionValidation(input))
                {
                    choice = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(750);
                    continue;
                }

                Console.Clear();
                printHeader();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t CUSTOMER MENU ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------\n\n\n");

                        Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch/ Earbuds) you want to view: ");
                        showDevice = Console.ReadLine().ToUpper();

                        if (showDevice == "MOBILE")
                        {
                            printMobiles(mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                        }
                        else if (showDevice == "LAPTOP")
                        {
                            printLaptops(LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);
                        }
                        else if (showDevice == "SMART WATCH")
                        {
                            printSmartWatches(swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);
                        }
                        else if (showDevice == "EARBUDS")
                        {
                            printEarbuds(EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Device Name.");
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Enter your Account Number: ");
                            aNo = Console.ReadLine();
                            if (CheckAccount(aNo, accountNo, accountCount) && aNo.Length == 13)
                            {
                                while (true)
                                {
                                    Console.WriteLine("Enter the amount of money you want to add: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        budget = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n\n");
                                    }
                                }
                                tempBudget = budget;
                                Console.WriteLine($"\n\nYour amount of {budget} has been updated.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong Account Number.");
                            }
                        }
                        break;

                    case 3:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch / Earbuds) you want to see under " + budget + ": ");
                            buyDevice = Console.ReadLine().ToUpper();

                            if (buyDevice == "MOBILE")
                            {
                                Console.WriteLine();
                                printMobileswithinbudget(budget, mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                            }
                            else if (buyDevice == "LAPTOP")
                            {
                                Console.WriteLine();
                                printLaptopswithinbudget(budget, LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);
                            }
                            else if (buyDevice == "SMART WATCH")
                            {
                                Console.WriteLine();
                                printSmartWatcheswithinbudget(budget, swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);
                            }
                            else if (buyDevice == "EARBUDS")
                            {
                                Console.WriteLine();
                                printEarbudswithinbudget(budget, EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);
                            }
                            else
                            {
                                Console.WriteLine("Wrong device Name.");
                            }
                        }
                        break;


                    case 4:
                        displaySHDevices(shDevices, shDevicesPrices, shCount);
                        break;

                    case 5:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch/ Earbuds) you want to buy: ");
                            buyDevice = Console.ReadLine().ToUpper();

                            if (buyDevice == "MOBILE" || buyDevice == "MOBILES")
                            {
                                Console.WriteLine();
                                printMobileswithinbudget(budget, mobileCompanies, SamsungM, SamsungMPrices, OppoM, oppoMPrices, InfinixM, infinixMPrices, miXiaomiM, miXiaomiMPrices, TecnoM, TecnoMPrices, mobileCount, mobileSCount, mobileOCount, mobileICount, mobileMCount, mobileTCount);
                            }
                            else if (buyDevice == "LAPTOP" || buyDevice == "LAPTOPS")
                            {
                                Console.WriteLine();
                                printLaptopswithinbudget(budget, LaptopCompanies, InfinixL, InfinixLPrices, Dell, dellPrices, HP, HPPrices, iphoneL, iphoneLPrices, laptopCount, laptopICount, laptopDCount, laptopHCount, laptopIpCount);
                            }
                            else if (buyDevice == "SMART WATCH" || buyDevice == "SMARTWATCH")
                            {
                                Console.WriteLine();
                                printSmartWatcheswithinbudget(budget, swCompanies, mibro, mibroPrices, kieslect, kieslectPrices, ZERO, zeroPrices, Assortedsw, AssortedswPrices, swCount, swMCount, swKCount, swZCount, swACount);
                            }
                            else if (buyDevice == "EARBUDS" || buyDevice == "EARBUD")
                            {
                                Console.WriteLine();
                                printEarbudswithinbudget(budget, EarbudsCompanies, XiaomiE, XiaomiEPrices, Audionic, AudionicPrices, AssortedE, AssortedEPrices, earbudCount, earbudXCount, earbudACount, earbudAsCount);
                            }
                            else
                            {
                                Console.WriteLine("This device ain't available.");
                            }

                            Console.WriteLine();
                            Console.WriteLine("If no device available Enter 'Return' to go back.");

                            while (true)
                            {
                                Console.WriteLine("Enter the name of model: ");
                                buyModel = Console.ReadLine().ToUpper();

                                if (ModelExisted(buyDevice, buyModel, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM, InfinixL, Dell, HP, iphoneL, mibro, kieslect, ZERO, Assortedsw, XiaomiE, Audionic, AssortedE))
                                {
                                    double devicePrice = 0.0;
                                    if (buyDevice == "MOBILE")
                                    {
                                        devicePrice = getDevicePrice(buyModel, SamsungM, SamsungMPrices, mobileSCount) +
                                                      getDevicePrice(buyModel, OppoM, oppoMPrices, mobileOCount) +
                                                      getDevicePrice(buyModel, InfinixM, infinixMPrices, mobileICount) +
                                                      getDevicePrice(buyModel, miXiaomiM, miXiaomiMPrices, mobileMCount) +
                                                      getDevicePrice(buyModel, TecnoM, TecnoMPrices, mobileTCount);
                                    }
                                    else if (buyDevice == "LAPTOP")
                                    {
                                        devicePrice = getDevicePrice(buyModel, InfinixL, InfinixLPrices, laptopICount) +
                                                      getDevicePrice(buyModel, Dell, dellPrices, laptopDCount) +
                                                      getDevicePrice(buyModel, HP, HPPrices, laptopHCount) +
                                                      getDevicePrice(buyModel, iphoneL, iphoneLPrices, laptopIpCount);
                                    }
                                    else if (buyDevice == "SMART WATCH")
                                    {
                                        devicePrice = getDevicePrice(buyModel, mibro, mibroPrices, swMCount) +
                                                      getDevicePrice(buyModel, kieslect, kieslectPrices, swKCount) +
                                                      getDevicePrice(buyModel, ZERO, zeroPrices, swZCount) +
                                                      getDevicePrice(buyModel, Assortedsw, AssortedswPrices, swACount);
                                    }
                                    else if (buyDevice == "EARBUDS")
                                    {
                                        devicePrice = getDevicePrice(buyModel, XiaomiE, XiaomiEPrices, earbudXCount) +
                                                      getDevicePrice(buyModel, Audionic, AudionicPrices, earbudACount) +
                                                      getDevicePrice(buyModel, AssortedE, AssortedEPrices, earbudAsCount);
                                    }
                                    if (devicePrice > 0 && devicePrice <= budget)
                                    {
                                        Console.WriteLine("The selected device " + buyDevice + " (" + buyModel + ") is within your budget and is bought successfully.");
                                        Console.WriteLine("Price: " + devicePrice);
                                        budget -= devicePrice;
                                        break;
                                    }
                                    else if (devicePrice > budget)
                                    {
                                        Console.WriteLine("The selected device " + buyDevice + " (" + buyModel + ")  is out of your budget.");
                                        break;
                                    }
                                }
                                else if (buyModel == "RETURN")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Model Name");
                                }
                            }
                        }
                        break;

                    case 6:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            displaySHDevices(shDevices, shDevicesPrices, shCount);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Enter the name of device you want to buy: ");
                            buySHDevice = Console.ReadLine().ToUpper();
                            shPrice = getSHDevicePrice(buySHDevice, shDevices, shDevicesPrices, shCount);

                            if (shPrice > 0 && shPrice <= budget)
                            {
                                Console.WriteLine("The selected device " + buySHDevice + " is within your budget and is bought successfully.");
                                Console.WriteLine("Price: " + shPrice);
                                budget -= shPrice;
                            }
                            else if (shPrice > budget)
                            {
                                Console.WriteLine("The selected device " + buySHDevice + " is out of your budget.");
                            }
                            else if (shPrice == 0)
                            {
                                Console.WriteLine("Invalid selection. Please check your input.");
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine(" \t \t \t BILL");
                        Console.WriteLine("-------------------------------------------------------------------------\n");
                        Console.WriteLine($"Your Initial Amount: ${tempBudget}");
                        if (true)
                        {
                            tempBudget = tempBudget - budget;
                        }
                        Console.WriteLine($"Your Paid Amount: ${tempBudget}");
                        Console.WriteLine($"Your Remaining Amount: ${budget}");
                        break;

                    case 8:
                        Console.WriteLine();
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Enter your feedback: ");
                            feedbacks[feedbackCount] = Console.ReadLine();
                            if (string.IsNullOrEmpty(feedbacks[feedbackCount]))
                            {
                                Console.WriteLine("Feedback cannot be empty. Please Enter correct feedback.");
                            }
                            else
                            {
                                Console.WriteLine("Thanks for your Feedback.");
                                break;
                            }
                        }
                        StoreFeedback(feedbacks, feedbackCount);
                        feedbackCount++;
                        break;

                    case 0:
                        Console.WriteLine(" ");
                        budget = 0;
                        tempBudget = budget;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;


                }
                if (choice != 0)
                {
                    Console.WriteLine("\n\nPress any key to go back to Menu.... ");
                    Console.ReadKey();
                }

            }
        }
    }
}
