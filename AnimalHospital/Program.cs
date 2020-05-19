using System;
using System.Collections.Generic;

namespace AnimalHospital
{
    class Program
    {
        public static Hospital hospital;
        static void Main(string[] args)
        {
            // starter en funktion der vil blive defineret længere nede i koden
            hospital = InitializeHospital();
            // starts a loop
            while (MainMenu()) { }

            Console.WriteLine("Goodbye!");
        }

        // start a loop that is true and running 
        static bool MainMenu()
        {
            // en masse console.writeline med noget text der vil blive vidst hver gang programmet looper
            Console.Clear();
            Console.WriteLine("Welcome to {0}. You have the following options:", hospital.name);
            Console.WriteLine("1. Admit a patient to the hospital");
            Console.WriteLine("2. Discharge a patient");
            Console.WriteLine("3. See a list of all patients in the hospital");
            Console.WriteLine("4. See a list of all doctors in the hospital");
            Console.WriteLine("5. Assign a specific doctor to a specific patient");
            Console.WriteLine("0. Quit the Program");
            Console.WriteLine();

            // console.readkey virker sådan at du kan kun skrive et bogstav eller tal og den gemmer så den værdi til senere brug
            var k = Console.ReadKey().KeyChar;
            // tjekker om k er lig med 1 
            if (k == '1')
            {
                // starter functionen AdmitPatient, som er defineret sidst i koden 
                AdmitPatient();
            }
            // tjekker om k er lig med 2
            else if (k == '2')
            {
                // definere en string til senere brug
                string navn;

                Console.WriteLine("Navnet på personen");
                // siger at navn som er en string vi definerede længere oppe skal være lig med console.readline
                navn = Console.ReadLine();
                
                // vi siger fjerne skal være lig med funktionen FindPatientByname(navn)
                Patient fjerne = hospital.FindPatientByName(navn);
                // kører funktionen DischargePatient fra hospital, hvor fjerne kommer med som værdi
                hospital.DischargePatient(fjerne);
            }
            // tjekker om k er lig med 3
            else if (k == '3')
            {

                foreach (Patient i in hospital.patients)
                {
                    Console.WriteLine(i.name);
                }
            }
            // tjekker om k er lig med 4
            else if (k == '4')
            {
                // kører funktionen DoktorList som er defineret længere nede
                DoktorList();

            }
            // tjekker om k er lig med 5
            else if (k == '5')
            {
                Console.WriteLine("Not yet implemented!");
            }
            // tjekker om k er lig med 0
            else if (k == '0')
            {
                // returner false hvilket gør at vores loop stopper og lukker programmet
                return false;
            }
            // sender dig herhen hvis du skriver et bogstav i den første console.readkey
            Console.WriteLine("Press any key to continue...");
            // skriv et tal eller bogstav
            Console.ReadKey();
            // returner true hvilket vil sige programmet starter forfra igen
            return true;
        }

        static void AdmitPatient()
        {
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine();

            Console.WriteLine("What is the patients age?");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("You must write a number, try again");
            }

            new Patient(name, age).AdmitTo(hospital);
        }

        static Hospital InitializeHospital()
        {
            Hospital hospital = new Hospital("Animal Hospital");

            hospital.doctors.AddRange(new Doctor[]
            {
                new Doctor("Matt Tennant", "Spinal Injury"),
                new Doctor("David Smith", "Knee Injury"),
                new Doctor("Jodie Tyler", "Oncology"),
                new Doctor("Rose Whitaker", "Intensive Care")
            });

            return hospital;
        }
        static void DoktorList()
        {
            List<string> Dliste = new List<string>();
            Dliste.Add("Matt Tennant, Spinal Injury");
            Dliste.Add("David Smith, Knee Injury");
            Dliste.Add("Jodie Tyler, Oncology");
            Dliste.Add("Rose Whitaker, Intensive Care");

            Dliste.ForEach(Console.WriteLine);
        }
    }
}
