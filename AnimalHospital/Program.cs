using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;


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
                foreach (Doctor i in hospital.doctors)
                {
                    Console.WriteLine(i.name);
                }
                // kører funktionen DoktorList som er defineret længere nede
                DoktorList();

            }
            // tjekker om k er lig med 5
            else if (k == '5')
            {
                Doktorogpatientt();  
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
            // definere en int og string uden værdi som kan bruges længere nede
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            // laver en Console.Readline, hvor værdien af den bliver gemt i name, som vi definerede længere oppe som en string
            name = Console.ReadLine();

            Console.WriteLine("What is the patients age?");
            // køre et loop, hvor man tvinger loopet til kun at godtage tal og console.readline værdien bliver gemt i age som er en int
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("You must write a number, try again");
            }
            // opretter patienten i patients, med værdien fra console.readline
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
        // Her bliver der oprettede nr5 i menuen med at give en patient en doctor
        static void Doktorogpatientt()
        {
            // Her bliver der oprettede navne på alle patienter og doctore så vi kan se hvem der er på hospitalet
            Console.WriteLine();
            Console.WriteLine("Patienter");
            foreach (Patient i in hospital.patients)
            {
                Console.WriteLine(i.name);
            }

            Console.WriteLine("");
            Console.WriteLine("Doctor");
            foreach (Doctor i in hospital.doctors)
            {
                Console.WriteLine(i.name);
            }

            Console.WriteLine();
            Console.WriteLine("Vælg en patient");

            // Her begynder vi rigtigt efter vi er gået ind på 5 i menuen hvor vi skriver ned først og så doctoren
            string okay = Console.ReadLine();
            for (int i = 0; i < hospital.patients.Count; i++)
            {
                string pations = hospital.patients[i].name;
                if (okay == pations)
                {
                   string pat = hospital.patients[i].name;
                   Console.WriteLine("patienten er " + pat );
                }
            }
            Console.WriteLine("Vælg en doctor til patienten");
            string okay1 = Console.ReadLine();
            for (int i = 0; i < hospital.doctors.Count; i++)
            {
                string doctors = hospital.doctors[i].name;
                if (okay1 == doctors)
                {
                    string doc = hospital.doctors[i].name;
                    Console.WriteLine("doctoren der bliver udladveret er " + doc + " som personens doctor");
                }
            }
        }
        // Her bliver der oprettede nr4 i menuen som så gør at vi kan se alle doctorende i hospitalet
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
