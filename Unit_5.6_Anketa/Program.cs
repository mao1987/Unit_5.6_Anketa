using System;

namespace Unit_5._6_Anketa
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAnketa(GetAnketa());
        }

        
        public static (string Name, string LastName, int Age, bool IsPet, int PetAmount, string[] PetsName, int AmountFavCorors, string[] FavColors) GetAnketa()
        {
            (string Name, string LastName, int Age, bool IsPet, int PetAmount, string[] PetsName, int AmountFavCorors, string[] FavColors) User;
            
            Console.WriteLine("Введите имя:");
            User.Name = Console.ReadLine();
            
            Console.WriteLine("Введите фамилию:");
            User.LastName = Console.ReadLine();            
            
            string age;
            int truenumber;
            do
            {
                Console.WriteLine("Введите возраст:");
                age = Console.ReadLine();
            } while (CheckData(age, out truenumber));
            User.Age = truenumber;
            
            Console.WriteLine("Наличие питомца (введите '+' или '-'):");
            string Pet = Console.ReadLine();            
            if (Pet == "+")
            {
                User.IsPet = true;                
                
                string petamount;                
                do
                {
                    Console.WriteLine("Количество питомцев:");
                    petamount = Console.ReadLine();
                } while (CheckData(petamount, out truenumber));
                User.PetAmount = truenumber;

                User.PetsName = GetPet(User.PetAmount);
            }
            else
            {
                User.IsPet = false;
                User.PetAmount = 0;
                User.PetsName = new string[0];
            }
                        
            string amountfavcolors;            
            do
            {
                Console.WriteLine("Введите количество любимых цветов (минимум = '1'):");
                amountfavcolors = Console.ReadLine();
            } while (CheckData(amountfavcolors, out truenumber));
            User.AmountFavCorors = truenumber;

            User.FavColors = GetColors(User.AmountFavCorors);

            return User;
        }
        
        public static void ShowAnketa((string Name, string LastName, int Age, bool IsPet, int PetAmount, string[] PetsName, int AmountFavCorors, string[] FavColors) User)
        {
            Console.WriteLine("*******Анкета пользователя*******\nИмя пользователя: {0}", User.Name);
            Console.WriteLine("Фамилия пользователя: {0}", User.LastName);
            Console.WriteLine("Возраст пользователя: {0}", User.Age);
            if (User.IsPet)
            {
                Console.WriteLine("Наличие питомца(ев): ДА");
                for (int count = 0; count < User.PetAmount; count++)
                {
                    Console.WriteLine("Питомец №{0}: {1}", count + 1, User.PetsName[count]);
                }
            }
            Console.WriteLine("Количество любимых цветов: {0}", User.AmountFavCorors);
            for (int count = 0; count < User.AmountFavCorors; count++)
            {
                Console.WriteLine("Любимый цвет №{0}: {1}", count + 1, User.FavColors[count]);
            }
            Console.WriteLine("*******Конец анкеты*******");
        }
        
        public static string[] GetPet(int PetAmount)
        {
            string[] PetsName = new string[PetAmount];
            for (int i = 0; i < PetAmount; i++)
            {
                Console.WriteLine("Введите кличку питомца №{0}", i + 1);
                PetsName[i] = Console.ReadLine();
            }
            return PetsName;
        }

        public static string[] GetColors(int AmountFavCorors)
        {
            string[] FavColors = new string[AmountFavCorors];
            for (int i = 0; i < AmountFavCorors; i++)
            {
                Console.WriteLine("Введите любимый цвет №{0}", i + 1);
                FavColors[i] = Console.ReadLine();
            }
            return FavColors;
        }

        public static bool CheckData(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int truenumber))
            {
                if (truenumber > 0)
                {
                    corrnumber = truenumber;
                    return false;
                }
            }            
            {
                corrnumber = 0;
                return true;
            }
        }        
    }
}