using System;

namespace AnimalHospital
{
    class Program
    {
        public static Hospital hospital;
        static void Main(string[] args)
        {
            hospital = InitializeHospital();
            while (MainMenu()) {}

            Console.WriteLine("Goodbye!");
        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to {0}. You have the following options:", hospital.name);
            Console.WriteLine("1. Admit a patient to the hospital");
            Console.WriteLine("2. Discharge a patient");
            Console.WriteLine("3. See a list of all patients in the hospital");
            Console.WriteLine("4. See a list of all doctors in the hospital");
            Console.WriteLine("5. Assign a specific doctor to a specific patient");
            Console.WriteLine("0. Quit the Program");
            Console.WriteLine();

            var k = Console.ReadKey().KeyChar;
            if(k == '1')
            {
                AdmitPatient();
            } 
            else if(k == '2')
            {
                Console.WriteLine("Not yet implemented!");
            } 
            else if(k == '3')
            {
                Console.WriteLine("Not yet implemented!");
            }
            else if (k == '4')
            {
                Console.WriteLine("Not yet implemented!");
            }
            else if (k == '5')
            {
                Console.WriteLine("Not yet implemented!");
            }
            else if (k == '0')
            {
                return false;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        static void AdmitPatient()
        {
            string name;
            int age;

            Console.WriteLine("What is the patients name?");
            name = Console.ReadLine();

            Console.WriteLine("What is the patients age?");
            while(!int.TryParse(Console.ReadLine(), out age))
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
    }
}
